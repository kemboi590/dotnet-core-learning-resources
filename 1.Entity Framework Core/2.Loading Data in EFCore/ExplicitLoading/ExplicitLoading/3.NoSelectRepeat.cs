using LazyLoading.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoading.ExplicitLoading
{
    public class NoSelectRepeat
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


                    // Explicitly load the Branch navigation property for the student
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


                    // Explicitly load the Branch navigation property for the student
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


/*
 How EF Core Handles Explicit Loading?
When we explicitly load a related entity using methods like Reference().Load() or Collection().Load(), EF Core will check if the navigation property is already loaded in the current context.

EF Core will not send another query if the navigation property is already loaded (i.e., its data is tracked in the DbContext).
EF Core will send a SELECT query to retrieve the data if the navigation property is not loaded.
 


First Explicit Load of Branch:
When we first call context.Entry(student).Reference(s => s.Branch).Load(), EF Core sends an SQL query to the database to load the Branch related to the student. EF Core’s change tracker then stores this data in memory.
The change tracker keeps track of entities and their navigation properties in the current DbContext instance.
Second Explicit Load of Branch:
When we make the second call to context.Entry(student).Reference(s => s.Branch).Load(); EF Core sees that the Branch navigation property for that student is already loaded in the current DbContext.
As a result, EF Core does not send another SQL query to the database because the related entity (Branch) is already in the tracked state of the DbContext. Instead, it simply uses the previously loaded data, thereby avoiding redundant queries.
 */