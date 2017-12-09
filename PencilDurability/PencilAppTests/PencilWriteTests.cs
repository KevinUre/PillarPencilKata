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
    public class PencilWriteTests
    {
        Pencil testPencil;
        string fauxPaper;

        [TestInitialize()]
        public void InitPencil()
        {
            testPencil = new Pencil(100, 10, 25);
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

        [TestMethod()]
        public void UpperCaseLettersCannotBeWrittenWhenThePencilHasOneDurabilty()
        {
            testPencil.Durability = 1;
            testPencil.Write("A", ref fauxPaper);
            Assert.AreEqual(" ", fauxPaper);
        }

        [TestMethod()]
        public void ZeroDurabilityPencilWritesOnlySpaces()
        {
            testPencil.Durability = 0;
            testPencil.Write("Hello", ref fauxPaper);
            Assert.AreEqual("     ", fauxPaper);
        }

        [TestMethod()]
        public void PencilWritesSpacesMidRequestIfDurabilityRunsOut()
        {
            testPencil.Durability = 3;
            testPencil.Write("Hello", ref fauxPaper);
            Assert.AreEqual("He   ", fauxPaper);
        }

        [TestMethod()]
        public void ShapeningRestoresInitialDurability()
        {
            int initialDur = testPencil.Durability;
            testPencil.Write("Hello World", ref fauxPaper);
            testPencil.Sharpen();
            Assert.AreEqual(initialDur, testPencil.Durability);
            testPencil = new Pencil(1000, 10, 25);
            testPencil.Write("Hello World", ref fauxPaper);
            testPencil.Sharpen();
            Assert.AreEqual(1000, testPencil.Durability);
        }

        [TestMethod()]
        public void SharpeningDecreasesLengthOfPencil()
        {
            int initialLength = testPencil.Length;
            testPencil.Sharpen();
            Assert.AreEqual(initialLength - 1, testPencil.Length);
        }

        [TestMethod()]
        public void SharpeningAZeroLengthPencilDoesNothing()
        {
            testPencil = new Pencil(100, 10, 25);
            testPencil.Length = 0;
            testPencil.Durability = 0;
            testPencil.Sharpen();
            Assert.AreEqual(0, testPencil.Durability);
        }
    }
}
