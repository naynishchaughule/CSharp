using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesEventsAndLambdas
{
    class GraduateStudents
    {
        public Int32 GWId { get; set; }
        public String SName { get; set; }
        EventPlanners ep;

        internal EventPlanners Ep
        {
            get { return ep; }
            set { ep = value; }
        }

        public GraduateStudents(int id, string name)
        {
            GWId = id;
            SName = name;
        }

        public void RegisterForCareerFair()
        {
            Ep = new EventPlanners(001, EventPlanners.TypeOfEvent.CareerFair, "Graduate Placements", new DateTime(2012, 07, 12), "Marvin Center", 25, "only for 2012 graduates of SEAS");
            Ep.eventNotification += new EventPlanners.EventState(ep_eventNotification);
        }

        void ep_eventNotification(object sender, EventInformation args, string msg)
        {
            Console.WriteLine("\n"+ args.Message);
            Console.WriteLine(sender);
            Console.WriteLine("note: {0}", msg);
        }
    }
}
