using EagerLoading.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagerLoading.Loading
{
    public class MultilevelEagerLoading
    {
        public static void Run()
        {
            var context = new EFCoreDbContext();
            try
            {
                // Method Syntax with Include and ThenInclude (using lambda expressions)
                Console.WriteLine("Loading Students and their related entities\n");
                // Eagerly load Student, Branch, Address, Courses, and the related Subjects using method syntax
                var student = context.Students
                    .Where(std => std.StudentId == 2)
                    .Include(s => s.Branch)               // Eagerly load related Branch
                    .Include(s => s.Address)              // Eagerly load related Address
                    .Include(s => s.Courses)              // Eagerly load related Courses
                    .ThenInclude(c => c.Subjects)        // Eagerly load related Subjects for each Course
                    .FirstOrDefault();                    // Execute the query and retrieve the data
                                                          // Display basic student information
                Console.WriteLine($"Student: {student.FirstName} {student.LastName}");
                Console.WriteLine($"Branch: {student.Branch?.BranchLocation}");
                Console.WriteLine($"Address: {student.Address?.Street}, {student.Address?.City}, {student.Address?.State}");
                // Display each course and its related subjects
                foreach (var course in student.Courses)
                {
                    Console.WriteLine($"Course: {course.Name}");
                    foreach (var subject in course.Subjects)
                    {
                        Console.WriteLine($"    Subject: {subject.SubjectName}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Exception handling: Catch and display any errors that occur during data retrieval
                Console.WriteLine($"An error occurred while fetching the data. Error: {ex.Message}");
            }
        // Final Output
        Console.WriteLine("\nEager loading of related entities completed.");
        }
        }
}
