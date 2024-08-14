using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using ArtPortfolio.Application.Common.Utility;
using System.Linq.Expressions;
using Microsoft.IdentityModel.Tokens;
using ArtPortfolio.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ArtPortfolio.Web.Controllers;

public class ArtistController : Controller {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private const string artistImagesPath = @"images\artist";

    public ArtistController(IUnitOfWork unitOfWork,
                             UserManager<ApplicationUser> userManager,
                             SignInManager<ApplicationUser> signInManager,
                             IWebHostEnvironment webHostEnvironment) {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _signInManager = signInManager;
        _webHostEnvironment = webHostEnvironment;
    }

    #region ACTION METHODS
    public async Task<IActionResult> Index(int? page, string? sortBy, string? timeSpan, string? searchQuery) {
        var filter = Filter(timeSpan: timeSpan, searchQuery: searchQuery);
        var artists = _unitOfWork.Artist.GetAll(filter, includeProperties: "Artworks");
        artists = SortArtists(artists, sortBy);
        var user = await _userManager.GetUserAsync(User);
        var artistsVM = new ArtistsVM {
            Artists = artists,
            IsAdmin = User.IsInRole(SD.Role_Admin),
            ArtistId = user?.ArtistId,
        };
        return View(artistsVM);
    }


    // CREATE ARTIST
    public async Task<IActionResult> Create() { 
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(Artist artist) {
        var user = await _userManager.GetUserAsync(User);
        if (user.ArtistId.HasValue) {
            TempData["error"] = $"The artist could not be created, account is already linked to an artist profile (id = {user.ArtistId}).";
            return RedirectToAction("Index", "Home");
        }

        ModelState.Remove("ProfilePictureUrl");
        if (ModelState.IsValid && artist.ProfilePicture is not null && string.IsNullOrEmpty(artist.ProfilePictureUrl)) {
            SaveArtistProfilePicture(artist);
            _unitOfWork.Artist.Add(artist);
            _unitOfWork.Artist.Save();
            user.ArtistId = artist.Id;
            _unitOfWork.ApplicationUser.Update(user);
            _unitOfWork.ApplicationUser.Save();
            TempData["success"] = "The artist has been created successfully.";
            return RedirectToAction(nameof(Index));
        }
        TempData["error"] = "The artist could not be created.";
        return View();
    }


    // UPDATE ARTIST
    public async Task<IActionResult> Update(int id) {
        var user = await _userManager.GetUserAsync(User);
        var validationResult = ValidateUser(user, id);
        if (validationResult != null) return validationResult;

        var artist = _unitOfWork.Artist.Get(artist => artist.Id == id);
        if (artist is null) {
            return RedirectToAction("Error", "Home");
        }

        return View(artist);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Update(Artist artist) {
        var user = await _userManager.GetUserAsync(User);
        var validationResult = ValidateUser(user, artist.Id);
        if (validationResult != null) return validationResult;

        if (ModelState.IsValid) {
            SaveArtistProfilePicture(artist);
            _unitOfWork.Artist.Update(artist);
            _unitOfWork.Artist.Save();
            TempData["success"] = "The artist has been updated successfully.";
            return RedirectToAction(nameof(Index));
        }
        TempData["error"] = "The artist could not be updated.";
        return View();
    }


    // DELETE ARTIST
    public async Task<IActionResult> Delete(int id) {
        var user = await _userManager.GetUserAsync(User);
        var validationResult = ValidateUser(user, id);
        if (validationResult != null) return validationResult;

        Artist? artistFromDb = _unitOfWork.Artist.Get(artist => artist.Id == id);
        return View(artistFromDb);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Delete(Artist artist) {
        int id = artist.Id;
        var user = await _userManager.GetUserAsync(User);
        var validationResult = ValidateUser(user, id);
        if (validationResult != null) return validationResult;

        Artist? artistFromDb = _unitOfWork.Artist.Get(artist => artist.Id == id, includeProperties: "Artworks");
        ApplicationUser? userFromDb = _unitOfWork.ApplicationUser.Get(user => user.ArtistId == id);
        if (artistFromDb is not null && userFromDb is not null) {
            DeleteArtistProfilePicture(artistFromDb);
            foreach (var artwork in artistFromDb.Artworks) {
                DeleteArtworkImage(artwork);
            };
            _unitOfWork.Artist.Remove(artistFromDb);
            _unitOfWork.Artist.Save();
            userFromDb.ArtistId = null;
            _unitOfWork.ApplicationUser.Update(userFromDb);
            _unitOfWork.ApplicationUser.Save();
            TempData["success"] = "The artist has been deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
        TempData["error"] = "The artist could not be deleted.";
        return View();
    }
    #endregion

    #region PRIVATE METHODS
    // <summary>
    /// Validates the user based on their sign-in status, artist profile linkage, and optional artist access permissions.
    /// </summary>
    /// <param name="user">The user to validate. Must be non-null and linked to an artist profile.</param>
    /// <param name="artistId">An optional artist ID. If provided, additional checks are performed to ensure the user has 
    /// appropriate permissions to access the artist profile.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> that redirects to the "Index" action of the "Home" controller with an error message 
    /// if validation fails. Returns null if validation is successful.
    /// </returns>
    private IActionResult ValidateUser(ApplicationUser user, int? artistId = null) {
        if (user is null) {
            TempData["error"] = "This action could not be completed; the user must be signed in.";
            return RedirectToAction("Index", "Home");
        }
        if (!user.ArtistId.HasValue) {
            TempData["error"] = "This action could not be completed; the account is not linked to an artist profile.";
            return RedirectToAction("Index", "Home");
        }

        if (artistId.HasValue) {
            // Check if the user is an admin or if the user's ArtistId matches the provided ArtistId
            if (!User.IsInRole(SD.Role_Admin) && user.ArtistId != artistId.Value) {
                TempData["error"] = "You do not have permission to access this artist profile.";
                return RedirectToAction("Error", "Home");
            }
        }

        return null;
    }

    /// <summary>
    /// Sorts a collection of artists based on the specified sorting criteria.
    /// </summary>
    /// <param name="artists">The collection of artists to be sorted.</param>
    /// <param name="sortBy">
    /// The sorting criteria, which can be one of the following values:
    /// <list type="bullet">
    /// <item><description>SD.SortBy_Date_Ascending</description></item>
    /// <item><description>SD.SortBy_Date_Descending</description></item>
    /// <item><description>SD.SortBy_Name_Ascending</description></item>
    /// <item><description>SD.SortBy_Name_Descending</description></item>
    /// </list>
    /// If an invalid value is provided, the artists will be sorted by date of birth in ascending order by default.
    /// </param>
    /// <returns>
    /// A sorted collection of artists based on the specified criteria.
    /// </returns>
    private IEnumerable<Artist> SortArtists(IEnumerable<Artist> artists, string sortBy) {
        return sortBy switch {
            SD.SortBy_Date_Ascending => artists.OrderBy(artist => artist.DateOfBirth),
            SD.SortBy_Date_Descending => artists.OrderByDescending(artist => artist.DateOfBirth),
            SD.SortBy_Name_Ascending => artists.OrderBy(artist => artist.FullName),
            SD.SortBy_Name_Descending => artists.OrderByDescending(artist => artist.FullName),
            _ => artists.OrderBy(artist => artist.DateOfBirth)
        };
    }

    /// <summary>
    /// Constructs a filter expression for artists based on the provided time span and query.
    /// </summary>
    /// <param name="timeSpan">The time span filter (e.g., "year", "month", "week").</param>
    /// <param name="query">The search query for artist first names or last names.</param>
    /// <returns>
    /// A lambda expression representing the filter criteria for artists,
    /// or null if no filter criteria are specified.
    /// </returns>
    private Expression<Func<Artist, bool>>? Filter(
        string? timeSpan = null,
        string? searchQuery = null) {
        var predicate = PredicateBuilder.True<Artist>();

        if (!string.IsNullOrEmpty(searchQuery)) {
            var queryNormalized = searchQuery.ToLower();
            predicate = predicate.And(artist => artist.FirstName.ToLower().Contains(queryNormalized) ||
                                                artist.LastName.ToLower().Contains(queryNormalized) ||
                                                artist.Biography.ToLower().Contains(queryNormalized));
        }

        // This does not really make sense, since we can't expect the artist to be one year old or younger
        // Probably should modify this attribute in the form or adding creation date for the artist account...
        if (!string.IsNullOrEmpty(timeSpan)) {
            DateTime? dateTime = timeSpan.ToLower() switch {
                var ts when ts == SD.TimeSpan_Year.ToLower() => DateTime.Now.AddYears(-1),
                var ts when ts == SD.TimeSpan_Month.ToLower() => DateTime.Now.AddMonths(-1),
                var ts when ts == SD.TimeSpan_Week.ToLower() => DateTime.Now.AddDays(-7),
                _ => null
            };
            if (dateTime.HasValue) {
                predicate = predicate.And(artist => artist.DateOfBirth >= dateTime.Value);
            }
        }

        return predicate;
    }

    /// <summary>
    /// Deletes the image file associated with the given artwork from the server.
    /// </summary>
    /// <param name="artwork">The artwork whose image file is to be deleted.</param>
    private void DeleteArtworkImage(Artwork artwork) {
        if (!string.IsNullOrEmpty(artwork.ImageUrl)) {
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, artwork.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath)) {
                System.IO.File.Delete(oldImagePath);
            }
        }
    }

    /// <summary>
    /// Deletes the profile picture file associated with the given artist from the server.
    /// </summary>
    /// <param name="artist">The artist whose profile picture file is to be deleted.</param>
    private void DeleteArtistProfilePicture(Artist artist) {
        if (!string.IsNullOrEmpty(artist.ProfilePictureUrl)) {
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, artist.ProfilePictureUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath)) {
                System.IO.File.Delete(oldImagePath);
            }
        }
    }

    /// <summary>
    /// Saves the profile picture file associated with the given artist to the server.
    /// </summary>
    /// <param name="artist">The artist whose profile picture file is to be saved.</param>
    private void SaveArtistProfilePicture(Artist artist) {
        if (artist.ProfilePicture is not null) {
            // Remove old profile picture if present
            DeleteArtistProfilePicture(artist);
            // Upload new profile picture
            var newImageName = $"{Guid.NewGuid()}{Path.GetExtension(artist.ProfilePicture.FileName)}";
            var newImagePath = Path.Combine(_webHostEnvironment.WebRootPath, artistImagesPath);
            using var fileStream = new FileStream(Path.Combine(newImagePath, newImageName), FileMode.Create);
            artist.ProfilePicture.CopyTo(fileStream);
            artist.ProfilePictureUrl = $@"\{artistImagesPath}\{newImageName}";
        }
    }
    #endregion

}
