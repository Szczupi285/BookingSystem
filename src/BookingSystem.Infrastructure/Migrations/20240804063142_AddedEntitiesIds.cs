using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedEntitiesIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cecb0d12-139a-471b-ad13-271f9880ff7d", "1830a667-1910-409b-a53c-cd26cf93c785" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "123fdecc-fc77-4781-a624-f9c4faf13cf7", "aa5589f2-889e-47ab-8e67-13caf1a7d017" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "123fdecc-fc77-4781-a624-f9c4faf13cf7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cecb0d12-139a-471b-ad13-271f9880ff7d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1830a667-1910-409b-a53c-cd26cf93c785");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa5589f2-889e-47ab-8e67-13caf1a7d017");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "123fdecc-fc77-4781-a624-f9c4faf13cf7", null, "Administrator", "ADMINISTRATOR" },
                    { "cecb0d12-139a-471b-ad13-271f9880ff7d", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1830a667-1910-409b-a53c-cd26cf93c785", 0, "5249a56c-c413-4ca6-86a3-fe242c74e0ab", "employee@example.com", true, false, null, "EMPLOYEE@EXAMPLE.COM", "EMPLOYEE", "AQAAAAIAAYagAAAAECyJdHW3ZsznRK5IPGnE8O1F+Vk/KWLtiCUCfeJ+f6PFnbejxRkubKPUe9fQPfibpw==", null, false, "134c6782-e30a-43b7-b207-d5db14232572", false, "Employee" },
                    { "aa5589f2-889e-47ab-8e67-13caf1a7d017", 0, "60f3a94f-8527-49f0-af98-54ad1f5d4956", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMINISTRATOR", "AQAAAAIAAYagAAAAEGsZvgSlZ9yqcJe7q++Bij7YfSTvwXxbjIMp+XcgZeQk5NYK3QmFzrG3gvaQvKO1oA==", null, false, "6c496df6-af1b-4155-b6af-9ef4584d8e35", false, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cecb0d12-139a-471b-ad13-271f9880ff7d", "1830a667-1910-409b-a53c-cd26cf93c785" },
                    { "123fdecc-fc77-4781-a624-f9c4faf13cf7", "aa5589f2-889e-47ab-8e67-13caf1a7d017" }
                });
        }
    }
}
