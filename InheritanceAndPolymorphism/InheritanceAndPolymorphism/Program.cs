using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    class Program : System.Object
    {
        static void Main(string[] args)
        {
            Employee prog = new Programmer(48091, "naynish p. chaughule", 85000, 500, "233-324-1246", new BenefitPlan("GWU", 3500));
            ((Programmer)prog).CalculateIncentives();

            Employee vp = new VicePresident(001, "henry w. gates", 150000, 200000, "343-325-9477", new BenefitPlan("DC Plan", 2573));            
            ((VicePresident)vp).CalculateIncentives();
            foreach (var item in vp.GetMyPlanDetails())
	        {
                Console.WriteLine(item);
	        }
            Console.WriteLine(vp.MyPlan.PlanName + " ends 06/07/2012");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Programmer jay = new Programmer();
            jay.CalculateIncentives();
            VicePresident vp1 = new VicePresident();
            vp1.CalculateIncentives();

            //since InnerClass is private it is not exposed to the outside world
            //OuterClass.InnerClass obj = new OuterClass.InnerClass();      
            //cannot access the public members of the InnerClass


            Fruit f = new Fruit(); f.ShowFruitDetails();
            Apple a = new Apple(); a.ShowFruitDetails();
            Mango m = new Mango(); m.ShowFruitDetails();
            //exception rule
            //reference of base class but instance of subclass: the method called with base class reference is virtual
            //and it is overridden in the sub class. Then the sub classes method would be called
            Fruit f1 = new Apple();
            f1.ShowFruitDetails();
            ((Apple)f1).Display();
            f1.Display();
            KashmirApple ka = new KashmirApple();
            ka.ShowFruitDetails();
            ka.Display();

            Fruit f1ka = new KashmirApple();
            f1ka.ShowFruitDetails();
            f1ka.Display();
            ((KashmirApple)f1ka).Display();

            Apple ap1 = new Apple();
            ap1.Display(); //i dont want this, i want the Display of the base class, cast it
            ((Fruit)ap1).Display();

            //The first law of casting between class types is that when two classes are related by an “is-a”
            //relationship, it is always safe to store a derived object within a base class reference (implicit cast).
            HelperMethod(f);
            HelperMethod(a);
            HelperMethod(m);
            HelperMethod(f1);
            
            Object o = new Mango();
            //Object o is pointing to a Fruit compatible class but that will not be known until runtime
            //HelperMethod(o); //not allowed
            //do a downward-cast, explicit casting is evaluated at runtime, not compile time
            HelperMethod((Mango)o);
            //demo of explicit cast evaluated at runtime
            VicePresident vpDemo = new VicePresident();
            Object mng = new Mango();
            try
            {
                vpDemo = (VicePresident)mng; //no compile time errors for this downward cast as it follows the inheritance chain
                //System.Object <-- VicePresident //run it and a runtime exception will be fired
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }

            //as and is does not require try catch
            //solution: determine at runtime whether a given type is compatible with another
            //vpDemo of VicePresident and mng of Object/mango
            vpDemo = mng as VicePresident;
            if (vpDemo == null)
                Console.WriteLine("Could not copy mng to vpDemo");

            Fruit castFruit;
            Apple appDev = new Apple();
            castFruit = appDev as Fruit;
            if (castFruit != null)
                Console.WriteLine("successful casting");

            //In addition to the as keyword, the C# language provides the is keyword to determine whether two
            //items are compatible. Unlike the as keyword, however, the is keyword returns false, rather than a null
            //reference, if the types are incompatible.
            //check to see if mng is a VicePresident
            if (mng is VicePresident) //bool return value
                Console.WriteLine("casting possible");
            else
                Console.WriteLine("casting not possible");

            MasterParent mp1 = new MasterParent();
            mp1.ShowDetials();
            Console.ReadLine();
        }

        static void HelperMethod(Fruit f)
        {
            if (f is Mango)
            {
                Mango m = f as Mango;
                if (m != null)
                    m.CEO();
                //or you know f is Mango compatible class, do downward cast without 'as' keyword
                ((Mango)f).CEO();
            }
            Console.WriteLine("Helper {0}", f.GetType());
            f.ShowFruitDetails(); //virtual method and overridden in sub
            f.Display();
        }
    }
}
