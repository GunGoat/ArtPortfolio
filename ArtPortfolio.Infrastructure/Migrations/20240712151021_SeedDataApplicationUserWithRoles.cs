using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataApplicationUserWithRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a2aff76-a1fc-4276-a5e6-051cc1344f58", new DateTime(2024, 7, 11, 13, 31, 56, 679, DateTimeKind.Utc).AddTicks(5163), "AQAAAAIAAYagAAAAELVm6wU5Y8L5xcbwrQJltW6HdgpIQ+CIcQh1h1RfiWLSYM0OwyDZXvRycbWnnrioBA==", "8fdc281a-e215-4a7a-bdcb-215da790caaf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "272b6cd6-b65a-4033-b2e3-c65bd1f8f777", new DateTime(2024, 7, 11, 13, 31, 56, 758, DateTimeKind.Utc).AddTicks(9208), "AQAAAAIAAYagAAAAEDRbvohK+MQR8YUgV11pc8RZ0vGka/Hpa+Hf2FlGXQY6PKVe77n/7+dVUpJagEzUKg==", "d3e4a099-3ca8-4801-8464-5a321b6102c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c64d930-62cb-4288-bb37-864fb2b220bc", new DateTime(2024, 7, 11, 13, 31, 56, 841, DateTimeKind.Utc).AddTicks(4947), "AQAAAAIAAYagAAAAEJ5hg6tpCHm6K+Z8b4gXXhtAEJLVq5XXVH5immYo69aYb8n6Jdn8vUgCpwswdkFY7A==", "1c087e70-8eef-4959-bca1-5d99bc09ad47" });
        }
    }
}
