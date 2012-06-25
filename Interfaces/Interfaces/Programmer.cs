using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    class Programmer : AbstractEmployeeBaseClass, ISalary
    {
        Dictionary<Object, Object> myDictionary = new Dictionary<Object, Object>();
        ISalary s;
        public Programmer()
        {

        }

        public Programmer(int id, double salary)
        {
            s = this;
            s.Id = id;
            s.Salary = salary;
            s.Dictionary.Add(s.Id, s.Salary);
        }

        int id;
        int ISalary.Id
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
        double ISalary.Salary
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

        Dictionary<object, object> ISalary.Dictionary
        {
            get
            {
                return myDictionary;
            }
        }

        void ISalary.ShowSalaryDetails()
        {
            foreach (KeyValuePair<Object, Object> item in s.Dictionary)
            {
                Console.WriteLine("Dictionary-Programmer Id: {0}, Salary: {1:C}", item.Key, item.Value);
            } 
        }
    }
}
