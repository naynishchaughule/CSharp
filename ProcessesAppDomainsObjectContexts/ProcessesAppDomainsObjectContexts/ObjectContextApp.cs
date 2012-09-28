using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Contexts; //for context types
using System.Threading;

namespace ProcessesAppDomainsObjectContexts
{
    public class SportsCar
    {
        public SportsCar()
        {
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("\n{0} object in Context {1}", this.ToString(), ctx.ContextID);
            foreach (IContextProperty item in ctx.ContextProperties)
            {
                Console.WriteLine(item.Name);
            }
        }
    }

    //All context attributes derive from the ContextAttribute base class.
    /*
    Types that are attributed with the [Synchronization] attribute are loaded into a thread-safe context.
    Given the special contextual needs of the SportsCarTS class type, imagine the problems that would occur
    if an allocated object were moved from a synchronized context into a nonsynchronized context. The
    object is suddenly no longer thread safe and thus becomes a candidate for massive data corruption, as
    numerous threads are attempting to interact with the (now thread-volatile) reference object. To ensure
    the CLR does not move SportsCarTS objects outside of a synchronized context, simply derive from
    ContextBoundObject.
    */
    [Synchronization]
    public class SportsCarTS : ContextBoundObject
    {
        public SportsCarTS()
        {
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("\n{0} object in Context {1}", this.ToString(), ctx.ContextID);
            foreach (IContextProperty item in ctx.ContextProperties)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
