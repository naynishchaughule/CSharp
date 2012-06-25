using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningEncapsulatedClassTypes
{
    enum Color
    {
        blue,
        white,
        green
    }

    class Concise
    {
        //none of my constructors set all the public properties
        //So the best way out was to call any constructor and set the remaining public properties
        //with object initialization syntax (OIS)
        public int Id { get; set; }
        public string Name { get; set; }
        //new public property not set by any of my constructors
        public string City { get; set; }
        public Color typeOfColor { get; set; }
        public string college;

        //auto property will set this ref to null (default value)
        //we will use traditional properties
        private Rectangle rec;
        //implicitly static
        //value of constant data must be known at compile time
        //value should be known ahead of time
        public const double PI = 3.14;
        
        //value can be assigned at runtime but only in the ctor
        //not implicitly static        
        private readonly double lambda;
        //set readonly in ctor
        public double Lambda
        {
            get { return lambda; }
        } 

        //readonly and const are same
        //but readonly can be assigned value at runtime in a class's ctor
        //const's value must be known at compile time

        //static readonly properties
        //can be invoked from class level
        //initialize it in a static ctor at runtime
        public static readonly double trigo;

        public Rectangle Rec
        {
            get { return rec; }
            set { rec = value; }
        }

        //Constructors are invoked at runtime.

        static Concise()
        {
            Random rn = new Random(89);
            trigo = rn.Next(500);
        }

        public Concise(Color c)
        {
            typeOfColor = c;
        }

        public Concise() : this (Color.white)
        {

        }

        public Concise(int id, string name)
        {
            Id = id;
            Name = name;
            //i can take the value from the ctor parameters and set it to lambda
            lambda = id;
        }

        public void Display()
        {
            Console.WriteLine("Concise Id {0}, Name {1}", Id, Name);
        }

        public void ColorDP()
        {
            Console.WriteLine("Concise color {0}", typeOfColor);
            Console.WriteLine("in class PI {0}", PI);            
        }
    }
}
