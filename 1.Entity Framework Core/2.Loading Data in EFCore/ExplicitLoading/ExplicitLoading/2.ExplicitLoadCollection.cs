using LazyLoading.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoading.ExplicitLoading
{
    public class ExplicitLoadCollection
    {
        public static void Run()
        {
            var context = new EFCoreDbContext();
            try
            {
         
                Console.WriteLine("\nExplicit Loading Student Related Data\n");
                // Load a student (only student data is loaded initially)
                var student = context.Students.FirstOrDefault(s => s.StudentId == 2);
                // Display basic student information
                if (student != null)
                {
                    Console.WriteLine($"\nStudent Id: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Gender: {student.Gender} \n");

                    // Explicitly load the Courses collection for the student
                    context.Entry(student).Collection(s=> s.Courses).Load();

                    foreach(var course in student.Courses)
                    {
                        Console.WriteLine($"Course: {course.Name}");
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
        }
    }
}
