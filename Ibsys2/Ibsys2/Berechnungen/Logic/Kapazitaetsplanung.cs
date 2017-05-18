﻿using Ibsys2.Static.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Berechnungen.Logic
{
    static class Kapazitaetsplanung
    {

        public static Arbeitsplatz a1 = new Arbeitsplatz(1, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(49, 6, 20),
            new Arbeitsplatzauftrag(54, 6, 20),
            new Arbeitsplatzauftrag(29, 6, 20)
        });
        public static Arbeitsplatz a2 = new Arbeitsplatz(2, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(50, 5, 30),
            new Arbeitsplatzauftrag(55, 5, 30),
            new Arbeitsplatzauftrag(30, 5, 20)
        });
        public static Arbeitsplatz a3 = new Arbeitsplatz(3, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(51, 5, 20),
            new Arbeitsplatzauftrag(56, 6, 20),
            new Arbeitsplatzauftrag(31, 6, 20)
        });
        public static Arbeitsplatz a4 = new Arbeitsplatz(4, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(1, 6, 30),
            new Arbeitsplatzauftrag(2, 7, 20),
            new Arbeitsplatzauftrag(3, 7, 30)
        });
        public static Arbeitsplatz a6 = new Arbeitsplatz(6, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(16, 2, 15),
            new Arbeitsplatzauftrag(18, 3, 15),
            new Arbeitsplatzauftrag(19, 3, 15),
            new Arbeitsplatzauftrag(20, 3, 15)
        });
        public static Arbeitsplatz a7 = new Arbeitsplatz(7, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(10, 2, 20),
            new Arbeitsplatzauftrag(11, 2, 20),
            new Arbeitsplatzauftrag(12, 2, 20),
            new Arbeitsplatzauftrag(13, 2, 20),
            new Arbeitsplatzauftrag(14, 2, 20),
            new Arbeitsplatzauftrag(15, 2, 20),
            new Arbeitsplatzauftrag(18, 2, 20),
            new Arbeitsplatzauftrag(19, 2, 20),
            new Arbeitsplatzauftrag(20, 2, 20),
            new Arbeitsplatzauftrag(26, 2, 30)
        });
        public static Arbeitsplatz a8 = new Arbeitsplatz(8, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(10, 1, 15),
            new Arbeitsplatzauftrag(11, 2, 15),
            new Arbeitsplatzauftrag(12, 2, 15),
            new Arbeitsplatzauftrag(13, 1, 15),
            new Arbeitsplatzauftrag(14, 2, 15),
            new Arbeitsplatzauftrag(15, 2, 15),
            new Arbeitsplatzauftrag(18, 3, 20),
            new Arbeitsplatzauftrag(19, 3, 25),
            new Arbeitsplatzauftrag(20, 3, 20)
        });
        public static Arbeitsplatz a9 = new Arbeitsplatz(9, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(10, 3, 20),
            new Arbeitsplatzauftrag(11, 3, 20),
            new Arbeitsplatzauftrag(12, 3, 20),
            new Arbeitsplatzauftrag(13, 3, 20),
            new Arbeitsplatzauftrag(14, 3, 20),
            new Arbeitsplatzauftrag(15, 3, 20),
            new Arbeitsplatzauftrag(18, 2, 20),
            new Arbeitsplatzauftrag(19, 2, 20),
            new Arbeitsplatzauftrag(20, 2, 20)
        });
        public static Arbeitsplatz a10 = new Arbeitsplatz(10, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(4, 4, 20),
            new Arbeitsplatzauftrag(5, 4, 20),
            new Arbeitsplatzauftrag(6, 4, 20),
            new Arbeitsplatzauftrag(7, 4, 20),
            new Arbeitsplatzauftrag(8, 4, 20),
            new Arbeitsplatzauftrag(9, 4, 20)
        });
        public static Arbeitsplatz a11 = new Arbeitsplatz(11, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(4, 3, 10),
            new Arbeitsplatzauftrag(5, 3, 10),
            new Arbeitsplatzauftrag(6, 3, 20),
            new Arbeitsplatzauftrag(7, 3, 10),
            new Arbeitsplatzauftrag(8, 3, 10),
            new Arbeitsplatzauftrag(9, 3, 20)
        });
        public static Arbeitsplatz a12 = new Arbeitsplatz(12, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(10, 3, 0),
            new Arbeitsplatzauftrag(11, 3, 0),
            new Arbeitsplatzauftrag(12, 3, 0),
            new Arbeitsplatzauftrag(13, 3, 0),
            new Arbeitsplatzauftrag(14, 3, 0),
            new Arbeitsplatzauftrag(15, 3, 0)
        });
        public static Arbeitsplatz a13 = new Arbeitsplatz(13, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(10, 2, 0),
            new Arbeitsplatzauftrag(11, 2, 0),
            new Arbeitsplatzauftrag(12, 2, 0),
            new Arbeitsplatzauftrag(13, 2, 0),
            new Arbeitsplatzauftrag(14, 2, 0),
            new Arbeitsplatzauftrag(15, 2, 0)
        });
        public static Arbeitsplatz a14 = new Arbeitsplatz(14, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(16, 3, 0)
        });
        public static Arbeitsplatz a15 = new Arbeitsplatz(15, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(17, 3, 15),
            new Arbeitsplatzauftrag(26, 3, 15)
        });


        public static Arbeitsplatz getArbeitsplatzByID(int id)
        {
            switch (id) {
                
                case 1: return a1;
                case 2: return a2;
                case 3: return a3;
                case 4: return a4;
                case 6: return a6;
                case 7: return a7;
                case 8: return a8;
                case 9: return a9;
                case 10: return a10;
                case 11: return a11;
                case 12: return a12;
                case 13: return a13;
                case 14: return a14;
                case 15: return a15;
            }
        }

    }
}
