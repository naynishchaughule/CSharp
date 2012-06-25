using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningEncapsulatedClassTypes
{   
    //to avoid clients to create an object of this class
    //make class static (much better) or abstract 
    //or make the default ctor as private (allows non static members, even abstract)
    class HealthPolicy
    {
        string salesRep;
        static string policyName;
        
        public static string PolicyName
        {
            get { return policyName; }
            set { policyName = value; }
        }

        private HealthPolicy()
        {

        }

        public HealthPolicy(string salesRep)
        {
            this.salesRep = salesRep;
        }

        static HealthPolicy()
        {
            policyName = "amb 18M";
        }

        public void Display()
        {
            Console.WriteLine("policy name: {0}, sales rep: {1}", PolicyName, salesRep);
        }
    }
}
