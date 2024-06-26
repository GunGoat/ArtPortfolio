using ArtPortfolio.Application.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ArtPortfolio.Web.Controllers;

public class ArtworkController : Controller {
	private readonly IUnitOfWork _unitOfWork;
	private readonly IWebHostEnvironment _webHostEnvironment;

	public ArtworkController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) {
		_unitOfWork = unitOfWork;
		_webHostEnvironment = webHostEnvironment;
	}

	public IActionResult Index() {
		var artworks = _unitOfWork.Artwork.GetAll();
		return View(artworks);
	}
}
