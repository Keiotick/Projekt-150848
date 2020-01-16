using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;


namespace ProjektPO_150848
{
    
    class Program
    {
        public static Stopwatch czas = new Stopwatch();
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(120, 50);

            Obiekty.wszystkieObiekty.Clear();
            

            Console.Clear();
            Grafiki.WydrukujTytul();
            Obiekty.glowny = Hero.TworzenieBohatera(Postac.poziom, Postac.nick, DrugieMenu.cheats);
            Console.Clear();
            
            
            while (true)
            {
                int poziomPor = Mapa.poziom;
                Obiekty.przeciwnicy.Clear();
                Mapa.Generate();
                Obiekty.GenerowaniePrzeciwnikow();
                while (poziomPor == Mapa.poziom)
                {
                    Mapa.Show();
                    Mapa.Poruszanie();
                    Obiekty.PoruszaniePrzeciwnikow();

                    if (Mapa.map[Obiekty.glowny.x, Obiekty.glowny.y] == "©")
                    {
                        Obiekty.glowny.x = 1;
                        Obiekty.glowny.y = 1;
                        Mapa.poziom++;
                    }
                    if (Mapa.map[Obiekty.glowny.x, Obiekty.glowny.y] == "∞")
                    {
                        Mapa.map[Obiekty.glowny.x, Obiekty.glowny.y] = "░";
                        Mapa.mapZapas[Obiekty.glowny.x, Obiekty.glowny.y] = "░";
                        if (Obiekty.glowny.zycie < Obiekty.glowny.maksHP)
                        {
                            for (int leczenie = 0; leczenie <= 2; leczenie++)
                            {
                                if (Obiekty.glowny.zycie < Obiekty.glowny.maksHP)
                                    Obiekty.glowny.zycie++;
                            }
                        }
                        else
                            Obiekty.glowny.atak += 5;
                    }
                    foreach (Przeciwnik element in Obiekty.przeciwnicy)
                    {
                        if (Obiekty.glowny.x == element.x && Obiekty.glowny.y == element.y)
                        {

                            Mapa.Walka(element);
                            break;
                        }
                    }





                    Console.Clear();
                }

            }

        }
    }
}
