using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Berechnungen.Datenstrukturen
{
    public class Order
    {
        private int _id;
        private int _amount;
        private int _mode;
        private double _article;
        private double _orderperiod;

        public Order(int id, int amount, int mode, double article, double orderperiod, double stockvalue)
        {
            this._id = id;
            this._amount = amount;
            this._mode = mode;
            this._article = article;
            this._orderperiod = orderperiod;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }

        public int Mode
        {
            get
            {
                return _mode;
            }
            set
            {
                _mode = value;
            }
        }

        public double Article
        {
            get
            {
                return _article;
            }
            set
            {
                _article = value;
            }
        }

        public double Orderperiod
        {
            get
            {
                return _orderperiod;
            }
            set
            {
                _orderperiod = value;
            }
        }


    }
}