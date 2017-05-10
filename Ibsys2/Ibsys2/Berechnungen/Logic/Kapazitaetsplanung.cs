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
        public static int k23;
        public static int k24;
        public static int k25;
        public static int k27;
        public static int k28;

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

        public static int k59;




        public static void berechnen()
        {
            Warehousestock w = Warehousestock.Class;
            Waitinglistworkstations wlw = Waitinglistworkstations.Class;
            Ordersinwork oiw = Ordersinwork.Class;

            ValueStore vs = ValueStore.Instance;

            #region Verbindliche Aufträge
            // Kinderfahrrad
            p1 = vs.vertriebswunschP1 + vs.sicherheitsbestandP1 - w.GetArticleByID(1).Amount - wlw.GetArticleAmountByID(1) - oiw.GetArticleAmountByID(1);

            e26K = p1 + wlw.GetArticleAmountByID(1) + vs.sicherheitsbestandP1 + w.GetArticleByID(26).Amount / 3 + wlw.GetArticleAmountByID(26) / 3 + oiw.GetArticleAmountByID(26) / 3;
            e51 = p1 + wlw.GetArticleAmountByID(1) + vs.sicherheitsbestandP1 + w.GetArticleByID(51).Amount + wlw.GetArticleAmountByID(51) + oiw.GetArticleAmountByID(51);

            e16K = e51 + wlw.GetArticleAmountByID(51) + vs.sicherheitsbestandP1 - w.GetArticleByID(16).Amount / 3 + wlw.GetArticleAmountByID(16) / 3 + oiw.GetArticleAmountByID(16) / 3;
            e17K = e51 + wlw.GetArticleAmountByID(51) + vs.sicherheitsbestandP1 - w.GetArticleByID(17).Amount / 3 + wlw.GetArticleAmountByID(17) / 3 + oiw.GetArticleAmountByID(17) / 3;
            e50 = e51 + wlw.GetArticleAmountByID(51) + vs.sicherheitsbestandP1 - w.GetArticleByID(50).Amount + wlw.GetArticleAmountByID(50) + oiw.GetArticleAmountByID(50);

            e4 = e50 + wlw.GetArticleAmountByID(50) + vs.sicherheitsbestandP1 - w.GetArticleByID(4).Amount + wlw.GetArticleAmountByID(4) + oiw.GetArticleAmountByID(4);
            e10 = e50 + wlw.GetArticleAmountByID(50) + vs.sicherheitsbestandP1 - w.GetArticleByID(10).Amount + wlw.GetArticleAmountByID(10) + oiw.GetArticleAmountByID(10);
            e49 = e50 + wlw.GetArticleAmountByID(50) + vs.sicherheitsbestandP1 - w.GetArticleByID(49).Amount + wlw.GetArticleAmountByID(49) + oiw.GetArticleAmountByID(49);

            e7 = e49 + wlw.GetArticleAmountByID(49) + vs.sicherheitsbestandP1 - w.GetArticleByID(7).Amount + wlw.GetArticleAmountByID(7) + oiw.GetArticleAmountByID(7);
            e13 = e49 + wlw.GetArticleAmountByID(49) + vs.sicherheitsbestandP1 - w.GetArticleByID(13).Amount + wlw.GetArticleAmountByID(13) + oiw.GetArticleAmountByID(13);
            e18 = e49 + wlw.GetArticleAmountByID(49) + vs.sicherheitsbestandP1 - w.GetArticleByID(18).Amount + wlw.GetArticleAmountByID(18) + oiw.GetArticleAmountByID(18);

            // Damenfahrrad
            p2 = vs.vertriebswunschP2 + vs.sicherheitsbestandP2 - w.GetArticleByID(2).Amount - wlw.GetArticleAmountByID(2) - oiw.GetArticleAmountByID(2);

            e26D = p2 + wlw.GetArticleAmountByID(2) + vs.sicherheitsbestandP2 + w.GetArticleByID(26).Amount / 3 + wlw.GetArticleAmountByID(26) / 3 + oiw.GetArticleAmountByID(26) / 3;
            e56 = p2 + wlw.GetArticleAmountByID(2) + vs.sicherheitsbestandP2 + w.GetArticleByID(56).Amount + wlw.GetArticleAmountByID(56) + oiw.GetArticleAmountByID(56);

            e16D = e56 + wlw.GetArticleAmountByID(56) + vs.sicherheitsbestandP2 - w.GetArticleByID(16).Amount / 3 + wlw.GetArticleAmountByID(16) / 3 + oiw.GetArticleAmountByID(16) / 3;
            e17D = e56 + wlw.GetArticleAmountByID(56) + vs.sicherheitsbestandP2 - w.GetArticleByID(17).Amount / 3 + wlw.GetArticleAmountByID(17) / 3 + oiw.GetArticleAmountByID(17) / 3;
            e55 = e56 + wlw.GetArticleAmountByID(56) + vs.sicherheitsbestandP2 - w.GetArticleByID(55).Amount + wlw.GetArticleAmountByID(55) + oiw.GetArticleAmountByID(55);

            e5 = e55 + wlw.GetArticleAmountByID(55) + vs.sicherheitsbestandP2 - w.GetArticleByID(5).Amount + wlw.GetArticleAmountByID(5) + oiw.GetArticleAmountByID(5);
            e11 = e55 + wlw.GetArticleAmountByID(55) + vs.sicherheitsbestandP2 - w.GetArticleByID(11).Amount + wlw.GetArticleAmountByID(11) + oiw.GetArticleAmountByID(11);
            e54 = e55 + wlw.GetArticleAmountByID(55) + vs.sicherheitsbestandP2 - w.GetArticleByID(54).Amount + wlw.GetArticleAmountByID(54) + oiw.GetArticleAmountByID(54);

            e8 = e54 + wlw.GetArticleAmountByID(54) + vs.sicherheitsbestandP2 - w.GetArticleByID(8).Amount + wlw.GetArticleAmountByID(8) + oiw.GetArticleAmountByID(8);
            e14 = e54 + wlw.GetArticleAmountByID(54) + vs.sicherheitsbestandP2 - w.GetArticleByID(14).Amount + wlw.GetArticleAmountByID(14) + oiw.GetArticleAmountByID(14);
            e19 = e54 + wlw.GetArticleAmountByID(54) + vs.sicherheitsbestandP2 - w.GetArticleByID(19).Amount + wlw.GetArticleAmountByID(19) + oiw.GetArticleAmountByID(19);

            // Herrenfahrrad
            p3 = vs.vertriebswunschP3 + vs.sicherheitsbestandP3 - w.GetArticleByID(3).Amount - wlw.GetArticleAmountByID(3) - oiw.GetArticleAmountByID(3);

            e26H = p3 + wlw.GetArticleAmountByID(3) + vs.sicherheitsbestandP3 + w.GetArticleByID(26).Amount / 3 + wlw.GetArticleAmountByID(26) / 3 + oiw.GetArticleAmountByID(26) / 3;
            e31 = p3 + wlw.GetArticleAmountByID(3) + vs.sicherheitsbestandP3 + w.GetArticleByID(31).Amount + wlw.GetArticleAmountByID(31) + oiw.GetArticleAmountByID(31);

            e16H = e31 + wlw.GetArticleAmountByID(31) + vs.sicherheitsbestandP3 - w.GetArticleByID(16).Amount / 3 + wlw.GetArticleAmountByID(16) / 3 + oiw.GetArticleAmountByID(16) / 3;
            e17H = e31 + wlw.GetArticleAmountByID(31) + vs.sicherheitsbestandP3 - w.GetArticleByID(17).Amount / 3 + wlw.GetArticleAmountByID(17) / 3 + oiw.GetArticleAmountByID(17) / 3;
            e30 = e31 + wlw.GetArticleAmountByID(31) + vs.sicherheitsbestandP3 - w.GetArticleByID(30).Amount + wlw.GetArticleAmountByID(30) + oiw.GetArticleAmountByID(30);

            e6 = e30 + wlw.GetArticleAmountByID(30) + vs.sicherheitsbestandP3 - w.GetArticleByID(6).Amount + wlw.GetArticleAmountByID(6) + oiw.GetArticleAmountByID(6);
            e12 = e30 + wlw.GetArticleAmountByID(30) + vs.sicherheitsbestandP3 - w.GetArticleByID(12).Amount + wlw.GetArticleAmountByID(12) + oiw.GetArticleAmountByID(12);
            e29 = e30 + wlw.GetArticleAmountByID(30) + vs.sicherheitsbestandP3 - w.GetArticleByID(29).Amount + wlw.GetArticleAmountByID(29) + oiw.GetArticleAmountByID(29);

            e9 = e29 + wlw.GetArticleAmountByID(29) + vs.sicherheitsbestandP3 - w.GetArticleByID(9).Amount + wlw.GetArticleAmountByID(9) + oiw.GetArticleAmountByID(9);
            e15 = e29 + wlw.GetArticleAmountByID(29) + vs.sicherheitsbestandP3 - w.GetArticleByID(15).Amount + wlw.GetArticleAmountByID(15) + oiw.GetArticleAmountByID(15);
            e20 = e29 + wlw.GetArticleAmountByID(29) + vs.sicherheitsbestandP3 - w.GetArticleByID(20).Amount + wlw.GetArticleAmountByID(20) + oiw.GetArticleAmountByID(20);

            #endregion

            #region Kaufteile

            k24 = p3 + e31 + e16H + e16D + e16K + 2*e30 + 2*e29 + p1 + e51 + 2*e50 + 2*e49 + p2 + e56 + 2*e55 + 2*e54;


            #endregion

        }

    }
}
