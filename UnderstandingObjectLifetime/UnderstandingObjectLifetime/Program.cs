using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderstandingObjectLifetime
{
    class Program
    {
        static void Main(string[] args)
        {            
            MyCustomDictionary.myDictionary.Add("int", 10);
            MyCustomDictionary.myDictionary.Add("double", 20.45);
            MyCustomDictionary.myDictionary.Add("hello world!", 10);
            foreach (KeyValuePair<Object, Object> item in MyCustomDictionary.myDictionary)
            {
                Console.WriteLine(item.Key);
            }
            Console.WriteLine("\nretrieve value given a key");
            Console.WriteLine(MyCustomDictionary.GetValue("int"));

            Console.WriteLine("\nretrieve keys given a value");
            List<Object> values = MyCustomDictionary.GetKey(10);            
            foreach (Object item in values)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nusing sorted dictionary");
            Product p1 = new Product(834662, "Pro .NET", 34.56);
            Product p2 = new Product(834663, "AA Batteries", 34.56);
            Product p3 = new Product(834664, "Reebok Shoes", 34.56);
            Product p4 = new Product(834665, "T - Shirt", 34.56);
            ShoppingCart sc1 = new ShoppingCart();
            sc1.SortedDictionary.Add(p1.Id, p1);
            sc1.SortedDictionary.Add(p2.Id, p2);
            sc1.SortedDictionary.Add(p3.Id, p3);
            sc1.SortedDictionary.Add(p4.Id, p4);
            sc1.SortedDictionary.Remove(p1.Id);
            double CartTotal = 0;
            foreach (KeyValuePair<Object, Object> item in sc1.SortedDictionary)
            {
                CartTotal += ((Product)item.Value).Cost;
            }
            Console.WriteLine("your cart total is {0}", CartTotal);

            Employee emp1 = new Employee();            
            Console.WriteLine("\nEmployee Id {0}", emp1.Id);
            //just clips the connection between the reference and the object on the managed heap
            //does not invoke the GC or destroys the object immediately
            //far less consequential
            emp1 = null;
            //managed class having unmanaged resources (such as raw OS file handles, raw unmanaged database connections, chunks of unmanaged
            //memory)

            //If you attempt to “use” an object that does not implement IDisposable, you will receive a compiler error
            //possible to declare multiple objects of the same type within a using scope
            using (FinalizableObjects fObj = new FinalizableObjects())
            {
                //fObj.Dispose is automatically called when using scope exits
                //using maps to try-finally block with a call to Dispose()
            }
            //finished using it so marked it null
            //before my object falls out of scope, i want to dispose it off
            //developers may fail to call dispose method
            //strategy 1: try-catch-finally
            //strategy 2: using keyword
            //if (fObj is IDisposable)
            //{
            //    fObj.Dispose();
            //}
            //fObj = null;            
            //System.GC
            //MembersOfGC();
            ManyObjects();
            Console.ReadLine();
        }

        public static void MembersOfGC()
        {
            //true, GC before returning
            Console.WriteLine(GC.GetTotalMemory(true));
            //When you manually force a garbage collection, you should always make a call to
            //GC.WaitForPendingFinalizers(). With this approach, you can rest assured that all finalizable objects
            //have had a chance to perform any necessary cleanup before your
            //program continues.            
            // Only investigate generation 1 objects
            GC.Collect(1);
            //GC.WaitForPendingFinalizers() will suspend the calling “thread”
            //during the collection process. This is a good thing, as it ensures your code does not invoke methods on
            //an object currently being destroyed
            GC.WaitForPendingFinalizers();
            Console.WriteLine("Collection count {0}",GC.CollectionCount(0));
            //0, 1 and 2
            Console.WriteLine(GC.MaxGeneration + 1);
            Console.WriteLine(GC.GetGeneration(MyCustomDictionary.myDictionary));
        }

        public static void ManyObjects()
        {
            Console.WriteLine("Collection count gen0: {0}, gen1: {1},  gen2: {2}", GC.CollectionCount(0), GC.CollectionCount(1), GC.CollectionCount(2));
            Console.WriteLine("gen of myDictionary: {0}", GC.GetGeneration(MyCustomDictionary.myDictionary));
            System.Object[] arr = new System.Object[9000000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new System.Object();
            }
            Console.WriteLine("Collection count gen0: {0}, gen1: {1},  gen2: {2}", GC.CollectionCount(0), GC.CollectionCount(1), GC.CollectionCount(2));
            Console.WriteLine("gen of myDictionary: {0}", GC.GetGeneration(MyCustomDictionary.myDictionary));
        }
    }
}
