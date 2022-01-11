using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguageEnviroment
{
    public class Canvas
    {


        Graphics g;

        public Pen drawPen;

        public SolidBrush solidBrush;

        public bool fill = false;

        public int xPosition, yPosition;

        public int penSizeX = 0, penSizeY = 0;
        int canvasSizeX = 0, canvasSizeY = 0;

        /// <summary>
        /// initiating the canvass instance
        /// </summary>
        /// <param name="g"></param>
        public Canvas(Graphics g)
        {
            this.g = g;
            xPosition = yPosition = 0;
            drawPen = new Pen(Color.Black, 1);


            solidBrush = new SolidBrush(Color.Transparent);
           

            MoveTo(0, 0);
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
        /// Drawing to the specified co-ordinates
        /// </summary>
        public void DrawTo(int targetX, int targetY)
        {
            g.DrawLine(drawPen, xPosition, yPosition, targetX, targetY);//draw the line
            xPosition = targetX;
            yPosition = targetY;
        }

        /// <summary>
        /// Drawing a square to the specified co-ordinates and size
        /// </summary>
        /// <param name="width"></param>
        public void DrawSquare(int width)
        {
            g.DrawRectangle(drawPen, xPosition, yPosition, xPosition + width, yPosition + width);
            g.FillRectangle(solidBrush, xPosition, yPosition, xPosition + width, yPosition + width);
        }
        /// <summary>
        /// Drawing a rectangle to the specified co-ordinates and size
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawRectangle(int width, int height)
        {
            g.DrawRectangle(drawPen, xPosition, yPosition, xPosition + width, yPosition + height);
            g.FillRectangle(solidBrush, xPosition, yPosition, xPosition + width, yPosition + height);
        }

        /// <summary>
        /// Drawing a traingle to the specified co-ordinates and size 
        /// </summary>
        /// <param name="pointsToDraw"></param>
        public void DrawTriangle(PointF[] pointsToDraw)
        {
            g.DrawPolygon(drawPen, pointsToDraw);
            g.FillPolygon(solidBrush, pointsToDraw);
        }

        /// <summary>
        /// Drawing a circle to the specified co-ordinates and radius 
        /// </summary>
        /// <param name="radius"></param>
        public void DrawCircle(float radius)
        {
        g.DrawEllipse(drawPen, xPosition - radius, yPosition - radius, radius*2,radius*2);
        g.FillEllipse(solidBrush, xPosition - radius, yPosition - radius, radius * 2, radius * 2);

        }

        /// <summary>
        /// Clears the canvass to a clean page 
        /// </summary>
        public void ClearDrawing()
        {
            g.Clear(Color.White);
        }

        /// <summary>
        /// Resets the Pen Poisiton to the original position
        /// </summary>
        public void ResetPenPosition()
        {
            MoveTo(50, 50);
        }

        /// <summary>
        /// Fills the drawn shape with selected colour
        /// </summary>
        public void FillShape()
        {
            fill = !fill;
        }



    }
}
