using DataAnnotation.Models;
using DataAnnotation.Models.many_many;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotation
{
    public class ManyRelations
    {
        public static void Run()
        {
            try
            {
                var context = new EFCoreDbContext();
                //Will be back here
                //AddStudentsAndCourses(context);
                DisplayStudentsAndCourses(context);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex.Message}");
            }
        }

        //Method to add students and courses
        static void AddStudentsAndCourses(EFCoreDbContext context)
        {
            //creating courese
            var course1 = new Course { CourseName = "ASP .NET Core" };
            var course2 = new Course { CourseName = "Machine Learning" };
            var course3 = new Course { CourseName = "Cloud Computing" };

            //create new students
            var student1 = new Student { Name = "Brian Kemboi", Courses = new List<Course> { course1, course2 } };
            var student2 = new Student { Name = "Denis Wachira", Courses = new List<Course> { course2, course3} };
            var student3 = new Student { Name = "Daisy Nyambura", Courses = new List<Course> { course1, course3} };


            //add to context
           context.Students.AddRange(student1, student2, student3);

            //save changes to db
            context.SaveChanges();

            Console.WriteLine("Students and courses added to db \n");
        }
    
        static void DisplayStudentsAndCourses(EFCoreDbContext context)
        {
            //fetch all student and courses
            var students = context.Students
                .Include(s => s.Courses)
                .ToList();

            //display courses for each student
            foreach (var student in students)
            {
                Console.WriteLine($"Student ID: {student.Id}, Name: {student.Name}");

                //courses
                if(student.Courses.Count > 0)
                {
                    Console.WriteLine("Enrolled in the following courses");
                    foreach (var course in student.Courses)
                    {
                        Console.WriteLine($"\t Course ID: {course.Id}, Name: {course.CourseName}");
                        
                    }
                }
                else
                {
                    Console.WriteLine("No courese enrolled");
                }
                
            }
        }
    }
}
