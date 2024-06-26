﻿// <auto-generated />
using System;
using ArtPortfolio.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArtPortfolio.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtPortfolio.Domain.Entities.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProfilePictureUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biography = "Dutch post-impressionist painter.",
                            DateOfBirth = new DateTime(1853, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "vincent.vangogh@example.com",
                            FirstName = "Vincent",
                            LastName = "van Gogh",
                            ProfilePictureUrl = "images/artist/vangogh.jpg",
                            Website = "https://www.vangoghgallery.com/"
                        },
                        new
                        {
                            Id = 2,
                            Biography = "Dutch draughtsman, painter, and printmaker.",
                            DateOfBirth = new DateTime(1606, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "rembrandt@example.com",
                            FirstName = "Rembrandt",
                            LastName = "van Rijn",
                            ProfilePictureUrl = "images/artist/rembrandt.jpg",
                            Website = "https://www.rembrandthuis.nl/"
                        });
                });

            modelBuilder.Entity("ArtPortfolio.Domain.Entities.Artwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Dimensions")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Medium")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Artworks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistId = 1,
                            CreationDate = new DateTime(1889, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Starry Night is one of the most recognized pieces of art in the world. It depicts the view from the east-facing window of his asylum room at Saint-Rémy-de-Provence, just before sunrise, with the addition of an ideal village. The swirling patterns in the sky, the glowing moon and stars, and the sleepy village below create a dynamic and captivating scene that exemplifies his unique style. This painting captures the turbulence and beauty of the night sky, evoking deep emotions and awe.",
                            Dimensions = "73.7 cm × 92.1 cm",
                            ImageUrl = "images/artwork/starrynight.jpg",
                            Medium = "Oil on canvas",
                            Title = "Starry Night"
                        },
                        new
                        {
                            Id = 2,
                            ArtistId = 1,
                            CreationDate = new DateTime(1888, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sunflowers is a series of paintings that are among the most famous works of Vincent van Gogh. These paintings were created to decorate the room of his friend and fellow artist, Paul Gauguin. The bright and vivid yellows, combined with the dynamic brushstrokes, capture the essence of the flowers in various stages of life, from full bloom to withering. The series reflects Van Gogh's fascination with the beauty of nature and his innovative approach to color and composition.",
                            Dimensions = "95 cm × 73 cm",
                            ImageUrl = "images/artwork/sunflowers.jpg",
                            Medium = "Oil on canvas",
                            Title = "Sunflowers"
                        },
                        new
                        {
                            Id = 3,
                            ArtistId = 1,
                            CreationDate = new DateTime(1888, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Bedroom is one of Vincent van Gogh's best-known works. It depicts his own bedroom in Arles, France, with bright and bold colors intended to express absolute 'rest' or 'sleep.' The skewed perspective, the vibrant palette, and the simplicity of the room's furnishings convey a sense of tranquility and personal space. This painting reflects his longing for a place of comfort and refuge, and its intimate nature makes it a touching piece of his collection.",
                            Dimensions = "72 cm × 90 cm",
                            ImageUrl = "images/artwork/thebedroom.jpg",
                            Medium = "Oil on canvas",
                            Title = "The Bedroom"
                        },
                        new
                        {
                            Id = 4,
                            ArtistId = 2,
                            CreationDate = new DateTime(1642, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Night Watch is one of the most famous Dutch Golden Age paintings. It depicts a group of city guards moving out, led by Captain Frans Banning Cocq and his lieutenant, Willem van Ruytenburch. The painting is renowned for its colossal size, dramatic use of light and shadow (tenebrism), and the perception of motion in what would have traditionally been a static military group portrait. The intricate details, such as the expressions of the guards, the play of light, and the overall composition, draw viewers into the dynamic scene.",
                            Dimensions = "363 cm × 437 cm",
                            ImageUrl = "images/artwork/nightwatch.jpg",
                            Medium = "Oil on canvas",
                            Title = "The Night Watch"
                        },
                        new
                        {
                            Id = 5,
                            ArtistId = 2,
                            CreationDate = new DateTime(1632, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Anatomy Lesson of Dr. Nicolaes Tulp is a group portrait of Dr. Tulp and several other Amsterdam surgeons. It captures a public dissection, a common practice for medical education at the time. The painting stands out for its realistic portrayal of the human anatomy and the lifelike depiction of the surgeons' faces. The lighting highlights the central figures, creating a stark contrast with the dark background, which enhances the dramatic effect. This work is a prime example of Rembrandt's skill in rendering texture, expression, and atmosphere.",
                            Dimensions = "169.5 cm × 216.5 cm",
                            ImageUrl = "images/artwork/anatomylesson.jpg",
                            Medium = "Oil on canvas",
                            Title = "The Anatomy Lesson of Dr. Nicolaes Tulp"
                        },
                        new
                        {
                            Id = 6,
                            ArtistId = 2,
                            CreationDate = new DateTime(1665, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Self-Portrait with Two Circles is a powerful self-portrait that showcases Rembrandt's mastery of chiaroscuro and his deep understanding of human emotion. In this painting, Rembrandt presents himself as an older man, holding his tools and standing confidently in front of two mysterious circles. The circles have been interpreted in various ways, but they add an element of intrigue to the composition. The detailed rendering of his face and the rich textures of his clothing reflect his introspective and honest approach to self-portraiture.",
                            Dimensions = "114.3 cm × 94 cm",
                            ImageUrl = "images/artwork/selfportrait.jpg",
                            Medium = "Oil on canvas",
                            Title = "Self-Portrait with Two Circles"
                        });
                });

            modelBuilder.Entity("ArtPortfolio.Domain.Entities.Artwork", b =>
                {
                    b.HasOne("ArtPortfolio.Domain.Entities.Artist", "Artist")
                        .WithMany("Artworks")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("ArtPortfolio.Domain.Entities.Artist", b =>
                {
                    b.Navigation("Artworks");
                });
#pragma warning restore 612, 618
        }
    }
}
