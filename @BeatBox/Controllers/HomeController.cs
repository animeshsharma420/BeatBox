using _BeatBox.DataAccess.Data;
using _BeatBox.ViewModels;
using BeatBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _BeatBox.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index(string searchTerm = null)
        {
           
                IQueryable<Song> query = _db.Songs;

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchTerm = searchTerm.Trim();
                    query = query.Where(song =>
                        song.Tittle.Contains(searchTerm) ||
                        song.SongSinger.Contains(searchTerm) ||
                        song.SongComposer.Contains(searchTerm) ||
                        song.Language.Contains(searchTerm) ||
                        song.SongCast.Contains(searchTerm) ||
                        song.SongLyrics.Contains(searchTerm));
                }

                List<Song> recentSongs = await query
                    .OrderByDescending(song => song.Released)
                    .Take(5)
                    .ToListAsync();

                var viewModel = new SongListViewModel
                {
                    SearchTerm = searchTerm,
                    Songs = recentSongs
                };

                return View(viewModel);
         }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}