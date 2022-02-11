using System;
using System.Data.Common;

namespace FlightPlanner.DataLayer
{
    // Implement operations that affect several tables (e.g. deleting a flight affects also the Booking table)
    class FlightPlannerDataModel
    {
        private BookingDataMapper bookingDataMapper;
        private FlightDataMapper flightDataMapper;
        private PlaneDataMapper planeDataMapper;
        private AirlineDataMapper airlineDataMapper;
        //      TODO: add other data mappers
        string ConnectionString { get; set; }

        public FlightPlannerDataModel(string connectionString)
        {
            this.ConnectionString = connectionString;
            bookingDataMapper = new BookingDataMapper(this.ConnectionString);
            flightDataMapper = new FlightDataMapper(this.ConnectionString);
            planeDataMapper = new PlaneDataMapper(this.ConnectionString);
            airlineDataMapper = new AirlineDataMapper(this.ConnectionString);
        }

        public void DeleteFlight(int id)
        {
            int rowCount = Int32.MinValue;
            try
            {
                // FK_Booking_Flight uses "on delete no action"
                // FK_PilotRoster_Flight uses "ON DELETE CASCADE"
                rowCount = bookingDataMapper.DeleteByFlightId(id);
                rowCount = flightDataMapper.Delete(id);
            }
            catch (DbException dbEx) // TOD O: review and improve exception handling
            {
                // TO DO: log to log file
                throw new InvalidOperationException("Flight could not be deleted!", dbEx);
            }
            catch (Exception)
            {
                // TO DO: log to log file
                throw;
            }

            if (rowCount < 1)
            {
                throw new InvalidOperationException("The specified flight could not be deleted.");
            }
        }

        public void DeletePlane(int id)
        {
            int rowCount = Int32.MinValue;
            try
            {
                // hier stehen geblieben
                // FK_Plane_PlaneType   uses "on delete set null"
                // FK_Plane_Airline     uses "on delete set null"
                rowCount = planeDataMapper.Delete(id);
            }
            catch (DbException dbEx)
            {
                throw new InvalidOperationException("Plane could not be deleted!", dbEx);
            }
            catch (Exception)
            {
                // TO DO: log to log file
                throw;
            }

            if (rowCount < 1)
            {
                throw new InvalidOperationException("The specified plane could not be deleted.");
            }
        }


        public void DeleteAirline(int id)
        {
            int rowCount = Int32.MinValue;
            try
            {
                // TODO

                // Plane uses 
                // REFERENCES PlaneType(Id) on delete set null

                // Pilot uses
                // FOREIGN KEY(AirlineId) REFERENCES Airline(Id) on delete set default

                rowCount = flightDataMapper.Delete(id);
                rowCount = planeDataMapper.Delete(id);
                rowCount = airlineDataMapper.Delete(id);
            }
            catch (DbException dbEx) // TOD O: review and improve exception handling
            {
                // TO DO: log to log file
                throw new InvalidOperationException("Airline could not be deleted!", dbEx);
            }
            catch (Exception)
            {
                // TO DO: log to log file
                throw;
            }

            if (rowCount < 1)
            {
                throw new InvalidOperationException("The specified Airline could not be deleted.");
            }
        }
        
        // TODO Delete für Airline testen

    }
}
