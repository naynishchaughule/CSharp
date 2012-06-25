using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesEventsAndLambdas
{
    class Events
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Location { get; set; }
        public delegate void Notify<T>(T s);
        public static event Notify<String> e;
        //with events I am not creating an instance of the underlying delegate
        //also I do not have to write registration and unregistration methods
        //Also events cannot be invoked by the outside world, they can only be invoked in this class
        //the outside world will have to attach methods to this public event

        public Events()
        {

        }

        public Events(int id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
        }

        public static void Fire()
        {
            e.Invoke("Career Fair at Marvin Center");
        }
    }
}
