using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _BeatBox.Migrations
{
    /// <inheritdoc />
    public partial class addingroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1854982b-db84-4bef-8aa1-9fae3662f2ef", null, "admin", "user" },
                    { "62381244-0e1c-4fd9-aa3e-c062edb6332b", null, "user", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1854982b-db84-4bef-8aa1-9fae3662f2ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62381244-0e1c-4fd9-aa3e-c062edb6332b");
        }
    }
}
