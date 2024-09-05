using Microsoft.EntityFrameworkCore;

namespace MVCAssessment.Models
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public UserDbContext(DbContextOptions opt) : base(opt) { }
    }
}
