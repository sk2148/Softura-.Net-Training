using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Dataa
{
    class Act
    {
        class product
        {
            public int prodid { get; set; }
            public int units { get; set; }
            public void ProdDetails()
            {
                SqlConnection con = new SqlConnection("data source=DESKTOP-VUVG2NF;database=Trail;user id=sa;password=P@ssw0rd");
                SqlCommand cmd = new SqlCommand("select Prod_ID,Prod_Name,dbo.fn_rupis(Price) as Price,Manufac_Date,Exp_Date from Product", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("ID: " + dr[0] + " |Name: " + dr[1] + " |Price: " + dr[2] + " |Manufactured Date: " + dr[3] + " |Expiry Date :" + dr[4]);
                }
                con.Close();
            }
            public int tot(int prodid, int units)
            {
                SqlConnection con = new SqlConnection("data source=DESKTOP-VUVG2NF;database=Trail;user id=sa;password=P@ssw0rd");
                SqlCommand cmd1 = new SqlCommand("select Price*" + units + "from Product where Prod_ID=" + prodid + "", con);
                con.Open();
                SqlDataReader dr = cmd1.ExecuteReader();
                while (dr.Read())
                {
                    int tot = Convert.ToInt32(dr[0]);
                    return tot;
                }
                con.Close();
                return 0;
            }
            public void InsPurchase(int prodid, int units, int custid, int total)
            {
                SqlConnection con = new SqlConnection("data source=DESKTOP-VUVG2NF;database=Trail;user id=sa;password=P@ssw0rd");
                SqlCommand cmd = new SqlCommand("insert Purchase values(" + custid + "," + prodid + "," + units + "," + total + ",getdate()) ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        class customer : product
        {
            public int custid { get; set; }
            public void ValCustID(int custid)
            {
                SqlConnection con = new SqlConnection("data source=DESKTOP-VUVG2NF;database=Trail;user id=sa;password=P@ssw0rd");
                SqlCommand cmd = new SqlCommand("select Name from Customer where Cust_ID=" + custid + "", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("\n" + " WELCOME! : " + dr[0]);
                }
                if (dr.HasRows)
                {
                    con.Close();
                    Console.WriteLine("\n" + "*******The Products Available*****************");
                    ProdDetails();
                }
                else
                {
                    Console.WriteLine("***Sorry!You'r not an Existing Customer***" + "\n" + "***Do You Wish To Create New(Y/N):***");
                    string choice = Console.ReadLine();
                    if (choice == "Y")
                    {
                        Console.WriteLine("Enter Your Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Gender(M/F):");
                        char gender = Convert.ToChar(Console.ReadLine());
                        Console.WriteLine("Enter Date of Birth:");
                        string Dob = Console.ReadLine();
                        Console.WriteLine("Enter Contact Number:");
                        string contact = Console.ReadLine();
                        Console.WriteLine("Enter MailID:");
                        string mail = Console.ReadLine();
                        Console.WriteLine("Enter the City: Choose from," + "\n" + " Chennai " + "\n" + " Mumbai " + "\n" + " Kolkata " + "\n" + " Delhi ");
                        string city = Console.ReadLine();
                        CustomerNew(name, gender, Dob, contact, mail, city);
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
            public void CustomerNew(string name, char gender, string Dob, string contact, string mail, string city)
            {
                SqlConnection con = new SqlConnection("data source=DESKTOP-VUVG2NF;database=Trail;user id=sa;password=P@ssw0rd");
                SqlCommand cmd = new SqlCommand("CustomerIns", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@gender", SqlDbType.Char).Value = gender;
                cmd.Parameters.Add("@Dob", SqlDbType.VarChar).Value = Dob;
                cmd.Parameters.Add("@contact", SqlDbType.Char).Value = contact;
                cmd.Parameters.Add("mail", SqlDbType.VarChar).Value = mail;
                cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = city;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("\n" + "You Have Successfully Registered!" + "\n" + "Do You Wish To Buy(Y/N):");
                string a = Console.ReadLine();
                if (a == "Y")
                {
                    Console.WriteLine("\n" + "The Products Available Are:");
                    ProdDetails();
                    Console.WriteLine("\n" + "Enter the Product ID:");
                    prodid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter How Many Units:");
                    units = Convert.ToInt32(Console.ReadLine());
                    int total = tot(prodid, units);
                    InsPurchase(prodid, units, custid, total);
                    Console.WriteLine("\n" + "Current Bill");
                    ShowCurBill();
                    Environment.Exit(0);
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            public void ShowCurBill()
            {
                SqlConnection con = new SqlConnection("data source=DESKTOP-VUVG2NF;database=Trail;user id=sa;password=P@ssw0rd");
                SqlCommand cmd = new SqlCommand("select top 1 Bill_No,Cust_ID,Prod_ID,Quantity,Total_Amount from Purchase  order by Bill_No desc ", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("Bill NO: " + dr[0] + " |Customer ID: " + dr[1] + " |Product ID: " + dr[2] + " |Quantity: " + dr[3] + " |Total Amount:Rs." + dr[4]);
                }
                con.Close();
            }
            public void CusPurDetails(int custid)
            {
                SqlConnection con = new SqlConnection("data source=DESKTOP-VUVG2NF;database=Trail;user id=sa;password=P@ssw0rd");
                SqlCommand cmd = new SqlCommand("select Bill_No,Cust_ID,Prod_ID,Quantity,Total_Amount from Purchase where Cust_ID = " + custid + "", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("Bill NO: " + dr[0] + " |Customer ID: " + dr[1] + " |Product ID: " + dr[2] + " |Quantity: " + dr[3] + " |Total Amount :Rs." + dr[4]);
                }
                con.Close();
            }
            public void CusPurDetailsByDate(int custid)
            {
                SqlConnection con = new SqlConnection("data source=DESKTOP-VUVG2NF;database=Trail;user id=sa;password=P@ssw0rd");
                SqlCommand cmd = new SqlCommand("select * from Purchase where Cust_ID =" + custid + " order by Pur_Date", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("Bill No: " + dr[0] + " |Customer ID: " + dr[1] + " |Product ID: " + dr[2] + " |Quuantity: " + dr[3] + " |Total Amount :Rs." + dr[4] + " |Purchased Date :" + dr[5]);
                }
                con.Close();
            }
        }

        public static void Main()
        {
            Console.WriteLine("Enter Your Customer ID:");
            customer cobj = new customer();
            cobj.custid = Convert.ToInt32(Console.ReadLine());
            cobj.ValCustID(cobj.custid);
            Console.WriteLine("\n" + "Enter The Product ID You Wish To Buy:");
            cobj.prodid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How Many Units You Want:");
            cobj.units = Convert.ToInt32(Console.ReadLine());
            int total = cobj.tot(cobj.prodid,cobj.units);
            cobj.InsPurchase(cobj.prodid, cobj.units, cobj.custid, total);
            Console.WriteLine("\n" + "***Current Bill***");
            cobj.ShowCurBill();
            Console.Write("\n"+"Do You Wish To See All Your Purchase History(Y/N):");
            string a = Console.ReadLine();
            if (a == "Y")
                cobj.CusPurDetails(cobj.custid);
            else
                Console.Clear();
            Console.WriteLine("\n" + "Do You Wish To See Purchase History By Date(Y/N):");
            string b = Console.ReadLine();
            if (b == "Y")
                cobj.CusPurDetailsByDate(cobj.custid);
            else
                Environment.Exit(0);
        }
    }
}
