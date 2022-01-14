using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguageEnviroment
{
    public class Commands
    {
        private Canvas CanvassInstance;
        private RichTextBox commandLine;

        /// <summary>
        /// This method is where the canvas instance and the command line is initiated to take commands and draw on to the outputwindow
        /// </summary>
        /// <param name="CanvasInstance"></param>
        /// <param name="CommandLine"></param>
        public Commands(Canvas CanvasInstance, RichTextBox CommandLine)
        {
            CanvassInstance = CanvasInstance;
            commandLine = CommandLine;
        }

        /// <summary>
        /// This method is where commands from the commandline are processed to go through exception handling
        /// Also if the command matches an argument the relevant method is called
        /// </summary>
        /// <param name="CanvasInstance"></param>
        /// <param name="Command"></param>
        public void ProcessCommand(Canvas CanvasInstance, String Command)
        {
                String[] CommandString = Command.Split(' ');
            
            switch (CommandString[0])
            {
                case "drawto":DrawTo(CommandString);
                    break;

                case "moveto": MoveTo(CommandString);
                    break;

                case "square":CanvassInstance.DrawSquare(25);
                    break;

                case "rect": DrawRect(CommandString);
                    break;

                case "circle":DrawCircle(CommandString);
                    break;

                case "triangle": DrawTriangle();
                    break;

                case "clear":
                    CanvassInstance.ClearDrawing(); 
                    break;

                case "redgreen":
                    FlashingColorRG();
                    break;

                case "blueyellow":
                    FlashingColorBY();
                    break;

                case "blackwhite":
                    FlashingColorBW();
                    break;

                case "reset": ResetPenPosition();
                    break;

                case "fill": FillShape(CommandString);
                    break;

                case "blackpen":
                    CanvassInstance.drawPen.Color = Color.Black;
                    break;

                case "bluepen":
                    CanvassInstance.drawPen.Color = Color.Blue;
                    break;

                case "redpen":
                    CanvassInstance.drawPen.Color = Color.Red;
                    break;

                // If none of the cases are met then show this error 
                default:
                    MessageBox.Show(CommandString + " is an invalid command. Please try again.");
                    break;
            }
                
        }

        /// <summary>
        /// Check we have been given the x and y
        /// </summary>
        /// <param name="ParamList"></param>
        private void DrawTo(string[] ParamList)
        {
           
            if (ParamList.Length == 3)
            {
                int x, y = 0;

                try
                {
                    x = Int32.Parse(ParamList[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse the parameter " + ParamList[1] + " as an int.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    y = Int32.Parse(ParamList[2]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + ParamList[2] + " as an int.");
                    commandLine.Text = "";
                    return;
                }

                CanvassInstance.DrawTo(x, y);
            }
            else
            {
                MessageBox.Show("Not enough parameters given for DrawTo, please use format of DrawTo 100,200");
                commandLine.Text = "";
            }
        }

        /// <summary>
        /// Check we have been given the x and y parameters
        /// </summary>
        /// <param name="CommandString"></param>
        private void MoveTo(string[] CommandString)
        {
            
            if (CommandString.Length == 3)
            {
                int x, y = 0;

                try
                {
                    x = Int32.Parse(CommandString[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + CommandString[1] + " as an int.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    y = Int32.Parse(CommandString[2]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + CommandString[2] + " as an int.");
                    commandLine.Text = "";
                    return;
                }

                CanvassInstance.MoveTo(x, y);
            }
            else
            {
                MessageBox.Show("Not enough parameters given for MoveTo, please use format of MoveTo 100,200");
                commandLine.Text = "";
            }
        }
        /// <summary>
        /// Check we have been given the x and y parameters
        /// </summary>
        /// <param name="ParamList"></param>
        private void DrawRect(string[] ParamList)
        {
            
            if (ParamList.Length == 3)
            {
                int x, y = 0;

                try
                {
                    x = Int32.Parse(ParamList[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + ParamList[1] + " as an int.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    y = Int32.Parse(ParamList[2]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + ParamList[2] + " as an int.");
                    commandLine.Text = "";
                    return;
                }

                CanvassInstance.DrawRectangle(x, y);
            }
            else
            {
                MessageBox.Show("Not enough parameters given for Rect, please use format of Rect 100,200");
                commandLine.Text = "";
            }
        }
        /// <summary>
        /// Check we have been given the x and y parameters
        /// </summary>
        /// <param name="ParamList"></param>
        private void DrawCircle(string[] ParamList)
        {
            
            if (ParamList.Length == 2)
            {
                int r = 0;

                try
                {
                    r = Int32.Parse(ParamList[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + ParamList[1] + " as an int.");
                    commandLine.Text = "";
                    return;
                }



                CanvassInstance.DrawCircle(r);
            }
            else
            {
                MessageBox.Show("Not enough parameters given for Circle, please use format of circle 100");
                commandLine.Text = "";
            }
        }
        /// <summary>
        /// Create the points that define a triangle.
        /// </summary>
        private void DrawTriangle()
        {
            
            PointF point1 = new PointF(25.0f+CanvassInstance.xPosition-25, 0.0f + CanvassInstance.yPosition - 25);
            PointF point2 = new PointF(50.0F + CanvassInstance.xPosition-25, 50.0F + CanvassInstance.yPosition- 25);
            PointF point3 = new PointF(0 +CanvassInstance.xPosition- 25, 50.0f +CanvassInstance.yPosition- 25);

            PointF[] trianglePoints =
            {
                    point1,
                    point2,
                    point3,
                     };

            CanvassInstance.DrawTriangle(trianglePoints);
        }

        /// <summary>
        /// This method is used to reset the pen position on the outputwindow 
        /// </summary>
        private void ResetPenPosition()
        {
            CanvassInstance.MoveTo(0, 0);
        }

        /// <summary>
        /// This method is called to set the flashingset as true to start flashing colors
        /// </summary>
        private void FlashingColorRG()
        {
            CanvassInstance.flashingSetRG = true;
        }

        /// <summary>
        /// This method is called to set the flashingset as true to start flashing colors
        /// </summary>
        private void FlashingColorBY()
        {
            CanvassInstance.flashingSetBY = true;
        }

        /// <summary>
        /// This method is called to set the flashingset as true to start flashing colors
        /// </summary>
        private void FlashingColorBW()
        {
            CanvassInstance.flashingSetBW = true;
        }

        /// <summary>
        /// This method is used to fill shapes with the colors the user has defined 
        /// </summary>
        /// <param name="ParamList"></param>
        private void FillShape(string [] ParamList)
        {
            CanvassInstance.FillShape();

            if (ParamList.Length == 2)
            {
                string c = ParamList[1];

                switch (c)
                {
                    case "black":
                        CanvassInstance.solidBrush.Color = Color.Black;
                        break;

                    case "blue":
                        CanvassInstance.solidBrush.Color = Color.Blue;
                        break;

                    case "red":
                        CanvassInstance.solidBrush.Color = Color.Red;
                        break;


                }
            }
            else
            {
                MessageBox.Show("Not enough parameters given for fill shape, please use format of fillshape, black");
                commandLine.Text = "";
            }

        }
    }
}
