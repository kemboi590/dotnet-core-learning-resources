using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace _2.TypedResults.Models
{
    public class AppDbContext : DbContext
    {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            { }
            public DbSet<Event> Events => Set<Event>();
    }
}
