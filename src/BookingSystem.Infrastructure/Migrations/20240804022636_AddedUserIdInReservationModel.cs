using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserIdInReservationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f7de2ca2-ee7d-46d6-b160-716ab1b5c0db", "1b04e98b-6edb-4c79-9de8-f8fd2f681cc7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "576273ed-c545-4b16-b151-2028fa9e6fc8", "4fd65fd7-a165-4860-a808-7b7e952e947c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "576273ed-c545-4b16-b151-2028fa9e6fc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7de2ca2-ee7d-46d6-b160-716ab1b5c0db");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b04e98b-6edb-4c79-9de8-f8fd2f681cc7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fd65fd7-a165-4860-a808-7b7e952e947c");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "576273ed-c545-4b16-b151-2028fa9e6fc8", null, "Administrator", "ADMINISTRATOR" },
                    { "f7de2ca2-ee7d-46d6-b160-716ab1b5c0db", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1b04e98b-6edb-4c79-9de8-f8fd2f681cc7", 0, "4535df31-f0bc-4f49-a535-39f081c1caa6", "employee@example.com", true, false, null, "EMPLOYEE@EXAMPLE.COM", "EMPLOYEE", "AQAAAAIAAYagAAAAEOZwe9W8YDquiSSC+DuwYKmxGjZy/XrL+un9553PC/EXrB03CN3x3o0OcqxuXW3XWw==", null, false, "ea419823-891b-4f04-8972-617c7fd7af3a", false, "Employee" },
                    { "4fd65fd7-a165-4860-a808-7b7e952e947c", 0, "e0bac454-286a-4aff-8d4e-a4c090bef32c", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMINISTRATOR", "AQAAAAIAAYagAAAAEEXEcq2MV7y7qp4JJv5ixBSZe5xeeWin1UTDu5GZXlcDmLUwHeqviZDOkY21PKVCNg==", null, false, "86b3c87c-fb7f-4d1c-b739-8dbb9e9301a1", false, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f7de2ca2-ee7d-46d6-b160-716ab1b5c0db", "1b04e98b-6edb-4c79-9de8-f8fd2f681cc7" },
                    { "576273ed-c545-4b16-b151-2028fa9e6fc8", "4fd65fd7-a165-4860-a808-7b7e952e947c" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
