using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebApplication7.Models;

namespace WebApplication7.Models
{
    public class connection : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=DESKTOP-KL71KR7\\SQLEXPRESS;Database= online_bus;Integrated Security=true");
           // optionsBuilder.UseSqlServer("Server=.;Database=online_bus;User Id=sa;password=aptech; TrustServerCertificate=True;");

            //optionsBuilder.UseSqlServer("Server=DESKTOP-KL71KR7\\SQLEXPRESS;Database= online_bus;Integrated Security=true");
            //optionsBuilder.UseSqlServer("Server=.;Database=online_bus;User Id=sa;password=aptech; TrustServerCertificate=True;");

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Location> Buses { get; set; }
        public DbSet<WebApplication7.Models.Buses>? Buses_1 { get; set; }








    }
}
