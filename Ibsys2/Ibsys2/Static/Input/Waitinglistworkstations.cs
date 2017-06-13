using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ibsys2.Static.Input.Waitinglistworkstations.Workplace;

namespace Ibsys2.Static.Input {
    public class Waitinglistworkstations:IEnumerable<Waitinglistworkstations.Workplace> {
        private static Waitinglistworkstations _class;
        private List<Workplace> _list;

        public static Waitinglistworkstations Class {
            get {
                if (_class == null)
                    new Waitinglistworkstations();
                return _class;
            }
        }

        public Waitinglistworkstations () {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            _list = new List<Workplace>();
        }

        public void Add(Workplace w) {
            if (w == null)
                throw new ArgumentNullException();
            _list.RemoveAll(x => x.ID == w.ID);
            _list.Add(w);
        }

        public List<Workplace> getAllWorkplaces(){
            return _list;
        }

        public Workplace GetWorkplaceByID(int id) {
            return _list.Find(x => x.ID == id);
        }

        public int GetArticleAmountByID(int id)
        {
            int res = 0;

            foreach(Workplace wp in _list){
                foreach(Waitinglist wl in wp.GetAllWaitinglistItem)
                {
                    if (wl.Item == id) res += wl.Amount;
                }
            }

            return res;
        }

        public void ClearClass() {
            _class = null;
            _list = null;
        }

        public IEnumerator<Workplace> GetEnumerator() {
            return ((IEnumerable<Workplace>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<Workplace>)_list).GetEnumerator();
        }

        public class Workplace {
            private int _id;

            private List<Waitinglist> _list;

            public Workplace(int _id) {
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

            public int Timeneed { get {
                    int summe = 0;
                    foreach (var w in _list)
                        summe += w.Timeneed;
                    return summe;
                }
            }

            public class Waitinglist {
                private int _period;
                private int _order;
                private int _firstbatch;
                private int _lastbatch;
                private int _item;
                private int _amount;
                private int _timeneed;

                public Waitinglist(int _period, int _order, int _firstbatch, int _lastbatch, int _item, int _amount, int _timeneed) {
                    this.Period = _period;
                    this.Order = _order;
                    this.Firstbatch = _firstbatch;
                    this.Lastbatch = _lastbatch;
                    this.Item = _item;
                    this.Amount = _amount;
                    this.Timeneed = _timeneed;
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

                public int Timeneed {
                    get {
                        return _timeneed;
                    }

                    set {
                        if (value < 0)
                            throw new ArgumentOutOfRangeException();
                        _timeneed = value;
                    }
                }
            }
        }
    }
}
