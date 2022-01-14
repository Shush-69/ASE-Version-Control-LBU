using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnviroment
{
    /// <summary>
    /// This method is for the rectangle method 
    /// </summary>
    public class Rectangle
    {
        public int xPosition;
        public int yPosition;
        public int toX;
        public int toY;

        /// <summary>
        /// This method is used to calculate and draw the rectangle shape
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
        public Rectangle(int xPos, int yPos, int toX, int toY)
        {
            int newXPos = xPos + toX;
            int newYPos = yPos + toY;

            xPosition = xPos;
            yPosition = yPos;
            this.toX = newXPos;
            this.toY = newYPos;
        }
    }
}

