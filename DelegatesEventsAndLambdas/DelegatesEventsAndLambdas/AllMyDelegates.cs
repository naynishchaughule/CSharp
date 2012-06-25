using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesEventsAndLambdas
{
    //CustomDelegate(sealed) --> System.MulticastDelegate(abstract) --> System.Delegate(abstract)
    delegate void BasicDelegate();
    delegate Double BinaryCalc(Double x, Double y);
}
