using _1.LINQ.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.LINQ
{
    public class Group
    {
        public static void Run()
        {

            try
            {
                var context = new EFCoreDbContext();
                //Group students by their branch using Query syntax
                var groupedStudentsQS = (from students in context.Students
                                         .Include(s => s.Branch)
                                         group students by
                                         students.Branch.BranchName into studentGroup
                                         select new
                                         {
                                             BranchName = studentGroup.Key,
                                             StudentCount = studentGroup.Count()
                                         }).ToList();

                //Group students by their branch using Query syntax
                var groupedStudentsMS = context.Students
                    .Include(s => s.Branch) //fetch all students and their related branch data
                     .GroupBy(s => s.Branch.BranchName) // Group students by BranchName i.e (all students of computer scinece in one hand and mechanical engineering on the other
                     .Select(g => new //transform each group into a new shape object with 2 properties
                     {
                         // g.Key is the BranchName in this case
                         BranchName = g.Key, //unique and becomes a key since we used branchName to group

                         // Count the number of students in each group
                         StudentCount = g.Count()
                     }).ToList();// bring the grouped data as a list in memory

                /* TRANSLATES TO THIS SQL
                 SELECT Branch.BranchName, COUNT(*) AS StudentCount
                 FROM Students
                 JOIN Branch ON Students.BranchId = Branch.BranchId
                 GROUP BY Branch.BranchName;
                 */

                //check if any groups were found
                if (groupedStudentsMS.Count == 0)
                {
                    Console.WriteLine("No students found");
                }
                else
                {
                    foreach (var group in groupedStudentsQS)
                    {
                        Console.WriteLine($"\nBranch: {group.BranchName}, Number of Students: {group.StudentCount}");
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
