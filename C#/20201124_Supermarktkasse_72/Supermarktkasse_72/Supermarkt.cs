using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Supermarktkasse_72
{
    class Supermarkt
    {
        private static Random rnd = new Random();

        private Queue<Kunde> schlange;

        private int anzahlDerKunden;
        private int summeDerWartezeiten;

        public Supermarkt()
        {
            schlange = new Queue<Kunde>();
        }

        // Durchschnittliche Wartezeit eines Kunden = Summe der Wartezeit aller Kunden / Anzahl der Kunden
        public void Simulate(DateTime dtStart, DateTime dtEnde)
        {
            // Am Beginn ist die Warteschlange leer
            schlange.Clear();

            // Simulationsschritt von einer Minute (ergibt sich aufgrund der Angabe)
            // dt = NICHT VERGESSEN!
            for (DateTime dt = dtStart; dt <= dtEnde; dt = dt.AddMinutes(1))
            {
                #region Ausgabe der Warteschlange
                Console.WriteLine($"{dt.ToShortTimeString()}: {schlange.Count} -> {String.Join(",",schlange)}");

                //Console.Write($"{dt.ToShortTimeString()}: {schlange.Count} -> ");

                //foreach ( var kunde in schlange )
                //{
                //    Console.Write(kunde.Identifier+",");
                //}

                //Console.WriteLine();
                #endregion

                #region Wartezeit erhöhen
                foreach( var kunde in schlange )
                {
                    kunde.Wartet();
                }
                #endregion

                #region Processing der Wartenden
                if ( schlange.Count > 0 )
                {   // Es wartet zumindest einer.

                    // Der erste wird bearbeitet.
                    Kunde ersterKunde = schlange.Peek();
                    ersterKunde.WirdBearbeitet();

                    if ( ersterKunde.IstFertig )
                    {   // Verlassen der Warteschlange
                        /*Kunde x = */schlange.Dequeue(); // Der erste geht raus.
                                                          // x ist immer ersterKunde
                        anzahlDerKunden++; // Entweder hier oder beim Anlegen

                        // Wenn der Kunde die Warteschlange verlässt, nachschauen wie lange er gewartet hatte.
                        summeDerWartezeiten += ersterKunde.Wartezeit;
                    }
                }
                #endregion

                #region Hinzufügen von Kunden in die Warteschlange
                if (dt.Hour >= 11 && dt.Hour <= 12)
                {   // Es ist nach 11:00 Uhr und vor 13:00 Uhr
                    if (rnd.Next(0, 100) < 50) // => 0, 1, ... 98, 99 sind 100 Zahlen
                    {   // 0, 1, ... 48, 49 sind 50 Zahlen
                        schlange.Enqueue(new Kunde());  // Kunde stellt sich in die Warteschlange
                    }
                }
                else
                {
                    if (rnd.Next(0, 100) < 30)
                    {   // zu 30 %
                        schlange.Enqueue(new Kunde());  // Kunde stellt sich in die Warteschlange
                    }
                }
                #endregion

                Thread.Sleep(1);
            }

            Console.WriteLine($"Es wurden {anzahlDerKunden} Kunden prozessiert.");

            double durchschnittlicheWartezeit = (double)summeDerWartezeiten / anzahlDerKunden;
            Console.WriteLine($"Die durchschnittliche Wartezeit pro Kunde betrug: {Math.Round(durchschnittlicheWartezeit*60)} Sekunden.");
        }
    }
}
