using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuildingCSharpApplications
{
    //listener
    public class Car
    {
        protected string _name;
        
        public Car(string name)
        {
            _name = name;
            Price pObj = new Price();
            pObj.calc += new Price.Display(this.Cost);
            pObj.RaiseEventPriceUpdate();
        }

        //event handler
        private double Cost(params double[] args)
        {
            double sum = 0;
            foreach (var item in args)
	            sum += item;
            Console.WriteLine(sum);
            return sum;
        }
    }
}
