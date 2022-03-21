using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp1
{
    public class Emp
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Gender { get; set; }
        public int Age { get; set; }
    }
    class day11task2
    {
        public static void Main()
        {

            FileStream fs = new FileStream("C:\\softura\\training\\Emp.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter bw = new StreamWriter(fs);
            Emp obj = new Emp();
            obj.Id =75456;
            obj.Name = "Dheepak";
            obj.Gender = "Male";
            obj.Age = 21;
            bw.WriteLine(obj.Id);
            bw.WriteLine(obj.Name);
            bw.WriteLine(obj.Gender);
            bw.WriteLine(obj.Age);
            bw.Flush();
            fs.Close();
            FileStream fs1 = new FileStream("C:\\softura\\training\\Emp.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs1);
            String str = sr.ReadToEnd();
            sr.Close();
            fs1.Close();
            Console.WriteLine(str);
            Console.Read();

        }

    }
}
