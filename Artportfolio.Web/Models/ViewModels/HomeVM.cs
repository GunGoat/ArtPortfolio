using ArtPortfolio.Domain.Entities;

namespace ArtPortfolio.Web.Models.ViewModels;
public class HomeVM {
    public string UserName { get; set; }
    public bool IsAdmin { get; set; }
    public Artist? Artist { get; set; } 
}