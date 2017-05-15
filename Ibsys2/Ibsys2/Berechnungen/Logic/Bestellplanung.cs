using Ibsys2.Static.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ibsys2.Static.Input.Waitingliststock;
using static Ibsys2.Static.Input.Waitingliststock.Missingpart;


namespace Ibsys2.Berechnungen.Logic
{
    class Bestellplanung
    {
        
       // public List<Arbeitsplatzauftrag> fertigungsListe;



        public Bestellplanung() {
            

        }

    }



    class BPKaufteil {

        public String bezeichnung;
        public int id;
        public int diskontmenge;
        public int lieferzeit;
        public int lieferzeitAbweichung;
		public int bestellkostenNormal;
		public int teileWert;                   //XML
		public int verbrauchPeriode0;                 //PP
		public int verbrauchPeriode1;                 //PP
		public int verbrauchPeriode2;                 //PP
		public int verbrauchPeriode3;                 //PP
        public int sicherheitsBestand;
        public int meldeBestand;
        public int optimaleBestellmenge;
		public int geplanteBestellzugaengePeriode0;   //XML
		public int geplanteBestellzugaengePeriode1;   //XML
		public int geplanteBestellzugaengePeriode2;   //XML
		public int geplanteBestellzugaengePeriode3;   //XML

        public int verbrauchProTagP0 {
            get { return this.verbrauchPeriode0 / 5; } 
        }

		public int verbrauchProTagP1 {
			get { return this.verbrauchPeriode1 / 5; }
		}

		public int verbrauchProTagP2 {
			get { return this.verbrauchPeriode2 / 5; }
		}

		public int verbrauchProTagP3 {
			get { return this.verbrauchPeriode3 / 5; }
		}

        public int lieferzeitGesamt {
            get { return this.lieferzeit + this.lieferzeitAbweichung; }
		}

		public int bestellkostenEil {
            get { return this.bestellkostenNormal * 10; }
		}

        public int durchSchnittsverbrauchProTag {
            get { return (this.verbrauchProTagPeriode0 + this.verbrauchProTagPeriode1 + this.verbrauchProTagPeriode2 + this.verbrauchProTagPeriode3) / 5; }
        }


        public BPKaufteil(String bezeichnung, int id, int diskontmenge, int lieferzeit, int lieferzeitAbweichung, int bestellkostenNormal, int sicherheitsBestand, int meldeBestend, int optimaleBestellmenge) {
            Warehousestock w = Warehousestock.Class;
            this.teileWert = w.GetArticleByID(id).Stockvalue;
            this.verbrauchPeriode0 = Produktionsplanung.getBedarfByID(id);
            this.verbrauchPeriode1 = ProduktionsplanungPeriode1.getBedarfByID(id);
            this.verbrauchPeriode2 = ProduktionsplanungPeriode2.getBedarfByID(id);
            this.verbrauchPeriode3 = ProduktionsplanungPeriode3.getBedarfByID(id);

            int aktuellePeriode = ValueStore.Instance.aktuellePeriode;
            Waitingliststock wls = Warehousestock.Class;
            foreach(Waitinglist wli in wls.GetMissingpartByID(id).GetAllWaitinglistItem) {
                if (wli.Period == aktuellePeriode) this.geplanteBestellzugaengePeriode0 = wli.Amount; 
                else if (wli.Period == aktuellePeriode +1) this.geplanteBestellzugaengePeriode1 = wli.Amount;
                else if (wli.Period == aktuellePeriode +2) this.geplanteBestellzugaengePeriode2 = wli.Amount;
                else if (wli.Period == aktuellePeriode +3) this.geplanteBestellzugaengePeriode3 = wli.Amount;
			}
              
            this.id = id;
            this.bezeichnung = bezeichnung;
            this.diskontmenge = diskontmenge;
            this.lieferzeit = lieferzeit;
            this.lieferzeitAbweichung = lieferzeitAbweichung;
            this.bestellkostenNormal = bestellkostenNormal;
            this.sicherheitsBestand = sicherheitsBestand;
            this.meldeBestand = meldeBestand;
            this.optimaleBestellmenge = optimaleBestellmenge;
        }

    }

}
