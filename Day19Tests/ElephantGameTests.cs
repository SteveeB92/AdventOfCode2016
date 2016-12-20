using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19.Tests
{
    [TestClass()]
    public class ElephantGameTests
    {
        [TestMethod()]
        public void FindWinnerTest()
        {
            ElephantGame game = new ElephantGame(5);
            int position = game._winningElf._position;

            Assert.AreEqual(3, position);
        }
    }
}