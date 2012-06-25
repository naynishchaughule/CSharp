using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesEventsAndLambdas
{
    class EventPlanners
    {
        public delegate void EventState(Object sender, EventInformation args, String msg);
        public event EventState eventNotification;

        public int Id { get; set; }
        public enum TypeOfEvent
        {
            Birthday,
            Engagement,
            Wedding,
            CareerFair,
            Anniversary
        }
        TypeOfEvent _eventType;

        internal TypeOfEvent EventType
        {
          get { return _eventType; }
          set { _eventType = value; }
        }

        public String Name { get; set; }
        public DateTime DateAndTime { get; set; }
        public String Venue {get; set;}
        public Double Cost { get; set; }
        EventInformation eveInfo;

        public EventPlanners(int id, TypeOfEvent e, string name, DateTime dt, String loc, Double cost, String eventRelatedInformation)
        {
            Id = id; EventType = e; Name = name; DateAndTime = dt; Venue = loc; Cost = cost;
            eveInfo = new EventInformation(eventRelatedInformation);
        }

        public void NotifyGuests()
        {
            if (eventNotification != null)
            {
                eventNotification.Invoke(this, eveInfo, "Welcome to the event!!!");
            }
        }

        public override string ToString()
        {
            return String.Format("Event Id: {0}, Type of Event: {1}, Name: {2}, Date-Time: {3}, Venue: {4}, Cost: {5}",
                Id, EventType, Name, DateAndTime, Venue, Cost);
        }
    }
}
