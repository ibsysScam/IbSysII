using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Output {
    public static class Productionlist {
        //<productionlist><production article="[1-99]" quantity="[0-999999]"/></productionlist>
        private static List<ProductionlistItem> _list = new List<ProductionlistItem>();

        public static void AddItem(ProductionlistItem item) {
            if (item == null)
                throw new Exception();
            _list.Add(item);
        }

        public static List<ProductionlistItem> getQuantityForArticle(int article) {
            return _list.FindAll(x => x.article == article);
        }

        public static string XMLOutput() {
            string Output = "<productionlist>";
            foreach (var pil in _list)
                Output += pil.XMLOutput();
            return Output + "</productionlist>";
        }
    }

    public class ProductionlistItem {
        private int _article;
        private int _quantity;

        public int article {
            get { return _article; }
            set {
                if (value < 0 || value > 100)
                    throw new Exception();
                _article = value;
            }
        }

        public int quantity {
            get { return _quantity; }
            set {
                if (value < 0 || value > 1000000)
                    throw new Exception();
                _quantity = value;
            }
        }

        public ProductionlistItem(int article, int quantity) {
            this.article = article;
            this.quantity = quantity;
        }

        public string XMLOutput() {
            return @"<production article=""" + _article + @""" quantity=""" + _quantity + @"""/>";
        }
    }
}
