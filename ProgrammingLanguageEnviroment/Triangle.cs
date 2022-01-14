using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnviroment
{
    /// <summary>
    /// this method is used to initate the triangle shape
    /// </summary>
    public class Triangle
    {
        public int length;
        public int xPos;
        public int yPos;

        /// <summary>
        /// This method is where the values are calculated to draw on the triangle 
        /// </summary>
        /// <param name="length"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        public Triangle(int length, int xPos, int yPos)
        {
            this.length = length;
            this.xPos = xPos;
            this.yPos = yPos;

        }

    }
}
    

