using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
namespace FinalProject.Models
{
    public class user
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "special characters not allowed")]
        
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "special characters not allowed")]
        public string Password { get; set; }
    }
}
