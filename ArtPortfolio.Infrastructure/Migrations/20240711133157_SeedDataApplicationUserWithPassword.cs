using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataApplicationUserWithPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7308eca5-b35a-47b5-8e4c-3643b3ae4bed", new DateTime(2024, 7, 11, 12, 48, 29, 249, DateTimeKind.Utc).AddTicks(7320), null, "d5e41618-6149-4027-ab8d-efc5083c8555" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b503500-a0be-4d41-9496-93540c377003", new DateTime(2024, 7, 11, 12, 48, 29, 249, DateTimeKind.Utc).AddTicks(7327), null, "e2d94398-ee49-4b02-b17b-d6358d43ed2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "390e3d02-2935-45bd-bf9b-0c989ec8aa97", new DateTime(2024, 7, 11, 12, 48, 29, 249, DateTimeKind.Utc).AddTicks(7335), null, "72e8d1f0-e710-44b4-a837-cf7d7c1e22db" });
        }
    }
}
