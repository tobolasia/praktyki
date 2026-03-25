using Microsoft.EntityFrameworkCore;
using MyCoreApp.Models;

namespace MyCoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherHistory> WeatherHistories { get; set; }
    }
}