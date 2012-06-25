using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatesEventsAndLambdas
{    
    //caller
    class Program
    {
        //delegate points to methods that return the base class instance (Fruit)
        public delegate Fruit Covariance();

        //generic delegate
        public delegate T GenericDelegate<T>(T obj);
        
        static void Main(string[] args)
        {
            Program p1 = new Program();
            Employee emp1 = new Employee();            
            emp1.Show();
            Console.WriteLine((typeof(BasicDelegate)).GetType().BaseType);
            Console.WriteLine("\nBinaryCalc");
            System.Delegate[] arrDelegateArray = { new BinaryCalc(SimpleMath.Add), new BinaryCalc(SimpleMath.Subtract)};
            System.MulticastDelegate.Combine(arrDelegateArray);
            foreach (Delegate item in arrDelegateArray)
            {
                if (item is DelegatesEventsAndLambdas.BinaryCalc)
                {
                    Console.WriteLine("Value: {0}", ((BinaryCalc)item).Invoke(100.45, 45.78));
                }
            }

            FinalEmployee femp1 = new FinalEmployee(0002, "jay", 45000);
            //Register methods with the delegate
            //it expects an object of type delegate: you can pass in a method that satisfies the constraints of the delegate
            //femp1.RegistrationMethod(p1.EmployeeHandler1);
            //femp1.RegistrationMethod(p1.EmployeeHandler2);

            Delegate[] altReg = new Delegate[] { new FinalEmployee.ObjectNotification(p1.EmployeeHandler1), new FinalEmployee.ObjectNotification(p1.EmployeeHandler2) };
            femp1.AlternativeRegistrationMethod(altReg);
            //femp1.UnRegisterSimple(p1.EmployeeHandler1);
            femp1.UnRegisterBackGround(p1.EmployeeHandler2);
            FinalEmployee.ChangedState();   
         
            //delegate covariance: return type of a method should take into account the rules of classical inheritance
            //same delegate object is used to point to two methods returning different instances but are related by
            //classical inheritance
            Covariance cvObj = new Covariance(ReturnsFruitInstance);
            cvObj += ReturnsMangoInstance;                        
            cvObj.Invoke();
         
            //creating an instance of generic delegate
            GenericDelegate<Mango> mngGeneric = new GenericDelegate<Mango>(GenericDelegateHandler);
            Console.WriteLine(mngGeneric.Invoke(new Mango("MNG", "Mumbai")));

            Student.Reg();
            Events.Fire();

            GraduateStudents gs = new GraduateStudents(32978439, "naynish p. chaughule");
            //student registers for the career fair
            gs.RegisterForCareerFair();

            //notify about the event
            gs.Ep.NotifyGuests();

            //
            GenericEventHandlerDemo geDemo = new GenericEventHandlerDemo();
            geDemo.e += new EventHandler<EventInformation>(GenEventHandler);
            geDemo.Inv(); 

            //anonymous methods:
            AnonymousMethods am = new AnonymousMethods();
            am.eveA += delegate(Object s, EventArgs e)
            {
                Console.WriteLine("\n" + s);
                Console.WriteLine(((EventInformation)e).Message);
            };
            am.DoSomeWork();

            WorkingWithLambdaExpressions();
            MyEventHandlingArchitecture();
            Fellows f1 = new Fellows();
            f1.RegisterWithEvent();
            f1.ea.RaiseEvent();
            Console.ReadLine();
        }

        private static void MyEventHandlingArchitecture()
        {
            
        }

        public static void ShowHandler1()
        {
            Console.WriteLine("Program.ShowHandler1() called...");
        }

        public static void ShowHandler2()
        {
            Console.WriteLine("Program.ShowHandler2() called...");
        }

        public void ShowHandler3()
        {
            Console.WriteLine("Program.ShowHandler3() called...");
        }

        public void EmployeeHandler1(String s)
        {
            Console.WriteLine("EmployeeHandler1, Value of String: {0}", s);
        }

        public void EmployeeHandler2(String s)
        {
            Console.WriteLine("EmployeeHandler2, Value of String: {0}", s.ToUpper());
        }

        public static Fruit ReturnsFruitInstance()
        {
            Console.WriteLine("\nReturnsFruitInstance() called...");
            return new Fruit("Apple");
        }

        public static Mango ReturnsMangoInstance()
        {
            Console.WriteLine("ReturnsMangoInstance() called...");
            return new Mango("mango...", "MH");
        }

        public static T GenericDelegateHandler<T>(T obj)
        {
            return obj;
        }

        public static void GenEventHandler(Object sender, EventInformation e)
        {
            Console.WriteLine("\nGenEventHandler() called...{0}", e.Message);
        }

        public static void WorkingWithLambdaExpressions()
        {
            List<Int32> list = new List<int>();
            list.AddRange(new Int32[] { 23, 4, 6, 67, 90, 56, 89, 29, 10, 18});
            //List<Int32> newList = list.FindAll(
            //        delegate(Int32 i)
            //        {
            //            if (i % 2 == 0)
            //            {
            //                return true;
            //            }
            //            else
            //                return false;
            //        }
            //    );

            List<Int32> newList = list.FindAll(
                    (int i) =>
                    {
                        if (i % 2 == 0)
                        {
                            return true;
                        }
                        else
                            return false;
                    }
                );
            Console.WriteLine("Even numbers...");
            foreach (Int32 item in newList)
            {
                Console.WriteLine(item);
            }
        }

        public static bool CheckEven(Int32 obj)
        {
            if (obj % 2 == 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
