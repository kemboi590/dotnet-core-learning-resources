using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Entities
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }


        //collection navigation prop  1 branch -> many students
        public ICollection<Student>? Students { get; set; }

    }
}
