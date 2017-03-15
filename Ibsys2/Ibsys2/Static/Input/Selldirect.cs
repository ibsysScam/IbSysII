using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Input {
    static class Selldirect {
        //<selldirect><item article="[1-3]" quantity="0" price="0.0" penalty="0.0"/></selldirect>
        private static int _quantity1;
        private static int _quantity2;
        private static int _quantity3;

        private static double _prize1;
        private static double _prize2;
        private static double _prize3;
        
        private static double _penalty1;
        private static double _penalty2;
        private static double _penalty3;


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

        public static double PreisArtikel1 {
            get { return _prize1; }
            set {
                if (value < 0)
                    throw new Exception();
                _prize1 = value;
            }
        }

        public static double PreisArtikel2 {
            get { return _prize2; }
            set {
                if (value < 0)
                    throw new Exception();
                _prize2 = value;
            }
        }

        public static double PreisArtikel3 {
            get { return _prize3; }
            set {
                if (value < 0)
                    throw new Exception();
                _prize3 = value;
            }
        }



        public static double StrafeArtikel1 {
            get { return _penalty1; }
            set {
                if (value < 0)
                    throw new Exception();
                _penalty1 = value;
            }
        }

        public static double StrafeArtikel2 {
            get { return _penalty2; }
            set {
                if (value < 0)
                    throw new Exception();
                _penalty2 = value;
            }
        }

        public static double StrafeArtikel3 {
            get { return _penalty3; }
            set {
                if (value < 0)
                    throw new Exception();
                _penalty3 = value;
            }
        }

        public static void setAnzahlArtikel(int artikel, int anzahl, double prize, double penalty) {
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
