using System;
class task5
{
public static void Main()
{
string[][] Product=new string[3][];
Product[0]=new string[]{"Britinia","Treat","Parle","Sunfeast"};
Product[1]=new string[]{"Dairy milk","Five star","Nestle","Munch","Kitkat"};
Product[2]=new string[]{"Coke","7up","Pepsi","Thumbs up","Miranda","Fanta"};
for(int i=0;i<Product.Length;i++)
{
for(int j=0;j<Product[i].Length;j++)
Console.Write(Product[i][j]+"\t");
Console.WriteLine();
}
}
}