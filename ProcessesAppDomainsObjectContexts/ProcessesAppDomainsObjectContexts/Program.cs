using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ProcessesAppDomainsObjectContexts
{
    class Program
    {
        static void Main(string[] args)
        {
            ListProcesses();
            ListSpecificProcess();
            EnumThreadsForPid(Process.GetCurrentProcess().Id);
            EnumModsForPid(Process.GetCurrentProcess().Id);
            //EnumModsForPid(4232);
            //StartAndKillProcess();
            //PStartInfo();
            ApplicationDomainDemo.DefaultAppDomain();
            ApplicationDomainDemo.ListAllAssembliesInAppDomain();
            ApplicationDomainDemo.InitDAD();
            CustomAppDomains.ListAllAssembliesInAppDomain();
            AppDomain ad = AppDomain.CurrentDomain;
            ad.ProcessExit += new EventHandler(ad_ProcessExit);
            SportsCar sc = new SportsCar();
            SportsCarTS ts = new SportsCarTS();
            Console.ReadLine();
        }

        static void ad_ProcessExit(object sender, EventArgs e)
        {
            Console.WriteLine("Default App Domain Unloaded");
        }

        private static void ListProcesses()
        {
            var PCollection = from item in Process.GetProcesses(".")
                              orderby item.Id
                              select item;
            foreach (Process item in PCollection)
            {
                Console.WriteLine(item.Id + " " + item.ProcessName);
            }
        }

        private static void ListSpecificProcess()
        {
            Console.WriteLine("\n" +Process.GetCurrentProcess());
        }

        private static void EnumThreadsForPid(int pid)
        {
            Process p = System.Diagnostics.Process.GetProcessById(pid);
            ProcessThreadCollection coll = p.Threads;
            Console.WriteLine("Threads of {0}", p);
            foreach (ProcessThread item in coll)
            {
                Console.WriteLine(item.Id + " " + item.PriorityLevel + " " + item.StartTime.ToString());
            }
        }

        private static void EnumModsForPid(int pid)
        {
            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(pid);
            ProcessModuleCollection pmc = p.Modules;
            Console.WriteLine("\nModules hosted by process {0}", p);
            foreach (ProcessModule item in pmc)
            {
                Console.WriteLine(item.ModuleName);
            }
        }

        static void StartAndKillProcess()
        {
            Process p = System.Diagnostics.Process.Start("IExplore.exe", "www.facebook.com");
            Console.ReadLine();
            p.Kill();
        }

        static void PStartInfo()
        {
            System.Diagnostics.ProcessStartInfo p = new ProcessStartInfo("IExplore.exe", "www.facebook.com");
            p.WindowStyle = ProcessWindowStyle.Maximized;
            Process p1 = Process.Start(p);
            Console.ReadLine();
            p1.Kill();
        }
    }
}
