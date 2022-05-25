using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models

{
    public class Addpatient
    {
        
            [Key]
            [Required]
            public int Patientid { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Sex { get; set; }
        public int Age { get; set; }
        public string DateofBirth { get; set; }
        
    }
    }

