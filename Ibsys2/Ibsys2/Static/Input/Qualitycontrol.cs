using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Input {
    static class Qualitycontrol {
        //<qualitycontrol type = "no" losequantity="0" delay="0"/>

        private static string _typ = "";

        public static string typ {
            get { return _typ; }
            set {
                if (String.IsNullOrEmpty(value))
                    throw new Exception();
                _typ = value;
            }
        }

        private static int _losequantity = 0;

        public static int losequantity {
            get { return _losequantity; }
            set {
                if (value < 0)
                    throw new Exception();
                _losequantity = value;
            }
        }


        private static int _delay = 0;

        public static int delay {
            get { return _delay; }
            set {
                if (value < 0)
                    throw new Exception();
                _delay = value;
            }
        }

    }
}
