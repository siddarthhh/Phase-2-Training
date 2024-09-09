using Microsoft.EntityFrameworkCore;

namespace ApiEx.Models
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ValidUser> ValidUsers { get; set; }

        public CompanyDbContext (DbContextOptions<CompanyDbContext> options) : base(options)
        {

        }
    }
}
