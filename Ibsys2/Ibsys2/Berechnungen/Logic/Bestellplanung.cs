﻿using Ibsys2.Static.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ibsys2.Static.Input.Waitingliststock.Missingpart;


namespace Ibsys2.Berechnungen.Logic
{
    public class Bestellplanung
    {

        public List<BPKaufteil> kaufteile = new List<BPKaufteil>() {

            new BPKaufteil(21, "Kette",         300,    9,    2,      50),
            new BPKaufteil(22, "Kette",         300,    9,    2,      50),
            new BPKaufteil(23, "Kette",         300,    6,    1,      50),
            new BPKaufteil(24, "Mutter 3/8",    6100,   16,   2,      100),
            new BPKaufteil(25, "Scheibe 3/8",   3600,   5,    1,      50),
            new BPKaufteil(27, "Schraube 3/8",  1800,   5,    1,      75),
            new BPKaufteil(28, "Rohr 3/4",      4500,   9,    2,      50),
            new BPKaufteil(32, "Farbe",         2700,   11,   3,      50),
            new BPKaufteil(33, "Felge cpl.",    900,    10,   3,      75),
            new BPKaufteil(34, "Speiche",       22000,  8,    2,      50),
            new BPKaufteil(35, "Konus",         3600,   11,   2,      75),
            new BPKaufteil(36, "Freilauf",      900,    6,    1,      100),
            new BPKaufteil(37, "Gabel",         900,    8,    2,      50),
            new BPKaufteil(38, "Welle",         300,    9,    2,      50),
            new BPKaufteil(39, "Blech",         1800,   8,    2,      75),
            new BPKaufteil(40, "Lenker",        900,    9,    1,      50),
            new BPKaufteil(41, "Mutter 3/4",    900,    5,    1,      50),
            new BPKaufteil(42, "Griff",         1800,   6,    2,      50),
            new BPKaufteil(43, "Sattel",        2700,   10,   3,      75),
            new BPKaufteil(44, "Stange 1/2",    900,    5,    1,      50),
            new BPKaufteil(45, "Mutter 1/4",    900,    9,    2,      50),
            new BPKaufteil(46, "Schraube 1/4",  900,    5,    2,      50),
            new BPKaufteil(47, "Zahnkranz",     900,    8,    1,      50),
            new BPKaufteil(48, "Pedal",         1800,   5,    1,      75),
            new BPKaufteil(52, "Felge cpl.",    600,    8,    2,      50),
            new BPKaufteil(53, "Speiche",       22000,  8,    1,      50),
            new BPKaufteil(57, "Felge cpl.",    600,    9,    2,      50),
            new BPKaufteil(58, "Speiche",       22000,  8,    3,      50),
            new BPKaufteil(59, "Schweißdraht",  1800,   4,    1,      50)

        };


        public List<BPBestellung> bestellungen = new List<BPBestellung>();
        Warehousestock w = Warehousestock.Class;

        public void createBestellung(BPKaufteil k)
        {
            if (k.reichweiteInTagen < k.lieferzeit && Warehousestock.Class.Totalstockvalue < 250000)
            {
                bestellungen.Add(new BPBestellung(k.id, k.optimaleBestellmengeEil, true));
            }
            else if (k.reichweiteInTagen >= k.lieferzeit && Warehousestock.Class.Totalstockvalue < 250000)
            {
                bestellungen.Add(new BPBestellung(k.id, k.optimaleBestellmengeNormal, false));
            }
            else if (k.reichweiteInTagen < k.lieferzeit && Warehousestock.Class.Totalstockvalue >= 250000)
            {
                bestellungen.Add(new BPBestellung(k.id, k.optimaleBestellmengeEilLB, true));
            }
            else
            {
                bestellungen.Add(new BPBestellung(k.id, k.optimaleBestellmengeNormalLB, false));
            }
        }

        public void bestellungenBerechnen()
        {

            foreach (BPKaufteil k in kaufteile)
            {
                //NORMAL, EIL, ODER KEINE BESTELLUNG?
                if (k.lieferzeit <= 5)
                {
                    if (k.voraussichtlicherEndBestandPeriode0 <= k.meldeBestand)
                    {
                        createBestellung(k);
                    }
                }
                else
                {
                    if (k.lieferzeit <= 10)
                    {
                        if (k.voraussichtlicherEndBestandPeriode1 <= k.meldeBestand)
                        {
                            createBestellung(k);
                        }
                    }
                    else
                    {
                        if (k.lieferzeit <= 15)
                        {
                            if (k.voraussichtlicherEndBestandPeriode2 <= k.meldeBestand)
                            {
                                createBestellung(k);
                            }
                        }
                        else
                        {
                            if (k.lieferzeit <= 20)
                            {
                                if (k.voraussichtlicherEndBestandPeriode3 <= k.meldeBestand)
                                {
                                    createBestellung(k);
                                }
                            }
                        }
                    }
                }

            }
        }

    }



    public class BPKaufteil
    {

        public String bezeichnung;
        public int id;
        public Double diskontmenge;
        public Double lieferzeit;
        public Double lieferzeitAbweichung;
        public Double bestellkostenNormal;
        public double teileWert;                   //XML
        public int verbrauchPeriode0;                 //PP
        public int verbrauchPeriode1;                 //PP
        public int verbrauchPeriode2;                 //PP
        public int verbrauchPeriode3;                 //PP
        public int sicherheitsBestand;
        public int meldeBestand;

        public int geplanteBestellzugaengePeriode0;   //XML
        public int geplanteBestellzugaengePeriode1;   //XML
        public int geplanteBestellzugaengePeriode2;   //XML
        public int geplanteBestellzugaengePeriode3;   //XML

        public Double verbrauchProTagP0 {
            get { return this.verbrauchPeriode0 / 5; }
        }

        public Double verbrauchProTagP1 {
            get { return this.verbrauchPeriode1 / 5; }
        }

        public Double verbrauchProTagP2 {
            get { return this.verbrauchPeriode2 / 5; }
        }

        public Double verbrauchProTagP3 {
            get { return this.verbrauchPeriode3 / 5; }
        }

        public Double lieferzeitGesamt {
            get { return this.lieferzeit + this.lieferzeitAbweichung; }
        }

        public Double bestellkostenEil {
            get { return this.bestellkostenNormal * 10; }
        }

        public Double durchSchnittsverbrauchProTag {
            get { return Math.Ceiling((this.verbrauchProTagP0 + this.verbrauchProTagP1 + this.verbrauchProTagP2 + this.verbrauchProTagP3) / 4); }
        }

        public Double voraussichtlicherEndBestandPeriode0 {
            get {
                Warehousestock w = Warehousestock.Class;
                return w.GetArticleByID(this.id).Amount + geplanteBestellzugaengePeriode0 - verbrauchPeriode0;
            }
        }

        public Double voraussichtlicherEndBestandPeriode1 {
            get {
                return voraussichtlicherEndBestandPeriode0 + geplanteBestellzugaengePeriode1 - verbrauchPeriode1;
            }
        }

        public Double voraussichtlicherEndBestandPeriode2 {
            get {
                return voraussichtlicherEndBestandPeriode1 + geplanteBestellzugaengePeriode2 - verbrauchPeriode2;
            }
        }

        public Double voraussichtlicherEndBestandPeriode3 {
            get {
                return voraussichtlicherEndBestandPeriode2 + geplanteBestellzugaengePeriode3 - verbrauchPeriode3;
            }
        }

        public Double optimaleBestellmengeNormal {
            get {
                if (optimaleBestellmengeNormalMitRabatt >= diskontmenge)
                {
                    return optimaleBestellmengeNormalMitRabatt;
                }
                else return optimaleBestellmengeNormalOhneRabatt;
            }
        }

        public Double optimaleBestellmengeEil {
            get {
                if (optimaleBestellmengeEilMitRabatt >= diskontmenge)
                {
                    return optimaleBestellmengeEilMitRabatt;
                }
                else return optimaleBestellmengeEilOhneRabatt;

            }
        }

        public Double optimaleBestellmengeNormalLB
        {
            get
            {
                if (optimaleBestellmengeNormalMitRabattLB >= diskontmenge)
                {
                    return optimaleBestellmengeNormalMitRabattLB;
                }
                else return optimaleBestellmengeNormalOhneRabattLB;
            }
        }

        public Double optimaleBestellmengeEilLB
        {
            get
            {
                if (optimaleBestellmengeEilMitRabattLB >= diskontmenge)
                {
                    return optimaleBestellmengeEilMitRabattLB;
                }
                else return optimaleBestellmengeEilOhneRabattLB;

            }
        }


        public Double optimaleBestellmengeNormalOhneRabatt {
            get { return ((int) Math.Ceiling((Math.Sqrt((200 * (verbrauchPeriode0 + verbrauchPeriode1 + verbrauchPeriode2 + verbrauchPeriode3) / 4 * 50 * bestellkostenNormal) / (teileWert * 0.6 * 50))) / 10) * 10); }
        }

        public Double optimaleBestellmengeEilOhneRabatt {
            get { return ((int) Math.Ceiling((Math.Sqrt((200 * (verbrauchPeriode0 + verbrauchPeriode1 + verbrauchPeriode2 + verbrauchPeriode3) / 4 * 50 * bestellkostenEil) / (teileWert * 0.6 * 50))) / 10) * 10); }
        }

        public Double optimaleBestellmengeNormalMitRabatt {
            get { return ((int) Math.Ceiling((Math.Sqrt((200 * (verbrauchPeriode0 + verbrauchPeriode1 + verbrauchPeriode2 + verbrauchPeriode3) / 4 * 50 * bestellkostenNormal) / (teileWert * 0.9 * 0.6 * 50))) / 10) * 10); }
        }

        public Double optimaleBestellmengeEilMitRabatt {
            get { return ((int) Math.Ceiling((Math.Sqrt((200 * (verbrauchPeriode0 + verbrauchPeriode1 + verbrauchPeriode2 + verbrauchPeriode3) / 4 * 50 * bestellkostenEil) / (teileWert * 0.9 * 2.6 * 50))) / 10) * 10); }
        }

        public Double optimaleBestellmengeNormalOhneRabattLB
        {
            get { return ((int)Math.Ceiling((Math.Sqrt((200 * (verbrauchPeriode0 + verbrauchPeriode1 + verbrauchPeriode2 + verbrauchPeriode3) / 4 * 50 * bestellkostenNormal) / (teileWert * 2.6 * 50))) / 10) * 10); }
        }

        public Double optimaleBestellmengeEilOhneRabattLB
        {
            get { return ((int)Math.Ceiling((Math.Sqrt((200 * (verbrauchPeriode0 + verbrauchPeriode1 + verbrauchPeriode2 + verbrauchPeriode3) / 4 * 50 * bestellkostenEil) / (teileWert * 2.6 * 50))) / 10) * 10); }
        }

        public Double optimaleBestellmengeNormalMitRabattLB
        {
            get { return ((int)Math.Ceiling((Math.Sqrt((200 * (verbrauchPeriode0 + verbrauchPeriode1 + verbrauchPeriode2 + verbrauchPeriode3) / 4 * 50 * bestellkostenNormal) / (teileWert * 0.9 * 2.6 * 50))) / 10) * 10); }
        }

        public Double optimaleBestellmengeEilMitRabattLB
        {
            get { return ((int)Math.Ceiling((Math.Sqrt((200 * (verbrauchPeriode0 + verbrauchPeriode1 + verbrauchPeriode2 + verbrauchPeriode3) / 4 * 50 * bestellkostenEil) / (teileWert * 0.9 * 0.6 * 50))) / 10) * 10); }
        }



        public double reichweiteInTagen {
            get {
                Warehousestock w = Warehousestock.Class;
                return (Convert.ToDouble(w.GetArticleByID(this.id).Amount) + this.geplanteBestellzugaengePeriode0 - this.sicherheitsBestand) / this.durchSchnittsverbrauchProTag;
            }
        }



        public BPKaufteil(int id, String bezeichnung, Double diskontmenge, Double lieferzeit, Double lieferzeitAbweichung, Double bestellkostenNormal)
        {
            this.id = id;
            this.bezeichnung = bezeichnung;
            this.diskontmenge = diskontmenge;
            this.lieferzeit = lieferzeit;
            this.lieferzeitAbweichung = lieferzeitAbweichung;
            this.bestellkostenNormal = bestellkostenNormal;

            Warehousestock w = Warehousestock.Class;
            this.teileWert = w.GetArticleByID(id).Price;
            this.verbrauchPeriode0 = Produktionsplanung.getBedarfByID(id);
            this.verbrauchPeriode1 = ProduktionsplanungPeriode1.getBedarfByID(id);
            this.verbrauchPeriode2 = ProduktionsplanungPeriode2.getBedarfByID(id);
            this.verbrauchPeriode3 = ProduktionsplanungPeriode3.getBedarfByID(id);

            int aktuellePeriode = Static.Static.lastperiod + 1;
            /*Waitingliststock wls = Waitingliststock.Class;
            var founditem = wls.GetMissingpartByID(id);*/

            Futureinwardstockmovement fism = Futureinwardstockmovement.Class;
            var founditem = fism.GetOrdersByArticle(id);
            if (founditem != null)
            {
                foreach (var wli in founditem)
                {
                    int lieferperiode = (int)Math.Floor(wli.Orderperiod + (this.lieferzeitGesamt / 5));
                    if (lieferperiode == aktuellePeriode)
                        this.geplanteBestellzugaengePeriode0 += wli.Amount;
                    else if (lieferperiode == aktuellePeriode + 1)
                        this.geplanteBestellzugaengePeriode1 += wli.Amount;
                    else if (lieferperiode == aktuellePeriode + 2)
                        this.geplanteBestellzugaengePeriode2 += wli.Amount;
                    else if (lieferperiode == aktuellePeriode + 3)
                        this.geplanteBestellzugaengePeriode3 += wli.Amount;
                    //if (wli.Orderperiod == aktuellePeriode) this.geplanteBestellzugaengePeriode0 += wli.Amount;
                    //else if (wli.Orderperiod == aktuellePeriode + 1) this.geplanteBestellzugaengePeriode1 += wli.Amount;
                    //else if (wli.Orderperiod == aktuellePeriode + 2) this.geplanteBestellzugaengePeriode2 += wli.Amount;
                    //else if (wli.Orderperiod == aktuellePeriode + 3) this.geplanteBestellzugaengePeriode3 += wli.Amount;
                }
            }

            this.sicherheitsBestand = (int)(((lieferzeitAbweichung * ValueStore.Instance.sicherheitsFaktor) * durchSchnittsverbrauchProTag));
            //this.sicherheitsBestand = ((int)(this.sicherheitsBestand / 10)) * 10;
            this.sicherheitsBestand = this.sicherheitsBestand + ((10 - (this.sicherheitsBestand % 10)) % 10);
            this.meldeBestand = ((int)((lieferzeit * durchSchnittsverbrauchProTag) + sicherheitsBestand));
            this.meldeBestand = this.meldeBestand + ((10 - (this.meldeBestand % 10)) % 10);
        }
    }




    public class BPBestellung
    {

        public Boolean isEilbestellung;
        public double menge;
        public int artikelID;

        public BPBestellung(int artikelID, double menge, Boolean isEil)
        {
            this.isEilbestellung = isEil;
            this.menge = menge;
            this.artikelID = artikelID;
        }
    }

}
