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
        public Commands CommandLines;
        

        public TestCommands(Canvas CanvasInstance, RichTextBox CommandLine)
        {
            CanvassInstance = CanvasInstance;
            commandLine = CommandLine;
            
        }

    }
        [TestClass]
        public class UnitTest1
        {

        /// <summary>
        /// This test i used to check wheather the Circle class is giving the correct output.
        /// </summary>

        //A cricle class is defined to calculate the numbers.
        [TestMethod]
        public void DrawCricleTest()
        {
           
           Canvas.Draw

             //Expected results and chcking are appended.
           Assert.AreEqual(-25, circleTest.xPosition);
         Assert.AreEqual(-25, circleTest.yPosition);
           Assert.AreEqual(50, circleTest.rad);

        }
        }
   
}
