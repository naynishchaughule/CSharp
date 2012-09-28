using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonSnappableTypes;
using System.Reflection;

namespace ExtendableApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName.Contains("CommonSnappableTypes"))
                {
                    MessageBox.Show("CommonSnappableTypes has no snap-ins!");
                }
                else if (!LoadExternalModule(dlg.FileName))
                {
                    MessageBox.Show("Nothing implements IAppFunctionality!");
                }
            }
        }

        private bool LoadExternalModule(string path)
        {
            bool foundSnapIn = false;
            Assembly theSnapInAsm = null;

            try
            {
            // Dynamically load the selected assembly.
            theSnapInAsm = Assembly.LoadFrom(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return foundSnapIn;
            }

            var theClassTypes = from t in theSnapInAsm.GetTypes()
                                where t.IsClass && t.GetInterface("IAppFunctionality") != null
                                select t;

            foreach (Type item in theClassTypes)
            {
                foundSnapIn = true;
                IAppFunctionality itfApp = (IAppFunctionality)Activator.CreateInstance(item);
                //IAppFunctionality itfApp = (IAppFunctionality)theSnapInAsm.CreateInstance(item.FullName, true);
                itfApp.DoIt();
                lstLoadedSnapIns.Items.Add(item.FullName);
                DisplayCompanyData(item);
            }
            return foundSnapIn;
        }

        private void DisplayCompanyData(Type t)
        {
            var compInfo = from ci in t.GetCustomAttributes(false)
                           where (ci.GetType() == typeof(CompanyInfoAttribute))
                           select ci;

            foreach (CompanyInfoAttribute c in compInfo)
            {
                MessageBox.Show(c.CompanyUrl, string.Format("More info about {0} can be found at", c.CompanyName));
            }
        }
    }
}
