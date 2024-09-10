using Microsoft.AspNetCore.Mvc;

namespace MusicApp.Models
{
    public class SongUploadModel
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public int Popularity { get; set; }
        public int PlaylistId { get; set; }

        [FromForm(Name = "file")]
        public IFormFile File { get; set; }
    }

}
