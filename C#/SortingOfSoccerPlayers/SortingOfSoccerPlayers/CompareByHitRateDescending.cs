using System.Collections.Generic;

namespace SortingOfSoccerPlayers
{
    class CompareByHitRateDescending : IComparer<Player>
    {
        public int Compare(Player x, Player y) => -x.HitRate.CompareTo(y.HitRate);
    }
}
