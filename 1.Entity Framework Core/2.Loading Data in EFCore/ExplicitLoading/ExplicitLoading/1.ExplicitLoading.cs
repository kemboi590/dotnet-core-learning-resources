using LazyLoading.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoading.ExplicitLoading
{
    public class ExplicitLoading
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

                    //Explicitly Load the Branch Navigation property for the student
                    context.Entry(student).Reference(s => s.Branch).Load();
                    // Check if Branch is null before accessing its properties
                    if (student.Branch != null)
                    {
                        Console.WriteLine($"\nBranch Location: {student.Branch.BranchLocation}, Email: {student.Branch.BranchEmail}, Phone: {student.Branch.BranchPhoneNumber} \n");
                    }
                    else
                    {
                        Console.WriteLine("\nBranch data not available.\n");
                    }

                    // Explicitly load the Address navigation property for the student
                    context.Entry(student).Reference(s=> s.Address).Load();
                    // Check if Address is null before accessing its properties
                    if (student.Address != null)
                    {
                        Console.WriteLine($"\nAddress: {student.Address.Street}, {student.Address.City}, {student.Address.State}, Pin: {student.Address.PostalCode} \n");
                    }
                    else
                    {
                        Console.WriteLine("\nAddress data not available.\n");
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
