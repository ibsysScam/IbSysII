using Ibsys2.Static.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ibsys2.Static.Input.Waitinglistworkstations.Workplace;

namespace Ibsys2.Berechnungen.Logic
{
    class Arbeitsplatz
    {

        public int id;

        public List<Arbeitsplatzauftrag> fertigungsListe;

        public int kapazitaetsbedarf;
        public double ruestzeit;
        public int kapabeadarfrueckstand;
        public double ruestzeitrueckstand;
        public double gesamtzeitbedarf;
        public int schichten;
        public double ueberstundenInMin;


        public double ueberStundenInMinProTag {
            get { return this.ueberstundenInMin / 5; }
        }

        public Arbeitsplatz(int arbeitsplatzID, List<Arbeitsplatzauftrag> liste)
        {
            this.id = arbeitsplatzID;
            this.fertigungsListe = liste;
            foreach (Arbeitsplatzauftrag apa in this.fertigungsListe)
            {
                this.kapazitaetsbedarf += apa.kapabedarfProTeil;
            }
            foreach (Arbeitsplatzauftrag apa in this.fertigungsListe)
            {
                this.ruestzeit += apa.ruestzeit;
            }
            this.ruestzeit = this.ruestzeit * 1.5;

            Waitinglistworkstations wlw = Waitinglistworkstations.Class;
            this.kapabeadarfrueckstand = wlw.GetWorkplaceByID(arbeitsplatzID).Timeneed;

            //this.ruestzeitrueckstand = 
            foreach (Waitinglist wl in wlw.GetWorkplaceByID(arbeitsplatzID).GetAllWaitinglistItem)
            {
                foreach (Arbeitsplatzauftrag apa in this.fertigungsListe)
                {
                    if (wl.Item == apa.artikelID) this.ruestzeitrueckstand += apa.ruestzeit;
                }
            }
            this.ruestzeitrueckstand = this.ruestzeitrueckstand * 1.5;

            this.gesamtzeitbedarf = this.kapazitaetsbedarf + this.ruestzeit + this.kapabeadarfrueckstand + this.ruestzeitrueckstand;

            double zeitBedarfProPeriode = this.gesamtzeitbedarf;
            if (zeitBedarfProPeriode <= 3600)
            {
                this.schichten = 1;
                if (zeitBedarfProPeriode >= 2400)
                    this.ueberstundenInMin = zeitBedarfProPeriode - 2400;
                else
                    this.ueberstundenInMin = 0;
            }
            else if (zeitBedarfProPeriode <= 6000)
            {
                this.schichten = 2;
                if (zeitBedarfProPeriode >= 4800)
                    this.ueberstundenInMin = zeitBedarfProPeriode - 4800;
                else
                    this.ueberstundenInMin = 0;
            }
            else if (zeitBedarfProPeriode <= 7200)
            {
                this.schichten = 3;
                this.ueberstundenInMin = zeitBedarfProPeriode - 7200;
            }

        }

    }



    class Arbeitsplatzauftrag
    {

        public int artikelID;
        public int fertigungszeit;
        public int ruestzeit;
        public int kapabedarfProTeil;

        public Arbeitsplatzauftrag(int artikelID, int fertigungszeit, int ruestzeit)
        {
            this.artikelID = artikelID;
            this.fertigungszeit = fertigungszeit;
            this.ruestzeit = ruestzeit;
            this.kapabedarfProTeil = Produktionsplanung.getBedarfByID(artikelID) * fertigungszeit;
        }

    }

}
