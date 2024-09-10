using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApp.Models
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }
        public string? Title { get; set; }
        public string? FilePath { get; set; } 
        public int Duration { get; set; } 
        public int Popularity { get; set; }

        [ForeignKey("PlaylistId")]
        public int PlaylistId { get; set; }

        public Playlist? Playlist { get; set; }
    }
}
