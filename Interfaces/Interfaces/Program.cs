using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    class Program : System.Object, MyCustomInterface
    {
        public int i = 20;
        static System.Data.SqlClient.SqlConnection conn;

        static void Main(string[] args)
        {
            string s = "hello interfaces";
            OperatingSystem os = new OperatingSystem(PlatformID.MacOSX, new Version());
            MyCustomInterface pObj = new Program();            
            ICloneableDemo(pObj);
            ICloneableDemo(s);
            ICloneableDemo(os);
            Console.WriteLine("working with interfaces");
            Console.WriteLine(((Program)pObj).i);

            try
            {
                conn = new System.Data.SqlClient.SqlConnection(
                        "Data Source=naynish-pc\\sqlexpress; Initial Catalog=TestData; UID = sa; PWD = Bhairav@12; Integrated Security=false");
                conn.Open();
                ICloneableDemo(conn);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }

            IEmployeePrototype emp1 = new Employee();
            emp1.ShowDetails();
            Console.WriteLine();
            AbstractEmployeeBaseClass[] abcArr = new AbstractEmployeeBaseClass[]
                {
                    new Founder(),
                    new VicePresident(1000, 200000),
                    new Programmer(48090, 85000)
                };

            foreach (AbstractEmployeeBaseClass item in abcArr)
            {
                if (item is ISalary)
                {
                    //if it implements ISalary then checking what specific type implements ISalary and filling the dictionary 
                    //with more entries
                    if (item is VicePresident)
                    {
                        ((VicePresident)item).Dictionary.Add(1001, 250000);
                        ((VicePresident)item).Dictionary.Add(1002, 300000);
                    }
                    else if (item is Programmer)
                    {
                        //Programmer implements the ISalary interface explicitly
                        //so call the members with the reference of the interface
                        ((ISalary)item).Dictionary.Add(48091, 90000);
                        ((ISalary)item).Dictionary.Add(48092, 95000);
                        InterfacesAsReturnValues().Dictionary.Add(48093, 120000);                        
                    }
                    ((ISalary)item).ShowSalaryDetails();
                }
                else
                {
                    Console.WriteLine(item.GetType() + " please implement ISalary interface");
                }
            }

            ISalary[] arrSal = new ISalary[] 
                    { 
                        new My(90, 38000),
                        new VicePresident(91, 90000),
                        new Programmer(92, 65000)
                    };
            Console.WriteLine("\narray of interfacess");
            foreach (ISalary item in arrSal)
            {
                item.ShowSalaryDetails();
            }

            NameClash nc = new NameClash();           
            //nc.Display();
            //call display with any interface's reference, shared Display() logic would be called.
            //since explicitly implemented interface members are private they are no longer available from object level
            //use interface reference
            ((IDisplayConsole)nc).Display();
            ((IDisplayWebForms)nc).Display();
            Console.WriteLine("\n");
            EnumerableType et = new EnumerableType();
            foreach (Product item in et)
            {
                Console.WriteLine("Id: {0}, Name: {1}, Price: {2}",item.Id, item.Name, item.Price);
            }
            //manually working with IEnumerator
            Console.WriteLine("\nmanual IEnumerator");
            IEnumerable ieTr = new EnumerableType();
            IEnumerator ieColl = ieTr.GetEnumerator();

            for (int i = 0; i < ((EnumerableType)ieTr).arrProd.Length; i++)
            {
                ieColl.MoveNext();
                Console.WriteLine("Id: {0}, Name: {1}, Price: {2}", ((Product)ieColl.Current).Id, ((Product)ieColl.Current).Name, ((Product)ieColl.Current).Price);    
            }

            Console.WriteLine("\nnamed iterators");
            //working with named iterators
            foreach (Product item in ((EnumerableType)ieTr).WorkingWithNamedIterators())
            {
                Console.WriteLine("Id: {0}, Name: {1}, Price: {2}", item.Id, item.Name, item.Price);
            }

            //MyCustomCollection
            Console.WriteLine("\nMyCustomCollection");
            IEnumerable ieMy = new MyCustomCollection();
            foreach (KeyValuePair<Object, Object> item in ieMy)
            {
                Console.WriteLine("key: {0}, value: {1}", item.Key, item.Value);
            }
                        
            Object[] valCollectionSave = new Object[((Dictionary<Object, Object>.ValueCollection)((MyCustomCollection)ieMy).DisplayJustValues()).Count];
            ((Dictionary<Object, Object>.ValueCollection)((MyCustomCollection)ieMy).DisplayJustValues()).CopyTo(valCollectionSave, 0);
            
            foreach (Object item in valCollectionSave)
            {              
               Console.WriteLine("value: {0}", item);              
            }
            Console.WriteLine("\ndictionary using foreach");
            foreach (KeyValuePair<Object, Object> item in ((MyCustomCollection)ieMy).UsingForeachInternally())
            {
                Console.WriteLine("key: {0}, value: {1}", item.Key, item.Value);
            }

            //shallow copy
            BitmapPoint point1 = new BitmapPoint(100.12, 200.36, 300.89);
            BitmapPoint point2 = point1;
            //internal values types have an independent copy
            point2.x = 1000;
            point2.y = 2000;
            //internal reference is copied and now both of them point to the same memory location
            point2.internalRef.StartPoint = 5000;
            Console.WriteLine("\npoint1" + point1);
            Console.WriteLine("\npoint2" + point2);

            //deep copy: created a new instance of BitmapPoint and did a member by member independent copy
            BitmapPoint p1DeepCopy = new BitmapPoint(10.46, 20.89, 45.00);
            BitmapPoint p2DeepCopy = (BitmapPoint)(((ICloneable)p1DeepCopy).Clone()); //(BitmapPoint)p1DeepCopy.ShallowCopy(); //if you want to perform a shallow copy
            p2DeepCopy.x = 100;
            p2DeepCopy.y = 200;
            p2DeepCopy.internalRef.StartPoint = 50;
            Console.WriteLine("\npoint1 deep copy: " + p1DeepCopy);
            Console.WriteLine("\npoint2 deep copy: " + p2DeepCopy);

            ComparableFruit[] arrFruit = new ComparableFruit[] 
                                         {
                                            new ComparableFruit("apple", 45),
                                            new ComparableFruit("mango", 23),
                                            new ComparableFruit("watermelon", 60),
                                            new ComparableFruit("banana", 12),
                                            new ComparableFruit("cherry", 67)
                                         };
            Array.Sort(arrFruit);
            foreach (ComparableFruit item in arrFruit)
            {
                Console.WriteLine("fruit: {0}, price: {1}", item.Name, item.Price);    
            }

            Console.WriteLine("\nMultiple Sort Orders - Sort by fruit name");
            //implement each class for each sort order
            Array.Sort(arrFruit, new SortByName());
            foreach (ComparableFruit item in arrFruit)
            {
                Console.WriteLine("fruit: {0}, price: {1}", item.Name, item.Price);
            }

            Console.WriteLine("\nMultiple Sort Orders - Sort by fruit price");            
            Array.Sort(arrFruit, new SortByPrice());
            foreach (ComparableFruit item in arrFruit)
            {
                Console.WriteLine("fruit: {0}, price: {1}", item.Name, item.Price);
            }
            Console.WriteLine("\n");
            Array.Sort(arrFruit, ComparableFruit.SortOrder(ComparableFruit.SortBy.FruitName));
            foreach (ComparableFruit item in arrFruit)
            {
                Console.WriteLine("fruit: {0}, price: {1}", item.Name, item.Price);
            }

            Console.WriteLine("\n");
            Array.Sort(arrFruit, ComparableFruit.SortOrder(ComparableFruit.SortBy.FruitPrice));
            foreach (ComparableFruit item in arrFruit)
            {
                Console.WriteLine("fruit: {0}, price: {1}", item.Name, item.Price);
            }  

            //last sorting using a readonly property
            Console.WriteLine("\nreadonly sort");
            Array.Sort(arrFruit, ComparableFruit.SortByName);
            foreach (ComparableFruit item in arrFruit)
            {
                Console.WriteLine("fruit: {0}, price: {1}", item.Name, item.Price);
            } 
            Console.ReadLine();
        }
        //END OF MAIN

        //accepts objects implementing ICloneable
        //if not and still you send them to this method then you will get a compile time error
        public static void ICloneableDemo(ICloneable ic)
        {
            //Clone() creates a new independent instance
            Object _ic = ic.Clone();
            //((Program)_ic).i = 100;
            Console.WriteLine(@"Underlying Type ""{0}""", _ic.GetType().Name);
        }

        void MyCustomInterface.Display()
        {
            Console.WriteLine("implementing MyCustomInterface.Display()");
        }

        object ICloneable.Clone()
        {
            //this method  creates a new independent copy
            Program temp = new Interfaces.Program();
            temp.i = this.i;
            return temp;
        }

        public static ISalary InterfacesAsReturnValues()
        {
            ISalary sal1 = new Programmer();
            return sal1;
        }
    }
}
