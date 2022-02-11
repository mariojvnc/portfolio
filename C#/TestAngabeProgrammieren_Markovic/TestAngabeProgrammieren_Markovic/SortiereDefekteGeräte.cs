using System.Collections.Generic;

namespace TestAngabeProgrammieren_Markovic
{
    class SortiereDefekteGeräte : IComparer<Gerät>
    {
        public int Compare(Gerät x, Gerät y)
        {

            int result = x.Länge.CompareTo(y.Länge);

            if (result == 0)
                result = x.Gewicht.CompareTo(y.Gewicht);
            
            return result;
        }
    }
}
