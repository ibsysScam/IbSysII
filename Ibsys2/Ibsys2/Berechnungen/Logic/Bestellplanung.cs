using Ibsys2.Static.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ibsys2.Static.Input.Waitingliststock.Missingpart;


namespace Ibsys2.Berechnungen.Logic
{
    public static class Bestellplanung
    {

        private static List<BPKaufteil> kaufteile = new List<BPKaufteil>();

        public static List<BPBestellung> bestellungen = new List<BPBestellung>();

        public static void createBestellung(BPKaufteil k)
        {
            if (k.reichweiteInTagen < k.lieferzeit)
            {
                bestellungen.Add(new BPBestellung(k.id, k.optimaleBestellmengeEil, true));
            }
            else bestellungen.Add(new BPBestellung(k.id, k.optimaleBestellmengeNormal, false));
        }

        public static void bestellungenBerechnen()
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
            get { return (this.verbrauchProTagP0 + this.verbrauchProTagP1 + this.verbrauchProTagP2 + this.verbrauchProTagP3) / 4; }
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


        public Double optimaleBestellmengeNormalOhneRabatt {
            get { return ((int)(Math.Sqrt((200 * (verbrauchPeriode0 + verbrauchPeriode1 + verbrauchPeriode2 + verbrauchPeriode3) / 4 * 50 * bestellkostenNormal) / (teileWert * 30))) / 10) * 10; }
        }

        public Double optimaleBestellmengeEilOhneRabatt {
            get { return ((int)(Math.Sqrt((200 * (verbrauchPeriode0 + verbrauchPeriode1 + verbrauchPeriode2 + verbrauchPeriode3) / 4 * 50 * bestellkostenEil) / (teileWert * 30))) / 10) * 10; }
        }

        public Double optimaleBestellmengeNormalMitRabatt {
            get { return ((int)(Math.Sqrt((200 * (verbrauchPeriode0 + verbrauchPeriode1 + verbrauchPeriode2 + verbrauchPeriode3) / 4 * 50 * bestellkostenNormal) / (teileWert * 30 * 0.9))) / 10) * 10; }
        }

        public Double optimaleBestellmengeEilMitRabatt {
            get { return ((int)(Math.Sqrt((200 * (verbrauchPeriode0 + verbrauchPeriode1 + verbrauchPeriode2 + verbrauchPeriode3) / 4 * 50 * bestellkostenEil / (teileWert * 30 * 0.9))) / 10) * 10); }
        }

        public int reichweiteInTagen {
            get {
                Warehousestock w = Warehousestock.Class;
                return (w.GetArticleByID(k.id).Amount + k.geplanteBestellzugaengePeriode0 - k.sicherheitsBestand) / k.durchSchnittsverbrauchProTag;
            }
        }


        public BPKaufteil(String bezeichnung, int id, Double diskontmenge, Double lieferzeit, Double lieferzeitAbweichung, Double bestellkostenNormal)
        {

            Warehousestock w = Warehousestock.Class;
            this.teileWert = w.GetArticleByID(id).Stockvalue;
            this.verbrauchPeriode0 = Produktionsplanung.getBedarfByID(id);
            this.verbrauchPeriode1 = ProduktionsplanungPeriode1.getBedarfByID(id);
            this.verbrauchPeriode2 = ProduktionsplanungPeriode2.getBedarfByID(id);
            this.verbrauchPeriode3 = ProduktionsplanungPeriode3.getBedarfByID(id);

            int aktuellePeriode = ValueStore.Instance.aktuellePeriode;
            Waitingliststock wls = Waitingliststock.Class;
            foreach (Waitinglist wli in wls.GetMissingpartByID(id).GetAllWaitinglistItem)
            {
                if (wli.Period == aktuellePeriode) this.geplanteBestellzugaengePeriode0 = wli.Amount;
                else if (wli.Period == aktuellePeriode + 1) this.geplanteBestellzugaengePeriode1 = wli.Amount;
                else if (wli.Period == aktuellePeriode + 2) this.geplanteBestellzugaengePeriode2 = wli.Amount;
                else if (wli.Period == aktuellePeriode + 3) this.geplanteBestellzugaengePeriode3 = wli.Amount;
            }

            this.id = id;
            this.bezeichnung = bezeichnung;
            this.diskontmenge = diskontmenge;
            this.lieferzeit = lieferzeit;
            this.lieferzeitAbweichung = lieferzeitAbweichung;
            this.bestellkostenNormal = bestellkostenNormal;


            this.sicherheitsBestand = ((int)((lieferzeit + (lieferzeitAbweichung * ValueStore.Instance.sicherheitsFaktor)) * durchSchnittsverbrauchProTag / 10) * 10);
            this.meldeBestand = ((int)((lieferzeit * durchSchnittsverbrauchProTag) + sicherheitsBestand) / 10) * 10;        // Rundung auf 10
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
