using Microsoft.EntityFrameworkCore;
using MySqlApiDemo.Models;

namespace MySqlApiDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
