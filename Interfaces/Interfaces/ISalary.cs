using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    interface ISalary
    {        
        int Id { get; set; }
        double Salary { get; set; }
        Dictionary<Object, Object> Dictionary { get; }
        void ShowSalaryDetails();
    }
}
