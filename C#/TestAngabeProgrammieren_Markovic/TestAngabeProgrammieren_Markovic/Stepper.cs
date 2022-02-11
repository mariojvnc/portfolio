using System;

namespace TestAngabeProgrammieren_Markovic
{
    class Stepper : Ausdauergerät
    {
        public Stepper(double gewicht, DateTime aufbauDatum, int länge, bool istDefekt)
               : base(gewicht, aufbauDatum, länge, istDefekt) { }

        public override string ToString()
        {
            return $"Gewicht: {Gewicht}kg | Datum des Aufbaues: {AufbauDatum.ToShortDateString()} | Länge: {Länge}cm | Defekt: {IstDefekt}";
        }
    }
}
