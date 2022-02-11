using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            // Eingabe einer Stadt -> 
            // Ausgabe der Temperatur und Feuchtigkeit und anderer Daten

            // 1. API-Key registrieren
            // 2. Ausgabe der Wetterdaten für eine bestimmte Stadt
            // 3. Error Handling

            const string API_KEY = "65e75cda377afe76ec9727992facf1d3";
            Console.Write($"Gib eine Stadt ein: ");
            string city = Console.ReadLine();

            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={API_KEY}&units=metric&lang=DE";

            WebClient wc = new WebClient();
            //wc.DownloadFile();

            string response = wc.DownloadString(url);
            Console.WriteLine(response);

            int code = 0;
            if (code == 200) // TODO Deserialize fromthe json response
            {
                // Extract Data
            }
            else
                Console.Error.WriteLine("Some error has occured.");

            Console.ReadKey();
        }
    }
}
