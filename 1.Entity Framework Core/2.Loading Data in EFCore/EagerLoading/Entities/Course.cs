using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagerLoading.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Fees { get; set; }
        public ICollection<Student> Students { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}


/*
 Relationships:
Students: A Course can have multiple Students (one-to-many).
Subjects: A Course can have multiple Subjects (one-to-many).
 */