using ArtPortfolio.Domain.Entities;

namespace ArtPortfolio.Web.Models.ViewModels;

public class ArtworkDetailVM {
    public Artwork Artwork { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsArtist { get; set; }
    public int? ArtistId { get; set; }
}
