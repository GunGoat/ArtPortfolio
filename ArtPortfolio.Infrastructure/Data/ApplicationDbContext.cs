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

        // Seed data for artists
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

        // Seed data for artworks
        modelBuilder.Entity<Artwork>().HasData(
            // Vincent van Gogh's Artworks
            new Artwork {
                Id = 1,
                Title = "Starry Night",
                Description = "Starry Night is one of Vincent van Gogh's most famous paintings. It depicts the night sky over Saint-Rémy-de-Provence in swirling patterns of light and color. The bright stars and crescent moon contrast with the dark, rolling hills and the sleepy village below, capturing Van Gogh's unique style and emotional intensity.",
                CreationDate = new DateTime(1889, 6, 1),
                Medium = "Oil on canvas",
                Dimensions = "73.7 cm × 92.1 cm",
                ImageUrl = "images/artwork/starrynight.jpg",
                ArtistId = 1
            },
            new Artwork {
                Id = 2,
                Title = "Sunflowers",
                Description = "Sunflowers is a series of still-life paintings by Vincent van Gogh. These paintings depict sunflowers in various stages of life, from budding to withering. Van Gogh's use of vibrant yellows and textured brushstrokes captures the vitality and beauty of these flowers, showcasing his mastery of color and composition.",
                CreationDate = new DateTime(1888, 8, 1),
                Medium = "Oil on canvas",
                Dimensions = "95 cm × 73 cm",
                ImageUrl = "images/artwork/sunflowers.jpg",
                ArtistId = 1
            },
            new Artwork {
                Id = 3,
                Title = "The Bedroom",
                Description = "The Bedroom is a series of three paintings by Vincent van Gogh. This particular piece depicts Van Gogh's bedroom in Arles, France, with its distinctive furnishings and vibrant colors. The skewed perspective and bold brushwork reflect Van Gogh's emotional and psychological state during his time in Arles, emphasizing his longing for a place of peace and solitude.",
                CreationDate = new DateTime(1888, 10, 1),
                Medium = "Oil on canvas",
                Dimensions = "72 cm × 90 cm",
                ImageUrl = "images/artwork/thebedroom.jpg",
                ArtistId = 1
            },
            new Artwork {
                Id = 4,
                Title = "Irises",
                Description = "Irises is a painting by Vincent van Gogh, notable for its vibrant blue and purple tones. Van Gogh painted this piece while staying at the asylum in Saint-Rémy-de-Provence, where he found solace in the beauty of the irises growing in the garden. The swirling brushstrokes and expressive use of color capture Van Gogh's emotional depth and connection to nature.",
                CreationDate = new DateTime(1889, 5, 1),
                Medium = "Oil on canvas",
                Dimensions = "71 cm × 93 cm",
                ImageUrl = "images/artwork/irises.jpg",
                ArtistId = 1
            },
            new Artwork {
                Id = 5,
                Title = "Self-Portrait with Bandaged Ear",
                Description = "Self-Portrait with Bandaged Ear is a self-portrait by Vincent van Gogh, painted shortly after he famously cut off part of his own ear. The painting reflects Van Gogh's resilience and introspection during a turbulent period in his life. The bandaged ear and intense gaze convey the artist's emotional turmoil and artistic identity.",
                CreationDate = new DateTime(1889, 1, 1),
                Medium = "Oil on canvas",
                Dimensions = "60 cm × 49 cm",
                ImageUrl = "images/artwork/selfportraitbandagedear.jpg",
                ArtistId = 1
            },
            new Artwork {
                Id = 6,
                Title = "Wheatfield with Crows",
                Description = "Wheatfield with Crows is one of Vincent van Gogh's final paintings, completed shortly before his death. The painting depicts a dramatic, stormy sky over a wheatfield with dark, ominous crows flying overhead. The turbulent atmosphere and bold brushstrokes convey Van Gogh's emotional turmoil and his fascination with the contrasts of life and death.",
                CreationDate = new DateTime(1890, 7, 1),
                Medium = "Oil on canvas",
                Dimensions = "50 cm × 103 cm",
                ImageUrl = "images/artwork/wheatfieldwithcrows.jpg",
                ArtistId = 1
            },
            // Rembrandt's Artworks
            new Artwork {
                Id = 7,
                Title = "The Night Watch",
                Description = "The Night Watch is one of the most famous paintings by Rembrandt van Rijn. Also known as The Militia Company of Captain Frans Banning Cocq, the painting depicts a group of city guards preparing for a march. Rembrandt's use of light and shadow creates a dynamic composition, emphasizing movement and individual character among the figures.",
                CreationDate = new DateTime(1642, 1, 1),
                Medium = "Oil on canvas",
                Dimensions = "363 cm × 437 cm",
                ImageUrl = "images/artwork/nightwatch.jpg",
                ArtistId = 2
            },
            new Artwork {
                Id = 8,
                Title = "The Anatomy Lesson of Dr. Nicolaes Tulp",
                Description = "The Anatomy Lesson of Dr. Nicolaes Tulp is a group portrait painted by Rembrandt van Rijn. It depicts Dr. Tulp demonstrating a dissection to medical professionals. Rembrandt's meticulous attention to detail and the dramatic use of light and shadow highlight the scientific and human drama of the scene, making it a masterpiece of Baroque art.",
                CreationDate = new DateTime(1632, 1, 1),
                Medium = "Oil on canvas",
                Dimensions = "169.5 cm × 216.5 cm",
                ImageUrl = "images/artwork/anatomylesson.jpg",
                ArtistId = 2
            },
            new Artwork {
                Id = 9,
                Title = "Self-Portrait with Two Circles",
                Description = "Self-Portrait with Two Circles is a notable self-portrait by Rembrandt van Rijn. The circles in the background have been interpreted in various ways, from symbols of artistic perfection to religious and philosophical meanings. Rembrandt's skillful portrayal of himself reflects his introspective nature and mastery of chiaroscuro.",
                CreationDate = new DateTime(1665, 1, 1),
                Medium = "Oil on canvas",
                Dimensions = "114.3 cm × 94 cm",
                ImageUrl = "images/artwork/selfportrait.jpg",
                ArtistId = 2
            },
            new Artwork {
                Id = 10,
                Title = "The Jewish Bride",
                Description = "The Jewish Bride is a portrait painting by Rembrandt van Rijn. Also known as Isaac and Rebecca, the painting depicts a tender moment between a Jewish groom and his bride. Rembrandt's sensitive portrayal captures the emotional intimacy and dignity of the couple, making it one of his most renowned works.",
                CreationDate = new DateTime(1667, 1, 1),
                Medium = "Oil on canvas",
                Dimensions = "121.5 cm × 166.5 cm",
                ImageUrl = "images/artwork/jewishbride.jpg",
                ArtistId = 2
            },
            new Artwork {
                Id = 11,
                Title = "The Storm on the Sea of Galilee",
                Description = "The Storm on the Sea of Galilee is a dramatic painting by Rembrandt van Rijn. It depicts the biblical scene of Jesus calming the storm on the Sea of Galilee. Rembrandt's use of light and shadow intensifies the chaos of the storm and the calm authority of Jesus, capturing both the physical and spiritual dimensions of the event.",
                CreationDate = new DateTime(1633, 1, 1),
                Medium = "Oil on canvas",
                Dimensions = "160 cm × 128 cm",
                ImageUrl = "images/artwork/stormontheseaofgalilee.jpg",
                ArtistId = 2
            },
            new Artwork {
                Id = 12,
                Title = "The Syndics of the Drapers' Guild",
                Description = "The Syndics of the Drapers' Guild is a group portrait by Rembrandt van Rijn. Commissioned by the cloth merchants' guild in Amsterdam, the painting depicts five syndics inspecting cloth samples. Rembrandt's meticulous attention to detail and the dignified portrayal of the subjects exemplify his mastery of portraiture and narrative composition.",
                CreationDate = new DateTime(1662, 1, 1),
                Medium = "Oil on canvas",
                Dimensions = "191.5 cm × 279 cm",
                ImageUrl = "images/artwork/syndicsofthedrapersguild.jpg",
                ArtistId = 2
            }
        );
    }

}
