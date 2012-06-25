using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleApp
{
    class UtilityClass
    {
        //salary of each employee in a given project
        public void SalaryOfEachEmployeeInProject(Project p)
        {
            Console.WriteLine("List of all Employees in project {0}", p.PName);
            foreach (Employee item in Program.EmployeeCollection)
            {
                if (item.ProjectAssigned.Contains(p))
                {
                    Console.WriteLine("name: {0}, salary {1}", item.Fname, item.Salary);
                }
            }            
        }
    }
}
