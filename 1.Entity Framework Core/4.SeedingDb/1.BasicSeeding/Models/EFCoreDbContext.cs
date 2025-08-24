using BasicSeeding.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotation.Models
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
            //seed countries with Data
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "Kenya", CountryCode = "KE" },
                new Country { CountryId = 2, CountryName = "Uganda", CountryCode = "UG" }
                );

            //seed State with Data
            modelBuilder.Entity<State>().HasData(
                new State { StateId= 1, StateName= "Nyeri", CountryId = 1 },
                new State { StateId= 2, StateName= "Kirinyaga", CountryId = 1 },
                new State { StateId= 3, StateName= "Kampala", CountryId = 2 }
                );

            //seed cities with data
            modelBuilder.Entity<City>().HasData(
                new City { CityId= 1, CityName= "Nyeri Town", StateId= 1},
                new City { CityId= 2, CityName= "Karatina Town", StateId= 1},
                new City { CityId= 3, CityName= "Kutus", StateId= 2},
                new City { CityId= 4, CityName= "Kerugoya", StateId= 2},
                new City { CityId= 5, CityName= "Kampala City", StateId= 3}
                );
        }

        //Represent the actual Tables
        public DbSet<Country> Countries {  get; set; }
        public DbSet<State> States {  get; set; }
        public DbSet<City> Cities {  get; set; }


            
    }
}


