//ST10390916
//All work is my own unless otherwise cited or referenced.

using Microsoft.EntityFrameworkCore;
using ST10390916_PROG_POE.Models;


namespace ST10390916_PROG_POE.Data
{
    public class AppDbContext : DbContext
    {
               
        public AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=ClaimsDB;Trusted_Connection=True");
        }

        

        public DbSet<User> users { get; set; }
        public DbSet<Claim> claims { get; set; }

    }
}
