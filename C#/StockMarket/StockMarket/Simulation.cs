using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class Simulation
    {
        // Die Börse in New York, die die Aktienwerte einer Aktie für viele Tage gespeichert hat.
        private StockMarketNewYork stockmarket;

        // TO DO Event 1: Lege ein Event an, das immer dann ausgelöst wird, wenn in der Simulation
        // ein neuer Aktienwert vom stockmarket geholt wurde.
        // Das Event soll an den Eventhandler das Datum und den Aktienwert mitsenden.
        public event EventHandler<DateAndShareValueEventArgs> NewSharedValueAvailable;

        // TODO Event 2: Lege ein Event an, dass immer dann ausgelöst wird, wenn für einen bestimmten 
        // Tag in stockmarket KEIN Aktienwert gefunden wurde. (=Das Datum war kein Handelstag.)
        // Das Event soll nur das Datum mitsenden.


        public async void RunAsync()
        {
            #region DO NOT CHANGE THIS CODE!
            if (stockmarket == null)
            {
                stockmarket = new StockMarketNewYork();
                await stockmarket.LoadAsync();
            }
            #endregion

            for (DateTime currentDate = stockmarket.FirstDate;
                 currentDate <= stockmarket.LastDate;
                 currentDate = currentDate.AddDays(1))
            {
                // TODO 10: Hole mit stockmarket.GetValue(currentDate) den Aktienwert für das Datum.
                // 1. Für das Datum wurde ein Aktienwert gefunden -> dazugehörige Event 1 auslösen
                // 2. Für das Datum wurde kein Aktienwert gefunden (Handelsfreier Tag!) 
                //    -> Exception catchen und das Event 2 auslösen.
                
                try
                {
                    // stockmarket.GetValue(currentDate);
                    decimal value = stockmarket.GetValue(currentDate);
                    NewSharedValueAvailable?.Invoke(this, new DateAndShareValueEventArgs(currentDate, value));
                }
                catch (NoDateForValueException ex)
                {

                }
                // TODO 9: Ersetze Sleep durch await Task.Delay
                await Task.Delay(500);
            }
        }

        public void Pause()
        {
            // TODO 11: Implementiere, dass man die Simulation anhalten und mit [Start] wieder fortsetzen kann.

        }

        // Berechnet den durchschnittlichen Aktienwert der letzten Kalendertage, z. B. 20 Tage
        public double CalculateAverageOfTheLastDays(int days)
        {
            if (stockmarket == null)
                return double.NaN;

            // TODO: Ersetze new DateTime() durch das Startdatum und das Endedatum des Zeitintervalls dessen Länge days ist.
            return stockmarket.CalculateAverage(new DateTime() /*ersetzen!*/,
                                                new DateTime() /*ersetzen!*/);
        }
    }

    
}
