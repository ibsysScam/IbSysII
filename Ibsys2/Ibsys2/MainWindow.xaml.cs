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

namespace Ibsys2 {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private static MainWindow _class;
        UIFeatures Ui = new UIFeatures();

        public static MainWindow Class {
            get {
                if (_class == null)
                    new MainWindow();
                return _class;
            }
        }
        public MainWindow() {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            SettingsService.Class.CreateFolder();
            SettingsService.Class.LoadSettings();

            InitializeComponent();
            LoadTranslations();
            UpdateSummeFromForcast(null, null);
        }

        public void LoadTranslations() {

        }

        public void UpdateCalculations() {
            prognosevarperiod1.Content = (Static.Static.lastperiod + 1).ToString();
            prognosevarperiod2.Content = (Static.Static.lastperiod + 2).ToString();
            prognosevarperiod3.Content = (Static.Static.lastperiod + 3).ToString();
            prognosevarperiod4.Content = (Static.Static.lastperiod + 4).ToString();
        }



        private void Choosefile_Click(object sender, RoutedEventArgs e) {
            Microsoft.Win32.OpenFileDialog dialogDateipfad = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> dialogDateipfadResult = dialogDateipfad.ShowDialog();
            if (dialogDateipfadResult == true) {
                if (!dialogDateipfad.FileName.Contains(".xml")) {
                    MessageBox.Show(TranslateService.Class.GetTranslation("XML_ERROR"), "XML Input", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Pathtextbox.Text = dialogDateipfad.FileName;
            }
        }

        protected bool GetFilename(out string filename, DragEventArgs e) {
            bool ret = false;
            filename = String.Empty;

            if ((e.AllowedEffects & DragDropEffects.Copy) == DragDropEffects.Copy) {
                Array data = ((IDataObject)e.Data).GetData("FileName") as Array;
                if (data != null) {
                    if ((data.Length == 1) && (data.GetValue(0) is String)) {
                        filename = ((string[])data)[0];
                        string ext = System.IO.Path.GetExtension(filename).ToLower();
                        if ((ext == ".xml") || (ext == ".XML")) {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        private void Window_DragEnter(object sender, DragEventArgs e) {
            Console.WriteLine("OnDragEnter");
            bool validData = GetFilename(out string filename, e);
            Console.WriteLine(validData.ToString());
            if (!validData) {
                MessageBox.Show(TranslateService.Class.GetTranslation("XML_ERROR"), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Pathtextbox.Text = filename;
        }


        private void Clear_Click(object sender, RoutedEventArgs e) {
            Pathtextbox.Text = "";
        }



        private void Settingsmenuheader_Click(object sender, RoutedEventArgs e) {
            Settings Settingspage = new Settings();
            Settingspage.Show();
        }

        private void Closemenuitem_Click(object sender, RoutedEventArgs e) {
            Environment.Exit(21);
        }

        private void Helpmenuitem_Click(object sender, RoutedEventArgs e) {
            Wiki Wikipage = new Wiki();
            Wikipage.Show();
        }

        private void Calculatebutton_Click(object sender, RoutedEventArgs e) {

           

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
            if(period0product1.Text == "" || period0product2.Text == "" || period0product3.Text == "" || period1product1.Text == "" || period1product2.Text == "" || period1product3.Text == ""  || period2product1.Text == "" || period2product2.Text == "" || period2product3.Text == "")
            {
                return false;
            }
            return true;
        }

        
        private void PrognosenNextbutton_Click(object sender, RoutedEventArgs e) {

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
                    Ui.EnableNextTab(sicherheitsbestandtab,MainTabControl);


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

        private void MainpageNextButton_Click(object sender, RoutedEventArgs e) {

            if (String.IsNullOrEmpty(Pathtextbox.Text)) {
                MessageBox.Show("Please insert a File!");
                return;
            }
            ReadXML readxml = new ReadXML();
            bool wellformed = readxml.ReadFile(Pathtextbox.Text);
            if (!wellformed) {
                MessageBox.Show("Malformed XML File! Please use another one!");
                return;
            }
            Ui.EnableNextTab(Prognosentab, MainTabControl);
            
        }



        private void UpdateSummeFromForcast(object sender, TextChangedEventArgs e) {
            try {
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
            } catch { }
        }

        private void NumberDoubleValidationTextBox(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9,.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NumberIntValidationTextBox(object sender, TextCompositionEventArgs e) {
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

