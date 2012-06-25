using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    //mark it public to make this interface accessible outside the defining assembly
    //interface hierarchy, one interface derives from another, now you need to implement 'void MyCustomInterface.Display()'
    //as well as 'object ICloneable.Clone()' if any of your classes intend to implement MyCustomInterface
    public interface MyCustomInterface : ICloneable
    {
        //interfaces cannot have fields, ctors, events and indexers
        //members are implicitly public and abstract
        //just methods and properties (interfaces model the behavior)
        void Display();
    }
}
