using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Input {
    public class Forecast:IEnumerable<Forecast.ForecastPeriod> {
        private static Forecast _class;
        private Dictionary<int, ForecastPeriod> _list;

        public static Forecast Class {
            get {
                if (_class == null)
                    new Forecast();
                return _class;
            }
        }

        public Forecast() {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            _list = new Dictionary<int, ForecastPeriod>();
        }

        public void AddForecast(int period, ForecastPeriod data) {
            if (period < 0 || data == null)
                throw new ArgumentException();
            if (_list.ContainsKey(period))
                _list.Remove(period);
            _list.Add(period, data);
            if (period == 0)
            {
                Output.Sellwish.Class.AnzahlArtikel1 = _list[0].Product1;
                Output.Sellwish.Class.AnzahlArtikel2 = _list[0].Product2;
                Output.Sellwish.Class.AnzahlArtikel3 = _list[0].Product3;
            }
        }

        public ForecastPeriod GetPeriod(int period) {
            return _list[period];
        }

        public void ClearClass() {
            _class = null;
            _list = null;
        }

        public IEnumerator<ForecastPeriod> GetEnumerator() {
            return ((IEnumerable<ForecastPeriod>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<ForecastPeriod>)_list).GetEnumerator();
        }

        public class ForecastPeriod {
            private int _product1;
            private int _product2;
            private int _product3;

            public ForecastPeriod(int _product1, int _product2, int _product3) {
                this.Product1 = _product1;
                this.Product2 = _product2;
                this.Product3 = _product3;
            }

            public int Product1 {
                get {
                    return _product1;
                }

                set {
                    if (value < 0)
                        throw new ArgumentException();
                    _product1 = value;
                }
            }

            public int Product2 {
                get {
                    return _product2;
                }

                set {
                    if (value < 0)
                        throw new ArgumentException();
                    _product2 = value;
                }
            }

            public int Product3 {
                get {
                    return _product3;
                }

                set {
                    if (value < 0)
                        throw new ArgumentException();
                    _product3 = value;
                }
            }
        }
    }
}
