using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{

    class Rectangle
    {
        public Double Length { get; set; }
        public Double Height { get; set; }

        public Rectangle(Double length, Double width)
        {
            Length = length; Height = width;
        }

        public virtual Double Area()
        {            
            return Length * Height;
        }      

        public override string ToString()
        {
            return String.Format("Area of a rectangle: {0}", Area());
        }
    }

    class Square : Rectangle
    {
        public Double Side { get; set; }

        public Square(Double side) : base (side, side)
        {
            Side = side;
        }

        public override Double Area()
        {            
            return Side * Side;
        }

        //it is illegal to define explicit and implicit conversion functions on
        //the same type if they do not differ by their return type or parameter set
        //when a type defines an implicit conversion routine, it is
        //legal for the caller to make use of the explicit cast syntax
        public static implicit operator Double(Square s)
        {
            return s.Length;
        }

        public static explicit operator Square(Double d)
        {
            return new Square(d);
        }

        public override string ToString()
        {
            return String.Format("Area of a square {0}", Area());
        }
    }

    //custom type conversion can be useful with structures as it does not support classical inheritance
    class Shoes
    {
        public String Name { get; set; }

        public Shoes (String name)
	    {
            Name = name;
	    }

        public override string ToString()
        {
            return String.Format("Shoe name: {0}", Name);
        }
    }

    class Reebok
    {
        public String Name { get; set; }
        public String StoreLocation { get; set; }
        public Double Price { get; set; }
             
        public Reebok(String name, String location, Double price)
        {
            Name = name;
            StoreLocation = location;
            Price = price;
        }
           
        //public static explicit operator Reebok (Shoes s)
        //{
        //    Reebok r = new Reebok(s.Name, "default - DC", 45);
        //    return r;
        //}

        public static implicit operator Shoes(Reebok r)
        {
            Shoes s = new Shoes(r.Name);
            return s;
        }

        public static explicit operator Reebok(Shoes s)
        {
            Reebok r = new Reebok(s.Name, "texas", 16);
            return r;                 
        }       

        public override string ToString()
        {            
            return String.Format("Reebok, Name: {0}, Store Location: {1}, Price: {2:C}", Name, StoreLocation, Price);
        }
    }

    class CustomTypeConversion
    {
        public void BasicOperations()
        {
            Int32 i = 10;
            Int64 longVal = i;
            Console.WriteLine("\nImplicit casting {0}", longVal);
            longVal = 300;
            SByte sb = (SByte)longVal;
            Console.WriteLine("\nExplicit casting {0}", sb);

            //Shoes and Reebok types are not related: applying explicit/implicit cast
            //creating a scenario such that, Shoes is the base class (but not in reality) 
            //and implict conversion from Reebok to Shoes is possible
            Shoes s = new Reebok("hello", "nyc", 78);

            //explicit cast
            Reebok r1 = (Reebok) new Shoes("hush puppies");
            Console.WriteLine(r1);

            //square (derived class) is a rectangle (base class)
            //implicit
            Rectangle rect = new Square(12);
            Console.WriteLine(rect);

            //explicit: cannot convert a base class to derived class using explicit cast
            //Square sqr = new Rectangle(19, 20);

            //Square --> Double: implicit cast
            //though it is implicit you can also apply a cast
            Double d = (Double)new Square(35);
            Console.WriteLine("Double d: {0}", d);
            //explicit cast
            Square mySqr = (Square)45.78;
            Console.WriteLine("Square mySqr: {0}", mySqr.Area());
        }
    }
}
