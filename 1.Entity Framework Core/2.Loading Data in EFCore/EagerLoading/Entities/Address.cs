using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagerLoading.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int? StudentId { get; set; }
        public Student Student { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }

}

/*
 Relationships:
Student: An address can be assigned to one Student (one-to-one).
Teacher: An address can be assigned to one Teacher (one-to-one).
 */
