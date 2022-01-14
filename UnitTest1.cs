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

        public Commands Commander;
        private Canvas CanvassInstance;

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

        /// <summary>
        /// Testing the values for the draw square method 
        /// </summary>
        [TestMethod]
        public void TestDrawSquare()
        {
            Square squareTest = new Square(50, 50, 25, 25);

            Assert.AreEqual(50, squareTest.xPosition);
            Assert.AreEqual(75, squareTest.toX);
            Assert.AreEqual(50, squareTest.yPosition);
            Assert.AreEqual(75, squareTest.toY);
        }

        /// <summary>
        /// testing the values for the draw to method 
        /// </summary>
        [TestMethod]
        public void TestDraw()
        {
            Drawto drawToTest = new Drawto(25, 50, 25, 50);

            Assert.AreEqual(25, drawToTest.xPosition);
            Assert.AreEqual(50, drawToTest.targetX);
            Assert.AreEqual(50, drawToTest.yPosition);
            Assert.AreEqual(0, drawToTest.targetY);
        }


        //Part 2 tests 



        /// <summary>
        /// Tests for invalid commands being parsed to the Commander method
        /// </summary>
       [TestMethod]
        [ExpectedException(typeof(MessageBox)," is an invalid command. Please try again.")]
        public void TestinvalidCommandException()
        {
            Commander.ProcessCommand(CanvassInstance, "squre");
        }

        /// <summary>
        /// Tests for not enough parameters given for the circle method 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(MessageBox),"Not enough parameters given for Circle, please use format of circle 100")]
        public void TestinvalidParamCircleException()
        {
            Commander.ProcessCommand(CanvassInstance, "circle fifty");
        }

        /// <summary>
        /// Tests for not enough parameters given for the moveto method
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(MessageBox), "Not enough parameters given for MoveTo, please use format of MoveTo 100,200")]
        public void TestinvalidParamSquareException()
        {
            Commander.ProcessCommand(CanvassInstance, "Moveto");
        }

    }


}
