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

            //optionsBuilder.UseSqlServer("Server=DESKTOP-KL71KR7\\SQLEXPRESS;Database= online_buses;Integrated Security=true");
             optionsBuilder.UseSqlServer("Server=.;Database=online_buses;User Id=sa;password=aptech; TrustServerCertificate=True;");
            //optionsBuilder.UseSqlServer("Server=TALHAKHAN;Database=online_buses;Trusted_Connection=True;");




        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Buses> Buses { get; set; }

        public DbSet<Schedules> Schedules { get; set; }
       

        public DbSet<Route> Route { get; set; }








    }
}
