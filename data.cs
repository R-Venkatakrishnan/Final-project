using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;
using project2.Models;
using System.Data;

namespace project2.DAL
{
    public class data
    {
        public string cnn = "";
        public data()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:Conn").Value;
        }

        public int CheckUse(Signup us)
        {
            SqlConnection conn = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("usertbl", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@urname", us.username);
            cmd.Parameters.AddWithValue("@pass", us.password);
            conn.Open();
            IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return (1);

            conn.Close();
            return (0);
        }
        public int signupp(Signup AD)
        {
            int result;
            SqlConnection conn = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("usertable", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@urname", AD.username);
            cmd.Parameters.AddWithValue("@pass", AD.password);
            cmd.Parameters.AddWithValue("@fname", AD.Firstname);
            cmd.Parameters.AddWithValue("@sex", AD.Sex);
            cmd.Parameters.AddWithValue("@dob", AD.DateofBirth);
            cmd.Parameters.AddWithValue("@ad", AD.address);
            cmd.Parameters.AddWithValue("@mn", AD.mobilenumber);
            conn.Open();
            result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }


public List<Product> Displayproduct(int id)
{
    List<Product> listproducts = new List<Product>();
            //List<cart> listcart = new List<cart>();
            using (SqlConnection con = new SqlConnection(cnn))
    {
                //SqlCommand cmd = new SqlCommand("productinfo"+" "+ id, con);

                //cmd.Parameters.AddWithValue("@productid", id);
                SqlCommand cmd = new SqlCommand("productinfo" , con);
                SqlCommand cmd1 = new SqlCommand("insertcart", con);
                cmd.CommandType=
                System.Data.CommandType.StoredProcedure;
                cmd1.CommandType =
              System.Data.CommandType.StoredProcedure;
                //cmd.CommandText = "INSERT INTO cart (ProductID)" +
                //    "VALUES (@productid)";
                cmd.Parameters.AddWithValue("@productid", id);
                
                if (con.State == ConnectionState.Closed)
               
                        con.Open();
                   
                    IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())

            {
                    cart car = new cart();
                    listproducts.Add(new Product()
                    {
                        Productid = int.Parse(reader["Productid"].ToString()),
                        Productname = reader["Productname"].ToString(),
                        price = int.Parse(reader["price"].ToString())


                   
                }) ;
            }

                //cmd.ExecuteNonQuery();
               
            }
   
    return listproducts;
}
        public int addcart(cart AD)
        {
            int result;
       
            SqlConnection conn = new SqlConnection(cnn);
            SqlCommand cmd1 = new SqlCommand("insertcart", conn);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@pid", AD.productid);
            cmd1.Parameters.AddWithValue("@pname", AD.productname);
        
            cmd1.Parameters.AddWithValue("@price", AD.price);

            conn.Open();
            result = cmd1.ExecuteNonQuery();
            conn.Close();
            return result;
                 }
        }
}


//public int Products(Signup AD)
//{
//    int result;
//    SqlConnection conn = new SqlConnection(cnn);
//    SqlCommand cmd = new SqlCommand("usertable", conn);
//    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//    cmd.Parameters.AddWithValue("@urname", AD.username);
//    cmd.Parameters.AddWithValue("@pass", AD.password);
//    cmd.Parameters.AddWithValue("@fname", AD.Firstname);
//    cmd.Parameters.AddWithValue("@sex", AD.Sex);
//    cmd.Parameters.AddWithValue("@dob", AD.DateofBirth);
//    cmd.Parameters.AddWithValue("@ad", AD.address);
//    cmd.Parameters.AddWithValue("@mn", AD.mobilenumber);
//    conn.Open();
//    result = cmd.ExecuteNonQuery();
//    conn.Close();
//    return result;
//}
//    }
