using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Input {
    public static class Result {
        public static class General {
            public static ResultTyp Capacity;
            public static ResultTyp Possiblecapacity;
            public static ResultTyp Relpossiblenormalcapacity;
            public static ResultTyp Productivetime;
            public static ResultTyp Effiency;
            public static ResultTyp Sellwish;
            public static ResultTyp Salesquantity;
            public static ResultTyp Deliveryreliability;
            public static ResultTyp Idletime;
            public static ResultTyp Idletimecosts;
            public static ResultTyp Storevalue;
            public static ResultTyp Storagecosts;
        }

        public static class Defectivegoods {
            public static ResultTyp Quantity;
            public static ResultTyp Costs;
        }

        public static class Normalsale {
            public static ResultTyp Salesprice;
            public static ResultTyp Profit;
            public static ResultTyp Profitperunit;
        }

        public static class Directsale {
            public static ResultTyp Profit;
            public static ResultTyp Contractpenalty;
        }

        public static class Marketplacesale {
            public static ResultTyp Profit;
        }

        public static class Summary {
            public static ResultTyp Profit;
        }
        

        public class ResultTyp {
            private string _current;
            private string _average;
            private string _all;

            public string Current {
                get {
                    return _current;
                }
            }

            public string Average {
                get {
                    return _average;
                }
            }

            public string All {
                get {
                    return _all;
                }
            }

            public ResultTyp(string _current, string _average, string _all) {
                this._current = _current;
                this._average = _average;
                this._all = _all;
            }
        }
    }
}
