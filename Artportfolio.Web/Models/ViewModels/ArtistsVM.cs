using ArtPortfolio.Domain.Entities;

namespace ArtPortfolio.Web.Models.ViewModels;

public class ArtistsVM {
	public IEnumerable<Artist> Artists { get; set; }
	public bool IsAdmin { get; set; }
	public int? ArtistId { get; set; }
}
