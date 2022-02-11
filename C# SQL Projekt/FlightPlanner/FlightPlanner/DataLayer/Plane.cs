using System;

namespace FlightPlanner.DataLayer
{
    class Plane
    {
        public int Id { get; set; }
        public DateTime LastMaintenance { get; set; }
        public DateTime Ownershipdate { get; set; }
        public int PlaneTypeId { get; set; }
        public int AirlineId { get; set; }
        
        public override string ToString() => $"Id: {Id}, LastMaintenance: {LastMaintenance}, Ownershipdate: {Ownershipdate}, PlaneTypeId: {PlaneTypeId}, AirlineId: {AirlineId}";
    }
}
