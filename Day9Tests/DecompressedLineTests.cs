using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9.Tests
{
    [TestClass()]
    public class DecompressedLineTests
    {

        [TestMethod()]
        public void ParseLineTest()
        {
            Dictionary<string, int> testDataDictionary = new Dictionary<string, int>();
            testDataDictionary.Add("ADVENT", 6);
            testDataDictionary.Add("A(1x5)BC", 7);
            testDataDictionary.Add("(3x3)XYZ", 9);
            testDataDictionary.Add("A(2x2)BCD(2x2)EFG", 11);
            testDataDictionary.Add("(6x1)(1x3)A", 6);
            testDataDictionary.Add("X(8x2)(3x3)ABCY", 18);

            foreach(KeyValuePair<string, int> testData in testDataDictionary)
            {
                DecompressedLine decompressedLine = new DecompressedLine(testData.Key, true);
                Assert.AreEqual(testData.Value, decompressedLine.decompressedLine.Length);
            }
        }
        
        [TestMethod()]
        public void ParseLineTestPart2()
        {
            Dictionary<string, int> testDataDictionary = new Dictionary<string, int>();
            testDataDictionary.Add("ADVENT", 6);
            testDataDictionary.Add("(3x3)XYZ", 9);
            testDataDictionary.Add("X(8x2)(3x3)ABCY", 20);
            testDataDictionary.Add("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN", 445);
            testDataDictionary.Add("(27x12)(20x12)(13x14)(7x10)(1x12)A", 241920);

            foreach (KeyValuePair<string, int> testData in testDataDictionary)
            {
                DecompressedLine decompressedLine = new DecompressedLine(testData.Key, false);
                Assert.AreEqual(testData.Value, decompressedLine.part2Length);
            }
        }

        [TestMethod()]
        public void TryParseNextMarkerTest()
        {
            DecompressedLine decompressLine = new DecompressedLine(string.Empty, true);
            Marker marker;
            decompressLine.TryParseNextMarker("A(1x5)BC", out marker);
            Assert.AreEqual(1, marker.amountOfCharsToRepeat);
            Assert.AreEqual(5, marker.repeatAmount);
            Assert.AreEqual(true, marker.validMarker);
            Assert.AreEqual(1, marker.indexOfMarker);
            Assert.AreEqual(5, marker.length);
        }
    }
}