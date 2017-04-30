using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Input {
    public class Warehousestock:IEnumerable<Warehousestock.Article> {
        private static Warehousestock _class;
        private List<Article> _list;

        public static Warehousestock Class {
            get {
                return _class;
            }
        }

        public double Totalstockvalue {
            get {
                double totalstockvalue = 0.0;
                foreach (Article a in _list)
                    totalstockvalue += a.Stockvalue;
                return totalstockvalue;
            }
        }

        public void AddArticle(Article a) {
            if (a == null)
                throw new ArgumentNullException();
            _list[a.ID] = a;
        }

        public Warehousestock() {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            _list = new List<Article>();
        }

        public Article GetArticleByID(int id) {
            return _list[id];
        }

        public bool CheckTotalstockvalue(double Totalstockvalue) {
            double test = 0.0;
            foreach (Article a in _list)
                test += a.Stockvalue;
            return Totalstockvalue == test;
        }

        public IEnumerator<Article> GetEnumerator() {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        public class Article {
            private int _id;
            private int _amount;
            private int _startamount;
            private double _pct;
            private double _price;
            private double _stockvalue;

            public Article(int _id, int _amount, int _startamount, double _pct, double _price, double _stockvalue) {
                this._id = _id;
                this.Amount = _amount;
                this.Startamount = _startamount;
                this.Pct = _pct;
                this.Price = _price;
                this.Stockvalue = _stockvalue;
            }

            public int ID {
                get { return _id; }
            }

            public int Amount {
                get { return _amount; }
                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _amount = value;
                }
            }

            public int Startamount {
                get { return _startamount; }
                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _startamount = value;
                }
            }

            public double Pct {
                get {
                    return _pct;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _pct = value;
                }
            }

            public double Price {
                get {
                    return _price;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _price = value;
                }
            }

            public double Stockvalue {
                get {
                    return _stockvalue;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _stockvalue = value;
                }
            }
        }
    }
}
