using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class UserService
    {
        public string connectionstring { get; set; }
        public UserService()
        {
            connectionstring = ConfigurationManager.ConnectionStrings["Sqlconnection"].ToString();
        }

        public List<User> getusers()
        {

            List<User> userlist = new List<User>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    string sql = "Select * from users";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            User user = new User();
                            user.id = Int32.Parse(rdr["ID"].ToString());
                            user.firstname = rdr["FirstName"].ToString();
                            user.lastname = rdr["LastName"].ToString();
                            user.emailid = rdr["EmailID"].ToString();
                            user.mobilenumber = rdr["MobileNumber"].ToString();
                            userlist.Add(user);
                        }

                    }

                }
            }
            catch (Exception ex)
            {

            }
           

            return userlist;
        }

        public void createuser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("Createuser", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@firstname", SqlDbType.NVarChar).Value = user.firstname;
                        cmd.Parameters.AddWithValue("@lastname", SqlDbType.NVarChar).Value = user.lastname;
                        cmd.Parameters.AddWithValue("@emaildID", SqlDbType.NVarChar).Value = user.emailid;
                        cmd.Parameters.AddWithValue("@mobilenumber", SqlDbType.NVarChar).Value = user.mobilenumber;
                        cmd.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception)
            {
            }
           
        }

        public User getuserbyid(long id)
        {
            User user = new User();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("getuserbyid", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = id;
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            user.id = Int32.Parse(rdr["ID"].ToString());
                            user.firstname = rdr["FirstName"].ToString();
                            user.lastname = rdr["LastName"].ToString();
                            user.emailid = rdr["EmailID"].ToString();
                            user.mobilenumber = rdr["MobileNumber"].ToString();
                    
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }
            return user;
        }

        public void updateuser(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("updateuser", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = user.id;
                        cmd.Parameters.AddWithValue("@firstname", SqlDbType.NVarChar).Value = user.firstname;
                        cmd.Parameters.AddWithValue("@lastname", SqlDbType.NVarChar).Value = user.lastname;
                        cmd.Parameters.AddWithValue("@emaildID", SqlDbType.NVarChar).Value = user.emailid;
                        cmd.Parameters.AddWithValue("@mobilenumber", SqlDbType.NVarChar).Value = user.mobilenumber;
                        cmd.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception)
            {
            }

        }

        public void deleteuser(long ID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("deleteuser", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", SqlDbType.BigInt).Value = ID;
                        cmd.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception)
            {
            }

        }

    }
}