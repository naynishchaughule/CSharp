using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    //pull out an interface from this class
    //right click on class --> Refactor --> Extract Interface (select public members you want in your interface)

    class VicePresident : AbstractEmployeeBaseClass, ISalary
    {
        Dictionary<Object, Object> myDictionary = new Dictionary<Object, Object>();
        public VicePresident(int id, double salary)
        {
            Id = id; Salary = salary;
            myDictionary.Add(Id, Salary);
        }

        int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        double salary;
        public double Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }
        
        public Dictionary<Object, Object> Dictionary
        {
            get
            {
                return myDictionary;
            }            
        }

        public void ShowSalaryDetails()
        {
            foreach (KeyValuePair<Object, Object> item in Dictionary)
            {
                Console.WriteLine("Dictionary-VicePresident Id: {0}, Salary: {1:C}", item.Key, item.Value);    
            }            
        }
    }
}
