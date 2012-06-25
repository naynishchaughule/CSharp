using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyExtensionsLibrary;

namespace AdvancedLanguageFeatures
{
    //implements IBasicMath and it supports a Subtract method
    class MyCalc : IBasicMath
    {
        double IBasicMath.Add(double x, double y)
        {
            return x + y;
        }
    }
}
