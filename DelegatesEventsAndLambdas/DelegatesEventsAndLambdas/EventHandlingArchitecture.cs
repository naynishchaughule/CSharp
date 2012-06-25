using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesEventsAndLambdas
{
    //group notification service
    class EventHandlingArchitecture
    {
        //using generic EventHandler<T> delegate
        public event EventHandler<DerivedEventArgs> myCustomEvent;
        public Int32 NotificationId { get; set; }
        public StringBuilder Message { get; set; }
        public DateTime DateAndTime { get; set; }
        public DerivedEventArgs EventType { get; set; }

        public EventHandlingArchitecture(int id, StringBuilder msg, DateTime dt, DerivedEventArgs d)
        {
            NotificationId = id; Message = msg; DateAndTime = dt;
            EventType = d;
        }

        public void RaiseEvent()
        {
            myCustomEvent.Invoke(this, EventType);
        }

        public override string ToString()
        {
            return String.Format("Object State, NotificationId: {0}, Message: {1},\nDateAndTime: {2}, EventType: {3}",
                NotificationId, Message, DateAndTime, EventType);
        }
    }
}
