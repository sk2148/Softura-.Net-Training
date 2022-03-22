using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1

{
    class day12task1
    {
        public static void Main()
        {

            FileStream fs = new FileStream("Restaurant.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            List<string> des = new List<String>();
            des.Add("Smoke Hub Desserts");
            des.Add("Coconut Truffle");
            des.Add("Rasamalai");
            des.Add("Caramel Custard");
            des.Add("Bread Halwa");
            des.Add("Lichi Mousse");
            foreach (string d in des)
            {
                sw.Write("\n" + d);
            }
            sw.Flush();
            sw.Close();
            fs.Close();
            FileStream fs1 = new FileStream("Restaurant.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs1);
            String s = sr.ReadToEnd();
            sr.Close();
            fs1.Close();
            Console.WriteLine(s);
            FileInfo fi = new FileInfo("Restaurant.txt");
            Console.WriteLine(fi.Length);
            Console.WriteLine(fi.CreationTime);
            Console.Read();
        }
    }
}
