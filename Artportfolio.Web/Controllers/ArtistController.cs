using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using ArtPortfolio.Application.Common.Utility;
using System.Linq.Expressions;
using Microsoft.IdentityModel.Tokens;

namespace ArtPortfolio.Web.Controllers;

public class ArtistController : Controller {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private const string artistImagesPath = @"images\artist";

    public ArtistController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index(int? page, string? sortBy, string? timeSpan, string? query) {
        var filter = Filter(timeSpan: timeSpan, query: query);
        var artists = _unitOfWork.Artist.GetAll(filter, includeProperties: "Artworks");
        if (!string.IsNullOrEmpty(sortBy)) {
            artists = sortBy switch {
                SD.SortBy_Date_Ascending => artists.OrderBy(artist => artist.DateOfBirth),
                SD.SortBy_Date_Descending => artists.OrderByDescending(artist => artist.DateOfBirth),
                SD.SortBy_Name_Ascending => artists.OrderBy(artist => artist.FullName),
                SD.SortBy_Name_Descending => artists.OrderByDescending(artist => artist.FullName),
                _ => artists
            };
        }

        return View(artists);
    }

    
    // FILTER ARTIST
    private Expression<Func<Artist, bool>>? Filter(string? timeSpan, string? query) {
        var predicate = PredicateBuilder.True<Artist>();

        if (!string.IsNullOrEmpty(query)) {
            var queryNormalized = query.ToLower();
            predicate = predicate.And(artist => artist.FirstName == queryNormalized ||
                                                artist.LastName == queryNormalized);
        }

        // This does not really makes sense, since we cant expect the artist to be one year olds or younger
        // Probably should modify this attribute in the form or adding creation date for the artist account...
        if(!string.IsNullOrEmpty(timeSpan)) {
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


    // CREATE ARTIST
    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Artist artist) {
        ModelState.Remove("ProfilePictureUrl");
        if (ModelState.IsValid) {
            if (artist.ProfilePicture is not null) {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(artist.ProfilePicture.FileName)}";
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, artistImagesPath);
                using var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create);
                artist.ProfilePicture.CopyTo(fileStream);
                artist.ProfilePictureUrl = $@"\{artistImagesPath}\{fileName}";
            }

            _unitOfWork.Artist.Add(artist);
            _unitOfWork.Artist.Save();
            TempData["success"] = "The artist has been created successfully.";
            return RedirectToAction(nameof(Index));
        }
        TempData["error"] = "The artist could not be created.";
        return View();
    }


    // UPDATE ARTIST
    public IActionResult Update(int id) {
        var artist = _unitOfWork.Artist.Get(artist => artist.Id == id);
        if (artist is null) {
            return RedirectToAction("Error", "Home");
        }

        return View(artist);
    }

    [HttpPost]
    public IActionResult Update(Artist artist) {
        if (ModelState.IsValid) {
            if (artist.ProfilePicture is not null) {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(artist.ProfilePicture.FileName)}";
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, artistImagesPath);
                var oldImage = Path.Combine(_webHostEnvironment.WebRootPath, artist.ProfilePictureUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImage)) {
                    System.IO.File.Delete(oldImage);
                }
                using var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create);
                artist.ProfilePicture.CopyTo(fileStream);
                artist.ProfilePictureUrl = $@"\{artistImagesPath}\{fileName}";
            }

            _unitOfWork.Artist.Update(artist);
            _unitOfWork.Artist.Save();
            TempData["success"] = "The artist has been updated successfully.";
            return RedirectToAction(nameof(Index));
        }
        TempData["error"] = "The artist could not be updated.";
        return View();
    }


    // DELETE ARTIST
    public IActionResult Delete(int id) {
        Artist? artistFromDb = _unitOfWork.Artist.Get(artist => artist.Id == id);
        if (artistFromDb is null) {
            return RedirectToAction("Error", "Home");
        }
        return View(artistFromDb);
    }

    [HttpPost]
    public IActionResult Delete(Artist artist) {
        int id = artist.Id;
        Artist? artistFromDb = _unitOfWork.Artist.Get(artwork => artwork.Id == id);
        if (artistFromDb is not null) {
            if (!string.IsNullOrEmpty(artistFromDb.ProfilePictureUrl)) {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, artistFromDb.ProfilePictureUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath)) {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _unitOfWork.Artist.Remove(artistFromDb);
            _unitOfWork.Artist.Save();
            TempData["success"] = "The artist has been deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
        TempData["error"] = "The artist could not be deleted.";
        return View();
    }
}
