using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleApp
{
    class ProjectManager : Employee
    {
        public ProjectManager(int empId, string fname, string lname, string address = "independence ave",
            string designation = "Project Manager", double salary = 150000)
            : base(empId, fname, lname, address, designation, salary)
        {
            
        }
    }
}
