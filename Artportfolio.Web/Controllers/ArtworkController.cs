using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Application.Common.Utility;
using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq.Expressions;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace ArtPortfolio.Web.Controllers;


public class ArtworkController : Controller {
	private readonly IUnitOfWork _unitOfWork;
	private readonly IWebHostEnvironment _webHostEnvironment;
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly SignInManager<ApplicationUser> _signInManager;
	private const string artworkImagesPath = @"images\artwork";
    private static readonly PagedListRenderOptions PaginationOptions = new PagedListRenderOptions {
        DisplayLinkToFirstPage = PagedListDisplayMode.Always,
        DisplayLinkToLastPage = PagedListDisplayMode.Always,
        DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
        DisplayLinkToNextPage = PagedListDisplayMode.Always,
        DisplayLinkToIndividualPages = true,
        DisplayPageCountAndCurrentLocation = false,
        MaximumPageNumbersToDisplay = 5,
        UlElementClasses = new[] { "pagination" },
        LiElementClasses = Enumerable.Empty<string>().ToList(),
        PageClasses = new[] { "page-link" },
        FunctionToDisplayEachPageNumber = (pageNumber => pageNumber.ToString())
    };

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
    public async Task<IActionResult> Index(int? page, string? sortBy, string? timeSpan, string? query) {
        var filter = Filter(timeSpan, query);
        var artworks = _unitOfWork.Artwork.GetAll(filter, includeProperties: "Artist");
		if (!string.IsNullOrEmpty(sortBy)) {
            artworks = sortBy switch {
                SD.SortBy_Date_Ascending => artworks.OrderBy(artwork => artwork.CreationDate),
                SD.SortBy_Date_Descending => artworks.OrderByDescending(artwork => artwork.CreationDate),
                SD.SortBy_Title_Ascending => artworks.OrderBy(artwork => artwork.Title),
                SD.SortBy_Title_Descending => artworks.OrderByDescending(artwork => artwork.Title),
                SD.SortBy_Price_Ascending => artworks.OrderBy(artwork => artwork.Price),
                SD.SortBy_Price_Descending => artworks.OrderByDescending(artwork => artwork.Price),
                _ => artworks.OrderBy(artwork => artwork.CreationDate)
            };
        }

        int pageSize = 12;
        int pageNumber = page ?? 1;
        var artworksVM = new ArtworksVM {
            IsLoggedIn = _signInManager.IsSignedIn(User),
            UserRoles = new List<string>(),
            UserArtistId = null,
            Artworks = artworks.ToPagedList(pageNumber, pageSize),
            PaginationOptions = PaginationOptions
		};

		if (artworksVM.IsLoggedIn) {
			var user = await _userManager.GetUserAsync(User);
			artworksVM.UserRoles = await _userManager.GetRolesAsync(user);
			artworksVM.UserArtistId = user.ArtistId;
		}

        return View(artworksVM);
	}


    // CREATE ARTWORK
    [Authorize(Roles = SD.Role_Artist)]
    public IActionResult Create() {
        var artists = _unitOfWork.Artist.GetAll().Select(artist =>
            new SelectListItem {
                Text = artist.FullName,
                Value = artist.Id.ToString()
            });
        ViewBag.Artists = artists;
        return View();
    }

    [HttpPost]
    public IActionResult Create(Artwork artwork) {
        ModelState.Remove("ImageUrl");
        if (ModelState.IsValid && artwork.Image is not null && string.IsNullOrEmpty(artwork.ImageUrl)) {
            SaveArtworkImage(artwork);
            _unitOfWork.Artwork.Add(artwork);
            _unitOfWork.Artwork.Save();
            TempData["success"] = "The artwork has been created successfully.";
            return RedirectToAction(nameof(Index));
        }
        TempData["error"] = "The artwork could not be created.";
        return View();
    }


    // UPDATE ARTWORK
    public IActionResult Update(int id) {
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
    public IActionResult Update(Artwork artwork) {
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
    public IActionResult Delete(int id) {
        Artwork? artworkFromDb = _unitOfWork.Artwork.Get(artwork => artwork.Id == id, includeProperties: "Artist");
        if (artworkFromDb is null) {
            return RedirectToAction("Error", "Home");
        }
        return View(artworkFromDb);
    }

    [HttpPost]
    public IActionResult Delete(Artwork artwork) {
        int id = artwork.Id;
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
    /// Constructs a filter expression for artworks based on the provided time span and query.
    /// </summary>
    /// <param name="timeSpan">The time span filter (e.g., "year", "month", "week").</param>
    /// <param name="query">The search query for artwork titles, descriptions, or artist name.</param>
    /// <returns>
    /// A lambda expression representing the filter criteria for artworks,
    /// or null if no filter criteria are specified.
    /// </returns>
    private Expression<Func<Artwork, bool>>? Filter(string? timeSpan, string? query) {
        var predicate = PredicateBuilder.True<Artwork>();

        if (!string.IsNullOrEmpty(query)) {
            var queryNormalized = query.ToLower();
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
                predicate = predicate.And(artist => artist.CreationDate >= dateTime.Value);
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
