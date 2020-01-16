using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO_150848
{
    public class Hero : Punkt
    {
        public int poziomtrudnosci;
        public string imie; 
        public int zycie;
        public int atak;
        public int maksHP;

        public Hero()
        {
            this.x = 1;
            this.y = 1;
            this.poziomtrudnosci = 2;
            this.imie = "Sonic";
            this.zycie = 10;
            this.atak = 5;
            this.ikona = "☺";
            this.maksHP = 25;

        }
        public Hero(int trudnosc,string nick, int cheats)
        {
            this.x = 1;
            this.y = 1;
            this.poziomtrudnosci = trudnosc;
            this.imie = nick;
            this.maksHP = 25;
            switch (trudnosc)
            {
                case 3:
                    this.zycie = 5;
                    break;
                case 1:
                    this.zycie = 15;
                    break;
                default:
                    this.zycie = 10;
                    break;
            }
                
            switch (trudnosc)
            {
                case 3:
                    this.atak = 0;
                    break;
                case 1:
                    this.atak = 10;
                    break;
                default:
                    this.atak = 5;
                    break;
            }
            switch (trudnosc)
            {
                case 3:
                    this.maksHP = 5;
                    break;
                case 1:
                    this.maksHP = 15;
                    break;
                default:
                    this.maksHP = 10;
                    break;
            }
            if (cheats == 1)
            {
                this.atak = 99999;
                this.zycie = 99999;
                this.maksHP = 99999;
            }
            this.ikona = "☺";
        }

        public static Hero TworzenieBohatera(int trudnosc, string nick, int cheats)
        {
            if (nick == null||nick=="")
                nick = "Bezimienny";
            if (nick == null || nick == "")
                nick = "Bezimienny";
            Hero bohater = new Hero(trudnosc, nick, DrugieMenu.cheats);
            return bohater;
        }

    }

    public class Postac
    {
        public static string nick;
        public static int poziom;
    }

    public class Przeciwnik : Punkt
    {
        public string nazwa;
        public int zycie;
        public int obrazenia;
    }

    public class Goblin : Przeciwnik
    {
        public Goblin(int xx, int yy)
        {
            this.nazwa = "Goblin";
            this.ikona = "G";
            this.zycie = 100;
            this.obrazenia = 1;
            this.x = xx;
            this.y = yy;
        }

    }
    public class Smok : Przeciwnik
    {
        public Smok(int xx, int yy)
        {
            this.nazwa = "Smok";
            this.ikona = "?";
            this.zycie = 5000;
            this.obrazenia = 5;
            this.x = xx;
            this.y = yy;
        }
    }
    public class Ork : Przeciwnik
    {
        public Ork(int xx, int yy)
        {
            this.nazwa = "Ork";
            this.ikona = "O";
            this.zycie = 500;
            this.obrazenia = 3;
            this.x = xx;
            this.y = yy;
        }
    }
}
