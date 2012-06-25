
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProgrammingConstructsPart2
{
    class Program
    {
        //System.ValueType is an abstract class
        //structs support interfaces
        static void Main(string[] args)
        {
            int x = 10, y = 20;
            Console.WriteLine("x {0}, y {1}", x, y);
            Add(x, y);
            int subResult; //passed by reference
            int original = 5000; 
            int newLine;
            Subtract(out newLine, x, y, out subResult, out original);
            Console.WriteLine("x {0}, y {1}", x, y);
            Console.WriteLine("subResult {0} and original {1}", subResult, original);

            //when a value type contains other reference types, assignment results in a copy of the references
            Employee objEmp = new Employee(new Car("honda"), 48090, "naynish");
            Console.WriteLine("{0} {1} {2}",objEmp.obj.name, objEmp.empID, objEmp.empName);
            Program p1 = new Program();
            Console.WriteLine("original data {0} {1} {2}", objEmp.obj.name, objEmp.empID, objEmp.empName);
            p1.DHP(objEmp);
            Console.WriteLine("after DHP call, pass by reference {0} {1} {2}", objEmp.obj.name, objEmp.empID, objEmp.empName);
            
            //shallow copy
            StructDoctor objDoc = new StructDoctor(new Hospital("gwu"), 48090, "Dr. naynish p. chaughule");
            Console.WriteLine(" original data {0} {1} {2}", objDoc.hp.name, objDoc.docID, objDoc.docName);
            //pass by value, but for internal objects it is pass by reference
            p1.DoctorList(objDoc);
            Console.WriteLine(" after call {0} {1} {2}", objDoc.hp.name, objDoc.docID, objDoc.docName);            
            
            double[] myAvg = new double[] { 10.33, 494.892, 73.67, 90.890};
            p1.CalculateAverage(myAvg);
            //The .NET runtime will automatically package the set of doubles into an array of type double behind the scenes
            p1.CalculateAverage(10.34, 445.33);
            //optiona and named
            NamedAndOptional(10, address: "18 M", name: "superman");

            GenericAdd(10, 20);
            Generic<double>(10.34, 24.35);

            WorkingWithArrays arrWorkings = new WorkingWithArrays();
            arrWorkings.SimpleArrays();
            Console.WriteLine();
            MyEnums.WorkingWithEnums();
            //assign all the data points of a structure
            //two independent variables on the stack (two copies of the Point type on the stack)
            Point p;
            p.x = 10;
            p.y = 20;
            p.DisplayPoint();
            Point newp;
            newp = p;
            p.x = 100;
            Console.WriteLine("p: x {0} y {1}", p.x, p.y);
            Console.WriteLine("p1: x {0} y {1}", newp.x, newp.y);

            City city1 = new City(2034, "new york");
            Console.WriteLine("original data");
            city1.Display(city1);

            city1.ChangeState(ref city1);
            Console.WriteLine("after call to ChangeState");
            city1.Display(city1);

            //value types can be marked as null (.net 2.0)
            System.Boolean? b = false;
            Console.WriteLine(b);
            b = null;
            //Hospital? empNull = new Hospital("marty");
            int?[] arrNull = new int?[5] {4, 78, 29, 20, null};
            foreach (int? item in arrNull)
            {
                Console.WriteLine(item);
            }
            //? suffix notation is a shorthand for creating an instance of the generic System.Nullable<T> structure type.
            //string? sNull = "cp";
            //? == System.Nullable<>
            System.Nullable<int> myNullInteger = new System.Nullable<int>(34);
            Console.WriteLine("System.Nullable<int> {0}", myNullInteger);
            myNullInteger = null;
            Console.WriteLine(myNullInteger.HasValue);
            Console.WriteLine(myNullInteger.GetValueOrDefault(1000)); //value to return if null
            System.Nullable<double>[] doubleNull = new double?[] { 56.37, null, 29.19, 03.78, null};
            foreach (System.Nullable<double> item in doubleNull)
	        {
                if (item.HasValue)  //if (item != null)                                             
                 Console.WriteLine(item.Value);
                else
                    Console.WriteLine("null");
	        }
            //if the value is null then default it to 1000
            //to assign a value to a nullable type if the retrieved value is in fact null
            System.Nullable<int> defaultNull = Program.ReturnsNullValue() ?? 1000;
            Console.WriteLine(defaultNull);
            Console.ReadLine();
        }

        public static System.Nullable<int> ReturnsNullValue()
        {
            return null;                 
        }

        static void Add(int x, int y)
        {
            int result = x + y;
            x = 1000;
            y = 2000;
        }

        static void Subtract(out int newLine, int x, int y, out int result, out int org)
        {
            //to return multiple values to the caller
            result = x - y;
            org = 20;
            newLine = 450;
        }

        void DHP(Employee e)
        {
            e.empID = 8900;
            e.empName = "joe";
            e.obj.name = "CRV";
            Console.WriteLine("in DHP {0} {1} {2}", e.obj.name, e.empID, e.empName);
        }

        void DoctorList(StructDoctor s)
        {
            s.docID = 10000;
            s.docName = "batman";
            s.hp.name = "comic";
            Console.WriteLine("in DoctorList {0} {1} {2}", s.hp.name, s.docID, s.docName);
        }

        //only 1 params allowed
        void CalculateAverage(params double[] arr)
        {
            double sum = 0, result = 0;

            foreach (double item in arr)
            {
                sum += item;
            }
            
            try 
	        {	        
		       result = sum/arr.Length;
	        }
	        catch (DivideByZeroException e)
	        {
		        Console.WriteLine(e.Message);
	        }
            Console.WriteLine("Average: {0}", result);
        }

        //DateTime dt = DateTime.Now (must be known at compile time)
        //COM interop
        static void NamedAndOptional(int i, string name = "naynish", string address = "2400 virginia ave")
        {
            Console.WriteLine("ID {0}, Name {1}, Street {2}", i, name, address);
        }

        static void GenericAdd(double x, double y)
        {
            Console.WriteLine("overloaded double add {0} {1}", x + y);
        }

        static void GenericAdd(int x, int y)
        {
            Console.WriteLine("overloaded int add {0} {1}", x, y);
        }

        static void Generic<T>(T x, T y)
        {           
            Console.WriteLine("Generic {0} {1}", x, y);
        }
    }
}

