using ArtPortfolio.Application.Common.Utility;
using ArtPortfolio.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ArtPortfolio.Infrastructure.Data;

public class AccountRequirement : IAuthorizationRequirement { }

public class AccountHandler : AuthorizationHandler<AccountRequirement> {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountHandler(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager) {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AccountRequirement requirement) {
        var user = await _userManager.GetUserAsync(context.User);
        if (user == null) {
            context.Fail();
            return;
        }

        var httpContext = _httpContextAccessor.HttpContext;
        var artistIdString = httpContext.Request.Form["ArtistId"].FirstOrDefault();
        int.TryParse(artistIdString, out int artistId);

        if (context.User.IsInRole(SD.Role_Artist)) {
            context.Succeed(requirement);
        }
        else if (context.User.IsInRole(SD.Role_Admin) && user.ArtistId == artistId) {
            context.Succeed(requirement);
        }
        else {
            context.Fail();
        }
    }
}
