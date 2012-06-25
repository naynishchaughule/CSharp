using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningEncapsulatedClassTypes
{
    class Employee
    {
        private int id;
        private string fname;
        private double salary;
        private string address;
        private static Random ran = new Random();
        private string companyContact;
        private static string country;

        //automatic properties .NET 3.5
        //offload the work of defining a private backing field
        //get or set must be more restrictive than the overall access modifier of the property
        public static int TaxPolicy { get;  protected set; }

        // Must use constructors to override default
        // values assigned to hidden backing fields.
        public static Square sqr1 { get; set; }

        public static string Country
        {
            get { return Employee.country; }
            set { Employee.country = value; }
        }

        //accessor
        public string GetCompanyContact()
        {
            return companyContact;
        }

        //mutator
        public void SetCompanyContact(string contact)
        {
            string[] split = contact.Split(new char[] {'-'});
            if (split[0].Length == 3 && split[1].Length == 3 && split[2].Length == 4)
                companyContact = contact;
            else
                Console.WriteLine("invalid number");
        }

        public static int projectId;
        //no access modifiers
        //parameterless
        static Employee()
        {
            //static data cannot be initialized in instance constructors
            //it resets the static data each time a new object is created
            //when the value is not known at compile time
            //given class may define only a single static constructor (no overloading)
            //static constructor does not take an access modifier and cannot take any parameters
            //static constructor executes exactly one time, regardless of how many objects of the type are created
            //static constructor executes before any instance-level constructors

            //runtime invokes the static constructor when it creates an instance of the class
            //or before accessing the first static member invoked by the caller
            projectId = 10;
            Country = "United States";
        }

        public int Id
        {
            get { return id; }
            //value is a contextual keyword
            //and it will always be the same underlying data type as the property itself
            set { id = value; }
        }

        //type of data it is encapsulating by what appears to be a return value.
        //simply prefix an accessibility keyword to the appropriate get or set keyword
        //the unqualified scope takes the visibility of the property’s declaration
        //simply omit the set block for readonly and vice versa
        public string Fname
        {
            get { return fname; }
            protected set 
            {         
                if (fname.Length < 15)
                    fname = value.ToUpper();             
            }
        }

        //issued compile-time error (reserved by the property Fname)
        //public string get_Fname()
        //{
        //    return fname;
        //}

        //number of and type of constructor arguments
        //default constructor never takes arguments
        //constructor chaining is outdated instead use optional parameters and named arguments
        public Employee() : this (65985, "tripti panjabi", 55000)
        {
            Console.WriteLine("default constructor");
        }

        public Employee(int id, string fname) : this (id, fname, 85000)
        {
            Console.WriteLine("constructor with two parameters");
        }

        //A constructor is a special method of a class that is called indirectly when creating an object using the new keyword.
        //master constructor
        public Employee(int id, string fname, double salary)
        {
            //this is implied when no ambiguity
            //always use properties in your constructor
            //A property is represented by get/set methods internally
            this.fname = fname;
            Id = id;
            Fname = fname;
            this.salary = salary;
            TaxPolicy = 1080;
            sqr1 = new Square(40);
        }

        //optional parameters and named arguments .NET 4.0 or higher
        public Employee(int id = 48090, string fname = "ryan b", double salary = 90000, string address = "18 M") : this (id, fname, salary)
        {
            this.address = address;
        }

        public double CalculateIncentives()
        {
            return 0.30 * salary;
        }

        public void Display()
        {
            Console.WriteLine("Employee Id {0}, Fname {1}, Salary {2:C}, Incentives {3:C}, country {4}", Id, Fname, salary + this.CalculateIncentives(), CalculateIncentives(), Country);
        }

        public static string GetRandomNumber()
        {
            string[] arr = new string[5] { "programmer", "ceo", "cfo", "founder", "stake holder"};
            return arr[ran.Next(5)];
        }

        public static void SetProjectID(int id)
        {
            projectId = id;
        }
    }
}
