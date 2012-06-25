using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLanguageFeatures
{
    class Point : IComparable
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }

        public Point() : this (10, 20)
        {

        }

        public Point(int x, int y)
        {
            X = x; Y = y;
        }

        //static methods
        public static Point operator + (Point p1, Point p2)
        {
            Point temp = new Point();
            temp.X = p1.X + p2.X;
            temp.Y = p1.Y + p2.Y;
            return temp;
        }

        //increment point by some value: two 
        public static Point operator + (Point p1, int increment)
        {
            Point temp = new Point();
            temp.X = p1.X + increment;
            temp.Y = p1.Y + increment;
            return temp;
        }

        public static Point operator + (int increment, Point p1)
        {
            Point temp = new Point();
            temp.X = p1.X + increment;
            temp.Y = p1.Y + increment;
            return temp;
        }

        //gives you both pre and post increment operators
        public static Point operator ++ (Point p)
        {
            return new Point(p.X + 1, p.Y + 1);
        }

        public static Point operator -- (Point p)
        {
            return new Point(p.X - 1, p.Y - 1);
        }

        public override bool Equals(Object p2)
        {
            if (this.ToString() == p2.ToString())
            {
                return true;
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public static bool operator == (Point p1, Point p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator != (Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }

        public override string ToString()
        {
            return String.Format("\nValue X: {0}, Y:{1}", X, Y);
        }

        public int CompareTo(object obj)
        {
            if (this.X < ((Point)obj).X && this.Y < ((Point)obj).Y)
            {
                return -1;
            }
            else if (this.X > ((Point)obj).X && this.Y > ((Point)obj).Y)
            {
                return +1;
            }
            else
                return 0;
        }

        public static bool operator < (Point p1, Point p2)
        {
            return (p1.CompareTo(p2) < 0);
        }

        public static bool operator > (Point p1, Point p2)
        {
            return (p1.CompareTo(p2) > 0);
        }

        public static bool operator >= (Point p1, Point p2)
        {
            return (p1.CompareTo(p2) >= 0);
        }

        public static bool operator <= (Point p1, Point p2)
        {
            return (p1.CompareTo(p2) <= 0);
        }
    }
}
