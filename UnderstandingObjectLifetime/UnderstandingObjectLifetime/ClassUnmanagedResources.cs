using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderstandingObjectLifetime
{
    class ClassUnmanagedResources : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("DISPOSE of ClassUnmanagedResources");            
        }
    }
}
