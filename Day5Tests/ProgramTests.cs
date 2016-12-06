using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void findPasswordForDoorTestPart1()
        {
            Assert.AreEqual("18f47a30", Program.findPasswordForDoorPart1("abc"));
        }

        [TestMethod()]
        public void findPasswordForDoorTestPart2()
        {
            Assert.AreEqual("05ace8e3", Program.findPasswordForDoorPart2("abc"));
        }

        [TestMethod()]
        public void generateHashTest()
        {
            Assert.AreEqual("00000", Program.generateHash("abc", 3231929).Substring(0, 5));
            Assert.AreEqual("00000", Program.generateHash("abc", 5017308).Substring(0, 5));
            Assert.AreEqual("00000", Program.generateHash("abc", 5278568).Substring(0, 5));
        }
    }
}