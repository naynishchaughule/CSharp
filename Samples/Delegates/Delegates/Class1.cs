using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    class Class1
    {        
        public bool Method1()
        {
            int i = 20;
            if (i < 40)
            {
                //successful execution of method
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Method2()
        {
            int i = 30;
            if (i < 40)
            {
                //successful execution of method
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
