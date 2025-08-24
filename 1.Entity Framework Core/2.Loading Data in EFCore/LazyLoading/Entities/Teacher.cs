using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoading.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}

/*
 Relationships:
Branch: A Teacher works in one Branch (one-to-one).
Subjects: A Teacher can teach multiple Subjects (one-to-many).
Address: A Teacher has one Address (one-to-one relationship).
 */