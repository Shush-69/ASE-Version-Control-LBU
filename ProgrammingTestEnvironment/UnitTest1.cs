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
        public void DrawCricleTest()
        {


            /// <summary>
            /// This test i used to check wheather the Circle class is giving the correct output.
            /// </summary>

            // A cricle class is defined to calculate the numbers.
          // DrawCircle circleTest = new DrawCircle(0, 0, 50);

            // Expected results and chcking are appended.
           // Assert.AreEqual(-25, circleTest.xPosition);
         //  Assert.AreEqual(-25, circleTest.yPosition);
          //  Assert.AreEqual(50, circleTest.rad);

        }
        }
   
}
