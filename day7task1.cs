using System;
class task1
{
public static void Main()
{
Console.WriteLine("Enter Name:");
string name=Console.ReadLine();
Console.WriteLine("Enter Age:");
int age=Convert.ToInt32(Console.ReadLine());
for(int i=1;i<=age;i++)
{
Console.WriteLine(name);
}
}
}