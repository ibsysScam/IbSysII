using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Output {
    public class Orderlist {
        //<orderlist><order article = "[1-99]" quantity="[0-999999]" modus="[0-999999]"/></orderlist>
        private List<OrderlistItem> _list = new List<OrderlistItem>();
        private static Orderlist _class;

        public static Orderlist Class {
            get {
                if (_class == null)
                    new Orderlist();
                return _class;
            }
        }

        public Orderlist() {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            this._list = new List<OrderlistItem>();
        }

        public void AddItem(OrderlistItem item) {
            if (item == null)
                throw new Exception();
            _list.Add(item);
        }

        public List<OrderlistItem> getOrdersByArticle(int article) {
            return _list.FindAll(x => x.article == article);
        }

        public string XMLOutput() {
            string Output = "<orderlist>";
            foreach (var ola in _list)
                Output += ola.XMLOutput();
            return Output + "</orderlist>";
        }

        public void ClearClass() {
            _class = null;
            _list = null;
        }
    }


    public class OrderlistItem {
        private int _article;
        private int _quantity;
        private int _modus;

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

        public string XMLOutput() {
            return @"<order article=""" + _article + @""" quantity=""" + _quantity + @""" modus=""" + _modus + @"""/>";
        }
    }
}
