using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Data
{
    public class Application
    {
        public class ApplicationDbContext : DbContext
        {
            // Constructor
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            // DbSets for your entities
            public DbSet<Category> Categories { get; set; }
            public DbSet<Users> Users { get; set; }

            public DbSet<Location> Locations { get; set; }
            public DbSet<Trip> Trips { get; set; }

            // Optionally configure entity relationships and constraints
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                // Add additional configuration here if needed
            }

        }
    }
}
