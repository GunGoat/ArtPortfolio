using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PricePrecisionAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 1500m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 4100m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 1000m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 4200m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 4000m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 2200m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 1400m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 5000m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 700m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 10,
                column: "Price",
                value: 1000m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 11,
                column: "Price",
                value: 4600m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 12,
                column: "Price",
                value: 1800m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 13,
                column: "Price",
                value: 700m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 14,
                column: "Price",
                value: 500m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 15,
                column: "Price",
                value: 4900m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 16,
                column: "Price",
                value: 2500m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 17,
                column: "Price",
                value: 1700m);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 18,
                column: "Price",
                value: 1500m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c026830b-c36f-413e-a0c7-9f98469adf4b", null, "Artist", "ARTIST" },
                    { "ee4202eb-df22-469a-8e0f-dc9c8f70c7b2", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64de37de-a5fa-47f2-ba36-0ece682e0674", new DateTime(2024, 7, 19, 14, 8, 33, 280, DateTimeKind.Utc).AddTicks(2638), "AQAAAAIAAYagAAAAENGuAQvZhRPC97MadgOMCAvE0yiXZPuDiVyBEO6unZWP/CrO8YA1zlL1gIiaLdXIfw==", "81a0dd11-4cc5-4a89-af47-e0c2980f6553" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "312e2267-8300-4466-a2d0-664758e453be", new DateTime(2024, 7, 19, 14, 8, 33, 362, DateTimeKind.Utc).AddTicks(3345), "AQAAAAIAAYagAAAAEANY1pcN3uBFf3SMdiPcry2+D6L2+lEJiy1COkdXTBLDxmsHhTEXYe90nc3UJWEn7g==", "23801e11-7b26-4680-b523-ca101988d061" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f5e4162-6baa-4b20-ac84-ecdd444a5f06", new DateTime(2024, 7, 19, 14, 8, 33, 443, DateTimeKind.Utc).AddTicks(472), "AQAAAAIAAYagAAAAEDzAIy5nh0fIzkI+2ud93Xwa7f5viFbTKS7jn2m+OHP/+COZ3GVVwu8k9CO6EwZJIw==", "707287a4-ff8a-4a59-a73c-982e3a838219" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c026830b-c36f-413e-a0c7-9f98469adf4b", "1" },
                    { "c026830b-c36f-413e-a0c7-9f98469adf4b", "2" },
                    { "c026830b-c36f-413e-a0c7-9f98469adf4b", "3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee4202eb-df22-469a-8e0f-dc9c8f70c7b2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c026830b-c36f-413e-a0c7-9f98469adf4b", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c026830b-c36f-413e-a0c7-9f98469adf4b", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c026830b-c36f-413e-a0c7-9f98469adf4b", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c026830b-c36f-413e-a0c7-9f98469adf4b");

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
    }
}
