using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace project2.Models
{
    public class Product
    {
        public int Productid { get; set; }
        public string Productname { get; set; }
        public string size { get; set; }
        public int price { get; set; }
    }
}
