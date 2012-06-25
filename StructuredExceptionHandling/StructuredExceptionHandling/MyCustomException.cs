using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructuredExceptionHandling
{
    //trap runtime errors
    //System.ApplicationException --> System.Exception (just a set of ctors) --> System.Object
    //strongly typed exception
    //exceptions are often passed outside of assembly
    public class MyCustomException : System.ApplicationException
    {
        DateTime _dt;
        public MyCustomException() : this ("default ctor msg", new Exception("default inner exception - naynish"), DateTime.Now)
        {
            
        }

        public MyCustomException(string msg) : base (msg)
        {

        }

        public MyCustomException(string msg, Exception inne, DateTime dt) : base (msg, inne)
        {
            HelpLink = "www.google.com";
            this.Data.Add("Source", this.Source);
            this.Data.Add("TargetSite", this.TargetSite);
            this.Data.Add("Message", this.Message);
            this.Data.Add("HelpLink", this.HelpLink);
            this.Data.Add("StackTrace", this.StackTrace);
            this.Data.Add("InnerException", this.InnerException);
            _dt = dt;
        }

        public void ShowExceptionDetails()
        {                       
            //This property gets or sets the name of the assembly, or the object, that threw the current exception.
            MyCustomHashTable.ht.Add("Source", this.Source);
            //This read-only property returns a MethodBase object, which describes numerous details about the method that threw the exception.
            //System.Reflection.MethodBase object
            MyCustomHashTable.ht.Add("TargetSite", this.TargetSite);
            //textual description of a given error
            MyCustomHashTable.ht.Add("Message", this.Message);
            MyCustomHashTable.ht.Add("HelpLink", this.HelpLink);
            //This read-only property contains a string that identifies the sequence of calls that triggered the exception.
            MyCustomHashTable.ht.Add("StackTrace", this.StackTrace);
            MyCustomHashTable.ht.Add("InnerException", this.InnerException);

            foreach (DictionaryEntry item in MyCustomHashTable.ht)
            {
                //if ((string)item.Key == "InnerException")
                //{
                //    Console.WriteLine(item.Key + " : " + item.Value);
                //}
                Console.WriteLine(item.Key + " : " + item.Value);
            }
        }

        public void ShowDetailsUsingDataProperty()
        {
            foreach (DictionaryEntry item in this.Data)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }

            Console.WriteLine("TYPE OF EXCEPTION: {0} {1}", this is System.ApplicationException, _dt);
        }        
    }

    //.NET best practice
    [Serializable]
    public class MyException : Exception
    {
        public MyException() { }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception inner) : base(message, inner) { }
        protected MyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
