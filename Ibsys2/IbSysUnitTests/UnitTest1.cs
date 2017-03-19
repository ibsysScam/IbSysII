using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ibsys2.Static;
using Ibsys2.Static.Input;
using Ibsys2.Pages;
using Ibsys2.Pages.ReadXML;

namespace IbSysUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestXMLCompile()
        {
            Ibsys2.Pages.ReadXML.ReadXML readXML = new ReadXML();
            readXML.KlickAufDateiUpload();
        }
    }
}
