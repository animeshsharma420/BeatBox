using BeatBox.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;


namespace _BeatBox.DataAccess.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    
    public DbSet<Song> Songs { get; set; }
   // public DbSet<Playlists> Playlist { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Song>().HasData(
            new Song { Id = 1, Tittle = "Sia", ThumbNail = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.smule.com%2Fsong%2Fsia-unstoppable-karaoke-lyrics%2F116078705_351078%2Farrangement&psig=AOvVaw1VTj0vvvCsrtD_j0EyAuyI&ust=1691840464192000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCIiemYHD1IADFQAAAAAdAAAAABAE", SongFilepath = "https://www.youtube.com/watch?v=cxjvTXo9WWM", Language = "English", Released = Convert.ToDateTime("2016-jan-14 06:00am"), SongComposer = "Sia", SongSinger = "Sia", SongCast = "sia", SongLyrics = "Unstopable" }
           );
    }
   
    



}

    