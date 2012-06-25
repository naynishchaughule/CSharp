using System;
using System.Collections;
using System.Collections.Generic;
//LINQ to Objects in System.Core.dll
using System.Linq;
using System.Text;

namespace LINQtoObjects
{
    public delegate TResult MyCustomDelegate<TSource, TResult>(TSource obj);
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Int32, String> employeeDetails = new Dictionary<int, string>();
            employeeDetails.Add(48090, "naynish p. chaughule");
            employeeDetails.Add(65985, "tripti panjabi");
            var resultEmployee = from emp in employeeDetails
                                 where emp.Key == 48090
                                 select emp;
            foreach (var item in resultEmployee)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            Int32[] intArr = new Int32[] { 67, 56, 2, 49, 254 };
            var resultLinq = from item in intArr 
                             where item > 60
                             select item;
            Console.WriteLine("Linq on basic array collection: ");
            foreach (var item in resultLinq)
            {
                Console.Write(item + " ");
            }

            //collection initialization syntax
            List<Rectangle> listRect = new List<Rectangle>()
            {
                new Rectangle(new Point(10.49, 48.27), new Point(89.23, 68.24)),
                new Rectangle(new Point(10.49, 48.27), new Point(89.23, 68.24)),
                new Rectangle { TopLeft = new Point (34.45, 54.37), BottomRight = new Point (45.23, 77.24) }
            };
            Console.WriteLine();
            List<Int32> listIntegers = new List<int>();
            listIntegers.AddRange(new Int32[] { 10, 34, 45, 29, 12 });
            listIntegers.FindAll(
                    (i) => 
                    {
                        if (i % 2 == 0)
                        {
                            Console.Write(i + "\t");
                            return true;
                        }
                        else return false;
                    }                
                );

            StringBuilder sb = new StringBuilder("ASP.NET ");            
            Console.WriteLine(StringBuilderExtension.ExtensionMethod(sb));
            Console.WriteLine("--Basics--");
            var anonymoustype = new { Id = 48090, ErrorDescription = "404", EmpDetails = new {empName = "naynish"}, 
                Salary = 85000 };
            LinqOverArrays();
            QueryOverInts();
            Console.WriteLine();
            ImmediateExecution();
            Console.WriteLine();
            WorkingWithLINQ linq = new WorkingWithLINQ();
            linq.Add();
            foreach (var item in linq.Basics())
	        {
                Console.WriteLine("\nkey: " + item.Key + "\nvalue: \n" + item.Value);
	        }

            foreach (Int32 item in ReturningResults())
            {
                Console.WriteLine(item);
            }
            LinqOverGenericCollections();
            Console.WriteLine("\n\n\n");
            LinqOverNonGenericCollections();
            Console.WriteLine("\n");
            FilteringData();
            Console.WriteLine("\n");
            foreach (Object item in WorkingWithProductInfo())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            LinqVenn();
            Console.WriteLine();
            LinqUsingEnumerable();                                    
            Console.ReadLine();
        }

        public static void LinqOverArrays()
        {
            String[] arr = new String[] { "nash", "yahoo1", "ice cream 5", "amazon ", "microsoft xbox 360", "samsungG2" };
            IEnumerable<String> resultSet = from item in arr
                            where item.Contains(" ") orderby item descending
                            select item;
            
            foreach (var item in resultSet)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(resultSet.GetType().Name);
            Console.WriteLine(resultSet.GetType().Assembly.GetName().Name);            
        }

        public static void QueryOverInts()
        {
            //different types handle different result sets
            //OrderedEnumerable<TElement, TKey> implements IEnumerable<T>
            Int32[] arrInt = new Int32[] { 4, 5, 23, 90, 267, 280, 192 };
            //IEnumerable<T> extends the IEnumerable interface
            //deferred execution
            IEnumerable result = from item in arrInt
                                 where item > 100
                                 select item;

            //the Linq query is evaluated only when you iterate over the result set
            foreach (Int32 item in result)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(result.GetType().Name);
            Console.WriteLine(result.GetType().Assembly.GetName().Name);
            
            //modify the contents of arrInt
            arrInt[0] = 152; 
            //i will get an updated result when i iterate each time over the result set, if there are any changes
            //in the collection
            foreach (Int32 item in result)
            {
                Console.Write(item + " ");
            }
        }

        public static void ImmediateExecution()
        {
            Int32[] arr = new Int32[] { 45, 21, 34, 1, 40, 39 };
            Int32[] result = (from item in arr 
                              where item > 37 orderby item descending
                              select item).ToArray<Int32>();
            List<Int32> myList = (from item in arr where item > 37 select item).ToList();

            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
        }

        public static Int32[] ReturningResults()
        {
            Int32[] arr = new Int32[] { 5, 24, 21, 98, 235 };
            return (from item in arr where item % 2 == 0 select item).ToArray<Int32>();
        }

        public static void LinqOverGenericCollections()
        {
            Dictionary<Int32, Employee> myDictionary = new Dictionary<int, Employee>();
            Employee emp1 = new Employee() { Id = 48090, Fname = "naynish", Company = "amazon", Salary = 85000 };
            Employee emp2 = new Employee() { Id = 48091, Fname = "jay", Company = "android", Salary = 55000 };
            Employee emp3 = new Employee() { Id = 48092, Fname = "purab", Company = "amazon", Salary = 75000 };
            Employee emp4 = new Employee() { Id = 48093, Fname = "praloy", Company = "amazon", Salary = 45000 };
            Employee emp5 = new Employee() { Id = 48094, Fname = "tripti", Company = "google", Salary = 100000 };
            Employee emp6 = new Employee() { Id = 48095, Fname = "malvika", Company = "amazon", Salary = 150000 };
            Employee emp7 = new Employee() { Id = 48096, Fname = "ron", Company = "amazon", Salary = 67000 };
            myDictionary.Add(emp1.Id, emp1); myDictionary.Add(emp2.Id, emp2); myDictionary.Add(emp3.Id, emp3);
            myDictionary.Add(emp4.Id, emp4); myDictionary.Add(emp5.Id, emp5); myDictionary.Add(emp6.Id, emp6);
            myDictionary.Add(emp7.Id, emp7);

            IEnumerable result = from item in myDictionary
                                 where item.Value.Salary > 60000 && item.Value.Company == "amazon"
                                 select item;
            Console.WriteLine(result.GetType().Name);
            foreach (KeyValuePair<Int32, Employee> item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void LinqOverNonGenericCollections()
        {            
            ArrayList myList = new ArrayList();
            myList.Add(new Employee() { Id = 48090, Fname = "naynish", Company = "amazon", Salary = 85000 });
            myList.Add(new Employee() { Id = 48091, Fname = "jay", Company = "android", Salary = 55000 });
            myList.Add(new Employee() { Id = 48092, Fname = "purab", Company = "amazon", Salary = 75000 });
            myList.Add(new Employee() { Id = 48093, Fname = "praloy", Company = "amazon", Salary = 45000 });
            myList.Add(new Employee() { Id = 48094, Fname = "tripti", Company = "google", Salary = 100000 });
            myList.Add(new Employee() { Id = 48095, Fname = "malvika", Company = "amazon", Salary = 150000 });
            myList.Add(new Employee() { Id = 48096, Fname = "ron", Company = "amazon", Salary = 67000 });

            // Transform ArrayList into an IEnumerable<T>-compatible type.
            IEnumerable<Employee> temp = myList.OfType<Employee>();

            IEnumerable<Employee> result = from item in temp
                                 where item.Salary > 60000 && item.Company == "amazon"
                                 select item;
            
            foreach (Employee item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void FilteringData()
        {
            ArrayList myList = new ArrayList();
            myList.Add(new Employee() { Id = 48090, Fname = "naynish", Company = "amazon", Salary = 85000 });
            myList.Add(new Employee() { Id = 48091, Fname = "jay", Company = "android", Salary = 55000 });
            myList.Add(new Employee() { Id = 48092, Fname = "purab", Company = "amazon", Salary = 75000 });
            myList.Add(new Employee() { Id = 48093, Fname = "praloy", Company = "amazon", Salary = 45000 });
            myList.Add(new Employee() { Id = 48094, Fname = "tripti", Company = "google", Salary = 100000 });
            myList.Add(new Employee() { Id = 48095, Fname = "malvika", Company = "amazon", Salary = 150000 });
            myList.Add(new Employee() { Id = 48096, Fname = "ron", Company = "amazon", Salary = 67000 });
            myList.Add(new Fruit() { Name = "Mango", Price = 4.5 });
            myList.Add(new Fruit() { Name = "Apple", Price = 2.34 });
            myList.Add(new Fruit() { Name = "Melon", Price = 0.99 });
            myList.Add(new Fruit() { Name = "Banana", Price = 1.90 });

            IEnumerable<Fruit> temp = myList.OfType<Fruit>();

            IEnumerable<Fruit> result = from item in temp
                                        where item.Price < 3
                                        select item;

            foreach (Fruit item in result)
            {
                Console.WriteLine(item); 
            }
        }

        public static Array WorkingWithProductInfo()
        {
            Hashtable ht = new Hashtable(); 
            ProductInfo p1 = new ProductInfo() { Id = 1, Name = "mouse", Price = 19, StockCount = 156};
            ProductInfo p2 = new ProductInfo() { Id = 2, Name = "lays", Price = 1.67, StockCount = 148};
            ProductInfo p3 = new ProductInfo() { Id = 3, Name = "android", Price = 56, StockCount = 500};
            ProductInfo p4 = new ProductInfo() { Id = 4, Name = "xps", Price = 120.48, StockCount = 672};
            ProductInfo p5 = new ProductInfo() { Id = 5, Name = "surface 1.0", Price = 190.35, StockCount = 190};
            ProductInfo p6 = new ProductInfo() { Id = 6, Name = "xbox 360", Price = 291.38, StockCount = 35};

            ht.Add(p1.Id, p1); ht.Add(p2.Id, p2); ht.Add(p3.Id, p3);
            ht.Add(p4.Id, p4); ht.Add(p5.Id, p5); ht.Add(p6.Id, p6);

            IEnumerable<DictionaryEntry> temp = ht.OfType<DictionaryEntry>();

            IEnumerable<DictionaryEntry> result = from item in temp
                                                  where ((ProductInfo)item.Value).Price > 100 && ((ProductInfo)item.Value).StockCount > 150
                                                  orderby ((ProductInfo)item.Value).Id ascending
                                                  select item;

            foreach (DictionaryEntry item in result)
            {
                Console.WriteLine(item.Value);                
            }

            var resultProjection = from item in temp
                                           where ((ProductInfo)item.Value).Price > 100
                                           select new { ((ProductInfo)item.Value).Id, ((ProductInfo)item.Value).Name, ((ProductInfo)item.Value).Price };
            Console.WriteLine("\n");
            Console.WriteLine(resultProjection.GetType().Name);
            Console.WriteLine("Count: " + resultProjection.Count());
            return resultProjection.Reverse().ToArray<Object>();
        }

        public static void LinqVenn()
        {
            List<Fruit> firstSet = new List<Fruit>() { 
                new Fruit() { Name = "mango", Price = 4.5}, 
                new Fruit() { Name = "apple", Price = 2.5}, 
                new Fruit() { Name = "melon", Price = 0.67}, 
                new Fruit() { Name = "banana", Price = 1.68} 
            };

            List<Fruit> secondSet = new List<Fruit>() { 
                new Fruit() { Name = "mango", Price = 4.5}, 
                new Fruit() { Name = "grapes", Price = 2.29}, 
                new Fruit() { Name = "peach", Price = 3.89}, 
                new Fruit() { Name = "banana", Price = 1.68} 
            };

            //first set it has but the second does not, i.e. firstSet has "apple" but the secondSet does not and hence forms
            //the result set
            IEnumerable<String> resultExcept = (from item in firstSet select item.Name).
                Except(from item in secondSet select item.Name);
            Console.WriteLine("\nExcept");
            foreach (String item in resultExcept)
            {
                Console.WriteLine(item);
            }

            IEnumerable<String> resultIntersection = (from item in firstSet select item.Name).
                Intersect(from item in secondSet select item.Name);
            Console.WriteLine("\nIntersect");
            foreach (String item in resultIntersection)
            {
                Console.WriteLine(item);
            }

            IEnumerable<String> resultUnion = (from item in firstSet select item.Name).
                Union(from item in secondSet select item.Name);
            Console.WriteLine("\nUnion");
            foreach (String item in resultUnion)
            {
                Console.WriteLine(item);
            }

            IEnumerable<String> resultConcat = (from item in firstSet select item.Name).
               Concat(from item in secondSet select item.Name);
            Console.WriteLine("\nConcat");
            foreach (String item in resultConcat.Distinct<String>())
            {
                Console.WriteLine(item);
            }

            //immediate execution since we are using extension methods of System.Linq.Enumerable
            Double resultMax = (from item in firstSet select item.Price).Max<Double>();             
            Console.WriteLine("\nMax: {0}", resultMax);

            Double resultMin = (from item in firstSet select item.Price).Min<Double>();
            Console.WriteLine("\nMin: {0}", resultMin);

            Double resultAverage = (from item in firstSet select item.Price).Average();
            Console.WriteLine("\nAverage: {0}", resultAverage);

            Double resultSum = (from item in firstSet select item.Price).Sum();
            Console.WriteLine("\nSum: {0}", resultSum);
        }

        public static void LinqUsingEnumerable()
        {
            List<Fruit> firstSet = new List<Fruit>() { 
                new Fruit() { Name = "mango", Price = 4.5}, 
                new Fruit() { Name = "apple", Price = 2.5}, 
                new Fruit() { Name = "melon", Price = 0.67}, 
                new Fruit() { Name = "banana", Price = 1.68} 
            };

            List<Fruit> secondSet = new List<Fruit>() { 
                new Fruit() { Name = "mango", Price = 4.5}, 
                new Fruit() { Name = "grapes", Price = 2.29}, 
                new Fruit() { Name = "peach", Price = 3.89}, 
                new Fruit() { Name = "banana", Price = 1.68} 
            };

            //Collection.Where(delegate instance).Selectdelegate instance)
            IEnumerable<Fruit> result = firstSet.Where((item) => { return item.Price > 2; }).Select((item) => { return item; });
            foreach (Fruit item in result)
            {
                Console.WriteLine(item);
            }

            //avoiding Linq operators and using methods of System.Linq.Enumerable
            Fruit f1 = new Fruit() { Name = "mango", Price = 4.5};
            Fruit f2 = new Fruit() { Name = "grapes", Price = 2.29};
            Fruit f3 = new Fruit() { Name = "peach", Price = 3.89};
            Fruit f4 = new Fruit() { Name = "banana", Price = 1.68 };
            Dictionary<String, Fruit> myDictionary = new Dictionary<string, Fruit>();
            myDictionary.Add(f1.Name, f1); myDictionary.Add(f2.Name, f2);
            myDictionary.Add(f3.Name, f3); myDictionary.Add(f4.Name, f4);
            //myDictionary implements IEnumerable<T>, all generic containers do and can be used with Linq
            //find fruits with price less that $3

            IEnumerable<KeyValuePair<String, Fruit>> resultFruits = myDictionary.Where((item)=>{return item.Value.Price < 3;}).Select((item)=>{return item;});
            Console.WriteLine("\nusing methods of System.Linq.Enumerable (avoiding Linq operators)");
            Console.WriteLine("underlying type of result set: {0}", resultFruits.GetType().Name);
            foreach (KeyValuePair<String, Fruit> item in resultFruits)
            {
                Console.WriteLine(item);
            }
            
            IEnumerable<KeyValuePair<String, Fruit>> myresult = myDictionary.Where<KeyValuePair<String, Fruit>>(
                (KeyValuePair<String, Fruit> item) =>
                {
                    if (item.Value.Price < 3)
                        return true;
                    else
                        return false;
                }
                ).OrderBy<KeyValuePair<String, Fruit>, Double>(
                (KeyValuePair<String, Fruit> item) =>
                {
                    return item.Value.Price;
                }
                ).Select<KeyValuePair<String, Fruit>,KeyValuePair<String, Fruit>>(
                (item) =>
                {   
                    return item;
                }
                );
            Console.WriteLine("\nnew...Using the Enumerable Type and Lambda Expressions");
            foreach (KeyValuePair<String, Fruit> item in myresult)
            {
                Console.WriteLine(item);
            }

            //Building Query Expressions Using the Enumerable Type and Anonymous Methods

            IEnumerable<KeyValuePair<String, Fruit>> myAnonymousResult = myDictionary.
                Where<KeyValuePair<String, Fruit>>(
                delegate (KeyValuePair<String, Fruit> item)
                {
                    if (item.Value.Price < 3)
                        return true;
                    else
                        return false;
                }
                ).OrderBy<KeyValuePair<String, Fruit>, Double>(
                delegate (KeyValuePair<String, Fruit> item)
                {
                    return item.Value.Price;
                }
                ).Select<KeyValuePair<String, Fruit>, KeyValuePair<String, Fruit>>(
                delegate(KeyValuePair<String, Fruit> item)
                {
                    return item;
                }
                );
            Console.WriteLine("\nnew...Using the Enumerable Type and Anonymous Methods");
            foreach (KeyValuePair<String, Fruit> item in myAnonymousResult)
            {
                Console.WriteLine(item);
            }

            //Building Query Expressions Using the Enumerable Type and Raw delegates
            Func<KeyValuePair<String, Fruit>, Boolean> whereDel = new Func<KeyValuePair<string, Fruit>, Boolean>(WhereClause);
            Func<KeyValuePair<String, Fruit>, Double> orderDel = new Func<KeyValuePair<string, Fruit>, Double>(OrderByClause);
            Func<KeyValuePair<String, Fruit>, KeyValuePair<String, Fruit>> selectDel = new Func<KeyValuePair<string, Fruit>, KeyValuePair<String, Fruit>>(SelectClause);
            
            IEnumerable<KeyValuePair<String, Fruit>> myRawResult = myDictionary.
                Where<KeyValuePair<String, Fruit>>(
                whereDel
                ).OrderBy<KeyValuePair<String, Fruit>, Double>(
                orderDel
                ).Select<KeyValuePair<String, Fruit>, KeyValuePair<String, Fruit>>(
                selectDel
                );

            Console.WriteLine("\nnew...Using the Enumerable Type and Raw Delegates");
            foreach (KeyValuePair<String, Fruit> item in myRawResult)
            {
                Console.WriteLine(item);
            }
        }

        public static Boolean WhereClause(KeyValuePair<String, Fruit> item)
        {
            if (item.Value.Price < 4)
                return true;
            else
                return false;
        }

        public static Double OrderByClause(KeyValuePair<String, Fruit> item)
        {
            return item.Value.Price;
        }

        public static KeyValuePair<String, Fruit> SelectClause(KeyValuePair<String, Fruit> item)
        {
            return item;
        }
    }
}


