using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesEventsAndLambdas
{
    class DerivedEventArgs : EventArgs
    {
        TypeOfEvent eventType;

        private TypeOfEvent EventType
        {
            get { return eventType; }
            set { eventType = value; }
        }

        public enum TypeOfEvent
        {
            WeatherWarnings,
            SchoolClosedAlerts,
            HighSecurityAlerts,
            PartyNotifications
        }

        public DerivedEventArgs(TypeOfEvent type)
        {
            EventType = type;
        }

        public override string ToString()
        {
            return String.Format("Type of Event: {0}", EventType);
        }
    }
}
