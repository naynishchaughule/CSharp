using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmployeeInformation
{
    public abstract class Employee
    {
        public Int32 Id { get; set; }
        public String Fname { get; set; }
        public Double Salary { get; set; }

        public virtual void Display()
        {
            MessageBox.Show(String.Format("Employee Id: {0}, Fname: {1}, Salary: {2}",                
                Id, Fname, Salary));
        }

        public override string ToString()
        {
            return String.Format("Employee Id: {0}, Fname: {1}, Salary: {2}",
                Id, Fname, Salary);
        }
    }

    public class CEO : Employee
    {

    }

    public class VicePresident : Employee
    {

    }  
}
