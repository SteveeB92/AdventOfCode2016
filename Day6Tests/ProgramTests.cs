using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day6;
using System;
using System.Collections.Generic;

namespace Day6.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        [TestMethod()]
        public void correctedMessagePart1Test()
        {
            //Part 1
            Assert.AreEqual("easter", Program.correctedMessage(@"..\..\Day6Tests.txt", true));
        }

        [TestMethod()]
        public void findCorrectedMessageFromListTest()
        {
            //Part 1
            string[] testData = { "eedadn", "drvtee", "eandsr", "raavrd", "atevrs", "tsrnev", "sdttsa", "rasrtv",
                                  "nssdts", "ntnada", "svetve", "tesnvt", "vntsnd", "vrdear", "dvrsen", "enarar" };
            List<string> list = new List<string>(testData);

            Assert.AreEqual("easter", Program.findCorrectedMessageFromList(list, true));
        }

        [TestMethod()]
        public void findMostOrLeastCommonCharInListForColumnTest()
        {
            string[] testData = { "eedadn", "drvtee", "eandsr", "raavrd", "atevrs", "tsrnev", "sdttsa", "rasrtv",
                                  "nssdts", "ntnada", "svetve", "tesnvt", "vntsnd", "vrdear", "dvrsen", "enarar" };
            List<string> list = new List<string>(testData);

            //Part 1
            Dictionary<int, char> results = new Dictionary<int, char>
            {
                { 0, 'e' }, { 1, 'a' }, { 2, 's' }, { 3, 't' }, { 4, 'e' }, { 5, 'r' }
            };

            for (int column = 0; column < results.Count; column++)
            {
                Assert.AreEqual(results[column], Program.findMostOrLeastCommonCharInListForColumn(list, column, true));
            }

            //Part 2
            results = new Dictionary<int, char>
            {
                { 0, 'a' }, { 1, 'd' }
            };

            for (int column = 0; column < results.Count; column++)
            {
                Assert.AreEqual(results[column], Program.findMostOrLeastCommonCharInListForColumn(list, column, false));
            }
        }
    }
}