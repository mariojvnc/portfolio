using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.DataLayer
{
    public class BookingRepository
    {
        // ersatz für data model
        string ConnectionString { get; set; }
        public BookingRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public void CreateBooking(Booking booking)
        {
            BookingDataMapper bookingDataMapper = new BookingDataMapper(ConnectionString);
            bookingDataMapper.Create(booking);
        }

        // Check, if you can book a flight (are the bookings (seats) already full?)
        public int GetNumberOfPlaneSeats(int flightId)
        {
            using (SqlConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                databaseConnection.Open();
                string commandText = $"select Seats from flight inner join Plane on PlaneId = Plane.Id " +
                $"inner join PlaneType on PlaneTypeId = PlaneType.Id where Flight.Id = {flightId}";

                SqlCommand sqlCommand = new SqlCommand(commandText, databaseConnection);

                /*IDbCommand selectSeatsCommand = databaseConnection.CreateCommand();
                selectSeatsCommand.CommandText = $"select Seats from flight inner join Plane on PlaneId = Plane.Id " +
                $"inner join PlaneType on PlaneTypeId = PlaneType.Id where Flight.Id = {flightId}";

                IDataReader planeTypeReader = selectSeatsCommand.ExecuteReader();
                planeTypeReader.Read();
                Console.WriteLine("planeTypeReader.Read(): " + planeTypeReader.Read());

                int seats = (int)planeTypeReader["Seats"];
                Console.WriteLine($"Seats in plane with FlightId \"{flightId}\": {seats}");
                return seats;*/

                int seats = (Int32)sqlCommand.ExecuteScalar();
                Console.WriteLine($"Seats in plane with FlightId \"{flightId}\": {seats}");

                return seats;

            }
        }

        public int GetNumberOfBookedSeats(int flightId)
        {
            // TODO
            using (SqlConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                databaseConnection.Open();
                string commandText = $"select coalesce( sum(seats), 0) as BookedSeats " +
                    $"from Booking " +
                    $"full outer join Flight on Booking.FlightId = Flight.Id " +
                    $"where FlightId = {flightId}";

                /*IDbCommand selectSeatsCommand = databaseConnection.CreateCommand();
                selectSeatsCommand.CommandText = $"select coalesce( sum(seats), 0) as BookedSeats " +
                    $"from Booking " +
                    $"full outer join Flight on Booking.FlightId = Flight.Id " +
                    $"where FlightId = {flightId}";
                 IDataReader planeTypeReader = selectSeatsCommand.ExecuteReader();
                planeTypeReader.Read();
                return (int)planeTypeReader["BookedSeats"];*/
                SqlCommand sqlCommand = new SqlCommand(commandText, databaseConnection);


                int bookedSeats = (Int32)sqlCommand.ExecuteScalar();
                Console.WriteLine($"Booked seats in plane with FlightId \"{flightId}\": {bookedSeats}");

                return bookedSeats;
            }
        }

        public bool IsCustomerExisting(int customerID)
        {
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();

                string sqlCommmand = $"select Top 1 Id from Customer inner join Booking on Customer.Id = CustomerId where Customer.Id = {customerID}";

                SqlCommand isCustomerCommand = new SqlCommand(sqlCommmand, databaseConnection);
                int custID = (Int32)isCustomerCommand.ExecuteScalar();

                if (custID != 0)
                    return true;

                return false;
            }
        }
    }
}
