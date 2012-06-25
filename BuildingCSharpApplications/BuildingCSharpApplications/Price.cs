using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuildingCSharpApplications
{
    //publisher
    class Price
    {        
        public delegate double Display(params double[] args);        
        public event Display calc;
        public int costPerLitre = 80.56;

        public void RaiseEventPriceUpdate()
        {
            calc(10.02, 234.45);     
        }
    }
}
