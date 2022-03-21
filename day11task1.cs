using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class day11task1
    {
        public static void Main()
        {

            FileStream fs = new FileStream("C:\\softura\\training\\Restaurant Dessert.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter bw = new StreamWriter(fs);
            List<string>des = new List<String>(); 
            des.Add("Coconut Truffle");
            des.Add("Rasamalai");
            des.Add("Caramel Custard");
            des.Add("Bread Halwa");
            des.Add("Lichi Mousse");
            foreach (string d in des)
            {
                bw.Write("\n"+d);
            }
            bw.Flush();
            bw.Close();
            fs.Close();
            FileStream fs1 = new FileStream("C:\\softura\\training\\Restaurant Dessert.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs1);
            String s = sr.ReadToEnd();
            sr.Close();
            fs1.Close();
            Console.WriteLine(s);
            FileInfo fi = new FileInfo(@"C:\softura\training\Restaurant Dessert.txt");
            Console.WriteLine(fi.Length);
            Console.WriteLine(fi.CreationTime);
            Console.Read();
        }
    }
}
