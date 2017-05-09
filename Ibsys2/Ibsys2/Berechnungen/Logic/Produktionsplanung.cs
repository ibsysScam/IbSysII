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
        public static int p49;
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

        public static void berechnen()
        {
            Warehousestock w = Warehousestock.Class;
            Waitinglistworkstations wlw = Waitinglistworkstations.Class;
            Ordersinwork oiw = Ordersinwork.Class;

            ValueStore vs = ValueStore.Instance;

            p1 = vs.vertriebswunschP1 + vs.sicherheitsbestandP1 - w.GetArticleByID(1).Amount - wlw.GetArticleAmountByID(1) - oiw.GetArticleAmountByID(1);

            e26K = p1 + wlw.GetArticleAmountByID(1) + vs.sicherheitsbestandP1 + w.GetArticleByID(26).Amount / 3 + wlw.GetArticleAmountByID(26) / 3 + oiw.GetArticleAmountByID(26) / 3;
            e51 = p1 + wlw.GetArticleAmountByID(1) + vs.sicherheitsbestandP1 + w.GetArticleByID(51).Amount + wlw.GetArticleAmountByID(51) + oiw.GetArticleAmountByID(51);

            e16K = e51 + wlw.GetArticleAmountByID(51) + vs.sicherheitsbestandP1 - w.GetArticleByID(16).Amount/3 + wlw.GetArticleAmountByID(16)/3 + oiw.GetArticleAmountByID(16)/3;
            

        }

    }
}
