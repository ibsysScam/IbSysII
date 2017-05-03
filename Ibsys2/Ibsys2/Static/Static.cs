using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ibsys2.Static.Input;
using Ibsys2.Static.Output;

namespace Ibsys2.Static {
    static class Static {
        public static int game = 0;
        public static int group = 0;
        public static int lastperiod = 0;
        public static string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public static string settingsfile = "settings.xml";
        public static string settingsfolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Ibsys2\");
        public static string settingspath = Path.Combine(settingsfolder, settingsfile);

        public static void ClearInputClasses() {
            Completedorders.Class.ClearClass();
            Cycletimes.Class.ClearClass();
            Futureinwardstockmovement.Class.ClearClass();
            Idletimecosts.Class.ClearClass();
            Inwardstockmovement.Class.ClearClass();
            Ordersinwork.Class.ClearClass();
            Waitingliststock.Class.ClearClass();
            Waitinglistworkstations.Class.ClearClass();
            Warehousestock.Class.ClearClass();
        }

        public static void ClearOutputClasses() {
            Orderlist.Class.ClearClass();
            Productionlist.Class.ClearClass();
            Qualitycontrol.Class.ClearClass();
            Selldirect.Class.ClearClass();
            Sellwish.Class.ClearClass();
            Workingtimelist.Class.ClearClass();
        }
    }
}
