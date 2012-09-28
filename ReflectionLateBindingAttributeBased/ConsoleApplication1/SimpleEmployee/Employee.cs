using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleEmployee
{
    public class Employee
    {
        public int Id { get; set; }
        public string Fname { get; set; }        
        public Employee()
        {
            Id = 48090; Fname = "Naynish";
        }

        public Employee(int id, string fname)
        {
            Id = id; Fname = fname;
        }

        public double CalculateSalary()
        {
            return 85000;
        }

        public double CalculateNewSalary(double salary, double bonus)
        {
            return salary + bonus;
        }

        public override string ToString()
        {
            return String.Format("Employee details:- Id: {0}, Fname: {1}", Id, Fname);
        }
    }
}
