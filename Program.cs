using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace tarsalgo
{
    class Tarsalgo
    {
        public int ora;
        public int perc;
        public int azonosito;
        public string merre;
    }
    class Program
    {
        static List<Tarsalgo> mentes = new List<Tarsalgo>();

        static void Beolvas()
        {
            StreamReader sr = null;
            string file = @"ajto.txt";

            using (sr = new StreamReader(file, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    Tarsalgo adat = new Tarsalgo();

                    string[] sorok = sr.ReadLine().Split(' ');

                    adat.ora = Convert.ToInt32(sorok[0]);
                    adat.perc = Convert.ToInt32(sorok[1]);
                    adat.azonosito = Convert.ToInt32(sorok[2]);
                    adat.merre = sorok[3];

                    mentes.Add(adat);
                }

            }
        }

        static List<string> ki = new List<string>();
        static void kibe()
        {
            string elsobe = "", utolsoki = "";
            bool elsobemehet = false;
            foreach (var item in mentes)
            {
                if (item.merre == "be" && elsobemehet != true)
                {
                    elsobe = Convert.ToString(item.azonosito);
                    elsobemehet = true;
                }
                if (item.merre == "ki")
                {
                    utolsoki = Convert.ToString(item.azonosito);
                }
            }
            Console.WriteLine("2. feladat");
            Console.WriteLine("Az első belépő: {0}", elsobe);
            Console.WriteLine("Az utolsó kilépő: {0}", utolsoki);
        }

        static List<Tarsalgo> menetel = new List<Tarsalgo>();
        static List<int> darabszam= new List<int>();

        static void meghat()
        {
            bool mehet = true;

            foreach (var item in mentes)
            {
                foreach (var item2 in menetel)
                {
                    if (item.azonosito == item2.azonosito)
                    {
                        mehet = false;
                    }
                }
                if (mehet == true)
                {
                    menetel.Add(item);
                }
                mehet = true;
            }

            menetel = menetel.OrderBy(x => x.azonosito).ToList();

            int darab = 0;

            for (int i = 0; i < menetel.Count; i++)
            {
                foreach (var item in mentes)
                {
                    if (item.azonosito == menetel[i].azonosito)
                    {
                        darab++;
                    }
                }
                darabszam.Add(darab);
                darab = 0;
            }

            StreamWriter r = new StreamWriter("athaladas.txt");
            int k= 0;
            foreach (var item in darabszam)
            {
                r.WriteLine("{0} {1}",menetel[k].azonosito,item);
                k++;
            }
            r.Close();
        }

        static void negyes()
        {
            Console.WriteLine();
            int h = 0;
            Console.WriteLine("4. feladat");
            Console.Write("A végén a társalgóban voltak: ");
            foreach (var item in darabszam)
            {
                if (item % 2 == 1)
                {
                    Console.Write(" {0}",menetel[h].azonosito);
                }
                h++;
            }
            Console.WriteLine();
        }

        static List<string> oraperc = new List<string>();

        static void otos()
        {
            Console.WriteLine();
            bool mehet = true;
            int sorszam = 0;
            string ido = "";
            foreach (var item in mentes)
            {
                foreach (var item2 in oraperc)
                {
                    ido = item.ora + ":" + item.perc;
                    if (ido == item2)
                    {
                        mehet = false;
                    }
                }
                if (mehet == true)
                {
                    oraperc.Add(ido);
                }
                mehet = true;
            }

            int[] tombok = new int[oraperc.Count];

            foreach (var item in oraperc)
            {
                foreach (var item2 in mentes)
                {
                    ido = item2.ora + ":" + item2.perc;
                    if (ido == item && item2.merre == "be")
                    {
                        tombok[sorszam]++;
                    }
                }
                sorszam++;
            }

            int max = 0;
            int index = 0;

            for (int i = 0; i < tombok.Length; i++)
            {
                if (tombok[i] >= max)
                {
                    index = i;
                    max = tombok[i];
                }

            }
            Console.WriteLine("5. feladat");
            Console.WriteLine("Például {0}-kor voltak a legtöbben a társalgóban. ", oraperc[index]);
        }

        static void bebebe()
        {
            Console.WriteLine("\n6. feladat");
            Console.Write("Adja meg a személy azonosítóját: ");
            b = int.Parse(Console.ReadLine());
        }

        static int b;
        static void hetes()
        {
            Console.WriteLine();
            Console.WriteLine("7. feladat");
            int k = 0;
            foreach (var item in mentes)
            {
                if (b == item.azonosito)
                {
                    if (k % 2 != 0)
                    {
                        Console.WriteLine("{0}:{1}", item.ora, item.perc);
                    }
                    else
                    {
                        Console.Write("{0}:{1}-", item.ora, item.perc);
                    }
                    k++;
                }

                
            }
        }

        static void nyolcas()
        {

        }
        static void Main(string[] args)
        {
            Beolvas();
            kibe();
            meghat();
            negyes();
            otos();
            bebebe();
            hetes();


            Console.ReadKey();
        }
    }
}
