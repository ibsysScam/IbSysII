using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Ibsys2.Static.Output;
using Ibsys2.Service;

namespace IbSysUnitTests
{
    [TestClass]
    public class Settings
    {

        [TestMethod]
        public void TestXMLInitialize()
        {
            SettingsService.Class.InitializeXML();
        }


        [TestMethod]
        public void ReadSettings()
        {
            SettingsService.Class.ReadSettings(_XMLTestInput);
        }


        #region TestSettings
        private static string _XMLTestInput = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<Settings>
<Language>Deutsch</Language>
</Settings>";
#endregion
    }


   
}