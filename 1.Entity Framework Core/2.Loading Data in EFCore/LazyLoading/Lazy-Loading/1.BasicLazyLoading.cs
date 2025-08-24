using LazyLoading.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagerLoading.Loading
{
    public class BasicLazyLoading
    {
        public static void Run()
        {
            var context = new EFCoreDbContext();
            try
            {
                // Eager Loading Example for Branch, Lazy Loading for Address
                Console.WriteLine("Eager Loading Branch, Lazy Loading Address\n");
                // Load a student and related Branch using Eager Loading
                var student = context.Students
                                     .Include(s => s.Branch)  // Eagerly load the Branch entity
                                     .FirstOrDefault(s => s.StudentId == 2);
                // Display basic student information
                if (student != null)
                {
                    Console.WriteLine($"\nStudent Id: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Gender: {student.Gender}");
                    // Check if Branch is null
                    if (student.Branch != null)
                    {
                        Console.WriteLine($"Branch Location: {student.Branch.BranchLocation}, Email: {student.Branch.BranchEmail}, Phone: {student.Branch.BranchPhoneNumber}\n");
                    }
                    else
                    {
                        Console.WriteLine("Branch data not available.\n");
                    }
                    // Accessing the Address property triggers lazy loading
                    // EF Core will issue a SQL query to load the related Address
                    if (student.Address != null)
                    {
                        Console.WriteLine($"\nAddress: {student.Address.Street}, {student.Address.City}, {student.Address.State}, Pin: {student.Address.PostalCode}");
                    }
                    else
                    {
                        Console.WriteLine("\nAddress data not available.");
                    }
                }
                else
                {
                    Console.WriteLine("Student data not found.");
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during data retrieval
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        // Final Output
        Console.WriteLine("\nEager loading of Branch and lazy loading of Address completed.");
        }
        }
}
