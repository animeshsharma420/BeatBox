using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeatBox.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Song Tittle")]
        public string Tittle { get; set; }
        [Required]
        [DisplayName("Song Filepath")]
        public string SongFilepath { get; set; }
        [Required]
        [DisplayName("Song Language")]
        public string Language { get; set; }
        [Required]
        [DisplayName("Song Released")]
        public DateTime Released { get; set; }
        [Required]
        [DisplayName("Song Composer")]
        public string SongComposer { get; set; }
        [Required]
        [DisplayName("Song Singer")]
        public string SongSinger { get; set; }
        [Required]
        [DisplayName("Song Cast")]
        public string SongCast { get; set; }
        [DisplayName("Song Lyrics")]
        public string? SongLyrics { get; set; }
        [Required]
        [DisplayName("Song ThumbNail")]
        public string ThumbNail { get; set; }

    }
}
