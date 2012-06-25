using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    interface IEmployeePrototype
    {
        int Id { get; set; }
        string Fname { get; set; }
        double Salary { get; set; }
        void ShowDetails();
    }
}
