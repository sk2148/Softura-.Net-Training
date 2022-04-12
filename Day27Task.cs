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
        public void Enroll_Insert()
        {
            SqlConnection con = new SqlConnection("data source=DESKTOP-VUVG2NF;database=Trail;user id=sa;password=P@ssw0rd");
            string sqlqry = "insert tbl_enrollment values('Shanmuga','Sanjai','M','sj7489','9988455667')";
            SqlCommand cmd = new SqlCommand(sqlqry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Row Inserted");
        }
        public void Enroll_Update()
        {
            SqlConnection con = new SqlConnection("data source=DESKTOP-VUVG2NF;database=Trail;user id=sa;password=P@ssw0rd");
            string sqlqry = "update tbl_enrollment set StuFname='Sanjai',StuLname='J'where StudentID=2002";
            SqlCommand cmd = new SqlCommand(sqlqry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Row Updated");
        }
        public void Enroll_Delete()
        {
            SqlConnection con = new SqlConnection("data source=DESKTOP-VUVG2NF;database=Trail;user id=sa;password=P@ssw0rd");
            string sqlqry = "delete tbl_enrollment where StudentID=2002";
            SqlCommand cmd = new SqlCommand(sqlqry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Row Deleted");
        }
        public void InsSp(string fname,string lname,char gender,string email,string phone)
        {
            SqlCommand cmd = new SqlCommand("sp_InsEnroll", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
        public void UpdSp(int Id,string fname,string lname)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdEnroll", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            Console.WriteLine("Row Updated Using Stored Procedure");
        }
        public void DelSp(int Id)
        {
            SqlCommand cmd = new SqlCommand("sp_DelEnroll", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            Console.WriteLine("Row Deleted Using Stored Procedure");
        }
        public static void Main()
        {
            Enrol_tbl obj = new Enrol_tbl();
            Console.WriteLine("Enter the ID:");
            int Id = Convert.ToInt32(Console.ReadLine());
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
            obj.Enroll_Insert();
            obj.InsSp(fname, lname, gender, email, phone);
            obj.Enroll_Update();
            obj.UpdSp(Id, fname, lname);
            obj.Enroll_Delete();
            obj.DelSp(Id);
        }
    }
}
