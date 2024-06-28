using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ArtPortfolio.Web.Controllers;

public class ArtworkController : Controller {
	private readonly IUnitOfWork _unitOfWork;
	private readonly IWebHostEnvironment _webHostEnvironment;
    private const string artworkImagesPath = @"images\artwork";

    public ArtworkController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) {
		_unitOfWork = unitOfWork;
		_webHostEnvironment = webHostEnvironment;
	}

	public IActionResult Index() {
		var artworks = _unitOfWork.Artwork.GetAll(includeProperties: "Artist");
		return View(artworks);
	}

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
