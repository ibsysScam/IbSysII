using System.IO;
using Ibsys2.Static;
using System;

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

        }

        public void SaveSettings()
        {

        }

        public void InitializeXML()
        {
            
            string file = Static.Static.settingsfile;
            string initialsettings = @"
    <?xml version=""1.0"" encoding=""UTF - 8""?>
    <settings>
        <language>deutsch</language>

    </settings>";


            if (!File.Exists(file))
            {
                File.Create(file);
                StreamWriter sw = new StreamWriter(file);
                sw.Write(initialsettings);
                sw.Close();
            }
        }
    }
}
