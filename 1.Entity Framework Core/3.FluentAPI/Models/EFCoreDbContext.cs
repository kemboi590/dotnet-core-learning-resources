using DataAnnotation.Models.many_many;
using DataAnnotation.Models.one_many;
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
            //One - One relationship
            modelBuilder.Entity<User>() //User entity
                 // Specifies that the User entity has a one-to-one relationship with a Passport entity, meaning each User has one Passport.
                .HasOne(u => u.Passport)
                // Specifies that the Passport entity is also related to exactly one User entity, making the relationship bidirectional.
                .WithOne(p => p.User)
                // Sets the UserId property in the Passport entity as the foreign key that references the User entity's primary key.
                .HasForeignKey<Passport>(p => p.UserId);

            //One - Many relationship
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // This will delete the child record(s) when parent record is deleted

            //Many-Many relationship
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity(j => j.ToTable("StudentCourses"));  //Explicitly set the join table name
        }

        //One - One relationship
        public DbSet<User> Users { get; set; }
        public DbSet<Passport> passports { get; set; }

        //One - Many relationship
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        //Many-Many relationship
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }        
    }
}


/*
 Understanding Fluent API Methods:

 HasOne(): Declares that the Principal entity is related to one Dependent Entity. That means it establishes that the User entity (Principal) is related to one Passport entity (Dependent).
WithOne(): Ensures the Dependent entity is also related to one Principal entity. It specifies the other side of the relationship, the Passport entity (dependent), which is also related to exactly one User (Principal) entity.
HasForeignKey(): This method defines the foreign key linking the dependent entity to the principal entity. It explicitly sets the foreign key (UserId) in the Passport entity, linking it to the Primary Key (ID) of the User entity.
 */