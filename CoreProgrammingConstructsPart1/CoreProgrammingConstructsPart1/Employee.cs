using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProgrammingConstructsPart1
{
    class Employee : IEnumerable
    {        
        public static BenefitPlan[] arrBenefit = new BenefitPlan[4];
        
        public Employee()
        {
            arrBenefit[0] = new BenefitPlan(6377);
            arrBenefit[1] = new BenefitPlan(4642);
            arrBenefit[2] = new BenefitPlan(7689);
            arrBenefit[3] = new BenefitPlan(0286);
        }

        public IEnumerator GetEnumerator()
        {
            return arrBenefit.GetEnumerator();
        }
    }
}
