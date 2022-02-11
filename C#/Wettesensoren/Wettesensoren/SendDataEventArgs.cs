using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wettesensoren
{
    // Sends data back to the server, after a request got triggered
    class SendDataEventArgs : EventArgs
    {
        public double Temperature { get; } // in Celcius
        public double Humidity { get; } // in %
        public Location Location { get; }

        public SendDataEventArgs(double temperature, double humidity, Location location)
        {
            Temperature = temperature;
            Humidity = humidity;
            Location = location;
        }
    }
}
