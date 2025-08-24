using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSeeding.Models
{
    [Table("States")]
    public class State
    {
        [Key]
        public int StateId { get; set; }

        [Required]
        [MaxLength(100)]
        public required string StateName { get; set; }
        public int CountryId { get; set; } //FK

        //Navigation
        public Country country { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
