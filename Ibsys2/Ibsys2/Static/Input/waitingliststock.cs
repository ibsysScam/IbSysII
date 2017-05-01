using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Input {
    public class Waitingliststock : IEnumerable<Waitingliststock.Missingpart> {
        private static Waitingliststock _class;
        private List<Missingpart> _list;

        public static Waitingliststock Class {
            get {
                if (_class == null)
                    new Waitingliststock();
                return _class;
            }
        }

        public Waitingliststock() {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            this._list = new List<Missingpart>();
        }

        public void Add(Missingpart m) {
            if (m == null)
                throw new ArgumentNullException();
            _list.RemoveAll(x => x.ID == m.ID);
            _list.Add(m);
        }

        public Missingpart GetMissingpartByID(int id) {
            return _list.Find(x => x.ID == id);
        }

        public void ClearClass() {
            _class = null;
            _list = null;
        }

        public IEnumerator<Missingpart> GetEnumerator() {
            return ((IEnumerable<Missingpart>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<Missingpart>)_list).GetEnumerator();
        }

        public class Missingpart {
            private int _id;

            private List<Waitinglist> _list;

            public Missingpart(int _id) {
                _list = new List<Waitinglist>();
                this._id = _id;
            }

            public void Add(Waitinglist w) {
                if (w == null)
                    throw new ArgumentNullException();
                _list.Add(w);
            }

            public List<Waitinglist> GetAllWaitinglistItem { get { return _list; } }

            public int ID {
                get {
                    return _id;
                }
            }

            public class Waitinglist {
                private int _period;
                private int _order;
                private int _firstbatch;
                private int _lastbatch;
                private int _item;
                private int _amount;

                public Waitinglist(int _period, int _order, int _firstbatch, int _lastbatch, int _item, int _amount) {
                    this.Period = _period;
                    this.Order = _order;
                    this.Firstbatch = _firstbatch;
                    this.Lastbatch = _lastbatch;
                    this.Item = _item;
                    this.Amount = _amount;
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

                public int Order {
                    get {
                        return _order;
                    }

                    set {
                        if (value < 0)
                            throw new ArgumentOutOfRangeException();
                        _order = value;
                    }
                }

                public int Firstbatch {
                    get {
                        return _firstbatch;
                    }

                    set {
                        if (value < 0)
                            throw new ArgumentOutOfRangeException();
                        _firstbatch = value;
                    }
                }

                public int Lastbatch {
                    get {
                        return _lastbatch;
                    }

                    set {
                        if (value < 0)
                            throw new ArgumentOutOfRangeException();
                        _lastbatch = value;
                    }
                }

                public int Item {
                    get {
                        return _item;
                    }

                    set {
                        if (value < 0)
                            throw new ArgumentOutOfRangeException();
                        _item = value;
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
}
