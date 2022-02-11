using System;

namespace TestAngabeProgrammieren_Markovic
{
    class Manager : AngestellterIn
    {
        public Manager(string vorname, string nachname, DateTime geburtsdatum, DateTime arbeitsbeginn)
            : base(vorname, nachname, geburtsdatum, arbeitsbeginn) { }

        public override string ToString()
        {
            return $"Name: {Vorname} {Nachname} | Geburtsdatum: {Geburtsdatum.ToShortDateString()} | Arbeitsbeginn: {Arbeitsbeginn.ToShortDateString()}";
        }
    }
}
