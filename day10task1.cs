using System;
class Age
{
int age;
public Age(int a)
{
age=a;
Console.WriteLine("Constructor 1");
Console.WriteLine("Age is "+a+"yrs old");
}
}
class Name:Age
{
String name;
public Name(String str, int n):base(n)
{
name= str;
Console.WriteLine("Constructor 2");
Console.WriteLine("Name is "+name);
}

class members
{
public static void Main()
{
Name obj= new Name("Santhosh",21);
}
}
}