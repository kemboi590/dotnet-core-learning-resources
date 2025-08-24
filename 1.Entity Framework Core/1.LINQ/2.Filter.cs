using _1.LINQ.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.LINQ
{
    public class Filter
    {
        public static void Run() 
        {
            //Filter all students who are female and belongs to Computer Science Engineering branch
            try
            {
                var context = new EFCoreDbContext();

                //filtering creteria
                string brancName = "Computer Science Engineering";

                string gender = "Female";

                //LINQ Query Syntax
                var filteredStudentQS = (from student in context.Students
                                         .Include(s => s.Branch)
                                         where student.Branch.BranchName == brancName && student.Gender == gender
                                         select student).ToList();

                //lINQ Mathod Syntax
                var filteredStudentsMS = context.Students
                    .Include(s => s.Branch)
                    .Where(s => s.Branch.BranchName == brancName && s.Gender == gender)
                    .ToList();

                //checking if the student match the filtering creteria
                if (!filteredStudentsMS.Any())
                {
                    //no student found
                    Console.WriteLine("No students found matching the given criteria.");
                }
                else
                {
                    foreach (var student in filteredStudentsMS)
                    {
                        Console.WriteLine($"Student Found: {student.FirstName} {student.LastName} Branch: {student.Branch.BranchName} Gender: {student.Gender}");
                    }
                }
            }
            catch (Exception ex) 
            {
                // Exception handling: log the exception message
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
              
        }
    }
}
