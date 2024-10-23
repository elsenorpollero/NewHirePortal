using Microsoft.EntityFrameworkCore;
using NewHirePortalClean.Models;

namespace NewHirePortalClean.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets for your models
        public DbSet<User> Users { get; set; }
        public DbSet<EmployeeApplication> EmployeeApplications { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PersonalInformation> PersonalInformation { get; set; }
        public DbSet<EmployeeInformation> EmployeeInformation { get; set; }

        // No need for OnConfiguring if the connection string is handled in Program.cs
    }
}
