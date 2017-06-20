using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Ibsys2.Pages;
using Ibsys2.Service;
using Ibsys2.Pages.Wiki;
using Ibsys2.Static.Input;
using Ibsys2.Static.Output;
using System.Text.RegularExpressions;
using UIFeautures;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.WindowsAPICodePack.Shell;
using Ibsys2.Berechnungen.Logic;
using System.Diagnostics;
using Ibsys2.Pages.About;


namespace Ibsys2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {


        private static MainWindow _class;
        UIFeatures Ui = new UIFeatures();
        

        public static MainWindow Class {
            get {
                if (_class == null)
                    new MainWindow();
                return _class;
            }
        }
        string exportpath = "";
        bool found = false;
        public MainWindow()
        {

            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            SettingsService.Class.CreateFolder();
            SettingsService.Class.LoadSettings();

            InitializeComponent();
            LoadTranslations();

            
            if (found == false)
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                foreach (string xmlFilePath in Directory.GetFiles(folder, "resultServlet.xml"))
                {

                    Pathtextbox.Text = xmlFilePath;
                    exportpath = xmlFilePath;
                    checkMalformedXML();
                    found = true;

                    break;
                }

            }

            if (found == false)
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                foreach (string xmlFilePath in Directory.GetFiles(folder, "resultServlet.xml"))
                {

                    Pathtextbox.Text = xmlFilePath;
                    checkMalformedXML();
                    exportpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                foreach (string xmlFilePath in Directory.GetFiles(folder, "resultServlet.xml"))
                {

                    Pathtextbox.Text = xmlFilePath;
                    checkMalformedXML();
                    exportpath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                foreach (string xmlFilePath in Directory.GetFiles(folder, "resultServlet.xml"))
                {

                    Pathtextbox.Text = xmlFilePath;
                    checkMalformedXML();
                    exportpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    found = true;
                    break;
                }
            }


            if (found == false)
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                foreach (string xmlFilePath in Directory.GetFiles(folder, "resultServlet.xml"))
                {

                    Pathtextbox.Text = xmlFilePath;
                    checkMalformedXML();
                    exportpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                string folder = KnownFolders.Downloads.Path;
                foreach (string xmlFilePath in Directory.GetFiles(folder, "resultServlet.xml"))
                {

                    Pathtextbox.Text = xmlFilePath;
                    checkMalformedXML();
                    exportpath = KnownFolders.Downloads.Path;
                    found = true;
                    break;
                }
            }


            MainpageNextButton.Content = TranslateService.Class.GetTranslation("NEXT");
            clear.Content = TranslateService.Class.GetTranslation("CLEAR");
            choosefile.Content = TranslateService.Class.GetTranslation("CHOOSEFILE");
            calculatebutton.Content = TranslateService.Class.GetTranslation("COUNT");
            Programm.Header = TranslateService.Class.GetTranslation("PROGRAM");
            Helpmenuitem.Header = TranslateService.Class.GetTranslation("HELP");
            Closemenuitem.Header = TranslateService.Class.GetTranslation("CLOSE");
            Settingsmenuheader.Header = TranslateService.Class.GetTranslation("SETTINGS");
            Aboutmenuheader.Header = TranslateService.Class.GetTranslation("ABOUT");
            Maintab.Header = TranslateService.Class.GetTranslation("IMPORT");
            Prognosentab.Header = TranslateService.Class.GetTranslation("DISTRIBUTION");
            VertriebPeriode.Content = TranslateService.Class.GetTranslation("PERIODE");
            VertriebSumme.Content = TranslateService.Class.GetTranslation("TOTAL");
            VertriebKind.Content = TranslateService.Class.GetTranslation("CHILDREN_BICYCLE");
            VertriebDame.Content = TranslateService.Class.GetTranslation("LADY_BICYCLE");
            VertriebHerren.Content = TranslateService.Class.GetTranslation("MEN_BICYCLE");
            VertriebPrognose.Content = TranslateService.Class.GetTranslation("FORECASTS");
            PrognosenNextButton.Content = TranslateService.Class.GetTranslation("NEXT");
            Vertriebswunsch.Content = TranslateService.Class.GetTranslation("SALES_ORDERS");
            DirektPeriode.Content = TranslateService.Class.GetTranslation("PERIODE");
            DirektSumme.Content = TranslateService.Class.GetTranslation("TOTAL");
            DirektKind.Content = TranslateService.Class.GetTranslation("CHILDREN_BICYCLE");
            DirektDame.Content = TranslateService.Class.GetTranslation("LADY_BICYCLE");
            DirektHerren.Content = TranslateService.Class.GetTranslation("MEN_BICYCLE");
            directnextbutton.Content = TranslateService.Class.GetTranslation("NEXT");
            contractpenalty.Content = TranslateService.Class.GetTranslation("CONTRACTPENALTY");
            retailprice.Content = TranslateService.Class.GetTranslation("RETAILPRICE");
            sicherheitsbestandtab.Header = TranslateService.Class.GetTranslation("SAFETY_STOCK");
            SicherPeriode.Content = TranslateService.Class.GetTranslation("PERIODE");
            SicherSumme.Content = TranslateService.Class.GetTranslation("TOTAL");
            SicherKind.Content = TranslateService.Class.GetTranslation("CHILDREN_BICYCLE");
            SicherDame.Content = TranslateService.Class.GetTranslation("LADY_BICYCLE");
            SicherHerren.Content = TranslateService.Class.GetTranslation("MEN_BICYCLE");

            Direktverkauftab.Header = TranslateService.Class.GetTranslation("DIRECT_SALES");

            kinderradtab.Header = TranslateService.Class.GetTranslation("CHILD");
            damenerradtab.Header = TranslateService.Class.GetTranslation("WOMAN");
            herrenerradtab.Header = TranslateService.Class.GetTranslation("MAN");
            Produktionsplanungtab.Header = TranslateService.Class.GetTranslation("PRODUCTIONPLAN");
            ProduktVertrieb.Content = TranslateService.Class.GetTranslation("SALES_ORDERS1");
            ProduktSicher.Content = TranslateService.Class.GetTranslation("SAFETY_STOCK1");
            ProduktLager.Content = TranslateService.Class.GetTranslation("END_WAREHOUSE_STOCK1");
            ProduktAuftrag.Content = TranslateService.Class.GetTranslation("ORDERS_QUEUE1");
            ProduktWarte.Content = TranslateService.Class.GetTranslation("PREORDER1");
            ProduktBearb.Content = TranslateService.Class.GetTranslation("WORK_IN_PROGRESS1");
            ProduktProdukt.Content = TranslateService.Class.GetTranslation("PRODUCTION_ORDERS_FOR_COMMING1");

            ProduktVertrieb1.Content = TranslateService.Class.GetTranslation("SALES_ORDERS1");
            ProduktSicher1.Content = TranslateService.Class.GetTranslation("SAFETY_STOCK1");
            ProduktLager1.Content = TranslateService.Class.GetTranslation("END_WAREHOUSE_STOCK1");
            ProduktAuftrag1.Content = TranslateService.Class.GetTranslation("ORDERS_QUEUE1");
            ProduktWarte1.Content = TranslateService.Class.GetTranslation("PREORDER1");
            ProduktBearb1.Content = TranslateService.Class.GetTranslation("WORK_IN_PROGRESS1");
            ProduktProdukt1.Content = TranslateService.Class.GetTranslation("PRODUCTION_ORDERS_FOR_COMMING1");

            ProduktVertrieb2.Content = TranslateService.Class.GetTranslation("SALES_ORDERS1");
            ProduktSicher2.Content = TranslateService.Class.GetTranslation("SAFETY_STOCK1");
            ProduktLager2.Content = TranslateService.Class.GetTranslation("END_WAREHOUSE_STOCK1");
            ProduktAuftrag2.Content = TranslateService.Class.GetTranslation("ORDERS_QUEUE1");
            ProduktWarte2.Content = TranslateService.Class.GetTranslation("PREORDER1");
            ProduktBearb2.Content = TranslateService.Class.GetTranslation("WORK_IN_PROGRESS1");
            ProduktProdukt2.Content = TranslateService.Class.GetTranslation("PRODUCTION_ORDERS_FOR_COMMING1");

            WORK1.Header = TranslateService.Class.GetTranslation("WORK1");
            WORK2.Header = TranslateService.Class.GetTranslation("WORK2");
            WORK3.Header = TranslateService.Class.GetTranslation("WORK3");
            WORK4.Header = TranslateService.Class.GetTranslation("WORK4");
            WORK6.Header = TranslateService.Class.GetTranslation("WORK6");
            WORK7.Header = TranslateService.Class.GetTranslation("WORK7");
            WORK8.Header = TranslateService.Class.GetTranslation("WORK8");
            WORK9.Header = TranslateService.Class.GetTranslation("WORK9");
            WORK10.Header = TranslateService.Class.GetTranslation("WORK10");
            WORK11.Header = TranslateService.Class.GetTranslation("WORK11");
            WORK12.Header = TranslateService.Class.GetTranslation("WORK12");
            WORK13.Header = TranslateService.Class.GetTranslation("WORK13");
            WORK14.Header = TranslateService.Class.GetTranslation("WORK14");
            WORK15.Header = TranslateService.Class.GetTranslation("WORK15");

            Work1Box.Header = TranslateService.Class.GetTranslation("WORK1");
            Work2Box.Header = TranslateService.Class.GetTranslation("WORK2");
            Work3Box.Header = TranslateService.Class.GetTranslation("WORK3");
            Work4Box.Header = TranslateService.Class.GetTranslation("WORK4");
            Work6Box.Header = TranslateService.Class.GetTranslation("WORK6");
            Work7Box.Header = TranslateService.Class.GetTranslation("WORK7");
            Work8Box.Header = TranslateService.Class.GetTranslation("WORK8");
            Work9Box.Header = TranslateService.Class.GetTranslation("WORK9");
            Work10Box.Header = TranslateService.Class.GetTranslation("WORK10");
            Work11Box.Header = TranslateService.Class.GetTranslation("WORK11");
            Work12Box.Header = TranslateService.Class.GetTranslation("WORK12");
            Work13Box.Header = TranslateService.Class.GetTranslation("WORK13");
            Work14Box.Header = TranslateService.Class.GetTranslation("WORK14");
            Work15Box.Header = TranslateService.Class.GetTranslation("WORK15");

            Plan1Box.Header = TranslateService.Class.GetTranslation("PLAN1");
            Plan2Box.Header = TranslateService.Class.GetTranslation("PLAN2");
            Plan3Box.Header = TranslateService.Class.GetTranslation("PLAN3");
            Plan4Box.Header = TranslateService.Class.GetTranslation("PLAN4");
            Plan6Box.Header = TranslateService.Class.GetTranslation("PLAN6");
            Plan7Box.Header = TranslateService.Class.GetTranslation("PLAN7");
            Plan8Box.Header = TranslateService.Class.GetTranslation("PLAN8");
            Plan9Box.Header = TranslateService.Class.GetTranslation("PLAN9");
            Plan10Box.Header = TranslateService.Class.GetTranslation("PLAN10");
            Plan11Box.Header = TranslateService.Class.GetTranslation("PLAN11");
            Plan12Box.Header = TranslateService.Class.GetTranslation("PLAN12");
            Plan13Box.Header = TranslateService.Class.GetTranslation("PLAN13");
            Plan14Box.Header = TranslateService.Class.GetTranslation("PLAN14");
            Plan15Box.Header = TranslateService.Class.GetTranslation("PLAN15");

            Einkauftab.Header = TranslateService.Class.GetTranslation("PURCHASE");
            Bestell.Header = TranslateService.Class.GetTranslation("ORDERS_OVERVIEW");
            Stammdaten.Header = TranslateService.Class.GetTranslation("DATA");
            securityfactor.Content = TranslateService.Class.GetTranslation("SECURITY_FACTOR");
            Lagerbestand.Header = TranslateService.Class.GetTranslation("WAREHOUSE");

            Priorisierungtab.Header = TranslateService.Class.GetTranslation("PRIO");
            down.Content = TranslateService.Class.GetTranslation("DOWN");
            up.Content = TranslateService.Class.GetTranslation("UP");
            Kapaplanungtab.Header = TranslateService.Class.GetTranslation("CAPACITY_PLAN");

            Plan1Box_Bezeichnung.Header = TranslateService.Class.GetTranslation("DESCRIPTION");
            Plan1Box_Fahrradtyp.Header = TranslateService.Class.GetTranslation("BIKETYPE");
            Plan1Box_Sachnr.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Plan1Box_Menge.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Plan1Box_Einzelaufwand.Header = TranslateService.Class.GetTranslation("INDIVIDUAL_EFFORT");
            Plan1Box_Gesamtaufwand.Header = TranslateService.Class.GetTranslation("TOTAL");
            Plan1Box_Kapaplanwork.Header = TranslateService.Class.GetTranslation("KAPA");
            Plan1Box_Berechnungwork.Header = TranslateService.Class.GetTranslation("TOTAL");

            Plan2Box_Bezeichnung.Header = TranslateService.Class.GetTranslation("DESCRIPTION");
            Plan2Box_Fahrradtyp.Header = TranslateService.Class.GetTranslation("BIKETYPE");
            Plan2Box_Sachnr.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Plan2Box_Menge.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Plan2Box_Einzelaufwand.Header = TranslateService.Class.GetTranslation("INDIVIDUAL_EFFORT");
            Plan2Box_Gesamtaufwand.Header = TranslateService.Class.GetTranslation("TOTAL");
            Plan2Box_Kapaplanwork.Header = TranslateService.Class.GetTranslation("KAPA");
            Plan2Box_Berechnungwork.Header = TranslateService.Class.GetTranslation("TOTAL");

            Plan3Box_Bezeichnung.Header = TranslateService.Class.GetTranslation("DESCRIPTION");
            Plan3Box_Fahrradtyp.Header = TranslateService.Class.GetTranslation("BIKETYPE");
            Plan3Box_Sachnr.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Plan3Box_Menge.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Plan3Box_Einzelaufwand.Header = TranslateService.Class.GetTranslation("INDIVIDUAL_EFFORT");
            Plan3Box_Gesamtaufwand.Header = TranslateService.Class.GetTranslation("TOTAL");
            Plan3Box_Kapaplanwork.Header = TranslateService.Class.GetTranslation("KAPA");
            Plan3Box_Berechnungwork.Header = TranslateService.Class.GetTranslation("TOTAL");

            Plan4Box_Bezeichnung.Header = TranslateService.Class.GetTranslation("DESCRIPTION");
            Plan4Box_Fahrradtyp.Header = TranslateService.Class.GetTranslation("BIKETYPE");
            Plan4Box_Sachnr.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Plan4Box_Menge.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Plan4Box_Einzelaufwand.Header = TranslateService.Class.GetTranslation("INDIVIDUAL_EFFORT");
            Plan4Box_Gesamtaufwand.Header = TranslateService.Class.GetTranslation("TOTAL");
            Plan4Box_Kapaplanwork.Header = TranslateService.Class.GetTranslation("KAPA");
            Plan4Box_Berechnungwork.Header = TranslateService.Class.GetTranslation("TOTAL");

            Plan6Box_Bezeichnung.Header = TranslateService.Class.GetTranslation("DESCRIPTION");
            Plan6Box_Fahrradtyp.Header = TranslateService.Class.GetTranslation("BIKETYPE");
            Plan6Box_Sachnr.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Plan6Box_Menge.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Plan6Box_Einzelaufwand.Header = TranslateService.Class.GetTranslation("INDIVIDUAL_EFFORT");
            Plan6Box_Gesamtaufwand.Header = TranslateService.Class.GetTranslation("TOTAL");
            Plan6Box_Kapaplanwork.Header = TranslateService.Class.GetTranslation("KAPA");
            Plan6Box_Berechnungwork.Header = TranslateService.Class.GetTranslation("TOTAL");

            Plan7Box_Bezeichnung.Header = TranslateService.Class.GetTranslation("DESCRIPTION");
            Plan7Box_Fahrradtyp.Header = TranslateService.Class.GetTranslation("BIKETYPE");
            Plan7Box_Sachnr.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Plan7Box_Menge.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Plan7Box_Einzelaufwand.Header = TranslateService.Class.GetTranslation("INDIVIDUAL_EFFORT");
            Plan7Box_Gesamtaufwand.Header = TranslateService.Class.GetTranslation("TOTAL");
            Plan7Box_Kapaplanwork.Header = TranslateService.Class.GetTranslation("KAPA");
            Plan7Box_Berechnungwork.Header = TranslateService.Class.GetTranslation("TOTAL");

            Plan8Box_Bezeichnung.Header = TranslateService.Class.GetTranslation("DESCRIPTION");
            Plan8Box_Fahrradtyp.Header = TranslateService.Class.GetTranslation("BIKETYPE");
            Plan8Box_Sachnr.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Plan8Box_Menge.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Plan8Box_Einzelaufwand.Header = TranslateService.Class.GetTranslation("INDIVIDUAL_EFFORT");
            Plan8Box_Gesamtaufwand.Header = TranslateService.Class.GetTranslation("TOTAL");
            Plan8Box_Kapaplanwork.Header = TranslateService.Class.GetTranslation("KAPA");
            Plan8Box_Berechnungwork.Header = TranslateService.Class.GetTranslation("TOTAL");

            Plan9Box_Bezeichnung.Header = TranslateService.Class.GetTranslation("DESCRIPTION");
            Plan9Box_Fahrradtyp.Header = TranslateService.Class.GetTranslation("BIKETYPE");
            Plan9Box_Sachnr.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Plan9Box_Menge.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Plan9Box_Einzelaufwand.Header = TranslateService.Class.GetTranslation("INDIVIDUAL_EFFORT");
            Plan9Box_Gesamtaufwand.Header = TranslateService.Class.GetTranslation("TOTAL");
            Plan9Box_Kapaplanwork.Header = TranslateService.Class.GetTranslation("KAPA");
            Plan9Box_Berechnungwork.Header = TranslateService.Class.GetTranslation("TOTAL");

            Plan10Box_Bezeichnung.Header = TranslateService.Class.GetTranslation("DESCRIPTION");
            Plan10Box_Fahrradtyp.Header = TranslateService.Class.GetTranslation("BIKETYPE");
            Plan10Box_Sachnr.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Plan10Box_Menge.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Plan10Box_Einzelaufwand.Header = TranslateService.Class.GetTranslation("INDIVIDUAL_EFFORT");
            Plan10Box_Gesamtaufwand.Header = TranslateService.Class.GetTranslation("TOTAL");
            Plan10Box_Kapaplanwork.Header = TranslateService.Class.GetTranslation("KAPA");
            Plan10Box_Berechnungwork.Header = TranslateService.Class.GetTranslation("TOTAL");

            Plan11Box_Bezeichnung.Header = TranslateService.Class.GetTranslation("DESCRIPTION");
            Plan11Box_Fahrradtyp.Header = TranslateService.Class.GetTranslation("BIKETYPE");
            Plan11Box_Sachnr.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Plan11Box_Menge.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Plan11Box_Einzelaufwand.Header = TranslateService.Class.GetTranslation("INDIVIDUAL_EFFORT");
            Plan11Box_Gesamtaufwand.Header = TranslateService.Class.GetTranslation("TOTAL");
            Plan11Box_Kapaplanwork.Header = TranslateService.Class.GetTranslation("KAPA");
            Plan11Box_Berechnungwork.Header = TranslateService.Class.GetTranslation("TOTAL");

            Plan12Box_Bezeichnung.Header = TranslateService.Class.GetTranslation("DESCRIPTION");
            Plan12Box_Fahrradtyp.Header = TranslateService.Class.GetTranslation("BIKETYPE");
            Plan12Box_Sachnr.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Plan12Box_Menge.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Plan12Box_Einzelaufwand.Header = TranslateService.Class.GetTranslation("INDIVIDUAL_EFFORT");
            Plan12Box_Gesamtaufwand.Header = TranslateService.Class.GetTranslation("TOTAL");
            Plan12Box_Kapaplanwork.Header = TranslateService.Class.GetTranslation("KAPA");
            Plan12Box_Berechnungwork.Header = TranslateService.Class.GetTranslation("TOTAL");

            Plan13Box_Bezeichnung.Header = TranslateService.Class.GetTranslation("DESCRIPTION");
            Plan13Box_Fahrradtyp.Header = TranslateService.Class.GetTranslation("BIKETYPE");
            Plan13Box_Sachnr.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Plan13Box_Menge.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Plan13Box_Einzelaufwand.Header = TranslateService.Class.GetTranslation("INDIVIDUAL_EFFORT");
            Plan13Box_Gesamtaufwand.Header = TranslateService.Class.GetTranslation("TOTAL");
            Plan13Box_Kapaplanwork.Header = TranslateService.Class.GetTranslation("KAPA");
            Plan13Box_Berechnungwork.Header = TranslateService.Class.GetTranslation("TOTAL");

            Plan14Box_Bezeichnung.Header = TranslateService.Class.GetTranslation("DESCRIPTION");
            Plan14Box_Fahrradtyp.Header = TranslateService.Class.GetTranslation("BIKETYPE");
            Plan14Box_Sachnr.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Plan14Box_Menge.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Plan14Box_Einzelaufwand.Header = TranslateService.Class.GetTranslation("INDIVIDUAL_EFFORT");
            Plan14Box_Gesamtaufwand.Header = TranslateService.Class.GetTranslation("TOTAL");
            Plan14Box_Kapaplanwork.Header = TranslateService.Class.GetTranslation("KAPA");
            Plan14Box_Berechnungwork.Header = TranslateService.Class.GetTranslation("TOTAL");

            Plan15Box_Bezeichnung.Header = TranslateService.Class.GetTranslation("DESCRIPTION");
            Plan15Box_Fahrradtyp.Header = TranslateService.Class.GetTranslation("BIKETYPE");
            Plan15Box_Sachnr.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Plan15Box_Menge.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Plan15Box_Einzelaufwand.Header = TranslateService.Class.GetTranslation("INDIVIDUAL_EFFORT");
            Plan15Box_Gesamtaufwand.Header = TranslateService.Class.GetTranslation("TOTAL");
            Plan15Box_Kapaplanwork.Header = TranslateService.Class.GetTranslation("KAPA");
            Plan15Box_Berechnungwork.Header = TranslateService.Class.GetTranslation("TOTAL");

            Plan1Box_Bezeichnung.Header = TranslateService.Class.GetTranslation("DESCRIPTION");
            Plan1Box_Fahrradtyp.Header = TranslateService.Class.GetTranslation("BIKETYPE");
            Plan1Box_Sachnr.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Plan1Box_Menge.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Plan1Box_Einzelaufwand.Header = TranslateService.Class.GetTranslation("INDIVIDUAL_EFFORT");
            Plan1Box_Gesamtaufwand.Header = TranslateService.Class.GetTranslation("TOTAL");
            Plan1Box_Kapaplanwork.Header = TranslateService.Class.GetTranslation("KAPA");
            Plan1Box_Berechnungwork.Header = TranslateService.Class.GetTranslation("TOTAL");

            Bestell1_Teileno.Header = TranslateService.Class.GetTranslation("ITEM_NO");
            Bestell1_Anzahl.Header = TranslateService.Class.GetTranslation("QUANTITY");
            Bestell1_Art.Header = TranslateService.Class.GetTranslation("TYPE");
            add.Content = TranslateService.Class.GetTranslation("ADD");
            delete.Content = TranslateService.Class.GetTranslation("DEL");
            split.Content = TranslateService.Class.GetTranslation("SPLIT");
            prioAddItemDescription.Content = TranslateService.Class.GetTranslation("ITEM");
            prioAddAmountDescription.Content = TranslateService.Class.GetTranslation("QUANTITY");

            Prio1_Position.Header = TranslateService.Class.GetTranslation("POSITION");
            Prio1_Teilenr.Header = TranslateService.Class.GetTranslation("ITEM1");
            Prio1_Anzahl.Header = TranslateService.Class.GetTranslation("QUANTITY");

            Lager1_Artikel.Header = TranslateService.Class.GetTranslation("LAARTIKEL");
            Lager1_Menge.Header = TranslateService.Class.GetTranslation("LAMENGE");
            Lager1_Startmenge.Header = TranslateService.Class.GetTranslation("LASTARTMENGE");
            Lager1_menge_startmenge.Header = TranslateService.Class.GetTranslation("LAMENGE1");
            Lager1_Preis.Header = TranslateService.Class.GetTranslation("LAPREIS");
            Lager1_Lagerwert.Header = TranslateService.Class.GetTranslation("LALAGERWERT");

            Liefer1_Lieferfrist.Header = TranslateService.Class.GetTranslation("LLIEFFERFRIST");
            Liefer1_Abweichung.Header = TranslateService.Class.GetTranslation("LABWEICHUNG");
            Liefer1_Kaufteileno.Header = TranslateService.Class.GetTranslation("LKAUFTEILENO");
            Liefer1_Kaufteil.Header = TranslateService.Class.GetTranslation("LKAUFTEIL");
            Liefer1_Bestellkosten.Header = TranslateService.Class.GetTranslation("LBESTELLKOSTEN");
            Liefer1_Diskontmenge.Header = TranslateService.Class.GetTranslation("LDISKONT");
            Liefer1_Teilewert.Header = TranslateService.Class.GetTranslation("LTEILEWERT");
            Liefer1_Verwendung.Header = TranslateService.Class.GetTranslation("LVERWENDUNG");

            Exportlabel.Content = TranslateService.Class.GetTranslation("EXPORTLABEL");

            UpdateSummeFromForcast(null, null);
            dataGrid1.ItemsSource = CreateWork1();
            dataGrid2.ItemsSource = CreateWork2();
            dataGrid3.ItemsSource = CreateWork3();
            dataGrid4.ItemsSource = CreateWork4();
            dataGrid6.ItemsSource = CreateWork6();
            dataGrid7.ItemsSource = CreateWork7();
            dataGrid8.ItemsSource = CreateWork8();
            dataGrid9.ItemsSource = CreateWork9();
            dataGrid10.ItemsSource = CreateWork10();
            dataGrid11.ItemsSource = CreateWork11();
            dataGrid12.ItemsSource = CreateWork12();
            dataGrid13.ItemsSource = CreateWork13();
            dataGrid14.ItemsSource = CreateWork14();
            dataGrid15.ItemsSource = CreateWork15();
            dataGrid16.ItemsSource = CreateWorkPlan16();
            dataGrid17.ItemsSource = CreateWorkPlan16();
            dataGrid18.ItemsSource = CreateWorkPlan16();
            dataGrid19.ItemsSource = CreateWorkPlan16();
            dataGrid20.ItemsSource = CreateWorkPlan16();
            dataGrid21.ItemsSource = CreateWorkPlan16();
            dataGrid22.ItemsSource = CreateWorkPlan16();
            dataGrid23.ItemsSource = CreateWorkPlan16();
            dataGrid24.ItemsSource = CreateWorkPlan16();
            dataGrid25.ItemsSource = CreateWorkPlan16();
            dataGrid26.ItemsSource = CreateWorkPlan16();
            dataGrid27.ItemsSource = CreateWorkPlan16();
            dataGrid28.ItemsSource = CreateWorkPlan16();
            dataGrid29.ItemsSource = CreateWorkPlan16();
            dataGrid30.ItemsSource = CreateLiefer1();
            dataGrid31.ItemsSource = CreateEinkauf1();
            dataGrid32.ItemsSource = CreateLagerbestand();
            prio.ItemsSource = CreatePrio1();
        }


        
        public ObservableCollection<Prio> CreatePrio1()
        {
            ObservableCollection<Prio> prio = new ObservableCollection<Prio>();
            return prio;
        }


        public ObservableCollection<Einkauf> CreateEinkauf1()
        {
            ObservableCollection<Einkauf> einkauf = new ObservableCollection<Einkauf>();
            return einkauf;
        }
        public ObservableCollection<Liefer> CreateLiefer1()
        {
            ObservableCollection<Liefer> liefer = new ObservableCollection<Liefer>();
            liefer.Add(new Liefer { Kaufteileno = "21", Kaufteil = TranslateService.Class.GetTranslation("CHAIN"), Verwendung = "K", Teilewert = "5,00", Diskontmenge = "300", Bestellkosten = "50", Lieferfrist = "1,8", Abweichung = "0,4" });
            liefer.Add(new Liefer { Kaufteileno = "22", Kaufteil = TranslateService.Class.GetTranslation("CHAIN"), Verwendung = "D", Teilewert = "6,50", Diskontmenge = "300", Bestellkosten = "50", Lieferfrist = "1,7", Abweichung = "0,4" });
            liefer.Add(new Liefer { Kaufteileno = "23", Kaufteil = TranslateService.Class.GetTranslation("CHAIN"), Verwendung = "H", Teilewert = "6,50", Diskontmenge = "300", Bestellkosten = "50", Lieferfrist = "1,2", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "24", Kaufteil = TranslateService.Class.GetTranslation("UT_three"), Verwendung = "KDH", Teilewert = "0,06", Diskontmenge = "6100", Bestellkosten = "100", Lieferfrist = "3,2", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "25", Kaufteil = TranslateService.Class.GetTranslation("WASHER"), Verwendung = "KDH", Teilewert = "0,06", Diskontmenge = "3600", Bestellkosten = "50", Lieferfrist = "0,9", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "27", Kaufteil = TranslateService.Class.GetTranslation("SCREW"), Verwendung = "KDH", Teilewert = "0,1", Diskontmenge = "1800", Bestellkosten = "75", Lieferfrist = "0,9", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "28", Kaufteil = TranslateService.Class.GetTranslation("TUBE"), Verwendung = "KDH", Teilewert = "1,20", Diskontmenge = "4500", Bestellkosten = "50", Lieferfrist = "1,7", Abweichung = "0,4" });
            liefer.Add(new Liefer { Kaufteileno = "32", Kaufteil = TranslateService.Class.GetTranslation("PAINT"), Verwendung = "KDH", Teilewert = "0,75", Diskontmenge = "2700", Bestellkosten = "50", Lieferfrist = "2,1", Abweichung = "0,5" });
            liefer.Add(new Liefer { Kaufteileno = "33", Kaufteil = TranslateService.Class.GetTranslation("RIM"), Verwendung = "H", Teilewert = "22,00", Diskontmenge = "900", Bestellkosten = "75", Lieferfrist = "1,9", Abweichung = "0,5" });
            liefer.Add(new Liefer { Kaufteileno = "34", Kaufteil = TranslateService.Class.GetTranslation("SPOKE"), Verwendung = "H", Teilewert = "0,1", Diskontmenge = "22000", Bestellkosten = "50", Lieferfrist = "1,6", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "35", Kaufteil = TranslateService.Class.GetTranslation("TAPER"), Verwendung = "KDH", Teilewert = "1,00", Diskontmenge = "3600", Bestellkosten = "75", Lieferfrist = "2,2", Abweichung = "0,4" });
            liefer.Add(new Liefer { Kaufteileno = "36", Kaufteil = TranslateService.Class.GetTranslation("FREE"), Verwendung = "KDH", Teilewert = "8,00", Diskontmenge = "900", Bestellkosten = "100", Lieferfrist = "1,2", Abweichung = "0,1" });
            liefer.Add(new Liefer { Kaufteileno = "37", Kaufteil = TranslateService.Class.GetTranslation("FORK"), Verwendung = "KDH", Teilewert = "1,50", Diskontmenge = "900", Bestellkosten = "50", Lieferfrist = "1,5", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "38", Kaufteil = TranslateService.Class.GetTranslation("AXLE"), Verwendung = "KDH", Teilewert = "1,50", Diskontmenge = "300", Bestellkosten = "50", Lieferfrist = "1,7", Abweichung = "0,4" });
            liefer.Add(new Liefer { Kaufteileno = "39", Kaufteil = TranslateService.Class.GetTranslation("SHEET"), Verwendung = "KDH", Teilewert = "1,50", Diskontmenge = "1800", Bestellkosten = "75", Lieferfrist = "1,5", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "40", Kaufteil = TranslateService.Class.GetTranslation("HANDLE_BAR"), Verwendung = "KDH", Teilewert = "2,50", Diskontmenge = "900", Bestellkosten = "50", Lieferfrist = "1,7", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "41", Kaufteil = TranslateService.Class.GetTranslation("NUT_FOUR"), Verwendung = "KDH", Teilewert = "0,06", Diskontmenge = "900", Bestellkosten = "50", Lieferfrist = "0,9", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "42", Kaufteil = TranslateService.Class.GetTranslation("HANDLE_GRIP"), Verwendung = "KDH", Teilewert = "0,10", Diskontmenge = "1800", Bestellkosten = "50", Lieferfrist = "1,2", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "43", Kaufteil = TranslateService.Class.GetTranslation("SADDLE"), Verwendung = "KDH", Teilewert = "5,00", Diskontmenge = "2700", Bestellkosten = "75", Lieferfrist = "2,0", Abweichung = "0,5" });
            liefer.Add(new Liefer { Kaufteileno = "44", Kaufteil = TranslateService.Class.GetTranslation("BAR"), Verwendung = "KDH", Teilewert = "0,50", Diskontmenge = "900", Bestellkosten = "50", Lieferfrist = "1,2", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "45", Kaufteil = TranslateService.Class.GetTranslation("NUT_QUARTER"), Verwendung = "KDH", Teilewert = "0,06", Diskontmenge = "900", Bestellkosten = "50", Lieferfrist = "1,7", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "46", Kaufteil = TranslateService.Class.GetTranslation("SCREW_QUARTER"), Verwendung = "KDH", Teilewert = "0,10", Diskontmenge = "900", Bestellkosten = "50", Lieferfrist = "0,9", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "47", Kaufteil = TranslateService.Class.GetTranslation("SPROCKET"), Verwendung = "KDH", Teilewert = "3,50", Diskontmenge = "900", Bestellkosten = "50", Lieferfrist = "1,1", Abweichung = "0,1" });
            liefer.Add(new Liefer { Kaufteileno = "48", Kaufteil = TranslateService.Class.GetTranslation("PEDAL"), Verwendung = "KDH", Teilewert = "1,50", Diskontmenge = "1800", Bestellkosten = "75", Lieferfrist = "1,0", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "52", Kaufteil = TranslateService.Class.GetTranslation("RIM"), Verwendung = "K", Teilewert = "22,00", Diskontmenge = "600", Bestellkosten = "50", Lieferfrist = "1,6", Abweichung = "0,4" });
            liefer.Add(new Liefer { Kaufteileno = "53", Kaufteil = TranslateService.Class.GetTranslation("SPOKE"), Verwendung = "K", Teilewert = "0,10", Diskontmenge = "22000", Bestellkosten = "50", Lieferfrist = "1,6", Abweichung = "0,2" });
            liefer.Add(new Liefer { Kaufteileno = "57", Kaufteil = TranslateService.Class.GetTranslation("RIM"), Verwendung = "D", Teilewert = "22,00", Diskontmenge = "600", Bestellkosten = "50", Lieferfrist = "1,7", Abweichung = "0,3" });
            liefer.Add(new Liefer { Kaufteileno = "58", Kaufteil = TranslateService.Class.GetTranslation("SPOKE"), Verwendung = "D", Teilewert = "0,10", Diskontmenge = "22000", Bestellkosten = "50", Lieferfrist = "1,6", Abweichung = "0,5" });
            liefer.Add(new Liefer { Kaufteileno = "59", Kaufteil = TranslateService.Class.GetTranslation("WELDING_WIRES"), Verwendung = "KDH", Teilewert = "0,15", Diskontmenge = "1800", Bestellkosten = "50", Lieferfrist = "0,7", Abweichung = "0,2" });
            return liefer;
        }

        public ObservableCollection<Lagerbestand> CreateLagerbestand()
        {
                    ObservableCollection<Lagerbestand> lagerbestand = new ObservableCollection<Lagerbestand>();
                    return lagerbestand;

        }

        public ObservableCollection<KapNo> CreateWorkPlan16()
        {
            ObservableCollection<KapNo> kapno = new ObservableCollection<KapNo>();
            kapno.Add(new KapNo { Kapaplanwork = TranslateService.Class.GetTranslation("CAPACITY_REQ_NEW"), Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = TranslateService.Class.GetTranslation("SETUP_TIME_NEW"), Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = TranslateService.Class.GetTranslation("CAP_REQ_PREV"), Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = TranslateService.Class.GetTranslation("SETUP_TIME_PREV"), Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = TranslateService.Class.GetTranslation("TOTAL_CAP_REQ"), Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = TranslateService.Class.GetTranslation("SHIFTS"), Berechnungwork = "" });
            kapno.Add(new KapNo { Kapaplanwork = TranslateService.Class.GetTranslation("OVERTIMEPERDAY"), Berechnungwork = "" });
            return kapno;
        }
        public ObservableCollection<ItemNo> CreateWork1()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRONT_WHEEL_COMPLETE"), Sachnr = "E49", Fahrradtyp = "K", Einzelaufwand = "6", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRONT_WHEEL_COMPLETE"), Sachnr = "E54", Fahrradtyp = "D", Einzelaufwand = "6", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRONT_WHEEL_COMPLETE"), Sachnr = "E29", Fahrradtyp = "H", Einzelaufwand = "6", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork2()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRAME_AND_WHEELS"), Sachnr = "E50", Fahrradtyp = "K", Einzelaufwand = "5", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRAME_AND_WHEELS"), Sachnr = "E55", Fahrradtyp = "D", Einzelaufwand = "5", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRAME_AND_WHEELS"), Sachnr = "E30", Fahrradtyp = "H", Einzelaufwand = "5", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork3()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("BICYCLE_WITHOUT_PEDAL"), Sachnr = "E51", Fahrradtyp = "K", Einzelaufwand = "5", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("BICYCLE_WITHOUT_PEDAL"), Sachnr = "E56", Fahrradtyp = "D", Einzelaufwand = "6", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("BICYCLE_WITHOUT_PEDAL"), Sachnr = "E31", Fahrradtyp = "H", Einzelaufwand = "6", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork4()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("BICYCLE_COMPLETE"), Sachnr = "P1", Fahrradtyp = "K", Einzelaufwand = "6", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("BICYCLE_COMPLETE"), Sachnr = "P2", Fahrradtyp = "D", Einzelaufwand = "7", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("BICYCLE_COMPLETE"), Sachnr = "P3", Fahrradtyp = "H", Einzelaufwand = "7", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork6()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("HANDLE_BAR"), Sachnr = "E16", Fahrradtyp = "KDH", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRAME"), Sachnr = "E18", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRAME"), Sachnr = "E19", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRAME"), Sachnr = "E20", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork7()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_REAR"), Sachnr = "E10", Fahrradtyp = "K", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_REAR"), Sachnr = "E11", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_REAR"), Sachnr = "E12", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_FRONT"), Sachnr = "E13", Fahrradtyp = "K", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_FRONT"), Sachnr = "E14", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_FRONT"), Sachnr = "E15", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRAME"), Sachnr = "E18", Fahrradtyp = "K", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRAME"), Sachnr = "E19", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRAME"), Sachnr = "E20", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("PEDAL"), Sachnr = "E26", Fahrradtyp = "KDH", Einzelaufwand = "2", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork8()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_REAR"), Sachnr = "E10", Fahrradtyp = "K", Einzelaufwand = "1", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_REAR"), Sachnr = "E11", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_REAR"), Sachnr = "E12", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_FRONT"), Sachnr = "E13", Fahrradtyp = "K", Einzelaufwand = "1", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_FRONT"), Sachnr = "E14", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_FRONT"), Sachnr = "E15", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRAME"), Sachnr = "E18", Fahrradtyp = "K", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRAME"), Sachnr = "E19", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRAME"), Sachnr = "E20", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork9()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_REAR"), Sachnr = "E10", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_REAR"), Sachnr = "E11", Fahrradtyp = "D", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_REAR"), Sachnr = "E12", Fahrradtyp = "H", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_FRONT"), Sachnr = "E13", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_FRONT"), Sachnr = "E14", Fahrradtyp = "D", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_FRONT"), Sachnr = "E15", Fahrradtyp = "H", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRAME"), Sachnr = "E18", Fahrradtyp = "K", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRAME"), Sachnr = "E19", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRAME"), Sachnr = "E20", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork10()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("REAR_WHEEL"), Sachnr = "E4", Fahrradtyp = "K", Einzelaufwand = "4", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("REAR_WHEEL"), Sachnr = "E5", Fahrradtyp = "D", Einzelaufwand = "4", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("REAR_WHEEL"), Sachnr = "E6", Fahrradtyp = "H", Einzelaufwand = "4", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRONT_WHEEL"), Sachnr = "E7", Fahrradtyp = "K", Einzelaufwand = "4", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRONT_WHEEL"), Sachnr = "E8", Fahrradtyp = "D", Einzelaufwand = "4", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRONT_WHEEL"), Sachnr = "E9", Fahrradtyp = "H", Einzelaufwand = "4", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork11()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("REAR_WHEEL"), Sachnr = "E4", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("REAR_WHEEL"), Sachnr = "E5", Fahrradtyp = "D", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("REAR_WHEEL"), Sachnr = "E6", Fahrradtyp = "H", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRONT_WHEEL"), Sachnr = "E7", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRONT_WHEEL"), Sachnr = "E8", Fahrradtyp = "D", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("FRONT_WHEEL"), Sachnr = "E9", Fahrradtyp = "H", Einzelaufwand = "3", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork12()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_REAR"), Sachnr = "E10", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_REAR"), Sachnr = "E11", Fahrradtyp = "D", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_REAR"), Sachnr = "E12", Fahrradtyp = "H", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_FRONT"), Sachnr = "E13", Fahrradtyp = "K", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_FRONT"), Sachnr = "E14", Fahrradtyp = "D", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_FRONT"), Sachnr = "E15", Fahrradtyp = "H", Einzelaufwand = "3", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork13()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_REAR"), Sachnr = "E10", Fahrradtyp = "K", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_REAR"), Sachnr = "E11", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_REAR"), Sachnr = "E12", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_FRONT"), Sachnr = "E13", Fahrradtyp = "K", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_FRONT"), Sachnr = "E14", Fahrradtyp = "D", Einzelaufwand = "2", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("MUDGUARD_FRONT"), Sachnr = "E15", Fahrradtyp = "H", Einzelaufwand = "2", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork14()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("HANDLE_BAR"), Sachnr = "E16", Fahrradtyp = "KDH", Einzelaufwand = "3", Gesamtaufwand = "" });
            return itemno;
        }

        public ObservableCollection<ItemNo> CreateWork15()
        {
            ObservableCollection<ItemNo> itemno = new ObservableCollection<ItemNo>();
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("SEAT"), Sachnr = "E17", Fahrradtyp = "KDH", Einzelaufwand = "3", Gesamtaufwand = "" });
            itemno.Add(new ItemNo { Bezeichnung = TranslateService.Class.GetTranslation("Pedal"), Sachnr = "E26", Fahrradtyp = "KDH", Einzelaufwand = "3", Gesamtaufwand = "" });
            return itemno;
        }

        public void LoadTranslations()
        {

        }

        public void UpdateCalculations()
        {
            prognosevarperiod1.Content = (Static.Static.lastperiod + 1).ToString();
            prognosevarperiod2.Content = (Static.Static.lastperiod + 2).ToString();
            prognosevarperiod3.Content = (Static.Static.lastperiod + 3).ToString();
            prognosevarperiod4.Content = (Static.Static.lastperiod + 4).ToString();
        }



        private void Choosefile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialogDateipfad = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> dialogDateipfadResult = dialogDateipfad.ShowDialog();
            if (dialogDateipfadResult == true)
            {
                if (!dialogDateipfad.FileName.Contains(".xml"))
                {
                    MessageBox.Show(TranslateService.Class.GetTranslation("XML_ERROR"), "XML Input", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Pathtextbox.Text = dialogDateipfad.FileName;
            }
        }

        protected bool GetFilename(out string filename, DragEventArgs e)
        {
            bool ret = false;
            filename = String.Empty;

            if ((e.AllowedEffects & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileName") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        string ext = System.IO.Path.GetExtension(filename).ToLower();
                        if ((ext == ".xml") || (ext == ".XML"))
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine("OnDragEnter");
            bool validData = GetFilename(out string filename, e);
            Console.WriteLine(validData.ToString());
            if (!validData)
            {
                MessageBox.Show(TranslateService.Class.GetTranslation("XML_ERROR"), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Pathtextbox.Text = filename;
        }


        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Pathtextbox.Text = "";
        }



        private void Settingsmenuheader_Click(object sender, RoutedEventArgs e)
        {
            Settings Settingspage = new Settings();
            Settingspage.Show();
        }

        private void Aboutmenuheader_Click(object sender, RoutedEventArgs e)
        {
            About AboutPage = new About();
            AboutPage.Show();
        }

        private void Closemenuitem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(21);
        }

        private void Helpmenuitem_Click(object sender, RoutedEventArgs e)
        {
            /*Wiki Wikipage = new Wiki();
            Wikipage.Show();*/
            try
            {
                Process.Start(@".\Help\Help_" + TranslateService.Class.PrimaryLanguage + ".pdf");
            }
            catch { }
        }

        private void Calculatebutton_Click(object sender, RoutedEventArgs e)
        {



            try
            {
                if (Sicherheitsfaktor.Text == "")
                {
                    MessageBox.Show(TranslateService.Class.GetTranslation("SECURITYFACTOR_EMPTY"));
                    return;
                }

                if (Convert.ToInt32(forecastsy1p1.Text) % 10 != 0 || Convert.ToInt32(forecastsy1p2.Text) % 10 != 0 || Convert.ToInt32(forecastsy1p3.Text) % 10 != 0 || Convert.ToInt32(forecastsy2p1.Text) % 10 != 0 || Convert.ToInt32(forecastsy2p2.Text) % 10 != 0 || Convert.ToInt32(forecastsy2p3.Text) % 10 != 0 || Convert.ToInt32(forecastsy3p1.Text) % 10 != 0 || Convert.ToInt32(forecastsy3p2.Text) % 10 != 0 || Convert.ToInt32(forecastsy3p3.Text) % 10 != 0 || Convert.ToInt32(forecastsy4p1.Text) % 10 != 0 || Convert.ToInt32(forecastsy4p2.Text) % 10 != 0 || Convert.ToInt32(forecastsy4p3.Text) % 10 != 0)
                {
                    MessageBox.Show(TranslateService.Class.GetTranslation("INPUT_VALUE_ERROR"));
                    return;
                }
            }
            catch
            {

            }

            ValueStore vs = ValueStore.Instance;
            vs.sicherheitsbestandP1 = Convert.ToInt32(forecastsy1p1.Text);
            vs.sicherheitsbestandP2 = Convert.ToInt32(forecastsy1p2.Text);
            vs.sicherheitsbestandP3 = Convert.ToInt32(forecastsy1p3.Text);

            vs.sb_Prognose1P1 = Convert.ToInt32(forecastsy2p1.Text);
            vs.sb_Prognose1P2 = Convert.ToInt32(forecastsy2p2.Text);
            vs.sb_Prognose1P3 = Convert.ToInt32(forecastsy2p3.Text);

            vs.sb_Prognose2P1 = Convert.ToInt32(forecastsy3p1.Text);
            vs.sb_Prognose2P2 = Convert.ToInt32(forecastsy3p2.Text);
            vs.sb_Prognose2P3 = Convert.ToInt32(forecastsy3p3.Text);

            vs.sb_Prognose3P1 = Convert.ToInt32(forecastsy4p1.Text);
            vs.sb_Prognose3P2 = Convert.ToInt32(forecastsy4p2.Text);
            vs.sb_Prognose3P3 = Convert.ToInt32(forecastsy4p3.Text);

            vs.sicherheitsFaktor = Convert.ToInt32(Sicherheitsfaktor.Text);


            Ui.EnableNextTab(Kapaplanungtab, MainTabControl);
            Ui.EnableNextTab(Einkauftab, MainTabControl, false);
            Ui.EnableNextTab(Produktionsplanungtab, MainTabControl, false);
            Ui.EnableNextTab(Priorisierungtab, MainTabControl, false);
            //Ui.EnableNextTab(Chartstab, MainTabControl, false);
            Ui.EnableNextTab(Exporttab, MainTabControl, false);
            //Check atuotmatic Import
            if (found == false)
            {
                customexportpathtextbox.IsEnabled = true;
            }
            if(found == true)
            {
                xmlexportbutton.IsEnabled = true;
            }


            Ibsys2.Berechnungen.Logic.Berechnungen logic = new Ibsys2.Berechnungen.Logic.Berechnungen();
            logic.berechnen();

            UpdatePlanningFields();
            UpdateKapaFields();
            UpdateEinkauf();
            UpdatePrioFields();
            UpdateLager();
        }

        private void UpdatePlanningFields()
        {
            ValueStore vs = ValueStore.Instance;
            Warehousestock w = Warehousestock.Class;
            Waitinglistworkstations wlw = Waitinglistworkstations.Class;
            Ordersinwork oiw = Ordersinwork.Class;

            //Kinderfahrrad
            kind11.Text = vs.vertriebswunschP1.ToString();
            kind31.Text = vs.sicherheitsbestandP1.ToString();
            kind41.Text = w.GetArticleByID(1).Amount.ToString();
            kind51.Text = wlw.GetArticleAmountByID(1).ToString();
            kind61.Text = oiw.GetArticleAmountByID(1).ToString();
            kind71.Text = Produktionsplanung.p1.ToString();

            kind12.Text = Produktionsplanung.p1.ToString();
            kind22.Text = wlw.GetArticleAmountByID(1).ToString();
            kind32.Text = vs.sicherheitsbestandP1.ToString();
            kind42.Text = (w.GetArticleByID(26).Amount / 3).ToString();
            kind52.Text = (wlw.GetArticleAmountByID(26) / 3).ToString();
            kind62.Text = (oiw.GetArticleAmountByID(26) / 3).ToString();
            kind72.Text = Produktionsplanung.e26K.ToString();

            kind13.Text = Produktionsplanung.p1.ToString();
            kind23.Text = wlw.GetArticleAmountByID(1).ToString();
            kind33.Text = vs.sicherheitsbestandP1.ToString();
            kind43.Text = w.GetArticleByID(51).Amount.ToString();
            kind53.Text = wlw.GetArticleAmountByID(51).ToString();
            kind63.Text = oiw.GetArticleAmountByID(51).ToString();
            kind73.Text = Produktionsplanung.e51.ToString();

            kind14.Text = Produktionsplanung.e51.ToString();
            kind24.Text = wlw.GetArticleAmountByID(51).ToString();
            kind34.Text = vs.sicherheitsbestandP1.ToString();
            kind44.Text = (w.GetArticleByID(16).Amount / 3).ToString();
            kind54.Text = (wlw.GetArticleAmountByID(16) / 3).ToString();
            kind64.Text = (oiw.GetArticleAmountByID(16) / 3).ToString();
            kind74.Text = Produktionsplanung.e16K.ToString();

            kind15.Text = Produktionsplanung.e51.ToString();
            kind25.Text = wlw.GetArticleAmountByID(51).ToString();
            kind35.Text = vs.sicherheitsbestandP1.ToString();
            kind45.Text = (w.GetArticleByID(17).Amount / 3).ToString();
            kind55.Text = (wlw.GetArticleAmountByID(17) / 3).ToString();
            kind65.Text = (oiw.GetArticleAmountByID(17) / 3).ToString();
            kind75.Text = Produktionsplanung.e17K.ToString();

            kind16.Text = Produktionsplanung.e51.ToString();
            kind26.Text = wlw.GetArticleAmountByID(51).ToString();
            kind36.Text = vs.sicherheitsbestandP1.ToString();
            kind46.Text = w.GetArticleByID(50).Amount.ToString();
            kind56.Text = wlw.GetArticleAmountByID(50).ToString();
            kind66.Text = oiw.GetArticleAmountByID(50).ToString();
            kind76.Text = Produktionsplanung.e50.ToString();

            kind17.Text = Produktionsplanung.e50.ToString();
            kind27.Text = wlw.GetArticleAmountByID(50).ToString();
            kind37.Text = vs.sicherheitsbestandP1.ToString();
            kind47.Text = w.GetArticleByID(4).Amount.ToString();
            kind57.Text = wlw.GetArticleAmountByID(4).ToString();
            kind67.Text = oiw.GetArticleAmountByID(4).ToString();
            kind77.Text = Produktionsplanung.e4.ToString();

            kind18.Text = Produktionsplanung.e50.ToString();
            kind28.Text = wlw.GetArticleAmountByID(50).ToString();
            kind38.Text = vs.sicherheitsbestandP1.ToString();
            kind48.Text = w.GetArticleByID(10).Amount.ToString();
            kind58.Text = wlw.GetArticleAmountByID(10).ToString();
            kind68.Text = oiw.GetArticleAmountByID(10).ToString();
            kind78.Text = Produktionsplanung.e10.ToString();

            kind19.Text = Produktionsplanung.e50.ToString();
            kind29.Text = wlw.GetArticleAmountByID(50).ToString();
            kind39.Text = vs.sicherheitsbestandP1.ToString();
            kind49.Text = w.GetArticleByID(49).Amount.ToString();
            kind59.Text = wlw.GetArticleAmountByID(49).ToString();
            kind69.Text = oiw.GetArticleAmountByID(49).ToString();
            kind79.Text = Produktionsplanung.e49.ToString();

            kind110.Text = Produktionsplanung.e49.ToString();
            kind210.Text = wlw.GetArticleAmountByID(49).ToString();
            kind310.Text = vs.sicherheitsbestandP1.ToString();
            kind410.Text = w.GetArticleByID(7).Amount.ToString();
            kind510.Text = wlw.GetArticleAmountByID(7).ToString();
            kind610.Text = oiw.GetArticleAmountByID(7).ToString();
            kind710.Text = Produktionsplanung.e7.ToString();

            kind111.Text = Produktionsplanung.e49.ToString();
            kind211.Text = wlw.GetArticleAmountByID(49).ToString();
            kind311.Text = vs.sicherheitsbestandP1.ToString();
            kind411.Text = w.GetArticleByID(13).Amount.ToString();
            kind511.Text = wlw.GetArticleAmountByID(13).ToString();
            kind611.Text = oiw.GetArticleAmountByID(13).ToString();
            kind711.Text = Produktionsplanung.e13.ToString();

            kind112.Text = Produktionsplanung.e49.ToString();
            kind212.Text = wlw.GetArticleAmountByID(49).ToString();
            kind312.Text = vs.sicherheitsbestandP1.ToString();
            kind412.Text = w.GetArticleByID(18).Amount.ToString();
            kind512.Text = wlw.GetArticleAmountByID(18).ToString();
            kind612.Text = oiw.GetArticleAmountByID(18).ToString();
            kind712.Text = Produktionsplanung.e18.ToString();


            //Damenfahhrad
            damen11.Text = vs.vertriebswunschP2.ToString();
            damen31.Text = vs.sicherheitsbestandP2.ToString();
            damen41.Text = w.GetArticleByID(2).Amount.ToString();
            damen51.Text = wlw.GetArticleAmountByID(2).ToString();
            damen61.Text = oiw.GetArticleAmountByID(2).ToString();
            damen71.Text = Produktionsplanung.p2.ToString();

            damen12.Text = Produktionsplanung.p2.ToString();
            damen22.Text = wlw.GetArticleAmountByID(2).ToString();
            damen32.Text = vs.sicherheitsbestandP2.ToString();
            damen42.Text = (w.GetArticleByID(26).Amount / 3).ToString();
            damen52.Text = (wlw.GetArticleAmountByID(26) / 3).ToString();
            damen62.Text = (oiw.GetArticleAmountByID(26) / 3).ToString();
            damen72.Text = Produktionsplanung.e26D.ToString();

            damen13.Text = Produktionsplanung.p2.ToString();
            damen23.Text = wlw.GetArticleAmountByID(2).ToString();
            damen33.Text = vs.sicherheitsbestandP2.ToString();
            damen43.Text = w.GetArticleByID(56).Amount.ToString();
            damen53.Text = wlw.GetArticleAmountByID(56).ToString();
            damen63.Text = oiw.GetArticleAmountByID(56).ToString();
            damen73.Text = Produktionsplanung.e56.ToString();

            damen14.Text = Produktionsplanung.e56.ToString();
            damen24.Text = wlw.GetArticleAmountByID(56).ToString();
            damen34.Text = vs.sicherheitsbestandP2.ToString();
            damen44.Text = (w.GetArticleByID(16).Amount / 3).ToString();
            damen54.Text = (wlw.GetArticleAmountByID(16) / 3).ToString();
            damen64.Text = (oiw.GetArticleAmountByID(16) / 3).ToString();
            damen74.Text = Produktionsplanung.e16D.ToString();

            damen15.Text = Produktionsplanung.e56.ToString();
            damen25.Text = wlw.GetArticleAmountByID(56).ToString();
            damen35.Text = vs.sicherheitsbestandP2.ToString();
            damen45.Text = (w.GetArticleByID(17).Amount / 3).ToString();
            damen55.Text = (wlw.GetArticleAmountByID(17) / 3).ToString();
            damen65.Text = (oiw.GetArticleAmountByID(17) / 3).ToString();
            damen75.Text = Produktionsplanung.e17D.ToString();

            damen16.Text = Produktionsplanung.e56.ToString();
            damen26.Text = wlw.GetArticleAmountByID(56).ToString();
            damen36.Text = vs.sicherheitsbestandP2.ToString();
            damen46.Text = w.GetArticleByID(55).Amount.ToString();
            damen56.Text = wlw.GetArticleAmountByID(55).ToString();
            damen66.Text = oiw.GetArticleAmountByID(55).ToString();
            damen76.Text = Produktionsplanung.e55.ToString();

            damen17.Text = Produktionsplanung.e55.ToString();
            damen27.Text = wlw.GetArticleAmountByID(55).ToString();
            damen37.Text = vs.sicherheitsbestandP2.ToString();
            damen47.Text = w.GetArticleByID(5).Amount.ToString();
            damen57.Text = wlw.GetArticleAmountByID(5).ToString();
            damen67.Text = oiw.GetArticleAmountByID(5).ToString();
            damen77.Text = Produktionsplanung.e5.ToString();

            damen18.Text = Produktionsplanung.e55.ToString();
            damen28.Text = wlw.GetArticleAmountByID(55).ToString();
            damen38.Text = vs.sicherheitsbestandP2.ToString();
            damen48.Text = w.GetArticleByID(11).Amount.ToString();
            damen58.Text = wlw.GetArticleAmountByID(11).ToString();
            damen68.Text = oiw.GetArticleAmountByID(11).ToString();
            damen78.Text = Produktionsplanung.e11.ToString();

            damen19.Text = Produktionsplanung.e55.ToString();
            damen29.Text = wlw.GetArticleAmountByID(55).ToString();
            damen39.Text = vs.sicherheitsbestandP2.ToString();
            damen49.Text = w.GetArticleByID(54).Amount.ToString();
            damen59.Text = wlw.GetArticleAmountByID(54).ToString();
            damen69.Text = oiw.GetArticleAmountByID(54).ToString();
            damen79.Text = Produktionsplanung.e54.ToString();

            damen110.Text = Produktionsplanung.e54.ToString();
            damen210.Text = wlw.GetArticleAmountByID(54).ToString();
            damen310.Text = vs.sicherheitsbestandP2.ToString();
            damen410.Text = w.GetArticleByID(8).Amount.ToString();
            damen510.Text = wlw.GetArticleAmountByID(8).ToString();
            damen610.Text = oiw.GetArticleAmountByID(8).ToString();
            damen710.Text = Produktionsplanung.e8.ToString();

            damen111.Text = Produktionsplanung.e54.ToString();
            damen211.Text = wlw.GetArticleAmountByID(54).ToString();
            damen311.Text = vs.sicherheitsbestandP2.ToString();
            damen411.Text = w.GetArticleByID(14).Amount.ToString();
            damen511.Text = wlw.GetArticleAmountByID(14).ToString();
            damen611.Text = oiw.GetArticleAmountByID(14).ToString();
            damen711.Text = Produktionsplanung.e14.ToString();

            damen112.Text = Produktionsplanung.e54.ToString();
            damen212.Text = wlw.GetArticleAmountByID(54).ToString();
            damen312.Text = vs.sicherheitsbestandP2.ToString();
            damen412.Text = w.GetArticleByID(19).Amount.ToString();
            damen512.Text = wlw.GetArticleAmountByID(19).ToString();
            damen612.Text = oiw.GetArticleAmountByID(19).ToString();
            damen712.Text = Produktionsplanung.e19.ToString();


            //Herrenfahrrad
            herren11.Text = vs.vertriebswunschP3.ToString();
            herren31.Text = vs.sicherheitsbestandP3.ToString();
            herren41.Text = w.GetArticleByID(3).Amount.ToString();
            herren51.Text = wlw.GetArticleAmountByID(3).ToString();
            herren61.Text = oiw.GetArticleAmountByID(3).ToString();
            herren71.Text = Produktionsplanung.p3.ToString();

            herren12.Text = Produktionsplanung.p3.ToString();
            herren22.Text = wlw.GetArticleAmountByID(3).ToString();
            herren32.Text = vs.sicherheitsbestandP2.ToString();
            herren42.Text = (w.GetArticleByID(26).Amount / 3).ToString();
            herren52.Text = (wlw.GetArticleAmountByID(26) / 3).ToString();
            herren62.Text = (oiw.GetArticleAmountByID(26) / 3).ToString();
            herren72.Text = Produktionsplanung.e26H.ToString();

            herren13.Text = Produktionsplanung.p3.ToString();
            herren23.Text = wlw.GetArticleAmountByID(3).ToString();
            herren33.Text = vs.sicherheitsbestandP2.ToString();
            herren43.Text = w.GetArticleByID(31).Amount.ToString();
            herren53.Text = wlw.GetArticleAmountByID(31).ToString();
            herren63.Text = oiw.GetArticleAmountByID(31).ToString();
            herren73.Text = Produktionsplanung.e31.ToString();

            herren14.Text = Produktionsplanung.e31.ToString();
            herren24.Text = wlw.GetArticleAmountByID(31).ToString();
            herren34.Text = vs.sicherheitsbestandP2.ToString();
            herren44.Text = (w.GetArticleByID(16).Amount / 3).ToString();
            herren54.Text = (wlw.GetArticleAmountByID(16) / 3).ToString();
            herren64.Text = (oiw.GetArticleAmountByID(16) / 3).ToString();
            herren74.Text = Produktionsplanung.e16H.ToString();

            herren15.Text = Produktionsplanung.e31.ToString();
            herren25.Text = wlw.GetArticleAmountByID(31).ToString();
            herren35.Text = vs.sicherheitsbestandP2.ToString();
            herren45.Text = (w.GetArticleByID(17).Amount / 3).ToString();
            herren55.Text = (wlw.GetArticleAmountByID(17) / 3).ToString();
            herren65.Text = (oiw.GetArticleAmountByID(17) / 3).ToString();
            herren75.Text = Produktionsplanung.e17H.ToString();

            herren16.Text = Produktionsplanung.e31.ToString();
            herren26.Text = wlw.GetArticleAmountByID(31).ToString();
            herren36.Text = vs.sicherheitsbestandP2.ToString();
            herren46.Text = w.GetArticleByID(30).Amount.ToString();
            herren56.Text = wlw.GetArticleAmountByID(30).ToString();
            herren66.Text = oiw.GetArticleAmountByID(30).ToString();
            herren76.Text = Produktionsplanung.e30.ToString();

            herren17.Text = Produktionsplanung.e30.ToString();
            herren27.Text = wlw.GetArticleAmountByID(30).ToString();
            herren37.Text = vs.sicherheitsbestandP2.ToString();
            herren47.Text = w.GetArticleByID(6).Amount.ToString();
            herren57.Text = wlw.GetArticleAmountByID(6).ToString();
            herren67.Text = oiw.GetArticleAmountByID(6).ToString();
            herren77.Text = Produktionsplanung.e6.ToString();

            herren18.Text = Produktionsplanung.e30.ToString();
            herren28.Text = wlw.GetArticleAmountByID(30).ToString();
            herren38.Text = vs.sicherheitsbestandP2.ToString();
            herren48.Text = w.GetArticleByID(12).Amount.ToString();
            herren58.Text = wlw.GetArticleAmountByID(12).ToString();
            herren68.Text = oiw.GetArticleAmountByID(12).ToString();
            herren78.Text = Produktionsplanung.e12.ToString();

            herren19.Text = Produktionsplanung.e30.ToString();
            herren29.Text = wlw.GetArticleAmountByID(30).ToString();
            herren39.Text = vs.sicherheitsbestandP2.ToString();
            herren49.Text = w.GetArticleByID(29).Amount.ToString();
            herren59.Text = wlw.GetArticleAmountByID(29).ToString();
            herren69.Text = oiw.GetArticleAmountByID(29).ToString();
            herren79.Text = Produktionsplanung.e29.ToString();

            herren110.Text = Produktionsplanung.e29.ToString();
            herren210.Text = wlw.GetArticleAmountByID(29).ToString();
            herren310.Text = vs.sicherheitsbestandP2.ToString();
            herren410.Text = w.GetArticleByID(9).Amount.ToString();
            herren510.Text = wlw.GetArticleAmountByID(9).ToString();
            herren610.Text = oiw.GetArticleAmountByID(9).ToString();
            herren710.Text = Produktionsplanung.e9.ToString();

            herren111.Text = Produktionsplanung.e29.ToString();
            herren211.Text = wlw.GetArticleAmountByID(29).ToString();
            herren311.Text = vs.sicherheitsbestandP2.ToString();
            herren411.Text = w.GetArticleByID(15).Amount.ToString();
            herren511.Text = wlw.GetArticleAmountByID(15).ToString();
            herren611.Text = oiw.GetArticleAmountByID(15).ToString();
            herren711.Text = Produktionsplanung.e15.ToString();

            herren112.Text = Produktionsplanung.e29.ToString();
            herren212.Text = wlw.GetArticleAmountByID(29).ToString();
            herren312.Text = vs.sicherheitsbestandP2.ToString();
            herren412.Text = w.GetArticleByID(20).Amount.ToString();
            herren512.Text = wlw.GetArticleAmountByID(20).ToString();
            herren612.Text = oiw.GetArticleAmountByID(20).ToString();
            herren712.Text = Produktionsplanung.e20.ToString();

        }

        private void UpdateKapaFields()
        {
            UpdateKapaFieldsEach(0, (ObservableCollection<ItemNo>)dataGrid1.ItemsSource, (ObservableCollection<KapNo>)dataGrid16.ItemsSource);
            UpdateKapaFieldsEach(1, (ObservableCollection<ItemNo>)dataGrid2.ItemsSource, (ObservableCollection<KapNo>)dataGrid17.ItemsSource);
            UpdateKapaFieldsEach(2, (ObservableCollection<ItemNo>)dataGrid3.ItemsSource, (ObservableCollection<KapNo>)dataGrid18.ItemsSource);
            UpdateKapaFieldsEach(3, (ObservableCollection<ItemNo>)dataGrid4.ItemsSource, (ObservableCollection<KapNo>)dataGrid19.ItemsSource);
            UpdateKapaFieldsEach(4, (ObservableCollection<ItemNo>)dataGrid6.ItemsSource, (ObservableCollection<KapNo>)dataGrid20.ItemsSource);
            UpdateKapaFieldsEach(5, (ObservableCollection<ItemNo>)dataGrid7.ItemsSource, (ObservableCollection<KapNo>)dataGrid21.ItemsSource);
            UpdateKapaFieldsEach(6, (ObservableCollection<ItemNo>)dataGrid8.ItemsSource, (ObservableCollection<KapNo>)dataGrid22.ItemsSource);
            UpdateKapaFieldsEach(7, (ObservableCollection<ItemNo>)dataGrid9.ItemsSource, (ObservableCollection<KapNo>)dataGrid23.ItemsSource);
            UpdateKapaFieldsEach(8, (ObservableCollection<ItemNo>)dataGrid10.ItemsSource, (ObservableCollection<KapNo>)dataGrid24.ItemsSource);
            UpdateKapaFieldsEach(9, (ObservableCollection<ItemNo>)dataGrid11.ItemsSource, (ObservableCollection<KapNo>)dataGrid25.ItemsSource);
            UpdateKapaFieldsEach(10, (ObservableCollection<ItemNo>)dataGrid12.ItemsSource, (ObservableCollection<KapNo>)dataGrid26.ItemsSource);
            UpdateKapaFieldsEach(11, (ObservableCollection<ItemNo>)dataGrid13.ItemsSource, (ObservableCollection<KapNo>)dataGrid27.ItemsSource);
            UpdateKapaFieldsEach(12, (ObservableCollection<ItemNo>)dataGrid14.ItemsSource, (ObservableCollection<KapNo>)dataGrid28.ItemsSource);
            UpdateKapaFieldsEach(13, (ObservableCollection<ItemNo>)dataGrid15.ItemsSource, (ObservableCollection<KapNo>)dataGrid29.ItemsSource);
        }

        private void UpdateKapaFieldsEach(int id, ObservableCollection<ItemNo> ArbeitsPlatz, ObservableCollection<KapNo> ArbeitsPlatzOverview)
        {
            foreach (ItemNo platz in ArbeitsPlatz)
            {
                int SachNr = System.Convert.ToInt32(Regex.Replace(platz.Sachnr, "[^0-9]+", string.Empty));
                platz.Gesamtaufwand = Kapazitaetsplanung.Class.arbeitsplatzListe[id].fertigungsListe.Find(x => x.artikelID == SachNr).kapabedarfProTeil.ToString();
                platz.Menge = Produktionsplanung.getBedarfByID(SachNr).ToString();
            }
            for (int i = 0; i < ArbeitsPlatzOverview.Count; i++)
            {
                ArbeitsPlatzOverview[i].Berechnungwork = Kapazitaetsplanung.Class.arbeitsplatzListe[id].getFieldsByID(i).ToString();
            }
        }

        private void UpdateEinkauf()
        {
            var fields = (ObservableCollection<Einkauf>)dataGrid31.ItemsSource;
            fields.Clear();
            foreach (var item in Orderlist.Class.Liste)
            {
                fields.Add(new Einkauf(item.Article.ToString(), item.Quantity.ToString(), item.Modus.ToString()));
            }
            /*
            dataGrid31.Columns[0].IsReadOnly = true;
            dataGrid31.Columns[0].Header = TranslateService.Class.GetTranslation("ITEM_NO");*/
        }

        private void UpdatePrioFields()
        {
            var fields = (ObservableCollection<Prio>)prio.ItemsSource;
            fields.Clear();
            int i = 0;
            foreach (var product in Productionlist.Class.List)
            {
                fields.Add(new Prio(i.ToString(), product.article.ToString(), product.quantity.ToString()));
                i++;
            }

        }

        private void UpdateLager()
        {
            Warehousestock w = Warehousestock.Class;

            var fields = (ObservableCollection<Lagerbestand>)dataGrid32.ItemsSource;
            fields.Clear();
            foreach (var item in Warehousestock.Class.Liste)
            {
                fields.Add(new Lagerbestand(item.ID.ToString(), item.Amount.ToString(), item.Startamount.ToString(), item.Pct.ToString(), item.Price.ToString(), item.Stockvalue.ToString()));
            }
            /*
            dataGrid31.Columns[0].IsReadOnly = true;
            dataGrid31.Columns[0].Header = TranslateService.Class.GetTranslation("ITEM_NO");*/
        }

        private bool AllFilled()
        {
            if (period0product1.Text == "" || period0product2.Text == "" || period0product3.Text == "" || period1product1.Text == "" || period1product2.Text == "" || period1product3.Text == "" || period2product1.Text == "" || period2product2.Text == "" || period2product3.Text == "")
            {
                return false;
            }
            return true;
        }

        private void PrognosenNextbutton_Click(object sender, RoutedEventArgs e)
        {

            Int32 maxValue = 1050;
            try
            {
                if (Convert.ToInt32(period0sum.Text) > maxValue || Convert.ToInt32(period1sum.Text) > maxValue || Convert.ToInt32(period2sum.Text) > maxValue || Convert.ToInt32(period3sum.Text) > maxValue)
                {
                    MessageBox.Show(TranslateService.Class.GetTranslation("SUM_TOO_BIG"));
                    return;
                }

                if (Convert.ToInt32(period0product1.Text) % 10 != 0 || Convert.ToInt32(period0product2.Text) % 10 != 0 || Convert.ToInt32(period0product3.Text) % 10 != 0 || Convert.ToInt32(period1product1.Text) % 10 != 0 || Convert.ToInt32(period1product2.Text) % 10 != 0 || Convert.ToInt32(period1product3.Text) % 10 != 0 || Convert.ToInt32(period2product1.Text) % 10 != 0 || Convert.ToInt32(period2product2.Text) % 10 != 0 || Convert.ToInt32(period2product3.Text) % 10 != 0 || Convert.ToInt32(period3product1.Text) % 10 != 0 || Convert.ToInt32(period3product2.Text) % 10 != 0 || Convert.ToInt32(period3product3.Text) % 10 != 0)
                {
                    MessageBox.Show(TranslateService.Class.GetTranslation("INPUTMOD10"));
                    return;
                }
            }
            catch
            {

            }

            if (AllFilled())
            {
                try
                {
                    Forecast.Class.AddForecast(0, new Forecast.ForecastPeriod(Convert.ToInt32(period0product1.Text), Convert.ToInt32(period0product2.Text), Convert.ToInt32(period0product3.Text)));
                    Forecast.Class.AddForecast(1, new Forecast.ForecastPeriod(Convert.ToInt32(period1product1.Text), Convert.ToInt32(period1product2.Text), Convert.ToInt32(period1product3.Text)));
                    Forecast.Class.AddForecast(2, new Forecast.ForecastPeriod(Convert.ToInt32(period2product1.Text), Convert.ToInt32(period2product2.Text), Convert.ToInt32(period2product3.Text)));
                    Forecast.Class.AddForecast(3, new Forecast.ForecastPeriod(Convert.ToInt32(period3product1.Text), Convert.ToInt32(period3product2.Text), Convert.ToInt32(period3product3.Text)));


                    ValueStore vs = ValueStore.Instance;
                    vs.vertriebswunschP1 = Forecast.Class.GetPeriod(0).Product1;
                    vs.vertriebswunschP2 = Forecast.Class.GetPeriod(0).Product2;
                    vs.vertriebswunschP3 = Forecast.Class.GetPeriod(0).Product3;

                    vs.prognose1P1 = Forecast.Class.GetPeriod(1).Product1;
                    vs.prognose1P2 = Forecast.Class.GetPeriod(1).Product2;
                    vs.prognose1P3 = Forecast.Class.GetPeriod(1).Product3;

                    vs.prognose2P1 = Forecast.Class.GetPeriod(2).Product1;
                    vs.prognose2P2 = Forecast.Class.GetPeriod(2).Product2;
                    vs.prognose2P3 = Forecast.Class.GetPeriod(2).Product3;

                    vs.prognose3P1 = Forecast.Class.GetPeriod(3).Product1;
                    vs.prognose3P2 = Forecast.Class.GetPeriod(3).Product2;
                    vs.prognose3P3 = Forecast.Class.GetPeriod(3).Product3;

                    Ui.EnableNextTab(Direktverkauftab, MainTabControl);


                }
                catch (FormatException)
                {
                    MessageBox.Show(TranslateService.Class.GetTranslation("ONLY_INT_ERROR"));
                }
            }

            else
            {
                MessageBox.Show(TranslateService.Class.GetTranslation("INPUT_NOT_COMPLETE"));
                return;
            }

        }

        private void DirectNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(s41.Text) > 1050 || (Convert.ToInt32(period0sum.Text) + Convert.ToInt32(s41.Text)) > 1050)
            {
                MessageBox.Show(TranslateService.Class.GetTranslation("SUM_TOO_BIG"));
                return;
            }
            Ui.EnableNextTab(sicherheitsbestandtab, MainTabControl);
        }

        public void checkMalformedXML()
        {

            if (String.IsNullOrEmpty(Pathtextbox.Text))
            {
                MessageBox.Show(TranslateService.Class.GetTranslation("XML_ERROR"));
                return;
            }
            ReadXML readxml = new ReadXML();
            bool wellformed = readxml.ReadFile(Pathtextbox.Text);
            if (!wellformed)
            {
                MessageBox.Show(TranslateService.Class.GetTranslation("XML_MALFORMED"));
                return;
            }
            Ui.EnableNextTab(Prognosentab, MainTabControl);
        }

        private void MainpageNextButton_Click(object sender, RoutedEventArgs e)
        {
            checkMalformedXML();
            exportpath = Pathtextbox.Text.Substring(0, Pathtextbox.Text.LastIndexOf(@"\"));
        }


        private void Forecast1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Int32 directsum1 = 0;

                if (d11 != null)
                    directsum1 += Convert.ToInt32(d11.Text);
                if (d21 != null)
                    directsum1 += Convert.ToInt32(d21.Text);
                if (d31 != null)
                    directsum1 += Convert.ToInt32(d31.Text);

                if (s41 != null)
                    s41.Text = directsum1.ToString();
            }
            catch
            {

            }
        }

        private void UpdateSummeFromForcast(object sender, TextChangedEventArgs e)
        {
            try
            {
                int p0sum = 0;
                int p1sum = 0;
                int p2sum = 0;
                int p3sum = 0;
                if (period0product1 != null)
                    p0sum += Convert.ToInt32(period0product1.Text);
                if (period0product2 != null)
                    p0sum += Convert.ToInt32(period0product2.Text);
                if (period0product3 != null)
                    p0sum += Convert.ToInt32(period0product3.Text);

                if (period1product1 != null)
                    p1sum += Convert.ToInt32(period1product1.Text);
                if (period1product2 != null)
                    p1sum += Convert.ToInt32(period1product2.Text);
                if (period1product3 != null)
                    p1sum += Convert.ToInt32(period1product3.Text);

                if (period2product1 != null)
                    p2sum += Convert.ToInt32(period2product1.Text);
                if (period2product2 != null)
                    p2sum += Convert.ToInt32(period2product2.Text);
                if (period2product3 != null)
                    p2sum += Convert.ToInt32(period2product3.Text);

                if (period3product1 != null)
                    p3sum += Convert.ToInt32(period3product1.Text);
                if (period3product2 != null)
                    p3sum += Convert.ToInt32(period3product2.Text);
                if (period3product3 != null)
                    p3sum += Convert.ToInt32(period3product3.Text);

                if (period0sum != null)
                    period0sum.Text = p0sum.ToString();

                if (period1sum != null)
                    period1sum.Text = p1sum.ToString();

                if (period2sum != null)
                    period2sum.Text = p2sum.ToString();

                if (period3sum != null)
                    period3sum.Text = p3sum.ToString();
            }
            catch { }
        }



        private void NumberDoubleValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NumberIntValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }



        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Prognosentab.IsSelected)
            {
                try
                {
                    prognosevarperiod1.Content = Static.Static.lastperiod + 1;
                    prognosevarperiod2.Content = Static.Static.lastperiod + 2;
                    prognosevarperiod3.Content = Static.Static.lastperiod + 3;
                    prognosevarperiod4.Content = Static.Static.lastperiod + 4;
                }
                catch
                {
                    MessageBox.Show(TranslateService.Class.GetTranslation("ERROR"));
                    return;
                }

            }

            if (sicherheitsbestandtab.IsSelected)
            {
                try
                {
                    sicherheitsvarperiod1.Content = Static.Static.lastperiod + 1;
                    sicherheitsvarperiod2.Content = Static.Static.lastperiod + 2;
                    sicherheitsvarperiod3.Content = Static.Static.lastperiod + 3;
                    sicherheitsvarperiod4.Content = Static.Static.lastperiod + 4;
                }
                catch
                {
                    MessageBox.Show(TranslateService.Class.GetTranslation("ERROR"));
                    return;
                }
            }

            if (Direktverkauftab.IsSelected)
            {
                try
                {
                    directvarperiod1.Content = Static.Static.lastperiod + 1;
                }
                catch
                {
                    MessageBox.Show(TranslateService.Class.GetTranslation("ERROR"));
                    return;
                }
            }
        }

        private void Forecast_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Int32 forecastsum1 = 0;
                Int32 forecastsum2 = 0;
                Int32 forecastsum3 = 0;
                Int32 forecastsum4 = 0;

                if (forecastsy1p1 != null)
                    forecastsum1 += Convert.ToInt32(forecastsy1p1.Text);
                if (forecastsy1p2 != null)
                    forecastsum1 += Convert.ToInt32(forecastsy1p2.Text);
                if (forecastsy1p3 != null)
                    forecastsum1 += Convert.ToInt32(forecastsy1p3.Text);

                if (forecastsy2p1 != null)
                    forecastsum2 += Convert.ToInt32(forecastsy2p1.Text);
                if (forecastsy2p2 != null)
                    forecastsum2 += Convert.ToInt32(forecastsy2p2.Text);
                if (forecastsy2p3 != null)
                    forecastsum2 += Convert.ToInt32(forecastsy2p3.Text);

                if (forecastsy3p1 != null)
                    forecastsum3 += Convert.ToInt32(forecastsy3p1.Text);
                if (forecastsy3p2 != null)
                    forecastsum3 += Convert.ToInt32(forecastsy3p2.Text);
                if (forecastsy3p3 != null)
                    forecastsum3 += Convert.ToInt32(forecastsy3p3.Text);

                if (forecastsy4p1 != null)
                    forecastsum4 += Convert.ToInt32(forecastsy4p1.Text);
                if (forecastsy4p2 != null)
                    forecastsum4 += Convert.ToInt32(forecastsy4p2.Text);
                if (forecastsy4p3 != null)
                    forecastsum4 += Convert.ToInt32(forecastsy4p3.Text);


                if (sumy1 != null)
                    sumy1.Text = forecastsum1.ToString();

                if (sumy2 != null)
                    sumy2.Text = forecastsum2.ToString();

                if (sumy3 != null)
                    sumy3.Text = forecastsum3.ToString();

                if (sumy4 != null)
                    sumy4.Text = forecastsum4.ToString();

            }
            catch
            {

            }
        }

        private void customexportpathtextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            xmlexportbutton.IsEnabled = true;
            if(customexportpathtextbox.Text == "")
            {
                xmlexportbutton.IsEnabled = false;
            }
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                CreateXML createXml = new CreateXML();
                string xmlfile = createXml.GenerateXMLData();
                
                if(found == true)
                {
                    StreamWriter sw = new StreamWriter(exportpath + "\\XMLOutput.xml");
                    sw.Write(xmlfile);
                    MessageBox.Show(TranslateService.Class.GetTranslation("XMLEXPORT_SUCCESS"));
                    sw.Close();
                    Process.Start(exportpath);

                }
               
                if(found == false && customexportpathtextbox.Text == "")
                {

                    MessageBox.Show(TranslateService.Class.GetTranslation("EMPTY_EXPORT_PATH"));
                    return;
                }

                if(found == false)
                {
                    exportpath = customexportpathtextbox.Text;
                    StreamWriter sw = new StreamWriter(exportpath + "\\XMLOutput.xml");
                    sw.Write(xmlfile);
                    MessageBox.Show(TranslateService.Class.GetTranslation("XMLEXPORT_SUCCESS"));
                    sw.Close();
                    Process.Start(exportpath);
                }
                
               

            }

            catch (Exception ex)
            {
                MessageBox.Show(TranslateService.Class.GetTranslation("XMLEXPORT_NO_SUCCESS"));
                return;
            }
        }

        private void UpdateEinkaufXML(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                try
                {
                    var field = Convert.ToInt32(Regex.Replace(((TextBox)e.EditingElement).Text, "[^0-9]+", string.Empty));
                    var row = (Einkauf)e.Row.Item;
                    var colum = (string)e.Column.Header;
                    var item = Orderlist.Class.GetOrdersByArticle(Convert.ToInt32(Regex.Replace(row.Teileno, "[^0-9]+", string.Empty))).Find(x => x.Modus == Convert.ToInt32(Regex.Replace(row.Art, "[^0-9]+", string.Empty)) && x.Quantity == Convert.ToInt32(Regex.Replace(row.Anzahl, "[^0-9]+", string.Empty)));
                    if (colum == TranslateService.Class.GetTranslation("MODE"))
                        item.Modus = field;
                    else if (colum == TranslateService.Class.GetTranslation("QUANTITY"))
                        item.Quantity = field;
                    else
                    {
                        if (colum == "Art")
                            item.Modus = field;
                        else if (colum == "Anzahl") 
                            item.Quantity = field;
                        else { throw new Exception(); }
                    }

                }
                catch { e.Cancel = true; }
            }
        }

        private void up_Click(object sender, RoutedEventArgs e)
        {
            var grid = (ObservableCollection<Prio>)prio.ItemsSource;
            var a = (Prio)prio.SelectedItem;
            if (a != null)
            {
                var position = Convert.ToInt32(a.Position);
                if (position > 0)
                {
                    Productionlist.Class.moveItemToSpecialIndex(position - 1, position);
                    grid.Clear();
                    UpdatePrioFields();
                }
            }
        }

        private void down_Click(object sender, RoutedEventArgs e)
        {
            var grid = (ObservableCollection<Prio>)prio.ItemsSource;
            var a = (Prio)prio.SelectedItem;
            if (a != null)
            {
                var position = Convert.ToInt32(a.Position);
                if (position + 1 < Productionlist.Class.List.Count)
                {
                    Productionlist.Class.moveItemToSpecialIndex(position + 2, position);
                    grid.Clear();
                    UpdatePrioFields();
                }
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var grid = (ObservableCollection<Prio>)prio.ItemsSource;
            var a = (Prio)prio.SelectedItem;
            if (a != null)
            {
                var position = Convert.ToInt32(a.Position);
                Productionlist.Class.List.RemoveAt(position);
                grid.Clear();
                UpdatePrioFields();
            }
        }

        private void split_Click(object sender, RoutedEventArgs e)
        {
            var grid = (ObservableCollection<Prio>)prio.ItemsSource;
            var a = (Prio)prio.SelectedItem;
            if (a != null)
            {
                var position = Convert.ToInt32(a.Position);
                int quantity1 = Productionlist.Class.List[position].quantity / 2;
                int quantity2 = 0;
                if ((quantity1) % 10 == 0)
                {
                    quantity2 = quantity1;
                }
                else
                {

                    quantity1 = (int)Math.Ceiling((double)Productionlist.Class.List[position].quantity / 20) * 10;
                    quantity2 = (int)Math.Floor((double)Productionlist.Class.List[position].quantity / 20) * 10;

                    if (quantity2 == 0)
                        return;
                }
                Productionlist.Class.List[position].quantity = quantity1;
                Productionlist.Class.AddItem(new ProductionlistItem(Productionlist.Class.List[position].article, quantity2));
                Productionlist.Class.moveItemToSpecialIndex(position + 1, Productionlist.Class.List.Count - 1);
                grid.Clear();
                UpdatePrioFields();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            int artikel = 0;
            int menge = 0;
            try
            {
                artikel = System.Convert.ToInt32(prioAddItem.Text);
                menge = System.Convert.ToInt32(prioAddAmount.Text);

                if (artikel < 1 || artikel > 59 || menge < 10 || menge % 10 != 0)
                {
                    throw new ArgumentException();
                }
            } catch { MessageBox.Show(TranslateService.Class.GetTranslation("INTANDMOD10"), "Error", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            Productionlist.Class.AddItem(new ProductionlistItem(artikel, menge));

            var grid = (ObservableCollection<Prio>)prio.ItemsSource;
            grid.Clear();
            UpdatePrioFields();
            prioAddAmount.Text = "";
            prioAddItem.Text = "";
        }

        private void openFinderButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

public class Liefer : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private string lieferfrist;
    private string abweichung;
    public string kaufteileno;
    public string kaufteil;
    public string bestellkosten;
    public string diskontmenge;
    public string teilewert;
    public string verwendung;

    
    public string Kaufteileno
    {
        get { return kaufteileno; }
        set
        {
            kaufteileno = value; OnPropertyChanged(new PropertyChangedEventArgs("KaufteileNo"));
        }
    }

    public string Kaufteil
    {
        get { return kaufteil; }
        set
        {
            kaufteil = value; OnPropertyChanged(new PropertyChangedEventArgs("Kaufteils"));
        }
    }
    public string Verwendung
    {
        get { return verwendung; }
        set
        {
            verwendung = value; OnPropertyChanged(new PropertyChangedEventArgs("Verwendung"));
        }
    }

    public string Bestellkosten
    {
        get { return bestellkosten; }
        set
        {
            bestellkosten = value; OnPropertyChanged(new PropertyChangedEventArgs("Bestellkosten"));
        }
    }
    public string Diskontmenge
    {
        get { return diskontmenge; }
        set
        {
            diskontmenge = value; OnPropertyChanged(new PropertyChangedEventArgs("Diskontmenge"));
        }
    }
    public string Teilewert
    {
        get { return teilewert; }
        set
        {
            teilewert = value; OnPropertyChanged(new PropertyChangedEventArgs("Teilewert"));
        }
    }

    public string Lieferfrist
    {
        get { return lieferfrist; }
        set
        {
            lieferfrist = value; OnPropertyChanged(new PropertyChangedEventArgs("Lieferfrist"));
        }
    }
    public string Abweichung
    {
        get { return abweichung; }
        set
        {
            abweichung = value; OnPropertyChanged(new PropertyChangedEventArgs("Abweichung"));
        }
    }
    protected void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (PropertyChanged != null)
        { PropertyChanged(this, e); }
    }
}

public class Lagerbestand : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private string artikel;
    private string menge;
    private string startmenge;
    private string menge_startmenge;
    private string preis;
    private string lagerwert;

    public Lagerbestand(string artikel, string menge, string startmenge, string menge_startmenge, string preis, string lagerwert)
    {
        this.Artikel = artikel;
        this.Menge = menge;
        this.Startmenge = startmenge;
        this.Menge_startmenge = menge_startmenge;
        this.Preis = preis;
        this.Lagerwert = lagerwert;
    }


    public string Artikel
    {
        get { return artikel; }
        set
        {
            artikel = value; OnPropertyChanged(new PropertyChangedEventArgs("Artikel"));
        }
    }

    public string Menge
    {
        get { return menge; }
        set
        {
            menge = value; OnPropertyChanged(new PropertyChangedEventArgs("Menge"));
        }
    }
    public string Startmenge
    {
        get { return startmenge; }
        set
        {
            startmenge = value; OnPropertyChanged(new PropertyChangedEventArgs("Startmenge"));
        }
    }

    public string Menge_startmenge
    {
        get { return menge_startmenge; }
        set
        {
            menge_startmenge = value; OnPropertyChanged(new PropertyChangedEventArgs("Menge Startmenge in Prozent"));
        }
    }
    public string Preis
    {
        get { return preis; }
        set
        {
            preis = value; OnPropertyChanged(new PropertyChangedEventArgs("Preis"));
        }
    }
    public string Lagerwert
    {
        get { return lagerwert; }
        set
        {
            lagerwert = value; OnPropertyChanged(new PropertyChangedEventArgs("Lagerwert"));
        }
    }
    
    protected void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (PropertyChanged != null)
        { PropertyChanged(this, e); }
    }
}


public class KapNo : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private string kapaplanwork;
    private string berechnungwork;

    public string Kapaplanwork
    {
        get { return kapaplanwork; }
        set
        {
            kapaplanwork = value; OnPropertyChanged(new PropertyChangedEventArgs("Kapaplanwork"));
        }
    }
    public string Berechnungwork
    {
        get { return berechnungwork; }
        set
        {
            berechnungwork = value; OnPropertyChanged(new PropertyChangedEventArgs("Berechnungwork"));
        }
    }
    protected void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (PropertyChanged != null)
        { PropertyChanged(this, e); }
    }
}


public class ItemNo : INotifyPropertyChanged
{
    // Ereignis
    public event PropertyChangedEventHandler PropertyChanged;
    // Eigenschaften

    private string bezeichnung;
    private string fahrradtyp;
    private string sachnr;
    private string menge;
    private string einzelaufwand;
    private string gesamtaufwand;

    public string Bezeichnung
    {
        get { return bezeichnung; }
        set
        {
            bezeichnung = value; OnPropertyChanged(new PropertyChangedEventArgs("Bezeichnung"));
        }
    }
    public string Fahrradtyp
    {
        get { return fahrradtyp; }
        set
        {
            fahrradtyp = value; OnPropertyChanged(new PropertyChangedEventArgs("Fahrradtyp"));
        }
    }
    public string Sachnr
    {
        get { return sachnr; }
        set
        {
            sachnr = value; OnPropertyChanged(new PropertyChangedEventArgs("Sach-Nr"));
        }
    }
    public string Menge
    {
        get { return menge; }
        set
        {
            menge = value; OnPropertyChanged(new PropertyChangedEventArgs("Menge"));
        }
    }
    public string Einzelaufwand
    {
        get { return einzelaufwand; }
        set
        {
            einzelaufwand = value; OnPropertyChanged(new PropertyChangedEventArgs("Einzelaufwand"));
        }
    }
    public string Gesamtaufwand
    {
        get { return gesamtaufwand; }
        set
        {
            gesamtaufwand = value; OnPropertyChanged(new PropertyChangedEventArgs("Gesamtaufwand"));
        }
    }
    protected void OnPropertyChanged(PropertyChangedEventArgs e)
{
        if (PropertyChanged != null)
        { PropertyChanged(this, e); }
    }
}
public class Einkauf : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private string teileno;
    private string anzahl;
    private string art;

    public Einkauf(string teileno, string anzahl, string art)
    {
        this.Teileno = teileno;
        this.Anzahl = anzahl;
        this.Art = art;
    }

    public string Teileno
    {
        get { return teileno; }
        set
        {
            teileno = value; OnPropertyChanged(new PropertyChangedEventArgs("TeileNo"));
        }
    }
    public string Anzahl
    {
        get { return anzahl; }
        set
        {
            anzahl = value; OnPropertyChanged(new PropertyChangedEventArgs("Anzahl"));
        }
    }
    public string Art
    {
        get { return art; }
        set
        {
            if (Convert.ToInt32(value) == 5)
                art = TranslateService.Class.GetTranslation("NORMAL") + " (" + value + ")";
            else if (Convert.ToInt32(value) == 4)
                art = TranslateService.Class.GetTranslation("EIL") + " (" + value + ")";
            OnPropertyChanged(new PropertyChangedEventArgs("Art"));
        }
    }
    protected void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (PropertyChanged != null)
        { PropertyChanged(this, e); }
    }
}

public class Prio : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private string position;
    private string teilenr;
    private string anzahl;


    public Prio (string id, string teilenr, string anzahl)
    {
        this.Position = id;
        this.Teilenr = teilenr;
        this.Anzahl = anzahl;
    }

    public string Position {
        get { return position; }
        set {
            position = value;
            OnPropertyChanged(new PropertyChangedEventArgs("ID"));
        }
    }

    public string Teilenr {
        get { return teilenr; }
        set {
            teilenr = value; OnPropertyChanged(new PropertyChangedEventArgs("Teilenr"));
        }
    }
    public string Anzahl {
        get { return anzahl; }
        set {
            anzahl = value; OnPropertyChanged(new PropertyChangedEventArgs("Anzahl"));
        }
    }

    protected void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (PropertyChanged != null)
        { PropertyChanged(this, e); }
    }
}