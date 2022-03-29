using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Rostok
{
    class Program
    {
        static void Main(string[] args)
        {
            List<adatok> beo = new List<adatok>();
            foreach (var sor in File.ReadAllLines("rostok.txt").Skip(1))
            {
                beo.Add(new adatok(sor));
            }
            Console.WriteLine($"3. feladat: Élelmiszerek száma: {beo.Count}");
        }
    }
}
