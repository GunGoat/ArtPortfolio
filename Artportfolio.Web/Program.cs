using ArtPortfolio.Application.Common;
using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Application.Common.Utility;
using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Infrastructure.Data;
using ArtPortfolio.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adds services for controllers with views to the DI container.
builder.Services.AddControllersWithViews();

// Configures the application to use SQL Server with the connection string from configuration.
builder.Services.AddDbContext<ApplicationDbContext>(
    option => option.UseSqlServer(
        builder.Configuration["ConnectionStrings:DefaultConnection"])
);

// Registers the UnitOfWork service with the DI container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Configures Identity services with the application user and role types.
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Register the authorization handler as scoped
builder.Services.AddScoped<IAuthorizationHandler, AccountHandler>();
builder.Services.AddAuthorization(options => {
    options.AddPolicy(SD.Policy_Artwork_Create_Update_Delete, policy =>
        policy.Requirements.Add(new AccountRequirement()));
});

// Configures Identity options, such as password requirements.
builder.Services.Configure<IdentityOptions>(option => {
    option.Password.RequiredLength = 6;
});

// Configures application cookie settings like access denied and login paths.
builder.Services.ConfigureApplicationCookie(option => {
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.LoginPath = "/Account/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Adds authorization middleware to the request pipeline.
app.UseAuthorization();

// Maps controller routes with a default route.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();