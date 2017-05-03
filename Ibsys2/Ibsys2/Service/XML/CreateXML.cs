using System;
using Ibsys2.Static.Output;

namespace Ibsys2.Service {
    public class CreateXML {
        public string GenerateXMLData() {
            string XMLOutput = "<input>";
            XMLOutput += Qualitycontrol.Class.XMLOutput();
            XMLOutput += Sellwish.Class.XMLOutput();
            XMLOutput += Selldirect.Class.XMLOutput();
            XMLOutput += Orderlist.Class.XMLOutput();
            XMLOutput += Productionlist.Class.XMLOutput();
            XMLOutput += Workingtimelist.Class.XMLOutput();
            return XMLOutput + "</input>";
        }
    }
}