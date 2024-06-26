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
                ProfilePictureUrl = "images/artist/vangogh.jpg",
                DateOfBirth = new DateTime(1853, 3, 30)
            },
            new Artist {
                Id = 2,
                FirstName = "Rembrandt",
                LastName = "van Rijn",
                Biography = "Dutch draughtsman, painter, and printmaker.",
                Email = "rembrandt@example.com",
                Website = "https://www.rembrandthuis.nl/",
                ProfilePictureUrl = "images/artist/rembrandt.jpg",
                DateOfBirth = new DateTime(1606, 7, 15)
            }
        );

        modelBuilder.Entity<Artwork>().HasData(
            // Vincent van Gogh's Artworks
            new Artwork {
                Id = 1,
                Title = "Starry Night",
                Description = "Starry Night is one of the most recognized pieces of art in the world. It depicts the view from the east-facing window of his asylum room at Saint-Rémy-de-Provence, just before sunrise, with the addition of an ideal village. The swirling patterns in the sky, the glowing moon and stars, and the sleepy village below create a dynamic and captivating scene that exemplifies his unique style. This painting captures the turbulence and beauty of the night sky, evoking deep emotions and awe.",
                CreationDate = new DateTime(1889, 6, 1),
                Medium = "Oil on canvas",
                Dimensions = "73.7 cm × 92.1 cm",
                ImageUrl = "images/artwork/starrynight.jpg",
                ArtistId = 1
            },
            new Artwork {
                Id = 2,
                Title = "Sunflowers",
                Description = "Sunflowers is a series of paintings that are among the most famous works of Vincent van Gogh. These paintings were created to decorate the room of his friend and fellow artist, Paul Gauguin. The bright and vivid yellows, combined with the dynamic brushstrokes, capture the essence of the flowers in various stages of life, from full bloom to withering. The series reflects Van Gogh's fascination with the beauty of nature and his innovative approach to color and composition.",
                CreationDate = new DateTime(1888, 8, 1),
                Medium = "Oil on canvas",
                Dimensions = "95 cm × 73 cm",
                ImageUrl = "images/artwork/sunflowers.jpg",
                ArtistId = 1
            },
            new Artwork {
                Id = 3,
                Title = "The Bedroom",
                Description = "The Bedroom is one of Vincent van Gogh's best-known works. It depicts his own bedroom in Arles, France, with bright and bold colors intended to express absolute 'rest' or 'sleep.' The skewed perspective, the vibrant palette, and the simplicity of the room's furnishings convey a sense of tranquility and personal space. This painting reflects his longing for a place of comfort and refuge, and its intimate nature makes it a touching piece of his collection.",
                CreationDate = new DateTime(1888, 10, 1),
                Medium = "Oil on canvas",
                Dimensions = "72 cm × 90 cm",
                ImageUrl = "images/artwork/thebedroom.jpg",
                ArtistId = 1
            },
            // Rembrandt's Artworks
            new Artwork {
                Id = 4,
                Title = "The Night Watch",
                Description = "The Night Watch is one of the most famous Dutch Golden Age paintings. It depicts a group of city guards moving out, led by Captain Frans Banning Cocq and his lieutenant, Willem van Ruytenburch. The painting is renowned for its colossal size, dramatic use of light and shadow (tenebrism), and the perception of motion in what would have traditionally been a static military group portrait. The intricate details, such as the expressions of the guards, the play of light, and the overall composition, draw viewers into the dynamic scene.",
                CreationDate = new DateTime(1642, 1, 1),
                Medium = "Oil on canvas",
                Dimensions = "363 cm × 437 cm",
                ImageUrl = "images/artwork/nightwatch.jpg",
                ArtistId = 2
            },
            new Artwork {
                Id = 5,
                Title = "The Anatomy Lesson of Dr. Nicolaes Tulp",
                Description = "The Anatomy Lesson of Dr. Nicolaes Tulp is a group portrait of Dr. Tulp and several other Amsterdam surgeons. It captures a public dissection, a common practice for medical education at the time. The painting stands out for its realistic portrayal of the human anatomy and the lifelike depiction of the surgeons' faces. The lighting highlights the central figures, creating a stark contrast with the dark background, which enhances the dramatic effect. This work is a prime example of Rembrandt's skill in rendering texture, expression, and atmosphere.",
                CreationDate = new DateTime(1632, 1, 1),
                Medium = "Oil on canvas",
                Dimensions = "169.5 cm × 216.5 cm",
                ImageUrl = "images/artwork/anatomylesson.jpg",
                ArtistId = 2
            },
            new Artwork {
                Id = 6,
                Title = "Self-Portrait with Two Circles",
                Description = "Self-Portrait with Two Circles is a powerful self-portrait that showcases Rembrandt's mastery of chiaroscuro and his deep understanding of human emotion. In this painting, Rembrandt presents himself as an older man, holding his tools and standing confidently in front of two mysterious circles. The circles have been interpreted in various ways, but they add an element of intrigue to the composition. The detailed rendering of his face and the rich textures of his clothing reflect his introspective and honest approach to self-portraiture.",
                CreationDate = new DateTime(1665, 1, 1),
                Medium = "Oil on canvas",
                Dimensions = "114.3 cm × 94 cm",
                ImageUrl = "images/artwork/selfportrait.jpg",
                ArtistId = 2
            }
        );
    }
}
