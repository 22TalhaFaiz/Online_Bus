﻿using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace WebApplication7.Models
{
    public class connection : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
<<<<<<< HEAD
           // optionsBuilder.UseSqlServer("Server=DESKTOP-KL71KR7\\SQLEXPRESS;Database= online_bus;Integrated Security=true");
            optionsBuilder.UseSqlServer("Server=.;Database=online_bus;User Id=sa;password=aptech; TrustServerCertificate=True;");
=======
            optionsBuilder.UseSqlServer("Server=DESKTOP-KL71KR7\\SQLEXPRESS;Database= online_bus;Integrated Security=true");
            //optionsBuilder.UseSqlServer("Server=.;Database=online_bus;User Id=sa;password=aptech; TrustServerCertificate=True;");
>>>>>>> 3a1449702830886577897258edea57e5a825f3ca
        }

        public DbSet<Users> Users { get; set; }
       





    }
}
