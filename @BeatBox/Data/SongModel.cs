using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace _BeatBox.Data
{
    public class SongModel
    {
        public int Id { get; set; }

        public string Tittle { get; set; }

        public IFormFile? SongFilePath { get; set; }

        public string Language { get; set; }

        public DateTime Released { get; set; }

        public string SongComposer { get; set; }

        public string SongSinger { get; set; }

        public string SongCast { get; set; }

        public string? Lyrics { get; set; }

        public IFormFile? ThumbNail { get; set; }
    }
}
