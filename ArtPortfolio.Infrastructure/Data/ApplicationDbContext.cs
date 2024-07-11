using ArtPortfolio.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtPortfolio.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Artist> Artists { get; set; }

    public DbSet<Artwork> Artworks { get; set; }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

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
                ProfilePictureUrl = "/images/artist/vangogh.jpg",
                DateOfBirth = new DateTime(1853, 3, 30)
            },
            new Artist {
                Id = 2,
                FirstName = "Rembrandt",
                LastName = "van Rijn",
                Biography = "Dutch draughtsman, painter, and printmaker.",
                Email = "rembrandt@example.com",
                Website = "https://www.rembrandthuis.nl/",
                ProfilePictureUrl = "/images/artist/rembrandt.jpg",
                DateOfBirth = new DateTime(1606, 7, 15)
            },
            new Artist {
                Id = 3,
                FirstName = "Gustaf",
                LastName = "Cederström",
                Biography = "Swedish painter known for his historical genre paintings.",
                Email = "gustaf.cederstrom@example.com",
                Website = "https://www.nationalmuseum.se/en/gustaf-cederstrom",
                ProfilePictureUrl = "/images/artist/cederstrom.jpg",
                DateOfBirth = new DateTime(1845, 4, 12)
            }
        );

        // Seed data for ApplicationUser
        modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser {
                Id = "1", // Use a unique string identifier
                UserName = "vincent.vangogh",
                NormalizedUserName = "VINCENT.VANGOGH",
                Email = "vincent.vangogh@example.com",
                NormalizedEmail = "VINCENT.VANGOGH@EXAMPLE.COM",
                Name = "Vincent van Gogh",
                CreatedAt = DateTime.UtcNow,
                ArtistId = 1
            },
            new ApplicationUser {
                Id = "2", // Use a unique string identifier
                UserName = "rembrandt",
                NormalizedUserName = "REMBRANDT",
                Email = "rembrandt@example.com",
                NormalizedEmail = "REMBRANDT@EXAMPLE.COM",
                Name = "Rembrandt van Rijn",
                CreatedAt = DateTime.UtcNow,
                ArtistId = 2
            },
            new ApplicationUser {
                Id = "3", // Use a unique string identifier
                UserName = "gustaf.cederstrom",
                NormalizedUserName = "GUSTAF.CEDERSTROM",
                Email = "gustaf.cederstrom@example.com",
                NormalizedEmail = "GUSTAF.CEDERSTROM@EXAMPLE.COM",
                Name = "Gustaf Cederström",
                CreatedAt = DateTime.UtcNow,
                ArtistId = 3
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
            ImageUrl = "/images/artwork/starrynight.jpg",
            ArtistId = 1
        },
        new Artwork {
            Id = 2,
            Title = "Sunflowers",
            Description = "Sunflowers is a series of still-life paintings by Vincent van Gogh. These paintings depict sunflowers in various stages of life, from budding to withering. Van Gogh's use of vibrant yellows and textured brushstrokes captures the vitality and beauty of these flowers, showcasing his mastery of color and composition.",
            CreationDate = new DateTime(1888, 8, 1),
            Medium = "Oil on canvas",
            Dimensions = "95 cm × 73 cm",
            ImageUrl = "/images/artwork/sunflowers.jpg",
            ArtistId = 1
        },
        new Artwork {
            Id = 3,
            Title = "The Bedroom",
            Description = "The Bedroom is a series of three paintings by Vincent van Gogh. This particular piece depicts Van Gogh's bedroom in Arles, France, with its distinctive furnishings and vibrant colors. The skewed perspective and bold brushwork reflect Van Gogh's emotional and psychological state during his time in Arles, emphasizing his longing for a place of peace and solitude.",
            CreationDate = new DateTime(1888, 10, 1),
            Medium = "Oil on canvas",
            Dimensions = "72 cm × 90 cm",
            ImageUrl = "/images/artwork/thebedroom.jpg",
            ArtistId = 1
        },
        new Artwork {
            Id = 4,
            Title = "Irises",
            Description = "Irises is a painting by Vincent van Gogh, notable for its vibrant blue and purple tones. Van Gogh painted this piece while staying at the asylum in Saint-Rémy-de-Provence, where he found solace in the beauty of the irises growing in the garden. The swirling brushstrokes and expressive use of color capture Van Gogh's emotional depth and connection to nature.",
            CreationDate = new DateTime(1889, 5, 1),
            Medium = "Oil on canvas",
            Dimensions = "71 cm × 93 cm",
            ImageUrl = "/images/artwork/irises.jpg",
            ArtistId = 1
        },
        new Artwork {
            Id = 5,
            Title = "Self-Portrait with Bandaged Ear",
            Description = "Self-Portrait with Bandaged Ear is a self-portrait by Vincent van Gogh, painted shortly after he famously cut off part of his own ear. The painting reflects Van Gogh's resilience and introspection during a turbulent period in his life. The bandaged ear and intense gaze convey the artist's emotional turmoil and artistic identity.",
            CreationDate = new DateTime(1889, 1, 1),
            Medium = "Oil on canvas",
            Dimensions = "60 cm × 49 cm",
            ImageUrl = "/images/artwork/selfportraitbandagedear.jpg",
            ArtistId = 1
        },
        new Artwork {
            Id = 6,
            Title = "Wheatfield with Crows",
            Description = "Wheatfield with Crows is one of Vincent van Gogh's final paintings, completed shortly before his death. The painting depicts a dramatic, stormy sky over a wheatfield with dark, ominous crows flying overhead. The turbulent atmosphere and bold brushstrokes convey Van Gogh's emotional turmoil and his fascination with the contrasts of life and death.",
            CreationDate = new DateTime(1890, 7, 1),
            Medium = "Oil on canvas",
            Dimensions = "50 cm × 103 cm",
            ImageUrl = "/images/artwork/wheatfieldwithcrows.jpg",
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
            ImageUrl = "/images/artwork/nightwatch.jpg",
            ArtistId = 2
        },
        new Artwork {
            Id = 8,
            Title = "The Anatomy Lesson of Dr. Nicolaes Tulp",
            Description = "The Anatomy Lesson of Dr. Nicolaes Tulp is a group portrait painted by Rembrandt van Rijn. It depicts Dr. Tulp demonstrating a dissection to medical professionals. Rembrandt's meticulous attention to detail and the dramatic use of light and shadow highlight the scientific and human drama of the scene, making it a masterpiece of Baroque art.",
            CreationDate = new DateTime(1632, 1, 1),
            Medium = "Oil on canvas",
            Dimensions = "169.5 cm × 216.5 cm",
            ImageUrl = "/images/artwork/anatomylesson.jpg",
            ArtistId = 2
        },
        new Artwork {
            Id = 9,
            Title = "Self-Portrait with Two Circles",
            Description = "Self-Portrait with Two Circles is a notable self-portrait by Rembrandt van Rijn. The circles in the background have been interpreted in various ways, from symbols of artistic perfection to religious and philosophical meanings. Rembrandt's skillful portrayal of himself reflects his introspective nature and mastery of chiaroscuro.",
            CreationDate = new DateTime(1665, 1, 1),
            Medium = "Oil on canvas",
            Dimensions = "114.3 cm × 94 cm",
            ImageUrl = "/images/artwork/selfportrait.jpg",
            ArtistId = 2
        },
        new Artwork {
            Id = 10,
            Title = "The Jewish Bride",
            Description = "The Jewish Bride is a portrait painting by Rembrandt van Rijn. Also known as Isaac and Rebecca, the painting depicts a tender moment between a Jewish groom and his bride. Rembrandt's sensitive portrayal captures the emotional intimacy and dignity of the couple, making it one of his most renowned works.",
            CreationDate = new DateTime(1667, 1, 1),
            Medium = "Oil on canvas",
            Dimensions = "121.5 cm × 166.5 cm",
            ImageUrl = "/images/artwork/jewishbride.jpg",
            ArtistId = 2
        },
        new Artwork {
            Id = 11,
            Title = "The Storm on the Sea of Galilee",
            Description = "The Storm on the Sea of Galilee is a dramatic painting by Rembrandt van Rijn. It depicts the biblical scene of Jesus calming the storm on the Sea of Galilee. Rembrandt's use of light and shadow intensifies the chaos of the storm and the calm authority of Jesus, capturing both the physical and spiritual dimensions of the event.",
            CreationDate = new DateTime(1633, 1, 1),
            Medium = "Oil on canvas",
            Dimensions = "160 cm × 128 cm",
            ImageUrl = "/images/artwork/stormontheseaofgalilee.jpg",
            ArtistId = 2
        },
        new Artwork {
            Id = 12,
            Title = "The Syndics of the Drapers' Guild",
            Description = "The Syndics of the Drapers' Guild is a group portrait by Rembrandt van Rijn. Commissioned by the cloth merchants' guild in Amsterdam, the painting depicts five syndics inspecting cloth samples. Rembrandt's meticulous attention to detail and the dignified portrayal of the subjects exemplify his mastery of portraiture and narrative composition.",
            CreationDate = new DateTime(1662, 1, 1),
            Medium = "Oil on canvas",
            Dimensions = "191.5 cm × 279 cm",
            ImageUrl = "/images/artwork/syndicsofthedrapersguild.jpg",
            ArtistId = 2
        },
        // Gustaf Cederström's Artworks
        new Artwork {
            Id = 13,
            Title = "Bringing Home the Body of King Karl XII",
            Description = "Bringing Home the Body of King Karl XII depicts the moment when Swedish soldiers carry the body of King Karl XII back to Sweden after his death in Norway. The somber scene captures the mourning and respect of his subjects.",
            CreationDate = new DateTime(1878, 1, 1),
            Medium = "Oil on canvas",
            Dimensions = "295 cm × 395 cm",
            ImageUrl = "/images/artwork/karlxii.jpg",
            ArtistId = 3
        },
        new Artwork {
            Id = 14,
            Title = "The Death of Sten Sture the Younger",
            Description = "The Death of Sten Sture the Younger portrays the Swedish regent succumbing to his wounds after the Battle of Bogesund.",
            CreationDate = new DateTime(1880, 1, 1),
            Medium = "Oil on canvas",
            Dimensions = "220 cm × 250 cm",
            ImageUrl = "/images/artwork/stensture.jpg",
            ArtistId = 3
        },
        new Artwork {
            Id = 15,
            Title = "Magnus Stenbock at Helsingborg",
            Description = "Magnus Stenbock at Helsingborg depicts the Swedish general in a dramatic pose, egging on his men to expel the Danish invasion of Scania.",
            CreationDate = new DateTime(1923, 1, 1),
            Medium = "Oil on canvas",
            Dimensions = "220 cm × 144 cm",
            ImageUrl = "/images/artwork/stenbock.jpg",
            ArtistId = 3
        },
        new Artwork {
            Id = 16,
            Title = "Narva",
            Description = "Narva is a historical painting depicting the decisive Swedish victory at Narva during the Great Northern War. The painting captures the surrender of the Russian army.",
            CreationDate = new DateTime(1910, 1, 1),
            Medium = "Oil on canvas",
            Dimensions = "295 cm × 395 cm",
            ImageUrl = "/images/artwork/narva.jpg",
            ArtistId = 3
        },
        new Artwork {
            Id = 17,
            Title = "David and Goliath",
            Description = "David and Goliath is a painting that depicts a tense and dramatic moment involving duelists, with swords drawn and a confrontation imminent.",
            CreationDate = new DateTime(1918, 1, 1),
            Medium = "Oil on canvas",
            Dimensions = "98 cm × 129 cm",
            ImageUrl = "/images/artwork/david.jpg",
            ArtistId = 3
        },
        new Artwork {
            Id = 18,
            Title = "Waiting Carolean",
            Description = "Waiting Carolean is a historical painting by Gustaf Cederström. The painting captures a Carolean in a moment of contemplation, leaning against a windowsill in his cottage.",
            CreationDate = new DateTime(1918, 1, 1),
            Medium = "Oil on canvas",
            Dimensions = "75 cm × 57.5 cm",
            ImageUrl = "/images/artwork/waitingcarolean.jpg",
            ArtistId = 3
        }
    );
    }
}
