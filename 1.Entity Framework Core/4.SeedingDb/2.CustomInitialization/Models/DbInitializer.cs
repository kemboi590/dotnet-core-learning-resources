using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInitialization.Models
{
    public class DbInitializer
    {
        public static void Initialize(EFCoreDbContext context)
        {
            //ensure the db is created
            context.Database.EnsureCreated();

            //check if the db has been seeded
            if (context.Countries.Any() || context.States.Any() || context.Cities.Any())
            {
                Console.WriteLine("Database already seeded.");
                return;
            }

            var transaction = context.Database.BeginTransaction();
            try
            {
                //seed the countries
                var countries = new List<Country>
                {
                new Country { CountryName = "Kenya", CountryCode = "KE" },
                new Country {  CountryName = "Uganda", CountryCode = "UG" }
                };
                context.Countries.AddRange(countries);
                context.SaveChanges(); // Save to generate CountryIds

                //seed states
                var states = new List<State>
                {
                new State {StateName= "Nyeri", CountryId = 1 },
                new State {StateName= "Kirinyaga", CountryId = 1 },
                new State {StateName= "Kampala", CountryId = 2 }
                };
                context.States.AddRange(states);
                context.SaveChanges(); // Save to generate StateIds

                //seed cities
                var cities = new List<City>
            {
                new City {CityName= "Nyeri Town", StateId= 1},
                new City {CityName= "Karatina Town", StateId= 1},
                new City {CityName= "Kutus", StateId= 2},
                new City {CityName= "Kerugoya", StateId= 2},
                new City {CityName= "Kampala City", StateId= 3}
            };
                context.Cities.AddRange(cities);
                context.SaveChanges();


                //commit changes
                transaction.Commit();

                Console.WriteLine("Database has been seeded successfully.");

            }
            catch (Exception ex)
            {
                //Rollback the transaction
                transaction.Rollback();
                Console.WriteLine($"An Error Occured{ex.Message}");
            }

            
        }
    }
}
