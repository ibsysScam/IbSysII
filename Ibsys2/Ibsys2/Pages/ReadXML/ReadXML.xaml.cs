using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Ibsys2.Static;
using Ibsys2.Static.Input;

namespace Ibsys2.Pages.ReadXML {
    /// <summary>
    /// Interaktionslogik für ReadXML.xaml
    /// </summary>
    public partial class ReadXML : Page {
        public ReadXML() {
            InitializeComponent();
        }


        private void KlickAufDateiUpload() {
            //if File Exists
            this.ParseXML(Static.Static.XMLInputPeriode1);
        }

        private void KlickAufTextUpload() {
            //If not Null

            this.ParseXML(Static.Static.XMLInputPeriode2);
        }

        private void ParseXML(string XMLinput) {
            if (String.IsNullOrEmpty(XMLinput))
                throw new ArgumentNullException();

            //http://stackoverflow.com/questions/642293/how-do-i-read-and-parse-an-xml-file-in-c

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(XMLinput);


            /* Aufbau:
             * <input>
             * <qualitycontrol type="no" losequantity="0" delay="0"/>
             * <sellwish><item article="[1-3]"  quantity="[0-999999]"/></sellwish>
             * <selldirect><item article="[1-3]" quantity="0" price="0.0" penalty="0.0"/></selldirect>
             * <orderlist><order article="[1-99]" quantity="[0-999999]" modus="[0-999999]"/></orderlist>
             * <productionlist><production article="[1-99]" quantity="[0-999999]"/></productionlist>
             * <workingtimelist><workingtime station="[1-99]" shift="[1-9]" overtime="[0-999999]"/></workingtimelist>
             * </input> */

            XmlNode qualitycontrol = doc.DocumentElement.SelectSingleNode("/input/qualitycontrol");
            XmlNodeList sellwish = doc.DocumentElement.SelectNodes("/input/sellwish");
            XmlNodeList selldirect = doc.DocumentElement.SelectNodes("/input/selldirect");
            XmlNodeList orderlist = doc.DocumentElement.SelectNodes("/input/orderlist");
            XmlNodeList productionlist = doc.DocumentElement.SelectNodes("/input/productionlist");
            XmlNodeList workingtimelist = doc.DocumentElement.SelectNodes("/input/workingtimelist");

            Qualitycontrol.typ = qualitycontrol.Attributes["type"].InnerText;
            Qualitycontrol.losequantity = Convert.ToInt32(qualitycontrol.Attributes["losequantity"].InnerText);
            Qualitycontrol.delay = Convert.ToInt32(qualitycontrol.Attributes["delay"].InnerText);

            foreach (XmlNode article in sellwish) {
                Sellwish.setAnzahlArtikel(Convert.ToInt32(article.Attributes["article"].InnerText), Convert.ToInt32(article.Attributes["quantity"].InnerText));
            }

        }
    }
}
