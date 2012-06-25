using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreProgrammingConstructsPart1
{
    class DataTypeConversions
    {        
        public void ConvertDataTypes()
        {
            byte b1 = 255, b2 = 250;
            //(b1 + b2) int --> byte (overflow)
            //all narrowing operations will result in compiler error
            //byte resultOverflow = (b1 + b2);
            //widening
            Int32 result = (Int32)(b1 + b2);
            Console.WriteLine(result);

            //byte newb1 = 20, newb2 = 30;
            //byte newResult = newb1 + newb2; //compiler error even though 50 can be stored in a byte
            //willing to have data loss
            try
            {
                //checked raises OverflowException
                byte dataLoss = checked((byte)(b1 + b2)); //505 - 256 = 249 (byte is unsigned, overflow in +ve)
                Console.WriteLine(dataLoss);
            }
            catch(OverflowException e)
            {
                Console.WriteLine("Over-flow {0}", e.Message);
            }


            try
            {
                checked
                {
                    short s1 = 30000, s2 = 30000;
                    short res = (short)(s1 + s2); // 60000 - 32767 = 27233 - 32767 = -5536
                    Console.WriteLine(res);
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine("short {0}", e.Message);
            }
            //project wide checked: Project Properties --> Build tab --> Advanced
            //select the Check for arithmetic overflow/underflow check box

            unchecked
            {
                //disable the system wide checked settings
                //does not raise OverflowException
                byte un1 = 255, un2 = 254;
                byte unResult = (byte)(un1 + un2);
                //language neutral, ignores unchecked keyword
                //always use the System.Convert class for data type conversions
                //it checks for overflow or underflow conditions and raises exceptions at runtime
                //it avoids the need to have checked, unchecked and system wide checked
                //byte unResult = System.Convert.ToByte(un1 + un2);
                Console.WriteLine(unResult);
                //the default behavior of the .NET runtime is to ignore arithmetic overflow/underflow.
            }
            //Contextual var token
            //applies only to local variables in a method or property scope.
            //illegal to use the var keyword to define return values, parameters, or field data of a custom type.
            var context = 10.0F;
            //reflecting
            Console.WriteLine("{0} {1}", context, context.GetType());
            ImplicitRestrictions();
        }

        public static void ImplicitRestrictions()
        {
            //affects only the declaration of variables at compile time.
            //dont's
            //var? obj = new Hierarchy();
            //obj = null;
            double[] arr = new double[] { 23.45, 345.89, 73.02};
            var result = from s in arr
                            where s > 30
                            select s;

            foreach (double item in arr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("{0}, {1}",result.GetType(), result.GetType().Namespace);
        }
    }
}
