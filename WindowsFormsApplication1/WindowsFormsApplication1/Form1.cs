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

        private void button1_Click(object sender, EventArgs e)
        {
            string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar;
            string dataDir = new Uri(new Uri(exeDir), @"../../Data/").LocalPath;
            ConvertImageToPdf(dataDir + "image1.png", dataDir + "Image1 Out.pdf");            
        }

        public static void ConvertImageToPdf(string inputFileName, string outputFileName)
        {
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);
            using (Image image = Image.FromFile(inputFileName))
            {
                int framesCount = image.GetFrameCount(FrameDimension.Page);
                for (int frameIdx = 0; frameIdx < framesCount; frameIdx++)
                {
                    // Insert a section break before each new page, in case of a multi-frame TIFF.
                    if (frameIdx != 0)
                        builder.InsertBreak(BreakType.SectionBreakNewPage);

                    // Select active frame.
                    image.SelectActiveFrame(FrameDimension.Page, frameIdx);

                    // We want the size of the page to be the same as the size of the image.
                    // Convert pixels to points to size the page to the actual image size.
                    PageSetup ps = builder.PageSetup;
                    ps.PageWidth = ConvertUtil.PixelToPoint(image.Width, image.HorizontalResolution);
                    ps.PageHeight = ConvertUtil.PixelToPoint(image.Height, image.VerticalResolution);

                    // Insert the image into the document and position it at the top left corner of the page.
                    builder.InsertImage(
                        image,
                        RelativeHorizontalPosition.Page,
                        0,
                        RelativeVerticalPosition.Page,
                        0,
                        ps.PageWidth,
                        ps.PageHeight,
                        WrapType.None);
                }
            }
            doc.Save(outputFileName);
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
                    //create PNG device with specified attributes
                    //Width, Height, Resolution, Quality
                    //Quality [0-100], 100 is Maximum
                    //create Resolution object
                    Resolution resolution = new Resolution(300);
                    PngDevice pngDevice = new PngDevice(resolution);

                    //convert a particular page and save the image to stream
                    pngDevice.Process(pdfDocument.Pages[pageCount], imageStream);

                    //close stream
                    imageStream.Close();
                    MessageBox.Show("Png file created in \\bin\\Debug");
                }
            }
        }
    }
}
