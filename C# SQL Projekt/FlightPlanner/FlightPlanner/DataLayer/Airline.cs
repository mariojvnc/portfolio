namespace FlightPlanner.DataLayer
{
    class Airline
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Country { get; set; }
        public string Headquarters { get; set; }

        public override string ToString() => $"Id: {Id}, Label: {Label}, Country: {Country}, Headquarters: { Headquarters}";
    }
}
