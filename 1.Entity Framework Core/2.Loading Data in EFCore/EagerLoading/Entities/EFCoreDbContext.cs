using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EagerLoading.Entities
{
    public class EFCoreDbContext : DbContext
    {
        //constructor- configures the options like db connections
        //public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options) 
        //{ 
        //}

        //override - allow configuration of the options
        //method - confugures the db context (set the db provider and the connection string)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // UseSqlServer method configures the DbContext to use SQL Server as the database provider.
            //optionsBuilder.UseSqlServer("Server={YOUR SEVER};Database={db Name};Trusted_Connection=True;Password={Password};TrustServerCertificate=True;");


            //step 1: load the config file
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // step 2: Get the connection string section
            var configSection = configBuilder.GetSection("ConnectionStrings");

            //step 3: retrieve the connection string value using the key
            var connectionString = configSection["SQLServerConnection"] ?? null;

            //step 4: configure the DbContext using the retrieved connection string
            optionsBuilder.UseSqlServer(connectionString);

            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

        }

        //properties should always be in prural - coresponds to the tables in the db
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
