using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static {
    static class Static {
        public static int game = 0;
        public static int group = 0;
        public static int period = 0;
        public static string string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

    }
}
