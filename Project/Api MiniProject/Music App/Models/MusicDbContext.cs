using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MusicApp.Models
{
    public class MusicDbContext : DbContext
    {
      
            public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
            {
            }
            public DbSet<ValidUser> ValidUsers { get; set; }    
            public DbSet<Song> Songs { get; set; }
            public DbSet<Playlist> Playlists { get; set; }

        
        }
    
}
