using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Input {
    public class Idletimecosts:IEnumerable<Idletimecosts.Workplace> {
        private static Idletimecosts _class;
        private List<Workplace> _list;

        public static Idletimecosts Class {
            get {
                if (_class == null)
                    new Idletimecosts();
                return _class;
            }
        }

        public int SumSetupevents {
            get {
                int summe = 0;
                foreach (var w in _list)
                    summe = +w.Setupevents;
                return summe;
            }
        }

        public int SumIdletime {
            get {
                int summe = 0;
                foreach (var w in _list)
                    summe = +w.Idletime;
                return summe;
            }
        }

        public double SumWageidletimecosts {
            get {
                double summe = 0.0;
                foreach (var w in _list)
                    summe = +w.Wageidletimecosts;
                return summe;
            }
        }

        public double SumWagecosts {
            get {
                double summe = 0.0;
                foreach (var w in _list)
                    summe = +w.Wagecosts;
                return summe;
            }
        }

        public double SumMachineidletimecosts {
            get {
                double summe = 0.0;
                foreach (var w in _list)
                    summe = +w.Machineidletimecosts;
                return summe;
            }
        }

        public Idletimecosts() {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            _list = new List<Workplace>();
        }

        public void AddWorkplace(Workplace w) {
            if (w == null)
                throw new ArgumentNullException();
            _list.RemoveAll(x => x.ID == w.ID);
            _list.Add(w);
        }

        public Workplace GetWorkplaceByID(int id) {
            return _list.Find(x => x.ID == id);
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
            private int _setupevents;
            private int _idletime;
            private double _wageidletimecosts;
            private double _wagecosts;
            private double _machineidletimecosts;

            public int ID {
                get {
                    return _id;
                }
            }

            public int Setupevents {
                get {
                    return _setupevents;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _setupevents = value;
                }
            }

            public int Idletime {
                get {
                    return _idletime;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _idletime = value;
                }
            }

            public double Wageidletimecosts {
                get {
                    return _wageidletimecosts;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _wageidletimecosts = value;
                }
            }

            public double Wagecosts {
                get {
                    return _wagecosts;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _wagecosts = value;
                }
            }

            public double Machineidletimecosts {
                get {
                    return _machineidletimecosts;
                }

                set {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    _machineidletimecosts = value;
                }
            }

            public Workplace(int _id, int _setupevents, int _idletime, double _wageidletimecosts, double _wagecosts, double _machineidletimecosts) {
                this._id = _id;
                this.Setupevents = _setupevents;
                this.Idletime = _idletime;
                this.Wageidletimecosts = _wageidletimecosts;
                this.Wagecosts = _wagecosts;
                this.Machineidletimecosts = _machineidletimecosts;
            }
        }
    }
}
