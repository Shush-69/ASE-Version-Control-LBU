using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ProgrammingLanguageEnviroment
{
    /// <summary>
    /// This class is where the outputwindow is initated to draw using Graphics 
    /// </summary>
    public class Canvas
    {
        Graphics g;

        public Pen drawPen;

        public SolidBrush solidBrush;

        public bool flashing, flashingSet, flashingSetRG, flashingSetBY, flashingSetBW, cycle;

        public bool fill = false;

        public int xPosition, yPosition;

        public int penSizeX = 0, penSizeY = 0;
        int canvasSizeX = 0, canvasSizeY = 0;
        PictureBox pictureBox;



        /// <summary>
        /// This method initiates the output window to draw different shapes 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pictureBox"></param>
        public Canvas(Graphics g, PictureBox pictureBox)
        {
            this.g = g;
            xPosition = yPosition = 0;
            drawPen = new Pen(Color.Black, 1);
            flashing = true;
            this.pictureBox = pictureBox;


            solidBrush = new SolidBrush(Color.Transparent);


            MoveTo(0, 0);
        }

        /// <summary>
        /// This method is where the shapes actually draw on to the outputwindow
        /// </summary>
        ~Canvas()
        {
            flashing = false;
        }

        /// <summary>
        /// Sets up the initial sizes for the drawing canvas and the pen
        /// </summary>
        public void SetElementsSizes(int newPenSizeX, int newPenSizeY, int newCanvasSizeX, int newCanvasSizeY)
        {
            penSizeX = newPenSizeX;
            penSizeY = newPenSizeY;
            canvasSizeX = newCanvasSizeX;
            canvasSizeY = newCanvasSizeY;
        }





        /// <summary>
        /// Moves the pen's drawing location to specified co-ordinates
        /// </summary>
        public void MoveTo(int targetX, int targetY)
        {
            xPosition = targetX;
            yPosition = targetY;
        }





        /// <summary>
        /// Moves the pen's drawing location to specified co-ordinates
        /// </summary>
        public void DrawTo(int targetX, int targetY)
        {
            //This method is for the Line to flash colors specifically red green
            void callFlashRG()
            {
                flashingLine(targetX, targetY, Color.Red, Color.Green);
            }
            if (flashingSetRG)
            {
                Thread thread = new Thread(callFlashRG);
                thread.Start();
            }

            //This method is for the Line to flash colors specifically blue yellow
            void callFlashBY()
            {
                flashingLine(targetX, targetY, Color.Blue, Color.Yellow);
            }

            if (flashingSetBY)
            {
                Thread thread = new Thread(callFlashBY);
                thread.Start();
            }
            //This method is for the Line to flash colors specifically White Black
            void callFlashBW()
            {
                flashingLine(targetX, targetY, Color.Black, Color.White);
            }

            if (flashingSetBW)
            {
                Thread thread = new Thread(callFlashBW);
                thread.Start();
            }
            // if non of the if statement arguments meet this is used to just draw the Line on the outputwindow 
            else
            {
                g.DrawLine(drawPen, xPosition, yPosition, targetX, targetY);//draw the line using a pen instance
                xPosition = targetX;
                yPosition = targetY;
            }
        }

        /// <summary>
        /// This Thread is called to initiate the flashing colors on the line
        /// </summary>
        /// <param name="targetX"></param>
        /// <param name="targetY"></param>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        public void flashingLine(int targetX, int targetY, Color color1, Color color2)
        {
            Pen DrawPen = new Pen (color2);
            while (flashing)
            {
                g.DrawLine(drawPen, xPosition, yPosition, targetX, targetY); ;//Draw shape with a Pen instance 
                xPosition = targetX;
                yPosition = targetY;
                refreshSafe();
                Thread.Sleep(500);
                drawPen.Color = color1;
                g.DrawLine(drawPen, xPosition, yPosition, targetX, targetY);//Draw shape# with a Pen instance 
                xPosition = targetX;
                yPosition = targetY;
                refreshSafe();
                Thread.Sleep(500);
                drawPen.Color = color2;
            }
        }



        /// <summary>
        /// The drawsquare method is called to draw a square on the output window
        /// </summary>
        /// <param name="width"></param>
        public void DrawSquare(int width)
        {
            
                //This method is for the Square to flash colors specifically red green
                void callFlashRG()
                {
                    flashingSquare(width, Color.Red, Color.Green);
                }
                if (flashingSetRG)
                {
                    Thread thread = new Thread(callFlashRG);
                    thread.Start();
                }

                //This method is for the Square to flash colors specifically blue yellow
                void callFlashBY()
                {
                    flashingSquare(width, Color.Blue, Color.Yellow);
                }

                if (flashingSetBY)
                {
                    Thread thread = new Thread(callFlashBY);
                    thread.Start();
                }
            //This method is for the Square to flash colors specifically White Black
            void callFlashBW()
                {
                    flashingSquare(width, Color.Black, Color.White);
                }

                if (flashingSetBW)
                {
                    Thread thread = new Thread(callFlashBW);
                    thread.Start();
                }
            // if non of the if statement arguments meet this is used to just draw the Square on the outputwindow 
            else
            {
                    g.DrawRectangle(drawPen, xPosition, yPosition, xPosition + width, yPosition + width); //Draw shape using a pen instance
                    g.FillRectangle(solidBrush, xPosition, yPosition, xPosition + width, yPosition + width); // Draw shape and fill with a solid brush instance
                }
        }

        /// <summary>
        /// This Thread is called to initiate the flashing colors on the Square
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        public void flashingSquare(int width, Color color1, Color color2)
        {
            SolidBrush brush = new SolidBrush(color2);
            while (flashing)
            {
                g.FillRectangle(brush, xPosition, yPosition, xPosition + width, yPosition + width);//Draw shape and fill with a solid brush instance 
                refreshSafe();
                Thread.Sleep(500);
                brush.Color = color1;
                g.FillRectangle(brush, xPosition, yPosition, xPosition + width, yPosition + width);//Draw shape and fill with a solid brush instance 
                refreshSafe();
                Thread.Sleep(500);
                brush.Color = color2;
            }
        }








        /// <summary>
        /// Draw rectangle method is used to draw a rectangle on the output window
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawRectangle(int width, int height)
        { 
            //This method is for the Rectangle to flash colors specifically red green
            void callFlashRG()
            {
                flashingRectangle(width, height, Color.Red, Color.Green);
            }
            if (flashingSetRG)
            {
                Thread thread = new Thread(callFlashRG);
                thread.Start();
            }

            //This method is for the Rectangle to flash colors specifically blue yellow
            void callFlashBY()
            {
                flashingRectangle(width, height, Color.Blue, Color.Yellow);
            }

            if (flashingSetBY)
            {
                Thread thread = new Thread(callFlashBY);
                thread.Start();
            }
            //This method is for the Rectangle to flash colors specifically White Black
            void callFlashBW()
            {
                flashingRectangle(width, height, Color.Black, Color.White);
            }

            if (flashingSetBW)
            {
                Thread thread = new Thread(callFlashBW);
                thread.Start();
            }
            // if non of the if statement arguments meet this is used to just draw the Rectangle on the outputwindow 
            else
            {
                g.DrawRectangle(drawPen, xPosition, yPosition, xPosition + width, yPosition + height);//Draw shape using a pen instance
                g.FillRectangle(solidBrush, xPosition, yPosition, xPosition + width, yPosition + height);//Draw shape and fill with a solid brush instance 
            }

        }
        /// <summary>
        /// This Thread is called to initiate the flashing colors on the Rectangle
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        public void flashingRectangle(int width, int height, Color color1, Color color2)
        {
            SolidBrush brush = new SolidBrush(color2);
            while (flashing)
            {
                g.FillRectangle(brush, xPosition, yPosition, xPosition + width, yPosition + height);//Draw shape and fill with a solid brush instance 
                refreshSafe();
                Thread.Sleep(500);
                brush.Color = color1;
                g.FillRectangle(brush, xPosition, yPosition, xPosition + width, yPosition + height);//Draw shape and fill with a solid brush instance 
                refreshSafe();
                Thread.Sleep(500);
                brush.Color = color2;
            }
        }









        /// <summary>
        /// This method is called to draw the triangle on our output window
        /// </summary>
        /// <param name="pointsToDraw"></param>
        public void DrawTriangle(PointF[] pointsToDraw)
        {
            //This method is for the Triangle to flash colors specifically red green
            void callFlashRG()
            {
                flashingTriangle(pointsToDraw, Color.Red, Color.Green);
            }
            if (flashingSetRG)
            {
                Thread thread = new Thread(callFlashRG);
                thread.Start();
            }

            //This method is for the triangle to flash colors specifically blue yellow
            void callFlashBY()
            {
                flashingTriangle(pointsToDraw, Color.Blue, Color.Yellow);
            }

            if (flashingSetBY)
            {
                Thread thread = new Thread(callFlashBY);
                thread.Start();
            }
            //This method is for the Triangle to flash colors specifically White Black
            void callFlashBW()
            {
                flashingTriangle(pointsToDraw, Color.Black, Color.White);
            }

            if (flashingSetBW)
            {
                Thread thread = new Thread(callFlashBW);
                thread.Start();
            }
            // if non of the if statement arguments meet this is used to just draw the Triangle on the outputwindow 
            else
            {
                g.DrawPolygon(drawPen, pointsToDraw);//Draw shape using a pen instance 
                g.FillPolygon(solidBrush, pointsToDraw);//Draw shape and fill with a solid brush instance 
            }
        }

        /// <summary>
        /// This Thread is called to initiate the flashing colors on the triangle
        /// </summary>
        /// <param name="pointsToDraw"></param>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        public void flashingTriangle(PointF[] pointsToDraw, Color color1, Color color2)
        {
            SolidBrush brush = new SolidBrush(color2);
            while (flashing)
            {
                g.FillPolygon(brush, pointsToDraw);//Draw shape and fill with a solid brush instance 
                refreshSafe();
                Thread.Sleep(500);
                brush.Color = color1;
                g.FillPolygon(brush, pointsToDraw);//Draw shape and fill with a solid brush instance 
                refreshSafe();
                Thread.Sleep(500);
                brush.Color = color2;
            }
        }







        /// <summary>
        /// This method is called to draw a circle on our output window
        /// </summary>
        /// <param name="radius"></param>
        public void DrawCircle(float radius) {

            //This method is for the circle to flash colors specifically red green
            void callFlashRG()
            {
                flashingCircle(radius, xPosition, yPosition, Color.Red, Color.Green);
            }
            if (flashingSetRG)
            {
                Thread thread = new Thread(callFlashRG);
                thread.Start();
            }

            //This method is for the circle to flash colors specifically blue yellow
            void callFlashBY()
            {
                flashingCircle(radius, xPosition, yPosition, Color.Blue, Color.Yellow);
            }
           
            if (flashingSetBY)
            {
                Thread thread = new Thread(callFlashBY);
                thread.Start();
            }
            //This method is for the circle to flash colors specifically White Black
            void callFlashBW()
            {
                flashingCircle(radius, xPosition, yPosition, Color.Black, Color.White);
            }

            if (flashingSetBW)
            {
                Thread thread = new Thread(callFlashBW);
                thread.Start();
            }
            // if non of the if statement arguments meet this is used to just draw the circle on the outputwindow 
            else
            {
                g.DrawEllipse(drawPen, xPosition - radius, yPosition - radius, radius * 2, radius * 2);
                g.FillEllipse(solidBrush, xPosition - radius, yPosition - radius, radius * 2, radius * 2);
            }
        }
        /// <summary>
        /// This is the main thread used to start the flashing colors 
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="color1"></param>
        /// <param name="color2"></param>
        public void flashingCircle(float radius, int xPos, int yPos, Color color1, Color color2)
        {
            SolidBrush brush = new SolidBrush(color2);
            while (flashing)
            {
                g.FillEllipse(brush, xPos - radius, yPos - radius, radius * 2, radius * 2);
                refreshSafe();
                Thread.Sleep(500);
                brush.Color = color1;
                g.FillEllipse(brush, xPos - radius, yPos - radius, radius * 2, radius * 2);
                refreshSafe();
                Thread.Sleep(500);
                brush.Color = color2;
            }
        }







        /// <summary>
        /// Refresh method is used to esnure the flashing color threads are refreshing and changing colors 
        /// </summary>
        public void refreshSafe()
        {
            if (pictureBox.InvokeRequired)
            {
                Action safeRefesh = delegate { refreshSafe(); };
                pictureBox.Invoke(safeRefesh);
            }
            else
            {
                pictureBox.Refresh();
            }
        }
    




/// <summary>
/// Clear drawing method is called to clear the output window of any drawings
/// </summary>
    public void ClearDrawing()
        {
            g.Clear(Color.White);
        }





        /// <summary>
        /// Reset method is called to reset the penposition on the output window 
        /// </summary>
        public void ResetPenPosition()
        {
            MoveTo(50, 50);
        }





        /// <summary>
        /// Fill shape method is called to fill any shape on the output window
        /// </summary>
        public void FillShape()
        {
            fill = !fill;
        }



    }
}
