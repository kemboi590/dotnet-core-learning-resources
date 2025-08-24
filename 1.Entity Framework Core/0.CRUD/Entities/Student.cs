using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime EnrollmentDate { get; set; }

        //navigation prop -> student and the branch
        public virtual Branch? Branch { get; set; }

    }
}
