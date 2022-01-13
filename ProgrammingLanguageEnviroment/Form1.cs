using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace ProgrammingLanguageEnviroment
{
    public partial class Form1 : Form

    {
        //bitmap to draw on is displayed in output window (white box)
        private Bitmap OutputBitmap = new Bitmap(725, 500); //define constance of screen x and y size
        private Canvas CanvasInstance;
        private Commands commandInstance;


        public Form1()
        {
            InitializeComponent();
            CanvasInstance = new Canvas(Graphics.FromImage(OutputBitmap), OutputWindow); //class for handling the drawing, pass the drawing surface to it
            commandInstance = new Commands(CanvasInstance, commandLine);

            CanvasInstance.SetElementsSizes(OutputBitmap.Width, OutputBitmap.Height, OutputWindow.Width, OutputWindow.Height);

            //Output window back ground color 
            OutputWindow.BackColor = Color.White;


            //Output image on to the output window
            OutputWindow.Image = OutputBitmap;
        }


        //when text is changed this happens
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        //the method that is called when the event occurs when the programme is ran
        private void CommandLine_KeyDown(object sender, KeyEventArgs e)//every time they press a key this is called
        {
            //set up this as a process method where i pass the line of commands to the objects

            string[] InputStringArray = commandLine.Text.Trim().ToLower().Split(' ');
            String CommandString = InputStringArray[0];
            string[] ParamList = new string[0];

            // Check we have more than one string
            

            if (e.KeyCode == Keys.Enter)
            {
                if (InputStringArray.Length > 1)
                {
                    commandInstance.ProcessCommand(CommandString, InputStringArray[1]);  
                }

                else
                {
                    commandInstance.ProcessCommand(CommandString, InputStringArray[0]);
                }

                commandLine.Text = "";//clears command line
                OutputWindow.Refresh();
            }       
        }

        public void InputWindow(object sender, EventArgs e)//need to have all commands be printed onto this input window, so that when i type anything into commandline it copies it
        {

        }

        private void outputWindow_Paint(object sender, PaintEventArgs e) //output window paint event(needed for some reason) WHY
        {
            Graphics g = e.Graphics; //get graphics context of form (which is being displayed) 
            

            g.DrawImageUnscaled(OutputBitmap, 0, 0); //puts off screen bitmap on the form
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            String[] ProgramCommand = ProgramWindow.Lines;

            for (int x = 0; x < ProgramCommand.Length; x++)
            {
                String CommandString = ProgramCommand[x];

                String[] Commander = CommandString.Split(null);

                if (Commander.Length > 1)
                {
                    commandInstance.ProcessCommand(Commander[0], Commander[1]);
                }

                else
                {
                    commandInstance.ProcessCommand(Commander[0], Commander[0]);
                }

                commandLine.Text = "";//clears command line
                OutputWindow.Refresh();
                

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            saveFD.FileName = "Save Image";
            saveFD.Filter = "JPEG|*.jpeg";

            if (saveFD.ShowDialog() != DialogResult.Cancel)
            {
                string savePath = saveFD.FileName;

                Bitmap OutputBitmap = new Bitmap(OutputWindow.Image);

                OutputBitmap.Save(savePath, ImageFormat.Jpeg);

                MessageBox.Show("Image Saved");


            }

        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "bmp files (*.jpeg)|*.Jpeg";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                OutputWindow.Image = Image.FromFile(dlg.FileName);
            }
            dlg.Dispose();
        }
        private void openFD_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
