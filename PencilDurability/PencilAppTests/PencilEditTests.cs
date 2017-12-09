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
    public class PencilEditTests
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
        public void EditingProperlyFindsTheGapToFill()
        {
            fauxPaper = "An       a day keeps the doctor away";
            testPencil.EditAppend("onion", ref fauxPaper);
            Assert.AreEqual("An onion a day keeps the doctor away", fauxPaper);
        }

        [TestMethod()]
        public void EditingWithANullInputDoesntCrash()
        {
            fauxPaper = "An       a day keeps the doctor away";
            testPencil.EditAppend(null, ref fauxPaper);
        }

        [TestMethod()]
        public void EditingWithANullPaperDoesntCrash()
        {
            fauxPaper = null;
            testPencil.EditAppend("onion", ref fauxPaper);
        }
    }
}
