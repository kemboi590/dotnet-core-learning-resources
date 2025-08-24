using _1.LINQ.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.LINQ
{
    public class MoreGrouping
    {
        public static void Run()
        {
            try
            {
                var context = new EFCoreDbContext();
                // Grouping students by their Branch using Method Syntax
                var groupedStudentsMS = context.Students
                                                         .Include(s => s.Branch) // Eager loading of the Branch property
                                                         .GroupBy(s => s.Branch.BranchName) // Group students by BranchName
                                                         .Select(g => new
                                                         {
                                                             // g.Key is the BranchName in this case
                                                             BranchName = g.Key,

                                                             // Count the number of students in each group
                                                             StudentCount = g.Count(),

                                                             // Retrieve the list of students in each group
                                                             Students = g.ToList(),   
                                                         })
                                                         .ToList();

                // Check if any groups are found
                if (groupedStudentsMS.Count == 0)
                {
                    // Output if no students are found
                    Console.WriteLine("No students found.");
                }
                else
                {
                    // Iterate through the grouped students and display their details
                    foreach (var group in groupedStudentsMS)
                    {
                        // Output the Branch name and the number of students in that branch
                        Console.WriteLine($"\nBranch: {group.BranchName}, Number of Students: {group.StudentCount}");

                        // Display details of each student in the branch
                        foreach (var student in group.Students)
                        {
                            Console.WriteLine($"\tStudent: {student.FirstName} {student.LastName}, Email: {student.Email}, Enrollment Date: {student.EnrollmentDate.ToShortDateString()}");
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

}