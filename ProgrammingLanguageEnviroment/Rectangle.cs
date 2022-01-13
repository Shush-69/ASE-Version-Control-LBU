using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnviroment
{
    public class Rectangle
    {
        public int xPosition;
        public int yPosition;
        public int toX;
        public int toY;

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

