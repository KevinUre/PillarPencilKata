using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PencilApp.Tests
{
    [TestClass()]
    public class PencilTests
    {
        Pencil testPencil;
        string fauxPaper;

        [TestInitialize()]
        public void InitPencil()
        {
            testPencil = new Pencil(100);
            fauxPaper = "";
        }

        [TestMethod()]
        public void WriteAddsHelloWorldToAnExistingString()
        {
            testPencil.Write("Hello World!", ref fauxPaper);
            Assert.AreEqual("Hello World!", fauxPaper);
        }

        [TestMethod()]
        public void WriteDoesntCrashWhenPassedNullPaper()
        {
            fauxPaper = null;
            testPencil.Write("Hello World!", ref fauxPaper);
        }

        [TestMethod()]
        public void WriteDoesntCrashWhenPassedNullStringToBeWritten()
        {
            testPencil.Write(null, ref fauxPaper);
        }

        [TestMethod()]
        public void WriteAppendsGivenTextToExistingText()
        {
            testPencil.Write("She sells sea shells", ref fauxPaper);
            testPencil.Write(" down by the sea shore", ref fauxPaper);
            Assert.AreEqual("She sells sea shells down by the sea shore", fauxPaper);
        }

        [TestMethod()]
        public void PencilDurabilityDecreasesWhenWritingMyFirstName()
        {
            testPencil.Write("kevin", ref fauxPaper);
            Assert.AreEqual(95, testPencil.Durability);
        }

        [TestMethod()]
        public void PencilDurabilityDecreasesWhenWritingAntidisestablishmentarianism()
        {
            testPencil.Write("antidisestablishmentarianism", ref fauxPaper);
            Assert.AreEqual(72, testPencil.Durability);
        }

        [TestMethod()]
        public void PencilDurabilityDoesNotCountSpacesWhenWritingHelloWorld()
        {
            testPencil.Write("hello world", ref fauxPaper);
            Assert.AreEqual(90, testPencil.Durability);
        }

        [TestMethod()]
        public void PencilStopsWritingWhenOutOfDurability()
        {
            testPencil.Durability = 3;
            testPencil.Write("hello world", ref fauxPaper);
            Assert.AreEqual("hel", fauxPaper);
        }

        [TestMethod()]
        public void PencilWithNoDurabilityCantWrite()
        {
            testPencil.Durability = 0;
            testPencil.Write("hello world", ref fauxPaper);
            Assert.AreEqual("", fauxPaper);
        }

        [TestMethod()]
        public void LowerCaseLettersUseOneDurability()
        {
            testPencil.Write("a", ref fauxPaper);
            Assert.AreEqual(99, testPencil.Durability);
        }

        [TestMethod()]
        public void UpperCaseLettersUseTwoDurability()
        {
            testPencil.Write("A", ref fauxPaper);
            Assert.AreEqual(98, testPencil.Durability);
        }
    }
}