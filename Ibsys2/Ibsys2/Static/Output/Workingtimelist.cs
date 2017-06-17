using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Static.Output
{
    public class Workingtimelist : IEnumerable<WorkingtimelistItem>, INotifyPropertyChanged
    {
        //<workingtimelist><workingtime station="[1-99]" shift="[1-9]" overtime="[0-999999]"/></workingtimelist>
        private static Workingtimelist _class;
        private List<WorkingtimelistItem> _list;

        public Workingtimelist()
        {
            if (_class != null)
                throw new Exception("Class already exists!");
            _class = this;
            this._list = new List<WorkingtimelistItem>();
        }

        public static Workingtimelist Class {
            get {
                if (_class == null)
                    new Workingtimelist();
                return _class;
            }
        }

        public void AddItem(WorkingtimelistItem item)
        {
            if (item == null)
                throw new Exception();
            _list.RemoveAll(x => x.station == item.station);
            _list.Add(item);
        }

        public WorkingtimelistItem getOrderForStation(int station)
        {
            return _list.Find(x => x.station == station);
        }

        public string XMLOutput()
        {
            string Output = "<workingtimelist>";
            foreach (var wtl in _list)
                Output += wtl.XMLOutput();
            return Output + "</workingtimelist>";
        }

        public void ClearClass()
        {
            _class = null;
            _list = null;
        }

        public IEnumerator<WorkingtimelistItem> GetEnumerator()
        {
            return ((IEnumerable<WorkingtimelistItem>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<WorkingtimelistItem>)_list).GetEnumerator();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class WorkingtimelistItem
    {
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
                if (value > 1000000)
                    throw new Exception();
                if (value < 0)
                    _overtime = 0;
                else
                    _overtime = value;
            }
        }

        public WorkingtimelistItem(int station, int shift, int overtime)
        {
            this.station = station;
            this.shift = shift;
            this.overtime = overtime;
        }

        public string XMLOutput()
        {
            return @"<workingtime station=""" + _station + @""" shift=""" + _shift + @""" overtime=""" + _overtime + @"""/>";
        }
    }
}
