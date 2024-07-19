using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedPriceToArtwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dc3b373-93ab-455e-afb9-364a77d5a728");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b2b691ad-e7f1-4dac-9fe7-bcb93bb0a544", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b2b691ad-e7f1-4dac-9fe7-bcb93bb0a544", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b2b691ad-e7f1-4dac-9fe7-bcb93bb0a544", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2b691ad-e7f1-4dac-9fe7-bcb93bb0a544");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Artworks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 10,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 11,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 12,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 13,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 14,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 15,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 16,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 17,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 18,
                column: "Price",
                value: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ced2cc0-5d1d-4148-a39f-bae06eb038ae", null, "Admin", "ADMIN" },
                    { "67cd551a-957e-4230-8b23-b788e06dfa26", null, "Artist", "ARTIST" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "414fc0cc-f42e-4638-9cc2-f50409a183af", new DateTime(2024, 7, 19, 12, 4, 30, 364, DateTimeKind.Utc).AddTicks(3621), "AQAAAAIAAYagAAAAEO4Md6x03PsWCFzjy7ZK4v8CTYpT1BUbxrvOtlKftRPMuNLPXNVs2i7tp42sUR1Khw==", "fdbb260f-31aa-43d9-90f2-86e7fde74b91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1336c85-f776-4fb7-a7d6-897fddce1f16", new DateTime(2024, 7, 19, 12, 4, 30, 448, DateTimeKind.Utc).AddTicks(99), "AQAAAAIAAYagAAAAEN3KcopXUQQ4N1wdcOFuWrKm81IQpPA1klJOZu8tzE+MXpQgYTya/CNqx2Liqn1Pfg==", "b702920e-4693-4cb0-b7e3-1bd3f35c0b91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38ecc8e2-ca1e-460b-bd34-703bb963a09b", new DateTime(2024, 7, 19, 12, 4, 30, 527, DateTimeKind.Utc).AddTicks(6861), "AQAAAAIAAYagAAAAEF24T9qAaP1g1TqteaG09+omhC/30xGdR+NpkUBwEMhenTCv274M8oPiFNfcrQJ8Lw==", "e606015e-fec5-4875-b618-34e80175465d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "67cd551a-957e-4230-8b23-b788e06dfa26", "1" },
                    { "67cd551a-957e-4230-8b23-b788e06dfa26", "2" },
                    { "67cd551a-957e-4230-8b23-b788e06dfa26", "3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ced2cc0-5d1d-4148-a39f-bae06eb038ae");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "67cd551a-957e-4230-8b23-b788e06dfa26", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "67cd551a-957e-4230-8b23-b788e06dfa26", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "67cd551a-957e-4230-8b23-b788e06dfa26", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67cd551a-957e-4230-8b23-b788e06dfa26");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Artworks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5dc3b373-93ab-455e-afb9-364a77d5a728", null, "Admin", "ADMIN" },
                    { "b2b691ad-e7f1-4dac-9fe7-bcb93bb0a544", null, "Artist", "ARTIST" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "faac567b-6f90-41d5-a305-149bf16331f8", new DateTime(2024, 7, 12, 15, 10, 21, 215, DateTimeKind.Utc).AddTicks(5488), "AQAAAAIAAYagAAAAEEbesS5scZBx9ZnVZyYCucUPwwik8YEvuHFoSAdkz14PgNtrYM5OwaLcrGf+6tG4bQ==", "ae5e74e1-a0c2-4bc9-a2fa-d7a632d16d4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fa8c87f-d9c2-4344-94d7-6807ee8b1e36", new DateTime(2024, 7, 12, 15, 10, 21, 300, DateTimeKind.Utc).AddTicks(341), "AQAAAAIAAYagAAAAEM8QKwiIy+GJ/YRXwhn9n2qfnNxD3ZzNNkyxRYtLyktaNMcKy6xt9yfoe+mWWXDBIg==", "117f8640-412c-4f30-a0c3-4fdef8edbda7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4811bb42-0b96-44ed-af5c-75debe2e4588", new DateTime(2024, 7, 12, 15, 10, 21, 385, DateTimeKind.Utc).AddTicks(2895), "AQAAAAIAAYagAAAAEO7kksqwfX7CpBok7hbj1nP6EFsOUB2+Rimdmdww0ODRi4RTvhXpNggTC/5d9PGWuQ==", "c2130390-077c-4d1e-91d9-37ed07bd8d3a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b2b691ad-e7f1-4dac-9fe7-bcb93bb0a544", "1" },
                    { "b2b691ad-e7f1-4dac-9fe7-bcb93bb0a544", "2" },
                    { "b2b691ad-e7f1-4dac-9fe7-bcb93bb0a544", "3" }
                });
        }
    }
}
