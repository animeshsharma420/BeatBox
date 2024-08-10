using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeatBox.Migrations
{
    /// <inheritdoc />
    public partial class addtableTodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbNail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "AddedOn", "Name", "ThumbNail" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 1, 14, 20, 45, 0, 0, DateTimeKind.Unspecified), "Romantic", "https://marketplace.canva.com/EAE67ZcRsjE/1/0/1600w/canva-blue-white-photocentric-song-playlist-youtube-thumbnail-OSa-FCg6KGk.jpg" },
                    { 2, new DateTime(2001, 1, 14, 20, 45, 0, 0, DateTimeKind.Unspecified), "Sad", "https://e1.pxfuel.com/desktop-wallpaper/408/1/desktop-wallpaper-sad-songs-for-sad-people-sad-people-thumbnail.jpg" },
                    { 3, new DateTime(2003, 1, 14, 20, 45, 0, 0, DateTimeKind.Unspecified), "Rock", "https://w7.pngwing.com/pngs/313/180/png-transparent-rock-concert-music-festival-rock-music-others-stage-performance-computer-wallpaper-thumbnail.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
