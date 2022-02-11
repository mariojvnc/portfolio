using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace FluglinienSchamma
{
    class Flugsicherung
    {
        public List<Flugzeug> Flugzeuge { get; private set; }
        private DateTime Heute = DateTime.Now;
        private static Random rnd = new Random();
        // Beispiel: Unwetterwarngung
        // WER schickt Unwetterwarnung? FLUGSICHERUNG
        // WER bekommt Unwetterwarnung? FLUGZEUG 

        // 1. Schritt: Eventsklasse anlegen
        // 2. Schritt: Event anlegen (wo? FLUGSICHERUNG)
        // 3. Schritt: Methode erstellen, die die Daten übermittelt bekommt (wo? FLUGZEUG)
        //             Diese Methode gibt dann informationen aus usw
        // 3. Schritt: Event mit der Methode verheiraten
        // 4. Schritt: Event triggern
        // 6. Schritt: Event wurde getriggert -> 

        public event EventHandler<UnwetterwarnungEventArgs> Unwetterwarnung;

        public Flugsicherung()
        {
            Flugzeuge = new List<Flugzeug>();
        }

        public void ReadFile(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            reader.ReadLine(); // erste zeile überspringen
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine(); // zuerst zeile
                string[] parts = line.Split(','); // dann splitten

                string[] parts_time = parts[0].Split(':');

                int hour = int.Parse(parts_time[0]);
                int minutes = int.Parse(parts_time[1]);

                var startzeit = new DateTime(Heute.Year, Heute.Month, Heute.Day, hour, minutes, 0);

                Flugzeuge.Add(new Flugzeug(startzeit, int.Parse(parts[1]), parts[2],
                    double.Parse(parts[3]), double.Parse(parts[4]), double.Parse(parts[5]), double.Parse(parts[6])));
            }
            reader.Close();
        }

        public void Simulate()
        {
            DateTime start = new DateTime(Heute.Year, Heute.Month, Heute.Day, 7, 30, 0);
            DateTime ende = new DateTime(Heute.Year, Heute.Month, Heute.Day, 13, 00, 0);

            for (DateTime time = start; time <= ende; time = time.AddMinutes(15))
            {
                Console.WriteLine($"\n{time.ToShortTimeString()} Uhr");

                // 09:00 Uhr -> OS2 fliegt!
                foreach (var flugzeug in Flugzeuge)
                {
                    if (time == flugzeug.Startzeit)
                    {
                        Action method = flugzeug.Fly; // keine runden Klammern
                        method.BeginInvoke(OnFinish(flugzeug), flugzeug/*geht auch mit null, null*/);
                        Unwetterwarnung += flugzeug.UnwetterwarnungGetriggert; // wir sagen der Unwetterwarnung, welche Methode sie aufrufen soll, wenn sie getriggert wurde
                        flugzeug.Notlandung += NeueNotlandung; // das flugzeug schickt uns notlandung infos
                    }
                }

                if (rnd.Next(0, 100) < 25) // 25 %-ige Wahrscheinlichkeit
                {
                    int x_unwetterwarnung_koordinate = rnd.Next(0, 11);
                    int y_unwetterwarnung_koordinate = rnd.Next(0, 11);
                    Console.WriteLine($"Neue Unwetterwarnung auf ({x_unwetterwarnung_koordinate}/{y_unwetterwarnung_koordinate})");
                    Unwetterwarnung?.Invoke(this, new UnwetterwarnungEventArgs(x_unwetterwarnung_koordinate, y_unwetterwarnung_koordinate));
                }


                Thread.Sleep(1000);
            }
        }


        public void NeueNotlandung(object sender, NotlandungEventArgs args)
        {
            if(!(sender is Flugzeug))
            {
                throw new InvalidOperationException();
            }

            Flugzeug flugzeug = sender as Flugzeug;

            Console.WriteLine($"    {flugzeug.Name} notgelandet auf {args.X_Kooridnate_Notlandung}/{args.Y_Kooridnate_Notlandung}");
        }

        public AsyncCallback OnFinish(Flugzeug flugzeug)
        {
            Console.WriteLine($"    {flugzeug.Name} ist abgeflogen.");
            return null; // weil es keine Void methode hat
        }
    }
}
