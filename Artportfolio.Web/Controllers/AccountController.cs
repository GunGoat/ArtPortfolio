using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Web.Models.ViewModels;
using ArtPortfolio.Application.Common.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace ArtPortfolio.Web.Controllers;

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

    public async Task<IActionResult> Logout() {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied() {
        return View();
    }

    public IActionResult Login(string? returnUrl = null) {
        LoginVM loginVM = new() {
            RedirectUrl = (returnUrl ?? Url.Content("~/"))
        };
        return View(loginVM);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginVM) {
        if (ModelState.IsValid) {
            var result = await _signInManager
                .PasswordSignInAsync(loginVM.Email, loginVM.Password, loginVM.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded) {
                if (string.IsNullOrEmpty(loginVM.RedirectUrl)) {
                    return RedirectToAction("Index", "Home");
                }
                else {
                    return LocalRedirect(loginVM.RedirectUrl);
                }
            }
            else {
                ModelState.AddModelError("", "Invalid login attempt.");
            }
        }

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

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpVM signUpVM) {

        if (ModelState.IsValid) {
            ApplicationUser user = new() {
                Name = signUpVM.Name,
                Email = signUpVM.Email,
                PhoneNumber = signUpVM.PhoneNumber,
                NormalizedEmail = signUpVM.Email.ToUpper(),
                EmailConfirmed = true,
                UserName = signUpVM.Email,
                CreatedAt = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, signUpVM.Password);

            if (result.Succeeded) {
                if (!string.IsNullOrEmpty(signUpVM.Role)) {
                    await _userManager.AddToRoleAsync(user, signUpVM.Role);
                }
                else {
                    await _userManager.AddToRoleAsync(user, SD.Role_Artist);
                }

                await _signInManager.SignInAsync(user, isPersistent: false);
                if (string.IsNullOrEmpty(signUpVM.RedirectUrl)) {
                    return RedirectToAction("Index", "Home");
                }
                else {
                    return LocalRedirect(signUpVM.RedirectUrl);
                }
            }

            foreach (var error in result.Errors) {
                ModelState.AddModelError("", error.Description);
            }
        }

        signUpVM.RoleList = _roleManager.Roles.Select(x => new SelectListItem {
            Text = x.Name,
            Value = x.Name
        });

        return View(signUpVM);
    }
}
