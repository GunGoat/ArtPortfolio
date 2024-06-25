using ArtPortfolio.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtPortfolio.Infrastructure.Data;

public class ApplicationDbContext : DbContext {

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	public DbSet<Artist> Artists { get; set; }

	public DbSet<Artwork> Artworks { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);

		// Seed data
		modelBuilder.Entity<Artist>().HasData(
			new Artist {
				Id = 1,
				FirstName = "Vincent",
				LastName = "van Gogh",
				Biography = "Dutch post-impressionist painter.",
				Email = "vincent.vangogh@example.com",
				Website = "https://www.vangoghgallery.com/",
				ProfilePictureUrl = "https://example.com/vangogh.jpg",
				DateOfBirth = new DateTime(1853, 3, 30)
			},
			new Artist {
				Id = 2,
				FirstName = "Pablo",
				LastName = "Picasso",
				Biography = "Spanish painter, sculptor, printmaker, ceramicist and stage designer.",
				Email = "pablo.picasso@example.com",
				Website = "https://www.picasso.com/",
				ProfilePictureUrl = "https://example.com/picasso.jpg",
				DateOfBirth = new DateTime(1881, 10, 25)
			}
		);

		modelBuilder.Entity<Artwork>().HasData(
			// Vincent van Gogh's Artworks
			new Artwork {
				Id = 1,
				Title = "Starry Night",
				Description = "A famous painting by Vincent van Gogh.",
				CreationDate = new DateTime(1889, 6, 1),
				Medium = "Oil on canvas",
				Dimensions = "73.7 cm × 92.1 cm",
				ImageUrl = "https://example.com/starrynight.jpg",
				ArtistId = 1
			},
			new Artwork {
				Id = 2,
				Title = "Sunflowers",
				Description = "A series of paintings by Vincent van Gogh.",
				CreationDate = new DateTime(1888, 8, 1),
				Medium = "Oil on canvas",
				Dimensions = "95 cm × 73 cm",
				ImageUrl = "https://example.com/sunflowers.jpg",
				ArtistId = 1
			},
			new Artwork {
				Id = 3,
				Title = "The Bedroom",
				Description = "A painting by Vincent van Gogh of his bedroom.",
				CreationDate = new DateTime(1888, 10, 1),
				Medium = "Oil on canvas",
				Dimensions = "72 cm × 90 cm",
				ImageUrl = "https://example.com/thebedroom.jpg",
				ArtistId = 1
			},
			// Pablo Picasso's Artworks
			new Artwork {
				Id = 4,
				Title = "The Weeping Woman",
				Description = "A famous painting by Pablo Picasso.",
				CreationDate = new DateTime(1937, 10, 26),
				Medium = "Oil on canvas",
				Dimensions = "60 cm × 49 cm",
				ImageUrl = "https://example.com/weepingwoman.jpg",
				ArtistId = 2
			},
			new Artwork {
				Id = 5,
				Title = "Guernica",
				Description = "A mural-sized oil painting on canvas by Pablo Picasso.",
				CreationDate = new DateTime(1937, 6, 1),
				Medium = "Oil on canvas",
				Dimensions = "349 cm × 776 cm",
				ImageUrl = "https://example.com/guernica.jpg",
				ArtistId = 2
			},
			new Artwork {
				Id = 6,
				Title = "Les Demoiselles d'Avignon",
				Description = "A large oil painting created in 1907 by Pablo Picasso.",
				CreationDate = new DateTime(1907, 7, 1),
				Medium = "Oil on canvas",
				Dimensions = "243.9 cm × 233.7 cm",
				ImageUrl = "https://example.com/lesdemoiselles.jpg",
				ArtistId = 2
			}
		);
	}
}
