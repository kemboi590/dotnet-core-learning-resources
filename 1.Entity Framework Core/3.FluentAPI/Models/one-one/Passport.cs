using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotation.Models
{
    public class Passport
    {
        public int Id { get; set; }
        public string PassportNumber { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
