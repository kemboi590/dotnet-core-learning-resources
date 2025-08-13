

using EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
           try
            {
                //ceate an instance with the db
                var context = new EFCoreDbContext();

                ////adding 2 students
                //AddBranches(context);

                //// add 2 branches
                //AddStudents(context);

                ////retrieving all students
                GetAllStudents(context);


                //// Retrieve and display a single student by ID
                //GetStudentById(context, 1);

                //// Update a student's information
                //UpdateStudent(context, 1);


                //// Delete a student by ID
                //DeleteStudent(context, 1);

                ////Get all students
                //GetAllStudents(context);

                Console.WriteLine("All operations completed successfully!");
            }
            catch  (Exception ex) 
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void AddBranches(EFCoreDbContext context)
        {
            //create 2 branches
            var branch1 = new Branch
            {
                BranchName = "Computer Science",
                Description = "Focuses on software development and computing technologies.",
                PhoneNumber = "123-456-7890",
                Email = "cs@dotnettutorials.net"
            };

            var branch2 = new Branch
            {
                BranchName = "Electrical Engineering",
                Description = "Focuses on electrical systems and circuit design.",
                PhoneNumber = "987-654-3210",
                Email = "ee@dotnettutorials.net"
            };

            //add branches to context
            context.Branches.Add(branch1);
            context.Branches.Add(branch2);

            //save changes to the db
            context.SaveChanges();
            Console.WriteLine("Branches have been added successfully");
        }

        private static void AddStudents(EFCoreDbContext context)
        {
            var csBranch = context.Branches.FirstOrDefault(b => b.BranchName == "Computer Science");
            var eeBranch = context.Branches.FirstOrDefault(b => b.BranchName == "Electrical Engineering");

            //Create 2 new students
            // Create two new Student objects
            var student1 = new Student
            {
                FirstName = "Pranaya",
                LastName = "Rout",
                DateOfBirth = new DateTime(2000, 1, 15),
                Gender = "Female",
                Email = "Pranaya.Rout@dotnettutorials.net",
                PhoneNumber = "555-1234",
                EnrollmentDate = DateTime.Now,
                Branch = csBranch // Assign the Computer Science branch
            };
            var student2 = new Student
            {
                FirstName = "Rakesh",
                LastName = "Kumar",
                DateOfBirth = new DateTime(1999, 10, 22),
                Gender = "Male",
                Email = "Rakesh.Kumar@dotnettutorials.net",
                PhoneNumber = "555-5678",
                EnrollmentDate = DateTime.Now,
                Branch = eeBranch // Assign the Electrical Engineering branch
            };

            //add the students to the context
            context.Students.Add(student1);
            context.Students.Add(student2);

            //save the changes
            context.SaveChanges();
            Console.WriteLine("Students added successfully");
        }


        private static void GetAllStudents(EFCoreDbContext context)
        { 
            //retrieve all the students from the context
            var students = context.Students.Include(s => s.Branch).ToList();

            //Display the students in the console
            Console.WriteLine("All students");
            foreach(var student in students)
            {
                Console.WriteLine($"\t {student.StudentId}: {student.FirstName} {student.LastName}, Branch: {student.Branch?.BranchName}");
            }
        }

        //get students by ID
        private static void GetStudentById(EFCoreDbContext context, int studentId)
        {
        //retrieve a single student by ID
        var student = context.Students.Include(s => s.Branch).FirstOrDefault(s => s.StudentId == studentId);

            if(student != null)
            {
                Console.WriteLine($"Student found: {student.FirstName} {student.LastName}, Branch: {student.Branch?.BranchName}");
            } else
            {
                Console.WriteLine($"Student with ID {studentId} not found.");
            }
        }

        //updating a student
        private static void UpdateStudent(EFCoreDbContext context, int studentId)
        {
            // Retrieve the student from the context
            var student = context.Students.FirstOrDefault(s => s.StudentId == studentId);

            if (student != null)
            {
                // Update the student's information
                student.LastName = "UpdatedLastName";
                student.Email = "updated.email@dotnettutorials.net";
                // Save changes to the database
                context.SaveChanges();
                Console.WriteLine($"Student with ID {studentId} updated successfully.");
            }
            else
            {
                Console.WriteLine($"Student with ID {studentId} not found.");
            }
        }

        //delete student
        private static void DeleteStudent(EFCoreDbContext context, int studentId)
        {
            // Retrieve the student from the context
            var student = context.Students.FirstOrDefault(s => s.StudentId == studentId);

            if (student != null)
            {
                // Remove the student from the context
                context.Students.Remove(student);
                // Save changes to the database
                context.SaveChanges();
                Console.WriteLine($"Student with ID {studentId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Student with ID {studentId} not found.");
            }
        }

    }
}


//Ref

//https://dotnettutorials.net/lesson/database-connection-string-in-entity-framework-core/