using Microsoft.EntityFrameworkCore;
using Employee.Models;

namespace Employee.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Employees> Employees { get; set; }  = null!;
    }
}