using System;
class login
{
public void check(string a,string b)
{
 Console.WriteLine("Email Id & Password has been entered");
}
public void check(int c ,int d)
{
Console.WriteLine("Membership Id & Pin has been entered"); 
}
public void check(string c,int d)
{
 Console.WriteLine("Mobile number & Pin has been entered");
}
public static void Main()
{
login obj=new login();
obj.check("sk2148@srmist.edu.in","ps1234");
obj.check(45899,2530);
obj.check("9945005045",8977);
}
}