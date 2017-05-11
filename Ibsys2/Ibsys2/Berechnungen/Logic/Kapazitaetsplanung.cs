using Ibsys2.Static.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Berechnungen.Logic
{
    static class Kapazitaetsplanung
    {

        public static Arbeitsplatz a1 = new Arbeitsplatz(1, new List<Arbeitsplatzauftrag>([
            new Arbeitsplatzauftrag(49, 6, 20),
            new Arbeitsplatzauftrag(54, 6, 20),
            new Arbeitsplatzauftrag(29, 6, 20)
        ]));
        public static Arbeitsplatz a2; 
        public static Arbeitsplatz a3;
        public static Arbeitsplatz a4;
        public static Arbeitsplatz a5;
        public static Arbeitsplatz a6;
        public static Arbeitsplatz a7;
        public static Arbeitsplatz a8;
        public static Arbeitsplatz a9;
        public static Arbeitsplatz a10;
        public static Arbeitsplatz a11;
        public static Arbeitsplatz a12;
        public static Arbeitsplatz a13;
        public static Arbeitsplatz a14;
        public static Arbeitsplatz a15;


        public static void berechnen()
        {
            Warehousestock w = Warehousestock.Class;
            Waitinglistworkstations wlw = Waitinglistworkstations.Class;
            Ordersinwork oiw = Ordersinwork.Class;

            ValueStore vs = ValueStore.Instance;

           
        }

    }
}
