using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LinqOverview
{
    public delegate bool DelegateFileHandler(FileInfo file);

    class RunTest
    {
         static void Main(string[] args)
         {
             //SearchForFiles(@"C:\", new Predicate<FileInfo>(SmallFiles));
             //SearchForFiles(@"C:\", new DelegateFileHandler(SmallFiles));
             //SearchForFiles(@"C:\", delegate(FileInfo fi)
             //{
             //    if (fi.Length < 10000)
             //    {
             //        return true;
             //    }
             //    else
             //        return false;
             //});
             SearchForFiles(@"C:\", (FileInfo fi) =>
             {
                 if (fi.Length >= 10000)
                 {
                     return true;
                 }
                 else
                     return false;
             });
         }

         private static void SearchForFiles(string path, Predicate<FileInfo> condition)
         {
             List<MyFileInfo> files = new List<MyFileInfo>();
             foreach (FileInfo item in new DirectoryInfo(path).GetFiles())
             {
                 if(condition.Invoke(item))
                 {
                     files.Add(new MyFileInfo(item.Name) { Length = item.Length, CreationTime = item.CreationTime });
                 }
             }

             foreach (MyFileInfo item in files.OrderBy<MyFileInfo, long>((myfi) => (-myfi.Length)))
             {
                 Console.WriteLine(item);     
             }

             //Console.WriteLine("Total size in bytes: {0}", files.TotalSize().ToString("N0"));
             Console.WriteLine("Total size in bytes of top two large files: {0}", files.OrderByDescending(fi => fi.Length).Take(2).Sum(fi => fi.Length).ToString("N0"));             
             Console.ReadLine();
         }

         private static bool SmallFiles(FileInfo file)
         {
             if (file.Length < 10000)
             {
                 return true;
             }
             else
                 return false;
         }

         private static bool LargeFiles(FileInfo file)
         {
             if (file.Length >= 10000)
             {
                 return true;
             }
             else
                 return false;
         }
    }
}
