using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleApp
{
    class SoftwareDeveloper : Employee
    {
        public SoftwareDeveloper(int empId, string fname, string lname, string address = "2400 virginia ave",
            string designation = "Software Developer", double salary = 85000)
            : base(empId, fname, lname, address, designation, salary)
        {

        }
    }
}
