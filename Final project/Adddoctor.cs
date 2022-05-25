using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FinalProject.Models
{
    public class Adddoctor
    {
        [Key]
        [Required]
        public int DoctorId { get; set; }

        [Required(ErrorMessage ="This field should not be left empty")]
        [RegularExpression("^[A-Za-z0-9]*$",ErrorMessage = "must not have special characters")]       
        public string FirstName { get; set; }
       
        [Required(ErrorMessage = "This field should not be left empty")]
       [RegularExpression("^[A-Za-z0-9]*$", ErrorMessage = "must not have special characters")]       
        public string LastName { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Specialization { get; set; }
        [Required]
        public string VistingHours { get; set; } 
    }
}
