using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static {
    static class Static {

        #region XMLInput
        private static string _XMLInputPeriode1 = @"<input>
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
</input>";

        private static string _XMLInputPeriode2 = @"<input>
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
</input>";
        #endregion

        public static String XMLInputPeriode1 { get { return _XMLInputPeriode1; } }

        public static String XMLInputPeriode2 { get { return _XMLInputPeriode2; } }
    }
}
