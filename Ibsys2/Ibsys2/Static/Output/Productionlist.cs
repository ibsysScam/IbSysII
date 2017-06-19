using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Output {
    public class Productionlist : INotifyPropertyChanged
    {
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

        public List<ProductionlistItem> List { get { return _list; } }

        public Productionlist() {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            this._list = new List<ProductionlistItem>();
        }

        public void AddItem(ProductionlistItem item) {
            if (item == null)
                throw new Exception();
            if (item.quantity <= 0)
                return;
            _list.Add(item);
        }

        public List<ProductionlistItem> getQuantitysForArticle(int article) {
            return _list.FindAll(x => x.article == article);
        }

        public void moveItemToSpecialIndex(int newIndex, int oldIndex)
        {
            var item = new ProductionlistItem(_list[oldIndex].article, _list[oldIndex].quantity);
            _list[oldIndex] = null;
            _list.Insert(newIndex, item);
            _list.RemoveAll(x => x == null);
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
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
                if (value > 1000000)
                    throw new Exception();
                if (value < 0)
                    _quantity = 0;
                else
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
