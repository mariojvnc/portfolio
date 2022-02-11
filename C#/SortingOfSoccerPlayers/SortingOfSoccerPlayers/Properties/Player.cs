using System;

namespace SortingOfSoccerPlayers
{
    enum Position { Mittelstürmer, Hängende_Spitze, Offensives_Mittelfeld, Linksaußen, Rechtsaußen }
    class Player : IComparable<Player>
    {
        #region Props
        public string Name { get; private set; }
        public Position Position { get; private set; }
        public int Age { get; private set; }
        public string Club { get; private set; }
        public string League { get; private set; }
        public int PlayedGames { get; private set; }
        public int Goals { get; private set; }
        public int Assists { get; private set; }
        public double HitRate { get {return Math.Round((double)Goals / PlayedGames, 2); } } // Torquote
        public int Points { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        #endregion

        #region Constructor
        public Player(string name, Position position, int age, string club, string league, int playedGames, int goals, int assists)
        {
            Name = name;
            Position = position;
            Age = age;
            Club = club;
            League = league;
            PlayedGames = playedGames;
            Goals = goals;
            Assists = assists;
            // Punkte = Geschossene Tore + Assists
            Points = goals + assists;

            string[] nameParts = name.Split(' ');
            FirstName = nameParts[0];
            if (nameParts.Length > 2)
                LastName = nameParts[1] + " " + nameParts[2];
            else if (nameParts.Length == 1)
                LastName = nameParts[0];
            else
                LastName = nameParts[1];
        }
        #endregion

        #region ToString()
        public override string ToString() => $"{Name} | {Position} | {Age} | {Club} | {League} | {PlayedGames} | {Goals} | {Assists}";
        #endregion

        #region Override (Comparer)
        public int CompareTo(Player other)
        {
            // 1. Kriterium: Nachname
            int result = this.LastName.CompareTo(other.LastName);

            if (result == 0)
            {   // 2. Kriterium: Vorname
                result = this.FirstName.CompareTo(other.FirstName);

                if (result == 0)
                {   // 3. Kriterium: Alter
                    result = this.Age.CompareTo(other.Age);
                }
            }

            return result;
        }
        #endregion
    }
}
