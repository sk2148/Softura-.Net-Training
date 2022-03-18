using System;
class Department
{
int esal;
public void salary(int sal)
{
esal=sal;
Console.WriteLine("Employee Salary is:"+esal);
}
public void department(string dep)
{
string d=dep;
double bonus=this.esal*0.2;
double b =this.esal*0.1;
if(dep=="sales&marketing")
{
Console.WriteLine("Bonus of sales & marketing:"+bonus);
}
else
{
Console.WriteLine("Bonus of production:"+b);
}
}
class EmployeeDetails:Department
{
int eid;string ename;string egender;int yoe;
public void emp_id(int id)
{
eid=id;
Console.WriteLine("Employee ID is:"+eid);
}
public void emp_name(string name)
{
ename=name;
Console.WriteLine("Employee Name is:"+ename);
}
public void emp_gender(string gender)
{
egender=gender;
Console.WriteLine("Employee Gender is:"+egender);
}
public void emp_YOE(int exp)
{
yoe=exp;
Console.WriteLine("Employee Experience is:"+yoe);
} 
}
class Employee
{
public static void Main()
{
EmployeeDetails obj=new EmployeeDetails();
Console.WriteLine("Enter the employee Id:");
int n=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the employee name:");
string n1=Console.ReadLine();
Console.WriteLine("Enter the employee Gender:");
string n2=Console.ReadLine();
Console.WriteLine("Enter the employee years of experience:");
int n3=Convert.ToInt32(Console.ReadLine());
EmployeeDetails obj2=new EmployeeDetails();
Console.WriteLine("Enter the employee salary:");
int n4=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the employee Department:");
string n5=Console.ReadLine();
obj.emp_id(n);
obj.emp_name(n1);
obj.emp_gender(n2);
obj.emp_YOE(n3);
obj2.salary(n4);
obj2.department(n5);
}
}
}