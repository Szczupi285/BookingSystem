using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f645ef29-07d3-43c1-8095-7c5977c59d57", "e5239d8e-7f51-4459-ac55-fd819a95e1e0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9b44701d-135b-4d76-a9df-3dbb65f3d454", "ecf97486-511b-4190-a556-6a1f86ec11da" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b44701d-135b-4d76-a9df-3dbb65f3d454");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f645ef29-07d3-43c1-8095-7c5977c59d57");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5239d8e-7f51-4459-ac55-fd819a95e1e0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ecf97486-511b-4190-a556-6a1f86ec11da");

            migrationBuilder.DropColumn(
                name: "LocaationId",
                table: "Desks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "709be053-6ca6-470a-8e3a-a789bb439191", null, "Employee", "EMPLOYEE" },
                    { "c5451021-88b8-4527-bd0f-ad8a84c96e65", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e78fa9f-d392-412d-b797-7b2cca2f81f0", 0, "9130f5f5-5970-4a63-95d8-3d37e156cf54", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMINISTRATOR", "AQAAAAIAAYagAAAAEFnszaFy4POVcBL4PuKuI+iEkqug21A6mGfqH6mYZzziFDukTTkDmEM9FEfVFULkzw==", null, false, "66dbe065-e66d-4336-9a25-5a5a9e52925c", false, "Administrator" },
                    { "d8790fb2-ca1a-42b2-9c3d-d807f39cd6ac", 0, "8d7159bd-a5c1-458a-acd0-bedfdd3dfbe0", "employee@example.com", true, false, null, "EMPLOYEE@EXAMPLE.COM", "EMPLOYEE", "AQAAAAIAAYagAAAAEBAeaAPzm7/Qz0x0RG0p3qms3o5NkupHlyNcUDHoofPSgCNOkzIHXIN3yqxoPzFIGg==", null, false, "a9abc612-8305-4a0c-8d6f-a26b2430d89a", false, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c5451021-88b8-4527-bd0f-ad8a84c96e65", "8e78fa9f-d392-412d-b797-7b2cca2f81f0" },
                    { "709be053-6ca6-470a-8e3a-a789bb439191", "d8790fb2-ca1a-42b2-9c3d-d807f39cd6ac" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c5451021-88b8-4527-bd0f-ad8a84c96e65", "8e78fa9f-d392-412d-b797-7b2cca2f81f0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "709be053-6ca6-470a-8e3a-a789bb439191", "d8790fb2-ca1a-42b2-9c3d-d807f39cd6ac" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "709be053-6ca6-470a-8e3a-a789bb439191");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5451021-88b8-4527-bd0f-ad8a84c96e65");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e78fa9f-d392-412d-b797-7b2cca2f81f0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8790fb2-ca1a-42b2-9c3d-d807f39cd6ac");

            migrationBuilder.AddColumn<Guid>(
                name: "LocaationId",
                table: "Desks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b44701d-135b-4d76-a9df-3dbb65f3d454", null, "Employee", "EMPLOYEE" },
                    { "f645ef29-07d3-43c1-8095-7c5977c59d57", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e5239d8e-7f51-4459-ac55-fd819a95e1e0", 0, "c75f8cf6-287e-487f-98db-0509491e4ca9", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMINISTRATOR", "AQAAAAIAAYagAAAAEBXT2M2VyFL1VMm/c1mK0j3liWiAH7bT089AV2qV3U10msKsl/CVXlHIEvuTcMe+gg==", null, false, "757a4695-2b8a-4b8c-b11b-e0173c30fce8", false, "Administrator" },
                    { "ecf97486-511b-4190-a556-6a1f86ec11da", 0, "1ef68026-6d8e-4c07-a0cc-f76fbe69cbb8", "employee@example.com", true, false, null, "EMPLOYEE@EXAMPLE.COM", "EMPLOYEE", "AQAAAAIAAYagAAAAEBT/WBjlaKu+S0e6S9vFERRlYIKxdqsCrrOnucSDLYlGBjUreDpL36kzOoZIzK1Q6Q==", null, false, "9d5efc9a-a417-4556-866f-714679396c50", false, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f645ef29-07d3-43c1-8095-7c5977c59d57", "e5239d8e-7f51-4459-ac55-fd819a95e1e0" },
                    { "9b44701d-135b-4d76-a9df-3dbb65f3d454", "ecf97486-511b-4190-a556-6a1f86ec11da" }
                });
        }
    }
}
