using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _BeatBox.Migrations
{
    /// <inheritdoc />
    public partial class updatingrolesagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07e53948-3921-49ab-9135-50fa03a95593");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27eeb298-82d4-4209-99e8-77491a05436c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43a3ca6d-c188-41a3-a77e-c12ff9f3d542", null, "client", "client" },
                    { "d23763a9-ba72-443c-8922-6a7da1527f56", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43a3ca6d-c188-41a3-a77e-c12ff9f3d542");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d23763a9-ba72-443c-8922-6a7da1527f56");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07e53948-3921-49ab-9135-50fa03a95593", null, "admin", "client" },
                    { "27eeb298-82d4-4209-99e8-77491a05436c", null, "client", null }
                });
        }
    }
}
