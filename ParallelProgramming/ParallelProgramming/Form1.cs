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

namespace ParallelProgramming
{
    public partial class Form1 : Form
    {
        List<int> myList = null;
        ParallelOptions pOpt;
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myList = new List<int>();
            myList.Add(10); myList.Add(20);
            Task.Factory.StartNew(new Action(Action));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pOpt = new ParallelOptions();
            pOpt.CancellationToken = cancelToken.Token;

            Parallel.ForEach(myList, pOpt, new Action<int>(Process));
        }

        private void Process(int x)
        {
            try
            {
                pOpt.CancellationToken.ThrowIfCancellationRequested();
                Thread.Sleep(5000);                
                MessageBox.Show((x * 100).ToString());                
            }
            catch (OperationCanceledException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Action()
        {
            MessageBox.Show("Runs on secondary thread!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}
