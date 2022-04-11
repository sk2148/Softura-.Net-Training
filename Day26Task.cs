using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lynq
{
    class Day26Task
    {
        public static void Main()
        {
            IList<Doctor> DocData = new List<Doctor>()
            {
                new Doctor(){DoctorID=1,DoctorName="Ananth Suganthi",DoctorAge=35,SpecialistID=101},
                new Doctor(){DoctorID=2,DoctorName="Badrinath",DoctorAge=40,SpecialistID=102},
                new Doctor(){DoctorID=3,DoctorName="Balamuralikrishna",DoctorAge=42,SpecialistID=103},
                new Doctor(){DoctorID=4,DoctorName="Ramamurthy",DoctorAge=38,SpecialistID=102},
                new Doctor(){DoctorID=5,DoctorName="Das Gautham",DoctorAge=35,SpecialistID=103}
            };
            IList<Specialization> SpecData = new List<Specialization>
            {
                new Specialization(){SpecialistID=101,Specialist="Gastro Surgeon"},
                new Specialization(){SpecialistID=102,Specialist="Ophthalmologist"},
                new Specialization(){SpecialistID=103,Specialist="Psychiatrist"},

            };
            var JoinDocdata = from spec in SpecData
                              join doc in DocData
                              on spec.SpecialistID equals doc.SpecialistID
                              into DocGroup
                              select new
                              {
                                  Doctors = DocGroup,
                                  SpecialzationName =spec.Specialist
                              };
            foreach (var item in JoinDocdata)
            {
                Console.WriteLine("\n"+item.SpecialzationName);
                foreach (var doct in item.Doctors)
                    Console.WriteLine("Doctor Name:Dr."+doct.DoctorName);
            }
            Console.WriteLine("\n"+"*********Using Anonymous Function*************");
            var JoinData = DocData.Join(
            SpecData,
               doc => doc.SpecialistID,
               spec => spec.SpecialistID,
               (doc, spec) => new
               {
                   DoctorName = doc.DoctorName,
                   SpecailistName = spec.Specialist
               }
               );
            foreach (var v in JoinData)
            {
                Console.WriteLine("Dr."+v.DoctorName + " Specialist In " + v.SpecailistName);
            }

        }
    }
    class Doctor
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public int DoctorAge { get; set; }

        public int SpecialistID { get; set; }
    }
    class Specialization
    {
        public int SpecialistID { get; set; }
        public string Specialist { get; set; }
    }
}
