using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Input {
    public class Inwardstockmovement {
        private static Inwardstockmovement _class;
        private List<Order> _list;

        public static Inwardstockmovement Class {
            get {
                if (_class == null)
                    new Inwardstockmovement();
                return _class;
            }
        }

        public Inwardstockmovement() {
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
            private int _time;
            private double _materialcosts;
            private double _ordercosts;
            private double _entirecosts;
            private double _piececosts;

            public Order(int _orderperiod, int _id, int _mode, int _article, int _amount, int _time, double _materialcosts, double _ordercosts, double _entirecosts, double _piececosts) {
                this.Orderperiod = _orderperiod;
                this.ID = _id;
                this.Mode = _mode;
                this.Article = _article;
                this.Amount = _amount;
                this.Time = _time;
                this.Materialcosts = _materialcosts;
                this.Ordercosts = _ordercosts;
                this.Entirecosts = _entirecosts;
                this.Piececosts = _piececosts;
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
                    if (value < 1)
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

            public int Time {
                get {
                    return _time;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _time = value;
                }
            }

            public double Materialcosts {
                get {
                    return _materialcosts;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _materialcosts = value;
                }
            }

            public double Ordercosts {
                get {
                    return _ordercosts;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _ordercosts = value;
                }
            }

            public double Entirecosts {
                get {
                    return _entirecosts;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _entirecosts = value;
                }
            }

            public double Piececosts {
                get {
                    return _piececosts;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _piececosts = value;
                }
            }
        }
    }
}
