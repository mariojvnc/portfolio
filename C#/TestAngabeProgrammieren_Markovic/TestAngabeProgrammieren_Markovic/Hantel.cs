using System;

namespace TestAngabeProgrammieren_Markovic
{
    internal class Hantel : Gerät
    {
        public Hantel(double gewicht, DateTime aufbauDatum, int länge, bool istDefekt)
            : base(gewicht, aufbauDatum, länge, istDefekt) { }
    }
}
