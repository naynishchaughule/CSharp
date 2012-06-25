using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningEncapsulatedClassTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee.projectId = 12;            
            //declares a reference
            Employee nash;
            //It is not until you assign a reference to an object that this reference points to a valid object in memory
            //Allocating Objects with the new Keyword
            nash = new Employee(48090, "naynish p. chaughule", 65000);
            nash.Display();

            //set to an appropriate default value
            Employee john = new Employee();
            john.Display();

            Employee purab = new Employee(78090, "purab s. bhatt");
            purab.Display();

            //named arguments 4.0
            
            Employee ryan = new Employee(address: "2400 virginia ave");
            ryan.Display();
            Console.WriteLine(Employee.GetRandomNumber());
            Employee.projectId = 45;
            Employee.SetProjectID(2500);
            Console.WriteLine(Employee.projectId);
            HealthPolicy hp1 = new HealthPolicy("olya reghay");
            HealthPolicy.PolicyName = "gwu 8905";
            hp1.Display();

            Geometry[] arrGeom = new Geometry[] { new Rectangle(10, 20), new Square(19), new Rectangle(25, 78)};
            foreach (Geometry item in arrGeom)
            {
                item.Area();
            }

            ryan.SetCompanyContact("202-714-5352");
            Console.WriteLine("ryan's company : {0}", ryan.GetCompanyContact());
            ryan.Id++;
            ryan.Display();
            Console.WriteLine("ryan's tax policy : {0} {1}", Employee.TaxPolicy, Employee.sqr1.side);

            Concise c1 = new Concise();
            c1.Display();
            c1.Id = 001; c1.Name = "syntactic sugar";
            c1.Display();

            Concise c2 = new Concise(002, "candy");
            c2.Display();

            //Each member in the initialization list maps to the name of a public field or public property of the object being initialized.                 
            //not making use of a custom constructor            
            //the type’s default constructor is invoked, followed by setting the values to the specified properties
            //just shorthand notations for the syntax used to create a class variable using a
            //default constructor, and setting the state data property by property
            Concise objSyn = new Concise { Id = 48090, Name = "nc" };
            //Concise objSyn = new Concise() { Id = 48090, Name = "nc" };
            objSyn.Display();

            //constructor arguments will be over written by the OIS
            Concise cNew = new Concise(90, "dummy") { Id = 65985, Name = "nishu" };
            cNew.Display();

            Concise cityNew = new Concise(9000, "john") { City = "New York" };

            Concise cColor = new Concise(Color.blue) { Id = 903, Name = "CP" };
            cColor.Display();
            cColor.ColorDP();

            //maps to public fields
            Concise cDefault = new Concise { Id = 927, Name = "rode", typeOfColor = Color.blue, City = "nyc", Rec = new Rectangle(10, 20), college = "GWU" };
            cDefault.Display();
            cDefault.ColorDP();
            cDefault.Rec.Area();
            //const data is called at class level
            Console.WriteLine(Concise.PI);
            Concise accessRead = new Concise(8967, "don bosco");
            Console.WriteLine(accessRead.Lambda);

            //invoking static ctor to set the static readonly property at runtime
            Console.WriteLine(Concise.trigo);

            Placement p1Off = new Placement("henry", "google");
            p1Off.DisplayPlacementStats();
            Console.ReadLine();
        }
    }
}
