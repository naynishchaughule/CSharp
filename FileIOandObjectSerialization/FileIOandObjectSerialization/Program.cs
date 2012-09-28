using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileIOandObjectSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@".\Testing");
            if(!di.Exists)
            {
                di.Create();
            }
            ShowWindowsDirectoryInfo();
            DisplayImageFiles();
            ModifyAppDirectory();
            FunWithDirectoryType();

            DriveInfo[] arr = DriveInfo.GetDrives();
            foreach (DriveInfo d in arr)
            {
                Console.WriteLine("Name: {0}", d.Name);
                Console.WriteLine("Type: {0}", d.DriveType);
                if (d.IsReady)
                {
                    Console.WriteLine("Free space: {0}", d.TotalFreeSpace);
                    Console.WriteLine("Format: {0}", d.DriveFormat);
                    Console.WriteLine("Label: {0}", d.VolumeLabel);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            FileHandling();
            FileReadWrite();
            FileStreamDemo();
            MyDirectoryWatcher();
            Console.ReadLine();
        }

        static void ShowWindowsDirectoryInfo()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
        }

        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Public\Pictures\Sample Pictures");
            FileInfo[] fiArr = dir.GetFiles("*.jpg");
            Console.WriteLine("\nNo. of files {0}", fiArr.Length);
            foreach (var item in fiArr)
            {
                Console.WriteLine("File name: {0}", item.Name);
                Console.WriteLine("File size: {0}", item.Length);
                Console.WriteLine("Creation: {0}", item.CreationTime);
                Console.WriteLine("Attributes: {0}", item.Attributes);
                Console.WriteLine();
            }
        }

        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(@".\Testing");
            DirectoryInfo newDir = dir.CreateSubdirectory(@"Create");
            Console.WriteLine("\n{0} created successfully", newDir.Name);
        }

        static void FunWithDirectoryType()
        {
            String[] arr = Directory.GetLogicalDrives();
            foreach (string item in arr)
            {
                Console.Write("Logical drive: {0}", item);
                Console.WriteLine();
            }

            try
            {
                Directory.Delete(@"G:\naynish\Pro C# 2010 and the .NET 4 Platform\FileIOandObjectSerialization\FileIOandObjectSerialization\bin\Debug\Testing", true);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void FileHandling()
        {
            FileInfo fi = new FileInfo(@"G:\naynish\Pro C# 2010 and the .NET 4 Platform\FileIOandObjectSerialization\FileIOandObjectSerialization\bin\Debug\Test.cs");
            using (FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                
            }
        }

        static void FileReadWrite()
        {
            string s = @"G:\naynish\Pro C# 2010 and the .NET 4 Platform\FileIOandObjectSerialization\FileIOandObjectSerialization\bin\Debug\Test.cs";
            String[] strArr = new string[] { "naynish", "tripti", "purab" };
            File.WriteAllLines(s, strArr);

            foreach (string item in File.ReadAllLines(s))
            {
                Console.WriteLine(item);
            }
        }

        static void FileStreamDemo()
        {
            String s = @"G:\naynish\Pro C# 2010 and the .NET 4 Platform\FileIOandObjectSerialization\FileIOandObjectSerialization\bin\Debug\Test.cs";
            using (FileStream fs = File.Open(s, FileMode.Create))
            {
                string greetings = "Hello World!";
                byte[] bArr = Encoding.Default.GetBytes(greetings);
                fs.Write(bArr, 0, bArr.Length);
                fs.Position = 0;

                byte[] bytesFromFile = new byte[bArr.Length];
                for (int i = 0; i < bArr.Length; i++)
                {
                    bytesFromFile[i] = (byte)fs.ReadByte();
                    Console.WriteLine(bytesFromFile[i]);
                }
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));                
            }
            StreamWriterReaderApp();
        }

        static void StreamWriterReaderApp()
        {
            String s = @"reminder.txt";            
            using (StreamWriter sw = File.CreateText(s))
            {
                sw.WriteLine("Hello, Tripti P.");
            }

            using (StreamReader sr = File.OpenText(s))
            {
                string input = null;
                while ((input = sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }
            StringWriterReaderApp();
        }

        static void StringWriterReaderApp()
        {
            using(StringWriter sw = new StringWriter())
            {
                sw.WriteLine("using string writer");                
                StringBuilder sb = sw.GetStringBuilder();
                Console.WriteLine(sb.ToString());
            }
            StringBuilder sb1 = new StringBuilder("inovalon");
            StringWriter sw1 = new StringWriter(sb1);
            using(StringReader sr = new StringReader(sb1.ToString()))
            {
                Console.WriteLine(sr.ReadLine());
            }
            BinaryWriterReaderApp();
        }

        static void BinaryWriterReaderApp()
        {
            String s = "reminder.txt";
            FileInfo f = new FileInfo(s);
            using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
            {
                bw.Write("software engineer");
            }

            using (BinaryReader bw = new BinaryReader(f.OpenRead()))
            {
                Console.WriteLine(bw.ReadString());
            }
        }

        static void MyDirectoryWatcher()
        {
            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = ".";
            fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            fsw.Filter = "*.txt";

            fsw.Changed += new FileSystemEventHandler(fsw_Changed);
            fsw.Created += new FileSystemEventHandler(fsw_Created);
            fsw.Renamed += new RenamedEventHandler(fsw_Renamed);
            fsw.EnableRaisingEvents = true;
        }

        static void fsw_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("file renamed {0}", e.Name);
        }

        static void fsw_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("file created {0}", e.Name);
        }

        static void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("file changed {0}", e.FullPath);
        }
    }
}
