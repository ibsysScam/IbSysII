using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Output {
    public class Qualitycontrol {
        //<qualitycontrol type = "no" losequantity="0" delay="0"/>

        private string _typ = "no";

        private static Qualitycontrol _class;

        public static Qualitycontrol Class {
            get {
                if (_class == null)
                    new Qualitycontrol();
                return _class;
            }
        }

        public Qualitycontrol() {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
        }

        public string typ {
            get { return _typ; }
            set {
                if (String.IsNullOrEmpty(value))
                    throw new Exception();
                _typ = value;
            }
        }

        private int _losequantity = 0;

        public int losequantity {
            get { return _losequantity; }
            set {
                if (value < 0)
                    throw new Exception();
                _losequantity = value;
            }
        }


        private int _delay = 0;

        public int delay {
            get { return _delay; }
            set {
                if (value < 0)
                    throw new Exception();
                _delay = value;
            }
        }

        public string XMLOutput() {
            return "<qualitycontrol type=\"" + _typ + "\" losequantity=\"" + _losequantity.ToString() + "\" delay=\"" + delay.ToString() + "\"/>";
        }
        public void ClearClass() {
            _class = null;
        }
    }
}
