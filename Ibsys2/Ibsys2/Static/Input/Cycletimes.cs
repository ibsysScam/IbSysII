using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Input {
    public class Cycletimes:IEnumerable<Cycletimes.Order> {
        private int _startedorders;
        private int _waitingorders;

        private static Cycletimes _class;
        private List<Order> _list;

        public static Cycletimes Class {
            get {
                if (_class == null)
                    new Cycletimes();
                return _class;
            }
        }


        public Cycletimes(int _startedorders, int _waitingorders) {
            if (_class != null && _startedorders != -1 && _waitingorders != -1)
                throw new Exception("Class already exists!");
            _class = this;
            this._list = new List<Order>();
            this.Startedorders = _startedorders;
            this.Waitingorders = _waitingorders;
        }

        private Cycletimes () {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            this._list = new List<Order>();
            this._startedorders = -1;
            this._waitingorders = -1;
        }

        public void AddOrder(Order o) {
            if (o == null)
                throw new ArgumentOutOfRangeException();
            _list.RemoveAll(x => x.ID == o.ID);
            _list.Add(o);
        }

        public Order GetOrderByID(int id) {
            return _list.Find(x => x.ID == id);
        }

        public List<Order> GetOrdersByPeriod(int period) {
            return _list.FindAll(x => x.Period == period);
        }

        public int Startedorders {
            get {
                return _startedorders;
            }

            set {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                _startedorders = value;
            }
        }

        public int Waitingorders {
            get {
                return _waitingorders;
            }

            set {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                _waitingorders = value;
            }
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

        public class Order {
            private int _id;
            private int _period;
            private string _starttime;
            private string _finishtime;
            private int _cycletimemin;
            private double _cycletimefactor;

            public int ID {
                get {
                    return _id;
                }
            }

            public int Period {
                get {
                    return _period;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _period = value;
                }
            }

            public string Starttime {
                get {
                    return _starttime;
                }

                set {
                    if (String.IsNullOrEmpty(value))
                        throw new ArgumentNullException();
                    _starttime = value;
                }
            }

            public string Finishtime {
                get {
                    return _finishtime;
                }

                set {
                    if (String.IsNullOrEmpty(value))
                        throw new ArgumentNullException();
                    _finishtime = value;
                }
            }

            public int Cycletimemin {
                get {
                    return _cycletimemin;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _cycletimemin = value;
                }
            }

            public double Cycletimefactor {
                get {
                    return _cycletimefactor;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _cycletimefactor = value;
                }
            }

            public Order(int _id, int _period, string _starttime, string _finishtime, int _cycletimemin, double _cycletimefactor) {
                this._id = _id;
                this.Period = _period;
                this.Starttime = _starttime;
                this.Finishtime = _finishtime;
                this.Cycletimemin = _cycletimemin;
                this.Cycletimefactor = _cycletimefactor;
            }
        }
    }
}
