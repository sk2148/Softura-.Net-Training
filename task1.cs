using System;
class Electricity
{
public static void Main()
{
int units,bill,p;
Console.WriteLine("Units Consumed:");
units=Convert.ToInt32(Console.ReadLine());
if(units<=200)
{
bill=units*2;
}
else if(units>200&&units<=350)
{
p=units-200;
bill=400+(p*3);
}
else if(units>350&&units<=500)
{
p=units-350;
bill=850+(p*5);
}
else{
p=units-500;
bill=1600+(p*7);
}
Console.WriteLine("Electricity bill to be Paid is:"+bill);
}
}
