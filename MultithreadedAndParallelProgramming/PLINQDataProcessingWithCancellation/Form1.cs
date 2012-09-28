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

namespace PLINQDataProcessingWithCancellation
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

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(new Action(Action1));
        }

        private void Action1()
        {
            ProcessIntData();
        }

        private static void ProcessIntData()
        {
            int[] source = Enumerable.Range(1, 10000000).ToArray();
            //int[] modThreeIsZero = (from num in source
            //                        where num % 3 == 0
            //                        orderby num descending
            //                        select num).ToArray();

            int[] modThreeIsZero = (from num in source.AsParallel().WithCancellation(cancelToken.Token)
                                    where num % 3 == 0
                                    orderby num descending
                                    select num).ToArray();
            MessageBox.Show(string.Format("Found {0} numbers that match query!", modThreeIsZero.Count()));            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}
