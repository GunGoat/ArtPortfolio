﻿// <auto-generated />
using System;
using ArtPortfolio.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArtPortfolio.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240712151021_SeedDataApplicationUserWithRoles")]
    partial class SeedDataApplicationUserWithRoles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtPortfolio.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ArtistId = 1,
                            ConcurrencyStamp = "faac567b-6f90-41d5-a305-149bf16331f8",
                            CreatedAt = new DateTime(2024, 7, 12, 15, 10, 21, 215, DateTimeKind.Utc).AddTicks(5488),
                            Email = "vincent.vangogh@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Name = "Vincent van Gogh",
                            NormalizedEmail = "VINCENT.VANGOGH@EXAMPLE.COM",
                            NormalizedUserName = "VINCENT.VANGOGH",
                            PasswordHash = "AQAAAAIAAYagAAAAEEbesS5scZBx9ZnVZyYCucUPwwik8YEvuHFoSAdkz14PgNtrYM5OwaLcrGf+6tG4bQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ae5e74e1-a0c2-4bc9-a2fa-d7a632d16d4b",
                            TwoFactorEnabled = false,
                            UserName = "vincent.vangogh"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ArtistId = 2,
                            ConcurrencyStamp = "5fa8c87f-d9c2-4344-94d7-6807ee8b1e36",
                            CreatedAt = new DateTime(2024, 7, 12, 15, 10, 21, 300, DateTimeKind.Utc).AddTicks(341),
                            Email = "rembrandt@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Name = "Rembrandt van Rijn",
                            NormalizedEmail = "REMBRANDT@EXAMPLE.COM",
                            NormalizedUserName = "REMBRANDT",
                            PasswordHash = "AQAAAAIAAYagAAAAEM8QKwiIy+GJ/YRXwhn9n2qfnNxD3ZzNNkyxRYtLyktaNMcKy6xt9yfoe+mWWXDBIg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "117f8640-412c-4f30-a0c3-4fdef8edbda7",
                            TwoFactorEnabled = false,
                            UserName = "rembrandt"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ArtistId = 3,
                            ConcurrencyStamp = "4811bb42-0b96-44ed-af5c-75debe2e4588",
                            CreatedAt = new DateTime(2024, 7, 12, 15, 10, 21, 385, DateTimeKind.Utc).AddTicks(2895),
                            Email = "gustaf.cederstrom@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Name = "Gustaf Cederström",
                            NormalizedEmail = "GUSTAF.CEDERSTROM@EXAMPLE.COM",
                            NormalizedUserName = "GUSTAF.CEDERSTROM",
                            PasswordHash = "AQAAAAIAAYagAAAAEO7kksqwfX7CpBok7hbj1nP6EFsOUB2+Rimdmdww0ODRi4RTvhXpNggTC/5d9PGWuQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c2130390-077c-4d1e-91d9-37ed07bd8d3a",
                            TwoFactorEnabled = false,
                            UserName = "gustaf.cederstrom"
                        });
                });

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
                            ProfilePictureUrl = "/images/artist/vangogh.jpg",
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
                            ProfilePictureUrl = "/images/artist/rembrandt.jpg",
                            Website = "https://www.rembrandthuis.nl/"
                        },
                        new
                        {
                            Id = 3,
                            Biography = "Swedish painter known for his historical genre paintings.",
                            DateOfBirth = new DateTime(1845, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "gustaf.cederstrom@example.com",
                            FirstName = "Gustaf",
                            LastName = "Cederström",
                            ProfilePictureUrl = "/images/artist/cederstrom.jpg",
                            Website = "https://www.nationalmuseum.se/en/gustaf-cederstrom"
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
                            Description = "Starry Night is one of Vincent van Gogh's most famous paintings. It depicts the night sky over Saint-Rémy-de-Provence in swirling patterns of light and color. The bright stars and crescent moon contrast with the dark, rolling hills and the sleepy village below, capturing Van Gogh's unique style and emotional intensity.",
                            Dimensions = "73.7 cm × 92.1 cm",
                            ImageUrl = "/images/artwork/starrynight.jpg",
                            Medium = "Oil on canvas",
                            Title = "Starry Night"
                        },
                        new
                        {
                            Id = 2,
                            ArtistId = 1,
                            CreationDate = new DateTime(1888, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sunflowers is a series of still-life paintings by Vincent van Gogh. These paintings depict sunflowers in various stages of life, from budding to withering. Van Gogh's use of vibrant yellows and textured brushstrokes captures the vitality and beauty of these flowers, showcasing his mastery of color and composition.",
                            Dimensions = "95 cm × 73 cm",
                            ImageUrl = "/images/artwork/sunflowers.jpg",
                            Medium = "Oil on canvas",
                            Title = "Sunflowers"
                        },
                        new
                        {
                            Id = 3,
                            ArtistId = 1,
                            CreationDate = new DateTime(1888, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Bedroom is a series of three paintings by Vincent van Gogh. This particular piece depicts Van Gogh's bedroom in Arles, France, with its distinctive furnishings and vibrant colors. The skewed perspective and bold brushwork reflect Van Gogh's emotional and psychological state during his time in Arles, emphasizing his longing for a place of peace and solitude.",
                            Dimensions = "72 cm × 90 cm",
                            ImageUrl = "/images/artwork/thebedroom.jpg",
                            Medium = "Oil on canvas",
                            Title = "The Bedroom"
                        },
                        new
                        {
                            Id = 4,
                            ArtistId = 1,
                            CreationDate = new DateTime(1889, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Irises is a painting by Vincent van Gogh, notable for its vibrant blue and purple tones. Van Gogh painted this piece while staying at the asylum in Saint-Rémy-de-Provence, where he found solace in the beauty of the irises growing in the garden. The swirling brushstrokes and expressive use of color capture Van Gogh's emotional depth and connection to nature.",
                            Dimensions = "71 cm × 93 cm",
                            ImageUrl = "/images/artwork/irises.jpg",
                            Medium = "Oil on canvas",
                            Title = "Irises"
                        },
                        new
                        {
                            Id = 5,
                            ArtistId = 1,
                            CreationDate = new DateTime(1889, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Self-Portrait with Bandaged Ear is a self-portrait by Vincent van Gogh, painted shortly after he famously cut off part of his own ear. The painting reflects Van Gogh's resilience and introspection during a turbulent period in his life. The bandaged ear and intense gaze convey the artist's emotional turmoil and artistic identity.",
                            Dimensions = "60 cm × 49 cm",
                            ImageUrl = "/images/artwork/selfportraitbandagedear.jpg",
                            Medium = "Oil on canvas",
                            Title = "Self-Portrait with Bandaged Ear"
                        },
                        new
                        {
                            Id = 6,
                            ArtistId = 1,
                            CreationDate = new DateTime(1890, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Wheatfield with Crows is one of Vincent van Gogh's final paintings, completed shortly before his death. The painting depicts a dramatic, stormy sky over a wheatfield with dark, ominous crows flying overhead. The turbulent atmosphere and bold brushstrokes convey Van Gogh's emotional turmoil and his fascination with the contrasts of life and death.",
                            Dimensions = "50 cm × 103 cm",
                            ImageUrl = "/images/artwork/wheatfieldwithcrows.jpg",
                            Medium = "Oil on canvas",
                            Title = "Wheatfield with Crows"
                        },
                        new
                        {
                            Id = 7,
                            ArtistId = 2,
                            CreationDate = new DateTime(1642, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Night Watch is one of the most famous paintings by Rembrandt van Rijn. Also known as The Militia Company of Captain Frans Banning Cocq, the painting depicts a group of city guards preparing for a march. Rembrandt's use of light and shadow creates a dynamic composition, emphasizing movement and individual character among the figures.",
                            Dimensions = "363 cm × 437 cm",
                            ImageUrl = "/images/artwork/nightwatch.jpg",
                            Medium = "Oil on canvas",
                            Title = "The Night Watch"
                        },
                        new
                        {
                            Id = 8,
                            ArtistId = 2,
                            CreationDate = new DateTime(1632, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Anatomy Lesson of Dr. Nicolaes Tulp is a group portrait painted by Rembrandt van Rijn. It depicts Dr. Tulp demonstrating a dissection to medical professionals. Rembrandt's meticulous attention to detail and the dramatic use of light and shadow highlight the scientific and human drama of the scene, making it a masterpiece of Baroque art.",
                            Dimensions = "169.5 cm × 216.5 cm",
                            ImageUrl = "/images/artwork/anatomylesson.jpg",
                            Medium = "Oil on canvas",
                            Title = "The Anatomy Lesson of Dr. Nicolaes Tulp"
                        },
                        new
                        {
                            Id = 9,
                            ArtistId = 2,
                            CreationDate = new DateTime(1665, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Self-Portrait with Two Circles is a notable self-portrait by Rembrandt van Rijn. The circles in the background have been interpreted in various ways, from symbols of artistic perfection to religious and philosophical meanings. Rembrandt's skillful portrayal of himself reflects his introspective nature and mastery of chiaroscuro.",
                            Dimensions = "114.3 cm × 94 cm",
                            ImageUrl = "/images/artwork/selfportrait.jpg",
                            Medium = "Oil on canvas",
                            Title = "Self-Portrait with Two Circles"
                        },
                        new
                        {
                            Id = 10,
                            ArtistId = 2,
                            CreationDate = new DateTime(1667, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Jewish Bride is a portrait painting by Rembrandt van Rijn. Also known as Isaac and Rebecca, the painting depicts a tender moment between a Jewish groom and his bride. Rembrandt's sensitive portrayal captures the emotional intimacy and dignity of the couple, making it one of his most renowned works.",
                            Dimensions = "121.5 cm × 166.5 cm",
                            ImageUrl = "/images/artwork/jewishbride.jpg",
                            Medium = "Oil on canvas",
                            Title = "The Jewish Bride"
                        },
                        new
                        {
                            Id = 11,
                            ArtistId = 2,
                            CreationDate = new DateTime(1633, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Storm on the Sea of Galilee is a dramatic painting by Rembrandt van Rijn. It depicts the biblical scene of Jesus calming the storm on the Sea of Galilee. Rembrandt's use of light and shadow intensifies the chaos of the storm and the calm authority of Jesus, capturing both the physical and spiritual dimensions of the event.",
                            Dimensions = "160 cm × 128 cm",
                            ImageUrl = "/images/artwork/stormontheseaofgalilee.jpg",
                            Medium = "Oil on canvas",
                            Title = "The Storm on the Sea of Galilee"
                        },
                        new
                        {
                            Id = 12,
                            ArtistId = 2,
                            CreationDate = new DateTime(1662, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Syndics of the Drapers' Guild is a group portrait by Rembrandt van Rijn. Commissioned by the cloth merchants' guild in Amsterdam, the painting depicts five syndics inspecting cloth samples. Rembrandt's meticulous attention to detail and the dignified portrayal of the subjects exemplify his mastery of portraiture and narrative composition.",
                            Dimensions = "191.5 cm × 279 cm",
                            ImageUrl = "/images/artwork/syndicsofthedrapersguild.jpg",
                            Medium = "Oil on canvas",
                            Title = "The Syndics of the Drapers' Guild"
                        },
                        new
                        {
                            Id = 13,
                            ArtistId = 3,
                            CreationDate = new DateTime(1878, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Bringing Home the Body of King Karl XII depicts the moment when Swedish soldiers carry the body of King Karl XII back to Sweden after his death in Norway. The somber scene captures the mourning and respect of his subjects.",
                            Dimensions = "295 cm × 395 cm",
                            ImageUrl = "/images/artwork/karlxii.jpg",
                            Medium = "Oil on canvas",
                            Title = "Bringing Home the Body of King Karl XII"
                        },
                        new
                        {
                            Id = 14,
                            ArtistId = 3,
                            CreationDate = new DateTime(1880, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Death of Sten Sture the Younger portrays the Swedish regent succumbing to his wounds after the Battle of Bogesund.",
                            Dimensions = "220 cm × 250 cm",
                            ImageUrl = "/images/artwork/stensture.jpg",
                            Medium = "Oil on canvas",
                            Title = "The Death of Sten Sture the Younger"
                        },
                        new
                        {
                            Id = 15,
                            ArtistId = 3,
                            CreationDate = new DateTime(1923, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Magnus Stenbock at Helsingborg depicts the Swedish general in a dramatic pose, egging on his men to expel the Danish invasion of Scania.",
                            Dimensions = "220 cm × 144 cm",
                            ImageUrl = "/images/artwork/stenbock.jpg",
                            Medium = "Oil on canvas",
                            Title = "Magnus Stenbock at Helsingborg"
                        },
                        new
                        {
                            Id = 16,
                            ArtistId = 3,
                            CreationDate = new DateTime(1910, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Narva is a historical painting depicting the decisive Swedish victory at Narva during the Great Northern War. The painting captures the surrender of the Russian army.",
                            Dimensions = "295 cm × 395 cm",
                            ImageUrl = "/images/artwork/narva.jpg",
                            Medium = "Oil on canvas",
                            Title = "Narva"
                        },
                        new
                        {
                            Id = 17,
                            ArtistId = 3,
                            CreationDate = new DateTime(1918, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "David and Goliath is a painting that depicts a tense and dramatic moment involving duelists, with swords drawn and a confrontation imminent.",
                            Dimensions = "98 cm × 129 cm",
                            ImageUrl = "/images/artwork/david.jpg",
                            Medium = "Oil on canvas",
                            Title = "David and Goliath"
                        },
                        new
                        {
                            Id = 18,
                            ArtistId = 3,
                            CreationDate = new DateTime(1918, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Waiting Carolean is a historical painting by Gustaf Cederström. The painting captures a Carolean in a moment of contemplation, leaning against a windowsill in his cottage.",
                            Dimensions = "75 cm × 57.5 cm",
                            ImageUrl = "/images/artwork/waitingcarolean.jpg",
                            Medium = "Oil on canvas",
                            Title = "Waiting Carolean"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "b2b691ad-e7f1-4dac-9fe7-bcb93bb0a544",
                            Name = "Artist",
                            NormalizedName = "ARTIST"
                        },
                        new
                        {
                            Id = "5dc3b373-93ab-455e-afb9-364a77d5a728",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            RoleId = "b2b691ad-e7f1-4dac-9fe7-bcb93bb0a544"
                        },
                        new
                        {
                            UserId = "2",
                            RoleId = "b2b691ad-e7f1-4dac-9fe7-bcb93bb0a544"
                        },
                        new
                        {
                            UserId = "3",
                            RoleId = "b2b691ad-e7f1-4dac-9fe7-bcb93bb0a544"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ArtPortfolio.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ArtPortfolio.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArtPortfolio.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ArtPortfolio.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArtPortfolio.Domain.Entities.Artist", b =>
                {
                    b.Navigation("Artworks");
                });
#pragma warning restore 612, 618
        }
    }
}
