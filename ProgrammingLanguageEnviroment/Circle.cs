using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnviroment
{

    public class Circle

    {

        public int xPosition;
        public int yPosition;
        public int rad;

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

