using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesEventsAndLambdas
{
    class Fellows
    {
        public EventHandlingArchitecture ea = new EventHandlingArchitecture(0001, new StringBuilder("notify me of weather"), new DateTime(2012, 07, 20), 
            new DerivedEventArgs(DerivedEventArgs.TypeOfEvent.WeatherWarnings));

        public void RegisterWithEvent()
        {
            ea.myCustomEvent += (Object sender, DerivedEventArgs e) =>
                {
                    Console.WriteLine(sender);
                };
        }       
    }
}
