using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace allatok
{
    internal class Program
    {

        static void Main(string[] args)
        {


            int allat = 0;
            Console.WriteLine("A versenyen maximum 10 éves állatok vehetnek rész!");
            while (allat == 0)
            {
              int allatok = 1;
                Console.WriteLine("Add meg az állat nevét:");
                string a = Console.ReadLine();

                Console.WriteLine("Add meg az állat születési évét:");
                int b = Convert.ToInt32(Console.ReadLine());
                while (b > 2024)
                {
                    Console.WriteLine("Adj meg valós információt");
                    break;
                }
                while (b < 2014)
                {

                    Console.WriteLine("Az állat 10 évnél idősebb, nem kap pontot a versenyen");
                    break;
                }


                Random z = new Random();
                int szepseg = z.Next(10);

                Random s = new Random();
                int ügyesseg = s.Next(10);

                int jelenlegiev = 2024;
                int alap = jelenlegiev - b;
                int összes = alap + szepseg + ügyesseg;
               


                Console.WriteLine($"{a} pontszámai:\n alappontszám: {jelenlegiev - b}\n Szépseg:{szepseg} \n ügyesseg:{ügyesseg} \n összesen: {összes} pontot szerzett");
                List<int> list = new List<int>();
                foreach (int i in list)
                {
                    list.Add(összes);
                }

                Console.WriteLine("Szeretnél még hozzáadni új versenyzőt i/n");
                string d = Console.ReadLine().ToLower();
                if (d == "n")
                {
                  
                    Console.WriteLine($"A versenyen összesen {allatok} db versenyző vett részt");
                
                }
                else
                {
                    allatok++;
                }
                for (int i = 0; i < list.Count; i++) 
                {
                    Console.WriteLine($"A legnagyobb pontszám: {list.Max()}");
                }
            
                Console.ReadKey();




            }
        }
    }    
}
