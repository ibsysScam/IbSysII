using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Input {
    public class Ordersinwork:IEnumerable<Ordersinwork.Workplace> {
        private static Ordersinwork _class;
        private List<Workplace> _list;

        public static Ordersinwork Class {
            get {
                if (_class == null)
                    new Ordersinwork();
                return _class;
            }
        }

        public Ordersinwork() {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            this._list = new List<Workplace>();
        }
        
        public void Add(Workplace w) {
            if (w == null)
                throw new ArgumentNullException();
            _list.RemoveAll(x => x.ID == w.ID);
            _list.Add(w);
        }

        public Workplace GetWorkplaceByID(int id) {
            return _list.Find(x => x.ID == id);
        }

        public int GetArticleAmountByID(int id)
        {
            int res = 0;

            foreach(Workplace w in _list)
            {
                if (w.Item == id) res += w.Amount;
            }

            return res;
        }

		public List<Workplace> getAllWorkplaces()
		{
            return _list;
		}

        public List<Workplace> GetWorkplaceByOrder(int order) {
            return _list.FindAll(x => x.Order == order);
        }

        public List<Workplace> GetWorkplaceByBatch(int batch) {
            return _list.FindAll(x => x.Batch == batch);
        }

        public List<Workplace> GetWorkplaceByitem(int item) {
            return _list.FindAll(x => x.Item == item);
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
            private int _period;
            private int _order;
            private int _batch;
            private int _item;
            private int _amount;
            private int _timeneed;

            public Workplace(int _id, int _period, int _order, int _batch, int _item, int _amount, int _timeneed) {
                this._id = _id;
                this._period = _period;
                this._order = _order;
                this._batch = _batch;
                this._item = _item;
                this._amount = _amount;
                this._timeneed = _timeneed;
            }

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

            public int Batch {
                get {
                    return _batch;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _batch = value;
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
