using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    //implementing ICloneable in this scenario to perform deep copy
    struct BitmapPoint : ICloneable
    {
        public double x, y;
        public Draw internalRef;
       
        public BitmapPoint(double x1, double y1, double startingPoint)
        {
            internalRef = new Draw(startingPoint);
            x = x1;
            y = y1;            
        }

        public override string ToString()
        {
            return String.Format("X: {0}, Y: {1}, Starting Point: {2}", x, y, this.internalRef.StartPoint);
        }

        //can do this but not required
        //public void DisplayPoint()
        //{
        //    Console.WriteLine("X: {0}, Y: {1}", X, Y);
        //}

        //deep copy
        object ICloneable.Clone()
        {
            //first do a member wise clone to create independent copies of value types. 
            BitmapPoint newBitmap = (BitmapPoint)this.MemberwiseClone();
            //newBitmap.x = this.x;
            //newBitmap.y = this.y;
            //then fill in the gaps: create new instance of internal reference type
            newBitmap.internalRef = new Draw();
            newBitmap.internalRef.StartPoint = this.internalRef.StartPoint;
            return newBitmap;
        }

        public Object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}
