using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO_150848
{
    public class Menu
    {
        public static List<string> Powrot = new List<string>() { "     > Powrot <      " };
        public static void DrukowanieListy(List<string> lista, int rodzaj=0)
        {
            Console.Clear();
           
            if (rodzaj == 1)
            {
                foreach (string line in Grafiki.koniec)
                {
                    Console.WriteLine(line);
                }
            }
            else if (rodzaj == 2)
            {
                foreach (string line in Grafiki.wygranko)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                foreach (string line in Grafiki.tytul)
                {
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine("\n\n");
            foreach (string element in lista)
                Console.WriteLine(element);
        }

        public static int IloscOpcji(int ilosc, int i)
        {
            ConsoleKeyInfo decyzja = Console.ReadKey();
            if (decyzja.Key == ConsoleKey.S || decyzja.Key == ConsoleKey.DownArrow)
                ++i;
            else if (decyzja.Key == ConsoleKey.W || decyzja.Key == ConsoleKey.UpArrow)
                --i;
            else if (decyzja.Key == ConsoleKey.Enter || decyzja.Key == ConsoleKey.Spacebar)
               return i = i * -1;
            if (i <= 0)
                i = ilosc;
            else if (i > ilosc)
                i = 1;
            return i;
        }
    }

    public class PierwszeMenu : Menu
    {
        
        static int liczbaOpcji = 3;
        public static List<string> unoMenu = new List<string>() { "                                                        > Nowa Gra <    ", "                                                           Opcje     ", "                                                          Wyjscie   " };
        public static List<string> dosMenu = new List<string>() { "                                                          Nowa Gra      ", "                                                         > Opcje <   ", "                                                          Wyjscie   " };
        public static List<string> tresMenu = new List<string>() { "                                                          Nowa Gra      ", "                                                           Opcje     ", "                                                        > Wyjscie < " };
        public static void Poczatek()
        {
            int i = 1;
            while (i > 0)
            {
                switch (i)
                {
                    case 1:
                        DrukowanieListy(unoMenu);
                        break;
                    case 2:
                        DrukowanieListy(dosMenu);
                        break;
                    case 3:
                        DrukowanieListy(tresMenu);
                        break;
                }
                i = IloscOpcji(liczbaOpcji, i);


            }
            switch (i)
            {
                case -1:
                    PoziomTrudnosci.Trudnosc();
                    break;
                case -2:
                    DrugieMenu.Opcje();
                    break;
                case -3:
                    Console.WriteLine("Kuniec");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
            }

        }
    }
    public class DrugieMenu : Menu
    {
        public static int cheats = 0;
        public static int liczbaOpcji = 4;
        public static List<string> unoMenuOpcje = new List<string>() { "                                                        > O Tworcy <    ", "                                                         Instrukcja     ", "                                                          Cheats[ ]   ", "                                                           Powrot    " };
        public static List<string> unoMenuOpcjeTak = new List<string>() { "                                                        > O Tworcy <    ", "                                                         Instrukcja     ", "                                                          Cheats[X]   ", "                                                           Powrot    " };
        public static List<string> dosMenuOpcje = new List<string>() { "                                                          O Tworcy      ", "                                                       > Instrukcja <   ", "                                                          Cheats[ ]   ", "                                                           Powrot    " };
        public static List<string> dosMenuOpcjeTak = new List<string>() { "                                                          O Tworcy      ", "                                                       > Instrukcja <   ", "                                                          Cheats[X]   ", "                                                           Powrot    " };
        public static List<string> tresMenuOpcje = new List<string>() { "                                                          O Tworcy      ", "                                                         Instrukcja     ", "                                                        > Cheats[ ] < ", "                                                           Powrot    " };
        public static List<string> tresMenuOpcjeTak = new List<string>() { "                                                          O Tworcy      ", "                                                         Instrukcja     ", "                                                        > Cheats[X] < ", "                                                           Powrot    " };
        public static List<string> quatroMenuOpcje = new List<string>() { "                                                          O Tworcy      ", "                                                         Instrukcja     ", "                                                          Cheats[ ]   ", "                                                         > Powrot <  " };
        public static List<string> quatroMenuOpcjeTak = new List<string>() { "                                                          O Tworcy      ", "                                                         Instrukcja     ", "                                                          Cheats[X]   ", "                                                         > Powrot <  " };
        public static void Opcje()
        {
            int i = 1;
            while (i > 0)
            {
                switch (i)
                {
                    case 1:
                        if(cheats==1)
                            DrukowanieListy(unoMenuOpcjeTak);
                        else
                            DrukowanieListy(unoMenuOpcje);
                        break;
                    case 2:
                        if (cheats == 1)
                            DrukowanieListy(dosMenuOpcjeTak);
                        else
                            DrukowanieListy(dosMenuOpcje);
                        break;
                    case 3:
                        if (cheats == 1)
                            DrukowanieListy(tresMenuOpcjeTak);
                        else
                            DrukowanieListy(tresMenuOpcje);
                        break;
                    case 4:
                        if (cheats == 1)
                            DrukowanieListy(quatroMenuOpcjeTak);
                        else
                            DrukowanieListy(quatroMenuOpcje);
                        break;
                }
                    i = IloscOpcji(4, i);

            }
            switch (i)
            {
                case -1:
                    Console.Clear();
                    Console.WriteLine("Game Design - Szymon Wylota");
                    Console.WriteLine("Kodowanie - Szymon Wylota");
                    Console.WriteLine("Pomyslodawca - Szymon Wylota");
                    Console.WriteLine("Inne - Szymon Wylota");
                    Console.WriteLine();
                    Console.WriteLine("wcisnij dowolny przycisk aby wrocic");
                    Console.ReadKey();
                    DrugieMenu.Opcje();
                    break;
                case -2:
                    Console.Clear();
                    Console.WriteLine("☺ - To Twoja postać. Poruszanie odbywa się za pomocą klawisami wsad lub strzałkami.");
                    Console.WriteLine("O,G,? - To przeciwnicy. Bedą podążać za Tobą, ale możesz spowolnić ich elementami otoczenia.\nGdy wpadniecie na siebie nastąpi walka.");
                    Console.WriteLine("♣ - To drzewo. Ani Ty ani przeciwnicy nie możecie bezpośrednio wejść na pole z drzewem.");
                    Console.WriteLine("▲ - To skała. Przeciwnicy nie mogą wejść na pole ze skałą.\nTwoja postać może przeskoczyć nad kamieniem, a nawet wskoczyć za jej pomocą na drzewo.");
                    Console.WriteLine("∞ - To wróżka. Gdy ją zbierzesz uleczy Cię jeśli jesteś ranny lub wzmocni zadawane przez Ciebie obrażenia.");
                    Console.WriteLine("© - To przejście. Gdy nastąpisz na nie, przejdziesz do kolejnego poziomu.");
                    Console.WriteLine();
                    Console.WriteLine("wcisnij dowolny przycisk aby przejsc dalej");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Wytłumaczenie walki:");
                    Console.WriteLine();
                    Console.WriteLine("Wisielec - musisz odgadnąć hasło używając jak najmniejszej ilości liter.");
                    Console.WriteLine("QTE - musisz w krótkim odstępie czasu wcisnąć podany klawisz.");
                    Console.WriteLine("Przepisanie - musisz jak najszybciej dokładnie przepisać podane zdanie.");
                    Console.WriteLine("PTA (w Twojej turze) - musisz nacisnąć klawisz F lub J według podanego najniższego elementu na ekranie.");
                    Console.WriteLine();
                    Console.WriteLine("wcisnij dowolny przycisk aby zamknac instrukcje");
                    Console.ReadKey();
                    DrugieMenu.Opcje();
                    break;
                case -3:
                    if (cheats == 1)
                        cheats = 0;
                    else
                        cheats = 1;
                    DrugieMenu.Opcje();
                    break;
                case -4:
                    PierwszeMenu.Poczatek();
                    break;
            }
        }
    }

    public class PoziomTrudnosci : Menu
    {
        
        static int liczbaOpcji = 4;
        public static List<string> unoTrud = new List<string>() { "                                                        > Latwy <    ", "                                                          Sredni     ", "                                                          Trudny   ", "                                                          Powrot    " };
        public static List<string> dosTrud = new List<string>() { "                                                          Latwy      ", "                                                        > Sredni <   ", "                                                          Trudny   ", "                                                          Powrot    " };
        public static List<string> tresTrud = new List<string>() { "                                                          Latwy      ", "                                                          Sredni     ", "                                                        > Trudny < ", "                                                          Powrot    " };
        public static List<string> quatroTrud = new List<string>() { "                                                          Latwy      ", "                                                          Sredni     ", "                                                          Trudny   ", "                                                        > Powrot <  " };
        public static void Trudnosc()
        {
            int i = 1;
            while (i > 0)
            {
                switch (i)
                {
                    case 1:
                        DrukowanieListy(unoTrud);
                        break;
                    case 2:
                        DrukowanieListy(dosTrud);
                        break;
                    case 3:
                        DrukowanieListy(tresTrud);
                        break;
                    case 4:
                        DrukowanieListy(quatroTrud);
                        break;
                }
                i = IloscOpcji(liczbaOpcji, i);

            }
            if(i>-4)
            {
                Console.Clear();
                Console.WriteLine("Podaj swe imię wędrowcze");
                Postac.nick = Console.ReadLine();
            }
            switch (i)
            {
                case -1: 
                    Postac.poziom = 1;
                    break;
                case -2:
                    Postac.poziom = 2;
                    break;
                case -3:
                    Postac.poziom = 3;
                    break;
                case -4:
                    PierwszeMenu.Poczatek();
                    break;
            }
        }

    }

    public class GameOver : Menu
    {
        static int liczbaOpcji = 2;
        public static List<string> unoKoniec = new List<string>() { "                                                        > Nowa Gra <    ", "                                                           Koniec     "};
        public static List<string> dosKoniec = new List<string>() { "                                                          Nowa Gra      ", "                                                         > Koniec <   "};
        public static void KoniecGry(int zakonczenie)
        {
            int i = 1;
            while (i > 0)
            {
                switch (i)
                {
                    case 1:
                        DrukowanieListy(unoKoniec,zakonczenie);
                        break;
                    case 2:
                        DrukowanieListy(dosKoniec,zakonczenie);
                        break;
                }
                i = IloscOpcji(liczbaOpcji, i);

            }
            switch (i)
            {
                case -1:
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                    Environment.Exit(0);
                    break;
                case -2:
                    Console.WriteLine("Kuniec");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
            }

        }
    }
}
