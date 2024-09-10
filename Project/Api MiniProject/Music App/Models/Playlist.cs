namespace MusicApp.Models
{
    public class Playlist
    {

        public int PlaylistId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Song>? Songs { get; set; }
    }
}
