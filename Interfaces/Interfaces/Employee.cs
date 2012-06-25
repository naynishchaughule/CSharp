using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    class Employee : System.Object, IEmployeePrototype
    {
        //Resolving Name Clashes via Explicit Interface Implementation

        IEmployeePrototype e;    
        public Employee() : this (48090, "naynish", 85000)
        {

        }

        public Employee(int id, string fname, double salary)
        {
            e = this;
            e.Id = id;
            e.Fname = fname;
            e.Salary = salary;
        }

        int _id;
        int IEmployeePrototype.Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        string _fname;
        string IEmployeePrototype.Fname
        {
            get
            {
                return _fname;
            }
            set
            {
                _fname = value;
            }
        }

        double _salary;
        double IEmployeePrototype.Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
            }
        }

        void IEmployeePrototype.ShowDetails()
        {
            Console.WriteLine("id {0}, fname {1}, salary {2}", e.Id, e.Fname, e.Salary);
        }
    }
}
