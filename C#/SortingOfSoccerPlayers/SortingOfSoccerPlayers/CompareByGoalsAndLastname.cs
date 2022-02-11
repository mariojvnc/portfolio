using System.Collections.Generic;

namespace SortingOfSoccerPlayers
{
    class CompareByGoalsAndLastname : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            // Sortiere alle Spieler nach ihren geschossenen Toren (aufsteigend) und dem Nachnamen (aufsteigend) 
            // Wenn mehrere Spieler die gleiche Anzahl geschossener Tore haben, sollen diese nach ihrem
            // Nachnamen sortiert werden.

            int result = x.Goals.CompareTo(y.Goals);

            if (result == 0)
                result = x.LastName.CompareTo(y.LastName);

            return result;
        }
    }
}
