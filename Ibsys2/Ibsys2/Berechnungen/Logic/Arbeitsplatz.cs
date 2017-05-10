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

        public static ValueStore Instance
        {
            get
            {
                return instance;
            }
        }

        public int vertriebswunschP1;
        public int vertriebswunschP2;
        public int vertriebswunschP3;

        public int sicherheitsbestandP1;
        public int sicherheitsbestandP2;
        public int sicherheitsbestandP3;
    }
}
