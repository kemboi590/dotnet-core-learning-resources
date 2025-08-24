using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EagerLoading.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int BranchId { get; set; }
        //navigation prop -> student and the branch
        public Branch Branch { get; set; }
        public Address Address {  get; set; }

        public ICollection<Course> Courses { get; set; }

    }
}

/*
 Relationships:
Branch: A Student belongs to one Branch (one-to-one).
Courses: A Student can enroll in many Courses (one-to-many).
Address: A Student has one Address (one-to-one relationship).
 */