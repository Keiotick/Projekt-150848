using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ProjektPO_150848
{
    public class Obiekty
    {
        public static Random ramdom = new Random();
        public static Hero glowny;
        public static List<Punkt> wszystkieObiekty = new List<Punkt>();
        public static List<Przeciwnik> przeciwnicy = new List<Przeciwnik>();
        public static List<string> przeszkody = new List<string> {"G", "♣", "▲","O","?","©" };

        public static void GenerowaniePrzeciwnikow()
        {
            int g = ramdom.Next(1, 5);
            for (int m =0; m<g; m++)
            {
                int x = ramdom.Next(5, Mapa.wymiarX-3);
                int y = ramdom.Next(5, Mapa.wymiarY-3);
                przeciwnicy.Add(new Goblin(x, y));
            }
            for (int m = 0; m < Mapa.poziom; m++)
            {
                int x = ramdom.Next(5, Mapa.wymiarX - 3);
                int y = ramdom.Next(5, Mapa.wymiarY - 3);
                przeciwnicy.Add(new Ork(x, y));
            }
            if (Mapa.poziom==3)
                przeciwnicy.Add(new Smok(Mapa.wymiarX - 2, Mapa.wymiarY - 2));
        }

        public static void PoruszaniePrzeciwnikow()
        {
            foreach (Przeciwnik element in przeciwnicy)
            {
                if(!(Mierzenie(Obiekty.glowny,element)))
                {
                    if (element.x < Obiekty.glowny.x)
                    {
                        if (!(przeszkody.Contains(Mapa.map[element.x + 1, element.y])))
                        {
                            Mapa.map[element.x, element.y] = Mapa.mapZapas[element.x, element.y];
                            element.x++;
                        }
                            
                        else
                        {
                            if (element.y < Obiekty.glowny.y)
                            {
                                if (!(przeszkody.Contains(Mapa.map[element.x, element.y + 1])))
                                {
                                    Mapa.map[element.x, element.y] = Mapa.mapZapas[element.x, element.y];
                                    element.y++;
                                }

                                    
                            }
                            else if (element.y > Obiekty.glowny.y)
                            {
                                if (!(przeszkody.Contains(Mapa.map[element.x, element.y - 1])))
                                {
                                    Mapa.map[element.x, element.y] = Mapa.mapZapas[element.x, element.y];
                                    element.y--;
                                }
                                    
                            }
                        }

                    }
                    else if (element.x > Obiekty.glowny.x)
                    {
                        if (!(przeszkody.Contains(Mapa.map[element.x - 1, element.y])))
                        {
                            Mapa.map[element.x, element.y] = Mapa.mapZapas[element.x, element.y];
                            element.x--;
                        }
                            
                        else
                        {
                            if (element.y < Obiekty.glowny.y)
                            {
                                if (!(przeszkody.Contains(Mapa.map[element.x, element.y + 1])))
                                {
                                    Mapa.map[element.x, element.y] = Mapa.mapZapas[element.x, element.y];
                                    element.y++;
                                }
                                    
                            }
                            else if (element.y > Obiekty.glowny.y)
                            {
                                if (!(przeszkody.Contains(Mapa.map[element.x, element.y - 1])))
                                {
                                    Mapa.map[element.x, element.y] = Mapa.mapZapas[element.x, element.y];
                                    element.y--;
                                }
                                    
                            }
                        }
                    }
                }
                else
                {
                    if (element.y < Obiekty.glowny.y)
                    {
                        if (!(przeszkody.Contains(Mapa.map[element.x, element.y+1])))
                        {
                            Mapa.map[element.x, element.y] = Mapa.mapZapas[element.x, element.y];
                            element.y++;
                        }
                        
                        else
                        {
                            if (element.x < Obiekty.glowny.x)
                            {
                                if (!(przeszkody.Contains(Mapa.map[element.x + 1, element.y])))
                                {
                                    Mapa.map[element.x, element.y] = Mapa.mapZapas[element.x, element.y];
                                    element.x++;
                                }
                                    

                            }
                            else if (element.x > Obiekty.glowny.x)
                            {
                                if (!(przeszkody.Contains(Mapa.map[element.x - 1, element.y])))
                                {
                                    Mapa.map[element.x, element.y] = Mapa.mapZapas[element.x, element.y];
                                    element.x--;
                                }
                                    
                            }
                        }
                    }
                    else if (element.y > Obiekty.glowny.y)
                    {
                        if (!(przeszkody.Contains(Mapa.map[element.x, element.y - 1])))
                        {
                            Mapa.map[element.x, element.y] = Mapa.mapZapas[element.x, element.y];
                            element.y--;
                        }
                            
                        else
                        {
                            if (element.x < Obiekty.glowny.x)
                            {
                                if (!(przeszkody.Contains(Mapa.map[element.x + 1, element.y])))
                                {
                                    Mapa.map[element.x, element.y] = Mapa.mapZapas[element.x, element.y];
                                    element.x++;
                                }
                                    

                            }
                            else if (element.x > Obiekty.glowny.x)
                            {
                                if (!(przeszkody.Contains(Mapa.map[element.x - 1, element.y])))
                                {
                                    Mapa.map[element.x, element.y] = Mapa.mapZapas[element.x, element.y];
                                    element.x--;
                                }
                                    
                            }
                        }
                    }
                }
                
            }
        }

        public static bool Mierzenie(Punkt a, Punkt b)
        {
            int x = a.x - b.x;
            if (x < 0)
                x = x * -1;
            int y = a.y - b.y;
            if (y < 0)
                y = y * -1;
            if (y > x)
                return true;
            return false;
        }

    }


    public class Punkt
    {
        public int x;
        public int y;
        public string ikona;
        public void Print()
        {
            Console.WriteLine(this.x + "," + this.y);
        }
    }



    class Mapa
    {
        public static int poziom=1;
        public static int wymiarX;
        public static int wymiarY;
        public static string[,] map = new string[300,300];
        public static string[,] mapZapas = new string[300, 300];



        public static void Generate()
        {
            Random ramdom = new Random();
            wymiarX = ramdom.Next(15, 31);
            wymiarY = ramdom.Next(15, 31);

            map = new string[wymiarX, wymiarY];
            mapZapas = new string[wymiarX, wymiarY];

            for (int i = 0; i < wymiarY; i++)
            {
                for (int j = 0; j < wymiarX; j++)
                {
                    if(i==0||i==wymiarY-1||j==0||j==wymiarX-1)
                    {
                        map[j, i] = "#";
                        mapZapas[j, i] = "#";
                    }
                    else
                    {
                        int szansa = ramdom.Next(0,101);
                        if(szansa>=0&&szansa<=10)
                        {
                            map[j, i] = "♣";
                            mapZapas[j, i] = "♣";
                        }
                        else if(szansa>10&&szansa<=15)
                        {
                            map[j, i] = "▲";
                            mapZapas[j, i] = "▲";
                        }
                        else if (szansa == 16)
                        {
                            map[j, i] = "∞";
                            mapZapas[j, i] = "∞";
                        }
                        else
                        {
                            map[j, i] = "░";
                            mapZapas[j, i] = "░";
                        }
                        
                    }
                }
                if(poziom!=3)
                    map[wymiarX - 2, wymiarY - 2] = "©";

            }
        }

        public static void Show()
        {
            
            for (int i = 1; i < wymiarY-1; i++)
            {
                for (int j = 1; j < wymiarX-1; j++)
                {

                    

                    foreach (Punkt element in Obiekty.przeciwnicy)
                    {
                        if(i==element.y&&j==element.x)
                        {
                            map[j, i] = element.ikona;
                        }
                    }
                    if (i == Obiekty.glowny.y && j == Obiekty.glowny.x)
                    {
                        map[j, i] = Obiekty.glowny.ikona;
                    }
                    

                    Console.Write(map[j, i] + "░");

                }
                Console.Write("\n");
            }
            Console.Write("\n\n\n\n");
            Console.Write(Obiekty.glowny.imie+"\n");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("HP:                  "+Obiekty.glowny.zycie+"/"+Obiekty.glowny.maksHP);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Dodatkowe obrazenia:    " + Obiekty.glowny.atak);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n");
            Console.WriteLine("["+Obiekty.glowny.x+","+Obiekty.glowny.y+"]");
        }

        public static void Poruszanie()
        {
            ConsoleKeyInfo decyzja = Console.ReadKey();
            if (((decyzja.Key == ConsoleKey.S || decyzja.Key == ConsoleKey.DownArrow) && Obiekty.glowny.y < Mapa.wymiarY - 2) && Mapa.map[Obiekty.glowny.x, Obiekty.glowny.y + 1] != "♣")
            {
                Mapa.map[Obiekty.glowny.x, Obiekty.glowny.y] = Mapa.mapZapas[Obiekty.glowny.x, Obiekty.glowny.y];
                if ((Mapa.mapZapas[Obiekty.glowny.x, Obiekty.glowny.y + 1] == "▲")&& (Obiekty.glowny.y < Mapa.wymiarY - 3))
                    Obiekty.glowny.y += 2;
                else
                    Obiekty.glowny.y++;
            }
            else if (((decyzja.Key == ConsoleKey.W || decyzja.Key == ConsoleKey.UpArrow) && Obiekty.glowny.y > 1) && Mapa.map[Obiekty.glowny.x, Obiekty.glowny.y-1] != "♣")
            {
                Mapa.map[Obiekty.glowny.x, Obiekty.glowny.y] = Mapa.mapZapas[Obiekty.glowny.x, Obiekty.glowny.y];
                if ((Mapa.mapZapas[Obiekty.glowny.x, Obiekty.glowny.y - 1] == "▲")&& (Obiekty.glowny.y > 2))
                    Obiekty.glowny.y -= 2;
                else
                    Obiekty.glowny.y--;
            }
            else if (((decyzja.Key == ConsoleKey.D || decyzja.Key == ConsoleKey.RightArrow) && Obiekty.glowny.x < Mapa.wymiarX - 2) && Mapa.map[Obiekty.glowny.x + 1, Obiekty.glowny.y] != "♣")
            {
                Mapa.map[Obiekty.glowny.x, Obiekty.glowny.y] = Mapa.mapZapas[Obiekty.glowny.x, Obiekty.glowny.y];
                if ((Mapa.mapZapas[Obiekty.glowny.x + 1, Obiekty.glowny.y] == "▲")&& (Obiekty.glowny.x < Mapa.wymiarX - 3))
                    Obiekty.glowny.x += 2;
                else
                    Obiekty.glowny.x++;
            }
            else if (((decyzja.Key == ConsoleKey.A || decyzja.Key == ConsoleKey.LeftArrow) && Obiekty.glowny.x > 1) && Mapa.map[Obiekty.glowny.x - 1, Obiekty.glowny.y] != "♣")
            {
                Mapa.map[Obiekty.glowny.x, Obiekty.glowny.y] = Mapa.mapZapas[Obiekty.glowny.x, Obiekty.glowny.y];
                if ((Mapa.mapZapas[Obiekty.glowny.x-1, Obiekty.glowny.y] == "▲")&& (Obiekty.glowny.x > 2))
                    Obiekty.glowny.x -= 2;
                else
                    Obiekty.glowny.x--;
            }
        }


        public static void Walka(Przeciwnik rywal)
        {
            Random ramdom = new Random();
            int runda = 0;
            

            

            while(true)
            {
                int ZadaneObrazenia = 0;
                int nastepna = 0;
                Console.Clear();
                if (rywal.ikona == "O")
                {
                    foreach (string line in Grafiki.ork)
                    {
                        Console.WriteLine(line);
                        System.Threading.Thread.Sleep(30);
                    }
                }
                else if (rywal.ikona == "?")
                {
                    foreach (string line in Grafiki.smok)
                    {
                        Console.WriteLine(line);
                        System.Threading.Thread.Sleep(30);
                    }
                }
                else
                {
                    {
                        foreach (string line in Grafiki.goblin)
                        {
                            Console.WriteLine(line);
                            System.Threading.Thread.Sleep(30);
                        }
                    }
                }
                Console.Write("\n\n");
                Console.Write(Obiekty.glowny.imie + "                                                                   "+"\n");
                Console.WriteLine("HP:                  " + Obiekty.glowny.zycie + "/" + Obiekty.glowny.maksHP+ "                                           " + rywal.nazwa);
                Console.WriteLine("Dodatkowe obrazenia:    " + Obiekty.glowny.atak+ "                    vs                     HP:" + rywal.zycie);
                Console.Write("\n");
                if (runda % 2 == 0)
                    Console.Write("Kliknij spacje lub enter aby rozpocząć turę przeciwnika!\n");
                else
                    Console.Write("Kliknij spacje lub enter aby rozpocząć Twoją turę!\n");
                
                while(nastepna ==0)
                {
                    ConsoleKeyInfo decyzja = Console.ReadKey();
                    if (decyzja.Key == ConsoleKey.Enter || decyzja.Key == ConsoleKey.Spacebar)
                    {
                        nastepna++;
                    }
                    else
                        Console.Write("\b");
                }
                Console.ReadKey();
                Console.Clear();

                if (runda % 2 == 0)
                {
                    int konkurencja = ramdom.Next(0,101);
                    if(konkurencja>=0&&konkurencja<20)
                    {
                        ZadaneObrazenia = AtakHang.Wisielec(Obiekty.glowny.poziomtrudnosci);
                        Obiekty.glowny.zycie -= ZadaneObrazenia;
                    }
                    else if (konkurencja >= 20 && konkurencja < 60)
                    {
                        ZadaneObrazenia = AtakQte.Qte(rywal.obrazenia);
                        Obiekty.glowny.zycie -= ZadaneObrazenia;
                    }
                    else
                    {
                        ZadaneObrazenia = AtakJeden.WylosujZdanko(Obiekty.glowny.poziomtrudnosci, rywal.obrazenia);
                        Obiekty.glowny.zycie -= ZadaneObrazenia;
                    }
                }
                else
                {
                    ZadaneObrazenia = AtakPta.Pta(Obiekty.glowny.poziomtrudnosci);
                    ZadaneObrazenia += Obiekty.glowny.atak;
                    rywal.zycie -= ZadaneObrazenia;
                }
                Console.Clear();
                if (runda % 2 == 0)
                    Console.WriteLine("Otrzymałeś "+ZadaneObrazenia+ " dmg");
                else
                    Console.WriteLine("Zadałeś " + ZadaneObrazenia + " dmg");

                System.Threading.Thread.Sleep(3000);
                if (Obiekty.glowny.zycie<=0)
                {
                    Grafiki.WydrukujKoniec();
                    break;
                }
                if(rywal.zycie<=0)
                {
                    if(rywal.nazwa=="Smok")
                    {
                        Grafiki.WydrukujWygranie();
                        break;
                    }
                    Obiekty.przeciwnicy.Remove(rywal);
                    Obiekty.wszystkieObiekty.Remove(rywal);
                    break;
                }
                runda++;
            }

        }

    }
}
