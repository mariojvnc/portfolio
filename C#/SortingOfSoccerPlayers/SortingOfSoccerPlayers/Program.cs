using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace SortingOfSoccerPlayers
{
    class Program
    {
        #region Methods
        static List<Player> ReadFile(string filename)
        {
            List<Player> players = new List<Player>();
            StreamReader reader = new StreamReader(filename);

            while (!reader.ReadLine().Contains("-")) { }

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line.Length == 0)
                    break;
                string name = line.Substring(0, 27).Trim(' ');
                string positionString = line.Substring(28, 22).Trim(' ');
                Position position = GetPosition(positionString);
                int age = int.Parse(line.Substring(50, 2));
                string club = line.Substring(52, 17).Trim(' ');
                string league = line.Substring(71, 15).Trim(' ');
                int playedGames = int.Parse(line.Substring(89, 2).Trim(' '));
                int goals = int.Parse(line.Substring(93, 2).Trim(' '));
                int assists = int.Parse(line.Substring(98, 1));

                players.Add(new Player(name, position, age, club, league, playedGames, goals, assists));
            }
            reader.Close();

            return players;
        }
        static char ShowMenu()
        {
            Console.WriteLine(" ---------------------Soccer Playerlist----------------------");
            Console.WriteLine($"        1 ... Sort by lastname ascending");
            Console.WriteLine($"        2 ... Sort by goals and lastname ascending");
            Console.WriteLine($"        3 ... Sort by Hit Rate descending");
            return Console.ReadKey(true).KeyChar;
        }
        static Position GetPosition(string positionString)
        {
            Position position = Position.Hängende_Spitze;
            switch (positionString)
            {
                case "Mittelstürmer": return Position.Mittelstürmer;
                case "Linksaußen": return Position.Linksaußen;
                case "Rechtsaußen": return Position.Rechtsaußen;
                case "Offensives Mittelfeld": return Position.Offensives_Mittelfeld;
            }
            return position;
        }
        static void SleepAndClear()
        {
            Thread.Sleep(6000);
            Console.Clear();
        }
        static void InputSortByLastname(List<Player> players)
        {
            Console.Clear();
            #region Sorted by lastname ascending
            // 1. Sortiere alle Spieler in aufsteigender alphabetischer Reihenfolge (A bis Z) 
            // Auszugebene Spalten: Name, Verein, Geschossene Tore, Assist, Punkte 
            players.Sort();
            Console.WriteLine($"{ "First name",-15} {"Last name",-15}{"Club",-15}\t{ "Goals",8}{"Assists",8}{"Points",8}\t(Sorted by lastname ascending)\n");
            foreach (Player player in players)
                Console.WriteLine($"{ player.FirstName,-15} {player.LastName,-15}{player.Club,-15}\t{ player.Goals,8}{player.Assists,8}{player.Points,8}");
            #endregion
            SleepAndClear();
        }
        static void InputSortByGoalsAndLastname(List<Player> players)
        {
            Console.Clear();
            #region Sorted by goals and lastname ascending
            // 2. Sortiere alle Spieler nach ihren geschossenen Toren (aufsteigend) und dem Nachnamen (aufsteigend) 
            // Auszugebende Spalten: Name, Geschossene Tore
            players.Sort(new CompareByGoalsAndLastname());
            Console.WriteLine($"{ "Name",-25}\t{"Goals",8}\t\t\t\t(Sorted by Goals and Lastname ascending)\n");
            foreach (Player player in players)
                Console.WriteLine($"{ player.Name,-25}\t{ player.Goals,8}");
            #endregion
            SleepAndClear();
        }
        static void InputSortByHitRate(List<Player> players)
        {
            Console.Clear();
            #region Sorted by Hit Rate descending
            // 3. Alle Spieler absteigend sortiert nach ihrer Trefferquote
            // (Trefferquote = Geschossene Tore / Anzahl der Spiele) 
            // Auszugebende Spalten: Name, Trefferquote, Geschossene Tore, Anzahl der Spiele 
            players.Sort(new CompareByHitRateDescending());
            Console.WriteLine($"{ "Name",-30}{"Hit Rate",8}\t{"Goals",8}\t\t{"Played Games",8}\t(Sorted by Hit Rate descending)\n");
            foreach (Player player in players)
                Console.WriteLine($"{ player.Name,-30}{player.HitRate,8}\t{player.Goals,8}\t\t{player.PlayedGames,8}");
            #endregion
            SleepAndClear();
        }
        #endregion

        static void Main(string[] args)
        {
            List<Player> players = ReadFile("Spieler.txt");

            while (true)
            {
                switch (ShowMenu())
                {
                    case '1':
                        InputSortByLastname(players);
                        break;
                    case '2':
                        InputSortByGoalsAndLastname(players);
                        break;
                    case '3':
                        InputSortByHitRate(players);
                        break;
                    default:
                        Console.WriteLine($"Invalid input!\n\n");
                        break;
                }
            }
        }
    }
}

