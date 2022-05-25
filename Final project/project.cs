using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;
using FinalProject.Models;
using System.Data;

namespace FinalProject.DAL
{
    public class project
    {
        public string cnn = "";
        public project()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:Conn").Value;
        }
        public int DoctorAd(Adddoctor AD)
        {
            int result;
            SqlConnection conn = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("doctor", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fname", AD.FirstName);
            cmd.Parameters.AddWithValue("@lname", AD.LastName);
            cmd.Parameters.AddWithValue("@sex", AD.Sex);
            cmd.Parameters.AddWithValue("@sp", AD.Specialization);
            cmd.Parameters.AddWithValue("@vh", AD.VistingHours);
            conn.Open();
            result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        public int PatientAD(Addpatient AD)
        {
            int result;
            SqlConnection conn = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Addpatient", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fname", AD.FirstName);
            cmd.Parameters.AddWithValue("@lname", AD.LastName);
            cmd.Parameters.AddWithValue("@sex", AD.Sex);
            //cmd.Parameters.AddWithValue("@age", AD.Age);
            cmd.Parameters.AddWithValue("@dob", AD.DateofBirth);
            conn.Open();
            result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public int ADDAPPOINTMENT(Appointment AD)
        {
            int result;
            SqlConnection conn = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Appointent", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", AD.PatientID);
            cmd.Parameters.AddWithValue("@spec", AD.SpecializationRequired);
            cmd.Parameters.AddWithValue("@doctor", AD.Doctor);
            cmd.Parameters.AddWithValue("@visit", AD.VisitDate);
            cmd.Parameters.AddWithValue("@atime", AD.AppointmentTime);
            conn.Open();
            result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public int CheckUse(user us)
        {
            SqlConnection conn = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("usertable", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@un", us.Username);
            cmd.Parameters.AddWithValue("@Pas", us.Password);
            conn.Open();
            IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return (1);

            conn.Close();
            return (0);
        }
        //public List<Appointment> Displayapt()
        //{
        //    List<Appointment> listSchedules = new List<Appointment>();
        //    using (SqlConnection con = new SqlConnection(cnn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("Displayapt", con))
        //        {
        //            if (con.State == ConnectionState.Closed)
        //                con.Open();
        //            IDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                listSchedules.Add(new Appointment()
        //                {
        //                    PatientID = int.Parse(reader["PatientID"].ToString()),
        //                    SpecializationRequired = reader["SpecializationRequired"].ToString(),
        //                    Doctor = reader["Doctor"].ToString(),
        //                    VisitDate = reader["VisitDate"].ToString(),
        //                    AppointmentTime = reader["AppointmentTime"].ToString()
        //                });
        //            }

        //        }
        //    }
        //    return listSchedules;
        //}

        public List<Appointment> Displayapt()
        {
            List<Appointment> listSchedules = new List<Appointment>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("displayappointment", con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listSchedules.Add(new Appointment()
                        {
                            AppointmentID = int.Parse(reader["AppointmentID"].ToString()),
                            PatientID = int.Parse(reader["PatientID"].ToString()),
                            SpecializationRequired = reader["SpecializationRequired"].ToString(),
                            Doctor = reader["Doctor"].ToString(),
                            VisitDate = reader["VisitDate"].ToString(),
                            AppointmentTime = reader["AppointmentTime"].ToString()
                        });
                    }

                }
            }
            return listSchedules;
        }

        public int Deletedat(int id)
        {
            int result;
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("DelAppointment ", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }











        //public int Deletedat(int id)
        //{
        //    int result;
        //    SqlConnection con = new SqlConnection(cnn);
        //    SqlCommand cmd = new SqlCommand("delapt", con);
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@id", id);
        //    con.Open();
        //    result = cmd.ExecuteNonQuery();
        //    con.Close();
        //    return result;
        //}
        public List<Adddoctor> Displaydoc()
        {
            List<Adddoctor> listSchedules = new List<Adddoctor>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("Displaydoc", con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listSchedules.Add(new Adddoctor()
                        {
                            DoctorId = int.Parse(reader["DoctorId"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Sex = reader["Sex"].ToString(),
                            Specialization = reader["Specialization"].ToString(),
                            VistingHours = reader["VisitingHours"].ToString(),

                        });
                    }

                }
            }
            return listSchedules;
        }





    }
}

