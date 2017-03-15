using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Input {
    static class Sellwish {
        //<sellwish><item article="[1-3]"  quantity="[0-999999]"/></sellwish>
        private static int _quantity1;
        private static int _quantity2;
        private static int _quantity3;


        public static int AnzahlArtikel1 {
            get { return _quantity1; }
            set {
                if (value < 0)
                    throw new Exception();
                _quantity1 = value;
            }
        }

        public static int AnzahlArtikel2 {
            get { return _quantity2; }
            set {
                if (value < 0)
                    throw new Exception();
                _quantity2 = value;
            }
        }

        public static int AnzahlArtikel3 {
            get { return _quantity3; }
            set {
                if (value < 0)
                    throw new Exception();
                _quantity3 = value;
            }
        }

        public static void setAnzahlArtikel(int artikel, int anzahl) {
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
    }
}
