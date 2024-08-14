using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Application.Common.Utility;
using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq.Expressions;

namespace ArtPortfolio.Web.Controllers;


public class ArtworkController : Controller {
	private readonly IUnitOfWork _unitOfWork;
	private readonly IWebHostEnvironment _webHostEnvironment;
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly SignInManager<ApplicationUser> _signInManager;
	private const string artworkImagesPath = @"images\artwork";
	private const int pageSize = 12;

	public ArtworkController(IUnitOfWork unitOfWork,
							 UserManager<ApplicationUser> userManager,
							 SignInManager<ApplicationUser> signInManager,
							 IWebHostEnvironment webHostEnvironment) {
		_unitOfWork = unitOfWork;
		_userManager = userManager;
		_signInManager = signInManager;
		_webHostEnvironment = webHostEnvironment;
	}

	#region ACTION METHODS
	public IActionResult Index(int? page, string? sortBy, string? timeSpan, string? searchQuery) {
		var artworksVM = new ArtworksVM {
			SortBy = sortBy ?? "",
			TimeSpan = timeSpan ?? "",
			SearchQuery = searchQuery ?? ""
		};
		return View(artworksVM);
	}

	public async Task<IActionResult> GetArtworkDetails(int id) {
		var user = await _userManager.GetUserAsync(User);
		var artwork = _unitOfWork.Artwork.Get(artwork => artwork.Id == id, includeProperties: "Artist");
		if (artwork == null) {
			return NotFound();
		}

		var model = new ArtworkDetailVM {
			Artwork = artwork,
			IsAdmin = User.IsInRole(SD.Role_Admin),
			IsArtist = User.IsInRole(SD.Role_Artist),
			ArtistId = user?.ArtistId
		};

		return PartialView("_ArtworkDetail", model);
	}

	public IActionResult LoadMoreArtworks(int page, string? sortBy, string? timeSpan, string? searchQuery, int? artistId = null) {
		page--;
		var filter = Filter(timeSpan: timeSpan, searchQuery: searchQuery, artistId: artistId);
		var artworks = _unitOfWork.Artwork.GetAll(filter, includeProperties: "Artist");
		artworks = SortArtworks(artworks, sortBy)
			.Skip(page * pageSize)
			.Take(pageSize);

		var result = artworks.Select(artwork => new {
			id = artwork.Id,
			imageUrl = artwork.ImageUrl,
			artistFullName = artwork.Artist.FullName,
			title = artwork.Title,
			creationDate = artwork.CreationDate.ToString("MMMM dd, yyyy"),
			price = artwork.Price
		}).ToList(); // Materialize the selection

		return Json(result);
	}

	// CREATE ARTWORK
	public async Task<IActionResult> Create() {
        var user = await _userManager.GetUserAsync(User);
        var validationResult = ValidateUser(user);
        if (validationResult != null) return validationResult;

        var artwork = new Artwork {
			ArtistId = user.ArtistId.Value 
		};
		return View(artwork);
	}

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(Artwork artwork) {
        var user = await _userManager.GetUserAsync(User);
        var validationResult = ValidateUser(user);
        if (validationResult != null) return validationResult;

        artwork.ArtistId = user.ArtistId.Value;
        ModelState.Remove("ImageUrl");
        if (ModelState.IsValid && artwork.Image is not null && string.IsNullOrEmpty(artwork.ImageUrl)) {
            SaveArtworkImage(artwork);
            _unitOfWork.Artwork.Add(artwork);
            _unitOfWork.Artwork.Save();
            TempData["success"] = "The artwork has been created successfully.";
            return RedirectToAction(nameof(Index));
        }
        TempData["error"] = "The artwork could not be created.";
        return View(artwork); // Pass the artwork model back to the view if validation fails
    }


    // UPDATE ARTWORK
    public async Task<IActionResult> Update(int id) {
        var user = await _userManager.GetUserAsync(User);
        var validationResult = ValidateUser(user, id);
        if (validationResult != null) return validationResult;

        var artwork = _unitOfWork.Artwork.Get(artwork => artwork.Id == id);
		if (artwork is null) {
			return RedirectToAction("Error", "Home");
		}

		var artists = _unitOfWork.Artist.GetAll().Select(artist =>
			new SelectListItem {
				Text = artist.FullName,
				Value = artist.Id.ToString()
			});
		ViewBag.Artists = artists;
		return View(artwork);
	}

	[HttpPost]
	[Authorize]
    public async Task<IActionResult> Update(Artwork artwork) {
        int id = artwork.Id;
        var user = await _userManager.GetUserAsync(User);
        var validationResult = ValidateUser(user, id);
        if (validationResult != null) return validationResult;

        if (ModelState.IsValid) {
			SaveArtworkImage(artwork);
			_unitOfWork.Artwork.Update(artwork);
			_unitOfWork.Artwork.Save();
			TempData["success"] = "The artwork has been updated successfully.";
			return RedirectToAction(nameof(Index));
		}
		TempData["error"] = "The artwork could not be updated.";
		return View();
	}


    // DELETE ARTWORK
    public async Task<IActionResult> Delete(int id) {
        var user = await _userManager.GetUserAsync(User);
        var validationResult = ValidateUser(user, id);
        if (validationResult != null) return validationResult;

        Artwork? artworkFromDb = _unitOfWork.Artwork.Get(artwork => artwork.Id == id, includeProperties: "Artist");
		return View(artworkFromDb);
	}

	[HttpPost]
	[Authorize]
    public async Task<IActionResult> Delete(Artwork artwork) {
		int id = artwork.Id;
		var user = await _userManager.GetUserAsync(User);
        var validationResult = ValidateUser(user, id);
        if (validationResult != null) return validationResult;

		Artwork? artworkFromDb = _unitOfWork.Artwork.Get(artwork => artwork.Id == id, includeProperties: "Artist");
		if (artworkFromDb is not null) {
			DeleteArtworkImage(artworkFromDb);
			_unitOfWork.Artwork.Remove(artworkFromDb);
			_unitOfWork.Artwork.Save();
			TempData["success"] = "The artwork has been deleted successfully.";
			return RedirectToAction(nameof(Index));
		}
		TempData["error"] = "The artwork could not be deleted.";
		return View();
	}
    #endregion

    #region PRIVATE METHODS

    /// <summary>
    /// Validates the user based on their sign-in status, artist profile linkage, and optional artwork access permissions.
    /// </summary>
    /// <param name="user">The user to validate. Must be non-null and linked to an artist profile.</param>
    /// <param name="artworkId">An optional artwork ID. If provided, additional checks are performed to ensure the user has 
    /// appropriate permissions to access the artwork.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> that redirects to the "Index" action of the "Home" controller with an error message 
    /// if validation fails. Returns null if validation is successful.
    /// </returns>
    private IActionResult ValidateUser(ApplicationUser user, int? artworkId = null) {
        if (user is null) {
            TempData["error"] = "This action could not be completed; the user must be signed in.";
            return RedirectToAction("Index", "Home");
        }
        if (!user.ArtistId.HasValue) {
            TempData["error"] = "This action could not be completed; the account is not linked to an artist profile.";
            return RedirectToAction("Index", "Home");
        }

        if (artworkId.HasValue) {
            var artworkWasFound = _unitOfWork.Artwork.Any(artwork => artwork.Id == artworkId.Value);
            if (!artworkWasFound) {
                TempData["error"] = "The artwork could not be found.";
                return RedirectToAction("Error", "Home");
            }

            // Check if the user is an admin or if the user's ArtistId matches the artwork's ArtistId
            var artworkPermissionToManage = _unitOfWork.Artwork.Any(artwork => artwork.Id == artworkId.Value && artwork.ArtistId == user.ArtistId);
            if (!artworkPermissionToManage) {
                TempData["error"] = "You do not have permission to access this artwork.";
                return RedirectToAction("Error", "Home");
            }
        }

        return null;
    }


    /// <summary>
    /// Sorts a collection of artworks based on the specified sorting criteria.
    /// </summary>
    /// <param name="artworks">The collection of artworks to be sorted.</param>
    /// <param name="sortBy">
    /// The sorting criteria, which can be one of the following values:
    /// <list type="bullet">
    /// <item><description>SD.SortBy_Date_Ascending</description></item>
    /// <item><description>SD.SortBy_Date_Descending</description></item>
    /// <item><description>SD.SortBy_Title_Ascending</description></item>
    /// <item><description>SD.SortBy_Title_Descending</description></item>
    /// <item><description>SD.SortBy_Price_Ascending</description></item>
    /// <item><description>SD.SortBy_Price_Descending</description></item>
    /// </list>
    /// If an invalid value is provided, the artworks will be sorted by creation date in ascending order by default.
    /// </param>
    /// <returns>
    /// A sorted collection of artworks based on the specified criteria.
    /// </returns>
    private IEnumerable<Artwork> SortArtworks(IEnumerable<Artwork> artworks, string sortBy) {
		return sortBy switch {
			SD.SortBy_Date_Ascending => artworks.OrderBy(artwork => artwork.CreationDate),
			SD.SortBy_Date_Descending => artworks.OrderByDescending(artwork => artwork.CreationDate),
			SD.SortBy_Title_Ascending => artworks.OrderBy(artwork => artwork.Title),
			SD.SortBy_Title_Descending => artworks.OrderByDescending(artwork => artwork.Title),
			SD.SortBy_Price_Ascending => artworks.OrderBy(artwork => artwork.Price),
			SD.SortBy_Price_Descending => artworks.OrderByDescending(artwork => artwork.Price),
			_ => artworks.OrderBy(artwork => artwork.CreationDate)
		};
	}

	/// <summary>
	/// Constructs a filter expression for artworks based on the provided time span, search query, and artist ID.
	/// </summary>
	/// <param name="timeSpan">The time span filter (e.g., "year", "month", "week").</param>
	/// <param name="searchQuery">The search query for artwork titles, descriptions, or artist name.</param>
	/// <param name="artistId">The ID of the artist to filter artworks by.</param>
	/// <returns>
	/// A lambda expression representing the filter criteria for artworks,
	/// or null if no filter criteria are specified.
	/// </returns>
	private Expression<Func<Artwork, bool>>? Filter(
		string? timeSpan = null,
		string? searchQuery = null,
		int? artistId = null) {
		var predicate = PredicateBuilder.True<Artwork>();

		if (!string.IsNullOrEmpty(searchQuery)) {
			var queryNormalized = searchQuery.ToLower();
			predicate = predicate.And(artwork => artwork.Title.ToLower().Contains(queryNormalized) ||
												 artwork.Description.ToLower().Contains(queryNormalized) ||
												 artwork.Artist.FirstName.ToLower().Contains(queryNormalized) ||
												 artwork.Artist.FirstName.ToLower().Contains(queryNormalized));
		}

		if (!string.IsNullOrEmpty(timeSpan)) {
			DateTime? dateTime = timeSpan.ToLower() switch {
				var ts when ts == SD.TimeSpan_Year.ToLower() => DateTime.Now.AddYears(-1),
				var ts when ts == SD.TimeSpan_Month.ToLower() => DateTime.Now.AddMonths(-1),
				var ts when ts == SD.TimeSpan_Week.ToLower() => DateTime.Now.AddDays(-7),
				_ => null
			};
			if (dateTime.HasValue) {
				predicate = predicate.And(artwork => artwork.CreationDate >= dateTime.Value);
			}
		}

		if (artistId.HasValue) {
			predicate = predicate.And(artwork => artwork.ArtistId == artistId.Value);
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
	/// Saves the image file associated with the given artwork to the server.
	/// Deletes the old image file if present.
	/// </summary>
	/// <param name="artwork">The artwork whose image file is to be saved.</param>
	private void SaveArtworkImage(Artwork artwork) {
		if (artwork.Image is not null) {
			// Remove old image if present
			DeleteArtworkImage(artwork);
			// Upload new image
			var newImageName = $"{Guid.NewGuid()}{Path.GetExtension(artwork.Image.FileName)}";
			var newImagePath = Path.Combine(_webHostEnvironment.WebRootPath, artworkImagesPath);
			using var fileStream = new FileStream(Path.Combine(newImagePath, newImageName), FileMode.Create);
			artwork.Image.CopyTo(fileStream);
			artwork.ImageUrl = $@"\{artworkImagesPath}\{newImageName}";
		}
	}
	#endregion
}
