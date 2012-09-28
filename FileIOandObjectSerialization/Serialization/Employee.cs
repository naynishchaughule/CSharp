using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization; //ISerializable

namespace Serialization
{
    [Serializable]
    public class Employee //: ISerializable
    {
        //[XmlAttribute]
        public int Id { get; set; }
        public string Fname { get; set; }

        [NonSerialized]
        public string tripz;

        [NonSerialized]
        public double Salary;
        public Employee()
        {
            Id = 48090;
            Fname = "Naynish P. Chaughule";
            Salary = 75000;
        }

        //de-serialization
        //protected Employee(SerializationInfo info, StreamingContext ctx)
        //{
        //    Id = info.GetInt32("Patni_Id");
        //    Fname = info.GetString("Patni_Fname");
        //    Salary = info.GetDouble("Salary");
        //    tripz = info.GetString("Tripti");            
        //}

        //serialization
        //void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue("Patni_Id", 6000);
        //    info.AddValue("Patni_Fname", "Jay Bhatt");
        //    info.AddValue("Salary", 56000);
        //    info.AddValue("Tripti", "Shopping");
        //}

        [OnSerializing]
        void PreSerializing(StreamingContext ctx)
        {
            //format
            Id = 460;
            Fname = "Kunal";
            Salary = 78000;
        }
    }
}
