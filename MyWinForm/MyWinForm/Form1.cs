using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using AppHooks;

namespace MyWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadExternalModule(ofd.FileName);
            }
        }

        private void LoadExternalModule(string path)
        {
            AssemblyName asmName = new AssemblyName();
            asmName.Name = path;
            Assembly asm = Assembly.LoadFrom(asmName.ToString());
            Type[] arrr = asm.GetTypes();
            foreach (Type item in arrr)
            {
                if (item.IsClass && item.GetInterface("MyApplicationInterface")!= null
                    && item.GetCustomAttributes(typeof(AppHooks.MyCustomAttributes), false) != null)
                {
                    MyApplicationInterface mai = (MyApplicationInterface)Activator.CreateInstance(item);
                    mai.DisplayMessage();
                    listBox1.Items.Add(item.FullName);
                    LoadAttributes(item);
                }            
            }            
        }

        private void LoadAttributes(Type t)
        {
            Object[] arr = t.GetCustomAttributes(typeof(MyCustomAttributes), false);
            foreach (MyCustomAttributes item in arr)
            {
                listBox1.Items.Add(item.Url);
            }
        }
    }
}
