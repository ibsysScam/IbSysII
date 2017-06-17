using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Output {
    public class Selldirect : INotifyPropertyChanged
    {
        //<selldirect><item article="[1-3]" quantity="0" price="0.0" penalty="0.0"/></selldirect>
        private int _quantity1;
        private int _quantity2;
        private int _quantity3;

        private double _prize1;
        private double _prize2;
        private double _prize3;
        
        private double _penalty1;
        private double _penalty2;
        private double _penalty3;

        private static Selldirect _class;

        public static Selldirect Class {
            get {
                if (_class == null)
                    new Selldirect();
                return _class;
            }
        }

        public Selldirect() {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
        }


        public int AnzahlArtikel1 {
            get { return _quantity1; }
            set {
                if (value < 0)
                    throw new Exception();
                _quantity1 = value;
            }
        }

        public int AnzahlArtikel2 {
            get { return _quantity2; }
            set {
                if (value < 0)
                    throw new Exception();
                _quantity2 = value;
            }
        }

        public int AnzahlArtikel3 {
            get { return _quantity3; }
            set {
                if (value < 0)
                    throw new Exception();
                _quantity3 = value;
            }
        }

        public double PreisArtikel1 {
            get { return _prize1; }
            set {
                if (value < 0)
                    throw new Exception();
                _prize1 = value;
            }
        }

        public double PreisArtikel2 {
            get { return _prize2; }
            set {
                if (value < 0)
                    throw new Exception();
                _prize2 = value;
            }
        }

        public double PreisArtikel3 {
            get { return _prize3; }
            set {
                if (value < 0)
                    throw new Exception();
                _prize3 = value;
            }
        }



        public double StrafeArtikel1 {
            get { return _penalty1; }
            set {
                if (value < 0)
                    throw new Exception();
                _penalty1 = value;
            }
        }

        public double StrafeArtikel2 {
            get { return _penalty2; }
            set {
                if (value < 0)
                    throw new Exception();
                _penalty2 = value;
            }
        }

        public double StrafeArtikel3 {
            get { return _penalty3; }
            set {
                if (value < 0)
                    throw new Exception();
                _penalty3 = value;
            }
        }

        public void setAnzahlArtikel(int artikel, int anzahl, double prize, double penalty) {
            switch (artikel) {
                case 1:
                    AnzahlArtikel1 = anzahl;
                    break;
                case 2:
                    AnzahlArtikel2 = anzahl;
                    break;
                case 3:
                    AnzahlArtikel3 = anzahl;
                    break;
                default:
                    throw new Exception();
            }
        }

        public string XMLOutput() {
            return (@"<selldirect><item article=""1"" quantity="""+_quantity1+ @""" price=""" + string.Format("{0:0.0}", _prize1) + @""" penalty=""" + string.Format("{0:0.0}", _penalty1) + @"""/><item article=""2"" quantity=""" + _quantity2 + @""" price=""" + string.Format("{0:0.0}", _prize2) + @""" penalty=""" + string.Format("{0:0.0}", _penalty2) + @"""/><item article=""3"" quantity=""" + _quantity3 + @""" price=""" + string.Format("{0:0.0}", _prize3) + @""" penalty=""" + string.Format("{0:0.0}", _penalty3) + @"""/></selldirect>").Replace(",", ".");
        }

        public void ClearClass() {
            _class = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
