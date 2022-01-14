using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnviroment
{
    /// <summary>
    /// This class is used to draw the line in the draw to method 
    /// </summary>
    public class Drawto
    {
        public int targetX;
        public int targetY;
        public int xPosition;
        public int yPosition;

        /// <summary>
        /// This method is used to calculate the values to draw the line in the drawto method
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="YPos"></param>
        /// <param name="xTarget"></param>
        /// <param name="yTarget"></param>
        public Drawto (int xPos, int YPos, int xTarget, int yTarget)
        {
            int newXPos = xPos + xTarget;
            int newYPos = YPos + yTarget;

            xPosition = xPos;
            yPosition = YPos;
            this.targetX = xTarget;
            this.targetX = yTarget;
        }
       
    }
}
