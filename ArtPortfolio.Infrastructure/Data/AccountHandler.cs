using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Application.Common.Utility;
using ArtPortfolio.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace ArtPortfolio.Infrastructure.Data;

public class ArtworkUpdateOrDeleteRequirement : IAuthorizationRequirement { }
public class ArtworkCreateRequirement : IAuthorizationRequirement { }

public class AccountHandler : AuthorizationHandler<IAuthorizationRequirement> {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;

    public AccountHandler(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork) {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IAuthorizationRequirement requirement) {
        var user = await _userManager.GetUserAsync(context.User);
        if (user == null) {
            context.Fail();
            return;
        }

        if (requirement is ArtworkUpdateOrDeleteRequirement) {
            await HandleAccountRequirement(context, (ArtworkUpdateOrDeleteRequirement)requirement, user);
        }
        else if (requirement is ArtworkCreateRequirement) {
            await HandleArtworkCreateRequirement(context, (ArtworkCreateRequirement)requirement, user);
        }
    }

    private async Task HandleAccountRequirement(AuthorizationHandlerContext context, ArtworkUpdateOrDeleteRequirement requirement, ApplicationUser user) {
        var httpContext = _httpContextAccessor.HttpContext;
        var artworkIdString = httpContext.Request.Form["Id"].FirstOrDefault();

        if (context.User.IsInRole(SD.Role_Admin)) {
            context.Succeed(requirement);
        }
        else if (context.User.IsInRole(SD.Role_Artist) &&
                   int.TryParse(artworkIdString, out int artworkId) &&
                   _unitOfWork.Artwork.Any(artwork => artwork.Id == artworkId && artwork.ArtistId == user.ArtistId)) {
            context.Succeed(requirement);
        }
        else {
            context.Fail();
        }
    }

    private async Task HandleArtworkCreateRequirement(AuthorizationHandlerContext context, ArtworkCreateRequirement requirement, ApplicationUser user) {
        if (context.User.IsInRole(SD.Role_Admin) || context.User.IsInRole(SD.Role_Artist)) {
            context.Succeed(requirement);
        }
        else {
            context.Fail();
        }
    }
}
