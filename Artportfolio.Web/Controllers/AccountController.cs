using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Web.Models.ViewModels;
using ArtPortfolio.Application.Common.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArtPortfolio.Web.Controllers {
    public class AccountController : Controller {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager) {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string? returnUrl = null) {
            LoginVM loginVM = new() {
                RedirectUrl = (returnUrl ?? Url.Content("~/"))
            };
            return View(loginVM);
        }

        public IActionResult SignUp() {
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult()) {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).Wait();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Artist)).Wait();
            }

            SignUpVM registerVM = new() {
                RoleList = _roleManager.Roles.Select(role => new SelectListItem {
                    Text = role.Name,
                    Value = role.Name
                })
            };

            return View(registerVM);
        }
    }
}
