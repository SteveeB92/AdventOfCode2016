using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        private const string PATH = @"..\..\Day3.txt";
        [TestMethod()]
        public void amountOfPossibleTrianglesPart1Test()
        {
            //Just so not broken anything when refactoring
            Assert.AreEqual(983, Program.amountOfPossibleTrianglesPart1(PATH));
        }

        [TestMethod()]
        public void amountOfPossibleTrianglesPart2Test()
        {
            Assert.AreEqual(1836, Program.amountOfPossibleTrianglesPart2(PATH));
        }

        [TestMethod()]
        public void removeExcessSpacesTest()
        {
            string exampleStringWithSpaces = "    4   21  894";
            Assert.AreEqual("4 21 894", Program.removeExcessSpaces(exampleStringWithSpaces));
        }

        [TestMethod()]
        public void isPossibleTriangleTest()
        {
            // Obvious fail -- 5 + 10 < 25
            string firstSide = "5";
            string secondSide = "10";
            string thirdSide = "25";
            Assert.AreEqual(false, Program.isPossibleTriangle(firstSide, secondSide, thirdSide));

            // Obvious pass -- 15 + 20 > 25
            firstSide = "15";
            secondSide = "20";
            thirdSide = "25";
            Assert.AreEqual(true, Program.isPossibleTriangle(firstSide, secondSide, thirdSide));

            // Different order possible triangle 
            firstSide = "25";
            secondSide = "15";
            thirdSide = "20";
            Assert.AreEqual(true, Program.isPossibleTriangle(firstSide, secondSide, thirdSide));
        }

        [TestMethod()]
        public void findLengthOfTwoSmallestSidesTest()
        {
            int firstSide = 5;
            int secondSide = 10;
            int thirdSide = 16;
            Assert.AreEqual(15, Program.findLengthOfTwoSmallestSides(firstSide, secondSide, thirdSide));

            //Different order
            firstSide = 16;
            secondSide = 10;
            thirdSide = 5;
            Assert.AreEqual(15, Program.findLengthOfTwoSmallestSides(firstSide, secondSide, thirdSide));
        }

        [TestMethod()]
        public void findLargestSideLengthTest()
        {
            int firstSide = 5;
            int secondSide = 10;
            int thirdSide = 16;
            Assert.AreEqual(16, Program.findLargestSideLength(firstSide, secondSide, thirdSide));

            //Different order
            firstSide = 16;
            secondSide = 10;
            thirdSide = 5;
            Assert.AreEqual(16, Program.findLargestSideLength(firstSide, secondSide, thirdSide));
        }
    }
}