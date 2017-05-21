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
            string filepath = Static.Static.settingspath;
            try {
                string xmlinput = File.ReadAllText(filepath);
                ReadSettings(xmlinput);
            } catch {
                SaveSettings();
            }
        }

        public void ReadSettings(string XMLInput)
        {
          

            if (String.IsNullOrEmpty(XMLInput))
                throw new ArgumentNullException();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(XMLInput);


            XmlNode language = doc.SelectSingleNode("/Settings/Language");
            string fulllanguage = language.InnerText;

            TranslateService.Class.PrimaryLanguage = fulllanguage;

        }

        public void SaveSettings()
        {
            
            string filename = Static.Static.settingspath;
            XmlDocument document = new XmlDocument();
            XmlNode Root = document.CreateElement("Settings");
            document.AppendChild(Root);
            Root.AppendChild(document.CreateElement("Language")).InnerText = TranslateService.Class.GetPrimaryLanguage.LanguageShortText;
            using (TextWriter sw = new StreamWriter(filename,false, Encoding.UTF8))
            {
                document.Save(sw);
            }
        }

        public void CreateFolder()
        {
            if (!Directory.Exists(Static.Static.settingsfolder))
            {
                string rootfolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ibsys2");
                Directory.CreateDirectory(rootfolder);

            }


           

            return;
        }
    }
}
