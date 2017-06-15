using System;
using System.Collections.Generic;
using Ibsys2.Service;
using static Ibsys2.Service.TranslateService;


namespace Ibsys2.Service {
    public static class GermanTranslation {
        private static Dictionary<string, string> _translate = new Dictionary<string, string>();

        public static void AddLanguage() {
            Translate();
            TranslateService.Class.AddTranslation(new Language("de", "Deutsch"), _translate);
        }

        private static void Translate() {
            _translate.Add("HELLO", "Hallo");
            _translate.Add("SETTINGS_SAVED", "Einstellungen gespeichert! Möchten Sie das Programm neustarten? Ohne Neustart kann es zu Problemen bei der Übersetzung kommen!");
            _translate.Add("SETTINGS", "Einstellungen");
            _translate.Add("XML_ERROR", "Das ist keine XML Datei!");
            _translate.Add("ONLY_INT_ERROR", "Bitte benutze nur Ganzzahlen!");
            _translate.Add("SALES_ORDERS", "verbindliche Aufträge");
            _translate.Add("FORECASTS", "Prognosen");
            _translate.Add("CHILDREN_BICYCLE", "Kinderrad");
            _translate.Add("LADY_BICYCLE", "Damenrad");
            _translate.Add("MEN_BICYCLE", "Herrenrad");
            _translate.Add("TOTAL", "Summe");
            _translate.Add("PRIMARY_REQ", "Primärbedarf");
            _translate.Add("MAT_PLAN", "Materialplanung");
            _translate.Add("DELIVERY_RELIABILITY", "Liefertreue");
            _translate.Add("THROUGHPUT_TIME", "Durchlaufzeit");
            _translate.Add("CAPACITY_UTILIZATION", "Auslastung");
            _translate.Add("STORE_VALUE", "Bestände");
            _translate.Add("PRODUCTION_COSTS", "Herstellkosten");
            _translate.Add("OPERATING_PROFIT", "Ergebnis");
            _translate.Add("TARGET_PLANING", "Zielplanung");
            _translate.Add("SUPPLY_CHAIN", "Wertschöpfungskette");
            _translate.Add("SAFETY_STOCK", "Sicherheitsbestand");
            _translate.Add("PLANNED_WAREHOUSE", "Geplanter Lagerbestand am Ende der Planperiode (Sicherheitsbestand)");
            _translate.Add("END_WAREHOUSE_STOCK", "Lagerbestand am Ende der Vorperiode");
            _translate.Add("ORDERS_QUEUE", "Aufträge in der Warteschlange");
            _translate.Add("WORK_IN_PROGRESS", "Aufträge in Bearbeitung");
            _translate.Add("PRODUCTION_ORDERS_FOR_COMMING", "Produktionsaufträge für die kommende Periode");
            _translate.Add("DESCRIPTION", "Bezeichnung");
            _translate.Add("REAR_WHEEL", "Hinterrad");
            _translate.Add("FRONT_WHEEL", "Vorderrad");
            _translate.Add("MUDGUARD_REAR", "Schutzblech hinten");
            _translate.Add("MUDGUARD_FRONT", "Schutzblech vorne");
            _translate.Add("HANDLE_BAR", "Lenker");
            _translate.Add("SEAT", "Sattel");
            _translate.Add("FRAME", "Rahmen");
            _translate.Add("PEDAL", "Pedale");
            _translate.Add("FRONT_WHEEL_COMPLETE", "Vorderrad komplett (cpl)");
            _translate.Add("FRAME_AND_WHEELS", "Rahmen und Räder");
            _translate.Add("BICYCLE_WITHOUT_PEDAL", "Fahrrad ohne Pedale");
            _translate.Add("BICYCLE_COMPLETE", "Fahrrad komplett (cpl)");
            _translate.Add("CAPACITY_REQ_NEW", "Kapazitätsbedarf (neu)");
            _translate.Add("SETUP_TIME_NEW", "Rüstzeit (neu)");
            _translate.Add("CAP_REQ_PREV", "Kap.bed.(Rückstand Vorperiode)");
            _translate.Add("SETUP_TIME_PREV", "Rüstzeit (Rückstand Vorperiode");
            _translate.Add("TOTAL_CAP_REQ", "Gesamt-Kapazitätsbedarf");
            _translate.Add("SHIFTS_OVERTIME", "Schichten und Überstunden");
            _translate.Add("CAPACITY_PLAN", "Kapazitätsplan");
            _translate.Add("WORKPLACE", "Arbeitsplatz");
            _translate.Add("ORDER_QUANTITY", "Auftragsmenge");
            _translate.Add("ITEM_NO", "Nr.");
            _translate.Add("PRODUCTION_PROGRAM", "Produktionsprogramm");
            _translate.Add("DELIVERY_TIME", "Lieferfrist");
            _translate.Add("DEVIATION", "Abweichung");
            _translate.Add("USED_IN", "Verwendung");
            _translate.Add("DISCOUNT_QUANTITY", "Diskontmenge");
            _translate.Add("INITIAL_STOCK", "Anfangsbestand");
            _translate.Add("GROSS_REQ", "Bruttobedarf gemäß Produktionsprogramm");
            _translate.Add("ORDER", "Bestellung");
            _translate.Add("STOCK_AFTER", "Bestand nach geplantem Wareneingang");
            _translate.Add("PURCH_ITEMS", "Kaufteiledisposition");
            _translate.Add("DIRECT_SALES", "Direktverkauf");
            _translate.Add("PURCH_ORDERS", "Einkaufsaufträge");
            _translate.Add("FAST", "Eil");
            _translate.Add("PRODUCTION_ORDERS", "Produktionsaufträge");
            _translate.Add("CAP_REQ", "Produktionskapazitäten");
            _translate.Add("QUANTITY", "Anzahl");
            _translate.Add("SHIFTS", "Schichten");
            _translate.Add("OVERTIME", "Überstunden [Min/Tag]");
            _translate.Add("PURCHASING", "Beschaffung");
            _translate.Add("CHAIN", "Kette");
            _translate.Add("XML_MALFORMED", "XML ist nicht wohlgeformt");
            _translate.Add("NUT_three", "Nut 3/8");            
            _translate.Add("WASHER", "Washer 3/8");       
            _translate.Add("SCREW", "Screw 3/8");
            _translate.Add("TUBE", "Tube 3/8");       
            _translate.Add("PAINT", "Paint"); 
            _translate.Add("RIM", "Rim complete");               
            _translate.Add("SPOKE", "Spoke");              
            _translate.Add("TAPER", "Taper sleeve");               
            _translate.Add("FREE", "Free wheel");                 
            _translate.Add("FORK", "Fork");               
            _translate.Add("AXLE", "Axle");               
            _translate.Add("SHEET", "Sheet");                 
            _translate.Add("NUT_FOUR", "Nut 3/4");                
            _translate.Add("HANDLE_GRIP", "Handle grip");                
            _translate.Add("SADDLE", "Saddle");                
            _translate.Add("BAR", "Bar 1/2");               
            _translate.Add("NUT_QUARTER", "Nut 1/4");                
            _translate.Add("SCREW_QUARTER", "Screw 1/4");               
            _translate.Add("SPROCKET", "Sprocket");                
            _translate.Add("WELDING_WIRES", "Welding Wires");
            _translate.Add("ITEM_VALUE", " Item value [€]");
            _translate.Add("STOCK_QUANTITY_PIECE", "Stock quantity [piece]");           
            _translate.Add("DISCOUNT_QUANTITY_PIECE", "Discount quantity [piece]");          
            _translate.Add("ORDER_COSTS", "Order costs [€]");           
            _translate.Add("PROCURE", "Procure lead-time [Period]");             
            _translate.Add("DEVIATION_PERIOD", "Deviation +/- [Period]");          
            _translate.Add("REAR_WHEEL_GROUP", "Gruppe Hinterrad");             
            _translate.Add("FRONT_WHEEL_GROUP", "Gruppe Vorderrad");              
            _translate.Add("HANDLE_COMPLETE", "Lenker komplett");             
            _translate.Add("SADDLE_COMPLETE", "Sattel komplett");                        
            _translate.Add("WHERE_USED", "Where used");               
            _translate.Add("IN_HOUSE", "In-house manufactured part and component");                
            _translate.Add("USED_IN_C", "Wird im Kinderfahrrad benutzt");                
            _translate.Add("USED_IN_L", "Wird im Damenfahrrad benutzt");               
            _translate.Add("USED_IN_M", "Wird im Männerfahrrad benutzt");      
            _translate.Add("SECURITYFACTOR_EMPTY", "Sicherheitsfaktor leer! ");
            _translate.Add("INPUT_VALUE_ERROR", "Error bei den Eingabedaten.");
            _translate.Add("INPUT_NOT_COMPLETE", "Bitte alle Felder ausfüllen");
            _translate.Add("SUM_TOO_BIG", "Die Summe ist zu groß!");
        }
        
    }
    
}