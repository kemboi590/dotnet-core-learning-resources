using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoading.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Fees { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}


/*
 Relationships:
Students: A Course can have multiple Students (one-to-many).
Subjects: A Course can have multiple Subjects (one-to-many).
 */