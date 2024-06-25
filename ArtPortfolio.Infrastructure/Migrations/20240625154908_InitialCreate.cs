using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Medium = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dimensions = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artworks_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Biography", "DateOfBirth", "Email", "FirstName", "LastName", "ProfilePictureUrl", "Website" },
                values: new object[,]
                {
                    { 1, "Dutch post-impressionist painter.", new DateTime(1853, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "vincent.vangogh@example.com", "Vincent", "van Gogh", "https://example.com/vangogh.jpg", "https://www.vangoghgallery.com/" },
                    { 2, "Spanish painter, sculptor, printmaker, ceramicist and stage designer.", new DateTime(1881, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "pablo.picasso@example.com", "Pablo", "Picasso", "https://example.com/picasso.jpg", "https://www.picasso.com/" }
                });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "Id", "ArtistId", "CreationDate", "Description", "Dimensions", "ImageUrl", "Medium", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1889, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A famous painting by Vincent van Gogh.", "73.7 cm × 92.1 cm", "https://example.com/starrynight.jpg", "Oil on canvas", "Starry Night" },
                    { 2, 1, new DateTime(1888, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A series of paintings by Vincent van Gogh.", "95 cm × 73 cm", "https://example.com/sunflowers.jpg", "Oil on canvas", "Sunflowers" },
                    { 3, 1, new DateTime(1888, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A painting by Vincent van Gogh of his bedroom.", "72 cm × 90 cm", "https://example.com/thebedroom.jpg", "Oil on canvas", "The Bedroom" },
                    { 4, 2, new DateTime(1937, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "A famous painting by Pablo Picasso.", "60 cm × 49 cm", "https://example.com/weepingwoman.jpg", "Oil on canvas", "The Weeping Woman" },
                    { 5, 2, new DateTime(1937, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A mural-sized oil painting on canvas by Pablo Picasso.", "349 cm × 776 cm", "https://example.com/guernica.jpg", "Oil on canvas", "Guernica" },
                    { 6, 2, new DateTime(1907, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A large oil painting created in 1907 by Pablo Picasso.", "243.9 cm × 233.7 cm", "https://example.com/lesdemoiselles.jpg", "Oil on canvas", "Les Demoiselles d'Avignon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ArtistId",
                table: "Artworks",
                column: "ArtistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artworks");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
