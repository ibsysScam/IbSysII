using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Input {
    class Futureinwardstockmovement {
        private static Futureinwardstockmovement _class;
        private List<Order> _list;

        public static Futureinwardstockmovement Class {
            get {
                if (_class == null)
                    new Futureinwardstockmovement();
                return _class;
            }
        }

        public Futureinwardstockmovement() {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            _list = new List<Order>();
        }

        public void AddOrder(Order o) {
            if (o == null)
                throw new ArgumentNullException();
            _list.Add(o);
        }

        public List<Order> GetOrdersFromPeriod(int i) {
            return _list.FindAll(x => x.Orderperiod == i);
        }

        public List<Order> GetOrdersByID(int i) {
            return _list.FindAll(x => x.ID == i);
        }

        public List<Order> GetOrdersByArticle(int i) {
            return _list.FindAll(x => x.Article == i);
        }

        public void ClearClass() {
            _class = null;
            _list = null;
        }


        public class Order {
            private int _orderperiod;
            private int _id;
            private int _mode;
            private int _article;
            private int _amount;
            

            public Order(int _orderperiod, int _id, int _mode, int _article, int _amount) {
                this.Orderperiod = _orderperiod;
                this.ID = _id;
                this.Article = _article;
                this.Amount = _amount;
            }

            public int Orderperiod {
                get {
                    return _orderperiod;
                }

                set {
                    if (value < 1)
                        throw new ArgumentOutOfRangeException();
                    _orderperiod = value;
                }
            }

            public int ID {
                get {
                    return _id;
                }

                set {
                    if (value < 1)
                        throw new ArgumentOutOfRangeException();
                    _id = value;
                }
            }

            public int Mode {
                get {
                    return _mode;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _mode = value;
                }
            }

            public int Article {
                get {
                    return _article;
                }

                set {
                    if (value < 1)
                        throw new ArgumentOutOfRangeException();
                    _article = value;
                }
            }

            public int Amount {
                get {
                    return _amount;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _amount = value;
                }
            }
        }
    }
}
