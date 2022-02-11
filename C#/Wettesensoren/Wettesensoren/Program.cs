using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wettesensoren
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Instances
            // Instances
            var server = new Server($"Deutschland - München");
            var measuringPointDachstein = new MeasuringPoint(Location.Dachstein);
            var measuringPointBischofsmütze = new MeasuringPoint(Location.Bischofsmütze);
            var measuringPointHochwurzen = new MeasuringPoint(Location.Hochwurzen);
            var measuringPointSchladming = new MeasuringPoint(Location.Schladming);
            var measuringPointRadstadt = new MeasuringPoint(Location.Radstadt);
            #endregion

            #region Registration
            // Register server with measuring point
            server.RequestData += measuringPointDachstein.NewRequestFromServer;
            server.RequestData += measuringPointBischofsmütze.NewRequestFromServer;
            server.RequestData += measuringPointHochwurzen.NewRequestFromServer;
            server.RequestData += measuringPointSchladming.NewRequestFromServer;
            server.RequestData += measuringPointRadstadt.NewRequestFromServer;

            // Register measuring points with server (so that the server gets data back from the measuring point, after a request got triggered)
            measuringPointDachstein.SendData += server.GetsData;
            measuringPointBischofsmütze.SendData += server.GetsData;
            measuringPointHochwurzen.SendData += server.GetsData;
            measuringPointSchladming.SendData += server.GetsData;
            measuringPointRadstadt.SendData += server.GetsData;
            #endregion

            server.Simulate();

            Console.ReadKey();
        }
    }
}
