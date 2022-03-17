using System;
public abstract class Arith
{
public abstract void Add(int n1,int n2);
public abstract void Sub(int n1,int n2);
public abstract void Mul(int n1,int n2);
public abstract void Div(int n1,int n2);
}
class Operations:Arith
{
public override void Add(int n1,int n2)
{
int res=n1+n2;
Console.WriteLine("Using Add:"+res);
}
public override void Sub(int n1,int n2)
{
int res=n1-n2;
Console.WriteLine("Using Sub:"+res);
}
public override void Mul(int n1,int n2)
{
int res=n1*n2;
Console.WriteLine("Using Mul:"+res);
}
public override void Div(int n1,int n2)
{
float res=(float)n1/n2;
Console.WriteLine("Using Div:"+res);
}
}
class Calculator
{
public static void Main()
{
Operations obj=new Operations();
Console.WriteLine("Enter The Numbers:");
int num1=Convert.ToInt32(Console.ReadLine());
int num2=Convert.ToInt32(Console.ReadLine());
obj.Add(num1,num2);
obj.Sub(num1,num2);
obj.Mul(num1,num2);
obj.Div(num1,num2);
}
}

