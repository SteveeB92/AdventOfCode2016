using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8.Tests
{
    [TestClass()]
    public class ScreenTests
    {

        private const string PATH = @"..\..\EmptyFile.txt";
        [TestMethod()]
        public void ScreenTest()
        {
            Screen screen = new Screen(7, 3, PATH);
            Assert.AreEqual(7, screen.screenDisplay.GetLength(1));
            Assert.AreEqual(3, screen.screenDisplay.GetLength(0));
        }

        [TestMethod()]
        public void ProcessLineTest()
        {
            var testData = new List<Tuple<string, bool[,]>>();

            Screen screen = new Screen(7, 3, PATH);
            string instruction = "rect 3x2";
            bool[,] expectedResult = { { true, true, true, false, false, false, false} ,
                                       { true, true, true, false, false, false, false},
                                       { false, false, false, false, false, false, false} };
            testData.Add(new Tuple<string, bool[,]>(instruction, expectedResult));

            instruction = "rotate column x=1 by 1";
            expectedResult = new bool[,] { { true, false, true, false, false, false, false} ,
                                           { true, true, true, false, false, false, false},
                                           { false, true, false, false, false, false, false} };
            testData.Add(new Tuple<string, bool[,]>(instruction, expectedResult));

            instruction = "rotate row y=0 by 4";
            expectedResult = new bool[,] { { false, false, false, false, true, false, true} ,
                                           { true, true, true, false, false, false, false},
                                           { false, true, false, false, false, false, false} };
            testData.Add(new Tuple<string, bool[,]>(instruction, expectedResult));

            instruction = "rotate column x=1 by 1";
            expectedResult = new bool[,] { { false, true, false, false, true, false, true} ,
                                           { true, false, true, false, false, false, false},
                                           { false, true, false, false, false, false, false} };
            testData.Add(new Tuple<string, bool[,]>(instruction, expectedResult));

            foreach (Tuple<string, bool[,]> entry in testData)
            {
                screen.ProcessLine(entry.Item1);
                bool screensMatch = Compare2DArrays<bool>(entry.Item2, screen.screenDisplay);

                Assert.AreEqual(true, screensMatch);
            }
        }

        [TestMethod()]
        public void ProcessRectangeTestInstruction()
        {
            Screen screen = new Screen(7, 3, PATH);
            RectangleInstruction rectangleInstruction = new RectangleInstruction("rect 4x3");
            bool[,] expectedResult = { { true, true, true, true, false, false, false} ,
                                       { true, true, true, true, false, false, false},
                                       { true, true, true, true, false, false, false} };
            screen.ProcessRectangleInstruction(rectangleInstruction);
            bool screensMatch = Compare2DArrays<bool>(expectedResult, screen.screenDisplay);

            Assert.AreEqual(true, screensMatch);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ProcessRectangeInstructionWidthTest()
        {
            Screen screen = new Screen(7, 3, PATH);
            RectangleInstruction rectangleInstruction = new RectangleInstruction("rect 8x2");
            screen.ProcessRectangleInstruction(rectangleInstruction);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ProcessRectangeInstructionHeightTest()
        {
            Screen screen = new Screen(7, 3, PATH);
            RectangleInstruction rectangleInstruction = new RectangleInstruction("rect 2x4");
            screen.ProcessRectangleInstruction(rectangleInstruction);
        }


        [TestMethod()]
        public void ProcessRotateRowTest()
        {
            Screen screen = new Screen(7, 3, PATH);
            string instruction = "rect 3x2";
            screen.ProcessLine(instruction);

            instruction = "rotate row y=0 by 5";
            RotateRowInstruction rotateRowInstruction = new RotateRowInstruction(instruction, 7);
            
            bool[,] expectedResult = { { true, false, false, false, false, true, true} ,
                                       { true, true, true, false, false, false, false},
                                       { false, false, false, false, false, false, false} };
            screen.ProcessRotateRow(rotateRowInstruction);
            bool screensMatch = Compare2DArrays<bool>(expectedResult, screen.screenDisplay);
            Assert.AreEqual(true, screensMatch);
        }

        [TestMethod()]
        public void ProcessRotateColumnTest()
        {
            Screen screen = new Screen(7, 3, PATH);
            string instruction = "rect 3x2";
            screen.ProcessLine(instruction);

            instruction = "rotate column x=2 by 1";
            RotateColumnInstruction rotateColumnInstruction = new RotateColumnInstruction(instruction, 7);

            bool[,] expectedResult = { { true, true, false, false, false, false, false} ,
                                       { true, true, true, false, false, false, false},
                                       { false, false, true, false, false, false, false} };
            screen.ProcessRotateColumn(rotateColumnInstruction);
            bool screensMatch = Compare2DArrays<bool>(expectedResult, screen.screenDisplay);
            Assert.AreEqual(true, screensMatch);
        }

        [TestMethod()]
        public void ParseAxisAndShiftAmountTest()
        {
            Instructions instruction = new Instructions();
            int axis;
            instruction.ParseAxisAndShiftAmount(" x=2 by 8", out axis, 5);
            Assert.AreEqual(2, axis);
            Assert.AreEqual(3, instruction.shiftAmount);
        }

        [TestMethod()]
        public void AmountOfPixelsTurnedOnTest()
        {
            Screen screen = new Screen(7, 3, PATH);
            string instruction = "rect 3x2";
            screen.ProcessLine(instruction);

            instruction = "rotate column x=1 by 1";
            screen.ProcessLine(instruction);

            instruction = "rotate row y=0 by 4";
            screen.ProcessLine(instruction);

            instruction = "rotate column x=1 by 1";
            screen.ProcessLine(instruction);
            
            instruction = "rect 2x2";
            screen.ProcessLine(instruction);

            Assert.AreEqual(8, screen.AmountOfPixelsTurnedOn());
        }

        private bool Compare2DArrays<t>(t[,] expectedResult, t[,] actual)
        {
            if (expectedResult.Length != actual.Length)
                return false;

            for (int i = 0; i < actual.GetLength(0); i++)
                for (int j = 0; j < actual.GetLength(1); j++)
                    if (!expectedResult[i, j].Equals(actual[i, j]))
                        return false;

            return true;
        }
    }
}