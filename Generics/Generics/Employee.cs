using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    class Employee
    {
        public Int32 Id { get; set; }
        public String Fname { get; set; }
        public Double Salary { get; set; }

        public Employee()
        {

        }

        public Employee(int id, string fname, double salary)
        {
            Id = id; Fname = fname; Salary = salary;
        }

        public override string ToString()
        {
            return String.Format("\nId: {0}, Fname: {1}, Salary: {2:C}", Id, Fname, Salary);
        }
    }
}
