using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using AdoMVC.Models;
using System.Data.SqlClient;
using System.Data;

namespace AdoMVC.DAL
{
    public class CustomerDAL
    {
        public string cnn = "";
        public CustomerDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:Conn").Value;
        }
        public List<Customer> GetAllCustomers()
        {
            List<Customer> listCustomer = new List<Customer>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllCustomers", con))
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                        con.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listCustomer.Add(new Customer()
                        {
                            CustomerID = int.Parse(reader["CustomerID"].ToString()),
                            CustomerName = reader["CustomerName"].ToString(),
                            EmailID = reader["EmailID"].ToString(),
                            MobileNo = reader["MobileNo"].ToString()
                        }); ;
                    }
                }
            }
            return listCustomer;
        }
        public List<Customer> NewCustomer(string cus, string em, string mb)
        {
            List<Customer> listCustomer = new List<Customer>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("NewCustomer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@cname",SqlDbType.VarChar).Value=cus;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = em;
                    cmd.Parameters.Add("@mobno", SqlDbType.VarChar).Value = mb;
                    cmd.ExecuteNonQuery();
                }
            }
            return listCustomer;
        }
    }
}
