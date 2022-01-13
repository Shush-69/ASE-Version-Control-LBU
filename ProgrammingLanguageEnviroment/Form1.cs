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

            string InputStringArray = commandLine.Text.Trim().ToLower();
            string[] ParamList = new string[0];

            // Check we have more than one string
            

            if (e.KeyCode == Keys.Enter)
            {
                if (InputStringArray.Length > 1)
                {
                    commandInstance.ProcessCommand(CanvasInstance, InputStringArray);  
                }

                else
                {
                    commandInstance.ProcessCommand(CanvasInstance, InputStringArray);
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
            String ProgramCommands = ProgramWindow.Text.ToLower();
            String[] Commander = ProgramCommands.Split(Environment.NewLine.ToCharArray());
            int Loop = 0;
            List<String> VariableNumber = new List<String>();
            List<String> VariableName = new List<String>();
            String IfOperator = "";
            String IfVariable = "";
            int IF = 0;
            int IfNumber = 0;
            List<String> IfArray = new List<String>();
            int l = 0;


            while (Loop < Commander.Length)
            {
                String[] SingleCommands = Commander[Loop].Split(' ');

                if (SingleCommands[0] == "if")
                {
                    IF = 1;
                    IfVariable = SingleCommands[1];
                    IfOperator = SingleCommands[2];
                    IfNumber = Int32.Parse(SingleCommands[3]);
                    Loop++;

                }
                else if (IF == 1 && SingleCommands[0] != "endif")
                {
                    IfArray.Add(Commander[Loop]);

                    Loop++;
                }

                else if (SingleCommands[0] == "endif")
                {


                    while (IfVariable != VariableName[l])
                    {
                        l++;
                    }
                    System.Windows.Forms.MessageBox.Show(VariableName[l]);
                    if (IfOperator == "==")
                    {
                        if (Int32.Parse(VariableNumber[l]) == IfNumber)
                        {


                            foreach (String item in IfArray)
                            {
                                commandInstance.ProcessCommand(CanvasInstance, item);

                                Refresh();


                            }
                            IF = 0;

                        }
                    }
                    Loop++;
                }
                else if (IF == 0 && (SingleCommands[0] == "redpen" || SingleCommands[0] == "bluepen" || SingleCommands[0] == "greenpen" || SingleCommands[0] == "square" || SingleCommands[0] == "rectangle" || SingleCommands[0] == "circle" || SingleCommands[0] == "triangle" || SingleCommands[0] == "moveto" || SingleCommands[0] == "drawto" || SingleCommands[0] == "fill" || SingleCommands[0] == "clear" || SingleCommands[0] == "reset"))
                {
                    commandInstance.ProcessCommand(CanvasInstance, Commander[Loop]);
                    Loop++;

                    Refresh();
                }
                else if (SingleCommands[1] == "=")
                {
                    VariableNumber.Add(SingleCommands[2]);
                    VariableName.Add(SingleCommands[0]);



                    Loop++;
                }
                else if (SingleCommands[1] == "+")
                {
                    int ifLoop = 0;
                    while (VariableName[ifLoop] != SingleCommands[0])
                    {
                        ifLoop++;
                    }
                    int PreviousValue = Int32.Parse(VariableNumber[ifLoop]);
                    int PlusValue = Int32.Parse(SingleCommands[2]);
                    String NewValue = (PreviousValue + PlusValue).ToString();
                    VariableNumber[ifLoop] = NewValue;

                    Loop++;
                }
                else
                {

                    System.Windows.Forms.MessageBox.Show("No command");
                    // (String line in InputWindow.Lines)
                }

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
