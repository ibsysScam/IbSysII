﻿using System;
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
            periode0.Content = (Static.Static.lastperiod + 1).ToString();
            periode1.Content = (Static.Static.lastperiod + 2).ToString();
            periode2.Content = (Static.Static.lastperiod + 3).ToString();
            periode3.Content = (Static.Static.lastperiod + 4).ToString();
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
            string filename;
            Console.WriteLine("OnDragEnter");
            bool validData = GetFilename(out filename, e);
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

            if (AllFilled())
            {
                try
                {
                    Forecast.Class.AddForecast(0, new Forecast.ForecastPeriod(Convert.ToInt32(period0product1.Text), Convert.ToInt32(period0product2.Text), Convert.ToInt32(period0product3.Text)));
                    Forecast.Class.AddForecast(1, new Forecast.ForecastPeriod(Convert.ToInt32(period1product1.Text), Convert.ToInt32(period1product2.Text), Convert.ToInt32(period1product3.Text)));
                    Forecast.Class.AddForecast(2, new Forecast.ForecastPeriod(Convert.ToInt32(period2product1.Text), Convert.ToInt32(period2product2.Text), Convert.ToInt32(period2product3.Text)));
                    Forecast.Class.AddForecast(3, new Forecast.ForecastPeriod(Convert.ToInt32(period3product1.Text), Convert.ToInt32(period3product2.Text), Convert.ToInt32(period3product3.Text)));
                    Ui.EnableNextTab(xmloutputtab);


                }
                catch (FormatException)
                {
                    MessageBox.Show(TranslateService.Class.GetTranslation("ONLY_INT_ERROR"));
                }
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
            Prognosentab.IsEnabled = true;
            MainTabControl.SelectedIndex = 1;
        }



        private void UpdateSummeFromForcast(object sender, TextChangedEventArgs e) {
            try {
                period0sum.Text = (Convert.ToInt32(period0product1.Text) + Convert.ToInt32(period0product2.Text) + Convert.ToInt32(period0product3.Text)).ToString();
                period1sum.Text = (Convert.ToInt32(period1product1.Text) + Convert.ToInt32(period1product2.Text) + Convert.ToInt32(period1product3.Text)).ToString();
                period2sum.Text = (Convert.ToInt32(period2product1.Text) + Convert.ToInt32(period2product2.Text) + Convert.ToInt32(period2product3.Text)).ToString();
                period3sum.Text = (Convert.ToInt32(period3product1.Text) + Convert.ToInt32(period3product2.Text) + Convert.ToInt32(period3product3.Text)).ToString();
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


    }
}

