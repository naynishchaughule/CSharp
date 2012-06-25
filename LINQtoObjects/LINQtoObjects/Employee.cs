using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQtoObjects
{
    class Employee
    {
        public Int32 Id { get; set; }
        public String Fname { get; set; }
        public String Company { get; set; }
        public Double Salary { get; set; }

        public Employee()
        {

        }

        public override string ToString()
        {
            return String.Format("Employee details Id: {0}, Fname: {1}, Company: {2}, Salary: {3}", Id, Fname, Company, Salary);
        }
    }
}
