using System;
class arith1
{
public void Add(int n1,int n2)
{
int add;
add=n1+n2;
Console.WriteLine("Using Add:"+add);
}
public void Sub(int n1,int n2)
{
int sub;
sub=n1-n2;
Console.WriteLine("Using Sub:"+sub);
}
}
class arith2:arith1
{
public void Mul(int n1,int n2)
{
int mul;
mul=n1*n2;
Console.WriteLine("Using Mul:"+mul);
}
public void Div(int n1,int n2)
{
float div;
div=(float)n1/n2;
Console.WriteLine("Using Div:"+div);
}
class arith
{
public static void Main()
{
arith2 obj=new arith2();
int num1;
int num2;
Console.WriteLine("Enter the Numbers to Perform Basic Arithmatic Operations :");
num1=Convert.ToInt32(Console.ReadLine());
num2=Convert.ToInt32(Console.ReadLine());
obj.Add(num1,num2);
obj.Sub(num1,num2);
obj.Mul(num1,num2);
obj.Div(num1,num2);
}
}
}