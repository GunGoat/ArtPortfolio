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

	public async Task<IActionResult> Index(int? page) {
        int pageSize = 12;
        int pageNumber = page ?? 1;
        var artworks = _unitOfWork.Artwork.GetAll(includeProperties: "Artist")
                                          .ToPagedList(pageNumber, pageSize);

        var artworksVM = new ArtworksVM {
            IsLoggedIn = _signInManager.IsSignedIn(User),
            UserRoles = new List<string>(),
            UserArtistId = null,
            Artworks = artworks,
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
            Text = $"{artist.FirstName} {artist.LastName}",
            Value = artist.Id.ToString()
        });
        ViewBag.Artists = artists;
        return View();
    }

    [HttpPost]
    [Authorize(Policy = SD.Policy_Artwork_Create_Update_Delete)]
    public IActionResult Create(Artwork artwork) {
        // Removing ImageUrl from ModelState so it does not affect the validation
        ModelState.Remove("ImageUrl");
        if (ModelState.IsValid) {
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
                Text = $"{artist.FirstName} {artist.LastName}",
                Value = artist.Id.ToString()
            });
        ViewBag.Artists = artists;
        return View(artwork);
    }

    [HttpPost]
    [Authorize(Policy = SD.Policy_Artwork_Create_Update_Delete)]
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
    [Authorize(Policy = SD.Policy_Artwork_Create_Update_Delete)]
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
