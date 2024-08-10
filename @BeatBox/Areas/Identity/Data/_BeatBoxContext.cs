using _BeatBox.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _BeatBox.Data;

public class _BeatBoxContext : IdentityDbContext<Users>
{
    public _BeatBoxContext(DbContextOptions<_BeatBoxContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        var admin = new IdentityRole("admin");
        admin.NormalizedName= "admin";

        var client= new IdentityRole("client");
        client.NormalizedName = "client";
        builder.Entity<IdentityRole>().HasData(admin,client);


        builder.ApplyConfiguration(new ApplicationUserEntityConfigraution());
    }
}
public class ApplicationUserEntityConfigraution : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(100);
        builder.Property(x => x.LastName).HasMaxLength(100);
    }
}
