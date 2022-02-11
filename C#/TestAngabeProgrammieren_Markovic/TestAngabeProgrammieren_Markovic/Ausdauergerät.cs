using System;

namespace TestAngabeProgrammieren_Markovic
{
    internal class Ausdauergerät : Gerät
    {
        public Ausdauergerät(double gewicht, DateTime aufbauDatum, int länge, bool istDefekt)
             : base(gewicht, aufbauDatum, länge, istDefekt) { }

    }
}
