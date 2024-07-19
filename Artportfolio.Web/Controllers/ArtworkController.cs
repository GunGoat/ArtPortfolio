using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Application.Common.Utility;
using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Web.Models.ViewModels;
using LinqKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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

	public async Task<IActionResult> Index(int? page, string? sortBy, string? timeSpan, string? query) {
        int pageSize = 12;
        int pageNumber = page ?? 1;

        // Define the initial predicate as true (no filter)
		var predicate = PredicateBuilder.New<Artwork>(true);

        // Set the timespan
        if (!string.IsNullOrEmpty(timeSpan)) {
            predicate = timeSpan switch {
                SD.TimeSpan_Year => predicate.And(artwork => artwork.CreationDate > DateTime.Now.AddDays(-365)),
                SD.TimeSpan_Month => predicate.And(artwork => artwork.CreationDate > DateTime.Now.AddMonths(-31)),
                SD.TimeSpan_Week => predicate.And(artwork => artwork.CreationDate > DateTime.Now.AddDays(-7)),
                _ => predicate 
            };
        }

		// search the query
		if (!string.IsNullOrEmpty(query)) {
			var loweredQuery = query.ToLower();
			predicate = predicate.And(artwork => artwork.Title.ToLower().Contains(loweredQuery) ||
												 artwork.Description.ToLower().Contains(loweredQuery));
		}

        // Perform the query to database
		var artworks = _unitOfWork.Artwork.GetAll(predicate, includeProperties: "Artist");

        // Order the resulting data
		if (!string.IsNullOrEmpty(sortBy)) {
            artworks = sortBy switch {
                SD.SortBy_Date_Ascending => artworks.OrderBy(artwork => artwork.CreationDate),
                SD.SortBy_Date_Descending => artworks.OrderByDescending(artwork => artwork.CreationDate),
                SD.SortBy_Title_Ascending => artworks.OrderBy(artwork => artwork.Title),
                SD.SortBy_Title_Descending => artworks.OrderByDescending(artwork => artwork.Title),
                SD.SortBy_Price_Ascending => artworks.OrderBy(artwork => artwork.Price),
                SD.SortBy_Price_Descending => artworks.OrderByDescending(artwork => artwork.Price),
                _ => artworks
            };
        }

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
    // [Authorize(Policy = SD.Policy_Artwork_Create)]
    public IActionResult Create(Artwork artwork) {
        // Removing ImageUrl from ModelState so it does not affect the validation
        ModelState.Remove("ImageUrl");
        if (ModelState.IsValid && artwork.Image is not null) {
            if (artwork.Image is not null) {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(artwork.Image.FileName)}";
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, artworkImagesPath);
                using var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create);
                artwork.Image.CopyTo(fileStream);
                artwork.ImageUrl = $@"\{artworkImagesPath}\{fileName}";
            }

            _unitOfWork.Artwork.Add(artwork);
            _unitOfWork.Artwork.Save();
            TempData["success"] = "The artwork has been created successfully.";
            return RedirectToAction(nameof(Index));
        }
        TempData["error"] = "The artwork could not be created.";
        return View();
    }

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
    // [Authorize(Policy = SD.Policy_Artwork_Update_Delete)]
    public IActionResult Update(Artwork artwork) {
        if (ModelState.IsValid) {
            if (artwork.Image is not null) {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(artwork.Image.FileName)}";
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, artworkImagesPath);
                var oldImage = Path.Combine(_webHostEnvironment.WebRootPath, artwork.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImage)) {
                    System.IO.File.Delete(oldImage);
                }
                using var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create);
                artwork.Image.CopyTo(fileStream);
                artwork.ImageUrl = $@"\{artworkImagesPath}\{fileName}";
            }

            _unitOfWork.Artwork.Update(artwork);
            _unitOfWork.Artwork.Save();
            TempData["success"] = "The artwork has been updated successfully.";
            return RedirectToAction(nameof(Index));
        }
        TempData["error"] = "The artwork could not be updated.";
        return View();
    }

    public IActionResult Delete(int id) {
        Artwork? artworkFromDb = _unitOfWork.Artwork.Get(artwork => artwork.Id == id, includeProperties: "Artist");
        if (artworkFromDb is null) {
            return RedirectToAction("Error", "Home");
        }
        return View(artworkFromDb);
    }

    [HttpPost]
    //[Authorize(Policy = SD.Policy_Artwork_Update_Delete)]
    public IActionResult Delete(Artwork artwork) {
        int id = artwork.Id;
        Artwork? artworkFromDb = _unitOfWork.Artwork.Get(artwork => artwork.Id == id, includeProperties: "Artist");
        if (artworkFromDb is not null) {
            if (!string.IsNullOrEmpty(artworkFromDb.ImageUrl)) {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, artworkFromDb.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath)) {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _unitOfWork.Artwork.Remove(artworkFromDb);
            _unitOfWork.Artwork.Save();
            TempData["success"] = "The artwork has been deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
        TempData["error"] = "The artwork could not be deleted.";
        return View();
    }
}
