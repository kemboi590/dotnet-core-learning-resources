using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotation.Models.many_many
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public List<Student> Students { get; set; } // Navigation property for many-to-many
    }
}
