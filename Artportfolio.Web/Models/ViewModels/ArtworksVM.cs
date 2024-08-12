using ArtPortfolio.Domain.Entities;

namespace ArtPortfolio.Web.Models.ViewModels;

public class ArtworksVM {
	public string SortBy { get; set; }
	public string TimeSpan { get; set; }
	public string SearchQuery { get; set; }
}
