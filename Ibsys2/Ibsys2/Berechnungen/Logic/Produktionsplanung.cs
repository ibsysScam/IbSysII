using Ibsys2.Static.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Berechnungen.Logic
{
    static class Produktionsplanung
    {

        //Kinderfahrrad
        public static int p1;
        public static int e26K;
        public static int e51;
        public static int e16K;
        public static int e17K;
        public static int e50;
        public static int e4;
        public static int e10;
        public static int e49;
        public static int e7;
        public static int e13;
        public static int e18;

        //Damenfahrrad
        public static int p2;
        public static int e26D;
        public static int e56;
        public static int e16D;
        public static int e17D;
        public static int e55;
        public static int e5;
        public static int e11;
        public static int e54;
        public static int e8;
        public static int e14;
        public static int e19;

        //Herrenfahrrad
        public static int p3;
        public static int e26H;
        public static int e31;
        public static int e16H;
        public static int e17H;
        public static int e30;
        public static int e6;
        public static int e12;
        public static int e29;
        public static int e9;
        public static int e15;
        public static int e20;


        //Kaufteile
        public static int k21;
        public static int k22;
        public static int k23;
        public static int k24;
        public static int k25;
        public static int k27;
        public static int k28;

        public static int k32;
        public static int k33;
        public static int k34;
        public static int k35;
        public static int k36;
        public static int k37;
        public static int k38;
        public static int k39;
        public static int k40;
        public static int k41;
        public static int k42;
        public static int k43;
        public static int k44;
        public static int k45;
        public static int k46;
        public static int k47;
        public static int k48;

        public static int k52;
        public static int k53;

        public static int k57;
        public static int k58;
        public static int k59;


        public static int getBedarfByID(int id)
        {

            berechnen();

            switch (id)
            {
                case 1: return p1;
                case 2: return p2;
                case 3: return p3;
                case 4: return e4;
                case 5: return e5;
                case 6: return e6;
                case 7: return e7;
                case 8: return e8;
                case 9: return e9;
                case 10: return e10;
                case 11: return e11;
                case 12: return e12;
                case 13: return e13;
                case 14: return e14;
                case 15: return e15;
                case 16: return e16K + e16D + e16H;
                case 17: return e17K + e17D + e17H;
                case 18: return e18;
                case 19: return e19;
                case 20: return e20;

				case 21: return k21;
				case 22: return k22;
				case 23: return k23;
				case 24: return k24;
				case 25: return k25;
                    
                case 26: return e26K + e26D + e26H;

				case 27: return k27;
				case 28: return k28;
                    
                case 29: return e29;
                case 30: return e30;
                case 31: return e31;

                case 32: return k32;
				case 33: return k33;
				case 34: return k34;
				case 35: return k35;
				case 36: return k36;
				case 37: return k37;
				case 38: return k38;
				case 39: return k39;
				case 40: return k40;
				case 41: return k41;
				case 42: return k42;
				case 43: return k43;
				case 44: return k44;
				case 45: return k45;
				case 46: return k46;
				case 47: return k47;
				case 48: return k48;
                    
                case 49: return e49;
                case 50: return e50;
                case 51: return e51;

                case 52: return k52;
		        case 53: return k53;

                case 54: return e54;
                case 55: return e55;
                case 56: return e56;

				case 57: return k57;
				case 58: return k58;
				case 59: return k59;

				default: return 0;
            }
        }


        public static void berechnen()
        {
            ValueStore vs = ValueStore.Instance;
            
            Warehousestock w = Warehousestock.Class;
            Waitinglistworkstations wlw = Waitinglistworkstations.Class;
            Ordersinwork oiw = Ordersinwork.Class;


            #region Verbindliche Aufträge
            // Kinderfahrrad
            p1 = vs.vertriebswunschP1 + vs.sicherheitsbestandP1 - w.GetArticleByID(1).Amount - wlw.GetArticleAmountByID(1) - oiw.GetArticleAmountByID(1);
            p1 = p1 + ((10 - (p1 % 10)) % 10);
            if (p1 < 0) p1 = 0;

            e26K = p1 + wlw.GetArticleAmountByID(1) + vs.sicherheitsbestandP1 - (w.GetArticleByID(26).Amount / 3 + wlw.GetArticleAmountByID(26) / 3 + oiw.GetArticleAmountByID(26) / 3);
            e26K = e26K + ((10 - (e26K % 10)) % 10);
            if (e26K < 0) e26K = 0;
            e51 = p1 + wlw.GetArticleAmountByID(1) + vs.sicherheitsbestandP1 - (w.GetArticleByID(51).Amount + wlw.GetArticleAmountByID(51) + oiw.GetArticleAmountByID(51));
            e51 = e51 + ((10 - (e51 % 10)) % 10);
            if (e51 < 0) e51 = 0;

            e16K = e51 + wlw.GetArticleAmountByID(51) + vs.sicherheitsbestandP1 - (w.GetArticleByID(16).Amount / 3 + wlw.GetArticleAmountByID(16) / 3 + oiw.GetArticleAmountByID(16) / 3);
            e16K = e16K + ((10 - (e16K % 10)) % 10);
            if (e16K < 0) e16K = 0;
            e17K = e51 + wlw.GetArticleAmountByID(51) + vs.sicherheitsbestandP1 - (w.GetArticleByID(17).Amount / 3 + wlw.GetArticleAmountByID(17) / 3 + oiw.GetArticleAmountByID(17) / 3);
            e17K = e17K + ((10 - (e17K % 10)) % 10);
            if (e17K < 0) e17K = 0;
            e50 = e51 + wlw.GetArticleAmountByID(51) + vs.sicherheitsbestandP1 - (w.GetArticleByID(50).Amount + wlw.GetArticleAmountByID(50) + oiw.GetArticleAmountByID(50));
            e50 = e50 + ((10 - (e50 % 10)) % 10);
            if (e50 < 0) e50 = 0;

            e4 = e50 + wlw.GetArticleAmountByID(50) + vs.sicherheitsbestandP1 - (w.GetArticleByID(4).Amount + wlw.GetArticleAmountByID(4) + oiw.GetArticleAmountByID(4));
            e4 = e4 + ((10 - (e4 % 10)) % 10);
            if (e4 < 0) e4 = 0;
            e10 = e50 + wlw.GetArticleAmountByID(50) + vs.sicherheitsbestandP1 - (w.GetArticleByID(10).Amount + wlw.GetArticleAmountByID(10) + oiw.GetArticleAmountByID(10));
            e10 = e10 + ((10 - (e10 % 10)) % 10);
            if (e10 < 0) e10 = 0;
            e49 = e50 + wlw.GetArticleAmountByID(50) + vs.sicherheitsbestandP1 - (w.GetArticleByID(49).Amount + wlw.GetArticleAmountByID(49) + oiw.GetArticleAmountByID(49));
            e49 = e49 + ((10 - (e49 % 10)) % 10);
            if (e49 < 0) e49 = 0;

            e7 = e49 + wlw.GetArticleAmountByID(49) + vs.sicherheitsbestandP1 - (w.GetArticleByID(7).Amount + wlw.GetArticleAmountByID(7) + oiw.GetArticleAmountByID(7));
            e7 = e7 + ((10 - (e7 % 10)) % 10);
            if (e7 < 0) e7 = 0;
            e13 = e49 + wlw.GetArticleAmountByID(49) + vs.sicherheitsbestandP1 - (w.GetArticleByID(13).Amount + wlw.GetArticleAmountByID(13) + oiw.GetArticleAmountByID(13));
            e13 = e13 + ((10 - (e13 % 10)) % 10);
            if (e13 < 0) e13 = 0;
            e18 = e49 + wlw.GetArticleAmountByID(49) + vs.sicherheitsbestandP1 - (w.GetArticleByID(18).Amount + wlw.GetArticleAmountByID(18) + oiw.GetArticleAmountByID(18));
            e18 = e18 + ((10 - (e18 % 10)) % 10);
            if (e18 < 0) e18 = 0;

            // Damenfahrrad
            p2 = vs.vertriebswunschP2 + vs.sicherheitsbestandP2 - w.GetArticleByID(2).Amount - wlw.GetArticleAmountByID(2) - oiw.GetArticleAmountByID(2);
            p2 = p2 + ((10 - (p2 % 10)) % 10);
            if (p2 < 0) p2 = 0;

            e26D = p2 + wlw.GetArticleAmountByID(2) + vs.sicherheitsbestandP2 - (w.GetArticleByID(26).Amount / 3 + wlw.GetArticleAmountByID(26) / 3 + oiw.GetArticleAmountByID(26) / 3);
            e26D = e26D + ((10 - (e26D % 10)) % 10);
            if (e26D < 0) e26D = 0;
            e56 = p2 + wlw.GetArticleAmountByID(2) + vs.sicherheitsbestandP2 - (w.GetArticleByID(56).Amount + wlw.GetArticleAmountByID(56) + oiw.GetArticleAmountByID(56));
            e56 = e56 + ((10 - (e56 % 10)) % 10);
            if (e56 < 0) e56 = 0;

            e16D = e56 + wlw.GetArticleAmountByID(56) + vs.sicherheitsbestandP2 - (w.GetArticleByID(16).Amount / 3 + wlw.GetArticleAmountByID(16) / 3 + oiw.GetArticleAmountByID(16) / 3);
            e16D = e16D + ((10 - (e16D % 10)) % 10);
            if (e16D < 0) e16D = 0;
            e17D = e56 + wlw.GetArticleAmountByID(56) + vs.sicherheitsbestandP2 - (w.GetArticleByID(17).Amount / 3 + wlw.GetArticleAmountByID(17) / 3 + oiw.GetArticleAmountByID(17) / 3);
            e17D = e17D + ((10 - (e17D % 10)) % 10);
            if (e17D < 0) e17D = 0;
            e55 = e56 + wlw.GetArticleAmountByID(56) + vs.sicherheitsbestandP2 - (w.GetArticleByID(55).Amount + wlw.GetArticleAmountByID(55) + oiw.GetArticleAmountByID(55));
            e55 = e55 + ((10 - (e55 % 10)) % 10);
            if (e55 < 0) e55 = 0;

            e5 = e55 + wlw.GetArticleAmountByID(55) + vs.sicherheitsbestandP2 - (w.GetArticleByID(5).Amount + wlw.GetArticleAmountByID(5) + oiw.GetArticleAmountByID(5));
            e5 = e5 + ((10 - (e5 % 10)) % 10);
            if (e5 < 0) e5 = 0;
            e11 = e55 + wlw.GetArticleAmountByID(55) + vs.sicherheitsbestandP2 - (w.GetArticleByID(11).Amount + wlw.GetArticleAmountByID(11) + oiw.GetArticleAmountByID(11));
            e11 = e11 + ((10 - (e11 % 10)) % 10);
            if (e11 < 0) e11 = 0;
            e54 = e55 + wlw.GetArticleAmountByID(55) + vs.sicherheitsbestandP2 - (w.GetArticleByID(54).Amount + wlw.GetArticleAmountByID(54) + oiw.GetArticleAmountByID(54));
            e54 = e54 + ((10 - (e54 % 10)) % 10);
            if (e54 < 0) e54 = 0;

            e8 = e54 + wlw.GetArticleAmountByID(54) + vs.sicherheitsbestandP2 - (w.GetArticleByID(8).Amount + wlw.GetArticleAmountByID(8) + oiw.GetArticleAmountByID(8));
            e8 = e8 + ((10 - (e8 % 10)) % 10);
            if (e8 < 0) e8 = 0;
            e14 = e54 + wlw.GetArticleAmountByID(54) + vs.sicherheitsbestandP2 - (w.GetArticleByID(14).Amount + wlw.GetArticleAmountByID(14) + oiw.GetArticleAmountByID(14));
            e14 = e14 + ((10 - (e14 % 10)) % 10);
            if (e14 < 0) e14 = 0;
            e19 = e54 + wlw.GetArticleAmountByID(54) + vs.sicherheitsbestandP2 - (w.GetArticleByID(19).Amount + wlw.GetArticleAmountByID(19) + oiw.GetArticleAmountByID(19));
            e19 = e19 + ((10 - (e19 % 10)) % 10);
            if (e19 < 0) e19 = 0;

            // Herrenfahrrad
            p3 = vs.vertriebswunschP3 + vs.sicherheitsbestandP3 - w.GetArticleByID(3).Amount - wlw.GetArticleAmountByID(3) - oiw.GetArticleAmountByID(3);
            p3 = p3 + ((10 - (p3 % 10)) % 10);
            if (p3 < 0) p3 = 0;

            e26H = p3 + wlw.GetArticleAmountByID(3) + vs.sicherheitsbestandP3 - (w.GetArticleByID(26).Amount / 3 + wlw.GetArticleAmountByID(26) / 3 + oiw.GetArticleAmountByID(26) / 3);
            e26H = e26H + ((10 - (e26H % 10)) % 10);
            if (e26H < 0) e26H = 0;
            e31 = p3 + wlw.GetArticleAmountByID(3) + vs.sicherheitsbestandP3 - (w.GetArticleByID(31).Amount + wlw.GetArticleAmountByID(31) + oiw.GetArticleAmountByID(31));
            e31 = e31 + ((10 - (e31 % 10)) % 10);
            if (e31 < 0) e31 = 0;

            e16H = e31 + wlw.GetArticleAmountByID(31) + vs.sicherheitsbestandP3 - (w.GetArticleByID(16).Amount / 3 + wlw.GetArticleAmountByID(16) / 3 + oiw.GetArticleAmountByID(16) / 3);
            e16H = e16H + ((10 - (e16H % 10)) % 10);
            if (e16H < 0) e16H = 0;
            //System.Windows.MessageBox.Show(e31 + " + " + wlw.GetArticleAmountByID(31) + " + " + vs.sicherheitsbestandP3 + " - (" + (w.GetArticleByID(17).Amount / 3 + " + "  + wlw.GetArticleAmountByID(17) / 3 + " + " + oiw.GetArticleAmountByID(17) / 3) + ")");
            e17H = e31 + wlw.GetArticleAmountByID(31) + vs.sicherheitsbestandP3 - (w.GetArticleByID(17).Amount / 3 + wlw.GetArticleAmountByID(17) / 3 + oiw.GetArticleAmountByID(17) / 3);
            e17H = e17H + ((10 - (e17H % 10)) % 10);
            if (e17H < 0) e17H = 0;
            e30 = e31 + wlw.GetArticleAmountByID(31) + vs.sicherheitsbestandP3 - (w.GetArticleByID(30).Amount + wlw.GetArticleAmountByID(30) + oiw.GetArticleAmountByID(30));
            e30 = e30 + ((10 - (e30 % 10)) % 10);
            if (e30 < 0) e30 = 0;

            e6 = e30 + wlw.GetArticleAmountByID(30) + vs.sicherheitsbestandP3 - (w.GetArticleByID(6).Amount + wlw.GetArticleAmountByID(6) + oiw.GetArticleAmountByID(6));
            e6 = e6 + ((10 - (e6 % 10)) % 10);
            if (e6 < 0) e6 = 0;
            e12 = e30 + wlw.GetArticleAmountByID(30) + vs.sicherheitsbestandP3 - (w.GetArticleByID(12).Amount + wlw.GetArticleAmountByID(12) + oiw.GetArticleAmountByID(12));
            e12 = e12 + ((10 - (e12 % 10)) % 10);
            if (e12 < 0) e12 = 0;
            e29 = e30 + wlw.GetArticleAmountByID(30) + vs.sicherheitsbestandP3 - (w.GetArticleByID(29).Amount + wlw.GetArticleAmountByID(29) + oiw.GetArticleAmountByID(29));
            e29 = e29 + ((10 - (e29 % 10)) % 10);
            if (e29 < 0) e29 = 0;

            e9 = e29 + wlw.GetArticleAmountByID(29) + vs.sicherheitsbestandP3 - (w.GetArticleByID(9).Amount + wlw.GetArticleAmountByID(9) + oiw.GetArticleAmountByID(9));
            e9 = e9 + ((10 - (e9 % 10)) % 10);
            if (e9 < 0) e9 = 0;
            e15 = e29 + wlw.GetArticleAmountByID(29) + vs.sicherheitsbestandP3 - (w.GetArticleByID(15).Amount + wlw.GetArticleAmountByID(15) + oiw.GetArticleAmountByID(15));
            e15 = e15 + ((10 - (e15 % 10)) % 10);
            if (e15 < 0) e15 = 0;
            e20 = e29 + wlw.GetArticleAmountByID(29) + vs.sicherheitsbestandP3 - (w.GetArticleByID(20).Amount + wlw.GetArticleAmountByID(20) + oiw.GetArticleAmountByID(20));
            e20 = e20 + ((10 - (e20 % 10)) % 10);
            if (e20 < 0) e20 = 0;

            #endregion

            #region Kaufteile

            k21 = p1;
            k22 = p2;
            k23 = p3;
            k24 = p3 + e31 + e16H + e16D + e16K + 2 * e30 + 2 * e29 + p1 + e51 + 2 * e50 + 2 * e49 + p2 + e56 + 2 * e55 + 2 * e54;
            k25 = 2 * e50 + 2 * e49 + 2 * e55 + 2 * e54 + 2 * e30 + 2 * e29;
            k27 = p1 + e51 + p2 + e56 + p3 + e31;
            k28 = e16D + e16H + e16K + 3 * e18 + 4 * e19 + 5 * e20;
            k32 = e10 + e13 + e18 + e11 + e14 + e19 + e12 + e15 + e20;
            k33 = e6 + e9;
            k34 = 36 * e6 + 36 * e9;
            k35 = 2 * e4 + 2 * e7 + 2 * e5 + 2 * e8 + 2 * e6 + 2 * e9;
            k36 = e4 + e5 + e6;
            k37 = e7 + e8 + e9;
            k38 = e7 + e8 + e9;
            k39 = e10 + e13 + e11 + e14 + e12 + e15;
            k40 = e16K + e16H + e16D;
            k41 = e16K + e16H + e16D;
            k42 = 2 * e16K + 2 * e16H + 2 * e16D;
            k43 = e17K + e17H + e17D;
            k44 = 2 * e26K + 2 * e26H + 2 * e26D + e17K + e17H + e17D;
            k45 = e17K + e17H + e17D;
            k46 = e17K + e17H + e17D;
            k47 = e26K + e26H + e26D;
            k48 = 2 * e26K + 2 * e26H + 2 * e26D;
            k52 = e4 + e7;
            k53 = 36 * e4 + 36 * e7;
            k57 = e5 + e8;
            k58 = 36 * e5 + 36 * e8;
            k59 = 2 * e18 + 2 * e19 + 2 * e20;

            #endregion

        }

    }
}
