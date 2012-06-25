using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    class NameClash : IDisplayConsole, IDisplayWinForms, IDisplayWebForms
    {
        //public void Display()
        //{
        //    Console.WriteLine("\ncommon display logic...");
        //}

        //explicitly implemented members are automatically private
        //do not mark them as public
        void IDisplayWebForms.Display()
        {
            Console.WriteLine("\nIDisplayWebForms.Display() called");
        }

        void IDisplayWinForms.Display()
        {
            Console.WriteLine("\nIDisplayWinForms.Display() called");
        }

        void IDisplayConsole.Display()
        {
            Console.WriteLine("\nIDisplayConsole.Display() called");
        }

        //While this syntax is quite helpful when you need to resolve name clashes, you can use explicit
        //interface implementation simply to hide more “advanced” members from the object level. In this way,
        //when the object user applies the dot operator, he or she will see only a subset of the type’s overall
        //functionality. However, those who require the more advanced behaviors can extract out the desired
        //interface via an explicit cast.
        //general rule is to explicity implement the members having name clashes
        //rest others keep it simple
    }
}
