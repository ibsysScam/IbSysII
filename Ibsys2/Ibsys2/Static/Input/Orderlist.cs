using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Input {
    static class Orderlist {
        //<orderlist><order article = "[1-99]" quantity="[0-999999]" modus="[0-999999]"/></orderlist>
        private static List<OrderlistItem> _list = new List<OrderlistItem>();

        public static void AddItem(OrderlistItem item) {
            if (item == null)
                throw new Exception();
            var result = _list.Find(x => x.article == item.article);
            if (result != null)
                throw new Exception();
            _list.Add(item);
        }

        public static OrderlistItem getOrderForArticle(int article) {
            return _list.Find(x => x.article == article);
        }
    }


    class OrderlistItem {
        private int _article;
        private int _quantity;
        private int _modus;

        public int article {
            get { return _article; }
            set {
                if (value < 0 || value > 100 )
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

        public int modus {
            get { return _modus; }
            set {
                if (value < 0 || value > 1000000)
                    throw new Exception();
                _modus = value;
            }
        }

        public OrderlistItem(int article, int quantity, int modus) {
            this.article = article;
            this.quantity = quantity;
            this.modus = modus;
        }
    }
}
