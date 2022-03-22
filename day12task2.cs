using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp2
{
    [Serializable]
    class Employee
    {
        public string Id = "XYZ89";
        public String EmpName = "Santhosh Kumar";
        public string EmpGender = "Male";
        public int EmpAge = 22;
    }
    class Emp
    {
        public void SeriToFile()
        {
            Employee obj = new Employee();
            FileStream fs = new FileStream("EmpDetails.txt", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter f = new BinaryFormatter();
            f.Serialize(fs, obj);
            fs.Close();
        }
        public void DeserialData()
        {
            FileStream fs = new FileStream("EmpDetails.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter f = new BinaryFormatter();
            Employee ed = (Employee)f.Deserialize(fs);
            Console.WriteLine(ed.Id);
            Console.WriteLine(ed.EmpName);
            Console.WriteLine(ed.EmpGender);
            Console.WriteLine(ed.EmpAge);
        }

        public static void Main()
        {
            Emp eobj = new Emp();
            eobj.SeriToFile();
            eobj.DeserialData();
            Console.Read();
        }

    }
}
