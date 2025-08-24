using _1.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.LINQ
{
    public class Sort
    {
        public static void Run()
        {
            try
            {
                var context =  new EFCoreDbContext();
                //LINQ Query Syntax
                var  sortedStudentsQS = (from student in context.Students
                                         orderby student.Gender ascending,
                                         student.EnrollmentDate descending
                                         select student).ToList();

                //LINQ Mathod Syntax
                var sortedStudentsMS = context.Students
                    .OrderBy(s => s.Gender) //primarily sort gender by ascending order
                    .ThenByDescending(s => s.EnrollmentDate) // secondary sort enrolment by descending order
                    .ToList();

                //check if students are found
                if(sortedStudentsMS.Count == 0)
                {
                    //no student found
                    Console.WriteLine("No student found ");
                }
                else
                {
                    foreach (var student in sortedStudentsMS)
                    {
                        Console.WriteLine($"Student: {student.LastName} {student.EnrollmentDate.ToShortDateString()}");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
        }
    }
}
