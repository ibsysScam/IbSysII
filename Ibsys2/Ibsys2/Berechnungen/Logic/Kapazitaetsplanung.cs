﻿using Ibsys2.Static.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ibsys2.Static.Input.Waitinglistworkstations;
using static Ibsys2.Static.Input.Waitinglistworkstations.Workplace;

namespace Ibsys2.Berechnungen.Logic
{
    public class Kapazitaetsplanung
    {

        public Arbeitsplatz a1 = new Arbeitsplatz(1, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(49, 6, 20),
            new Arbeitsplatzauftrag(54, 6, 20),
            new Arbeitsplatzauftrag(29, 6, 20)
        });
        public Arbeitsplatz a2 = new Arbeitsplatz(2, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(50, 5, 30),
            new Arbeitsplatzauftrag(55, 5, 30),
            new Arbeitsplatzauftrag(30, 5, 20)
        });
        public Arbeitsplatz a3 = new Arbeitsplatz(3, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(51, 5, 20),
            new Arbeitsplatzauftrag(56, 6, 20),
            new Arbeitsplatzauftrag(31, 6, 20)
        });
        public Arbeitsplatz a4 = new Arbeitsplatz(4, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(1, 6, 30),
            new Arbeitsplatzauftrag(2, 7, 20),
            new Arbeitsplatzauftrag(3, 7, 30)
        });
        public Arbeitsplatz a6 = new Arbeitsplatz(6, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(16, 2, 15),
            new Arbeitsplatzauftrag(18, 3, 15),
            new Arbeitsplatzauftrag(19, 3, 15),
            new Arbeitsplatzauftrag(20, 3, 15)
        });
        public Arbeitsplatz a7 = new Arbeitsplatz(7, new List<Arbeitsplatzauftrag>() {
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
        public Arbeitsplatz a8 = new Arbeitsplatz(8, new List<Arbeitsplatzauftrag>() {
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
        public Arbeitsplatz a9 = new Arbeitsplatz(9, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(10, 3, 15),
            new Arbeitsplatzauftrag(11, 3, 15),
            new Arbeitsplatzauftrag(12, 3, 15),
            new Arbeitsplatzauftrag(13, 3, 15),
            new Arbeitsplatzauftrag(14, 3, 15),
            new Arbeitsplatzauftrag(15, 3, 15),
            new Arbeitsplatzauftrag(18, 2, 15),
            new Arbeitsplatzauftrag(19, 2, 15),
            new Arbeitsplatzauftrag(20, 2, 15)
        });
        public Arbeitsplatz a10 = new Arbeitsplatz(10, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(4, 4, 20),
            new Arbeitsplatzauftrag(5, 4, 20),
            new Arbeitsplatzauftrag(6, 4, 20),
            new Arbeitsplatzauftrag(7, 4, 20),
            new Arbeitsplatzauftrag(8, 4, 20),
            new Arbeitsplatzauftrag(9, 4, 20)
        });
        public Arbeitsplatz a11 = new Arbeitsplatz(11, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(4, 3, 10),
            new Arbeitsplatzauftrag(5, 3, 10),
            new Arbeitsplatzauftrag(6, 3, 20),
            new Arbeitsplatzauftrag(7, 3, 20),
            new Arbeitsplatzauftrag(8, 3, 20),
            new Arbeitsplatzauftrag(9, 3, 20)
        });
        public Arbeitsplatz a12 = new Arbeitsplatz(12, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(10, 3, 0),
            new Arbeitsplatzauftrag(11, 3, 0),
            new Arbeitsplatzauftrag(12, 3, 0),
            new Arbeitsplatzauftrag(13, 3, 0),
            new Arbeitsplatzauftrag(14, 3, 0),
            new Arbeitsplatzauftrag(15, 3, 0)
        });
        public Arbeitsplatz a13 = new Arbeitsplatz(13, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(10, 2, 0),
            new Arbeitsplatzauftrag(11, 2, 0),
            new Arbeitsplatzauftrag(12, 2, 0),
            new Arbeitsplatzauftrag(13, 2, 0),
            new Arbeitsplatzauftrag(14, 2, 0),
            new Arbeitsplatzauftrag(15, 2, 0)
        });
        public Arbeitsplatz a14 = new Arbeitsplatz(14, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(16, 3, 0)
        });
        public Arbeitsplatz a15 = new Arbeitsplatz(15, new List<Arbeitsplatzauftrag>() {
            new Arbeitsplatzauftrag(17, 3, 15),
            new Arbeitsplatzauftrag(26, 3, 15)
        });

        public List<Arbeitsplatz> arbeitsplatzListe;

        private static Kapazitaetsplanung _class;

        public static Kapazitaetsplanung Class {
            get {
                if (_class == null)
                    new Kapazitaetsplanung();
                return _class;
            }
        }

        public Kapazitaetsplanung()
        {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            arbeitsplatzListe = new List<Arbeitsplatz>() {
            a1,a2,a3,a4,a6,a7,a8,a9,a10,a11,a12,a13,a14,a15
        };
        }

        public Arbeitsplatz getArbeitsplatzByID(int id)
        {
            switch (id)
            {

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
                default: return a1;
            }
        }

        public void kapazitaetsrueckstandAufNachfolgendeArbeitsplaetzeVerrechnen()
        {
            Waitinglistworkstations wlw = Waitinglistworkstations.Class;
            List<Workplace> workplaces = wlw.getAllWorkplaces();
            foreach (Workplace w in workplaces)
            {
                foreach (Waitinglist wl in w.GetAllWaitinglistItem)
                {
                    // E13-15
                    if (wl.Item == 13)
                    {
                        if (w.ID == 13)
                        {
                            a12.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.kapabeadarfrueckstand += wl.Amount * 1;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 12)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 1;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }
                    else if (wl.Item == 14)
                    {
                        if (w.ID == 13)
                        {
                            a12.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 12)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }
                    else if (wl.Item == 15)
                    {
                        if (w.ID == 13)
                        {
                            a12.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 12)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }



                    //E18-20
                    else if (wl.Item == 18)
                    {
                        if (w.ID == 6)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.ruestzeitrueckstand += 20;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }
                    else if (wl.Item == 19)
                    {
                        if (w.ID == 6)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.ruestzeitrueckstand += 25;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 20;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 20;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 20;
                        }
                    }
                    else if (wl.Item == 20)
                    {
                        if (w.ID == 6)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.ruestzeitrueckstand += 20;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }


                    //E7-9
                    else if (wl.Item == 7)
                    {
                        if (w.ID == 10)
                        {
                            a11.kapabeadarfrueckstand += wl.Amount * 3;
                            a11.ruestzeitrueckstand += 20;
                        }

                    }
                    else if (wl.Item == 8)
                    {
                        if (w.ID == 10)
                        {
                            a11.kapabeadarfrueckstand += wl.Amount * 3;
                            a11.ruestzeitrueckstand += 20;
                        }

                    }
                    else if (wl.Item == 9)
                    {
                        if (w.ID == 10)
                        {
                            a11.kapabeadarfrueckstand += wl.Amount * 3;
                            a11.ruestzeitrueckstand += 20;
                        }

                    }


                    //E4-6
                    else if (wl.Item == 4)
                    {
                        if (w.ID == 10)
                        {
                            a11.kapabeadarfrueckstand += wl.Amount * 3;
                            a11.ruestzeitrueckstand += 10;
                        }

                    }
                    else if (wl.Item == 5)
                    {
                        if (w.ID == 10)
                        {
                            a11.kapabeadarfrueckstand += wl.Amount * 3;
                            a11.ruestzeitrueckstand += 10;
                        }

                    }
                    else if (wl.Item == 6)
                    {
                        if (w.ID == 10)
                        {
                            a11.kapabeadarfrueckstand += wl.Amount * 3;
                            a11.ruestzeitrueckstand += 20;
                        }

                    }


                    //E10-12
                    if (wl.Item == 10)
                    {
                        if (w.ID == 13)
                        {
                            a12.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.kapabeadarfrueckstand += wl.Amount * 1;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 12)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 1;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }
                    else if (wl.Item == 11)
                    {
                        if (w.ID == 13)
                        {
                            a12.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 12)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }
                    else if (wl.Item == 12)
                    {
                        if (w.ID == 13)
                        {
                            a12.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 12)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }

                    //E16
                    else if (wl.Item == 16)
                    {
                        if (w.ID == 6)
                        {
                            a14.kapabeadarfrueckstand += wl.Amount * 3;
                        }

                    }


                    //E26
                    else if (wl.Item == 26)
                    {
                        if (w.ID == 7)
                        {
                            a15.kapabeadarfrueckstand += wl.Amount * 3;
                            a15.ruestzeitrueckstand += 15;
                        }

                    }
                }
            }
            var oiw = Waitinglistworkstations.Class;
            List<Workplace> oWorkplaces = oiw.getAllWorkplaces();
            foreach (Workplace w in oWorkplaces)
            {
                foreach (Waitinglist wl in w.GetAllWaitinglistItem)
                {
                    // E13-15
                    if (wl.Item == 13)
                    {
                        if (w.ID == 13)
                        {
                            a12.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.kapabeadarfrueckstand += wl.Amount * 1;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 12)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 1;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }
                    else if (wl.Item == 14)
                    {
                        if (w.ID == 13)
                        {
                            a12.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 12)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }
                    else if (wl.Item == 15)
                    {
                        if (w.ID == 13)
                        {
                            a12.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 12)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }



                    //E18-20
                    else if (wl.Item == 18)
                    {
                        if (w.ID == 6)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.ruestzeitrueckstand += 20;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }
                    else if (wl.Item == 19)
                    {
                        if (w.ID == 6)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.ruestzeitrueckstand += 25;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 20;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 20;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 20;
                        }
                    }
                    else if (wl.Item == 20)
                    {
                        if (w.ID == 6)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.ruestzeitrueckstand += 20;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 2;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }


                    //E7-9
                    else if (wl.Item == 7)
                    {
                        if (w.ID == 10)
                        {
                            a11.kapabeadarfrueckstand += wl.Amount * 3;
                            a11.ruestzeitrueckstand += 20;
                        }

                    }
                    else if (wl.Item == 8)
                    {
                        if (w.ID == 10)
                        {
                            a11.kapabeadarfrueckstand += wl.Amount * 3;
                            a11.ruestzeitrueckstand += 20;
                        }

                    }
                    else if (wl.Item == 9)
                    {
                        if (w.ID == 10)
                        {
                            a11.kapabeadarfrueckstand += wl.Amount * 3;
                            a11.ruestzeitrueckstand += 20;
                        }

                    }


                    //E4-6
                    else if (wl.Item == 4)
                    {
                        if (w.ID == 10)
                        {
                            a11.kapabeadarfrueckstand += wl.Amount * 3;
                            a11.ruestzeitrueckstand += 10;
                        }

                    }
                    else if (wl.Item == 5)
                    {
                        if (w.ID == 10)
                        {
                            a11.kapabeadarfrueckstand += wl.Amount * 3;
                            a11.ruestzeitrueckstand += 10;
                        }

                    }
                    else if (wl.Item == 6)
                    {
                        if (w.ID == 10)
                        {
                            a11.kapabeadarfrueckstand += wl.Amount * 3;
                            a11.ruestzeitrueckstand += 20;
                        }

                    }


                    //E10-12
                    if (wl.Item == 10)
                    {
                        if (w.ID == 13)
                        {
                            a12.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.kapabeadarfrueckstand += wl.Amount * 1;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 12)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 1;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }
                    else if (wl.Item == 11)
                    {
                        if (w.ID == 13)
                        {
                            a12.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 12)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }
                    else if (wl.Item == 12)
                    {
                        if (w.ID == 13)
                        {
                            a12.kapabeadarfrueckstand += wl.Amount * 3;
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 12)
                        {
                            a8.kapabeadarfrueckstand += wl.Amount * 2;
                            a8.ruestzeitrueckstand += 15;
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 8)
                        {
                            a7.kapabeadarfrueckstand += wl.Amount * 2;
                            a7.ruestzeitrueckstand += 20;
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                        else if (w.ID == 7)
                        {
                            a9.kapabeadarfrueckstand += wl.Amount * 3;
                            a9.ruestzeitrueckstand += 15;
                        }
                    }

                    //E16
                    else if (wl.Item == 16)
                    {
                        if (w.ID == 6)
                        {
                            a14.kapabeadarfrueckstand += wl.Amount * 3;
                        }

                    }


                    //E26
                    else if (wl.Item == 26)
                    {
                        if (w.ID == 7)
                        {
                            a15.kapabeadarfrueckstand += wl.Amount * 3;
                            a15.ruestzeitrueckstand += 15;
                        }

                    }
                }
            }

        }

    }
}
