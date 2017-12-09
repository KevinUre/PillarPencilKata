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
    public class PencilEraseTests
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

        [TestMethod()]
        public void ErasingSpacesDoesNotConsumeEraseDurability()
        {
            fauxPaper = "This is an eraser test";
            testPencil.Erase("an eraser", ref fauxPaper);
            Assert.AreEqual(17, testPencil.EraserDurability);
        }

        [TestMethod()]
        public void ErasingAPhraseLongerThanTheEraserDurabilityFailsToEraseItAll()
        {
            testPencil.EraserDurability = 3;
            fauxPaper = "Buffalo Bill";
            testPencil.Erase("Bill", ref fauxPaper);
            Assert.AreEqual("Buffalo B   ", fauxPaper);
        }

        [TestMethod()]
        public void ErasingANullInputDoesntCrash()
        {
            fauxPaper = "This is an eraser test";
            testPencil.Erase(null, ref fauxPaper);
        }

        [TestMethod()]
        public void ErasingNullPaperDoesntCrash()
        {
            fauxPaper = null;
            testPencil.Erase("chuck", ref fauxPaper);
        }
    }
}
