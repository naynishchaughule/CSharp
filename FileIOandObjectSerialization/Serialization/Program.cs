using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary; //BinaryFormatter
using System.Runtime.Serialization.Formatters.Soap; //SoapFormatter
using System.Xml.Serialization; //XmlSerializer
using System.Runtime.Serialization; //IFormatter
using System.Runtime.Remoting.Messaging; //IRemotingFormatter
using System.IO;

namespace Serialization
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee();
            BinaryFormatter bf = new BinaryFormatter();
            //simple object access protocol
            SoapFormatter soap = new SoapFormatter();
            //requires a default constructor
            XmlSerializer xml = new XmlSerializer(typeof(Employee));
            using (Stream s = new FileStream("serial.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                SerializeDemo<Employee>(soap,s, emp1);
            }

            DeSerializeDemo(soap);

            //List<Employee> myList = new List<Employee>();
            //myList.Add(new Employee() { Id = 65985, Fname = "Tripti Panjabi", Salary = 65000 });
            //myList.Add(new Employee() { Id = 45783, Fname = "Purab Bhatt", Salary = 45200 });
            //XmlSerializer xml1 = new XmlSerializer(typeof(List<Employee>));
            //using (Stream sList = new FileStream("Collection.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            //{
            //    SerializeDemo<List<Employee>>(xml1, sList, myList);
            //}

            //DeSerializeCollectionDemo(xml1);            
            Console.ReadLine();
        }

        static void SerializeDemo<T>(IFormatter ift, Stream strm, T obj)
        {
          ift.Serialize(strm, obj);              
        }

        static void SerializeDemo<T>(XmlSerializer ift, Stream strm, T obj)
        {
            ift.Serialize(strm, obj);
        }

        static void DeSerializeDemo(IFormatter ift)
        {
            using (Stream s = File.OpenRead("serial.txt"))
            {
                Employee emp = (Employee)ift.Deserialize(s);
                Console.WriteLine("{0}, {1}, {2}, {3}", emp.Id, emp.Fname, emp.Salary, emp.tripz);
            }
        }

        static void DeSerializeDemo(XmlSerializer ift)
        {
            using (Stream s = File.OpenRead("serial.txt"))
            {
                Employee emp = (Employee)ift.Deserialize(s);
                Console.WriteLine("{0}, {1}, {2}", emp.Id, emp.Fname, emp.Salary);
            }
        }

        static void DeSerializeCollectionDemo(IFormatter ift)
        {
            using (Stream s = File.OpenRead("Collection.txt"))
            {
                List<Employee> emp = (List<Employee>)ift.Deserialize(s);
                foreach (Employee item in emp)
                {
                    Console.WriteLine("{0}, {1}, {2}", item.Id, item.Fname, item.Salary);
                }
            }
        }

        static void DeSerializeCollectionDemo(XmlSerializer ift)
        {
            using (Stream s = File.OpenRead("Collection.txt"))
            {
                List<Employee> emp = (List<Employee>)ift.Deserialize(s);
                foreach (Employee item in emp)
                {
                    Console.WriteLine("{0}, {1}, {2}", item.Id, item.Fname, item.Salary);    
                }                
            }
        }
    }
}
