using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    //containing class for BenefitPlan objects
    //all though we cannot create an instance of the abstract class
    //it is still assembled in memory when derived classes are created.
    //an abstract base class’s polymorphic interface simply refers to its set of virtual and abstract methods.
    abstract class Employee
    {
        VicePresident emp1, emp2;
        public readonly string companyName;
        private int id;
        private string fname;
        private double salary;
        //backing field for the below auto property will not be seen on the class diagram file
        public string Address { get; set; }
        //readonly fields can be set only once and should be in the constructor
        private readonly string ssn;
        protected double incentives;

        //containment/delegation model "has-a relationship"
        private BenefitPlan myPlan;        

        public BenefitPlan MyPlan
        {
            get { return myPlan; }
            set { myPlan = value; }
        }        

        public string Ssn
        {
            get { return ssn; }
        } 


        public int Id
        {
            get { return id; }
            set { id = value; }
        }        

        public string Fname
        {
            get { return fname; }
            set { fname = value; }
        }        

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public Employee() : this (48090, "naynish c", 85000, "459-751-6983", new BenefitPlan())
        {

        }

        public Employee(int id, string fname, double salary, string ssn, BenefitPlan bPlan)
        {
            companyName = "google";
            Id = id;
            Fname = fname;
            Salary = salary;
            this.ssn = ssn;
            MyPlan = bPlan;            
        }

        //does not supply a default implementation, but must be accounted for by each derived class
        //Abstract methods can only be defined in abstract classes. If you attempt to do otherwise, you will be
        //issued a compiler error.
        public abstract void CalculateIncentives();

        protected virtual void Display()
        {
            Console.WriteLine("name {0}, ssn {1}", Fname, Ssn);
        }

        //Delegation is simply the act of adding public members to the containing class that make use of the contained object’s functionality
        public object[] GetMyPlanDetails()
        {
            //contained object’s functionality
            return MyPlan.GetAllDetails();
        }
        //contained a BenefitPlan object
        //exposed the functionality of BenefitPlan object by defining public members in the Employee class
        //relay

        public override bool Equals(object obj)
        {
            //checking compatibility            
            emp2 = obj as VicePresident;
            if (emp2 != null)
            {
                if (this.emp1.valueComp == ((VicePresident)obj).valueComp)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("not equal on value based semantics");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("types are not compatible");
                return false;
            }
        }

        //a hash code is a numerical value that represents an object as a particular state.
        //System.Object.GetHashCode() uses your object’s current location in memory to yield the hash value.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void SetEmployee(Employee e1, Employee e2)
        {
            emp1 = e1 as VicePresident;
            emp2 = e2 as VicePresident;
        }

        public override string ToString()
        {
            return "hello world!";
        }
    }
}
