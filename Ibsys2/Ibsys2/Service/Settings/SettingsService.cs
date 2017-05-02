using System.IO;
using Ibsys2.Static;
using System;
using System.Xml;

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
        public void ReadSettings()
        {
            string filepath = Static.Static.settingsfile;

            string xmlinput = File.ReadAllText(filepath);

            if (String.IsNullOrEmpty(xmlinput))
                throw new ArgumentNullException();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlinput);


            XmlNode language = doc.SelectSingleNode("/Settings/Language");
            Static.Static.language = language.InnerText;



        }

        public void SaveSettings(string ElementID, string value)
        {
            XmlWriter writer = XmlWriter.Create(Static.Static.settingsfile);

            writer.WriteStartDocument();
            writer.WriteStartElement("Settings");

            if(ElementID  == "Language")
            {
                writer.WriteElementString(ElementID, value);
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
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
