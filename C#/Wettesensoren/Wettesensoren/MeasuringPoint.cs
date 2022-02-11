using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wettesensoren
{
    enum Location
    {
        Dachstein = 1, Bischofsmütze, Hochwurzen, Schladming, Radstadt
    }
    class MeasuringPoint
    {
        public Location Location { get; private set; }
        public double Temperature { get; set; } // in Celcius
        public double Humidity { get; set; } // in %

        public event EventHandler<SendDataEventArgs> SendData;

        private static Random rnd = new Random();
        public MeasuringPoint(Location location)
        {
            Location = location;
            Temperature = rnd.Next(-20, 41);
            Humidity = rnd.Next(1, 101);
        }

        public void NewRequestFromServer(object sender, RequestDataEventArgs args)
        {
            if (!(sender is Server))
            {
                throw new InvalidOperationException();
            }
            Console.WriteLine($"{sender as Server}, time: {args.Time.ToShortTimeString()}");

            SendData?.Invoke(this, new SendDataEventArgs(Temperature, Humidity, Location)); // The Invoke sends data back to the server
        }
    }
}
