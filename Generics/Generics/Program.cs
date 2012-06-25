using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    class Program
    {
        ArrayList arrList = new ArrayList();
        static void Main(string[] args)
        {
            Program p1 = new Program();
            Int32 intBoxed = 10, unboxed;
            //boxing
            Object obj = (Object)intBoxed;
            //unboxing
            try
            {
                Int16 newint = (Int16)obj;
            }
            catch (InvalidCastException ice)
            {
                Console.WriteLine(ice.Message);
            }
            finally
            {
                Int32 newint = (Int32)obj;
                unboxed = newint;
            }
            //Int32 newint = (Int32)obj;
            Console.WriteLine(unboxed);
            p1.WorkingWithArrayList();
            p1.WorkingWithQueue();
            p1.WorkingWithSortedList();
            p1.WorkingWithStack();
            p1.WorkingWithGenerics();
            p1.GenericListDemo();
            p1.GenericStack();
            Demo d1 = new Demo();
            int x = 10, y = 20;
            d1.Swap<Int32>(ref x, ref y);
            Product product1 = new Product(0001, "book", 3.45);
            Product product2 = new Product(0002, "file", 2.13);
            d1.Swap<Product>(ref product1, ref product2);
            //d1.Swap(ref product1, ref product2); //not a standard approach, always specify Type Parameters
            
            GenericStructure<Int32> myStruct = new GenericStructure<int>(10, 25);
            //myStruct.Reset();
            Console.WriteLine(myStruct);
            
            TypeParameterConstraints<SatisfyingConstraints> scObj = new TypeParameterConstraints<SatisfyingConstraints>();
            scObj.Show(new SatisfyingConstraints(34.678));

            FinalGenericDerivedClass<Product, Employee> objFGDC = new FinalGenericDerivedClass<Product, Employee>();
            objFGDC.Show();
            Console.WriteLine(objFGDC);
            Console.ReadLine();
        }

        public void GenericStack()
        {
            Stack<Product> stack = new Stack<Product>();
            stack.Push(new Product(001, "mouse stack", 12));
            stack.Push(new Product(002, "cookies", 20));
            Console.WriteLine("\npeek: " + stack.Peek());
            
            Queue<Product> q = new Queue<Product>();
            q.Enqueue(new Product(001, "mouse q", 12));
            q.Enqueue(new Product(002, "coffee", 4.78));
            Console.WriteLine(q.Peek());

            SortedSet<Product> ss = new SortedSet<Product>(new Product());
            ss.Add(new Product(001, "mouse", 19.78));
            ss.Add(new Product(002, "hello", 200));
            ss.Add(new Product(004, "cup", 4.6));
            ss.Add(new Product(003, "cake", 1.56));
            ss.Add(new Product(005, "tv", 120));
            Console.WriteLine("\nsorted set");
            foreach (Product item in ss)
            {
                Console.WriteLine(item);
            }
        }

        public void GenericListDemo()
        {
            List<Product> listOfProducts = new List<Product>()
            {
                new Product(001, "mouse", 12),
                new Product(002, "keyboard", 20),
                new Product(003, "pencil", 1.23)
            };
            Product p1 = new Product(000, "headset", 19.45);
            listOfProducts.Insert(1, p1);
            foreach (Product item in listOfProducts)
            {
                Console.WriteLine(item);
            }
            Product[] pArr = listOfProducts.ToArray();
        }

        public void WorkingWithArrayList()
        {
            //the members of any type in System.Collections are designed to work with type 'Object'
            //hence even if you insert a value type in these collections a performance hit is encountered due to boxing
            //to top it all its not type safe, i can insert anything in the below ArrayList
            //the only option left in this case is to create a custom type-safe collection class
            arrList.Add(10); arrList.Add(20); arrList.Add(30); //arrList.Add(40.34);
            foreach (Int32 item in arrList)
            {
                Console.Write(item + " ");
            }

            Employee emp1 = new Employee(48090, "naynish", 85000);
            Employee emp2 = new Employee(48091, "purab", 65000);
            Employee emp3 = new Employee(48092, "jay", 75000);
            //not inserted in the Hash Table
            Employee emp4 = new Employee(48093, "tripti", 60000);
            //Add these Employee objects to the custom collection
            EmployeeObjectCollection collection = new EmployeeObjectCollection();
            collection.Add(emp1); collection.Add(emp2); collection.Add(emp3);
            int key = 48095;
            if (collection.GetValue(key).Id != 0)
            {
                Console.WriteLine(collection.GetValue(key));
            }
            else
            {
                Console.WriteLine("\nEmployee {0} does not exist in the Hash Table", key);
                Console.WriteLine("please view the below hash table entries and enter the correct key");
                foreach (DictionaryEntry item in collection)
                {
                    Console.WriteLine((Employee)item.Value);
                }
            }           
        }

        public void WorkingWithQueue()
        {
            Console.WriteLine("\nqueue implementation");
            Queue q1 = new Queue();
            Employee emp1 = new Employee(90, "hello world!", 45000);
            Employee emp2 = new Employee(91, "test data", 90000);
            Employee emp3 = new Employee(92, "android", 95000);
            q1.Enqueue(emp1); q1.Enqueue(emp2); q1.Enqueue(emp3);
            q1.Dequeue();
            Console.WriteLine("Queue element count {0}",q1.Count);
            foreach (Employee item in q1)
            {
                Console.WriteLine(item);
            }
        }

        public void WorkingWithSortedList()
        {
            Console.WriteLine("\nsorted list implementation");
            SortedList s = new SortedList();
            Employee emp1 = new Employee(90, "hello world!", 45000);
            Employee emp2 = new Employee(91, "test data", 90000);
            Employee emp3 = new Employee(92, "android", 95000);
            s.Add(emp1.Id, emp1); s.Add(emp2.Id, emp2); s.Add(emp3.Id, emp3);
            s.Remove(emp2.Id);
            foreach (DictionaryEntry item in s)
            {
                Console.WriteLine("key {0}, value {1}", item.Key, item.Value);
            }
        }

        public void WorkingWithStack()
        {
            Console.WriteLine("\nstack implementation");
            Stack s = new Stack();
            Employee emp1 = new Employee(90, "hello world!", 45000);
            Employee emp2 = new Employee(91, "test data", 90000);
            Employee emp3 = new Employee(92, "android", 95000);
            s.Push(emp1); s.Push(emp2); s.Push(emp3);
            s.Pop();            
            foreach (Employee item in s)
            {
                Console.WriteLine(item);
            }
        }

        public void WorkingWithGenerics()
        {
            Console.WriteLine("\nGenerics");
            GenericEmployeeCollection<GenericEmployeeType> newobj = new GenericEmployeeCollection<GenericEmployeeType>();
            GenericEmployeeType emp1 = new GenericEmployeeType(90, "naynish", 65000);
            GenericEmployeeType emp2 = new GenericEmployeeType(91, "tripti", 75000);
            GenericEmployeeType emp3 = new GenericEmployeeType(92, "jay", 85000);
            GenericEmployeeType emp4 = new GenericEmployeeType(93, "purab", 95000);
            newobj.myGenDictionary.Add(emp1.Id, emp1); newobj.myGenDictionary.Add(emp2.Id, emp2);
            newobj.myGenDictionary.Add(emp3.Id, emp3); newobj.myGenDictionary.Add(emp4.Id, emp4);
            foreach (KeyValuePair<Int32, GenericEmployeeType> item in newobj.myGenDictionary)
            {
                Console.WriteLine(item.Key + " " + item);
            }

            Console.WriteLine("\nGeneric List");
            GenericEmployeeType[] empArr = new GenericEmployeeType[] { emp1, emp2, emp3, emp4 };
            newobj.ShowListEntries<GenericEmployeeType>(empArr);
            Console.WriteLine("\nIncentives: Specifying type parameters for members");
            emp1.Incentives<Int32>(90);

            Fruit[] fruit = new Fruit[]
            {
                new Fruit("apple", 45),
                new Fruit("watermelon", 12),
                new Fruit("peach", 78),
                new Fruit("banana", 10),
            };

            System.Array.Sort<Fruit>(fruit, new ImplementIComparer());
            foreach (Fruit item in fruit)
            {
                Console.WriteLine(item);
            }

            System.Array.Sort<Fruit>(fruit, Fruit.SortByPrice);
            //sorting by price
            Console.WriteLine("\n sorting fruits by price");
            foreach (Fruit item in fruit)
            {
                Console.WriteLine(item);
            }

            //implementing IComparer<OperatingSystems> in the same class           
            //collection initialization syntax
            //Note You can only apply collection initialization syntax to classes that support an Add() method, which is
            //formalized by the ICollection<T>/ICollection interfaces.
            List<OperatingSystems> li = new List<OperatingSystems>()
                {
                    new OperatingSystems("WIN32", 900),
                    new OperatingSystems("OSX", 906),
                    new OperatingSystems("LINUX", 400),
                    new OperatingSystems("UBUNTU", 590)
                };            
            li.Sort(new OperatingSystems());
            foreach (OperatingSystems item in li)
            {
                Console.WriteLine(item);
            }
        }
    }
}
