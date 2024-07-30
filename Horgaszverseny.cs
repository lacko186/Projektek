using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horgaszverseny
{
    class Versenyzo
    {
        public static int db = 0;
        public string nev;
        public string csapat;
        public List<double> halak = new List<double>();

        public static void VersenyAdatok()
        {
            Console.WriteLine("Helyszín: Deseda\nRendező: KSHE...");
        }
        public Versenyzo(string nev, string csapat)
        {
            this.nev = nev;
            this.csapat = csapat;
            Versenyzo.db += 1;
        }
        public void HalatFogott(double suly)
        {
            this.halak.Add(suly);
        }

        public double Eredmeny()
        {
            List<double> h = new List<double>(this.halak);
            h.Sort();
            h.Reverse();
            double ossz = 0;
            for (int i = 0; i < h.Count; i++)
            {
                ossz += h[i];
                if (i == 3)
                {
                    break;
                }
            }
            return ossz;
        }
        public double AtlagSuly()
        {
            return this.halak.Average();
        }
        public double LegnagyobbHal()
        {
            if (this.halak.Count > 0)
            {
                return this.halak.Max();
            }
            else
            {
                return 0;    
            }            
        }
        public override string ToString()
        {
            return $"Neve: {this.nev}\nCsapat: {this.csapat}\nLegnagyobb hal: {this.LegnagyobbHal()} kg";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Versenyzo.VersenyAdatok();
            List<Versenyzo> adatok = new List<Versenyzo>();
            Console.Write("Akarsz-e versenyzőt regisztrálni (i / n)? ");
            string valasz = Console.ReadLine();
            while (valasz == "i")
            {
                Console.Write("Neve: ");
                string neve = Console.ReadLine();
                Console.Write("Csapata: ");
                string csapata = Console.ReadLine();
                Versenyzo ujVersenyzo = new Versenyzo(neve, csapata);
                adatok.Add(ujVersenyzo);
                Console.Write("Akarsz-e újabb versenyzőt regisztrálni (i / n)?");
                valasz = Console.ReadLine();
            }
            Random rnd = new Random();
            for (int i = 0; i < 15; i++)
            {
                int sorszam = rnd.Next(adatok.Count);
                double kg = rnd.NextDouble()*25+5;
                  adatok[sorszam].HalatFogott(kg);
                   Console.WriteLine(kg);
            }
            Console.WriteLine("A horgászok adatai: ");
            foreach (Versenyzo item in adatok)
            {
                Console.WriteLine(item);
            }
            int x = 0;
            for (int i = 1; i < adatok.Count; i++)
                {
                if (adatok[x].Eredmeny() < adatok[i].Eredmeny())
                {
                    x = i;
                }
            }
            Console.WriteLine("A verseny győztese:");
            Console.WriteLine($"Neve: {adatok[x].nev} - {adatok[x].Eredmeny()} kg");
            Versenyzo bajnok = adatok[0];

            foreach (Versenyzo item in adatok)
          {
                if (bajnok.LegnagyobbHal() < item.LegnagyobbHal())
                {
                    bajnok = item;
                }
            }
            Console.WriteLine("A verseny győztese:");
            Console.WriteLine($"Neve: {bajnok.nev} - {bajnok.LegnagyobbHal()} kg");
            StreamWriter sw = new StreamWriter("t:/nagyfogasok.txt");
            foreach (Versenyzo item in adatok)
            {
                sw.WriteLine($"Neve: {item.nev} - {item.LegnagyobbHal()} kg");
            }
            sw.Close();
            Console.ReadKey();
        }
    }
}
