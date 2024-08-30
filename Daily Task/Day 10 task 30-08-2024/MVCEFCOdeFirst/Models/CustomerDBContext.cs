using Microsoft.EntityFrameworkCore;

namespace MVCEFCOdeFirst.Models
{
    public class CustomerDBContext:DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Orders { get; set; }
        public CustomerDBContext(DbContextOptions<CustomerDBContext > options) : base(options) { }
    }
}
