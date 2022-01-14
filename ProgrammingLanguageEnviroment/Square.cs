using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnviroment
{
    /// <summary>
    /// This class is used to initiate the square shape 
    /// </summary>
    public class Square
    {
        public int xPosition;
        public int yPosition;
        public int toX;
        public int toY;

        /// <summary>
        /// This method is where the values are calculated to draw the square shape 
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
        public Square(int xPos, int yPos, int toX, int toY)
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
