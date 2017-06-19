using Ibsys2.Static.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Berechnungen.Logic
{
    public class Berechnungen
    {

        private static void createOrderList() {
            Orderlist ol = Orderlist.Class;
            Bestellplanung bp = new Bestellplanung();
            bp.bestellungenBerechnen();

            foreach (BPBestellung bestellung in bp.bestellungen){
                ol.AddItem(new OrderlistItem(bestellung.artikelID, Convert.ToInt32(bestellung.menge), bestellung.isEilbestellung ? 4 : 5)); 
            }
        }

        private static void createProductionList() {
            Productionlist pl = Productionlist.Class;
            Produktionsplanung.berechnen();
            for (int i = 1; i < 21; i++) 
            {
                pl.AddItem(new ProductionlistItem(i, Produktionsplanung.getBedarfByID(i)));
            }

            pl.AddItem(new ProductionlistItem(26, Produktionsplanung.getBedarfByID(26)));

			for (int i = 29; i < 32; i++)
			{
				pl.AddItem(new ProductionlistItem(i, Produktionsplanung.getBedarfByID(i)));
			}

			for (int i = 49; i < 52; i++)
			{
				pl.AddItem(new ProductionlistItem(i, Produktionsplanung.getBedarfByID(i)));
			}

			for (int i = 54; i < 57; i++)
			{
				pl.AddItem(new ProductionlistItem(i, Produktionsplanung.getBedarfByID(i)));
			}

        }

        private static void createWorkingtimelist() {
            Workingtimelist wl = Workingtimelist.Class;
            Kapazitaetsplanung.Class.kapazitaetsrueckstandAufNachfolgendeArbeitsplaetzeVerrechnen();
            foreach(Arbeitsplatz a in Kapazitaetsplanung.Class.arbeitsplatzListe){
                wl.AddItem(new WorkingtimelistItem(a.id, a.schichten, a.ueberStundenInMinProTag));    
            }
        }


        public void berechnen(){
            createProductionList();
            createWorkingtimelist();
            createOrderList();
        }


    }
}
