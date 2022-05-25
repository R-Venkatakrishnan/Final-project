using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
      public int PatientID { get; set; }
        public string SpecializationRequired { get; set; }
        public string Doctor { get; set; }
        public string VisitDate { get; set; }

        public string AppointmentTime { get; set; }
    }
}
