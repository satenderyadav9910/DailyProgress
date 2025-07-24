using Microsoft.EntityFrameworkCore;
using DailyProgress.VideoGameApi.Models;

namespace DailyProgress.VideoGameApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<VideoGame> VideoGames { get; set; }

    }
}