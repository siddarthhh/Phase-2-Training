using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApp.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace MusicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SongsController : ControllerBase
    {
        private readonly MusicDbContext _context;

        public SongsController(MusicDbContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        [SwaggerOperation(Summary = "Get the songs list")]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        [SwaggerOperation(Summary = "Get the song by id")]

        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var song = await _context.Songs.FindAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Users")]
        [SwaggerOperation(Summary = "Edit the songs list")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            if (id != song.SongId)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Songs
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        [SwaggerOperation(Summary = "Add the songs to the playlist")]

        public async Task<ActionResult<Song>> PostSong([FromForm] SongUploadModel model)
        {
            if (model.File == null || model.File.Length == 0)
            {
                return BadRequest(new { message = "No file uploaded." });
            }

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedSongs");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var fileName = Path.GetFileName(model.File.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.File.CopyToAsync(stream);
            }

            var song = new Song
            {
                Title = model.Title,
                FilePath = filePath, 
                Duration = model.Duration,
                Popularity = model.Popularity,
                PlaylistId = model.PlaylistId
            };

            // Save the song in the database
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = song.SongId }, song);
        }


        // DELETE: api/Songs/5

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Hit this to Delete the song")]

        public async Task<IActionResult> DeleteSong(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [Authorize(Roles = "User,Admin")]
        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.SongId == id);
        }
        [HttpGet("play/{id}")]
        [Authorize(Roles = "User,Admin")]

        [SwaggerOperation(Summary = "Download and play the song")]

        public IActionResult PlaySong(int id)
        {
            var song = _context.Songs.FirstOrDefault(s => s.SongId == id);
            if (song == null)
            {
                return NotFound("Song not found.");
            }

            if (!System.IO.File.Exists(song.FilePath))
            {
                return NotFound("Song file not found.");
            }

            var fileStream = new FileStream(song.FilePath, FileMode.Open, FileAccess.Read);
            var mimeType = "audio/mpeg"; 

            return new FileStreamResult(fileStream, mimeType)
            {
                FileDownloadName = Path.GetFileName(song.FilePath)
            };
        }
        // 1. GET: api/Songs/Search
        [HttpGet("Search")]
        [Authorize(Roles = "User,Admin")]
        [SwaggerOperation(Summary = "Search songs by title, duration, or popularity.")]
        public async Task<ActionResult<IEnumerable<Song>>> SearchSongs(
            string? title = null,
            int? minDuration = null,
            int? maxDuration = null,
            int? minPopularity = null,
            int? maxPopularity = null)
        {
            var songsQuery = _context.Songs.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                songsQuery = songsQuery.Where(s => s.Title != null && s.Title.Contains(title));
            }

            if (minDuration.HasValue)
            {
                songsQuery = songsQuery.Where(s => s.Duration >= minDuration.Value);
            }
            if (maxDuration.HasValue)
            {
                songsQuery = songsQuery.Where(s => s.Duration <= maxDuration.Value);
            }

            if (minPopularity.HasValue)
            {
                songsQuery = songsQuery.Where(s => s.Popularity >= minPopularity.Value);
            }
            if (maxPopularity.HasValue)
            {
                songsQuery = songsQuery.Where(s => s.Popularity <= maxPopularity.Value);
            }

            var songs = await songsQuery.ToListAsync();

            if (!songs.Any())
            {
                return NotFound("No songs found matching the search criteria.");
            }

            return songs;
        }

        //  GET: api/Songs/FilterByDuration
        [HttpGet("FilterByDuration")]
        [Authorize(Roles = "User,Admin")]
        [SwaggerOperation(Summary = "Filter songs by duration range.")]
        public async Task<ActionResult<IEnumerable<Song>>> FilterByDuration(int minDuration = 0, int maxDuration = int.MaxValue)
        {
            var songs = await _context.Songs
                .Where(s => s.Duration >= minDuration && s.Duration <= maxDuration)
                .ToListAsync();

            return songs;
        }

        //  GET: api/Songs/FilterByPopularity
        [HttpGet("FilterByPopularity")]
        [Authorize(Roles = "User,Admin")]
        [SwaggerOperation(Summary = "Filter songs by popularity range.")]
        public async Task<ActionResult<IEnumerable<Song>>> FilterByPopularity(int minPopularity = 0, int maxPopularity = 100)
        {
            var songs = await _context.Songs
                .Where(s => s.Popularity >= minPopularity && s.Popularity <= maxPopularity)
                .ToListAsync();

            return songs;
        }

        //  GET: api/Songs/SortBy
        [HttpGet("SortBy")]
        [Authorize(Roles = "User,Admin")]
        [SwaggerOperation(Summary = "Sort songs by title, duration, or popularity.")]
        public async Task<ActionResult<IEnumerable<Song>>> SortSongs(string sortBy = "title", string order = "asc")
        {
            var songs = await _context.Songs.ToListAsync();

            songs = sortBy.ToLower() switch
            {
                "title" => order.ToLower() == "asc"
                    ? songs.OrderBy(s => s.Title).ToList()
                    : songs.OrderByDescending(s => s.Title).ToList(),

                "duration" => order.ToLower() == "asc"
                    ? songs.OrderBy(s => s.Duration).ToList()
                    : songs.OrderByDescending(s => s.Duration).ToList(),

                "popularity" => order.ToLower() == "asc"
                    ? songs.OrderBy(s => s.Popularity).ToList()
                    : songs.OrderByDescending(s => s.Popularity).ToList(),

                _ => songs
            };

            return songs;
        }

        //  GET: api/Songs/CountByCriteria
        [HttpGet("CountByCriteria")]
        [Authorize(Roles = "User,Admin")]
        [SwaggerOperation(Summary = "Count the number of songs matching specific criteria.")]
        public async Task<ActionResult<int>> CountSongsByCriteria(
            int minDuration = 0,
            int maxDuration = int.MaxValue,
            int minPopularity = 0,
            int maxPopularity = 100)
        {
            var count = await _context.Songs
                .Where(s => s.Duration >= minDuration &&
                            s.Duration <= maxDuration &&
                            s.Popularity >= minPopularity &&
                            s.Popularity <= maxPopularity)
                .CountAsync();

            return count;
        }
    }

}
