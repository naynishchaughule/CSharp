using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExportDataToOfficeApp
{
    public partial class Form1 : Form
    {
        List<string> employeeNames = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            employeeNames = new List<string>
            {
                "Naynish P. Chaughule",
                "Tripti Panjabi",
                "Malvika Santos Panjabi"
            };
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            dataGridCars.DataSource = null;
            dataGridCars.DataSource = employeeNames;
        }

        private void add_Click(object sender, EventArgs e)
        {
           
        }

        private void export_Click(object sender, EventArgs e)
        {
            // Load up Excel, then make a new empty workbook.
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            excelApp.Workbooks.Add();
            // This example uses a single workSheet.
            Excel._Worksheet workSheet = excelApp.ActiveSheet;
            // Establish column headings in cells.
            workSheet.Cells[1, "A"] = "Employee Names";


            int row = 1;
            foreach (string c in employeeNames)
            {
                row++;
                workSheet.Cells[row, "A"] = c.ToString();
            }
            workSheet.Range["A1"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormat3DEffects1);
            workSheet.SaveAs(string.Format(@"{0}\Inventory.xlsx", Environment.CurrentDirectory));
            excelApp.Quit();
            MessageBox.Show("The Inventory.xslx file has been saved to your app folder",
            "Export complete!");
        }
    }
}
