using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Wettesensoren
{
    class Server
    {
        Stopwatch watch = new Stopwatch();
        Dictionary<Location, (double temp, double humidity)> locationToTempAndHumdidty = new Dictionary<Location, (double, double)>();
        public string Location { get; private set; } // location of server

        public Server(string location)
        {
            Location = location;
        }

        public event EventHandler<RequestDataEventArgs> RequestData;

        public void RequestDataTrigger()
        {
            RequestData?.Invoke(this, new RequestDataEventArgs(DateTime.Now));
        }

        public void GetsData(object sender, SendDataEventArgs args)
        {
            if (!(sender is MeasuringPoint))
                throw new InvalidOperationException();

            if (!(locationToTempAndHumdidty.ContainsKey(args.Location)))
                locationToTempAndHumdidty[args.Location] = (args.Temperature, args.Humidity);

            Console.WriteLine($"Server got new data: Location {args.Location} | Temp.: {args.Temperature} | Humidity: {args.Humidity}\n");
        }

        public void Simulate()
        {

            watch.Start();
            while (watch.ElapsedMilliseconds < 50_0000) // 500 s
            {
                RequestDataTrigger();
                if (locationToTempAndHumdidty.Count == 5)
                    OutputDictionaryAndClear();

                Thread.Sleep(8000);
            }
            watch.Stop();
        }

        public void OutputDictionaryAndClear()
        {
            foreach (var location in locationToTempAndHumdidty)
                Console.WriteLine($"{location.Key}: {location.Value.temp} °C, {location.Value.humidity}");
            locationToTempAndHumdidty.Clear();
        }

        public override string ToString()
        {
            return $"Location of Server: {Location}";
        }
    }
}
