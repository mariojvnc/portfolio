using System;

namespace TestAngabeProgrammieren_Markovic
{
    internal class AngestellterIn : IComparable<AngestellterIn>
    {
        public string Vorname { get; private set; }
        public string Nachname { get; private set; }
        public DateTime Geburtsdatum { get; private set; }
        public DateTime Arbeitsbeginn { get; private set; }

        public AngestellterIn(string vorname, string nachname, DateTime geburtsdatum, DateTime arbeitsbeginn)
        {
            Vorname = vorname;
            Nachname = nachname;
            Geburtsdatum = geburtsdatum;
            Arbeitsbeginn = arbeitsbeginn;
        }


        public int CompareTo(AngestellterIn y)
        {
            // 1. Kriterium: Datum des Arbeitsbeginnes

            int result = -this.Arbeitsbeginn.CompareTo(y.Arbeitsbeginn);

            if(result == 0)
            {
                // 2. Kriterium: Geburtstag
                result = this.Geburtsdatum.CompareTo(y.Geburtsdatum);
            }

            return result;
        }
    }
}
