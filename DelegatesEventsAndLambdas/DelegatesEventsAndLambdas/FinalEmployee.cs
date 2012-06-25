using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesEventsAndLambdas
{
    class FinalEmployee
    {
        public Int32 Id { get; set; }
        public String Fname { get; set; }
        public Double Salary { get; set; }
        //public so that any one can create an instance of this delegate type        
        public delegate void ObjectNotification(String s);

        //private: enforcing encapsulation, not giving access to the outside world to modify this delegate instance
        private static ObjectNotification delObject;

        public FinalEmployee() : this (0001, "naynish", 85000)
        {

        }

        public FinalEmployee(Int32 id, String fname, Double salary)
        {
            Id = id;
            Fname = fname;
            Salary = salary;
        }

        public static void ChangedState()
        {
            if (delObject != null)
            {
                delObject.Invoke("state of FinalEmployee changed");
            }
        }

        public override string ToString()
        {
            return String.Format("Employee Id: {0}, Fname: {1}, Salary: {2}", Id, Fname, Salary);
        }

        //allowing the outside world to send in methods to attach to our delegate object
        public void RegistrationMethod(ObjectNotification e)
        {
            //multicast delegate: maintains a list of methods to call
            delObject += e;            
        }

        public void AlternativeRegistrationMethod(Delegate[] e)
        {
            delObject = (ObjectNotification)Delegate.Combine(e);
        }

        public void UnRegisterSimple(ObjectNotification e)
        {
            delObject -= e;
        }

        //method group conversion: 
        //supply a direct method name, rather than a delegate object, when calling methods that take delegates
        //as arguments.
        public void UnRegisterBackGround(ObjectNotification e)
        {
            delObject = (ObjectNotification)Delegate.Remove(delObject, e);
        }
    }
}
