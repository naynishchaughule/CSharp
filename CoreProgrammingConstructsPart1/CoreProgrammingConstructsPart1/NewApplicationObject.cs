using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace CoreProgrammingConstructsPart1
{
    //new application object
    class NewApplicationObject
    {        
        public static int Main()
        {
            Console.WriteLine("new app object");
            Console.Title = "Core Constructs";
            string[] args = System.Environment.GetCommandLineArgs();
            foreach (string item in args)
            {
                if (item.Substring(0, 1) == "/")
                    Console.WriteLine("cheat code {0}", item);
                Console.WriteLine(item);
            }            
            //successfully, void also returns 0
            //On the Windows operating system, an application’s return value is stored within a system
            //environment variable named %ERRORLEVEL%.            
            Program.Main();
            ExitCode();
            ShowEnvironmentDetails();
            NewApplicationObject newObj = new NewApplicationObject();
            newObj.FormattingNumericalData();

            Hierarchy hObj = new Hierarchy();
            hObj.Print();

            DataTypeConversions dtc = new DataTypeConversions();
            dtc.ConvertDataTypes();

            //Console.Write("clear buffer y/n? ");
            //if (Console.ReadLine() == "y")
            //    Console.Clear();
            //Console.Write("re-run app y/n? ");
            //if (Console.ReadLine() == "y")
            //    Main();
            //else
            //{
            //    Console.Beep();
            //    System.Environment.Exit(0);             
            //}       

            CustomIteration[] arr = new CustomIteration[] { new CustomIteration(10, new Car(2000)), new CustomIteration(20, new Car(5000)), new CustomIteration(30,new Car(8900)) };
            int count = 0;
            foreach (CustomIteration item in arr)
            {
                Console.WriteLine(item.carArr[count].price);
                count++;
            }

            Employee emp = new Employee();
            foreach (BenefitPlan item in emp)
            {
                Console.WriteLine(item.planID);
            }

            Console.ReadLine();            
            return System.Environment.ExitCode = 0;
        }

        private static void ExitCode()
        {
            Console.WriteLine(Program.p.HasExited);
            Console.WriteLine(Program.p.Id);
            Console.WriteLine(Program.p.BasePriority);
        }

        private static void ShowEnvironmentDetails()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(System.Environment.Version);
            Console.WriteLine(System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));
            Console.WriteLine(System.Environment.Is64BitOperatingSystem);
            Console.WriteLine(System.Environment.MachineName);
            Console.WriteLine(System.Environment.ProcessorCount);
            foreach (var item in System.Environment.GetLogicalDrives())
            {
                Console.Write(item + " ");   
            }
            Console.WriteLine(String.Format(@"\n"));
            Console.WriteLine(Environment.SystemDirectory);
            Console.WriteLine(Environment.UserDomainName);
            Console.WriteLine(Environment.WorkingSet);
            Console.WriteLine(Environment.StackTrace);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        private void FormattingNumericalData()
        {
            Console.WriteLine("{0:c}", 34.56);
            Console.WriteLine("{0:d4}", 454);
            Console.WriteLine("{0:e}, {1:e}", 454345464, 9690065470921726849);
            Console.WriteLine("{0:f4}, {1:F4}", 50.57, 89.34);
            Console.WriteLine("{0:g4}, {1:G4}", 50.57, 35.59);
            Console.WriteLine("{0:n4}, {1:N3}", 9038, 456);
            Console.WriteLine("{0:x}, {1:X}", 903854822709, 456);
            CustomFormatting obj = new CustomFormatting();
            Console.WriteLine(obj.Format("hello world", this, new MyFormatProvider())); 
        }

        public string Display()
        {
            return String.Format(" print");
        }
    }
}
