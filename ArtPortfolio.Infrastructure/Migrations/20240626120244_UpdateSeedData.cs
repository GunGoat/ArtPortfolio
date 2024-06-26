using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Artworks",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePictureUrl",
                table: "Artists",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfilePictureUrl",
                value: "images/artist/vangogh.jpg");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Biography", "DateOfBirth", "Email", "FirstName", "LastName", "ProfilePictureUrl", "Website" },
                values: new object[] { "Dutch draughtsman, painter, and printmaker.", new DateTime(1606, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "rembrandt@example.com", "Rembrandt", "van Rijn", "images/artist/rembrandt.jpg", "https://www.rembrandthuis.nl/" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Starry Night is one of the most recognized pieces of art in the world. It depicts the view from the east-facing window of his asylum room at Saint-Rémy-de-Provence, just before sunrise, with the addition of an ideal village. The swirling patterns in the sky, the glowing moon and stars, and the sleepy village below create a dynamic and captivating scene that exemplifies his unique style. This painting captures the turbulence and beauty of the night sky, evoking deep emotions and awe.", "images/artwork/starrynight.jpg" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Sunflowers is a series of paintings that are among the most famous works of Vincent van Gogh. These paintings were created to decorate the room of his friend and fellow artist, Paul Gauguin. The bright and vivid yellows, combined with the dynamic brushstrokes, capture the essence of the flowers in various stages of life, from full bloom to withering. The series reflects Van Gogh's fascination with the beauty of nature and his innovative approach to color and composition.", "images/artwork/sunflowers.jpg" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The Bedroom is one of Vincent van Gogh's best-known works. It depicts his own bedroom in Arles, France, with bright and bold colors intended to express absolute 'rest' or 'sleep.' The skewed perspective, the vibrant palette, and the simplicity of the room's furnishings convey a sense of tranquility and personal space. This painting reflects his longing for a place of comfort and refuge, and its intimate nature makes it a touching piece of his collection.", "images/artwork/thebedroom.jpg" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "Description", "Dimensions", "ImageUrl", "Title" },
                values: new object[] { new DateTime(1642, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Night Watch is one of the most famous Dutch Golden Age paintings. It depicts a group of city guards moving out, led by Captain Frans Banning Cocq and his lieutenant, Willem van Ruytenburch. The painting is renowned for its colossal size, dramatic use of light and shadow (tenebrism), and the perception of motion in what would have traditionally been a static military group portrait. The intricate details, such as the expressions of the guards, the play of light, and the overall composition, draw viewers into the dynamic scene.", "363 cm × 437 cm", "images/artwork/nightwatch.jpg", "The Night Watch" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "Description", "Dimensions", "ImageUrl", "Title" },
                values: new object[] { new DateTime(1632, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Anatomy Lesson of Dr. Nicolaes Tulp is a group portrait of Dr. Tulp and several other Amsterdam surgeons. It captures a public dissection, a common practice for medical education at the time. The painting stands out for its realistic portrayal of the human anatomy and the lifelike depiction of the surgeons' faces. The lighting highlights the central figures, creating a stark contrast with the dark background, which enhances the dramatic effect. This work is a prime example of Rembrandt's skill in rendering texture, expression, and atmosphere.", "169.5 cm × 216.5 cm", "images/artwork/anatomylesson.jpg", "The Anatomy Lesson of Dr. Nicolaes Tulp" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "Description", "Dimensions", "ImageUrl", "Title" },
                values: new object[] { new DateTime(1665, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Self-Portrait with Two Circles is a powerful self-portrait that showcases Rembrandt's mastery of chiaroscuro and his deep understanding of human emotion. In this painting, Rembrandt presents himself as an older man, holding his tools and standing confidently in front of two mysterious circles. The circles have been interpreted in various ways, but they add an element of intrigue to the composition. The detailed rendering of his face and the rich textures of his clothing reflect his introspective and honest approach to self-portraiture.", "114.3 cm × 94 cm", "images/artwork/selfportrait.jpg", "Self-Portrait with Two Circles" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Artworks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePictureUrl",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfilePictureUrl",
                value: "https://example.com/vangogh.jpg");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Biography", "DateOfBirth", "Email", "FirstName", "LastName", "ProfilePictureUrl", "Website" },
                values: new object[] { "Spanish painter, sculptor, printmaker, ceramicist and stage designer.", new DateTime(1881, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "pablo.picasso@example.com", "Pablo", "Picasso", "https://example.com/picasso.jpg", "https://www.picasso.com/" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "A famous painting by Vincent van Gogh.", "https://example.com/starrynight.jpg" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "A series of paintings by Vincent van Gogh.", "https://example.com/sunflowers.jpg" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "A painting by Vincent van Gogh of his bedroom.", "https://example.com/thebedroom.jpg" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "Description", "Dimensions", "ImageUrl", "Title" },
                values: new object[] { new DateTime(1937, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "A famous painting by Pablo Picasso.", "60 cm × 49 cm", "https://example.com/weepingwoman.jpg", "The Weeping Woman" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "Description", "Dimensions", "ImageUrl", "Title" },
                values: new object[] { new DateTime(1937, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A mural-sized oil painting on canvas by Pablo Picasso.", "349 cm × 776 cm", "https://example.com/guernica.jpg", "Guernica" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "Description", "Dimensions", "ImageUrl", "Title" },
                values: new object[] { new DateTime(1907, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A large oil painting created in 1907 by Pablo Picasso.", "243.9 cm × 233.7 cm", "https://example.com/lesdemoiselles.jpg", "Les Demoiselles d'Avignon" });
        }
    }
}
