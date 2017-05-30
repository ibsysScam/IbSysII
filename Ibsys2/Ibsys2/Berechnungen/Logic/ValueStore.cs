using Ibsys2.Static.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibsys2.Berechnungen.Logic
{
    public sealed class ValueStore
    {
        private static readonly ValueStore instance = new ValueStore();

        private ValueStore() { }

        public static ValueStore Instance {
            get {
                return instance;
            }
        }

        //Periode 0
        public int vertriebswunschP1;
        public int vertriebswunschP2;
        public int vertriebswunschP3;

        public int sicherheitsbestandP1;
        public int sicherheitsbestandP2;
        public int sicherheitsbestandP3;

		//Periode 1
		public int prognose1P1;
		public int prognose1P2;
		public int prognose1P3;

		public int sb_Prognose1P1;
		public int sb_Prognose1P2;
		public int sb_Prognose1P3;

		//Periode 2
		public int prognose2P1;
		public int prognose2P2;
		public int prognose2P3;

		public int sb_Prognose2P1;
		public int sb_Prognose2P2;
		public int sb_Prognose2P3;

		//Periode 3
		public int prognose3P1;
		public int prognose3P2;
		public int prognose3P3;

		public int sb_Prognose3P1;
		public int sb_Prognose3P2;
		public int sb_Prognose3P3;



        public int sicherheitsFaktor;
    }
}
