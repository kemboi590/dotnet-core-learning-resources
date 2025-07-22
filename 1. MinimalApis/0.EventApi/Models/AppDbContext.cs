using Microsoft.EntityFrameworkCore;

namespace _0.EventApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Event> Events => Set<Event>();
    }
}
