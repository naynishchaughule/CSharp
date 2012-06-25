using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    //sealing a class makes the best sense when you are designing a utility class
    //C# structures are always implicitly sealed
    sealed class VicePresident : Employee
    {
        private double salesInDollars;
        public int valueComp;
        public double SalesInDollars
        {
            get { return salesInDollars; }
            set { salesInDollars = value; }
        }

        public VicePresident() : this (9000, "tripti panjabi", 980000, 600000, "332-874-5632", new BenefitPlan())
        {
            
        }

        public VicePresident(int value)
        {
            valueComp = value;
        }

        public VicePresident(int id, string fname, double salary, double sales, string ssn, BenefitPlan b) : base (id, fname, salary, ssn, b)
        {
            SalesInDollars = sales;
            incentives = (0.30 * Salary); 
        }

        //if you do not override the abstract method then you will have to mark this class as abstract
        public override void CalculateIncentives()
        {           
            //base.Display(); //to call void Employee.Display()
            this.Display(); //void VicePresident.Display()
            Console.WriteLine("incentives {0}, sales {1:C}", 0.30 * Salary, SalesInDollars);
            Console.WriteLine();
        }

        protected override void Display()
        {
            Console.WriteLine("Vice-President's display called name {0}, ssn {1}", Fname, Ssn);
            Console.WriteLine("Salary = {0} + {1} - {2} = total {3:C}", Salary, incentives, MyPlan.Amount, Salary + incentives - MyPlan.Amount);
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.valueComp + " " + this.GetType();
        }

        public override int GetHashCode()
        {
            return (this.valueComp.ToString() + this.ToString()).GetHashCode();
        }
    }

    //cannot derive from a sealed class
    //class MyClass : VicePresident
    //{
        
    //}
}
