using System;

namespace TestAngabeProgrammieren_Markovic
{
    internal class Gerät : IComparable<Gerät>
    {
        public double Gewicht { get; private set; }
        public DateTime AufbauDatum { get; private set; }
        public int Länge { get; private set; }
        public bool IstDefekt { get; private set; }

        public Gerät(double gewicht, DateTime aufbauDatum, int länge, bool istDefekt)
        {
            Gewicht = gewicht;
            AufbauDatum = aufbauDatum;
            Länge = länge;
            IstDefekt = istDefekt;
        }
       
        public int CompareTo(Gerät y)
        {
            int result = this.Gewicht.CompareTo(y.Gewicht);

            if (result == 0)
                result = this.AufbauDatum.CompareTo(y.AufbauDatum);

            return result;
        }
    }
}
