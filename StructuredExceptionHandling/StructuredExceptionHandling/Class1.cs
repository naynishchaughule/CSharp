using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructuredExceptionHandling
{
    class Class1
    {
        public void Display()
        {
            Console.WriteLine("Display() in Class1");
            throw new MyCustomException("rethrown");
        }
    }
}
