using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ibsys2.Static;
using Ibsys2.Service;

namespace Ibsys2.Pages
{
    /// <summary>
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        
        public Settings()
        {
            InitializeComponent();
            LoadLanguages();
            LanguageLabel.Content = TranslateService.Class.GetTranslation("LANGUAGE") + ":";
            SettingsPage.Title = TranslateService.Class.GetTranslation("LANGUAGE");

        }

        public void LoadLanguages()
        {
            var languages = TranslateService.Class.GetLanguages();
            foreach (var language in languages)
            {
                Languageselector.Items.Add(language.LanguageLongText);
            }
            Languageselector.SelectedValue = TranslateService.Class.GetPrimaryLanguage.LanguageLongText;
        }

        private void Languageselector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SettingsService.Class.SaveSettings("Language", Languageselector.SelectionBoxItem.ToString());
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            TranslateService.Class.PrimaryLanguage = Languageselector.SelectionBoxItem.ToString();
            Thread.Sleep(100);
            LanguageLabel.Content = TranslateService.Class.GetTranslation("LANGUAGE") + ":";
            SettingsPage.Title = TranslateService.Class.GetTranslation("LANGUAGE");
            SettingsService.Class.SaveSettings();
            MessageBoxResult result = MessageBox.Show(TranslateService.Class.GetTranslation("SETTINGS_SAVED"), "Settings", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);

            if(result == MessageBoxResult.Yes)
            {
                try {
                    System.Diagnostics.Process P = new System.Diagnostics.Process();
                    P.StartInfo.FileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    P.Start();
                } catch { }
                Environment.Exit(21);
            }
            this.Close();
        }


    }
}
