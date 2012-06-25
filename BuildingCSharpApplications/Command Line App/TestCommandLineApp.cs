using System;
using System.Windows.Forms;
using MyMathLibrary;
namespace CommandLineCompilation
{
	class TestCommandLineApp
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			 foreach (string item in args)
			 {
				Console.WriteLine(item);
			 }
            double result = MyMathClass.Add(10.34, 324.345, 78.02, 90.245);
            //fun with Double.Parse(string s)
            Console.WriteLine("result: {0}", Double.Parse(result.ToString()).ToString());
			MessageBox.Show("Completed reading command line arguments...");
		}
	}
}