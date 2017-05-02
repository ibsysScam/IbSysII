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

        }

        public void LoadLanguages()
        {
            var languages = TranslateService.Class.GetLanguages();
            foreach (var language in languages)
            {
                Languageselector.Items.Add(language.LanguageLongText);
            }
            Languageselector.SelectedValue = Static.Static.language;
        }

        private void Languageselector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SettingsService.Class.SaveSettings("Language", Languageselector.SelectionBoxItem.ToString());
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(100);
            MessageBox.Show(TranslateService.Class.GetTranslation("SETTINGS_SAVED"), "Settings", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            //SettingsService.Class.SaveSettings("Language",Languageselector.SelectionBoxItem.ToString());
            return;
        }


    }
}
