using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    //inherits all the public and protected members
    class Programmer : Employee
    {
        private int linesOfCodePerDay;
        public int typeCheck;
        
        public Programmer(int typeCheck)
        {
            this.typeCheck = typeCheck;
        }

        public int LinesOfCodePerDay
        {
            get { return linesOfCodePerDay; }
            set { linesOfCodePerDay = value; }
        }

        public Programmer() : this (27673, "jay bhatt", 45000, 150, "332-423-42038", new BenefitPlan())
        {

        }

        //ctors even though public are never inherited
        //default constructor of a base class is called automatically before the logic of the derived constructor is executed
        //derived constructor is passing data to the immediate parent constructor
        // As a general rule, all subclasses should explicitly call an appropriate base class constructor.
        public Programmer(int id, string fname, double salary, int lines, string ssn, BenefitPlan b) : base (id, fname, salary, ssn, b)
        {
            LinesOfCodePerDay = lines;
            incentives = 0.15 * Salary;
        }

        public override void CalculateIncentives()
        {            
            base.Display(); //Display(); //void Employee.Display();
            this.Display();
            Console.WriteLine("incentives {0}, line of code per day {1}", incentives, LinesOfCodePerDay);
            Console.WriteLine();            
        }

        protected override void Display()
        {
            Console.WriteLine("Salary = {0} + {1} - {2} = total {3:C}", Salary, incentives, MyPlan.Amount, Salary + incentives - MyPlan.Amount);
        }
    }
}
