using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    class BenefitPlan
    {
        string planName;
        double amount;
        static readonly string country;

        static BenefitPlan()
        {
            country = "united states of america";
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string PlanName
        {
            get { return planName; }
            set { planName = value; }
        }

        public BenefitPlan() : this ("W2 Health Policy", 5000)
        {

        }

        public BenefitPlan(string name, int amt)
        {
            PlanName = name;
            Amount = amt;
        }

        public void DisplayHealthPlan()
        {
            Console.WriteLine("Health Plan {0}", PlanName);
        }

        public object[] GetAllDetails()
        {
            object[] arr = new object[] { BenefitPlan.country, Amount, PlanName};
            return arr;
        }
    }
}
