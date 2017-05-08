using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Charts
{
    class Charts : INotifyPropertyChanged
    {
        //http://modernuicharts.codeplex.com/ 
        //http://igrali.com/2013/05/25/getting-started-with-free-metro-modern-ui-charts-windows-8/ - folgendes Beispiel:

        private string _name = string.Empty;
        private int _count = 0;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                NotifyPropertyChanged("Count");
            }

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
}
