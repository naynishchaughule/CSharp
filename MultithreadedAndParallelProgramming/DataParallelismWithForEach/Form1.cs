using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace DataParallelismWithForEach
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnProcessImages_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                ProcessFiles();
            }
            );
        }

        private void ProcessFiles()
        {
            ParallelOptions pOpt = new ParallelOptions();
            pOpt.CancellationToken = cancelToken.Token;
            pOpt.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            string[] files = Directory.GetFiles(@"G:\naynish\Pro C# 2010 and the .NET 4 Platform\MultithreadedAndParallelProgramming\DataParallelismWithForEach\Resources\Images", "*.jpg",
                             SearchOption.AllDirectories);
            Directory.CreateDirectory(@"G:\naynish\Pro C# 2010 and the .NET 4 Platform\MultithreadedAndParallelProgramming\DataParallelismWithForEach\ModifiedPictures");

            //foreach (string currentFile in files)
            //{
            //    string filename = Path.GetFileName(currentFile);
            //    using (Bitmap bitmap = new Bitmap(currentFile))
            //    {
            //        Thread.Sleep(4000);
            //        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //        bitmap.Save(Path.Combine(@"G:\naynish\Pro C# 2010 and the .NET 4 Platform\MultithreadedAndParallelProgramming\DataParallelismWithForEach\ModifiedPictures", filename));
            //        this.Text = string.Format("Processing {0} on thread {1}", filename,
            //        Thread.CurrentThread.ManagedThreadId);
            //    }
            //}

            try
            {
                Parallel.ForEach(files, pOpt, currentFile =>
                {
                    pOpt.CancellationToken.ThrowIfCancellationRequested();
                    string filename = Path.GetFileName(currentFile);
                    using (Bitmap bitmap = new Bitmap(currentFile))
                    {
                        Thread.Sleep(4000);
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(@"G:\naynish\Pro C# 2010 and the .NET 4 Platform\MultithreadedAndParallelProgramming\DataParallelismWithForEach\ModifiedPictures", filename));
                        //this.Text = string.Format("Processing {0} on thread {1}", filename,
                        //Thread.CurrentThread.ManagedThreadId);
                    }
                }
                );
            }
            catch(OperationCanceledException e)
            {
                //this.Text = e.Message;
                MessageBox.Show("Cancelled: {0}", e.Message);
            }

            //this.Text = "completed";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}
