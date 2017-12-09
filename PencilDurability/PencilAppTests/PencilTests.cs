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
            testPencil = new Pencil();
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
    }
}