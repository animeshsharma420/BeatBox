using _BeatBox.Data;
using _BeatBox.DataAccess.Data;
using BeatBox.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace _BeatBox.Controllers
{
    public class SongController : Controller
    {
        private readonly ApplicationDbContext _db;
       
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SongController(ApplicationDbContext db,IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Songs()
        {
            List<Song> objSongList = _db.Songs.ToList();
            return View(objSongList);
        }
        public IActionResult AddNewSong()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewSong(SongModel obj)
        {
            if (ModelState.IsValid)
            {
                string stringFileName = UploadFile(obj);
                string songfilename = UploadSong(obj);
                Song objSong = new Song()
                {
                    Tittle = obj.Tittle,
                    SongFilepath = songfilename,
                    Language = obj.Language,
                    Released = obj.Released,
                    SongComposer = obj.SongComposer,
                    SongSinger = obj.SongSinger,
                    SongCast = obj.SongCast,
                    SongLyrics = obj.Lyrics,
                    ThumbNail = stringFileName
                };
                _db.Songs.Add(objSong);
                _db.SaveChanges();
                return RedirectToAction("Songs");
            }
            return View();
        }
        private string UploadSong(SongModel obj)
        {
            string filename = null;
            if (obj.SongFilePath != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Songs");
                filename = Guid.NewGuid().ToString() + "-" + obj.SongFilePath.FileName;
                string filepath = Path.Combine(uploadDir, filename);
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    obj.SongFilePath.CopyTo(fileStream);
                }
            }
            return filename;
        }
        private string UploadFile(SongModel obj)
        {
            string filename = null;
            if (obj.ThumbNail != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Image/song");
                filename = Guid.NewGuid().ToString() + "-" + obj.ThumbNail.FileName;
                string filepath = Path.Combine(uploadDir, filename);
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    obj.ThumbNail.CopyTo(fileStream);
                }
            }
            return filename;
        }
        public IActionResult SongEdit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Song? SongsFromDb = _db.Songs.Find(id);
            if (SongsFromDb == null)
            {
                return NotFound();
            }
            return View(SongsFromDb);
        }
        [HttpPost]
        public IActionResult SongEdit(SongModel obj, int? id)
        {
            if (ModelState.IsValid)
            {
                var data = _db.Songs.Where(e => e.Id == obj.Id).SingleOrDefault();
                // Category? categoryFromDb = _db.Categories.Find(id);
                string uniquefilename = string.Empty;
                if (obj.ThumbNail == null)
                {
                    if (data.ThumbNail != null)
                    {

                        string filepath = Path.Combine(_webHostEnvironment.WebRootPath, "Image/song", data.ThumbNail);
                        if (System.IO.File.Exists(filepath))
                        {
                            System.IO.File.Delete(filepath);
                        }
                    }
                }
                string uniqueSongName = string.Empty;
                if (obj.SongFilePath == null)
                {
                    if (data.SongFilepath != null)
                    {

                        string filepath = Path.Combine(_webHostEnvironment.WebRootPath, "Songs", data.SongFilepath);
                        if (System.IO.File.Exists(filepath))
                        {
                            System.IO.File.Delete(filepath);
                        }
                    }
                }
                uniquefilename = UploadFile(obj);
                uniqueSongName = UploadSong(obj);
                data.Tittle = obj.Tittle;

                if (obj.SongFilePath != null)
                {
                    data.SongFilepath = uniqueSongName;
                }
                data.Language = obj.Language;
                data.Released = obj.Released;
                data.SongComposer = obj.SongComposer;
                data.SongSinger = obj.SongSinger;
                data.SongCast = obj.SongCast;
                data.SongLyrics = obj.Lyrics;
                if (obj.ThumbNail != null)
                {
                    data.ThumbNail = uniquefilename;
                }
                _db.Songs.Update(data);
                _db.SaveChanges();
                return RedirectToAction("Songs");
            }
            return View();
        }
        public IActionResult SongDelete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Song? SongsFromDb = _db.Songs.Find(id);
            if (SongsFromDb == null)
            {
                return NotFound();
            }
            return View(SongsFromDb);
        }
        [HttpPost, ActionName("SongDelete")]
        public IActionResult DeletePOST(int? id)
        {
            Song? obj = _db.Songs.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Songs.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Songs");

        }
    }
}
