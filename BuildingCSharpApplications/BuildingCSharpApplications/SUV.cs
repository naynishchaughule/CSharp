using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuildingCSharpApplications
{
    public class SUV : Car
    {
        public SUV(string name):base(name)
        {

        }

        public string GetName()
        {
            return _name;
        }
    }
}
