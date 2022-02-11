using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket
{
    class StockMarketNewYork
    {
        private const string baseDir = @"..\..\..\data";
        private SortedDictionary<DateTime, decimal> dicDate2Value = new SortedDictionary<DateTime, decimal>();

        public async Task LoadAsync()
        {
            string filename = Path.Combine(baseDir, "daily_values.csv");

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    // TO DO 3: Stelle das Einlesen einer Zeile auf asynchron um.
                    string line = await reader.ReadLineAsync();
                    string[] parts = line.Split(';');

                    // TO DO 4: Speichere alle Datumsangaben und Aktienwerte 
                    // in einer Containerklasse deiner Wahl ab.
                    // Beachte, dass es auch handelsfreie Tage gibt, 
                    // an denen kein Aktienwert vorhanden ist.
                    dicDate2Value[DateTime.Parse(parts[0])] = decimal.Parse(parts[1]);
                }
            }
        }

        public decimal GetValue(DateTime date)
        {
            // TO DO 5: Gibt den Aktienwert für ein bestimmtes Datum zurück.
            // Lies dafür den Aktienwert aus deiner Containerklasse aus, soweit er gespeichert ist.
            //
            // Selbstdefinierte Exception: 
            // Falls für das Datum KEIN Wert gespeichert ist (Weil 
            // soll eine selbstdefinierte Exception geworfen werden.
            if (dicDate2Value.ContainsKey(date))
                return dicDate2Value[date];
            else
                throw new NoDateForValueException($"Für das Datum {date.ToShortDateString()} wurde keine Aktie gefunden");
        }

        public DateTime FirstDate
        {
            get
            {
                // TO DO 6: gib das erste Datum zurück, für das ein Aktienwert gespeichert ist.
                //foreach (var element in dicDate2Value)
                //    if(dicDate2Value[element^])
                return dicDate2Value.First().Key; // ersetzen!
            }
        }

        public DateTime LastDate
        {
            get
            {
                // TO DO 7: gib das letzte Datum zurück, für das ein Aktienwert gespeichert ist.
                return dicDate2Value.Last().Key; // ersetzen!
            }
        }

        public double CalculateAverage(DateTime dtFrom, DateTime dtTo)
        {
            // TODO 8: Implementiere die Berechnung des durchschnittlichen Aktienwerts über das Zeitintervall
            return 0; // ersetzen!
        }
    }
}
