using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Output {
    public class Sellwish: INotifyPropertyChanged
    {
        //<sellwish><item article="[1-3]"  quantity="[0-999999]"/></sellwish>
        private int _quantity1;
        private int _quantity2;
        private int _quantity3;

        private static Sellwish _class;



        public static Sellwish Class {
            get {
                if (_class == null)
                    new Sellwish();
                return _class;
            }
        }



        public Sellwish() {
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

        public void setAnzahlArtikel(int artikel, int anzahl) {
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
            string Output = "<sellwish>";
            if (_quantity1 > 0)
                Output += @"<item article=""1"" quantity=""" + _quantity1 + @"""/>";
            if (_quantity2 > 0)
                Output += @"<item article=""2"" quantity=""" + _quantity2 + @"""/>";
            if (_quantity3 > 0)
                Output += @"<item article=""3"" quantity=""" + _quantity3 + @"""/>";
            return Output + "</sellwish>";
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
