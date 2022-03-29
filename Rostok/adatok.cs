using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rostok
{
    class adatok
    {
        public string megnev { get; set; }
        public string kat { get; set; }
        public string egyseg { get; set; }
        public double rost { get; set; }
        public adatok(string sor)
        {
            string[] db = sor.Split(';');
            megnev = db[0];
            kat = db[1];
            egyseg = db[2];
            rost = Convert.ToDouble(db[3]);
        }
    }
}
