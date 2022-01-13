using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProgrammingLanguageEnviroment;
using System.Windows;
using System.Windows.Forms;

namespace ProgrammingTestEnvironment
{
    class TestCommands
    {
        private Canvas CanvassInstance;
        private RichTextBox commandLine;

        public TestCommands(Canvas CanvasInstance, RichTextBox CommandLine)
        {
            CanvassInstance = CanvasInstance;
            commandLine = CommandLine;
            
        }

    }
        [TestClass]
        public class UnitTest1
        {


        [TestMethod]
        
        public void TestCircleDraw()
        {
            // A cricle class is defined to calculate the numbers.
            Circle circle = new Circle(0, 0, 50);

            // Expected results and chcking are appended.
            Assert.AreEqual(-25, circle.xPosition);
            Assert.AreEqual(-25, circle.yPosition);
            Assert.AreEqual(50, circle.rad);
        }

        /// <summary>
        /// Testing values for rectangle
        /// </summary>
        [TestMethod]
        public void TestDrawRect()
        {

            Rectangle rectangleTest = new Rectangle(100, 100, 300, 300);

            Assert.AreEqual(100, rectangleTest.xPosition);
            Assert.AreEqual(400, rectangleTest.toX);
            Assert.AreEqual(100, rectangleTest.yPosition);
            Assert.AreEqual(400, rectangleTest.toY);
        }

        /// <summary>
        /// Testing values for rectangle
        /// </summary>
        [TestMethod]
        public void TestDrawTriangle()
        {
            Triangle triangleTest = new Triangle(100, 100, 100);

            Assert.AreEqual(100, triangleTest.length);
            Assert.AreEqual(100, triangleTest.xPos);
            Assert.AreEqual(100, triangleTest.yPos);
        }


    }
        
   
}
