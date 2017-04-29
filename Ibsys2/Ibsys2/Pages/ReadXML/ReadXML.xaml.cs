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
using Ibsys2.Static.Output;

namespace Ibsys2.Pages.ReadXML {
    /// <summary>
    /// Interaktionslogik für ReadXML.xaml
    /// </summary>
    public partial class ReadXML : Page {
        public ReadXML() {
            InitializeComponent();
        }


        public void KlickAufDateiUpload() {
            //if File Exists
            this.ParseXML(Static.Static.XMLInputPeriode1);
        }

        public void KlickAufTextUpload() {
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

            foreach (XmlNode GreatNode in doc.DocumentElement.ChildNodes) {
                foreach (XmlNode node in GreatNode) {
                    if (GreatNode.Name == "sellwish") {
                        Sellwish.setAnzahlArtikel(Convert.ToInt32(node.Attributes["article"].InnerText), Convert.ToInt32(node.Attributes["quantity"].InnerText));
                    }
                    else if(GreatNode.Name == "selldirect") {
                        Selldirect.setAnzahlArtikel(Convert.ToInt32(node.Attributes["article"].InnerText), Convert.ToInt32(node.Attributes["quantity"].InnerText), Convert.ToDouble(node.Attributes["quantity"].InnerText), Convert.ToDouble(node.Attributes["penalty"].InnerText));
                    } 
                    else if (GreatNode.Name == "orderlist") {
                        Orderlist.AddItem(new OrderlistItem(Convert.ToInt32(node.Attributes["article"].InnerText), Convert.ToInt32(node.Attributes["quantity"].InnerText), Convert.ToInt32(node.Attributes["modus"].InnerText)));
                    }
                    else if(GreatNode.Name == "productionlist") {
                        Productionlist.AddItem(new ProductionlistItem(Convert.ToInt32(node.Attributes["article"].InnerText), Convert.ToInt32(node.Attributes["quantity"].InnerText)));
                    } 
                    else if (GreatNode.Name == "workingtimelist") {
                        Workingtimelist.AddItem(new WorkingtimelistItem(Convert.ToInt32(node.Attributes["station"].InnerText), Convert.ToInt32(node.Attributes["shift"].InnerText), Convert.ToInt32(node.Attributes["overtime"].InnerText)));
                    }
                }
            }
        }
    }
}
