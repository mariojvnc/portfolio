using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fussballverein
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            GoalKeeper g1 = new GoalKeeper("Manuel Neuer", new DateTime(2004, 7, 29), 765000m);
            FieldPlayer f1 = new FieldPlayer("Lionel Messi", new DateTime(2020, 9, 14), 1225000m, Position.Striker);
            Coach c1 = new Coach("Mario Markovic", new DateTime(1976, 8, 24), 554000m);
            Club club = new Club("FC Donaustadt");

            club.Add(g1);
            club.Add(f1);
            club.Add(c1);

            Console.WriteLine(club);
            Console.ReadKey();
        }
    }
}
