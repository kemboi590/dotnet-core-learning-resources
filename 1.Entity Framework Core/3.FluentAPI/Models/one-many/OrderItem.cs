using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotation.Models.one_many
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int OrderId { get; set; } // FK, Required Relationship
        public Order Order { get; set; } // Navigation property
    }
}
