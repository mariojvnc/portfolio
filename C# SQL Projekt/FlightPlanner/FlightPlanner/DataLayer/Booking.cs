namespace FlightPlanner.DataLayer
{
    public class Booking 
    {
        public Booking() { }

        public Booking(int flightId, int customerId, int seats, int travelClass, double price)
        {
            FlightId = flightId;
            CustomerId = customerId;
            Seats = seats;
            TravelClass = travelClass;
            Price = price;
        }

        public int FlightId { set; get; } // foreign key
        public int CustomerId { set; get; } // foreign key
        public int Seats { set; get; }
        public int TravelClass { set; get; }
        public double Price { set; get; }
    }
}
