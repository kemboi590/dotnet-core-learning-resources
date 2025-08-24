using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInitialization.Models
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        [MaxLength(100)]
        public required string CityName { get; set; }
        public int StateId { get; set; } //FK

        //Navigation prop
        public State State { get; set; }
    }
}
