using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Input {
    public class Completedorders : IEnumerable<Completedorders.Order> {
        private static Completedorders _class;
        private List<Order> _list;

        public static Completedorders Class {
            get {
                if (_class == null)
                    new Completedorders();
                return _class;
            }
        }

        public Completedorders() {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            this._list = new List<Order>();
        }

        public void AddOrder(Order o) {
            if (o == null)
                throw new ArgumentNullException();
            _list.RemoveAll(x => x.ID == o.ID);
            _list.Add(o);
        }

        public Order GetOrderByID(int id) {
            return _list.Find(x => x.ID == id);
        }

        public List<Order> GetOrdersByItem(int item) {
            return _list.FindAll(x => x.Item == item);
        }

        public List<Order> GetOrdersByPeriod(int period) {
            return _list.FindAll(x => x.Period == period);
        }

        public void ClearClass() {
            _class = null;
            _list = null;
        }

        public IEnumerator<Order> GetEnumerator() {
            return ((IEnumerable<Order>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<Order>)_list).GetEnumerator();
        }

        public class Order:IEnumerable<Order.Batch> {
            private int _period;
            private int _id;
            private int _item;


            private List<Batch> _list;

            public int Period {
                get {
                    return _period;
                }

                set {
                    _period = value;
                }
            }

            public int ID {
                get {
                    return _id;
                }
            }

            public int Item {
                get {
                    return _item;
                }

                set {
                    _item = value;
                }
            }

            public int Quantity {
                get {
                    int summe = 0;
                    foreach (var batch in _list)
                        summe += batch.Amount;
                    return summe;
                }
            }

            public double Cost {
                get {
                    double summe = 0.0;
                    foreach (var batch in _list)
                        summe += batch.Cost;
                    return summe;
                }
            }

            public double Averageunitcosts { get { return (this.Cost / this.Quantity); } }

            public Order(int _period, int _id, int _item) {
                this._list = new List<Batch>();
                this.Period = _period;
                this._id = _id;
                this.Item = _item;
            }

            public void AddBatch(Batch b) {
                if (b == null)
                    throw new ArgumentNullException();
                _list.RemoveAll(x => x.ID == b.ID);
                _list.Add(b);
            }

            public Batch GetBatchById(int id) {
                return _list.Find(x => x.ID == id);
            }

            public IEnumerator<Batch> GetEnumerator() {
                return ((IEnumerable<Batch>)_list).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return ((IEnumerable<Batch>)_list).GetEnumerator();
            }

            public class Batch {
                private int _id;
                private int _amount;
                private int _cycletime;
                private double _cost;

                public Batch(int _id, int _amount, int _cycletime, double _cost) {
                    this._id = _id;
                    this.Amount = _amount;
                    this.Cycletime = _cycletime;
                    this.Cost = _cost;
                }

                public int ID {
                    get {
                        return _id;
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

                public int Cycletime {
                    get {
                        return _cycletime;
                    }

                    set {
                        if (value < 0)
                            throw new ArgumentOutOfRangeException();
                        _cycletime = value;
                    }
                }

                public double Cost {
                    get {
                        return _cost;
                    }

                    set {
                        if (value < 0)
                            throw new ArgumentOutOfRangeException();
                        _cost = value;
                    }
                }
            }
        }
    }
}
