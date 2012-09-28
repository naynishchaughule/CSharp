using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace LinqToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            doc.AppendChild(declaration);

            XmlComment comment = doc.CreateComment("my first xml document");
            doc.AppendChild(comment);

            XmlElement Employee = doc.CreateElement("Employee");            
            doc.AppendChild(Employee);            
            Employee.SetAttribute("ID", "48090");

            XmlElement Fname = doc.CreateElement("Fname");
            Fname.InnerXml = "naynish";
            Employee.AppendChild(Fname);            

            XmlElement Lname = doc.CreateElement("Lname");
            Lname.InnerXml = "chaughule";
            Employee.AppendChild(Lname);

            XmlElement Salary = doc.CreateElement("Salary");
            Salary.InnerXml = "85000";
            Employee.AppendChild(Salary);

            doc.Save("FirstXml");
            Console.WriteLine("{0}", File.ReadAllText("FirstXml"));
            Console.WriteLine();
            SimpleXmlUsingLinq();
            Traverse();
            Update();
            Console.ReadLine();
        }

        private static void Update()
        {
            Console.WriteLine();
            Console.WriteLine("Update work");
            XDocument doc = XDocument.Load("LinqToXml");
            var ID = doc.XPathSelectElement("//Employee[ID = '48090']");
            XElement mobile = new XElement("Mobile", "202-714-5352");
            ID.Add(mobile);
            ID.Element("Salary").Remove();
            ID.SetElementValue("Mobile", "9920053379");
            ID.SetElementValue("Salary", 55000);
            doc.Save("LinqToXml");
            Console.WriteLine(ID);            
        }

        private static void Traverse()
        {
            Console.WriteLine();
            var Employee = XDocument.Load("LinqToXml");
            var Salary = Employee.XPathSelectElements("//Employee[Fname = 'naynish']");
            foreach (var item in Salary)
            {
                Console.WriteLine(item.Element("Salary").Value);
            }            
        }

        private static void SimpleXmlUsingLinq()
        {
            var result = new XDocument
                (
                new XDeclaration("1.0", "UTF-8", "yes"),
                new XComment("using linq"),
                new XElement("Employees", new XAttribute("OrgCode", "382"),
                    new XElement("Employee",
                        new XElement("ID", "48090"),
                        new XElement("Fname", "naynish"),
                        new XElement("Lname", "chaughule"),
                        new XElement("Salary", "85000")
                                )
                            )               
                );
            result.Save("LinqToXml");
            Display();
        }

        private static void Display()
        {
            Console.WriteLine("{0}", File.ReadAllText("LinqToXml"));
        }
    }
}
