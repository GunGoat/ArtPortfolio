using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArtPortfolio.Web.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, 
							  UserManager<ApplicationUser> userManager, 
							  SignInManager<ApplicationUser> signInManager, 
							  IUnitOfWork unitOfWork) {
			_logger = logger;
			_userManager = userManager;
			_signInManager = signInManager;
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index() {
			//if (_signInManager.IsSignedIn(User) is false) {
			//	return RedirectToAction("Index", "Artwork");
			//}
            return View();
		}

		public IActionResult Privacy() {
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
