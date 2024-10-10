using Microsoft.EntityFrameworkCore;
using NewHirePortalClean.Models;

namespace NewHirePortalClean.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Application> Applications { get; set; } // Add this line
    }
}
