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

namespace Ibsys2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
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
        }
        public ObservableCollection<KapNo> CreateWorkPlan16()
        {
            ObservableCollection<KapNo> kapno = new ObservableCollection<KapNo>();
            kapno.Add(new KapNo { Kapaplanwork = "Kapazitätsbedarf (neu)", Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = "Rüstzeit (neu)", Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = "Kap. bed. (Rückstand Vorperiode)", Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = "Rüstzeit (Rückstand Vorperiode)", Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = "Gesamt-Kapazitätsbedarf", Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = "Schichten und Überstunden", Berechnungwork = "" });
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
                    MessageBox.Show("Pls Fill all needed Fields");
                    return;
                }

                if (Convert.ToInt32(forecastsy1p1.Text) % 10 != 0 || Convert.ToInt32(forecastsy1p2.Text) % 10 != 0 || Convert.ToInt32(forecastsy1p3.Text) % 10 != 0 || Convert.ToInt32(forecastsy2p1.Text) % 10 != 0 || Convert.ToInt32(forecastsy2p2.Text) % 10 != 0 || Convert.ToInt32(forecastsy2p3.Text) % 10 != 0 || Convert.ToInt32(forecastsy3p1.Text) % 10 != 0 || Convert.ToInt32(forecastsy3p2.Text) % 10 != 0 || Convert.ToInt32(forecastsy3p3.Text) % 10 != 0 || Convert.ToInt32(forecastsy4p1.Text) % 10 != 0 || Convert.ToInt32(forecastsy4p2.Text) % 10 != 0 || Convert.ToInt32(forecastsy4p3.Text) % 10 != 0)
                {
                    MessageBox.Show("Error in Inputvalues");
                    return;
                }
            }
            catch
            {

            }

            Ui.EnableNextTab(Kapaplanungtab, MainTabControl);
            Ui.EnableNextTab(Einkauftab, MainTabControl);
            Ui.EnableNextTab(Produktionsplanungtab, MainTabControl);
            Ui.EnableNextTab(Chartstab, MainTabControl);
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

            Int32 maxValue = 1500;
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
                MessageBox.Show("Please fill all Fields!");
                return;
            }

        }

        private void DirectNextButton_Click(object sender, RoutedEventArgs e)
        {
            Ui.EnableNextTab(sicherheitsbestandtab, MainTabControl);
        }

        private void MainpageNextButton_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(Pathtextbox.Text))
            {
                MessageBox.Show("Please insert a File!");
                return;
            }
            ReadXML readxml = new ReadXML();
            bool wellformed = readxml.ReadFile(Pathtextbox.Text);
            if (!wellformed)
            {
                MessageBox.Show("Malformed XML File! Please use another one!");
                return;
            }
            Ui.EnableNextTab(Prognosentab, MainTabControl);

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