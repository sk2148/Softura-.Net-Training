using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Dataa
{
    class Enrol_tbl
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-VUVG2NF;database=Trail;user id=sa;password=P@ssw0rd");
        public void Enroll_Insert(int id,string fname,string lname,char gender,string email,string phone)
        {
            string sqlqry = "insert tbl_enroll values("+id+",'"+fname+"','"+lname+"','"+gender+"','"+email+"','"+phone+"')";
            SqlCommand cmd = new SqlCommand(sqlqry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Row Inserted");
        }
        public void Enroll_Update(int id,string lname)
        {
            string sqlqry = "update tbl_enroll set Lname='"+lname+"' where Id="+id+"";
            SqlCommand cmd = new SqlCommand(sqlqry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Row Updated");
        }
        public void Enroll_Delete(int id)
        {
            SqlConnection con = new SqlConnection("data source=DESKTOP-VUVG2NF;database=Trail;user id=sa;password=P@ssw0rd");
            string sqlqry = "delete tbl_enroll where Id="+id+"";
            SqlCommand cmd = new SqlCommand(sqlqry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Row Deleted");
        }
        public void InsSp(int Id,string fname,string lname,char gender,string email,string phone)
        {
            SqlCommand cmd = new SqlCommand("sp_InsEnroll", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@gender", SqlDbType.Char).Value = gender;
            cmd.Parameters.Add("email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Row Inserted using Stored Procedure");
        }
        public void UpdSp(int Id,string lname)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdEnroll", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Row Updated Using Stored Procedure");
        }
        public void DelSp(int Id)
        {
            SqlCommand cmd = new SqlCommand("sp_DelEnroll", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Row Deleted Using Stored Procedure");
        }
        public static void Main()
        {
            Enrol_tbl obj = new Enrol_tbl();
            Console.WriteLine("Enter the Function To be Performed:" + "\n" +"1.Insert"+"\n"+"2.Update"+"\n"+"3.Delete");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter the ID:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the First Name:");
                string fname = Console.ReadLine();
                Console.WriteLine("Enter the Last Name:");
                string lname = Console.ReadLine();
                Console.WriteLine("Enter the Gender:");
                char gender = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Enter the EmailID:");
                string email = Console.ReadLine();
                Console.WriteLine("Enter the Phone Number:");
                string phone = Console.ReadLine();
                obj.Enroll_Insert(id, fname,lname,gender,email,phone);
                //obj.InsSp(id, fname, lname, gender, email, phone);
            }
            else
                if (choice == 2)
            {
                Console.WriteLine("Enter the Id :");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Last Name To be Changed:");
                string lname = Console.ReadLine();
                //obj.Enroll_Update(id, lname);
                obj.UpdSp(id, lname);
            }
            else
                if (choice == 3)
            {
                Console.WriteLine("Enter The Id To be Deleted:");
                int Id = Convert.ToInt32(Console.ReadLine());
                //obj.Enroll_Delete(Id);
                obj.DelSp(Id);
            }
            else
                Console.WriteLine("Invalid Operation");
        }
    }
}
