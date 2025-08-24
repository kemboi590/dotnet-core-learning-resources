using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagerLoading.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public Address Address { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}

/*
 Relationships:
Branch: A Teacher works in one Branch (one-to-one).
Subjects: A Teacher can teach multiple Subjects (one-to-many).
Address: A Teacher has one Address (one-to-one relationship).
 */