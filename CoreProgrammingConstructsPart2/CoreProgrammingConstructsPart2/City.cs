using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProgrammingConstructsPart2
{
    class City
    {
        //If a reference type is passed by reference, the callee may change the values of the object’s state data as well as the object it is referencing.
        // If a reference type is passed by value, the callee may change the values of the object’s state data but not the object it is referencing.
        int code;
        string name;

        public City(int code, string name)
        {
            this.code = code;
            this.name = name;
        }

        public void ChangeState(ref City myCity)
        {
            myCity.code = 00000;
            myCity.name = "null";

            myCity = new City(007, "bond");
        }

        public void Display(City c)
        {
            Console.WriteLine("{0} {1}", c.code, c.name);
        }
    }
}
