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
using Ibsys2.Static.Output;

namespace Ibsys2.Pages.CreateXML {
    /// <summary>
    /// Interaktionslogik für CreateXML.xaml
    /// </summary>
    public partial class CreateXML : Page {
        public CreateXML() {
            InitializeComponent();
        }

        public string GenerateXMLData() {
            string XMLOutput = "<input>";
            XMLOutput += Qualitycontrol.XMLOutput();
            XMLOutput += Sellwish.XMLOutput();
            XMLOutput += Selldirect.XMLOutput();
            XMLOutput += Orderlist.XMLOutput();
            XMLOutput += Productionlist.XMLOutput();
            XMLOutput += Workingtimelist.XMLOutput();
            return XMLOutput + "</input>";
        }
    }
}
