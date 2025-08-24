using _1.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.LINQ
{
    public class Search
    {
        public static void Run()
        {
            try
            {
                var context = new EFCoreDbContext();

                string searchFirstName = "Alice";
                //LINQ Query Syntax
                var searchQS = (from student in context.Students
                                where student.FirstName == searchFirstName
                                select student).ToList();
                //LINQ Method Syntax
                var searchMS = context.Students //access the students DbSet
                    .Where(s => s.FirstName == searchFirstName) // filter students with the given first Name
                    .ToList(); //executes the query and returns result as a list

                //check is the student is found
                if (!searchMS.Any())
                {
                    //no student found
                    Console.WriteLine("No student found with the given firstname");
                }
                else
                {
                    foreach (var student in searchMS)
                    {
                        Console.WriteLine($"Student Found: {student.FirstName}  {student.LastName}  {student.Email}");
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
