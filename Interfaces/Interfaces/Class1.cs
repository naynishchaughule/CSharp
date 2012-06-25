using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{    
    interface Class1
    {
    }

    //struct's cannot extend or derive from abstract classes but can implement interfaces
    //but one such exception is all the structs in the .NET universe derive from an abstract class called System.ValueType
    //other than this structs never support inheritance
    struct My : Class1, ISalary
    {
        Dictionary<object, object> myStructDictionary;
        public My(int id1, double sal)
        {
            id = id1;
            salary = sal;
            myStructDictionary = new Dictionary<object, object>();
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

        public Dictionary<object, object> Dictionary
        {
            get { return myStructDictionary; }
        }

        public void ShowSalaryDetails()
        {
            Console.WriteLine("struct show sal called...");
        }
    }
}
