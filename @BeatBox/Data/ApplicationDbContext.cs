using BeatBox.Models;
using Microsoft.EntityFrameworkCore;

using static System.Net.WebRequestMethods;

using BeatBox.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _BeatBox.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace _BeatBox.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext<Users> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    
    public DbSet<Song> Songs { get; set; }
   // public DbSet<Playlists> Playlist { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(login => new { login.LoginProvider, login.ProviderKey });
        });

        modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.HasKey(role => new { role.UserId, role.RoleId });
        });

        modelBuilder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.HasKey(token => new { token.UserId, token.LoginProvider, token.Name });
        });

        modelBuilder.Entity<Song>().HasData(
            new Song { Id = 1, Tittle = "Sia", ThumbNail = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.smule.com%2Fsong%2Fsia-unstoppable-karaoke-lyrics%2F116078705_351078%2Farrangement&psig=AOvVaw1VTj0vvvCsrtD_j0EyAuyI&ust=1691840464192000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCIiemYHD1IADFQAAAAAdAAAAABAE", SongFilepath = "https://www.youtube.com/watch?v=cxjvTXo9WWM", Language = "English", Released = Convert.ToDateTime("2016-jan-14 06:00am"), SongComposer = "Sia", SongSinger = "Sia", SongCast = "sia", SongLyrics = "Unstopable" }
           );
    }
   
    



}

    