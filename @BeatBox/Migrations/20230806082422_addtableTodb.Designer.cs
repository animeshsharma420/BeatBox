﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _BeatBox.Data;
using _BeatBox.DataAccess.Data;

#nullable disable

namespace BeatBox.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230806082422_addtableTodb")]
    partial class addtableTodb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_BeatBox.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThumbNail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddedOn = new DateTime(2002, 1, 14, 20, 45, 0, 0, DateTimeKind.Unspecified),
                            Name = "Romantic",
                            ThumbNail = "https://marketplace.canva.com/EAE67ZcRsjE/1/0/1600w/canva-blue-white-photocentric-song-playlist-youtube-thumbnail-OSa-FCg6KGk.jpg"
                        },
                        new
                        {
                            Id = 2,
                            AddedOn = new DateTime(2001, 1, 14, 20, 45, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sad",
                            ThumbNail = "https://e1.pxfuel.com/desktop-wallpaper/408/1/desktop-wallpaper-sad-songs-for-sad-people-sad-people-thumbnail.jpg"
                        },
                        new
                        {
                            Id = 3,
                            AddedOn = new DateTime(2003, 1, 14, 20, 45, 0, 0, DateTimeKind.Unspecified),
                            Name = "Rock",
                            ThumbNail = "https://w7.pngwing.com/pngs/313/180/png-transparent-rock-concert-music-festival-rock-music-others-stage-performance-computer-wallpaper-thumbnail.png"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}