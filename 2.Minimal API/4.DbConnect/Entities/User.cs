using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace _4.DbConnect.Entities
{
    public class User : IdentityUser
    {
        //[Required]
        public string FullName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;



    }
}
