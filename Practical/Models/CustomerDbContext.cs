using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Practical.Models
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext(DbContextOptions options):base(options) 
        { 

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
