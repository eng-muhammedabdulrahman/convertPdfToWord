using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// support pdf to word process
using Spire.Pdf;
// support C# File, IO
using System.IO;
// open executable file at runtime
using System.Diagnostics;
namespace convertPdfToWord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // define the global string variable
        string path = "";
        // Browse Button
        private void openfile(object sender, EventArgs e)
        {
        // create open file dialog object
            OpenFileDialog fd = new OpenFileDialog();
        // set filter option
            fd.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|(*.*)";
        // show the dialog using its instance method and verifiy it using
        // its built-in constant properties
        // it returns the full path of the file, if user selects any pdf file else returns null
            if(fd.ShowDialog()==DialogResult.OK)
            {
        //get the selected file path and save it to global variable path
                path= fd.FileName;
        // assign this selected file path to text box bx1
                bx1.Text = fd.FileName;
        // thats all for this button code 
            }
        }
        // Convert Button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
        // Create an object for PDF Document cless
                PdfDocument obj = new PdfDocument();
        // load the selected pdf file (via open file dialog) to the instance method of the above class
                obj.LoadFromFile(path);
                // start the convert process and save the resultant word document using
                // its instance method called SaveToFile()
                obj.SaveToFile("ConvertW.docx", FileFormat.DOCX);
                // here i ve given the current project path of resultant word file
                // you can give either current path or aboslute path
                // now check whether the new docx will be created or not using Exists() method of file class
                // if the condition below returns true means, the output word document will be ready
                if (File.Exists("ConvertW.docx")==true)
                {
                    // now we need to open the created word document istantly
                    // this is done by using the static method of Process class called Start (path)
                    Process.Start("ConvertW.docx");
                    // now build and run the project....
                }
            }
            catch (Exception ext)
            {
                System.Console.WriteLine(ext.Message);
            }
        }
    }
}
// Now I will show my project folder in my PC
// because resultant word file be saved to current project folder....
// Now I will run...