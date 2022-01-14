using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnviroment
{
    /// <summary>
    /// This is where the circle shape is initated 
    /// </summary>
    public class Circle

    {

        public int xPosition;
        public int yPosition;
        public int rad;

        /// <summary>
        /// This is where the values are calculated to be able to draw a circle on the output window
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        public Circle(int x, int y, int radius)
        {
            int circlePosx = x - (radius / 2);
            int circlePosy = y - (radius / 2);

            xPosition = circlePosx;
            yPosition = circlePosy;
            this.rad = radius;

        }
    }
        
    
}

