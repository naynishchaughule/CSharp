using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesEventsAndLambdas
{
    class GenericEventHandlerDemo
    {
        public event EventHandler<EventInformation> e;

        public void Inv()
        {
            e.Invoke(this, new EventInformation("EventHandler<T>"));
        }
    }
}
