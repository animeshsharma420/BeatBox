using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using _BeatBox.Areas.Identity.Data;
using _BeatBox.DataAccess.Data;
using _BeatBox.Data;
using _BeatBox.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the BeatBox DbContext
builder.Services.AddDbContext<_BeatBoxContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("_BeatBoxContextConnection")));

// If you have another DbContext, say WinkContext, register it as well
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity for BeatBox users
builder.Services.AddDefaultIdentity<Users>(options =>

    options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); 

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
