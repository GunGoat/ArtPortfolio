using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Biography", "DateOfBirth", "Email", "FirstName", "LastName", "ProfilePictureUrl", "Website" },
                values: new object[] { 3, "Swedish painter known for his historical genre paintings.", new DateTime(1845, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "gustaf.cederstrom@example.com", "Gustaf", "Cederström", "/images/artist/cederstrom.jpg", "https://www.nationalmuseum.se/en/gustaf-cederstrom" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ArtistId", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, 1, "7308eca5-b35a-47b5-8e4c-3643b3ae4bed", new DateTime(2024, 7, 11, 12, 48, 29, 249, DateTimeKind.Utc).AddTicks(7320), "vincent.vangogh@example.com", false, false, null, "Vincent van Gogh", "VINCENT.VANGOGH@EXAMPLE.COM", "VINCENT.VANGOGH", null, null, false, "d5e41618-6149-4027-ab8d-efc5083c8555", false, "vincent.vangogh" },
                    { "2", 0, 2, "5b503500-a0be-4d41-9496-93540c377003", new DateTime(2024, 7, 11, 12, 48, 29, 249, DateTimeKind.Utc).AddTicks(7327), "rembrandt@example.com", false, false, null, "Rembrandt van Rijn", "REMBRANDT@EXAMPLE.COM", "REMBRANDT", null, null, false, "e2d94398-ee49-4b02-b17b-d6358d43ed2f", false, "rembrandt" },
                    { "3", 0, 3, "390e3d02-2935-45bd-bf9b-0c989ec8aa97", new DateTime(2024, 7, 11, 12, 48, 29, 249, DateTimeKind.Utc).AddTicks(7335), "gustaf.cederstrom@example.com", false, false, null, "Gustaf Cederström", "GUSTAF.CEDERSTROM@EXAMPLE.COM", "GUSTAF.CEDERSTROM", null, null, false, "72e8d1f0-e710-44b4-a837-cf7d7c1e22db", false, "gustaf.cederstrom" }
                });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "Id", "ArtistId", "CreationDate", "Description", "Dimensions", "ImageUrl", "Medium", "Title" },
                values: new object[,]
                {
                    { 13, 3, new DateTime(1878, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bringing Home the Body of King Karl XII depicts the moment when Swedish soldiers carry the body of King Karl XII back to Sweden after his death in Norway. The somber scene captures the mourning and respect of his subjects.", "295 cm × 395 cm", "/images/artwork/karlxii.jpg", "Oil on canvas", "Bringing Home the Body of King Karl XII" },
                    { 14, 3, new DateTime(1880, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Death of Sten Sture the Younger portrays the Swedish regent succumbing to his wounds after the Battle of Bogesund.", "220 cm × 250 cm", "/images/artwork/stensture.jpg", "Oil on canvas", "The Death of Sten Sture the Younger" },
                    { 15, 3, new DateTime(1923, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magnus Stenbock at Helsingborg depicts the Swedish general in a dramatic pose, egging on his men to expel the Danish invasion of Scania.", "220 cm × 144 cm", "/images/artwork/stenbock.jpg", "Oil on canvas", "Magnus Stenbock at Helsingborg" },
                    { 16, 3, new DateTime(1910, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Narva is a historical painting depicting the decisive Swedish victory at Narva during the Great Northern War. The painting captures the surrender of the Russian army.", "295 cm × 395 cm", "/images/artwork/narva.jpg", "Oil on canvas", "Narva" },
                    { 17, 3, new DateTime(1918, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "David and Goliath is a painting that depicts a tense and dramatic moment involving duelists, with swords drawn and a confrontation imminent.", "98 cm × 129 cm", "/images/artwork/david.jpg", "Oil on canvas", "David and Goliath" },
                    { 18, 3, new DateTime(1918, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waiting Carolean is a historical painting by Gustaf Cederström. The painting captures a Carolean in a moment of contemplation, leaning against a windowsill in his cottage.", "75 cm × 57.5 cm", "/images/artwork/waitingcarolean.jpg", "Oil on canvas", "Waiting Carolean" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
