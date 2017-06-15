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
using System.IO;
using Ibsys2.Pages;
using Ibsys2.Service;
using Ibsys2.Pages.Wiki;
using Ibsys2.Static.Input;
using Ibsys2.Static.Output;
using System.Text.RegularExpressions;
using UIFeautures;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.WindowsAPICodePack.Shell;


namespace Ibsys2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow : Window
    {
       

        private static MainWindow _class;
        UIFeatures Ui = new UIFeatures();

        public static MainWindow Class
        {
            get
            {
                if (_class == null)
                    new MainWindow();
                return _class;
            }
        }
        public MainWindow()
        {
           
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            SettingsService.Class.CreateFolder();
            SettingsService.Class.LoadSettings();

            InitializeComponent();
            LoadTranslations();

            bool found = false;
            if (found == false)
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                foreach (string xmlFilePath in Directory.GetFiles(folder, "resultServlet.xml"))
                {

                    Pathtextbox.Text = xmlFilePath;
                    checkMalformedXML();
                    found = true;

                    break;
                }

            }

            if (found == false)
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                foreach (string xmlFilePath in Directory.GetFiles(folder, "resultServlet.xml"))
                {

                    Pathtextbox.Text = xmlFilePath;
                    checkMalformedXML();
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                foreach (string xmlFilePath in Directory.GetFiles(folder, "resultServlet.xml"))
                {

                    Pathtextbox.Text = xmlFilePath;
                    checkMalformedXML();
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                foreach (string xmlFilePath in Directory.GetFiles(folder, "resultServlet.xml"))
                {

                    Pathtextbox.Text = xmlFilePath;
                    checkMalformedXML();
                    found = true;
                    break;
                }
            }


            if (found == false)
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                foreach (string xmlFilePath in Directory.GetFiles(folder, "resultServlet.xml"))
                {

                    Pathtextbox.Text = xmlFilePath;
                    checkMalformedXML();
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                string folder = KnownFolders.Downloads.Path;
                foreach (string xmlFilePath in Directory.GetFiles(folder, "resultServlet.xml"))
                {

                    Pathtextbox.Text = xmlFilePath;
                    checkMalformedXML();
                    found = true;
                    break;
                }
            }




            UpdateSummeFromForcast(null, null);
            dataGrid1.ItemsSource = CreateWork1();
            dataGrid2.ItemsSource = CreateWork2();
            dataGrid3.ItemsSource = CreateWork3();
            dataGrid4.ItemsSource = CreateWork4();
            dataGrid6.ItemsSource = CreateWork6();
            dataGrid7.ItemsSource = CreateWork7();
            dataGrid8.ItemsSource = CreateWork8();
            dataGrid9.ItemsSource = CreateWork9();
            dataGrid10.ItemsSource = CreateWork10();
            dataGrid11.ItemsSource = CreateWork11();
            dataGrid12.ItemsSource = CreateWork12();
            dataGrid13.ItemsSource = CreateWork13();
            dataGrid14.ItemsSource = CreateWork14();
            dataGrid15.ItemsSource = CreateWork15();
            dataGrid16.ItemsSource = CreateWorkPlan16();
            dataGrid17.ItemsSource = CreateWorkPlan16();
            dataGrid18.ItemsSource = CreateWorkPlan16();
            dataGrid19.ItemsSource = CreateWorkPlan16();
            dataGrid20.ItemsSource = CreateWorkPlan16();
            dataGrid21.ItemsSource = CreateWorkPlan16();
            dataGrid22.ItemsSource = CreateWorkPlan16();
            dataGrid23.ItemsSource = CreateWorkPlan16();
            dataGrid24.ItemsSource = CreateWorkPlan16();
            dataGrid25.ItemsSource = CreateWorkPlan16();
            dataGrid26.ItemsSource = CreateWorkPlan16();
            dataGrid27.ItemsSource = CreateWorkPlan16();
            dataGrid28.ItemsSource = CreateWorkPlan16();
            dataGrid29.ItemsSource = CreateWorkPlan16();
            dataGrid30.ItemsSource = CreateLiefer1();
            dataGrid31.ItemsSource = CreateEinkauf1();
            prio.ItemsSource = CreatePrio1();
        }


        public ObservableCollection<Prio> CreatePrio1()
        {
            ObservableCollection<Prio> prio = new ObservableCollection<Prio>();
            return prio;
        }

      
        public ObservableCollection<Einkauf> CreateEinkauf1()
        {
            ObservableCollection<Einkauf> einkauf = new ObservableCollection<Einkauf>();
            return einkauf;
        }
        public ObservableCollection<Liefer> CreateLiefer1()
        {
            ObservableCollection<Liefer> liefer = new ObservableCollection<Liefer>();
            liefer.Add(new Liefer { Kaufteileno = "21", Kaufteil = "Kette", Verwendung="K", Teilewert="5,00", Diskontmenge="300", Bestellkosten="50", Lieferfrist = "1,8", Abweichung = "0,4" });
            liefer.Add(new Liefer { Kaufteileno = "22", Kaufteil = "Kette", Verwendung = "D", Teilewert = "6,50", Diskontmenge = "300", Bestellkosten = "50", Lieferfrist = "1,7", Abweichung = "0,4" });
            liefer.Add(new Liefer { Kaufteileno = "23", Kaufteil = "Kette", Verwendung = "H", Teilewert = "6,50", Diskontmenge = "300", Bestellkosten = "50", Lieferfrist = "1,2", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "24", Kaufteil = "Mutter 3/8", Verwendung = "KDH", Teilewert = "0;06", Diskontmenge = "6100", Bestellkosten = "100", Lieferfrist = "3,2", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "25", Kaufteil = "Scheibe 3/8", Verwendung = "KDH", Teilewert = "0;06", Diskontmenge = "3600", Bestellkosten = "50", Lieferfrist = "0,9", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "27", Kaufteil = "Schraube 3/8", Verwendung = "KDH", Teilewert = "0,1", Diskontmenge = "1800", Bestellkosten = "75", Lieferfrist = "0,9", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "28", Kaufteil = "Rohr 3/4", Verwendung = "KDH", Teilewert = "1,20", Diskontmenge = "4500", Bestellkosten = "50", Lieferfrist = "1,7", Abweichung = "0,4" });
            liefer.Add(new Liefer { Kaufteileno = "32", Kaufteil = "Farbe", Verwendung = "KDH", Teilewert = "0,75", Diskontmenge = "2700", Bestellkosten = "50", Lieferfrist = "2,1", Abweichung = "0,5" });
            liefer.Add(new Liefer { Kaufteileno = "33", Kaufteil = "Felge cpl.", Verwendung = "H", Teilewert = "22,00", Diskontmenge = "900", Bestellkosten = "75", Lieferfrist = "1,9", Abweichung = "0,5" });
            liefer.Add(new Liefer { Kaufteileno = "34", Kaufteil = "Speiche", Verwendung = "H", Teilewert = "0,1", Diskontmenge = "22000", Bestellkosten = "50", Lieferfrist = "1,6", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "35", Kaufteil = "Nabe", Verwendung = "KDH", Teilewert = "1,00", Diskontmenge = "3600", Bestellkosten = "75", Lieferfrist = "2,2", Abweichung = "0,4" });
            liefer.Add(new Liefer { Kaufteileno = "36", Kaufteil = "Freilauf", Verwendung = "KDH", Teilewert = "8,00", Diskontmenge = "900", Bestellkosten = "100", Lieferfrist = "1,2", Abweichung = "0,1" });
            liefer.Add(new Liefer { Kaufteileno = "37", Kaufteil = "Gabel", Verwendung = "KDH", Teilewert = "1,50", Diskontmenge = "900", Bestellkosten = "50", Lieferfrist = "1,5", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "38", Kaufteil = "Welle", Verwendung = "KDH", Teilewert = "1,50", Diskontmenge = "300", Bestellkosten = "50", Lieferfrist = "1,7", Abweichung = "0,4" });
            liefer.Add(new Liefer { Kaufteileno = "39", Kaufteil = "Blech", Verwendung = "KDH", Teilewert = "1,50", Diskontmenge = "1800", Bestellkosten = "75", Lieferfrist = "1,5", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "40", Kaufteil = "Lenker", Verwendung = "KDH", Teilewert = "2,50", Diskontmenge = "900", Bestellkosten = "50", Lieferfrist = "1,7", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "41", Kaufteil = "Mutter 3/4", Verwendung = "KDH", Teilewert = "0,06", Diskontmenge = "900", Bestellkosten = "50", Lieferfrist = "0,9", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "42", Kaufteil = "Griff", Verwendung = "KDH", Teilewert = "0,10", Diskontmenge = "1800", Bestellkosten = "50", Lieferfrist = "1,2", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "43", Kaufteil = "Sattel", Verwendung = "KDH", Teilewert = "5,00", Diskontmenge = "2700", Bestellkosten = "75", Lieferfrist = "2,0", Abweichung = "0,5" });
            liefer.Add(new Liefer { Kaufteileno = "44", Kaufteil = "Stange 1/2", Verwendung = "KDH", Teilewert = "0,50", Diskontmenge = "900", Bestellkosten = "50", Lieferfrist = "1,2", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "45", Kaufteil = "Mutter 1/4", Verwendung = "KDH", Teilewert = "0,06", Diskontmenge = "900", Bestellkosten = "50", Lieferfrist = "1,7", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "46", Kaufteil = "Schraube 1/4", Verwendung = "KDH", Teilewert = "0,10", Diskontmenge = "900", Bestellkosten = "50", Lieferfrist = "0,9", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "47", Kaufteil = "Zahnkranz", Verwendung = "KDH", Teilewert = "3,50", Diskontmenge = "900", Bestellkosten = "50", Lieferfrist = "1,1", Abweichung = "0,1" });
            liefer.Add(new Liefer { Kaufteileno = "48", Kaufteil = "Pedal", Verwendung = "KDH", Teilewert = "1,50", Diskontmenge = "1800", Bestellkosten = "75", Lieferfrist = "1,0", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "52", Kaufteil = "Felge cpl.", Verwendung = "K", Teilewert = "22,00", Diskontmenge = "600", Bestellkosten = "50", Lieferfrist = "1,6", Abweichung = "0,4" });
            liefer.Add(new Liefer { Kaufteileno = "53", Kaufteil = "Speiche", Verwendung = "K", Teilewert = "0,10", Diskontmenge = "22000", Bestellkosten = "50", Lieferfrist = "1,6", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "57", Kaufteil = "Felge cp.", Verwendung = "D", Teilewert = "22,00", Diskontmenge = "600", Bestellkosten = "50", Lieferfrist = "1,7", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "58", Kaufteil = "Speiche", Verwendung = "D", Teilewert = "0,10", Diskontmenge = "22000", Bestellkosten = "50", Lieferfrist = "1,6", Abweichung = "0,5" });
            liefer.Add(new Liefer { Kaufteileno = "59", Kaufteil = "Schweißdraht", Verwendung = "KDH", Teilewert = "0,15", Diskontmenge = "1800", Bestellkosten = "50", Lieferfrist = "0,7", Abweichung = "0,2" });
            return liefer;
        }

        public ObservableCollection<KapNo> CreateWorkPlan16()
        {
            ObservableCollection<KapNo> kapno = new ObservableCollection<KapNo>();
            kapno.Add(new KapNo { Kapaplanwork = TranslateService.Class.GetTranslation("CAPACITY_REQ_NEW"), Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = TranslateService.Class.GetTranslation("SETUP_TIME_NEW"), Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = TranslateService.Class.GetTranslation("CAP_REQ_PREV"), Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = TranslateService.Class.GetTranslation("SETUP_TIME_PREV"), Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = TranslateService.Class.GetTranslation("TOTAL_CAP_REQ"), Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = TranslateService.Class.GetTranslation("SHIFTS_OVERTIME"), Berechnungwork = "" });
            return kapno;
        }
        public ObservableCollection<ItemNo> CreateWork1()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo{ Bezeichnung="Vorderrad komplett (cpl)", Sachnr="E49", Fahrradtyp="K", Einzelaufwand="6", Gesamtaufwand="" });
            itemno.Add(new ItemNo{ Bezeichnung = "Vorderrad komplett (cpl)", Sachnr = "E54", Fahrradtyp = "D", Einzelaufwand = "6", Gesamtaufwand = "" });
            itemno.Add(new ItemNo{ Bezeichnung = "Vorderrad komplett (cpl)", Sachnr = "E29", Fahrradtyp = "H", Einzelaufwand = "6", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork2()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = "Rahmen und Räder", Sachnr = "E50", Fahrradtyp = "K", Einzelaufwand = "5", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Rahmen und Räder", Sachnr = "E55", Fahrradtyp = "D", Einzelaufwand = "5", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Rahmen und Räder", Sachnr = "E30", Fahrradtyp = "H", Einzelaufwand = "5", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork3()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = "Fahrrad ohne Pedale", Sachnr = "E51", Fahrradtyp = "K", Einzelaufwand = "5", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Fahrrad ohne Pedale", Sachnr = "E56", Fahrradtyp = "D", Einzelaufwand = "6", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Fahrrad ohne Pedale", Sachnr = "E31", Fahrradtyp = "H", Einzelaufwand = "6", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork4()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = "Fahrrad komplett (cpl)", Sachnr = "P1", Fahrradtyp = "K", Einzelaufwand = "6", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Fahrrad komplett (cpl)", Sachnr = "P2", Fahrradtyp = "D", Einzelaufwand = "7", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Fahrrad komplett (cpl)", Sachnr = "P3", Fahrradtyp = "H", Einzelaufwand = "7", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork6()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = "Lenker", Sachnr = "E16", Fahrradtyp = "KDH", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Rahmen", Sachnr = "E18", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Rahmen", Sachnr = "E19", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Rahmen", Sachnr = "E20", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork7()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech hinten", Sachnr = "E10", Fahrradtyp = "K", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech hinten", Sachnr = "E11", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech hinten", Sachnr = "E12", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech vorne", Sachnr = "E13", Fahrradtyp = "K", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech vorne", Sachnr = "E14", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech vorne", Sachnr = "E15", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Rahmen", Sachnr = "E18", Fahrradtyp = "K", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Rahmen", Sachnr = "E19", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Rahmen", Sachnr = "E20", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Pedale", Sachnr = "E26", Fahrradtyp = "KDH", Einzelaufwand = "2", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork8()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech hinten", Sachnr = "E10", Fahrradtyp = "K", Einzelaufwand = "1", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech hinten", Sachnr = "E11", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech hinten", Sachnr = "E12", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech vorne", Sachnr = "E13", Fahrradtyp = "K", Einzelaufwand = "1", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech vorne", Sachnr = "E14", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech vorne", Sachnr = "E15", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Rahmen", Sachnr = "E18", Fahrradtyp = "K", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Rahmen", Sachnr = "E19", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Rahmen", Sachnr = "E20", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork9()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech hinten", Sachnr = "E10", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech hinten", Sachnr = "E11", Fahrradtyp = "D", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech hinten", Sachnr = "E12", Fahrradtyp = "H", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech vorne", Sachnr = "E13", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech vorne", Sachnr = "E14", Fahrradtyp = "D", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech vorne", Sachnr = "E15", Fahrradtyp = "H", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Rahmen", Sachnr = "E18", Fahrradtyp = "K", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Rahmen", Sachnr = "E19", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Rahmen", Sachnr = "E20", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork10()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = "Hinterrad", Sachnr = "E4", Fahrradtyp = "K", Einzelaufwand = "4", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Hinterrad", Sachnr = "E5", Fahrradtyp = "D", Einzelaufwand = "4", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Hinterrad", Sachnr = "E6", Fahrradtyp = "H", Einzelaufwand = "4", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Vorderrad", Sachnr = "E7", Fahrradtyp = "K", Einzelaufwand = "4", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Vorderrad", Sachnr = "E8", Fahrradtyp = "D", Einzelaufwand = "4", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Vorderrad", Sachnr = "E9", Fahrradtyp = "H", Einzelaufwand = "4", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork11()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = "Hinterrad", Sachnr = "E4", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Hinterrad", Sachnr = "E5", Fahrradtyp = "D", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Hinterrad", Sachnr = "E6", Fahrradtyp = "H", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Vorderrad", Sachnr = "E7", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Vorderrad", Sachnr = "E8", Fahrradtyp = "D", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Vorderrad", Sachnr = "E9", Fahrradtyp = "H", Einzelaufwand = "3", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork12()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech hinten", Sachnr = "E10", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech hinten", Sachnr = "E11", Fahrradtyp = "D", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech hinten", Sachnr = "E12", Fahrradtyp = "H", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech vorne", Sachnr = "E13", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech vorne", Sachnr = "E14", Fahrradtyp = "D", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech vorne", Sachnr = "E15", Fahrradtyp = "H", Einzelaufwand = "3", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork13()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech hinten", Sachnr = "E10", Fahrradtyp = "K", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech hinten", Sachnr = "E11", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech hinten", Sachnr = "E12", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech vorne", Sachnr = "E13", Fahrradtyp = "K", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech vorne", Sachnr = "E14", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Schutzblech vorne", Sachnr = "E15", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork14()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = "Lenker", Sachnr = "E16", Fahrradtyp = "KDH", Einzelaufwand = "3", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork15()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = "Sattel", Sachnr = "E17", Fahrradtyp = "KDH", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = "Pedale", Sachnr = "E26", Fahrradtyp = "KDH", Einzelaufwand = "3", Gesamtaufwand = "" });
            return itemno;
        }

        public void LoadTranslations()
        {

        }

        public void UpdateCalculations()
        {
            prognosevarperiod1.Content = (Static.Static.lastperiod + 1).ToString();
            prognosevarperiod2.Content = (Static.Static.lastperiod + 2).ToString();
            prognosevarperiod3.Content = (Static.Static.lastperiod + 3).ToString();
            prognosevarperiod4.Content = (Static.Static.lastperiod + 4).ToString();
        }



        private void Choosefile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialogDateipfad = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> dialogDateipfadResult = dialogDateipfad.ShowDialog();
            if (dialogDateipfadResult == true)
            {
                if (!dialogDateipfad.FileName.Contains(".xml"))
                {
                    MessageBox.Show(TranslateService.Class.GetTranslation("XML_ERROR"), "XML Input", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Pathtextbox.Text = dialogDateipfad.FileName;
            }
        }

        protected bool GetFilename(out string filename, DragEventArgs e)
        {
            bool ret = false;
            filename = String.Empty;

            if ((e.AllowedEffects & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileName") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        string ext = System.IO.Path.GetExtension(filename).ToLower();
                        if ((ext == ".xml") || (ext == ".XML"))
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine("OnDragEnter");
            bool validData = GetFilename(out string filename, e);
            Console.WriteLine(validData.ToString());
            if (!validData)
            {
                MessageBox.Show(TranslateService.Class.GetTranslation("XML_ERROR"), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Pathtextbox.Text = filename;
        }


        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Pathtextbox.Text = "";
        }



        private void Settingsmenuheader_Click(object sender, RoutedEventArgs e)
        {
            Settings Settingspage = new Settings();
            Settingspage.Show();
        }

        private void Aboutmenuheader_Click(object sender, RoutedEventArgs e)
        {
            Settings Settingspage = new Settings();
            Settingspage.Show();
        }

        private void Closemenuitem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(21);
        }

        private void Helpmenuitem_Click(object sender, RoutedEventArgs e)
        {
            Wiki Wikipage = new Wiki();
            Wikipage.Show();
        }

        private void Calculatebutton_Click(object sender, RoutedEventArgs e)
        {



            try
            {
                if (Sicherheitsfaktor.Text == "")
                {
                    MessageBox.Show(TranslateService.Class.GetTranslation("SECURITYFACTOR_EMPTY"));
                    return;
                }

                if (Convert.ToInt32(forecastsy1p1.Text) % 10 != 0 || Convert.ToInt32(forecastsy1p2.Text) % 10 != 0 || Convert.ToInt32(forecastsy1p3.Text) % 10 != 0 || Convert.ToInt32(forecastsy2p1.Text) % 10 != 0 || Convert.ToInt32(forecastsy2p2.Text) % 10 != 0 || Convert.ToInt32(forecastsy2p3.Text) % 10 != 0 || Convert.ToInt32(forecastsy3p1.Text) % 10 != 0 || Convert.ToInt32(forecastsy3p2.Text) % 10 != 0 || Convert.ToInt32(forecastsy3p3.Text) % 10 != 0 || Convert.ToInt32(forecastsy4p1.Text) % 10 != 0 || Convert.ToInt32(forecastsy4p2.Text) % 10 != 0 || Convert.ToInt32(forecastsy4p3.Text) % 10 != 0)
                {
                    MessageBox.Show(TranslateService.Class.GetTranslation("INPUT_VALUE_ERROR<"));
                    return;
                }
            }
            catch
            {

            }

            Ui.EnableNextTab(Kapaplanungtab, MainTabControl);
            Ui.EnableNextTab(Einkauftab, MainTabControl);
            Ui.EnableNextTab(Produktionsplanungtab, MainTabControl);
            Ui.EnableNextTab(Priorisierungtab, MainTabControl);
            Ui.EnableNextTab(Chartstab, MainTabControl);
            Ui.EnableNextTab(Exporttab, MainTabControl);
        }

        private bool AllFilled()
        {
            if (period0product1.Text == "" || period0product2.Text == "" || period0product3.Text == "" || period1product1.Text == "" || period1product2.Text == "" || period1product3.Text == "" || period2product1.Text == "" || period2product2.Text == "" || period2product3.Text == "")
            {
                return false;
            }
            return true;
        }


        private void PrognosenNextbutton_Click(object sender, RoutedEventArgs e)
        {

            Int32 maxValue = 1050;
            try
            {
                if (Convert.ToInt32(period0sum.Text) > maxValue || Convert.ToInt32(period1sum.Text) > maxValue || Convert.ToInt32(period2sum.Text) > maxValue || Convert.ToInt32(period3sum.Text) > maxValue)
                {
                    MessageBox.Show("Value greater than " + maxValue);
                    return;
                }

                if (Convert.ToInt32(period0product1.Text) % 10 != 0 || Convert.ToInt32(period0product2.Text) % 10 != 0 || Convert.ToInt32(period0product3.Text) % 10 != 0 || Convert.ToInt32(period1product1.Text) % 10 != 0 || Convert.ToInt32(period1product2.Text) % 10 != 0 || Convert.ToInt32(period1product3.Text) % 10 != 0 || Convert.ToInt32(period2product1.Text) % 10 != 0 || Convert.ToInt32(period2product2.Text) % 10 != 0 || Convert.ToInt32(period2product3.Text) % 10 != 0 || Convert.ToInt32(period3product1.Text) % 10 != 0 || Convert.ToInt32(period3product2.Text) % 10 != 0 || Convert.ToInt32(period3product3.Text) % 10 != 0)
                {
                    MessageBox.Show("Incorrect Values in Productionplan!");
                    return;
                }
            }
            catch
            {

            }

            if (AllFilled())
            {
                try
                {
                    Forecast.Class.AddForecast(0, new Forecast.ForecastPeriod(Convert.ToInt32(period0product1.Text), Convert.ToInt32(period0product2.Text), Convert.ToInt32(period0product3.Text)));
                    Forecast.Class.AddForecast(1, new Forecast.ForecastPeriod(Convert.ToInt32(period1product1.Text), Convert.ToInt32(period1product2.Text), Convert.ToInt32(period1product3.Text)));
                    Forecast.Class.AddForecast(2, new Forecast.ForecastPeriod(Convert.ToInt32(period2product1.Text), Convert.ToInt32(period2product2.Text), Convert.ToInt32(period2product3.Text)));
                    Forecast.Class.AddForecast(3, new Forecast.ForecastPeriod(Convert.ToInt32(period3product1.Text), Convert.ToInt32(period3product2.Text), Convert.ToInt32(period3product3.Text)));
                    Ui.EnableNextTab(Direktverkauftab, MainTabControl);


                }
                catch (FormatException)
                {
                    MessageBox.Show(TranslateService.Class.GetTranslation("ONLY_INT_ERROR"));
                }
            }

            else
            {
                MessageBox.Show(TranslateService.Class.GetTranslation("INPUT_NOT_COMPLETE"));
                return;
            }

        }

        private void DirectNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(s41.Text) > 1050 || (Convert.ToInt32(period0sum.Text) + Convert.ToInt32(s41.Text)) > 1050)
            {
                MessageBox.Show("Summe zu groß");
                return;
            }
            Ui.EnableNextTab(sicherheitsbestandtab, MainTabControl);
        }

        public void checkMalformedXML()
        {

            if (String.IsNullOrEmpty(Pathtextbox.Text))
            {
                MessageBox.Show(TranslateService.Class.GetTranslation("XML_ERROR"));
                return;
            }
            ReadXML readxml = new ReadXML();
            bool wellformed = readxml.ReadFile(Pathtextbox.Text);
            if (!wellformed)
            {
                MessageBox.Show(TranslateService.Class.GetTranslation("XML_MALFORMED"));
                return;
            }
            Ui.EnableNextTab(Prognosentab, MainTabControl);
        }

        private void MainpageNextButton_Click(object sender, RoutedEventArgs e)
        {
            checkMalformedXML();
        }


private void Forecast1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Int32 directsum1 = 0;

                if (d11 != null)
                    directsum1 += Convert.ToInt32(d11.Text);
                if (d21 != null)
                    directsum1 += Convert.ToInt32(d21.Text);
                if (d31 != null)
                    directsum1 += Convert.ToInt32(d31.Text);

                if (s41 != null)
                    s41.Text = directsum1.ToString();
            }
            catch
            {

            }
        }

private void UpdateSummeFromForcast(object sender, TextChangedEventArgs e)
        {
            try
            {
                int p0sum = 0;
                int p1sum = 0;
                int p2sum = 0;
                int p3sum = 0;
                if (period0product1 != null)
                    p0sum += Convert.ToInt32(period0product1.Text);
                if (period0product2 != null)
                    p0sum += Convert.ToInt32(period0product2.Text);
                if (period0product3 != null)
                    p0sum += Convert.ToInt32(period0product3.Text);

                if (period1product1 != null)
                    p1sum += Convert.ToInt32(period1product1.Text);
                if (period1product2 != null)
                    p1sum += Convert.ToInt32(period1product2.Text);
                if (period1product3 != null)
                    p1sum += Convert.ToInt32(period1product3.Text);

                if (period2product1 != null)
                    p2sum += Convert.ToInt32(period2product1.Text);
                if (period2product2 != null)
                    p2sum += Convert.ToInt32(period2product2.Text);
                if (period2product3 != null)
                    p2sum += Convert.ToInt32(period2product3.Text);

                if (period3product1 != null)
                    p3sum += Convert.ToInt32(period3product1.Text);
                if (period3product2 != null)
                    p3sum += Convert.ToInt32(period3product2.Text);
                if (period3product3 != null)
                    p3sum += Convert.ToInt32(period3product3.Text);

                if (period0sum != null)
                    period0sum.Text = p0sum.ToString();

                if (period1sum != null)
                    period1sum.Text = p1sum.ToString();

                if (period2sum != null)
                    period2sum.Text = p2sum.ToString();

                if (period3sum != null)
                    period3sum.Text = p3sum.ToString();
            }
            catch { }
        }



        private void NumberDoubleValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NumberIntValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }



        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Prognosentab.IsSelected)
            {
                try
                {
                    prognosevarperiod1.Content = Static.Static.lastperiod + 1;
                    prognosevarperiod2.Content = Static.Static.lastperiod + 2;
                    prognosevarperiod3.Content = Static.Static.lastperiod + 3;
                    prognosevarperiod4.Content = Static.Static.lastperiod + 4;
                }
                catch
                {
                    MessageBox.Show("error");
                    return;
                }

            }

            if (sicherheitsbestandtab.IsSelected)
            {
                try
                {
                    sicherheitsvarperiod1.Content = Static.Static.lastperiod + 1;
                    sicherheitsvarperiod2.Content = Static.Static.lastperiod + 2;
                    sicherheitsvarperiod3.Content = Static.Static.lastperiod + 3;
                    sicherheitsvarperiod4.Content = Static.Static.lastperiod + 4;
                }
                catch
                {
                    MessageBox.Show("error");
                    return;
                }
            }

            if (Direktverkauftab.IsSelected)
            {
                try
                {
                    directvarperiod1.Content = Static.Static.lastperiod + 1;
                }
                catch
                {
                    MessageBox.Show("error");
                    return;
                }
            }
        }

        private void Forecast_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Int32 forecastsum1 = 0;
                Int32 forecastsum2 = 0;
                Int32 forecastsum3 = 0;
                Int32 forecastsum4 = 0;

                if (forecastsy1p1 != null)
                    forecastsum1 += Convert.ToInt32(forecastsy1p1.Text);
                if (forecastsy1p2 != null)
                    forecastsum1 += Convert.ToInt32(forecastsy1p2.Text);
                if (forecastsy1p3 != null)
                    forecastsum1 += Convert.ToInt32(forecastsy1p3.Text);

                if (forecastsy2p1 != null)
                    forecastsum2 += Convert.ToInt32(forecastsy2p1.Text);
                if (forecastsy2p2 != null)
                    forecastsum2 += Convert.ToInt32(forecastsy2p2.Text);
                if (forecastsy2p3 != null)
                    forecastsum2 += Convert.ToInt32(forecastsy2p3.Text);

                if (forecastsy3p1 != null)
                    forecastsum3 += Convert.ToInt32(forecastsy3p1.Text);
                if (forecastsy3p2 != null)
                    forecastsum3 += Convert.ToInt32(forecastsy3p2.Text);
                if (forecastsy3p3 != null)
                    forecastsum3 += Convert.ToInt32(forecastsy3p3.Text);

                if (forecastsy4p1 != null)
                    forecastsum4 += Convert.ToInt32(forecastsy4p1.Text);
                if (forecastsy4p2 != null)
                    forecastsum4 += Convert.ToInt32(forecastsy4p2.Text);
                if (forecastsy4p3 != null)
                    forecastsum4 += Convert.ToInt32(forecastsy4p3.Text);


                if (sumy1 != null)
                    sumy1.Text = forecastsum1.ToString();

                if (sumy2 != null)
                    sumy2.Text = forecastsum2.ToString();

                if (sumy3 != null)
                    sumy3.Text = forecastsum3.ToString();

                if (sumy4 != null)
                    sumy4.Text = forecastsum4.ToString();

            }
            catch
            {

            }
        }

    }
}

public class Liefer : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private string lieferfrist;
    private string abweichung;
    public string kaufteileno;
    public string kaufteil;
    public string bestellkosten;
    public string diskontmenge;
    public string teilewert;
    public string verwendung;

    
    public string Kaufteileno
    {
        get { return kaufteileno; }
        set
        {
            kaufteileno = value; OnPropertyChanged(new PropertyChangedEventArgs("KaufteileNo"));
        }
    }

    public string Kaufteil
    {
        get { return kaufteil; }
        set
        {
            kaufteil = value; OnPropertyChanged(new PropertyChangedEventArgs("Kaufteils"));
        }
    }
    public string Verwendung
    {
        get { return verwendung; }
        set
        {
            verwendung = value; OnPropertyChanged(new PropertyChangedEventArgs("Verwendung"));
        }
    }

    public string Bestellkosten
    {
        get { return bestellkosten; }
        set
        {
            bestellkosten = value; OnPropertyChanged(new PropertyChangedEventArgs("Bestellkosten"));
        }
    }
    public string Diskontmenge
    {
        get { return diskontmenge; }
        set
        {
            diskontmenge = value; OnPropertyChanged(new PropertyChangedEventArgs("Diskontmenge"));
        }
    }
    public string Teilewert
    {
        get { return teilewert; }
        set
        {
            teilewert = value; OnPropertyChanged(new PropertyChangedEventArgs("Teilewert"));
        }
    }

    public string Lieferfrist
    {
        get { return lieferfrist; }
        set
        {
            lieferfrist = value; OnPropertyChanged(new PropertyChangedEventArgs("Lieferfrist"));
        }
    }
    public string Abweichung
    {
        get { return abweichung; }
        set
        {
            abweichung = value; OnPropertyChanged(new PropertyChangedEventArgs("Abweichung"));
        }
    }
    protected void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (PropertyChanged != null)
        { PropertyChanged(this, e); }
    }
}

public class KapNo : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private string kapaplanwork;
    private string berechnungwork;

    public string Kapaplanwork
    {
        get { return kapaplanwork; }
        set
        {
            kapaplanwork = value; OnPropertyChanged(new PropertyChangedEventArgs("Kapaplanwork"));
        }
    }
    public string Berechnungwork
    {
        get { return berechnungwork; }
        set
        {
            berechnungwork = value; OnPropertyChanged(new PropertyChangedEventArgs("Berechnungwork"));
        }
    }
    protected void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (PropertyChanged != null)
        { PropertyChanged(this, e); }
    }
}


public class ItemNo : INotifyPropertyChanged
{
    // Ereignis
    public event PropertyChangedEventHandler PropertyChanged;
    // Eigenschaften

    private string bezeichnung;
    private string fahrradtyp;
    private string sachnr;
    private string menge;
    private string einzelaufwand;
    private string gesamtaufwand;

    public string Bezeichnung
    {
        get { return bezeichnung; }
        set
        {
            bezeichnung = value; OnPropertyChanged(new PropertyChangedEventArgs("Bezeichnung"));
        }
    }
    public string Fahrradtyp
    {
        get { return fahrradtyp; }
        set
        {
            fahrradtyp = value; OnPropertyChanged(new PropertyChangedEventArgs("Fahrradtyp"));
        }
    }
    public string Sachnr
    {
        get { return sachnr; }
        set
        {
            sachnr = value; OnPropertyChanged(new PropertyChangedEventArgs("Sach-Nr"));
        }
    }
    public string Menge
    {
        get { return menge; }
        set
        {
            menge = value; OnPropertyChanged(new PropertyChangedEventArgs("Menge"));
        }
    }
    public string Einzelaufwand
    {
        get { return einzelaufwand; }
        set
        {
            einzelaufwand = value; OnPropertyChanged(new PropertyChangedEventArgs("Einzelaufwand"));
        }
    }
    public string Gesamtaufwand
    {
        get { return gesamtaufwand; }
        set
        {
            gesamtaufwand = value; OnPropertyChanged(new PropertyChangedEventArgs("Gesamtaufwand"));
        }
    }
    protected void OnPropertyChanged(PropertyChangedEventArgs e)
{
        if (PropertyChanged != null)
        { PropertyChanged(this, e); }
    }
}
public class Einkauf : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private string teileno;
    private string anzahl;
    private string art;

    public string Teileno
    {
        get { return teileno; }
        set
        {
            teileno = value; OnPropertyChanged(new PropertyChangedEventArgs("TeileNo"));
        }
    }
    public string Anzahl
    {
        get { return anzahl; }
        set
        {
            anzahl = value; OnPropertyChanged(new PropertyChangedEventArgs("Anzahl"));
        }
    }
    public string Art
    {
        get { return art; }
        set
        {
            art = value; OnPropertyChanged(new PropertyChangedEventArgs("Art"));
        }
    }
    protected void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (PropertyChanged != null)
        { PropertyChanged(this, e); }
    }
}

public class Prio : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private string teilenr;
    private string anzahl;

    public string Teilenr
    {
        get { return teilenr; }
        set
        {
            teilenr = value; OnPropertyChanged(new PropertyChangedEventArgs("Teilenr"));
        }
    }
    public string Anzahl
    {
        get { return anzahl; }
        set
        {
            anzahl = value; OnPropertyChanged(new PropertyChangedEventArgs("Anzahl"));
        }
    }

    protected void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (PropertyChanged != null)
        { PropertyChanged(this, e); }
    }
}