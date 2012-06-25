using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProgrammingConstructsPart2
{
    class Employee
    {
        public Car obj;
        public int empID;
        public string empName;

        public Employee(Car obj, int empID, string empName)
        {
            this.obj = obj;
            this.empID = empID;
            this.empName = empName;
        }
    }
}
