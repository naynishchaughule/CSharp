using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesEventsAndLambdas
{
    class EventInformation : EventArgs
    {
        String message;

        public String Message
        {
            get { return message; }
            set { message = value; }
        }

        public EventInformation(String message)
        {
            Message = message;
        }
    }
}
