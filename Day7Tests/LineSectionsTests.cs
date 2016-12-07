using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Tests
{
    [TestClass()]
    public class LineSectionsTests
    {
        [TestMethod()]
        public void LineSectionsTest()
        {
            string line = "abba[mnop]qrst";
            LineSections lineSection = new LineSections(line);
            Assert.AreEqual("abba", lineSection.firstSection);
            Assert.AreEqual("mnop", lineSection.secondSection);
            Assert.AreEqual("qrst", lineSection.thirdSection);
        }

        [TestMethod()]
        public void isIPSupportsTLSTest()
        {

            string line = "abba[mnop]qrst";
            LineSections lineSection = new LineSections(line);
            Assert.AreEqual(true, lineSection.isIPSupportsTLS());
            
            line = "abcd[bddb]xyyx";
            lineSection = new LineSections(line);
            Assert.AreEqual(false, lineSection.isIPSupportsTLS());
            
            line = "aaaa[qwer]tyui";
            lineSection = new LineSections(line);
            Assert.AreEqual(false, lineSection.isIPSupportsTLS());
            
            line = "ioxxoj[asdfgh]zxcvbn";
            lineSection = new LineSections(line);
            Assert.AreEqual(true, lineSection.isIPSupportsTLS());

        }

        [TestMethod()]
        public void sectionContainsABBASequenceTest()
        {
            string line = "abba[mnop]qrst";
            LineSections lineSection = new LineSections(line);
            Assert.AreEqual(true, lineSection.sectionContainsABBASequence(lineSection.firstSection));
            Assert.AreEqual(false, lineSection.sectionContainsABBASequence(lineSection.secondSection));
            Assert.AreEqual(false, lineSection.sectionContainsABBASequence(lineSection.thirdSection));
        }

        [TestMethod()]
        public void checkFourCharsAreABBATest()
        {
            string line = "abba[mnop]qrst";
            LineSections lineSection = new LineSections(line);

            char[] chars = new char[] { 'a', 'b', 'b', 'a' };
            Assert.AreEqual(true, lineSection.checkFourCharsAreABBA(chars, 0));

            chars = new char[] { 'a', 'b', 'c', 'a', 'a' };
            Assert.AreEqual(false, lineSection.checkFourCharsAreABBA(chars, 1));

            chars = new char[] { 'a', 'b', 'a', 'a', 'c', 'c', 'a', 'd', 'e'};
            Assert.AreEqual(true, lineSection.checkFourCharsAreABBA(chars, 3));
        }
    }
}