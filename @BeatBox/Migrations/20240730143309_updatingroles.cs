using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _BeatBox.Migrations
{
    /// <inheritdoc />
    public partial class updatingroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1854982b-db84-4bef-8aa1-9fae3662f2ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62381244-0e1c-4fd9-aa3e-c062edb6332b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07e53948-3921-49ab-9135-50fa03a95593", null, "admin", "client" },
                    { "27eeb298-82d4-4209-99e8-77491a05436c", null, "client", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "1854982b-db84-4bef-8aa1-9fae3662f2ef", null, "admin", "user" },
                    { "62381244-0e1c-4fd9-aa3e-c062edb6332b", null, "user", null }
                });
        }
    }
}
