using ArtPortfolio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtPortfolio.Data
{
    public class ArtPortfolioDbContext : DbContext {
		public DbSet<Artist> Artists { get; set; }
		public DbSet<Artwork> Artworks { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer("YourConnectionStringHere");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			// Configuring the one-to-many relationship
			modelBuilder.Entity<Artwork>()
				.HasOne(a => a.Artist)
				.WithMany(b => b.Artworks)
				.HasForeignKey(a => a.ArtistId);
		}
	}
}
