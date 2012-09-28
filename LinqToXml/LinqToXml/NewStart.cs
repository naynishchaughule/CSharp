using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Xml.XPath;

namespace LinqToXml
{
    class NewStart
    {
        static void Main(string[] args)
        {
            //XDocument doc = XDocument.Load("LinqToXml");
            //var result = (from item in doc.Descendants("Employee")
            //             where item.Element("ID").Value == "48090"
            //             select item).Single();
            //Console.WriteLine(result.Parent.Attribute("OrgCode").Value);
            //Console.WriteLine(result.Element("Fname").Value);
            //result.Element("ID").Value = "65985";
            //doc.Save("LinqToXml");
            Transform();
            Console.ReadLine();
        }

        private static void Transform()
        {
            XDocument doc = XDocument.Load("LinqToXml");
            var result = new XElement("PatniEmployees", 
                         from item in doc.Descendants("Employee")           
                         select new XElement("StarEmployee", 
                         new XElement("EmpID", item.Element("ID").Value),                             
                         new XElement("FirstName", item.Element("Fname").Value)                                 
                         ));
            result.Save("EmpDetails");
            Console.WriteLine(File.ReadAllText("EmpDetails"));
        }

        static void Display()
        {
            Console.WriteLine(File.ReadAllText("NewXML"));
        }
    }
}
