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

            Console.WriteLine($"4. feladat: nem 100g-os egység: {beo.Where(x => x.egyseg != "100g").Count()}");

            Console.WriteLine($"5.feladat: Frissgyümölcsök átlagos rosttartalma: {beo.Where(x => x.egyseg == "100g" && x.kat == "Friss gyümölcsök").Average(x => x.rost)}g");

            Console.WriteLine($"6.feladat: Kérek egy karakter láncot:");
            string bekert_adat = Console.ReadLine();

            if (true)
            {

            }
            else
            {
                Console.WriteLine("A keresés eredménytelen!");
            }


            Console.WriteLine($"7.feladat: Kategóriák  száma: {beo.GroupBy(x => x.kat).Count()}");

            Console.WriteLine($"8.feladat: Statisztika");
            Console.WriteLine($"\tAszalt gyümölcsök - {beo.Where(x => x.kat == "Aszalt gyümölcsök").Count()}");
            Console.WriteLine($"\tFriss gyümölcsök - {beo.Where(x => x.kat == "Friss gyümölcsök").Count()}");
            Console.WriteLine($"\tGabonák és lisztek - {beo.Where(x => x.kat == "Gabonák és lisztek").Count()}");
            Console.WriteLine($"\tZöldségek - {beo.Where(x => x.kat == "Zöldségek").Count()}");
            Console.WriteLine($"\tMagvak - {beo.Where(x => x.kat == "Magvak").Count()}");

            Console.WriteLine($"9.feladat: Rostok100g.txt");
            StreamWriter sw = File.CreateText("Rostok100g.txt");
            sw.WriteLine("Megnevezés;Kategória;Rost");
            
            foreach (var i in beo)
            {
                if (i.egyseg== "100g")
                {
                    sw.WriteLine($"{i.megnev};{i.kat};{i.rost}");
                }
            }



        }
    }
}