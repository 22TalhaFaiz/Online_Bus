using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace WebApplication7.Models
{
    public class connection2 : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-KL71KR7\\SQLEXPRESS;Database= online_bus;Integrated Security=true");
            //optionsBuilder.UseSqlServer("Server=.;Database=online_bus;User Id=sa;password=aptech; TrustServerCertificate=True;");
        }

       
        public DbSet<Contact> contact_us { get; set; }





    }
}
