using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Output {
    public static class Workingtimelist {
        //<workingtimelist><workingtime station="[1-99]" shift="[1-9]" overtime="[0-999999]"/></workingtimelist>
        private static List<WorkingtimelistItem> _list = new List<WorkingtimelistItem>();

        public static void AddItem(WorkingtimelistItem item) {
            if (item == null)
                throw new Exception();
            _list.RemoveAll(x => x.station == item.station);
            _list.Add(item);
        }

        public static List<WorkingtimelistItem> getOrderForArticle(int station) {
            return _list.FindAll(x => x.station == station);
        }

        public static string XMLOutput() {
            string Output = "<workingtimelist>";
            foreach (var wtl in _list)
                Output += wtl.XMLOutput();
            return Output + "</workingtimelist>";
        }
    }

    public class WorkingtimelistItem {
        private int _station;
        private int _shift;
        private int _overtime;

        public int station {
            get { return _station; }
            set {
                if (value < 0 || value > 100)
                    throw new Exception();
                _station = value;
            }
        }

        public int shift {
            get { return _shift; }
            set {
                if (value < 0 || value > 10)
                    throw new Exception();
                _shift = value;
            }
        }

        public int overtime {
            get { return _overtime; }
            set {
                if (value < 0 || value > 1000000)
                    throw new Exception();
                _overtime = value;
            }
        }

        public WorkingtimelistItem(int station, int shift, int overtime) {
            this.station = station;
            this.shift = shift;
            this.overtime = overtime;
        }

        public string XMLOutput() {
            return @"<workingtime station=""" + _station + @""" shift=""" + _shift + @""" overtime=""" + _overtime + @"""/>";
        }
    }
}
