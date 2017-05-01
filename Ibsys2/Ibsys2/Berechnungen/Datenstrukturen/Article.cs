using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Berechnungen.Datenstrukturen
{
    public class Article
    {
        private int _id;
        private int _amount;
        private int _startamount;
        private double _pctStart;
        private double _price;
        private double _stockvalue;

        public Article(int id, int amount, int startamount, double pctStart, double price, double stockvalue)
        {
            this._id = id;
            this._amount = amount;
            this._startamount = startamount;
            this._pctStart = pctStart;
            this._price = price;
            this._stockvalue = stockvalue;
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

        public int Startamount
        {
            get
            {
                return _startamount;
            }
            set
            {
                _startamount = value;
            }
        }

        public double PctStart
        {
            get
            {
                return _pctStart;
            }
            set
            {
                _pctStart = value;
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public double Stockvalue
        {
            get
            {
                return _stockvalue;
            }
            set
            {
                _stockvalue = value;
            }
        }



    }
}