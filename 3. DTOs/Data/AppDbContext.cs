using _3._DTOs.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace _3._DTOs.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Event> Events => Set<Event>();
    }
}
