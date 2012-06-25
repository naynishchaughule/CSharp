using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderstandingObjectLifetime
{
    class FinalizableObjects : System.Object, IDisposable
    {
        ClassUnmanagedResources cumr = new ClassUnmanagedResources();
        //if you are building managed classes that maintain internal unmanaged resources
        //necessary cleanup logic for your type, defined as protected
        //the garbage collector will call an object’s Finalize() method
        //finalizer never takes an access modifier (they are implicitly protected), never takes parameters, and
        //can’t be overloaded (only one finalizer per class)
        //CLR will automatically invoke finalizers upon AppDomain shutdown
        //nondeterministic in nature
        //allocate objects, CLR knows it has a Finalize() method
        //Finalization Queue maintains a pointer to this method
        //during GC the CLR moves the objects pointed by the Finalization Queue to another managed 
        //structure "Finalization Reachable Table 'eff-reachable'"
        //a separate thread is spawned to invoke the Finalize() method for each object
        //on the freachable table at the next garbage collection
        //takes two GC to actually Finalize an object
        //all this happens when the GC is invoked and hence it is non-deterministic
        //if you have costly resources that you want to release immediately use IDisposable interface
        ~FinalizableObjects()
        {
            // Clean up unmanaged resources here.
            //ildasm.exe
            //try-catch
            //finally will call the base class's Finalize()            
            Console.WriteLine("FinalizableObjects finalize called");
            //Console.Beep();
            //// Do **not** call Dispose() on any managed objects.
        }

        //Structures and class types can both implement IDisposable
        //You can dispose objects even before the object falls out of scope using this technique
        //it is perfectly safe to communicate with other managed objects within a Dispose() method
        //GC does not know about this method
        //GC is not invoked yet at this stage, hence i can assume that the other contained objects are still alive
        public void Dispose()
        {
            Console.WriteLine("Dispose() called");
            cumr.Dispose();
            //the resources are cleaned up
            GC.SuppressFinalize(this);
        }
        //the problem with the entire approach is code duplication in Finalize() and Dispose()
    }
}
