using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.DataLayer
{
    class Flight
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public int Duration { get; set; }
        public DateTime DepartureDate { get; set; }
        public int PlaneId { get; set; }

        public Flight(int id, string departure, string destination, int duration, DateTime departureDate, int planeId)
        {
            Id = id;
            Departure = departure;
            Destination = destination;
            Duration = duration;
            DepartureDate = departureDate;
            PlaneId = planeId;
        }

        public Flight() { }

        public override string ToString()
        {
            return $"Id: {Id}, Departure: {Departure}, Destination: {Destination}, " +
                $"Duration: {Duration}, DepartureDate: {DepartureDate}, PlaneId: {PlaneId}";
        }
    }
}
