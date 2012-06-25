using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructuredExceptionHandling
{
    class Class2
    {
        public void Relay()
        {
            Class1 c1 = new Class1();
            try
            {
                c1.Display();
            }
            //processing an exception
            catch (MyCustomException e)
            {
                Console.WriteLine("exception partially handled - rethrowing it up the call stack");
                //throw;
                //i encounter a new exception
                InvalidCastException ice = new InvalidCastException("inner exception - nash");
                try
                {                    
                    throw ice;
                }
                    
                catch (Exception e1)
                {
                    throw new MyCustomException("new exception occurred", ice, DateTime.Now);
                }
            }
        }
    }
}

