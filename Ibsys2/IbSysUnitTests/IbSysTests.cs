using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ibsys2.Static;
using Ibsys2.Static.Output;
using Ibsys2.Pages;
using Ibsys2.Pages.ReadXML;
using Ibsys2.Pages.CreateXML;

namespace IbSysUnitTests
{
    [TestClass]
    public class IbSysTests
    {
        [TestMethod]
        public void KlickaufDateiUploadXMLCompile()
        {
            ReadXML readXML = new ReadXML();
            readXML.KlickAufDateiUpload();
        }

        public void KlickaufTextUploadXMLCompile()
        {
            ReadXML readXML = new ReadXML();
            readXML.KlickAufTextUpload();
        }

      
        public void TestCreateXML()
        {
            CreateXML createXML = new CreateXML();
            
        }


        [TestMethod]
        public void sellWishSetAnzahl()
        {

            Sellwish.setAnzahlArtikel(1 ,2);
            Sellwish.setAnzahlArtikel(2, 2);
            Sellwish.setAnzahlArtikel(3, 2);

        }


        [TestMethod]      
        public void getQuantityForItem()
        {
            Ibsys2.Static.Output.Productionlist.getQuantityForArticle(1);
            Ibsys2.Static.Output.Productionlist.getQuantityForArticle(2);
            Ibsys2.Static.Output.Productionlist.getQuantityForArticle(3);
        }

        [TestMethod]
        public void orderlistAddItem()
        {
            OrderlistItem item1 = new OrderlistItem(1, 2, 1);
            OrderlistItem item2 = new OrderlistItem(2, 2, 1);
            OrderlistItem item3 = new OrderlistItem(3, 2, 1);

            Orderlist.AddItem(item1);
            Orderlist.AddItem(item2);
            Orderlist.AddItem(item3);


        }


        [TestMethod]
        public void getOrderForItemOrderList()
        {
            Orderlist.getOrderForArticle(1);
            Orderlist.getOrderForArticle(2);
            Orderlist.getOrderForArticle(3);
        }


       
         [TestMethod]
        public void workTimeListAddItem()
        {
            WorkingtimelistItem item1 = new WorkingtimelistItem(1, 2, 3);
            WorkingtimelistItem item2 = new WorkingtimelistItem(2, 2, 3);
            WorkingtimelistItem item3 = new WorkingtimelistItem(10,1, 3);
            Workingtimelist.AddItem(item1);
            Workingtimelist.AddItem(item2);
            Workingtimelist.AddItem(item3);
        }


        [TestMethod]
        public void sellDirectsetAnzahlArtikel()
        {
            Selldirect.setAnzahlArtikel(1, 2, 3, 4);
            Selldirect.setAnzahlArtikel(2, 2, 3, 4);
            Selldirect.setAnzahlArtikel(3, 2, 3, 4);
        }

    }
}
