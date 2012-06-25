using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyExtensionsLibrary;

namespace AdvancedLanguageFeatures
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            Employee emp1 = new Employee(48090, "naynish p. chaughule", 85000);
            Employee emp2 = new Employee(48091, "tripti panjabi", 65000);
            Employee emp3 = new Employee(48092, "jay bhatt", 95000);
            GenericEmployeeContainer.employeeList.Add(emp1);
            GenericEmployeeContainer.employeeList.Add(emp2);
            GenericEmployeeContainer.employeeList.Add(emp3);
            Console.WriteLine("Original ArrayList");
            foreach (Employee item in GenericEmployeeContainer.employeeList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");
            //generic containers provide indexers out of the box
            GenericEmployeeContainer.employeeList[0] = new Employee(0001, "naynish p. chaughule", 150000);
            Console.WriteLine(GenericEmployeeContainer.employeeList[0].Salary);
            foreach (Employee item in GenericEmployeeContainer.employeeList)
            {
                Console.WriteLine(item);
            }

            //using the non-generic container and implementing indexer
            CustomNonGenericContainer.employeeArrayList.Add(emp1);
            CustomNonGenericContainer.employeeArrayList.Add(emp2);
            CustomNonGenericContainer.employeeArrayList.Add(emp3);
            CustomNonGenericContainer.employeeArrayList[0] = new Employee(0001, "karan ratanpal", 70000);
            Console.WriteLine("\nnon-generic custom collection class");
            foreach (Employee item in CustomNonGenericContainer.employeeArrayList)
            {
                Console.WriteLine(item);
            }

            //using string based indexing for Dictionary<String, Employee>
            EmployeeDictionary.customEmployeeDictionary.Add("naynish", new Employee(10, "naynish p. chaughule", 25000));
            EmployeeDictionary.customEmployeeDictionary.Add("jay", new Employee(11, "jay bhatt", 50000));
            EmployeeDictionary.customEmployeeDictionary.Add("purab", new Employee(12, "purab bhatt", 35000));
            Console.WriteLine("\ndictionary with string based indexing");
            Employee temp = EmployeeDictionary.customEmployeeDictionary["purab"];
            Console.WriteLine("found based on key " + temp);
            EmployeeDictionary e = new EmployeeDictionary();
            EmployeeDictionary.customEmployeeDictionary["tripti"] = new Employee(13, "tripti panjabi", 30000);
            foreach (KeyValuePair<String, Employee> item in e)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }

            //indexer overloading
            Console.WriteLine("\nindexer overloading");
            IndexerOverloading.ht["naynish"] = new Employee(90, "naynish", 60000);
            IndexerOverloading.ht["jay"] = new Employee(91, "jay", 65000);
            IndexerOverloading.ht["purab"] = new Employee(92, "purab", 69000);
            IndexerOverloading.ht[0] = new Employee(100, "tripti", 67000);
            IndexerOverloading indo = new IndexerOverloading();
            foreach (DictionaryEntry item in indo)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            StringProblem sp1 = new StringProblem();
            sp1.Work();

            StringProblem2 sp2 = new StringProblem2();
            sp2.Repeated();

            TwoDimensionalProblem two = new TwoDimensionalProblem();
            two[0, 0] = 9; two[0, 1] = 5;
            for (int i = 0; i < TwoDimensionalProblem.twoArr.GetLength(0); i++)
            {
                for (int j = 0; j < TwoDimensionalProblem.twoArr.GetLength(1); j++)
                {
                    Console.Write("{0} ", two[i, j]);
                }
                Console.WriteLine();
            }

            UsingDataTable.WorkingWithDataTables();
            Console.WriteLine(UsingDataTable.dt.Rows[0][1]);

            Point p1 = new Point { X = 25, Y = 40 };
            Point p2 = new Point { X = 28, Y = 46 };
            //Point.operator + (p1, p2)
            Point p3 = p1 + p2;
            Console.WriteLine(p3);
            Console.WriteLine(p3 + 34); Console.WriteLine(40 + p3);
            Console.WriteLine(p3 += 10);
            Console.WriteLine(p3++); Console.WriteLine(++p3);
            Console.WriteLine(p1 == p2);
            Console.WriteLine("Comparison {0}", p1 >= p2);
            CustomTypeConversion ct = new CustomTypeConversion();
            ct.BasicOperations();
            Rectangle rtExtension = new Rectangle(89, 67);
            rtExtension.ShowAssemblyDetails();
            Double d = 90.67;
            Console.WriteLine(d.GetSquare());
            Console.WriteLine(MyExtensions.GetSquare(10.56));
            StringProblem spMyExt = new StringProblem();
            spMyExt.ShowMyAssembly();

            IBasicMath mc = new MyCalc();
            Console.WriteLine("Sum = {0}",mc.Add(10.45, 78.679));
            Console.WriteLine("Difference = {0}", mc.Subtract(10.45, 78.679));

            Movie mv = new Movie();
            mv.Configure("inception!!");

            //anonymous types
            var myCar = new { Name = "ford xls 1.30", Price = 10.90 };
            var myNewCar = new { Name = "ford xls 1.30", Price = 10.90 };
            ShowDetailsOfAnonymousTypes(myCar, myNewCar);

            //cart
            var myCart = new { 
            dt = DateTime.Now,
            item1 = new { Name = "chips x", Price = 1.69 }
            };
            myCar.ShowAssemblyDetails();
            
            //lazy instantiation
            Store s = new Store();
            s.Billing();
            s.ShowProductList();

            Factorial f = new Factorial();
            Console.WriteLine(f.Calculate(5));
            f.Fibonacci();
            Console.WriteLine();
            Int32 xOut;
            f.FibonacciRecursion(out xOut);

            //pointers
            WorkingWithPointers wp = new WorkingWithPointers();
            Int32 xVal = 12;
            wp.Square(&xVal);
            wp.Basics();
            Int32 xValue = 10, yValue = 89;
            wp.Swap(&xValue, &yValue);
            Console.WriteLine(xValue + " " + yValue);

            MyPoint valPoint = new MyPoint();
            MyPoint* pStruct = &valPoint;
            pStruct->x = 16;
            pStruct->y = 196;
            Console.WriteLine("access struct vars {0} {1}", (*pStruct).x, pStruct->y);
            Console.WriteLine((*pStruct));

            //allocate a block of memory on the stack
            Int32* IOS = stackalloc Int32[10];

            JobPointer jp = new JobPointer();
            jp.Id = 10;
            fixed (Int32* ptrJob = &jp.Id)
            {
                //Use Int32* here
            }
            //JobPointer jp unpinned: and garbage collected once the method completes

            //the C# sizeof keyword is used to
            //obtain the size in bytes of a value type (never a reference type), and it may only be used within an unsafe
            //context.
            Console.WriteLine("size of Node: {0} bytes",  sizeof(Node));
            Console.ReadLine();
        }

        public static void ShowDetailsOfAnonymousTypes(System.Object mv, System.Object mc)
        {
            Console.WriteLine(mv.GetType().AssemblyQualifiedName);
            Console.WriteLine(mv);
            //two anonymous types will yield the same hash value if (and only if)
            //they have the same set of properties that have been assigned the same values
            Console.WriteLine(mv.GetHashCode());
            //value based comparison
            Console.WriteLine(mv.Equals(mc));
            //reference based comparison: what the ref variables point to in the memory
            Console.WriteLine(mv == mc);
            //the anonymous types are instances of the same compiler-generated class type
            //due to the fact that mv and mc have the same properties
            Console.WriteLine("{0} --- {1}", mv.GetType(), mc.GetType());
        }
    }
}
