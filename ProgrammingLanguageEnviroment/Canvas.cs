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


        public Canvas(Graphics g)
        {
            this.g = g;
            xPosition = yPosition = 0;
            drawPen = new Pen(Color.Black, 1);


            solidBrush = new SolidBrush(Color.Black);
           

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
        /// Moves the pen's drawing location to specified co-ordinates
        /// </summary>
        public void DrawTo(int targetX, int targetY)
        {
            g.DrawLine(drawPen, xPosition, yPosition, targetX, targetY);//draw the line
            xPosition = targetX;
            yPosition = targetY;
        }

        public void DrawSquare(int width)//add command for this
        {
            g.DrawRectangle(drawPen, xPosition, yPosition, xPosition + width, yPosition + width);
            g.FillRectangle(solidBrush, xPosition, yPosition, xPosition + width, yPosition + width);
        }
        public void DrawRectangle(int width, int height)
        {
            g.DrawRectangle(drawPen, xPosition, yPosition, xPosition + width, yPosition + height);
            g.FillRectangle(solidBrush, xPosition, yPosition, xPosition + width, yPosition + height);


        }

        public void DrawTriangle(PointF[] pointsToDraw)
        {
            g.DrawPolygon(drawPen, pointsToDraw);
            g.FillPolygon(solidBrush, pointsToDraw);
        }

        public void DrawCircle(float radius)
        {
        g.DrawEllipse(drawPen, xPosition - radius, yPosition - radius, radius*2,radius*2);
        g.FillEllipse(solidBrush, xPosition - radius, yPosition - radius, radius * 2, radius * 2);

        }

        public void ClearDrawing()
        {
            g.Clear(Color.White);
        }
        public void ResetPenPosition()
        {
            MoveTo(50, 50);
        }

        public void FillShape()
        {
            fill = !fill;
        }



    }
}
