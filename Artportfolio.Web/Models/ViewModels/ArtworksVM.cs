using ArtPortfolio.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace ArtPortfolio.Web.Models.ViewModels {
	public class ArtworksVM {
		public bool IsLoggedIn { get; set; }
		public IList<string> UserRoles { get; set; }
		public int? UserArtistId { get; set; }

		public IPagedList<Artwork> Artworks { get; set; }
		public PagedListRenderOptions PaginationOptions { get; set; }
	}
}
