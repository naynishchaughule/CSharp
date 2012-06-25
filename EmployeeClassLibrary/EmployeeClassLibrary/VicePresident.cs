using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmployeeClassLibrary
{
    public class VicePresident : Employee
    {
        public VicePresident() : base (48090, "naynish", "chaughule", "Senior Software Engineer", "202-714-5352", "2400 Virginia Ave NW, Apt - C#903, Washington - DC", 85000)
        {
            MessageBox.Show("Version 2.0.0.0");
        }

        public VicePresident(Int32 id, String fname, String lname, String designation, String phone, String address, Double salary) 
            : base (id, fname, lname, designation, phone, address, salary)
        {

        }
    }
}
