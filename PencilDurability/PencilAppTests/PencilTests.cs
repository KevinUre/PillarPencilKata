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

        [TestMethod()]
        public void ErasingASignleWordRepalcesItWithSpaces()
        {
            fauxPaper = "This is an eraser test";
            testPencil.Erase("eraser", ref fauxPaper);
            Assert.AreEqual("This is an        test", fauxPaper);
        }

        [TestMethod()]
        public void ErasingANonexistantWordDoesNothing()
        {
            fauxPaper = "Kevin Ure";
            testPencil.Erase("Zach", ref fauxPaper);
            Assert.AreEqual("Kevin Ure", fauxPaper);
        }

        [TestMethod()]
        public void ErasingPartOfAWordRepalcesOnlyThatPart()
        {
            fauxPaper = "antidisestablishmentarianism";
            testPencil.Erase("establishment", ref fauxPaper);
            Assert.AreEqual("antidis             arianism", fauxPaper);
        }

        [TestMethod()]
        public void ErasingSeveralWordsRepalcesTheWholePhraseWithSpaces()
        {
            fauxPaper = "This is an eraser test";
            testPencil.Erase("an eraser", ref fauxPaper);
            Assert.AreEqual("This is           test", fauxPaper);
        }

        [TestMethod()]
        public void ErasingAWordWithSeveralInstancesOnlyErasesTheLastInstance()
        {
            fauxPaper = "How much wood would a woodchuck chuck if a woodchuck could chuck wood?";
            testPencil.Erase("chuck", ref fauxPaper);
            Assert.AreEqual("How much wood would a woodchuck chuck if a woodchuck could       wood?", fauxPaper);
        }

        [TestMethod()]
        public void ErasingAWordSeveralTimes()
        {
            fauxPaper = "How much wood would a woodchuck chuck if a woodchuck could chuck wood?";
            testPencil.Erase("chuck", ref fauxPaper);
            testPencil.Erase("chuck", ref fauxPaper);
            Assert.AreEqual("How much wood would a woodchuck chuck if a wood      could       wood?", fauxPaper);
        }

        [TestMethod()]
        public void ErasingAWordConsumesThatWordsLengthInEraserDurability()
        {
            fauxPaper = "This is an eraser test";
            testPencil.Erase("eraser", ref fauxPaper);
            Assert.AreEqual(19, testPencil.EraserDurability);
        }
    }
}
