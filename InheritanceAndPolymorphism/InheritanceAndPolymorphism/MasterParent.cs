using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    class MasterParent : Object
    {
        public void ShowDetials()
        {
            VicePresident emp1 = new VicePresident(48090);
            VicePresident emp2 = new VicePresident(48091);
            VicePresident emp3 = emp1;
            emp1.SetEmployee(emp1, emp2);
            Console.WriteLine(emp1.Equals(emp2));
            Console.WriteLine(emp2.ToString());
            Console.WriteLine(emp1.GetHashCode());
            Console.WriteLine(emp2.GetHashCode());
            Console.WriteLine(emp3.GetHashCode());

            //messed up the equals and get hash code

            //still have an option of calling the static methods
            //checks if the two references point to the same object in the memory
            Console.WriteLine(System.Object.Equals(emp1, emp3));
        }        
    }
}
