using Microsoft.EntityFrameworkCore;
using YoutubeCategorizer.Core.Models;

namespace YoutubeCategorizer.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}