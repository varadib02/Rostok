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
            while (bekert_adat.Length<2)
            {
                bekert_adat = Console.ReadLine();
            }
            bool igaz=false;
            foreach (var i in beo)
            {
                for (int j = 0; j < i.megnev.Length; j++)
                {
                    for (int k = j + 1; k < bekert_adat.Length; k++)
                    {
                        if (i.megnev.ToLower()[k] == bekert_adat.ToLower()[k] && i.megnev.ToLower()[k-1] == bekert_adat.ToLower()[k - 1])
                        {
                        
                            igaz = true;
                        }
                        else { igaz = false; }
                    }
                    
                }
                if (igaz == true)
                {
                    Console.WriteLine($"{i.megnev} @ {i.kat} @ {i.egyseg} @ {i.rost}");
                }
            }
            if (igaz==false)
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
            StreamWriter sw=File.CreateText("Rostok100g.txt");
            sw.Close();
            List<string> szures = new List<string>();
            szures.Add("Megnevezés;Kategória;Rost");
            beo
                .Where(x=>x.egyseg=="100g")
                .ToList()
                .ForEach(x=>szures.Add($"{x.megnev};{x.kat};{x.rost}"));
            File.WriteAllLines("Rostok100g.txt",szures);

            

        }
    }
}