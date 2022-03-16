using System;
class Tax1
{
public virtual void calculateTax(int price)
{
float vat;
vat=(float)(price*(1+0.2));
Console.WriteLine("Vat:"+vat);
}
}
class Tax2:Tax1
{
public override void calculateTax(int price)
{
float gst;
gst=(float)(price*12)/100;
Console.WriteLine("Gst:"+gst);
}
}
class Tax
{
public static void Main()
{
int amount;
Console.WriteLine("Enter the Amount to Pay Tax:");
amount=Convert.ToInt32(Console.ReadLine());
Tax2 obj=new Tax2();
obj.calculateTax(amount);
Tax1 obj1=new Tax1();
obj1.calculateTax(amount);
}
}