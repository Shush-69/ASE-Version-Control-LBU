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

        public Commands(Canvas CanvasInstance, RichTextBox CommandLine)
        {
            CanvassInstance = CanvasInstance;
            commandLine = CommandLine;
        }

        public void ProcessCommand(String CommandString, String ParamLists)
        {
            String[] ParamList = ParamLists.Split(','); 
            switch (CommandString)
            {
                case "drawto":DrawTo(ParamList);
                    break;

                case "moveto": MoveTo(ParamList);
                    break;

                case "square":CanvassInstance.DrawSquare(25);
                    break;

                case "rect": DrawRect(ParamList);
                    break;

                case "circle":DrawCircle(ParamList);
                    break;

                case "triangle": DrawTriangle();
                    break;

                case "clear":
                    CanvassInstance.ClearDrawing(); 
                    break;

                case "pencolour": ChangePenColour(ParamList);
                    break;

                case "reset": ResetPenPosition();
                    break;

                case "fillshape": FillShape(ParamList);
                    break;

                case "flashingcolour": FlashingColor();
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
           
            if (ParamList.Length == 2)
            {
                int x, y = 0;

                try
                {
                    x = Int32.Parse(ParamList[0]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse the parameter " + ParamList[0] + " as an int.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    y = Int32.Parse(ParamList[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + ParamList[1] + " as an int.");
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
        ///  Check we have been given the x and y parameters
        /// </summary>
        /// <param name="ParamList"></param>
        private void MoveTo(string[] ParamList)
        {
            
            if (ParamList.Length == 2)
            {
                int x, y = 0;

                try
                {
                    x = Int32.Parse(ParamList[0]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + ParamList[0] + " as an int.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    y = Int32.Parse(ParamList[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + ParamList[1] + " as an int.");
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
            
            if (ParamList.Length == 2)
            {
                int x, y = 0;

                try
                {
                    x = Int32.Parse(ParamList[0]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + ParamList[0] + " as an int.");
                    commandLine.Text = "";
                    return;
                }

                try
                {
                    y = Int32.Parse(ParamList[1]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + ParamList[1] + " as an int.");
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
            
            if (ParamList.Length == 1)
            {
                int r = 0;

                try
                {
                    r = Int32.Parse(ParamList[0]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to parse parameter " + ParamList[0] + " as an int.");
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
        /// Check we have been given the x and y parameters
        /// </summary>
        /// <param name="ParamList"></param>
        private void ChangePenColour(string[] ParamList)
        {
           
            if (ParamList.Length == 1)
            {
                string c = ParamList[0];

                switch (c)
                {
                    case "black": CanvassInstance.drawPen.Color = Color.Black;
                        break;

                    case "blue": CanvassInstance.drawPen.Color = Color.Blue;
                        break;

                    case "red": CanvassInstance.drawPen.Color = Color.Red;
                        break;


                }
            }
            else
            {
                MessageBox.Show("Not enough parameters given for Circle, please use format of circle 100");
                commandLine.Text = "";
            }
        }
        private void ResetPenPosition()
        {
            CanvassInstance.MoveTo(0, 0);
        }

        private void FlashingColor()
        {

        }

        private void FillShape(string [] ParamList)
        {
            CanvassInstance.FillShape();

            if (ParamList.Length == 1)
            {
                string c = ParamList[0];

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
