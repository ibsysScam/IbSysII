using Ibsys2.Static.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ibsys2.Static.Input.Waitinglistworkstations.Workplace;

namespace Ibsys2.Berechnungen.Logic
{
    public class Arbeitsplatz
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

        public int getFieldsByID(int id)
        {
            switch (id)
            {
                case 0: return this.kapazitaetsbedarf;
                case 1: return Convert.ToInt32(this.ruestzeit);
                case 2: return this.kapabeadarfrueckstand;
                case 3: return Convert.ToInt32(this.ruestzeitrueckstand);
                case 4: return Convert.ToInt32(gesamtzeitbedarf);
                case 5: return this.schichten;
                case 6: return this.ueberStundenInMinProTag;
                default: return -1;
            }
        }


        public int ueberStundenInMinProTag {
            get { return Convert.ToInt32(Math.Ceiling(this.ueberstundenInMin / 50)*10); }
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
             var item = wlw.GetWorkplaceByID(arbeitsplatzID);
            if (item == null)
                this.kapabeadarfrueckstand = 0;
            else
                this.kapabeadarfrueckstand = item.Timeneed;

            //this.ruestzeitrueckstand = 
            var WorkplaceWithID = wlw.GetWorkplaceByID(arbeitsplatzID);
            if (WorkplaceWithID != null && WorkplaceWithID.GetAllWaitinglistItem != null)
                foreach (Waitinglist wl in wlw.GetWorkplaceByID(arbeitsplatzID).GetAllWaitinglistItem)
                {
                    foreach (Arbeitsplatzauftrag apa in this.fertigungsListe)
                    {
                        if (wl.Item == apa.artikelID) this.ruestzeitrueckstand += apa.ruestzeit;
                    }
                }
            if(arbeitsplatzID == 7 || arbeitsplatzID == 8 || arbeitsplatzID == 9 || arbeitsplatzID == 15)
            {
                this.ruestzeitrueckstand = this.ruestzeitrueckstand * 3.0;
            }
            this.ruestzeitrueckstand = this.ruestzeitrueckstand * 1.5;

            this.gesamtzeitbedarf = this.kapazitaetsbedarf + this.ruestzeit + this.kapabeadarfrueckstand + this.ruestzeitrueckstand;

            double zeitBedarfProPeriode = this.gesamtzeitbedarf;
            if (zeitBedarfProPeriode <= 3600)
            {
                this.schichten = 1;
                this.ueberstundenInMin = Math.Ceiling((zeitBedarfProPeriode - 2400) / 10) * 10;
            }
            else if (zeitBedarfProPeriode <= 6000)
            {
                this.schichten = 2;
                this.ueberstundenInMin = Math.Ceiling((zeitBedarfProPeriode - 4800) / 10) * 10;

            }
            else if (zeitBedarfProPeriode <= 7200)
            {
                this.schichten = 3;
                this.ueberstundenInMin = 0;
            }
            else
            {
                this.schichten = 3;
                this.gesamtzeitbedarf = 7200;
                this.ueberstundenInMin = 0;
            }
            if (ueberstundenInMin < 0)
                this.ueberstundenInMin = 0;
        }

    }



    public class Arbeitsplatzauftrag
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
