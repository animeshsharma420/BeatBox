using BeatBox.Models;

namespace _BeatBox.ViewModels
{
    public class SongListViewModel
    {
        public string? SearchTerm { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
