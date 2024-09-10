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
    public class PlaylistsController : ControllerBase
    {
        private readonly MusicDbContext _context;

        public PlaylistsController(MusicDbContext context)
        {
            _context = context;
        }

        // GET: api/Playlists
        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            return await _context.Playlists.Include(o => o.Songs).ToListAsync();
        }

        // GET: api/Playlists/5
        [Authorize(Roles = "User,Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylist(int id)
        {
            var playlist = await _context.Playlists.FindAsync(id);

            if (playlist == null)
            {
                return NotFound();
            }

            return playlist;
        }

        // PUT: api/Playlists/5
        [HttpPut("{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> PutPlaylist(int id, Playlist playlist)
        {
            if (id != playlist.PlaylistId)
            {
                return BadRequest();
            }

            _context.Entry(playlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistExists(id))
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

        // POST: api/Playlists
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaylist", new { id = playlist.PlaylistId }, playlist);
        }

        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }

            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaylistExists(int id)
        {
            return _context.Playlists.Any(e => e.PlaylistId == id);
        }

        // GET: api/Playlists/FilterByDuration
        [HttpGet("FilterByDuration")]
        [Authorize(Roles = "User,Admin")]
        [SwaggerOperation(Summary = "Filter playlists by total duration of songs.")]
        public async Task<ActionResult<IEnumerable<Playlist>>> FilterByDuration(int minDuration = 0, int maxDuration = int.MaxValue)
        {
            var playlists = await _context.Playlists
                .Include(p => p.Songs)
                .Where(p => p.Songs.Sum(s => s.Duration) >= minDuration && p.Songs.Sum(s => s.Duration) <= maxDuration)
                .ToListAsync();

            return playlists;
        }

        // GET: api/Playlists/FilterByPopularity
        [HttpGet("FilterByPopularity")]
        [Authorize(Roles = "User,Admin")]

        [SwaggerOperation(Summary = "Filter playlists by average song popularity.")]
        public async Task<ActionResult<IEnumerable<Playlist>>> FilterByPopularity(int minPopularity = 0, int maxPopularity = 100)
        {
            var playlists = await _context.Playlists
                .Include(p => p.Songs)
                .Where(p => p.Songs.Average(s => s.Popularity) >= minPopularity && p.Songs.Average(s => s.Popularity) <= maxPopularity)
                .ToListAsync();

            return playlists;
        }

        //  GET: api/Playlists/CountSongs
        [HttpGet("CountSongs/{id}")]
        [Authorize(Roles = "User,Admin")]
        [SwaggerOperation(Summary = "Count the number of songs in a specific playlist.")]
        public async Task<ActionResult<int>> CountSongs(int id)
        {
            var playlist = await _context.Playlists
                .Include(p => p.Songs)
                .FirstOrDefaultAsync(p => p.PlaylistId == id);

            if (playlist == null)
            {
                return NotFound();
            }

            return playlist.Songs.Count;
        }

        // 5. GET: api/Playlists/TotalDuration/{id}
        [HttpGet("TotalDuration/{id}")]
        [Authorize(Roles = "User,Admin")]
        [SwaggerOperation(Summary = "Calculate the total duration of a specific playlist.")]
        public async Task<ActionResult<int>> TotalDuration(int id)
        {
            var playlist = await _context.Playlists
                .Include(p => p.Songs)
                .FirstOrDefaultAsync(p => p.PlaylistId == id);

            if (playlist == null)
            {
                return NotFound();
            }

            return playlist.Songs.Sum(s => s.Duration);
        }

        //  GET: api/Playlists/CountPlaylistsByCriteria
        [HttpGet("CountPlaylistsByCriteria")]
        [Authorize(Roles = "User,Admin")]
        [SwaggerOperation(Summary = "Count the number of playlists that match certain criteria.")]
        public async Task<ActionResult<int>> CountPlaylistsByCriteria(int minSongCount = 1, int minTotalDuration = 0, int minPopularity = 0)
        {
            var count = await _context.Playlists
                .Include(p => p.Songs)
                .Where(p => p.Songs.Count >= minSongCount &&
                            p.Songs.Sum(s => s.Duration) >= minTotalDuration &&
                            p.Songs.Average(s => s.Popularity) >= minPopularity)
                .CountAsync();

            return count;
        }
        //  GET: api/Playlists/Search
        [HttpGet("Search")]
        [Authorize(Roles = "User,Admin")]
        [SwaggerOperation(Summary = "Search playlists by name, song title, or description.")]
        public async Task<ActionResult<IEnumerable<Playlist>>> SearchPlaylists(
            string? name = null,
            string? songTitle = null,
            string? description = null)
        {
            var playlistsQuery = _context.Playlists
                .Include(p => p.Songs)
                .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                playlistsQuery = playlistsQuery.Where(p => p.Name != null && p.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(songTitle))
            {
                playlistsQuery = playlistsQuery.Where(p => p.Songs.Any(s => s.Title != null && s.Title.Contains(songTitle)));
            }

            if (!string.IsNullOrEmpty(description))
            {
                playlistsQuery = playlistsQuery.Where(p => p.Description != null && p.Description.Contains(description));
            }

            var playlists = await playlistsQuery.ToListAsync();

            if (!playlists.Any())
            {
                return NotFound("No playlists found matching the search criteria.");
            }

            return playlists;
        }
        [HttpGet("SortBy")]
        [Authorize(Roles = "User,Admin")]
        [SwaggerOperation(Summary = "Sort songs by duration, or songCount.")]
        public async Task<ActionResult<IEnumerable<Playlist>>> SortPlaylists(string sortBy = "songCount", string order = "asc")
        {
            var playlists = await _context.Playlists.Include(p => p.Songs).ToListAsync();

            playlists = sortBy.ToLower() switch
            {
                "duration" => order.ToLower() == "asc" 
                    ? playlists.OrderBy(p => p.Songs.Sum(s => s.Duration)).ToList() 
                    : playlists.OrderByDescending(p => p.Songs.Sum(s => s.Duration)).ToList(),

                "songcount" => order.ToLower() == "asc" 
                    ? playlists.OrderBy(p => p.Songs.Count).ToList() 
                    : playlists.OrderByDescending(p => p.Songs.Count).ToList(),

                _ => playlists
            };

            return playlists;
        }

    }
}
