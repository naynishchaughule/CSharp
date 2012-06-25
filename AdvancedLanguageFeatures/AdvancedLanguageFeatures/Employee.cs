using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    class Employee
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Double Salary { get; set; }

        public Employee(int id, string name, double salary)
        {
            Id = id; Name = name; Salary = salary;
        }

        public override string ToString()
        {
            return String.Format("Employee Id: {0}, Name: {1}, Salary: {2}", Id, Name, Salary);
        }
    }
}
