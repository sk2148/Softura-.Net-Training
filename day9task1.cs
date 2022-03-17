using System;
interface Mem
{
void Platinum();
void Gold();
void Silver();
}
class Pack:Mem
{
public void Silver()
{
Console.WriteLine("3 Days Accommodation at Resort");
}
public void Gold()
{
Console.WriteLine("5 Days Accommodation at Resort"+" & "+"2 Dinners on the House");
}
public void Platinum()
{
Console.WriteLine("7 Days Accommodation at Resort"+" & "+"5 Dinners on the House");
}
}
class interfce
{
public static void Main()
{
Pack pac=new Pack();
pac.Silver();
pac.Gold();
pac.Platinum();
}
}
