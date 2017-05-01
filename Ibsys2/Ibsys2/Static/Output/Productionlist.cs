using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Output {
    public class Productionlist:IEnumerable<ProductionlistItem> {
        //<productionlist><production article="[1-99]" quantity="[0-999999]"/></productionlist>
        private List<ProductionlistItem> _list = new List<ProductionlistItem>();

        private static Productionlist _class;

        public static Productionlist Class {
            get {
                if (_class == null)
                    new Productionlist();
                return _class;
            }
        }

        public Productionlist() {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            this._list = new List<ProductionlistItem>();
        }

        public void AddItem(ProductionlistItem item) {
            if (item == null)
                throw new Exception();
            _list.RemoveAll(x => x.article == item.article);
            _list.Add(item);
        }

        public ProductionlistItem getQuantityForArticle(int article) {
            return _list.Find(x => x.article == article);
        }

        public string XMLOutput() {
            string Output = "<productionlist>";
            foreach (var pil in _list)
                Output += pil.XMLOutput();
            return Output + "</productionlist>";
        }
        public void ClearClass() {
            _class = null;
            _list = null;
        }

        public IEnumerator<ProductionlistItem> GetEnumerator() {
            return ((IEnumerable<ProductionlistItem>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<ProductionlistItem>)_list).GetEnumerator();
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
