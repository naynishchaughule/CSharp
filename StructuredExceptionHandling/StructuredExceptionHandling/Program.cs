using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.ExceptionServices;

namespace StructuredExceptionHandling
{
    class Program
    {
        static InvalidCastException ice;
        //Within the Windows API, it is possible to trap extremely low-level errors that represent “corrupted
        //state” errors. //test
        [HandleProcessCorruptedStateExceptions]
        static void Main(string[] args)
        {            
            //try-catch within Main is my last chance to handle Corrupted State Exceptions
            try
            {                
                //prev exception
                Exception inn = new Exception("my inner exception - naynish");  
                //inner exception: 
                //used to obtain information about the previous exception(s) that caused the current exception to occur.
                //The previous exception(s) are recorded by passing them into the constructor
                //of the most current exception.
                throw new MyCustomException("hello exceptions!", inn, DateTime.Now);        
            }            

            catch (MyCustomException e)
            {
                e.ShowExceptionDetails();
                //returns System.Reflection.MethodBase object
                Console.WriteLine(e.TargetSite.DeclaringType);
                Console.WriteLine(e.TargetSite.MemberType);
                Console.WriteLine("using System.Exception.Data property\n \n \n \n");
                e.ShowDetailsUsingDataProperty();               

            }

            //catch 
            //{
                //never use it, its is not informative
            //}
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);                
            }
            //will always execute - exception or not
            //when you need to dispose of objects, close a file, detach from a database
            finally
            {
            
            }

            //new try-catch
            try
            {                
                ice = new InvalidCastException();
                throw ice;
            }
            catch (Exception)
            {
                System.Exception temp = ice as System.Exception;
                Console.WriteLine("InvalidCastException {0}", temp is System.SystemException);
            }

            //rethrowing logic
            try
            {
                Class2 c2 = new Class2();
                c2.Relay();
            }
            catch (Exception e)
            {
                Console.WriteLine("final catch clause {0}", e.Message);
                Console.WriteLine(e.InnerException.Message);
            }

            Console.WriteLine("End of App --");            
            Console.ReadLine();
        }
    }
}
