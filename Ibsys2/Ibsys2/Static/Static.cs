using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static {
    static class Static {
        public static int game = 0;
        public static int group = 0;
        public static int period = 0;
        public static string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public static string settingsfile = "settings.xml";
        public static string settingsfolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Ibsys2\");
        public static string settingspath = Path.Combine(settingsfolder, settingsfile);
    }
}
