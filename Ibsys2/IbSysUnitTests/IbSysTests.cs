using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ibsys2.Static;
using Ibsys2.Static.Output;
using Ibsys2.Pages;
using Ibsys2.Pages.ReadXML;
using Ibsys2.Pages.CreateXML;
using Ibsys2.Berechnungen.Datenstrukturen;

namespace IbSysUnitTests
{
    [TestClass]
    public class IbSysTests
    {
        [TestMethod]
        public void sellWishSetAnzahl()
        {

            Sellwish.Class.setAnzahlArtikel(1 ,2);
            Sellwish.Class.setAnzahlArtikel(2, 2);
            Sellwish.Class.setAnzahlArtikel(3, 2);

        }


        [TestMethod]      
        public void getQuantityForItem()
        {
            Ibsys2.Static.Output.Productionlist.Class.getQuantitysForArticle(1);
            Ibsys2.Static.Output.Productionlist.Class.getQuantitysForArticle(2);
            Ibsys2.Static.Output.Productionlist.Class.getQuantitysForArticle(3);
        }

        [TestMethod]
        public void orderlistAddItem()
        {
            OrderlistItem item1 = new OrderlistItem(1, 2, 1);
            OrderlistItem item2 = new OrderlistItem(2, 2, 1);
            OrderlistItem item3 = new OrderlistItem(3, 2, 1);

            Orderlist.Class.AddItem(item1);
            Orderlist.Class.AddItem(item2);
            Orderlist.Class.AddItem(item3);


        }


        [TestMethod]
        public void getOrderForItemOrderList()
        {
            Orderlist.Class.getOrdersByArticle(1);
            Orderlist.Class.getOrdersByArticle(2);
            Orderlist.Class.getOrdersByArticle(3);
        }


       
         [TestMethod]
        public void workTimeListAddItem()
        {
            WorkingtimelistItem item1 = new WorkingtimelistItem(1, 2, 3);
            WorkingtimelistItem item2 = new WorkingtimelistItem(2, 2, 3);
            WorkingtimelistItem item3 = new WorkingtimelistItem(10,1, 3);
            Workingtimelist.Class.AddItem(item1);
            Workingtimelist.Class.AddItem(item2);
            Workingtimelist.Class.AddItem(item3);
        }


        [TestMethod]
        public void sellDirectsetAnzahlArtikel()
        {
            Selldirect.Class.setAnzahlArtikel(1, 2, 3, 4);
            Selldirect.Class.setAnzahlArtikel(2, 2, 3, 4);
            Selldirect.Class.setAnzahlArtikel(3, 2, 3, 4);
        }

        [TestMethod]
        public void ArticleDataStruct()
        {
            Article article = new Article(1,1,1,2.2,2.1,2.0);
           
        }

    }
}
