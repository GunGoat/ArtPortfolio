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
    [Migration("20240625154908_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

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
                            ProfilePictureUrl = "https://example.com/vangogh.jpg",
                            Website = "https://www.vangoghgallery.com/"
                        },
                        new
                        {
                            Id = 2,
                            Biography = "Spanish painter, sculptor, printmaker, ceramicist and stage designer.",
                            DateOfBirth = new DateTime(1881, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "pablo.picasso@example.com",
                            FirstName = "Pablo",
                            LastName = "Picasso",
                            ProfilePictureUrl = "https://example.com/picasso.jpg",
                            Website = "https://www.picasso.com/"
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
                        .HasColumnType("nvarchar(max)");

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
                            Description = "A famous painting by Vincent van Gogh.",
                            Dimensions = "73.7 cm × 92.1 cm",
                            ImageUrl = "https://example.com/starrynight.jpg",
                            Medium = "Oil on canvas",
                            Title = "Starry Night"
                        },
                        new
                        {
                            Id = 2,
                            ArtistId = 1,
                            CreationDate = new DateTime(1888, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A series of paintings by Vincent van Gogh.",
                            Dimensions = "95 cm × 73 cm",
                            ImageUrl = "https://example.com/sunflowers.jpg",
                            Medium = "Oil on canvas",
                            Title = "Sunflowers"
                        },
                        new
                        {
                            Id = 3,
                            ArtistId = 1,
                            CreationDate = new DateTime(1888, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A painting by Vincent van Gogh of his bedroom.",
                            Dimensions = "72 cm × 90 cm",
                            ImageUrl = "https://example.com/thebedroom.jpg",
                            Medium = "Oil on canvas",
                            Title = "The Bedroom"
                        },
                        new
                        {
                            Id = 4,
                            ArtistId = 2,
                            CreationDate = new DateTime(1937, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A famous painting by Pablo Picasso.",
                            Dimensions = "60 cm × 49 cm",
                            ImageUrl = "https://example.com/weepingwoman.jpg",
                            Medium = "Oil on canvas",
                            Title = "The Weeping Woman"
                        },
                        new
                        {
                            Id = 5,
                            ArtistId = 2,
                            CreationDate = new DateTime(1937, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A mural-sized oil painting on canvas by Pablo Picasso.",
                            Dimensions = "349 cm × 776 cm",
                            ImageUrl = "https://example.com/guernica.jpg",
                            Medium = "Oil on canvas",
                            Title = "Guernica"
                        },
                        new
                        {
                            Id = 6,
                            ArtistId = 2,
                            CreationDate = new DateTime(1907, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A large oil painting created in 1907 by Pablo Picasso.",
                            Dimensions = "243.9 cm × 233.7 cm",
                            ImageUrl = "https://example.com/lesdemoiselles.jpg",
                            Medium = "Oil on canvas",
                            Title = "Les Demoiselles d'Avignon"
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
