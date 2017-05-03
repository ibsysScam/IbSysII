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
using Ibsys2.Pages.ReadXML;
using System.IO;
using Ibsys2.Pages;
using Ibsys2.Service;
using Ibsys2.Pages.Wiki;

namespace Ibsys2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SettingsService.Class.InitializeXML();
            SettingsService.Class.LoadSettings();
            InitializeTranslation();
            TranslateService.Class.PrimaryLanguage = "de";
            TranslateService.Class.FallbackLanguage = "en";
            InitializeComponent();
            
        }

        private void Choosefile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialogDateipfad = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> dialogDateipfadResult = dialogDateipfad.ShowDialog();
            if (dialogDateipfadResult == true)
            {
                pathtextbox.Text = dialogDateipfad.FileName;
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

        private void Xmlgenerate_Click(object sender, RoutedEventArgs e)
        {
            ReadXML readxml = new ReadXML();
            readxml.ReadFile(pathtextbox.Text);
        }


        private void InitializeTranslation()
        {

        }


        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            string filename;
            Console.WriteLine("OnDragEnter");
            bool validData = GetFilename(out filename, e);
            Console.WriteLine(validData.ToString());
            if (!validData)
            {
                MessageBox.Show("File is not an XML File!");
                return;
            }

            pathtextbox.Text = filename;
        }


        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            pathtextbox.Text = "";
        }



        private void Settingsmenuheader_Click(object sender, RoutedEventArgs e)
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
    }
}
