using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Timers;
using System.Diagnostics;
using System.Threading;


namespace ProjektPO_150848
{
    public class AtakJeden
    {
        public static Stopwatch czas = new Stopwatch();
        public static int WylosujZdanko(int trud,int dmg)
        {
            string[] pierwsza = { "Prezydent", "Marcin", "Komar", "Małgosia", "Ukraina", "Sąsiad", "Ksiądz", "Programista","Wiedźmin", "Polityk", "Lekarz","Niewidowy","Trump","Yoda","Gandalf","Hagrid","Zombie","Batman" };
            string[] druga = { "posiada", "ukrywa", "poluje na", "naśladuje", "zabija", "ratuje", "nagrywa", "ogląda", "sprzedaje", "pokazuje", "kradnie", "lubi", "krytykuje","niszczy","adoptuje","je","niszczy" };
            string[] trzecia = { "trzy", "wielkie", "straszne", "nieistniejące", "niewdzięczne", "agresywne", "chore", "gorące","tajemnicze","kosmiczne", "biedne", "mordercze", "nielegalne", "urocze","małe","śmiertelne" };
            string[] czwarta = { "jamniki", "bomby", "niemowlęta", "komputery", "programistki", "sowy", "rośliny", "pizze","zwierzęta","leki", "cukierki", "choroby", "filmiki","marakasy","paznokcie","alkohole" };
            Random Ramdom = new Random();
            int a = Ramdom.Next(0, pierwsza.Length);
            int b = Ramdom.Next(0, druga.Length);
            int c = Ramdom.Next(0, trzecia.Length);
            int d = Ramdom.Next(0, czwarta.Length);
            int randomNumber = Ramdom.Next(0, 100);
            string zdanie = (pierwsza[a] + " " + druga[b] + " " + trzecia[c] + " " + czwarta[d]+".");

            int limit;
            switch(trud)
            {
                case 1:
                    limit = 12000;
                    break;
                case 3:
                    limit = 8000;
                    break;
                default:
                    limit = 10000;
                    break;
            }

            Console.Clear();
            Console.WriteLine("Ręcę na klawiaturę");
            System.Threading.Thread.Sleep(500);
            for (int i = 5; i >=1 ; i--)
            {
                Console.WriteLine(i);
                System.Threading.Thread.Sleep(500);
            }
            Console.Clear();
            Console.WriteLine("Szybko przepisz podane zdanie:\n\n\n");
            czas.Start();
            Console.WriteLine(zdanie+"\n\n\n");
            string odpowiedz = Console.ReadLine();

            if (odpowiedz == zdanie && czas.ElapsedMilliseconds <= limit)
            {
                Console.WriteLine(czas.ElapsedMilliseconds);
                Console.WriteLine("Idealnie");
                czas.Reset();
                System.Threading.Thread.Sleep(1000);
                return 0;
            }
            else if (odpowiedz == zdanie && czas.ElapsedMilliseconds > limit)
            {
                Console.WriteLine(czas.ElapsedMilliseconds);
                Console.WriteLine("Zbyt wolno");
                czas.Reset();
                System.Threading.Thread.Sleep(1000);
                return dmg;
            }
            else
            {
                czas.Reset();
                Console.WriteLine("Niestety");
                System.Threading.Thread.Sleep(1000);
                return dmg;
            }
                

        }
        public static int Porownanko(string a, string b)
        {
            if (a == b )
                return 1;
            else
                return 0;
        }
    }

    public class AtakQte
    {
        public static char[] alfabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        public static Random Ramdom = new Random();
        public static ConsoleKeyInfo guzior;

        public static int Qte(int trud)
        {
            int obrazenia = 0;
            Console.WriteLine("Ręcę na klawiaturę");
            System.Threading.Thread.Sleep(500);
            for (int i = 5; i >= 1; i--)
            {
                Console.WriteLine(i);
                System.Threading.Thread.Sleep(500);
            }
            for (int ile = 1; ile <=trud; ile++)
            {
                Console.Clear();
                int a = Ramdom.Next(0, alfabet.Length);


                System.Threading.Thread.Sleep(1000);
                ConsoleKeyInfo guzior = new ConsoleKeyInfo();
                Console.WriteLine("Wciśnij " + alfabet[a] + "!");
                for (int czas = 20; czas > 0; czas--)
                {
                    if (Console.KeyAvailable == true)
                    {
                        guzior = Console.ReadKey();
                        break;
                    }
                    else
                    {
                        //Console.WriteLine(sekundy.ToString());
                        System.Threading.Thread.Sleep(100);
                    }
                }
                Console.WriteLine("\nWcisnąłeś " + guzior.Key);
                if (guzior.KeyChar != alfabet[a])
                {
                    obrazenia++;
                }
                System.Threading.Thread.Sleep(1000);
            }
            



           

            return obrazenia;
            
        }
    }

    public class AtakPta
    {
        public static char[] wszystkie = new char[500];
        public static Random Ramdom = new Random();
        public static Stopwatch limit = new Stopwatch();
        public static ConsoleKeyInfo guzik;
        public static int Pta(int trud)
        {
            int trafione = 0;
            int wielkosc = wszystkie.Length;
            ConsoleKeyInfo guzik = new ConsoleKeyInfo();
            int czas = 10000;

            switch(trud)
            {
                case 1:
                    czas = 15000;
                    break;
                case 3:
                    czas = 10000;
                    break;
                default:
                    czas = 12000;
                    break;
            }

            for (int i=0;i< wielkosc; i++)
            {
                int ktoraLitera = Ramdom.Next(0, 2);

                switch(ktoraLitera)
                {
                    case 0:
                        wszystkie[i] = 'f';
                        break;
                    case 1:
                        wszystkie[i] = 'j';
                        break;
                }
            }

            limit.Start();
            while (limit.ElapsedMilliseconds<czas&&wielkosc>7)
            {
                int licznik = wielkosc - 5;
                while(licznik < wielkosc)
                {
                    switch (wszystkie[licznik])
                    {
                        case 'f':
                            Console.WriteLine(" [ f ]     [ X ]");
                            Console.WriteLine();
                            break;
                        case 'j':
                            Console.WriteLine(" [ X ]     [ j ]");
                            Console.WriteLine();
                            break;
                    }
                    licznik++;
                    

                }
                guzik = Console.ReadKey();
                if(guzik.KeyChar==wszystkie[wielkosc-1])
                {
                    trafione++;
                }
                else
                {
                    limit.Reset();
                    return trafione;
                }
                   
                //System.Threading.Thread.Sleep(100000);
                wielkosc--;
                Console.Clear();



            }
            limit.Reset();
                return trafione;
        }
    }

    public class AtakHang
    {
        public static string[] wyrazy = { "karwasze","komputer","abecadło","grzejnik","minister","aptekarz","tabletka","jedzenie","jadalnia","śledztwo","wachadło","poduszka","gradient","ekologia","algorytm","rekwizyt","szkielet","synergia","kapelusz","akwarium","milenium", };
        public static int Wisielec(int trud)
        {
            Random Ramdom = new Random();
            int a = Ramdom.Next(0, wyrazy.Length);
            string odpowiedz = wyrazy[a];
            List<char> dozwolone = new List<char> { 'q','w','e','r','t','y','u','i','o','p','a','s','d','f','g','h','j','k','l','z','x','c','v','b','n','m','ą','ę','ó','ł','ń','ć','ż','ź','ś'};
            List<char> odwiedzone = new List<char>();
            List<char> litery = odpowiedz.ToList();
            List<char> zakryte = new List<char>();
            Char podana;
            int wymagane=0;

            int darmowe = 7;
            switch(trud)
            {
                case 1:
                    darmowe = 10;
                    break;
                case 3:
                    darmowe = 5;
                    break;
                default:
                    darmowe = 7;
                    break;
            }
            int obrazenia = 0;

            foreach(Char lit in litery)
            {
                zakryte.Add('_');
                wymagane++;
            }

            while(wymagane>0)
            {
                Console.WriteLine("                                 Darmowe ruchy: {0}                       Otrzymane Obrazenia: {1}\n", darmowe,obrazenia);
                Console.WriteLine("Uzyte litery: ");
                foreach(char element in odwiedzone)
                {
                    Console.Write(element+" ");
                }
                Console.WriteLine("\n\n\n\n\n\n\n\n\n");
                Console.Write("                                                     ");
                foreach (char element in zakryte)
                {
                    Console.Write(element + " ");
                }


                Console.WriteLine("\n\n\n\nPodaj Litere: ");
                podana = Console.ReadKey().KeyChar;
                podana = char.ToLower(podana);
                if(!dozwolone.Contains(podana))
                    {
                    Console.WriteLine("     Niedozwolony znak");
                    Thread.Sleep(1000);
                    }
                else if (odwiedzone.Contains(podana))
                {
                    Console.WriteLine("     litera została już podana");
                    Thread.Sleep(1000);
                }
                else
                {
                    odwiedzone.Add(podana);
                    if(litery.Contains(podana))
                    {
                        for(int i = 0;i<litery.Count;i++)
                        {
                            if(podana==litery[i])
                            {
                                zakryte[i] = podana;
                                wymagane--;
                            }
                        }
                    }
                    else
                    {
                        if (darmowe > 0)
                        {
                            darmowe--;
                        }
                        else
                            obrazenia++;
                    }
                }
                Console.Clear();


            }

            return obrazenia;
        }

    }

}
