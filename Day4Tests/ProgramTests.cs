using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void sectionIDIfRealTest()
        {
            //is a real room because the most common letters are a (5), b (3), and then a tie between x, y, and z, which are listed alphabetically.
            Assert.AreEqual(123, Program.sectionIDIfReal("aaaaa-bbb-z-y-x-123[abxyz]"));
            //is a real room because although the letters are all tied (1 of each), the first five are listed alphabetically.
            Assert.AreEqual(987, Program.sectionIDIfReal("a-b-c-d-e-f-g-h-987[abcde]"));
            //Real room
            Assert.AreEqual(404, Program.sectionIDIfReal("not-a-real-room-404[oarel]"));
            //Not a real room
            Assert.AreEqual(0, Program.sectionIDIfReal("totally-real-room-200[decoy]"));

            Assert.AreEqual(563, Program.sectionIDIfReal("ajvyjprwp-kdwwh-bjunb-563[jwbpa]"));

            Assert.AreEqual(0, Program.sectionIDIfReal("qvbmzvibqwvit-xtiabqk-oziaa-apqxxqvo-590[wbigl]"));

        }
    }
}