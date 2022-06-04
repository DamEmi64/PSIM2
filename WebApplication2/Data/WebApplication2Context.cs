using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class WebApplication2Context : DbContext
    {
        public WebApplication2Context (DbContextOptions<WebApplication2Context> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>().HasKey(table => new { table.UserID, table.StationID });
        }
        public DbSet<WebApplication2.Models.Comment> Comment { get; set; }

        public DbSet<WebApplication2.Models.User> User { get; set; }

        public DbSet<WebApplication2.Models.Station> Station { get; set; }
        public DbSet<WebApplication2.Models.History> History { get; set; }
        public DbSet<WebApplication2.Models.Role> Role { get; set; }
        public DbSet<WebApplication2.Models.FuelAvaliability> FuelAvaliability { get; set; }
        public DbSet<WebApplication2.Models.FuelGrade> FuelGrade { get; set; }
    }
}
