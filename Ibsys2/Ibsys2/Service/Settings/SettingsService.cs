using System.IO;
using Ibsys2.Static;
using System;
using System.Xml;
using System.Text;

namespace Ibsys2.Service
{
    public class SettingsService
    {
        private static SettingsService _class;
        public static SettingsService Class
        {
            get
            {
                if (_class == null)
                    new SettingsService();
                return _class;
            }
        }


        public SettingsService()
        {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
           
            
        }

        public void LoadSettings()
        {
            string filepath = Static.Static.settingsfile;
            string xmlinput = File.ReadAllText(filepath);

            ReadSettings(xmlinput);
        }

        public void ReadSettings(string XMLInput)
        {
          

            if (String.IsNullOrEmpty(XMLInput))
                throw new ArgumentNullException();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(XMLInput);


            XmlNode language = doc.SelectSingleNode("/Settings/Language");
            Static.Static.language = language.InnerText;

            TranslateService.Class.PrimaryLanguage = Static.Static.language;

        }

        public void SaveSettings(string ElementID, string value)
        {
            string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Static.Static.settingsfile);

            XmlDocument document = new XmlDocument();
            XmlNode Root = document.CreateElement("Settings");
            document.AppendChild(Root);
            Root.AppendChild(document.CreateElement("Language")).InnerText = TranslateService.Class.GetPrimaryLanguage.LanguageShortText;
            using (TextWriter sw = new StreamWriter(filename,false, Encoding.UTF8))
            {
                document.Save(sw);
            }
        }

        public void InitializeXML()
        {
            
            string file = Static.Static.settingsfile;
            string initialsettings = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<Settings>
<Language>Deutsch</Language>
</Settings>";


            if (!File.Exists(file))
            {
               
                StreamWriter sw = new StreamWriter(file);
                sw.Write(initialsettings);
                sw.Close();
            }
        }
    }
}
