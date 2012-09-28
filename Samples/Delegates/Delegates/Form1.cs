using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delegates
{
    public partial class Form1 : Form
    {
        Class1 c1 = new Class1();
        public delegate bool myCustom();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Methods Executed Successfully:\n";
            myCustom myDelegateInstance = new myCustom(c1.Method1);
            myDelegateInstance += c1.Method2;            
            foreach (Delegate item in myDelegateInstance.GetInvocationList())
	        {                
                if(((myCustom)item).Invoke())
                {
                    //MessageBox.Show(item.Method.ToString());
                    progressBar1.Maximum = 2;
                    progressBar1.Value += 1;
                    label1.Text += "\n" + item.Method.Name + "\n";
                }
	        }             
        }
    }
}
