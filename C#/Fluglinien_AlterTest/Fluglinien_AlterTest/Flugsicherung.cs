using System;
using System.Collections.Generic;
using System.IO;

namespace Fluglinien_AlterTest
{
    enum Unwetterart { Hagel, Gewitter, Sturm, Starkregen, Dauerregen, Hitz, Kälte, Schnee }
    class Flugsicherung
    {
        public List<Flugzeug> Flugzeuge;
        public DateTime Heute = DateTime.Now;
        private Random rnd = new Random();

        // 1.
        public event EventHandler<UnwetterEventArgs> Unwetterwarnung;

        public Flugsicherung(string path)
        {
            Flugzeuge = new List<Flugzeug>();

            StreamReader reader = new StreamReader(path);
            reader.ReadLine(); // erste zeile überspringen
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                const char seperator = ',';
                string[] parts = line.Split(seperator);

                string[] parts_time = parts[0].Split(':');
                int hour = int.Parse(parts_time[0]);
                int minutes = int.Parse(parts_time[1]);

                var dateAndTime = new DateTime(Heute.Year, Heute.Month, Heute.Day, hour, minutes, 0);

                Flugzeuge.Add(new Flugzeug(dateAndTime, int.Parse(parts[1]), parts[2],
                    double.Parse(parts[3]), double.Parse(parts[4]), double.Parse(parts[5]), double.Parse(parts[6])));
            }
            reader.Close();
        }

        public void Simulation()
        {
            DateTime start = new DateTime(Heute.Year, Heute.Month, Heute.Day, 7, 30, 0);
            DateTime ende = new DateTime(Heute.Year, Heute.Month, Heute.Day, 13, 00, 0);

            for (DateTime time = start; time <= ende; time = time.AddMinutes(15))
            {
                Console.WriteLine($"\n{time.ToShortTimeString()} Uhr");

                foreach (var flugzeug in Flugzeuge)
                {
                    if (time.ToShortTimeString() == flugzeug.Startzeit.ToShortTimeString())
                    {
                        Action method = flugzeug.Fly;
                        method.BeginInvoke(OnFinish(flugzeug), flugzeug);
                        this.Unwetterwarnung += flugzeug.UnwetterwarnungGetriggert;
                        flugzeug.Notlandung += NeueNotlandung;
                       // Flugzeuge.Remove(flugzeug);
                    }

                }

                // 2. Triggern
                // zu 25 % Unwetter
                if (rnd.Next(0, 100) < 25)
                {
                    int x_koordinate = rnd.Next(0, 11);
                    int y_koordinate = rnd.Next(0, 11);
                    Unwetterart unwetterart = (Unwetterart)rnd.Next(0, 7);

                    Unwetterwarnung?.Invoke(this, new UnwetterEventArgs(x_koordinate, y_koordinate, unwetterart));

                    Console.WriteLine($"\n-------------------------------------------\nUNWETTERWARNUNG auf {x_koordinate}/{y_koordinate} | Art: {unwetterart}\n-------------------------------------------\n");
                }

                System.Threading.Thread.Sleep(1000);
            }
        }

        public void NeueNotlandung(object sender, NotlandungEventArgs args)
        {
            Console.WriteLine($"    {args.FlugzeugName} notgelandet auf {args.X_Kooridnate_Notlandung}/{args.Y_Kooridnate_Notlandung}");
        }

        private AsyncCallback OnFinish(Flugzeug flugzeug)
        {
            Console.WriteLine($"    {flugzeug.Name} ist abgeflogen.");
            
            return null;
        }
    }
}
