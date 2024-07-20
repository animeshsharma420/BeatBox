﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _BeatBox.DataAccess.Data;

#nullable disable

namespace BeatBox.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240120070332_addtable")]
    partial class addtable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BeatBox.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AddedOn")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

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

            modelBuilder.Entity("BeatBox.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Released")
                        .HasColumnType("datetime2");

                    b.Property<string>("SongCast")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SongComposer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SongFilepath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SongLyrics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SongSinger")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThumbNail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Language = "English",
                            Released = new DateTime(2016, 1, 14, 6, 0, 0, 0, DateTimeKind.Unspecified),
                            SongCast = "sia",
                            SongComposer = "Sia",
                            SongFilepath = "https://www.youtube.com/watch?v=cxjvTXo9WWM",
                            SongLyrics = "Unstopable",
                            SongSinger = "Sia",
                            ThumbNail = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.smule.com%2Fsong%2Fsia-unstoppable-karaoke-lyrics%2F116078705_351078%2Farrangement&psig=AOvVaw1VTj0vvvCsrtD_j0EyAuyI&ust=1691840464192000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCIiemYHD1IADFQAAAAAdAAAAABAE",
                            Tittle = "Sia"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
