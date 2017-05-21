using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Ibsys2.Service;
using Ibsys2.Static.Output;

namespace IbSysUnitTests {
    [TestClass]
    public class XML {
        [TestMethod]
        public void KlickaufDateiUploadXMLCompile() {
            ReadXML readXML = new ReadXML();
            readXML.ParseXML(_XMLTestInput);
        }

        [TestMethod]
        public void TestCreateXMLPeriode1() {
            CreateXML createXML = new CreateXML();
            XMLCreatePeriode1();
            var XML = createXML.GenerateXMLData();

            if (String.Compare(XML, _XMLTestOutputPeriode1, true) != 0)
                throw new Exception("XML Output is not the same!");
        }

        [TestMethod]
        public void TestCreateXMLPeriode2() {
            CreateXML createXML = new CreateXML();
            XMLCreatePeriode2();
            var XML = createXML.GenerateXMLData();

            if (String.Compare(XML, _XMLTestOutputPeriode2, true) != 0)
                throw new Exception("XML Output is not the same!");
        }

        public void XMLCreatePeriode1() {
            if (String.IsNullOrEmpty(XML._XMLTestOutputPeriode1))
                throw new ArgumentNullException();

            //http://stackoverflow.com/questions/642293/how-do-i-read-and-parse-an-xml-file-in-c

            System.Xml.XmlDocument doc = new XmlDocument();
            doc.LoadXml(XML._XMLTestOutputPeriode1);

            Sellwish.Class.ClearClass();
            Selldirect.Class.ClearClass();
            Orderlist.Class.ClearClass();
            Productionlist.Class.ClearClass();
            Workingtimelist.Class.ClearClass();
            Qualitycontrol.Class.ClearClass();

            foreach (XmlNode GreatNode in doc.DocumentElement.ChildNodes) {
                foreach (XmlNode node in GreatNode) {
                    if (GreatNode.Name == "sellwish") {
                        Sellwish.Class.setAnzahlArtikel(Convert.ToInt32(node.Attributes["article"].InnerText), Convert.ToInt32(node.Attributes["quantity"].InnerText));
                    } else if (GreatNode.Name == "selldirect") {
                        Selldirect.Class.setAnzahlArtikel(Convert.ToInt32(node.Attributes["article"].InnerText), Convert.ToInt32(node.Attributes["quantity"].InnerText), Convert.ToDouble(node.Attributes["quantity"].InnerText), Convert.ToDouble(node.Attributes["penalty"].InnerText));
                    } else if (GreatNode.Name == "orderlist") {
                        Orderlist.Class.AddItem(new OrderlistItem(Convert.ToInt32(node.Attributes["article"].InnerText), Convert.ToInt32(node.Attributes["quantity"].InnerText), Convert.ToInt32(node.Attributes["modus"].InnerText)));
                    } else if (GreatNode.Name == "productionlist") {
                        Productionlist.Class.AddItem(new ProductionlistItem(Convert.ToInt32(node.Attributes["article"].InnerText), Convert.ToInt32(node.Attributes["quantity"].InnerText)));
                    } else if (GreatNode.Name == "workingtimelist") {
                        Workingtimelist.Class.AddItem(new WorkingtimelistItem(Convert.ToInt32(node.Attributes["station"].InnerText), Convert.ToInt32(node.Attributes["shift"].InnerText), Convert.ToInt32(node.Attributes["overtime"].InnerText)));
                    } else if (GreatNode.Name == "qualitycontrol") {
                        Qualitycontrol.Class.typ = GreatNode.Attributes["type"].InnerText;
                        Qualitycontrol.Class.losequantity = Convert.ToInt32(GreatNode.Attributes["losequantity"].InnerText);
                        Qualitycontrol.Class.delay = Convert.ToInt32(GreatNode.Attributes["delay"].InnerText);
                    }
                }
            }
        }

        public void XMLCreatePeriode2() {
            if (String.IsNullOrEmpty(XML._XMLTestOutputPeriode2))
                throw new ArgumentNullException();

            //http://stackoverflow.com/questions/642293/how-do-i-read-and-parse-an-xml-file-in-c

            System.Xml.XmlDocument doc = new XmlDocument();
            doc.LoadXml(XML._XMLTestOutputPeriode2);

            Sellwish.Class.ClearClass();
            Selldirect.Class.ClearClass();
            Orderlist.Class.ClearClass();
            Productionlist.Class.ClearClass();
            Workingtimelist.Class.ClearClass();
            Qualitycontrol.Class.ClearClass();

            foreach (XmlNode GreatNode in doc.DocumentElement.ChildNodes) {
                foreach (XmlNode node in GreatNode) {
                    if (GreatNode.Name == "sellwish") {
                        Sellwish.Class.setAnzahlArtikel(Convert.ToInt32(node.Attributes["article"].InnerText), Convert.ToInt32(node.Attributes["quantity"].InnerText));
                    } else if (GreatNode.Name == "selldirect") {
                        Selldirect.Class.setAnzahlArtikel(Convert.ToInt32(node.Attributes["article"].InnerText), Convert.ToInt32(node.Attributes["quantity"].InnerText), Convert.ToDouble(node.Attributes["quantity"].InnerText), Convert.ToDouble(node.Attributes["penalty"].InnerText));
                    } else if (GreatNode.Name == "orderlist") {
                        Orderlist.Class.AddItem(new OrderlistItem(Convert.ToInt32(node.Attributes["article"].InnerText), Convert.ToInt32(node.Attributes["quantity"].InnerText), Convert.ToInt32(node.Attributes["modus"].InnerText)));
                    } else if (GreatNode.Name == "productionlist") {
                        Productionlist.Class.AddItem(new ProductionlistItem(Convert.ToInt32(node.Attributes["article"].InnerText), Convert.ToInt32(node.Attributes["quantity"].InnerText)));
                    } else if (GreatNode.Name == "workingtimelist") {
                        Workingtimelist.Class.AddItem(new WorkingtimelistItem(Convert.ToInt32(node.Attributes["station"].InnerText), Convert.ToInt32(node.Attributes["shift"].InnerText), Convert.ToInt32(node.Attributes["overtime"].InnerText)));
                    } else if (GreatNode.Name == "qualitycontrol") {
                        Qualitycontrol.Class.typ = GreatNode.Attributes["type"].InnerText;
                        Qualitycontrol.Class.losequantity = Convert.ToInt32(GreatNode.Attributes["losequantity"].InnerText);
                        Qualitycontrol.Class.delay = Convert.ToInt32(GreatNode.Attributes["delay"].InnerText);
                    }
                }
            }
        }

        #region XMLOutput
        private static string _XMLTestOutputPeriode1 = (@"<input>
<qualitycontrol type=""no"" losequantity=""0"" delay=""0""/>
<sellwish>
<item article=""1"" quantity=""150""/>
<item article=""2"" quantity=""150""/>
<item article=""3"" quantity=""150""/>
</sellwish>
<selldirect>
<item article=""1"" quantity=""0"" price=""0.0"" penalty=""0.0""/>
<item article=""2"" quantity=""0"" price=""0.0"" penalty=""0.0""/>
<item article=""3"" quantity=""0"" price=""0.0"" penalty=""0.0""/>
</selldirect>
<orderlist>
<order article=""21"" quantity=""300"" modus=""5""/>
<order article=""22"" quantity=""300"" modus=""5""/>
<order article=""24"" quantity=""6100"" modus=""4""/>
<order article=""24"" quantity=""6100"" modus=""5""/>
<order article=""25"" quantity=""3600"" modus=""5""/>
<order article=""28"" quantity=""4500"" modus=""5""/>
<order article=""32"" quantity=""2700"" modus=""5""/>
<order article=""33"" quantity=""900"" modus=""5""/>
<order article=""36"" quantity=""900"" modus=""5""/>
<order article=""37"" quantity=""900"" modus=""5""/>
<order article=""38"" quantity=""1000"" modus=""4""/>
<order article=""39"" quantity=""1000"" modus=""4""/>
<order article=""40"" quantity=""900"" modus=""5""/>
<order article=""42"" quantity=""1800"" modus=""5""/>
<order article=""45"" quantity=""900"" modus=""5""/>
<order article=""53"" quantity=""22000"" modus=""5""/>
</orderlist>
<productionlist>
<production article=""4"" quantity=""110""/>
<production article=""5"" quantity=""80""/>
<production article=""6"" quantity=""80""/>
<production article=""7"" quantity=""110""/>
<production article=""8"" quantity=""80""/>
<production article=""9"" quantity=""80""/>
<production article=""10"" quantity=""110""/>
<production article=""11"" quantity=""80""/>
<production article=""12"" quantity=""80""/>
<production article=""13"" quantity=""110""/>
<production article=""14"" quantity=""80""/>
<production article=""15"" quantity=""80""/>
<production article=""16"" quantity=""270""/>
<production article=""17"" quantity=""270""/>
<production article=""18"" quantity=""110""/>
<production article=""19"" quantity=""80""/>
<production article=""20"" quantity=""80""/>
<production article=""26"" quantity=""270""/>
<production article=""49"" quantity=""110""/>
<production article=""54"" quantity=""80""/>
<production article=""29"" quantity=""80""/>
<production article=""50"" quantity=""110""/>
<production article=""55"" quantity=""80""/>
<production article=""30"" quantity=""80""/>
<production article=""51"" quantity=""110""/>
<production article=""56"" quantity=""80""/>
<production article=""31"" quantity=""80""/>
<production article=""1"" quantity=""130""/>
<production article=""2"" quantity=""100""/>
<production article=""3"" quantity=""100""/>
</productionlist>
<workingtimelist>
<workingtime station=""1"" shift=""1"" overtime=""0""/>
<workingtime station=""2"" shift=""1"" overtime=""0""/>
<workingtime station=""3"" shift=""1"" overtime=""0""/>
<workingtime station=""4"" shift=""1"" overtime=""0""/>
<workingtime station=""6"" shift=""1"" overtime=""0""/>
<workingtime station=""7"" shift=""1"" overtime=""90""/>
<workingtime station=""8"" shift=""1"" overtime=""0""/>
<workingtime station=""9"" shift=""1"" overtime=""0""/>
<workingtime station=""10"" shift=""1"" overtime=""0""/>
<workingtime station=""11"" shift=""1"" overtime=""0""/>
<workingtime station=""12"" shift=""1"" overtime=""0""/>
<workingtime station=""13"" shift=""1"" overtime=""0""/>
<workingtime station=""14"" shift=""1"" overtime=""0""/>
<workingtime station=""15"" shift=""1"" overtime=""0""/>
</workingtimelist>
</input>").Replace(Environment.NewLine, "").Replace("  ", " ").Replace("> <", "><");

        private static string _XMLTestOutputPeriode2 = (@"<input>
<qualitycontrol type=""no"" losequantity=""0"" delay=""0""/>
<sellwish>
<item article=""1"" quantity=""150""/>
<item article=""2"" quantity=""100""/>
<item article=""3"" quantity=""100""/>
</sellwish>
<selldirect>
<item article=""1"" quantity=""0"" price=""0.0"" penalty=""0.0""/>
<item article=""2"" quantity=""0"" price=""0.0"" penalty=""0.0""/>
<item article=""3"" quantity=""0"" price=""0.0"" penalty=""0.0""/>
</selldirect>
<orderlist>
<order article=""27"" quantity=""1800"" modus=""5""/>
<order article=""35"" quantity=""3600"" modus=""4""/>
<order article=""39"" quantity=""1800"" modus=""5""/>
<order article=""41"" quantity=""900"" modus=""5""/>
<order article=""44"" quantity=""900"" modus=""5""/>
<order article=""46"" quantity=""900"" modus=""5""/>
<order article=""47"" quantity=""900"" modus=""5""/>
<order article=""48"" quantity=""1800"" modus=""5""/>
<order article=""52"" quantity=""600"" modus=""4""/>
<order article=""57"" quantity=""600"" modus=""5""/>
<order article=""58"" quantity=""22000"" modus=""5""/>
<order article=""59"" quantity=""1800"" modus=""5""/>
</orderlist>
<productionlist>
<production article=""1"" quantity=""150""/>
<production article=""26"" quantity=""63""/>
<production article=""51"" quantity=""150""/>
<production article=""16"" quantity=""150""/>
<production article=""17"" quantity=""150""/>
<production article=""50"" quantity=""150""/>
<production article=""4"" quantity=""150""/>
<production article=""10"" quantity=""150""/>
<production article=""49"" quantity=""150""/>
<production article=""7"" quantity=""150""/>
<production article=""13"" quantity=""150""/>
<production article=""18"" quantity=""150""/>
<production article=""2"" quantity=""100""/>
<production article=""26"" quantity=""143""/>
<production article=""56"" quantity=""100""/>
<production article=""16"" quantity=""100""/>
<production article=""17"" quantity=""100""/>
<production article=""55"" quantity=""100""/>
<production article=""5"" quantity=""100""/>
<production article=""11"" quantity=""100""/>
<production article=""54"" quantity=""100""/>
<production article=""8"" quantity=""100""/>
<production article=""14"" quantity=""100""/>
<production article=""19"" quantity=""100""/>
<production article=""3"" quantity=""100""/>
<production article=""26"" quantity=""143""/>
<production article=""31"" quantity=""100""/>
<production article=""16"" quantity=""100""/>
<production article=""17"" quantity=""100""/>
<production article=""30"" quantity=""100""/>
<production article=""6"" quantity=""100""/>
<production article=""12"" quantity=""100""/>
<production article=""29"" quantity=""100""/>
<production article=""9"" quantity=""100""/>
<production article=""15"" quantity=""100""/>
<production article=""20"" quantity=""100""/>
</productionlist>
<workingtimelist>
<workingtime station=""1"" shift=""1"" overtime=""0""/>
<workingtime station=""2"" shift=""1"" overtime=""0""/>
<workingtime station=""3"" shift=""1"" overtime=""0""/>
<workingtime station=""4"" shift=""1"" overtime=""15""/>
<workingtime station=""6"" shift=""1"" overtime=""0""/>
<workingtime station=""7"" shift=""2"" overtime=""0""/>
<workingtime station=""8"" shift=""1"" overtime=""60""/>
<workingtime station=""9"" shift=""1"" overtime=""150""/>
<workingtime station=""10"" shift=""1"" overtime=""120""/>
<workingtime station=""11"" shift=""1"" overtime=""0""/>
<workingtime station=""12"" shift=""1"" overtime=""0""/>
<workingtime station=""13"" shift=""1"" overtime=""0""/>
<workingtime station=""14"" shift=""1"" overtime=""0""/>
<workingtime station=""15"" shift=""1"" overtime=""0""/>
</workingtimelist>
</input>").Replace(Environment.NewLine, "").Replace("  ", " ").Replace("> <", "><");
        #endregion
        #region XMLInput
        private static string _XMLTestInput = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<results game=""198"" group=""5"" period=""6"">
	<warehousestock>
		<article id=""1"" amount=""0"" startamount=""100"" pct=""0,00"" price=""169,15"" stockvalue=""0,00"" />
		<article id=""2"" amount=""70"" startamount=""100"" pct=""70,00"" price=""167,02"" stockvalue=""11691,33"" />
		<article id=""3"" amount=""40"" startamount=""100"" pct=""40,00"" price=""169,56"" stockvalue=""6782,56"" />
		<article id=""4"" amount=""40"" startamount=""100"" pct=""40,00"" price=""40,66"" stockvalue=""1626,59"" />
		<article id=""5"" amount=""30"" startamount=""100"" pct=""30,00"" price=""38,73"" stockvalue=""1161,85"" />
		<article id=""6"" amount=""40"" startamount=""100"" pct=""40,00"" price=""40,13"" stockvalue=""1605,24"" />
		<article id=""7"" amount=""60"" startamount=""100"" pct=""60,00"" price=""36,46"" stockvalue=""2187,80"" />
		<article id=""8"" amount=""0"" startamount=""100"" pct=""0,00"" price=""34,94"" stockvalue=""0,00"" />
		<article id=""9"" amount=""40"" startamount=""100"" pct=""40,00"" price=""36,00"" stockvalue=""1440,18"" />
		<article id=""10"" amount=""40"" startamount=""100"" pct=""40,00"" price=""12,70"" stockvalue=""507,96"" />
		<article id=""11"" amount=""30"" startamount=""100"" pct=""30,00"" price=""14,34"" stockvalue=""430,33"" />
		<article id=""12"" amount=""40"" startamount=""100"" pct=""40,00"" price=""13,77"" stockvalue=""550,88"" />
		<article id=""13"" amount=""60"" startamount=""100"" pct=""60,00"" price=""14,46"" stockvalue=""867,69"" />
		<article id=""14"" amount=""0"" startamount=""100"" pct=""0,00"" price=""14,39"" stockvalue=""0,00"" />
		<article id=""15"" amount=""40"" startamount=""100"" pct=""40,00"" price=""15,93"" stockvalue=""637,28"" />
		<article id=""16"" amount=""180"" startamount=""300"" pct=""60,00"" price=""6,99"" stockvalue=""1257,83"" />
		<article id=""17"" amount=""100"" startamount=""300"" pct=""33,33"" price=""8,15"" stockvalue=""815,17"" />
		<article id=""18"" amount=""20"" startamount=""100"" pct=""20,00"" price=""18,44"" stockvalue=""368,79"" />
		<article id=""19"" amount=""0"" startamount=""100"" pct=""0,00"" price=""15,26"" stockvalue=""0,00"" />
		<article id=""20"" amount=""40"" startamount=""100"" pct=""40,00"" price=""17,72"" stockvalue=""708,73"" />
		<article id=""21"" amount=""300"" startamount=""300"" pct=""100,00"" price=""5,74"" stockvalue=""1721,43"" />
		<article id=""22"" amount=""380"" startamount=""300"" pct=""126,67"" price=""7,96"" stockvalue=""3026,44"" />
		<article id=""23"" amount=""110"" startamount=""300"" pct=""36,67"" price=""6,09"" stockvalue=""669,43"" />
		<article id=""24"" amount=""4870"" startamount=""6100"" pct=""79,84"" price=""0,12"" stockvalue=""604,44"" />
		<article id=""25"" amount=""3500"" startamount=""3600"" pct=""97,22"" price=""0,07"" stockvalue=""232,55"" />
		<article id=""26"" amount=""88"" startamount=""300"" pct=""29,33"" price=""11,61"" stockvalue=""1022,06"" />
		<article id=""27"" amount=""2970"" startamount=""1800"" pct=""165,00"" price=""0,13"" stockvalue=""391,05"" />
		<article id=""28"" amount=""5900"" startamount=""4500"" pct=""131,11"" price=""1,11"" stockvalue=""6558,68"" />
		<article id=""29"" amount=""40"" startamount=""100"" pct=""40,00"" price=""72,91"" stockvalue=""2916,21"" />
		<article id=""30"" amount=""40"" startamount=""100"" pct=""40,00"" price=""129,56"" stockvalue=""5182,40"" />
		<article id=""31"" amount=""40"" startamount=""100"" pct=""40,00"" price=""147,79"" stockvalue=""5911,68"" />
		<article id=""32"" amount=""6030"" startamount=""2700"" pct=""223,33"" price=""0,69"" stockvalue=""4189,17"" />
		<article id=""33"" amount=""1240"" startamount=""900"" pct=""137,78"" price=""20,68"" stockvalue=""25639,60"" />
		<article id=""34"" amount=""45840"" startamount=""22000"" pct=""208,36"" price=""0,11"" stockvalue=""4887,78"" />
		<article id=""35"" amount=""4280"" startamount=""3600"" pct=""118,89"" price=""1,00"" stockvalue=""4294,47"" />
		<article id=""36"" amount=""980"" startamount=""900"" pct=""108,89"" price=""7,41"" stockvalue=""7260,44"" />
		<article id=""37"" amount=""1160"" startamount=""900"" pct=""128,89"" price=""1,42"" stockvalue=""1648,95"" />
		<article id=""38"" amount=""360"" startamount=""300"" pct=""120,00"" price=""2,21"" stockvalue=""795,75"" />
		<article id=""39"" amount=""2240"" startamount=""900"" pct=""248,89"" price=""1,40"" stockvalue=""3145,48"" />
		<article id=""40"" amount=""800"" startamount=""900"" pct=""88,89"" price=""2,32"" stockvalue=""1858,91"" />
		<article id=""41"" amount=""800"" startamount=""900"" pct=""88,89"" price=""0,10"" stockvalue=""83,16"" />
		<article id=""42"" amount=""1600"" startamount=""1800"" pct=""88,89"" price=""0,12"" stockvalue=""184,06"" />
		<article id=""43"" amount=""2780"" startamount=""1900"" pct=""146,32"" price=""4,54"" stockvalue=""12625,01"" />
		<article id=""44"" amount=""264"" startamount=""2700"" pct=""9,78"" price=""1,06"" stockvalue=""278,67"" />
		<article id=""45"" amount=""880"" startamount=""900"" pct=""97,78"" price=""0,11"" stockvalue=""94,09"" />
		<article id=""46"" amount=""880"" startamount=""900"" pct=""97,78"" price=""0,14"" stockvalue=""122,77"" />
		<article id=""47"" amount=""692"" startamount=""900"" pct=""76,89"" price=""3,22"" stockvalue=""2226,01"" />
		<article id=""48"" amount=""1184"" startamount=""1800"" pct=""65,78"" price=""1,39"" stockvalue=""1649,32"" />
		<article id=""49"" amount=""10"" startamount=""100"" pct=""10,00"" price=""69,54"" stockvalue=""695,40"" />
		<article id=""50"" amount=""100"" startamount=""100"" pct=""100,00"" price=""127,59"" stockvalue=""12758,90"" />
		<article id=""51"" amount=""20"" startamount=""100"" pct=""20,00"" price=""146,80"" stockvalue=""2936,04"" />
		<article id=""52"" amount=""920"" startamount=""600"" pct=""153,33"" price=""21,13"" stockvalue=""19442,91"" />
		<article id=""53"" amount=""34720"" startamount=""22000"" pct=""157,82"" price=""0,10"" stockvalue=""3514,78"" />
		<article id=""54"" amount=""70"" startamount=""100"" pct=""70,00"" price=""68,15"" stockvalue=""4770,80"" />
		<article id=""55"" amount=""50"" startamount=""100"" pct=""50,00"" price=""124,55"" stockvalue=""6227,55"" />
		<article id=""56"" amount=""40"" startamount=""100"" pct=""40,00"" price=""142,67"" stockvalue=""5706,80"" />
		<article id=""57"" amount=""580"" startamount=""600"" pct=""96,67"" price=""20,16"" stockvalue=""11691,76"" />
		<article id=""58"" amount=""22080"" startamount=""22000"" pct=""100,36"" price=""0,09"" stockvalue=""2047,55"" />
		<article id=""59"" amount=""2320"" startamount=""1800"" pct=""128,89"" price=""0,16"" stockvalue=""373,65"" />
		<totalstockvalue>202026,33</totalstockvalue>
	</warehousestock>
	<inwardstockmovement>
		<order orderperiod=""4"" id=""4"" mode=""5"" article=""35"" amount=""3600"" time=""37440"" materialcosts=""3240,00"" ordercosts=""75,00"" entirecosts=""3315,00"" piececosts=""0,92"" />
		<order orderperiod=""5"" id=""2"" mode=""5"" article=""27"" amount=""1800"" time=""37440"" materialcosts=""162,00"" ordercosts=""75,00"" entirecosts=""237,00"" piececosts=""0,13"" />
		<order orderperiod=""5"" id=""8"" mode=""5"" article=""53"" amount=""22000"" time=""38880"" materialcosts=""1980,00"" ordercosts=""50,00"" entirecosts=""2030,00"" piececosts=""0,09"" />
		<order orderperiod=""5"" id=""7"" mode=""5"" article=""52"" amount=""600"" time=""40320"" materialcosts=""11880,00"" ordercosts=""50,00"" entirecosts=""11930,00"" piececosts=""19,88"" />
		<order orderperiod=""6"" id=""7"" mode=""4"" article=""44"" amount=""900"" time=""40320"" materialcosts=""450,00"" ordercosts=""500,00"" entirecosts=""950,00"" piececosts=""1,06"" />
		<order orderperiod=""4"" id=""2"" mode=""5"" article=""32"" amount=""2700"" time=""41760"" materialcosts=""1822,50"" ordercosts=""50,00"" entirecosts=""1872,50"" piececosts=""0,69"" />
		<order orderperiod=""5"" id=""3"" mode=""5"" article=""32"" amount=""2700"" time=""41760"" materialcosts=""1822,50"" ordercosts=""50,00"" entirecosts=""1872,50"" piececosts=""0,69"" />
		<order orderperiod=""4"" id=""7"" mode=""5"" article=""43"" amount=""2700"" time=""43200"" materialcosts=""12150,00"" ordercosts=""75,00"" entirecosts=""12225,00"" piececosts=""4,53"" />
		<order orderperiod=""6"" id=""2"" mode=""4"" article=""22"" amount=""300"" time=""43200"" materialcosts=""1950,00"" ordercosts=""500,00"" entirecosts=""2450,00"" piececosts=""8,17"" />
		<order orderperiod=""6"" id=""4"" mode=""5"" article=""27"" amount=""1800"" time=""43200"" materialcosts=""162,00"" ordercosts=""75,00"" entirecosts=""237,00"" piececosts=""0,13"" />
	</inwardstockmovement>
	<futureinwardstockmovement>
		<order orderperiod=""5"" id=""4"" mode=""5"" article=""35"" amount=""3600"" />
		<order orderperiod=""5"" id=""5"" mode=""5"" article=""38"" amount=""300"" />
		<order orderperiod=""6"" id=""9"" mode=""5"" article=""47"" amount=""900"" />
		<order orderperiod=""6"" id=""10"" mode=""5"" article=""48"" amount=""1800"" />
		<order orderperiod=""6"" id=""3"" mode=""5"" article=""23"" amount=""300"" />
		<order orderperiod=""6"" id=""6"" mode=""5"" article=""40"" amount=""900"" />
		<order orderperiod=""6"" id=""5"" mode=""5"" article=""38"" amount=""300"" />
		<order orderperiod=""6"" id=""8"" mode=""5"" article=""45"" amount=""900"" />
		<order orderperiod=""6"" id=""12"" mode=""5"" article=""58"" amount=""22000"" />
		<order orderperiod=""6"" id=""1"" mode=""5"" article=""21"" amount=""300"" />
		<order orderperiod=""6"" id=""11"" mode=""5"" article=""57"" amount=""600"" />
		<order orderperiod=""5"" id=""1"" mode=""5"" article=""24"" amount=""6100"" />
	</futureinwardstockmovement>
	<idletimecosts>
		<workplace id=""1"" setupevents=""6"" idletime=""0"" wageidletimecosts=""0,00"" wagecosts=""1289,25"" machineidletimecosts=""0,00"" />
		<workplace id=""2"" setupevents=""11"" idletime=""150"" wageidletimecosts=""67,50"" wagecosts=""1012,50"" machineidletimecosts=""1,50"" />
		<workplace id=""3"" setupevents=""6"" idletime=""405"" wageidletimecosts=""195,75"" wagecosts=""951,75"" machineidletimecosts=""4,05"" />
		<workplace id=""4"" setupevents=""6"" idletime=""370"" wageidletimecosts=""220,50"" wagecosts=""1399,50"" machineidletimecosts=""3,70"" />
		<workplace id=""6"" setupevents=""6"" idletime=""600"" wageidletimecosts=""270,00"" wagecosts=""810,00"" machineidletimecosts=""60,00"" />
		<workplace id=""7"" setupevents=""20"" idletime=""500"" wageidletimecosts=""391,50"" wagecosts=""1768,50"" machineidletimecosts=""50,00"" />
		<workplace id=""8"" setupevents=""17"" idletime=""515"" wageidletimecosts=""283,50"" wagecosts=""1201,50"" machineidletimecosts=""51,50"" />
		<workplace id=""9"" setupevents=""12"" idletime=""645"" wageidletimecosts=""362,25"" wagecosts=""1797,75"" machineidletimecosts=""161,25"" />
		<workplace id=""10"" setupevents=""6"" idletime=""260"" wageidletimecosts=""180,00"" wagecosts=""1530,00"" machineidletimecosts=""26,00"" />
		<workplace id=""11"" setupevents=""6"" idletime=""260"" wageidletimecosts=""117,00"" wagecosts=""963,00"" machineidletimecosts=""26,00"" />
		<workplace id=""12"" setupevents=""6"" idletime=""660"" wageidletimecosts=""297,00"" wagecosts=""783,00"" machineidletimecosts=""66,00"" />
		<workplace id=""13"" setupevents=""6"" idletime=""1240"" wageidletimecosts=""558,00"" wagecosts=""522,00"" machineidletimecosts=""186,00"" />
		<workplace id=""14"" setupevents=""0"" idletime=""1320"" wageidletimecosts=""594,00"" wagecosts=""486,00"" machineidletimecosts=""13,20"" />
		<workplace id=""15"" setupevents=""6"" idletime=""810"" wageidletimecosts=""418,50"" wagecosts=""931,50"" machineidletimecosts=""8,10"" />
		<sum setupevents=""114"" idletime=""7735"" wageidletimecosts=""3955,50"" wagecosts=""15446,25"" machineidletimecosts=""657,30"" />
	</idletimecosts>
	<waitinglistworkstations>
		<workplace id=""1"" timeneed=""120"">
			<waitinglist period=""6"" order=""33"" firstbatch=""6"" lastbatch=""7"" item=""49"" amount=""20"" timeneed=""120"" />
		</workplace>
		<workplace id=""2"" timeneed=""0"" />
		<workplace id=""3"" timeneed=""300"">
			<waitinglist period=""6"" order=""27"" firstbatch=""4"" lastbatch=""9"" item=""51"" amount=""60"" timeneed=""300"" />
		</workplace>
		<workplace id=""4"" timeneed=""300"">
			<waitinglist period=""6"" order=""25"" firstbatch=""6"" lastbatch=""10"" item=""1"" amount=""50"" timeneed=""300"" />
		</workplace>
		<workplace id=""6"" timeneed=""0"" />
		<workplace id=""7"" timeneed=""0"" />
		<workplace id=""8"" timeneed=""0"" />
		<workplace id=""9"" timeneed=""60"">
			<waitinglist period=""6"" order=""36"" firstbatch=""4"" lastbatch=""6"" item=""18"" amount=""30"" timeneed=""60"" />
		</workplace>
		<workplace id=""10"" timeneed=""0"" />
		<workplace id=""11"" timeneed=""0"" />
		<workplace id=""12"" timeneed=""0"" />
		<workplace id=""13"" timeneed=""0"" />
		<workplace id=""14"" timeneed=""0"" />
		<workplace id=""15"" timeneed=""540"">
			<waitinglist period=""6"" order=""26"" firstbatch=""2"" lastbatch=""11"" item=""26"" amount=""100"" timeneed=""300"" />
			<waitinglist period=""6"" order=""29"" firstbatch=""1"" lastbatch=""8"" item=""17"" amount=""80"" timeneed=""240"" />
		</workplace>
	</waitinglistworkstations>
	<waitingliststock>
		<missingpart id=""14"">
			<waitinglist period=""6"" order=""9"" firstbatch=""27"" lastbatch=""27"" item=""54"" amount=""10"" />
		</missingpart>
	</waitingliststock>
	<ordersinwork>
		<workplace id=""1"" period=""6"" order=""33"" batch=""5"" item=""49"" amount=""10"" timeneed=""15"" />
		<workplace id=""3"" period=""6"" order=""27"" batch=""3"" item=""51"" amount=""10"" timeneed=""25"" />
		<workplace id=""4"" period=""6"" order=""25"" batch=""5"" item=""1"" amount=""10"" timeneed=""20"" />
		<workplace id=""9"" period=""6"" order=""36"" batch=""3"" item=""18"" amount=""10"" timeneed=""5"" />
		<workplace id=""15"" period=""6"" order=""26"" batch=""1"" item=""26"" amount=""10"" timeneed=""30"" />
	</ordersinwork>
	<completedorders>
		<order period=""5"" id=""18"" item=""55"" quantity=""10"" cost=""1309,35"" averageunitcosts=""130,93"">
			<batch id=""13"" amount=""10"" cycletime=""80"" cost=""1309,35"" />
			</order>
		<order period=""5"" id=""21"" item=""54"" quantity=""50"" cost=""3417,17"" averageunitcosts=""68,34"">
			<batch id=""7"" amount=""10"" cycletime=""80"" cost=""740,38"" />
			<batch id=""8"" amount=""10"" cycletime=""60"" cost=""660,38"" />
			<batch id=""9"" amount=""10"" cycletime=""60"" cost=""682,88"" />
			<batch id=""10"" amount=""10"" cycletime=""975"" cost=""667,88"" />
			<batch id=""11"" amount=""10"" cycletime=""60"" cost=""665,63"" />
		</order>
		<order period=""5"" id=""23"" item=""14"" quantity=""90"" cost=""868,15"" averageunitcosts=""9,65"">
			<batch id=""1"" amount=""10"" cycletime=""4190"" cost=""182,04"" />
			<batch id=""2"" amount=""10"" cycletime=""2920"" cost=""85,76"" />
			<batch id=""3"" amount=""10"" cycletime=""2920"" cost=""85,76"" />
			<batch id=""4"" amount=""10"" cycletime=""2920"" cost=""85,76"" />
			<batch id=""5"" amount=""10"" cycletime=""2920"" cost=""85,76"" />
			<batch id=""6"" amount=""10"" cycletime=""2920"" cost=""85,76"" />
			<batch id=""7"" amount=""10"" cycletime=""2920"" cost=""85,76"" />
			<batch id=""8"" amount=""10"" cycletime=""2920"" cost=""85,76"" />
			<batch id=""9"" amount=""10"" cycletime=""2920"" cost=""85,76"" />
		</order>
		<order period=""5"" id=""24"" item=""19"" quantity=""90"" cost=""1050,18"" averageunitcosts=""11,67"">
			<batch id=""1"" amount=""10"" cycletime=""3045"" cost=""152,69"" />
			<batch id=""2"" amount=""10"" cycletime=""3020"" cost=""107,69"" />
			<batch id=""3"" amount=""10"" cycletime=""3010"" cost=""107,69"" />
			<batch id=""4"" amount=""10"" cycletime=""3000"" cost=""107,69"" />
			<batch id=""5"" amount=""10"" cycletime=""2990"" cost=""107,69"" />
			<batch id=""6"" amount=""10"" cycletime=""2980"" cost=""116,69"" />
			<batch id=""7"" amount=""10"" cycletime=""2970"" cost=""116,69"" />
			<batch id=""8"" amount=""10"" cycletime=""2960"" cost=""116,69"" />
			<batch id=""9"" amount=""10"" cycletime=""1990"" cost=""116,69"" />
		</order>
		<order period=""5"" id=""25"" item=""26"" quantity=""10"" cost=""163,64"" averageunitcosts=""16,36"">
			<batch id=""1"" amount=""10"" cycletime=""925"" cost=""163,64"" />
		</order><order period=""6"" id=""1"" item=""2"" quantity=""220"" cost=""36709,87"" averageunitcosts=""166,86"">
			<batch id=""1"" amount=""10"" cycletime=""70"" cost=""1677,93"" />
			<batch id=""2"" amount=""10"" cycletime=""70"" cost=""1679,66"" />
			<batch id=""3"" amount=""10"" cycletime=""70"" cost=""1676,63"" />
			<batch id=""4"" amount=""10"" cycletime=""70"" cost=""1673,65"" />
			<batch id=""5"" amount=""10"" cycletime=""70"" cost=""1683,92"" />
			<batch id=""6"" amount=""10"" cycletime=""70"" cost=""1667,38"" />
			<batch id=""7"" amount=""10"" cycletime=""70"" cost=""1662,63"" />
			<batch id=""8"" amount=""10"" cycletime=""70"" cost=""1655,53"" />
			<batch id=""9"" amount=""10"" cycletime=""70"" cost=""1650,98"" />
			<batch id=""10"" amount=""10"" cycletime=""70"" cost=""1651,08"" />
			<batch id=""11"" amount=""10"" cycletime=""70"" cost=""1674,57"" />
			<batch id=""12"" amount=""10"" cycletime=""910"" cost=""1661,07"" />
			<batch id=""13"" amount=""10"" cycletime=""70"" cost=""1643,07"" />
			<batch id=""14"" amount=""10"" cycletime=""70"" cost=""1643,07"" />
			<batch id=""15"" amount=""10"" cycletime=""70"" cost=""1653,31"" />
			<batch id=""16"" amount=""10"" cycletime=""70"" cost=""1653,31"" />
			<batch id=""17"" amount=""10"" cycletime=""90"" cost=""1739,93"" />
			<batch id=""18"" amount=""10"" cycletime=""70"" cost=""1714,85"" />
			<batch id=""19"" amount=""10"" cycletime=""90"" cost=""1678,57"" />
			<batch id=""20"" amount=""10"" cycletime=""70"" cost=""1658,80"" />
			<batch id=""21"" amount=""10"" cycletime=""70"" cost=""1656,13"" />
			<batch id=""22"" amount=""10"" cycletime=""70"" cost=""1653,80"" />
		</order>
		<order period=""6"" id=""2"" item=""26"" quantity=""220"" cost=""2472,05"" averageunitcosts=""11,24"">
			<batch id=""1"" amount=""10"" cycletime=""75"" cost=""111,14"" />
			<batch id=""2"" amount=""10"" cycletime=""85"" cost=""111,14"" />
			<batch id=""3"" amount=""10"" cycletime=""95"" cost=""111,14"" />
			<batch id=""4"" amount=""10"" cycletime=""105"" cost=""111,14"" />
			<batch id=""5"" amount=""10"" cycletime=""115"" cost=""111,14"" />
			<batch id=""6"" amount=""10"" cycletime=""125"" cost=""111,14"" />
			<batch id=""7"" amount=""10"" cycletime=""135"" cost=""111,14"" />
			<batch id=""8"" amount=""10"" cycletime=""145"" cost=""111,14"" />
			<batch id=""9"" amount=""10"" cycletime=""155"" cost=""111,14"" />
			<batch id=""10"" amount=""10"" cycletime=""165"" cost=""111,14"" />
			<batch id=""11"" amount=""10"" cycletime=""175"" cost=""111,14"" />
			<batch id=""12"" amount=""10"" cycletime=""185"" cost=""111,14"" />
			<batch id=""13"" amount=""10"" cycletime=""195"" cost=""111,14"" />
			<batch id=""14"" amount=""10"" cycletime=""205"" cost=""111,14"" />
			<batch id=""15"" amount=""10"" cycletime=""215"" cost=""117,89"" />
			<batch id=""16"" amount=""10"" cycletime=""225"" cost=""124,64"" />
			<batch id=""17"" amount=""10"" cycletime=""1135"" cost=""117,89"" />
			<batch id=""18"" amount=""10"" cycletime=""1145"" cost=""111,14"" />
			<batch id=""19"" amount=""10"" cycletime=""1155"" cost=""111,14"" />
			<batch id=""20"" amount=""10"" cycletime=""1165"" cost=""111,14"" />
			<batch id=""21"" amount=""10"" cycletime=""1175"" cost=""111,14"" />
			<batch id=""22"" amount=""10"" cycletime=""1185"" cost=""111,14"" />
		</order>
		<order period=""6"" id=""3"" item=""56"" quantity=""220"" cost=""31539,44"" averageunitcosts=""143,36"">
			<batch id=""1"" amount=""10"" cycletime=""60"" cost=""1445,49"" />
			<batch id=""2"" amount=""10"" cycletime=""60"" cost=""1445,49"" />
			<batch id=""3"" amount=""10"" cycletime=""60"" cost=""1446,14"" />
			<batch id=""4"" amount=""10"" cycletime=""60"" cost=""1490,39"" />
			<batch id=""5"" amount=""10"" cycletime=""60"" cost=""1394,80"" />
			<batch id=""6"" amount=""10"" cycletime=""60"" cost=""1424,80"" />
			<batch id=""7"" amount=""10"" cycletime=""60"" cost=""1410,29"" />
			<batch id=""8"" amount=""10"" cycletime=""60"" cost=""1409,70"" />
			<batch id=""9"" amount=""10"" cycletime=""60"" cost=""1408,52"" />
			<batch id=""10"" amount=""10"" cycletime=""60"" cost=""1412,94"" />
			<batch id=""11"" amount=""10"" cycletime=""60"" cost=""1412,94"" />
			<batch id=""12"" amount=""10"" cycletime=""80"" cost=""1438,69"" />
			<batch id=""13"" amount=""10"" cycletime=""80"" cost=""1496,07"" />
			<batch id=""14"" amount=""10"" cycletime=""60"" cost=""1458,49"" />
			<batch id=""15"" amount=""10"" cycletime=""60"" cost=""1443,71"" />
			<batch id=""16"" amount=""10"" cycletime=""60"" cost=""1436,16"" />
			<batch id=""17"" amount=""10"" cycletime=""60"" cost=""1431,73"" />
			<batch id=""18"" amount=""10"" cycletime=""60"" cost=""1428,60"" />
			<batch id=""19"" amount=""10"" cycletime=""60"" cost=""1426,62"" />
			<batch id=""20"" amount=""10"" cycletime=""60"" cost=""1424,89"" />
			<batch id=""21"" amount=""10"" cycletime=""60"" cost=""1423,60"" />
			<batch id=""22"" amount=""10"" cycletime=""1005"" cost=""1429,38"" />
		</order>
		<order period=""6"" id=""4"" item=""16"" quantity=""210"" cost=""1458,87"" averageunitcosts=""6,95"">
			<batch id=""1"" amount=""10"" cycletime=""65"" cost=""80,18"" />
			<batch id=""2"" amount=""10"" cycletime=""60"" cost=""68,93"" />
			<batch id=""3"" amount=""10"" cycletime=""70"" cost=""68,93"" />
			<batch id=""4"" amount=""10"" cycletime=""80"" cost=""68,93"" />
			<batch id=""5"" amount=""10"" cycletime=""90"" cost=""68,93"" />
			<batch id=""6"" amount=""10"" cycletime=""100"" cost=""68,93"" />
			<batch id=""7"" amount=""10"" cycletime=""110"" cost=""68,93"" />
			<batch id=""8"" amount=""10"" cycletime=""120"" cost=""68,93"" />
			<batch id=""9"" amount=""10"" cycletime=""130"" cost=""68,93"" />
			<batch id=""10"" amount=""10"" cycletime=""140"" cost=""68,93"" />
			<batch id=""11"" amount=""10"" cycletime=""150"" cost=""68,93"" />
			<batch id=""12"" amount=""10"" cycletime=""160"" cost=""68,93"" />
			<batch id=""13"" amount=""10"" cycletime=""170"" cost=""68,93"" />
			<batch id=""14"" amount=""10"" cycletime=""180"" cost=""68,93"" />
			<batch id=""15"" amount=""10"" cycletime=""1150"" cost=""68,93"" />
			<batch id=""16"" amount=""10"" cycletime=""1160"" cost=""68,93"" />
			<batch id=""17"" amount=""10"" cycletime=""1170"" cost=""68,93"" />
			<batch id=""18"" amount=""10"" cycletime=""1180"" cost=""68,93"" />
			<batch id=""19"" amount=""10"" cycletime=""1190"" cost=""68,93"" />
			<batch id=""20"" amount=""10"" cycletime=""1200"" cost=""68,93"" />
			<batch id=""21"" amount=""10"" cycletime=""1210"" cost=""68,93"" />
		</order>
		<order period=""6"" id=""5"" item=""17"" quantity=""210"" cost=""1680,42"" averageunitcosts=""8,00"">
			<batch id=""1"" amount=""10"" cycletime=""45"" cost=""85,52"" />
			<batch id=""2"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""3"" amount=""10"" cycletime=""45"" cost=""85,52"" />
			<batch id=""4"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""5"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""6"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""7"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""8"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""9"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""10"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""11"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""12"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""13"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""14"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""15"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""16"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""17"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""18"" amount=""10"" cycletime=""30"" cost=""84,77"" />
			<batch id=""19"" amount=""10"" cycletime=""30"" cost=""91,52"" />
			<batch id=""20"" amount=""10"" cycletime=""930"" cost=""84,77"" />
			<batch id=""21"" amount=""10"" cycletime=""30"" cost=""78,02"" />
		</order>
		<order period=""6"" id=""6"" item=""55"" quantity=""230"" cost=""28647,43"" averageunitcosts=""124,55"">
			<batch id=""1"" amount=""10"" cycletime=""1010"" cost=""1213,81"" />
			<batch id=""2"" amount=""10"" cycletime=""50"" cost=""1243,86"" />
			<batch id=""3"" amount=""10"" cycletime=""50"" cost=""1229,40"" />
			<batch id=""4"" amount=""10"" cycletime=""50"" cost=""1228,08"" />
			<batch id=""5"" amount=""10"" cycletime=""50"" cost=""1227,07"" />
			<batch id=""6"" amount=""10"" cycletime=""50"" cost=""1226,63"" />
			<batch id=""7"" amount=""10"" cycletime=""50"" cost=""1236,35"" />
			<batch id=""8"" amount=""10"" cycletime=""1040"" cost=""1247,24"" />
			<batch id=""9"" amount=""10"" cycletime=""80"" cost=""1304,25"" />
			<batch id=""10"" amount=""10"" cycletime=""50"" cost=""1278,67"" />
			<batch id=""11"" amount=""10"" cycletime=""50"" cost=""1274,81"" />
			<batch id=""12"" amount=""10"" cycletime=""50"" cost=""1264,92"" />
			<batch id=""13"" amount=""10"" cycletime=""50"" cost=""1244,92"" />
			<batch id=""14"" amount=""10"" cycletime=""1010"" cost=""1236,97"" />
			<batch id=""15"" amount=""10"" cycletime=""50"" cost=""1254,24"" />
			<batch id=""16"" amount=""10"" cycletime=""50"" cost=""1238,09"" />
			<batch id=""17"" amount=""10"" cycletime=""50"" cost=""1238,90"" />
			<batch id=""18"" amount=""10"" cycletime=""50"" cost=""1240,43"" />
			<batch id=""19"" amount=""10"" cycletime=""50"" cost=""1239,26"" />
			<batch id=""20"" amount=""10"" cycletime=""50"" cost=""1239,26"" />
			<batch id=""21"" amount=""10"" cycletime=""50"" cost=""1239,26"" />
			<batch id=""22"" amount=""10"" cycletime=""80"" cost=""1255,38"" />
			<batch id=""23"" amount=""10"" cycletime=""50"" cost=""1245,63"" />
		</order>
		<order period=""6"" id=""7"" item=""5"" quantity=""220"" cost=""8517,06"" averageunitcosts=""38,71"">
			<batch id=""1"" amount=""10"" cycletime=""100"" cost=""407,39"" />
			<batch id=""2"" amount=""10"" cycletime=""70"" cost=""384,89"" />
			<batch id=""3"" amount=""10"" cycletime=""70"" cost=""384,89"" />
			<batch id=""4"" amount=""10"" cycletime=""70"" cost=""384,89"" />
			<batch id=""5"" amount=""10"" cycletime=""70"" cost=""384,89"" />
			<batch id=""6"" amount=""10"" cycletime=""70"" cost=""384,89"" />
			<batch id=""7"" amount=""10"" cycletime=""70"" cost=""384,89"" />
			<batch id=""8"" amount=""10"" cycletime=""70"" cost=""384,89"" />
			<batch id=""9"" amount=""10"" cycletime=""70"" cost=""384,89"" />
			<batch id=""10"" amount=""10"" cycletime=""70"" cost=""384,89"" />
			<batch id=""11"" amount=""10"" cycletime=""1030"" cost=""384,89"" />
			<batch id=""12"" amount=""10"" cycletime=""1020"" cost=""390,62"" />
			<batch id=""13"" amount=""10"" cycletime=""1010"" cost=""399,62"" />
			<batch id=""14"" amount=""10"" cycletime=""1000"" cost=""399,62"" />
			<batch id=""15"" amount=""10"" cycletime=""990"" cost=""399,62"" />
			<batch id=""16"" amount=""10"" cycletime=""980"" cost=""381,62"" />
			<batch id=""17"" amount=""10"" cycletime=""150"" cost=""381,62"" />
			<batch id=""18"" amount=""10"" cycletime=""140"" cost=""381,62"" />
			<batch id=""19"" amount=""10"" cycletime=""130"" cost=""381,62"" />
			<batch id=""20"" amount=""10"" cycletime=""120"" cost=""381,62"" />
			<batch id=""21"" amount=""10"" cycletime=""110"" cost=""381,62"" />
			<batch id=""22"" amount=""10"" cycletime=""100"" cost=""381,62"" />
		</order>
		<order period=""6"" id=""8"" item=""11"" quantity=""120"" cost=""1812,82"" averageunitcosts=""15,11"">
			<batch id=""1"" amount=""10"" cycletime=""525"" cost=""195,32"" />
			<batch id=""2"" amount=""10"" cycletime=""535"" cost=""152,57"" />
			<batch id=""3"" amount=""10"" cycletime=""545"" cost=""152,57"" />
			<batch id=""4"" amount=""10"" cycletime=""555"" cost=""152,57"" />
			<batch id=""5"" amount=""10"" cycletime=""565"" cost=""152,57"" />
			<batch id=""6"" amount=""10"" cycletime=""575"" cost=""152,57"" />
			<batch id=""7"" amount=""10"" cycletime=""585"" cost=""152,57"" />
			<batch id=""8"" amount=""10"" cycletime=""1315"" cost=""145,82"" />
			<batch id=""9"" amount=""10"" cycletime=""1325"" cost=""139,07"" />
			<batch id=""10"" amount=""10"" cycletime=""1335"" cost=""139,07"" />
			<batch id=""11"" amount=""10"" cycletime=""1345"" cost=""139,07"" />
			<batch id=""12"" amount=""10"" cycletime=""1355"" cost=""139,07"" />
		</order>
		<order period=""6"" id=""9"" item=""54"" quantity=""260"" cost=""17822,85"" averageunitcosts=""68,55"">
			<batch id=""1"" amount=""10"" cycletime=""60"" cost=""665,63"" />
			<batch id=""2"" amount=""10"" cycletime=""60"" cost=""665,63"" />
			<batch id=""3"" amount=""10"" cycletime=""60"" cost=""676,15"" />
			<batch id=""4"" amount=""10"" cycletime=""60"" cost=""672,70"" />
			<batch id=""5"" amount=""10"" cycletime=""80"" cost=""729,71"" />
			<batch id=""6"" amount=""10"" cycletime=""60"" cost=""719,13"" />
			<batch id=""7"" amount=""10"" cycletime=""60"" cost=""715,28"" />
			<batch id=""8"" amount=""10"" cycletime=""60"" cost=""705,38"" />
			<batch id=""9"" amount=""10"" cycletime=""60"" cost=""685,38"" />
			<batch id=""10"" amount=""10"" cycletime=""60"" cost=""677,43"" />
			<batch id=""11"" amount=""10"" cycletime=""975"" cost=""694,70"" />
			<batch id=""12"" amount=""10"" cycletime=""60"" cost=""678,55"" />
			<batch id=""13"" amount=""10"" cycletime=""60"" cost=""679,37"" />
			<batch id=""14"" amount=""10"" cycletime=""60"" cost=""680,90"" />
			<batch id=""15"" amount=""10"" cycletime=""60"" cost=""679,72"" />
			<batch id=""16"" amount=""10"" cycletime=""60"" cost=""679,72"" />
			<batch id=""17"" amount=""10"" cycletime=""60"" cost=""679,72"" />
			<batch id=""18"" amount=""10"" cycletime=""60"" cost=""679,72"" />
			<batch id=""19"" amount=""10"" cycletime=""60"" cost=""681,97"" />
			<batch id=""20"" amount=""10"" cycletime=""975"" cost=""697,72"" />
			<batch id=""21"" amount=""10"" cycletime=""60"" cost=""679,72"" />
			<batch id=""22"" amount=""10"" cycletime=""60"" cost=""679,72"" />
			<batch id=""23"" amount=""10"" cycletime=""60"" cost=""679,72"" />
			<batch id=""24"" amount=""10"" cycletime=""60"" cost=""679,72"" />
			<batch id=""25"" amount=""10"" cycletime=""60"" cost=""679,72"" />
			<batch id=""26"" amount=""10"" cycletime=""60"" cost=""679,72"" />
		</order>
		<order period=""6"" id=""10"" item=""8"" quantity=""220"" cost=""7693,77"" averageunitcosts=""34,97"">
			<batch id=""1"" amount=""10"" cycletime=""110"" cost=""373,85"" />
			<batch id=""2"" amount=""10"" cycletime=""80"" cost=""343,85"" />
			<batch id=""3"" amount=""10"" cycletime=""70"" cost=""343,85"" />
			<batch id=""4"" amount=""10"" cycletime=""1030"" cost=""343,85"" />
			<batch id=""5"" amount=""10"" cycletime=""1020"" cost=""352,85"" />
			<batch id=""6"" amount=""10"" cycletime=""1010"" cost=""361,85"" />
			<batch id=""7"" amount=""10"" cycletime=""1000"" cost=""361,85"" />
			<batch id=""8"" amount=""10"" cycletime=""990"" cost=""361,85"" />
			<batch id=""9"" amount=""10"" cycletime=""980"" cost=""343,85"" />
			<batch id=""10"" amount=""10"" cycletime=""150"" cost=""343,85"" />
			<batch id=""11"" amount=""10"" cycletime=""140"" cost=""343,85"" />
			<batch id=""12"" amount=""10"" cycletime=""130"" cost=""343,85"" />
			<batch id=""13"" amount=""10"" cycletime=""120"" cost=""343,85"" />
			<batch id=""14"" amount=""10"" cycletime=""110"" cost=""343,85"" />
			<batch id=""15"" amount=""10"" cycletime=""100"" cost=""343,85"" />
			<batch id=""16"" amount=""10"" cycletime=""90"" cost=""343,85"" />
			<batch id=""17"" amount=""10"" cycletime=""80"" cost=""343,85"" />
			<batch id=""18"" amount=""10"" cycletime=""70"" cost=""343,85"" />
			<batch id=""19"" amount=""10"" cycletime=""70"" cost=""343,85"" />
			<batch id=""20"" amount=""10"" cycletime=""1030"" cost=""343,85"" />
			<batch id=""21"" amount=""10"" cycletime=""1020"" cost=""361,85"" />
			<batch id=""22"" amount=""10"" cycletime=""1010"" cost=""361,85"" />
		</order>
		<order period=""6"" id=""11"" item=""14"" quantity=""220"" cost=""3184,01"" averageunitcosts=""14,47"">
			<batch id=""1"" amount=""10"" cycletime=""1380"" cost=""184,07"" />
			<batch id=""2"" amount=""10"" cycletime=""1390"" cost=""130,07"" />
			<batch id=""3"" amount=""10"" cycletime=""1400"" cost=""134,57"" />
			<batch id=""4"" amount=""10"" cycletime=""1410"" cost=""141,32"" />
			<batch id=""5"" amount=""10"" cycletime=""1420"" cost=""130,07"" />
			<batch id=""6"" amount=""10"" cycletime=""1430"" cost=""156,32"" />
			<batch id=""7"" amount=""10"" cycletime=""1440"" cost=""130,07"" />
			<batch id=""8"" amount=""10"" cycletime=""1450"" cost=""130,07"" />
			<batch id=""9"" amount=""10"" cycletime=""1460"" cost=""130,07"" />
			<batch id=""10"" amount=""10"" cycletime=""1470"" cost=""130,07"" />
			<batch id=""11"" amount=""10"" cycletime=""1480"" cost=""130,07"" />
			<batch id=""12"" amount=""10"" cycletime=""1490"" cost=""143,57"" />
			<batch id=""13"" amount=""10"" cycletime=""1500"" cost=""169,82"" />
			<batch id=""14"" amount=""10"" cycletime=""550"" cost=""143,57"" />
			<batch id=""15"" amount=""10"" cycletime=""560"" cost=""148,07"" />
			<batch id=""16"" amount=""10"" cycletime=""570"" cost=""152,57"" />
			<batch id=""17"" amount=""10"" cycletime=""580"" cost=""152,57"" />
			<batch id=""18"" amount=""10"" cycletime=""590"" cost=""152,57"" />
			<batch id=""19"" amount=""10"" cycletime=""600"" cost=""159,32"" />
			<batch id=""20"" amount=""10"" cycletime=""1465"" cost=""175,07"" />
			<batch id=""21"" amount=""10"" cycletime=""1475"" cost=""130,07"" />
			<batch id=""22"" amount=""10"" cycletime=""1485"" cost=""130,07"" />
		</order>
		<order period=""6"" id=""12"" item=""19"" quantity=""220"" cost=""3488,19"" averageunitcosts=""15,86"">
			<batch id=""1"" amount=""10"" cycletime=""2485"" cost=""234,46"" />
			<batch id=""2"" amount=""10"" cycletime=""2460"" cost=""158,46"" />
			<batch id=""3"" amount=""10"" cycletime=""1490"" cost=""173,46"" />
			<batch id=""4"" amount=""10"" cycletime=""1480"" cost=""216,21"" />
			<batch id=""5"" amount=""10"" cycletime=""1470"" cost=""148,71"" />
			<batch id=""6"" amount=""10"" cycletime=""1585"" cost=""164,71"" />
			<batch id=""7"" amount=""10"" cycletime=""1575"" cost=""173,46"" />
			<batch id=""8"" amount=""10"" cycletime=""1565"" cost=""139,71"" />
			<batch id=""9"" amount=""10"" cycletime=""1555"" cost=""139,71"" />
			<batch id=""10"" amount=""10"" cycletime=""1545"" cost=""139,71"" />
			<batch id=""11"" amount=""10"" cycletime=""1535"" cost=""139,71"" />
			<batch id=""12"" amount=""10"" cycletime=""1525"" cost=""139,71"" />
			<batch id=""13"" amount=""10"" cycletime=""1515"" cost=""139,71"" />
			<batch id=""14"" amount=""10"" cycletime=""1505"" cost=""139,71"" />
			<batch id=""15"" amount=""10"" cycletime=""1500"" cost=""139,71"" />
			<batch id=""16"" amount=""10"" cycletime=""1500"" cost=""139,71"" />
			<batch id=""17"" amount=""10"" cycletime=""1500"" cost=""153,21"" />
			<batch id=""18"" amount=""10"" cycletime=""1500"" cost=""166,71"" />
			<batch id=""19"" amount=""10"" cycletime=""540"" cost=""171,21"" />
			<batch id=""20"" amount=""10"" cycletime=""540"" cost=""171,21"" />
			<batch id=""21"" amount=""10"" cycletime=""1460"" cost=""159,21"" />
			<batch id=""22"" amount=""10"" cycletime=""1450"" cost=""139,71"" />
		</order>
		<order period=""6"" id=""13"" item=""3"" quantity=""90"" cost=""15285,62"" averageunitcosts=""169,84"">
			<batch id=""1"" amount=""10"" cycletime=""100"" cost=""1698,26"" />
			<batch id=""2"" amount=""10"" cycletime=""940"" cost=""1711,76"" />
			<batch id=""3"" amount=""10"" cycletime=""70"" cost=""1683,26"" />
			<batch id=""4"" amount=""10"" cycletime=""100"" cost=""1725,26"" />
			<batch id=""5"" amount=""10"" cycletime=""910"" cost=""1710,26"" />
			<batch id=""6"" amount=""10"" cycletime=""70"" cost=""1683,26"" />
			<batch id=""7"" amount=""10"" cycletime=""70"" cost=""1683,26"" />
			<batch id=""8"" amount=""10"" cycletime=""70"" cost=""1696,61"" />
			<batch id=""9"" amount=""10"" cycletime=""70"" cost=""1693,69"" />
		</order>
		<order period=""6"" id=""14"" item=""26"" quantity=""90"" cost=""1082,75"" averageunitcosts=""12,03"">
			<batch id=""1"" amount=""10"" cycletime=""125"" cost=""141,14"" />
			<batch id=""2"" amount=""10"" cycletime=""1530"" cost=""141,14"" />
			<batch id=""3"" amount=""10"" cycletime=""1450"" cost=""133,64"" />
			<batch id=""4"" amount=""10"" cycletime=""1430"" cost=""111,14"" />
			<batch id=""5"" amount=""10"" cycletime=""1440"" cost=""111,14"" />
			<batch id=""6"" amount=""10"" cycletime=""1450"" cost=""111,14"" />
			<batch id=""7"" amount=""10"" cycletime=""1460"" cost=""111,14"" />
			<batch id=""8"" amount=""10"" cycletime=""1470"" cost=""111,14"" />
			<batch id=""9"" amount=""10"" cycletime=""1480"" cost=""111,14"" />
		</order>
		<order period=""6"" id=""15"" item=""31"" quantity=""80"" cost=""11841,80"" averageunitcosts=""148,02"">
			<batch id=""1"" amount=""10"" cycletime=""1025"" cost=""1488,88"" />
			<batch id=""2"" amount=""10"" cycletime=""80"" cost=""1482,13"" />
			<batch id=""3"" amount=""10"" cycletime=""60"" cost=""1472,60"" />
			<batch id=""4"" amount=""10"" cycletime=""80"" cost=""1487,25"" />
			<batch id=""5"" amount=""10"" cycletime=""60"" cost=""1476,98"" />
			<batch id=""6"" amount=""10"" cycletime=""60"" cost=""1476,98"" />
			<batch id=""7"" amount=""10"" cycletime=""60"" cost=""1478,49"" />
			<batch id=""8"" amount=""10"" cycletime=""60"" cost=""1478,49"" />
		</order>
		<order period=""6"" id=""16"" item=""16"" quantity=""70"" cost=""493,79"" averageunitcosts=""7,05"">
			<batch id=""1"" amount=""10"" cycletime=""65"" cost=""80,18"" />
			<batch id=""2"" amount=""10"" cycletime=""60"" cost=""68,93"" />
			<batch id=""3"" amount=""10"" cycletime=""70"" cost=""68,93"" />
			<batch id=""4"" amount=""10"" cycletime=""80"" cost=""68,93"" />
			<batch id=""5"" amount=""10"" cycletime=""90"" cost=""68,93"" />
			<batch id=""6"" amount=""10"" cycletime=""100"" cost=""68,93"" />
			<batch id=""7"" amount=""10"" cycletime=""110"" cost=""68,93"" />
		</order>
		<order period=""6"" id=""17"" item=""17"" quantity=""70"" cost=""573,89"" averageunitcosts=""8,20"">
			<batch id=""1"" amount=""10"" cycletime=""45"" cost=""85,52"" />
			<batch id=""2"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""3"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""4"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""5"" amount=""10"" cycletime=""30"" cost=""78,02"" />
			<batch id=""6"" amount=""10"" cycletime=""30"" cost=""84,77"" />
			<batch id=""7"" amount=""10"" cycletime=""30"" cost=""91,52"" />
		</order>
		<order period=""6"" id=""18"" item=""30"" quantity=""70"" cost=""9097,75"" averageunitcosts=""129,97"">
			<batch id=""1"" amount=""10"" cycletime=""70"" cost=""1296,45"" />
			<batch id=""2"" amount=""10"" cycletime=""50"" cost=""1286,45"" />
			<batch id=""3"" amount=""10"" cycletime=""50"" cost=""1294,60"" />
			<batch id=""4"" amount=""10"" cycletime=""50"" cost=""1298,22"" />
			<batch id=""5"" amount=""10"" cycletime=""50"" cost=""1300,94"" />
			<batch id=""6"" amount=""10"" cycletime=""1030"" cost=""1317,97"" />
			<batch id=""7"" amount=""10"" cycletime=""70"" cost=""1303,12"" />
		</order>
		<order period=""6"" id=""19"" item=""6"" quantity=""60"" cost=""2407,86"" averageunitcosts=""40,13"">
			<batch id=""1"" amount=""10"" cycletime=""1020"" cost=""448,81"" />
			<batch id=""2"" amount=""10"" cycletime=""990"" cost=""391,81"" />
			<batch id=""3"" amount=""10"" cycletime=""160"" cost=""391,81"" />
			<batch id=""4"" amount=""10"" cycletime=""150"" cost=""391,81"" />
			<batch id=""5"" amount=""10"" cycletime=""140"" cost=""391,81"" />
			<batch id=""6"" amount=""10"" cycletime=""130"" cost=""391,81"" />
		</order>
		<order period=""6"" id=""20"" item=""12"" quantity=""60"" cost=""841,16"" averageunitcosts=""14,02"">
			<batch id=""1"" amount=""10"" cycletime=""3045"" cost=""175,07"" />
			<batch id=""2"" amount=""10"" cycletime=""3055"" cost=""130,07"" />
			<batch id=""3"" amount=""10"" cycletime=""3065"" cost=""130,07"" />
			<batch id=""4"" amount=""10"" cycletime=""3075"" cost=""130,07"" />
			<batch id=""5"" amount=""10"" cycletime=""3085"" cost=""132,32"" />
			<batch id=""6"" amount=""10"" cycletime=""3095"" cost=""143,57"" />
		</order>
		<order period=""6"" id=""21"" item=""29"" quantity=""60"" cost=""4401,21"" averageunitcosts=""73,35"">
			<batch id=""1"" amount=""10"" cycletime=""80"" cost=""740,17"" />
			<batch id=""2"" amount=""10"" cycletime=""60"" cost=""730,17"" />
			<batch id=""3"" amount=""10"" cycletime=""60"" cost=""730,17"" />
			<batch id=""4"" amount=""10"" cycletime=""60"" cost=""730,17"" />
			<batch id=""5"" amount=""10"" cycletime=""60"" cost=""730,17"" />
			<batch id=""6"" amount=""10"" cycletime=""80"" cost=""740,36"" />
		</order>
		<order period=""6"" id=""22"" item=""9"" quantity=""50"" cost=""1800,22"" averageunitcosts=""36,00"">
			<batch id=""1"" amount=""10"" cycletime=""140"" cost=""384,04"" />
			<batch id=""2"" amount=""10"" cycletime=""110"" cost=""354,04"" />
			<batch id=""3"" amount=""10"" cycletime=""100"" cost=""354,04"" />
			<batch id=""4"" amount=""10"" cycletime=""90"" cost=""354,04"" />
			<batch id=""5"" amount=""10"" cycletime=""80"" cost=""354,04"" />
		</order>
		<order period=""6"" id=""23"" item=""15"" quantity=""50"" cost=""796,59"" averageunitcosts=""15,93"">
			<batch id=""1"" amount=""10"" cycletime=""3120"" cost=""195,32"" />
			<batch id=""2"" amount=""10"" cycletime=""3130"" cost=""143,57"" />
			<batch id=""3"" amount=""10"" cycletime=""3140"" cost=""152,57"" />
			<batch id=""4"" amount=""10"" cycletime=""3150"" cost=""152,57"" />
			<batch id=""5"" amount=""10"" cycletime=""3160"" cost=""152,57"" />
		</order>
		<order period=""6"" id=""24"" item=""20"" quantity=""50"" cost=""885,91"" averageunitcosts=""17,72"">
			<batch id=""1"" amount=""10"" cycletime=""1850"" cost=""244,58"" />
			<batch id=""2"" amount=""10"" cycletime=""2545"" cost=""162,08"" />
			<batch id=""3"" amount=""10"" cycletime=""2535"" cost=""159,75"" />
			<batch id=""4"" amount=""10"" cycletime=""2525"" cost=""159,75"" />
			<batch id=""5"" amount=""10"" cycletime=""2515"" cost=""159,75"" />
		</order>
		<order period=""6"" id=""25"" item=""1"" quantity=""40"" cost=""6765,92"" averageunitcosts=""169,15"">
			<batch id=""1"" amount=""10"" cycletime=""90"" cost=""1696,49"" />
			<batch id=""2"" amount=""10"" cycletime=""60"" cost=""1681,06"" />
			<batch id=""3"" amount=""10"" cycletime=""60"" cost=""1687,27"" />
			<batch id=""4"" amount=""10"" cycletime=""60"" cost=""1701,10"" />
		</order>
		<order period=""6"" id=""27"" item=""51"" quantity=""20"" cost=""2919,32"" averageunitcosts=""145,97"">
			<batch id=""1"" amount=""10"" cycletime=""70"" cost=""1463,80"" />
			<batch id=""2"" amount=""10"" cycletime=""50"" cost=""1455,52"" />
		</order>
		<order period=""6"" id=""28"" item=""16"" quantity=""80"" cost=""562,72"" averageunitcosts=""7,03"">
			<batch id=""1"" amount=""10"" cycletime=""1025"" cost=""80,18"" />
			<batch id=""2"" amount=""10"" cycletime=""60"" cost=""68,93"" />
			<batch id=""3"" amount=""10"" cycletime=""70"" cost=""68,93"" />
			<batch id=""4"" amount=""10"" cycletime=""80"" cost=""68,93"" />
			<batch id=""5"" amount=""10"" cycletime=""90"" cost=""68,93"" />
			<batch id=""6"" amount=""10"" cycletime=""100"" cost=""68,93"" />
			<batch id=""7"" amount=""10"" cycletime=""110"" cost=""68,93"" />
			<batch id=""8"" amount=""10"" cycletime=""120"" cost=""68,93"" />
		</order>
		<order period=""6"" id=""30"" item=""50"" quantity=""80"" cost=""10228,56"" averageunitcosts=""127,86"">
			<batch id=""1"" amount=""10"" cycletime=""80"" cost=""1282,38"" />
			<batch id=""2"" amount=""10"" cycletime=""50"" cost=""1267,38"" />
			<batch id=""3"" amount=""10"" cycletime=""80"" cost=""1282,38"" />
			<batch id=""4"" amount=""10"" cycletime=""80"" cost=""1288,43"" />
			<batch id=""5"" amount=""10"" cycletime=""50"" cost=""1272,22"" />
			<batch id=""6"" amount=""10"" cycletime=""80"" cost=""1320,09"" />
			<batch id=""7"" amount=""10"" cycletime=""50"" cost=""1257,84"" />
			<batch id=""8"" amount=""10"" cycletime=""50"" cost=""1257,84"" />
		</order>
		<order period=""6"" id=""31"" item=""4"" quantity=""70"" cost=""2846,54"" averageunitcosts=""40,66"">
			<batch id=""1"" amount=""10"" cycletime=""1060"" cost=""416,93"" />
			<batch id=""2"" amount=""10"" cycletime=""1030"" cost=""412,43"" />
			<batch id=""3"" amount=""10"" cycletime=""1020"" cost=""412,43"" />
			<batch id=""4"" amount=""10"" cycletime=""1010"" cost=""412,43"" />
			<batch id=""5"" amount=""10"" cycletime=""1000"" cost=""403,43"" />
			<batch id=""6"" amount=""10"" cycletime=""170"" cost=""394,43"" />
			<batch id=""7"" amount=""10"" cycletime=""160"" cost=""394,43"" />
		</order>
		<order period=""6"" id=""32"" item=""10"" quantity=""70"" cost=""936,18"" averageunitcosts=""13,37"">
			<batch id=""1"" amount=""10"" cycletime=""4175"" cost=""174,24"" />
			<batch id=""2"" amount=""10"" cycletime=""4185"" cost=""126,99"" />
			<batch id=""3"" amount=""10"" cycletime=""4195"" cost=""126,99"" />
			<batch id=""4"" amount=""10"" cycletime=""4205"" cost=""126,99"" />
			<batch id=""5"" amount=""10"" cycletime=""3255"" cost=""126,99"" />
			<batch id=""6"" amount=""10"" cycletime=""3265"" cost=""126,99"" />
			<batch id=""7"" amount=""10"" cycletime=""3275"" cost=""126,99"" />
		</order>
		<order period=""6"" id=""33"" item=""49"" quantity=""40"" cost=""2792,47"" averageunitcosts=""69,81"">
			<batch id=""1"" amount=""10"" cycletime=""80"" cost=""700,56"" />
			<batch id=""2"" amount=""10"" cycletime=""60"" cost=""697,31"" />
			<batch id=""3"" amount=""10"" cycletime=""975"" cost=""704,06"" />
			<batch id=""4"" amount=""10"" cycletime=""60"" cost=""690,56"" />
		</order>
		<order period=""6"" id=""34"" item=""7"" quantity=""60"" cost=""2170,00"" averageunitcosts=""36,17"">
			<batch id=""1"" amount=""10"" cycletime=""170"" cost=""386,67"" />
			<batch id=""2"" amount=""10"" cycletime=""140"" cost=""356,67"" />
			<batch id=""3"" amount=""10"" cycletime=""130"" cost=""356,67"" />
			<batch id=""4"" amount=""10"" cycletime=""120"" cost=""356,67"" />
			<batch id=""5"" amount=""10"" cycletime=""110"" cost=""356,67"" />
			<batch id=""6"" amount=""10"" cycletime=""100"" cost=""356,67"" />
		</order>
		<order period=""6"" id=""35"" item=""13"" quantity=""60"" cost=""867,69"" averageunitcosts=""14,46"">
			<batch id=""1"" amount=""10"" cycletime=""3300"" cost=""183,24"" />
			<batch id=""2"" amount=""10"" cycletime=""3310"" cost=""135,99"" />
			<batch id=""3"" amount=""10"" cycletime=""3320"" cost=""135,99"" />
			<batch id=""4"" amount=""10"" cycletime=""3330"" cost=""135,99"" />
			<batch id=""5"" amount=""10"" cycletime=""3340"" cost=""135,99"" />
			<batch id=""6"" amount=""10"" cycletime=""3350"" cost=""140,49"" />
		</order>
		<order period=""6"" id=""36"" item=""18"" quantity=""20"" cost=""368,79"" averageunitcosts=""18,44"">
			<batch id=""1"" amount=""10"" cycletime=""1960"" cost=""222,27"" />
			<batch id=""2"" amount=""10"" cycletime=""1935"" cost=""146,52"" />
		</order>
	</completedorders>
	<cycletimes startedorders=""5"" waitingorders=""2"">
		<order id=""25"" period=""5"" starttime=""5-5-9-20"" finishtime=""6-1-0-45"" cycletimemin=""95"" cycletimefactor=""9,74"" />
		<order id=""23"" period=""5"" starttime=""5-3-2-40"" finishtime=""6-1-4-30"" cycletimemin=""410"" cycletimefactor=""10,80"" />
		<order id=""24"" period=""5"" starttime=""5-3-3-55"" finishtime=""6-1-7-50"" cycletimemin=""380"" cycletimefactor=""11,99"" />
		<order id=""18"" period=""5"" starttime=""5-1-5-30"" finishtime=""6-1-8-0"" cycletimemin=""680"" cycletimefactor=""10,81"" />
		<order id=""21"" period=""5"" starttime=""5-1-6-20"" finishtime=""6-2-1-55"" cycletimemin=""680"" cycletimefactor=""12,32"" />
		<order id=""8"" period=""6"" starttime=""6-1-0-0"" finishtime=""6-2-2-15"" cycletimemin=""500"" cycletimefactor=""3,15"" />
		<order id=""2"" period=""6"" starttime=""6-1-0-0"" finishtime=""6-2-2-45"" cycletimemin=""725"" cycletimefactor=""2,21"" />
		<order id=""4"" period=""6"" starttime=""6-1-0-0"" finishtime=""6-2-3-5"" cycletimemin=""665"" cycletimefactor=""2,44"" />
		<order id=""7"" period=""6"" starttime=""6-1-0-0"" finishtime=""6-2-5-40"" cycletimemin=""930"" cycletimefactor=""1,91"" />
		<order id=""11"" period=""6"" starttime=""6-1-4-0"" finishtime=""6-3-3-45"" cycletimemin=""800"" cycletimefactor=""3,58"" />
		<order id=""16"" period=""6"" starttime=""6-3-2-30"" finishtime=""6-3-6-35"" cycletimemin=""245"" cycletimefactor=""1,00"" />
		<order id=""10"" period=""6"" starttime=""6-2-4-40"" finishtime=""6-4-1-30"" cycletimemin=""930"" cycletimefactor=""2,89"" />
		<order id=""12"" period=""6"" starttime=""6-1-7-15"" finishtime=""6-4-2-10"" cycletimemin=""770"" cycletimefactor=""5,21"" />
		<order id=""28"" period=""6"" starttime=""6-3-7-50"" finishtime=""6-4-4-25"" cycletimemin=""275"" cycletimefactor=""4,49"" />
		<order id=""19"" period=""6"" starttime=""6-3-9-20"" finishtime=""6-4-4-50"" cycletimemin=""290"" cycletimefactor=""4,03"" />
		<order id=""1"" period=""6"" starttime=""6-1-0-0"" finishtime=""6-4-7-20"" cycletimemin=""1560"" cycletimefactor=""3,05"" />
		<order id=""22"" period=""6"" starttime=""6-4-3-20"" finishtime=""6-4-7-40"" cycletimemin=""250"" cycletimefactor=""1,04"" />
		<order id=""20"" period=""6"" starttime=""6-2-3-20"" finishtime=""6-4-8-35"" cycletimemin=""320"" cycletimefactor=""9,98"" />
		<order id=""23"" period=""6"" starttime=""6-2-5-20"" finishtime=""6-4-11-20"" cycletimemin=""290"" cycletimefactor=""11,17"" />
		<order id=""3"" period=""6"" starttime=""6-1-0-0"" finishtime=""6-5-0-30"" cycletimemin=""1340"" cycletimefactor=""4,32"" />
		<order id=""5"" period=""6"" starttime=""6-2-2-45"" finishtime=""6-5-0-45"" cycletimemin=""645"" cycletimefactor=""6,51"" />
		<order id=""24"" period=""6"" starttime=""6-3-5-5"" finishtime=""6-5-1-15"" cycletimemin=""255"" cycletimefactor=""10,39"" />
		<order id=""6"" period=""6"" starttime=""6-1-8-0"" finishtime=""6-5-2-15"" cycletimemin=""1180"" cycletimefactor=""4,59"" />
		<order id=""18"" period=""6"" starttime=""6-1-0-0"" finishtime=""6-5-3-25"" cycletimemin=""370"" cycletimefactor=""16,12"" />
		<order id=""31"" period=""6"" starttime=""6-4-7-0"" finishtime=""6-5-3-40"" cycletimemin=""330"" cycletimefactor=""3,76"" />
		<order id=""13"" period=""6"" starttime=""6-3-5-10"" finishtime=""6-5-4-50"" cycletimemin=""660"" cycletimefactor=""4,33"" />
		<order id=""14"" period=""6"" starttime=""6-2-2-40"" finishtime=""6-5-5-0"" cycletimemin=""335"" cycletimefactor=""13,31"" />
		<order id=""15"" period=""6"" starttime=""6-2-8-0"" finishtime=""6-5-5-50"" cycletimemin=""500"" cycletimefactor=""8,38"" />
		<order id=""34"" period=""6"" starttime=""6-5-1-40"" finishtime=""6-5-7-0"" cycletimemin=""290"" cycletimefactor=""1,10"" />
		<order id=""30"" period=""6"" starttime=""6-1-4-30"" finishtime=""6-5-7-35"" cycletimemin=""430"" cycletimefactor=""13,83"" />
		<order id=""32"" period=""6"" starttime=""6-2-7-0"" finishtime=""6-5-7-35"" cycletimemin=""340"" cycletimefactor=""12,81"" />
		<order id=""21"" period=""6"" starttime=""6-1-0-0"" finishtime=""6-5-7-40"" cycletimemin=""380"" cycletimefactor=""16,37"" />
		<order id=""17"" period=""6"" starttime=""6-5-5-0"" finishtime=""6-5-8-45"" cycletimemin=""225"" cycletimefactor=""1,00"" />
		<order id=""35"" period=""6"" starttime=""6-3-1-20"" finishtime=""6-5-10-50"" cycletimemin=""310"" cycletimefactor=""11,13"" />
	</cycletimes>
	<result>
		<general>
			<capacity current=""33600"" average=""33600,00"" all=""201600"" />
			<possiblecapacity current=""38350"" average=""36104,17"" all=""216625"" />
			<relpossiblenormalcapacity current=""114,14%"" average=""107,45%"" all=""-"" />
			<productivetime current=""30630"" average=""26241,67"" all=""157450"" />
			<effiency current=""79,87%"" average=""72,68%"" all=""-"" />
			<sellwish current=""500"" average=""400,00"" all=""2400"" />
			<salesquantity current=""490"" average=""398,33"" all=""2390"" />
			<deliveryreliability current=""98,00%"" average=""99,58%"" all=""-"" />
			<idletime current=""7720"" average=""9862,50"" all=""59175"" />
			<idletimecosts current=""4612,80"" average=""5386,00"" all=""32316,00"" />
			<storevalue current=""208878,00"" average=""243425,00"" all=""-"" />
			<storagecosts current=""1253,27"" average=""3995,57"" all=""23973,40"" />
		</general>
		<defectivegoods>
			<quantity current=""0"" average=""0,00"" all=""0"" />
			<costs current=""0,00"" average=""0,00"" all=""0,00"" />
		</defectivegoods>
		<normalsale>
			<salesprice current=""200,00"" average=""200,00"" all=""-"" />
			<profit current=""10143,60"" average=""4869,33"" all=""29216,00"" />
			<profitperunit current=""20,70"" average=""12,22"" all=""-"" />
		</normalsale>
		<directsale>
			<profit current=""0,00"" average=""0,00"" all=""0,00"" />
			<contractpenalty current=""0,00"" average=""0,00"" all=""0,00"" />
		</directsale>
		<marketplacesale>
			<profit current=""0,00"" average=""0,00"" all=""0,00"" />
		</marketplacesale>
		<summary>
			<profit current=""10143,60"" average=""4869,33"" all=""29216,00"" />
		</summary>
	</result>
</results>";
        #endregion
    }
}
