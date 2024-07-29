using ArtPortfolio.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace ArtPortfolio.Web.Models.ViewModels;

public class ArtworksVM {
	public string SortBy { get; set; }
	public string TimeSpan { get; set; }
	public string SearchQuery { get; set; }
}
