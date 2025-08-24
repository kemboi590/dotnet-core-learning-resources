using EagerLoading.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagerLoading.Loading
{
    public class IncludeMore
    {
        public static void Run()
        {
            var context = new EFCoreDbContext();
            try
            {
                // METHOD SYNTAX with Include (using lambda expression)
                Console.WriteLine("Method Syntax: Loading Students with Branch, Address, and Courses");
                // Eagerly load Student entities along with their related Branch, Address, and Courses entities using method syntax.
                var studentsWithDetailsMethod = context.Students
                    .Include(s => s.Branch)            // Eagerly load Branch entity
                    .Include(s => s.Address)           // Eagerly load Address entity
                    .Include(s => s.Courses)           // Eagerly load Courses collection
                    .ToList();
                Console.WriteLine(); //Line Break before displaying the data
                                     // Display results
                foreach (var student in studentsWithDetailsMethod)
                {
                    Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Branch: {student.Branch?.BranchLocation}, " +
                        $"Address: {(student.Address == null ? "No Address" : student.Address.City)}, Courses Count: {student.Courses.Count}");
                }
                // QUERY SYNTAX with Include (using lambda expression)
                Console.WriteLine("\nQuery Syntax: Loading Students with Branch, Address, and Courses");
                //Eagerly load Student entities along with their related Branch, Address, and Courses entities using query syntax.
                var studentsWithDetailsQuery = (from student in context.Students
                                                .Include(s => s.Branch)             // Eagerly load Branch entity
                                                .Include(s => s.Address)            // Eagerly load Address entity
                                                .Include(s => s.Courses)            // Eagerly load Courses collection
                                                select student).ToList();
                // Display results
                foreach (var student in studentsWithDetailsMethod)
                {
                    Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Branch: {student.Branch?.BranchLocation}, " +
                        $"Address: {(student.Address == null ? "No Address" : student.Address.City)}, Courses Count: {student.Courses.Count}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred while fetching the data. Error: {ex.Message}");
            }
        }
    }
}
