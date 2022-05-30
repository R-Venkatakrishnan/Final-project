using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace project2.Models
{
    public class Signup
    {
        public string username { get; set; }
        public string password { get; set; }
        public string Firstname { get; set; }
        public string Sex { get; set; }
        public string DateofBirth { get; set; }
        public string address { get; set; }
        public string mobilenumber { get; set; }
    }
}
