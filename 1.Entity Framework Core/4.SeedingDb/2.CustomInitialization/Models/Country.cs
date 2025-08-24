using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInitialization.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        [MaxLength(100)]
        public required string CountryName { get; set; }
        [Required]
        [MaxLength(10)]
        public required string CountryCode { get; set; }

        //Navigation Prop
        public ICollection<State>  States { get; set; }
    }
}
