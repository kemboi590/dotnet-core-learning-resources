using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInitialization.Models
{
    public class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //load the config file
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //Get the connection string section
            var configSection = configBuilder.GetSection("ConnectionStrings");

            //retrieve the connection string key
            var connectionString = configSection["SQLServerConnection"] ?? null;

            //configure the dbcontext using the connection string
            optionsBuilder.UseSqlServer(connectionString);  
        }


        //override the onModelCreating method to customize the model building process
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Country
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(c => c.CountryId);

                //relationship - country and state
                entity.HasMany(c => c.States) //A Country has many States
                .WithOne(s => s.country)//Each State has one Country
                .HasForeignKey(s => s.CountryId) // Foreign key in State table
                .OnDelete(DeleteBehavior.Cascade);
            });

            //state
            modelBuilder.Entity<State>(entity => { 
                entity.HasKey(s => s.StateId);

                //Relationship - state and city - one -> many
                entity.HasMany(s => s.Cities)
                .WithOne(c => c.State)
                .HasForeignKey(c => c.StateId)
                .OnDelete(DeleteBehavior.Cascade);
            
            });
        }

        //Represent the actual Tables
        public DbSet<Country> Countries {  get; set; }
        public DbSet<State> States {  get; set; }
        public DbSet<City> Cities {  get; set; }
            
    }
}


