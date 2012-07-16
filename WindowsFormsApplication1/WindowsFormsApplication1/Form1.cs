using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Drawing.Imaging;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Pdf.Devices;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar;
            string dataDir = new Uri(new Uri(exeDir), @"../../Data/").LocalPath;
            Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(dataDir + "//InputFile.pdf");
            for (int pageCount = 1; pageCount <= pdfDocument.Pages.Count; pageCount++)
            {
                using (FileStream imageStream = new FileStream("image" + pageCount + ".png", FileMode.Create))
                {                   
                    Resolution resolution = new Resolution(300);
                    PngDevice pngDevice = new PngDevice(resolution);
                    pngDevice.Process(pdfDocument.Pages[pageCount], imageStream);                    
                    imageStream.Close();
                    MessageBox.Show("png file created in \\bin\\Debug");
                }
            }
        }
    }
}
