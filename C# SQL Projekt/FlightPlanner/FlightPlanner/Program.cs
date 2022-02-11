using FlightPlanner.DataLayer;
using FlightPlanner.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner
{
    class Program
    {
        /*public static DbProviderFactories Create(string key)
        {
            var providerType = GetProviderTypeFromConfig(key);
            var connectionString = GetConnectionFromConfig(key);

            if (providerType == ProviderType.Sql)
                return new SqlDatabaseProvider(connectionString);

            if (providerType == ProviderType.Oracle)
                return new OracleDatabaseProvider(connectionString);

            throw new NotImplementedException("Provider not found");
        }*/
        static void Main(string[] args)
        {
            // Programm verwendet ADO.NET API Connected Layer, Alternativen: ADO.NET Disconnected Layer, ADO.NET Entity Framework
            try
            {
                #region Test

                int rowCount = -2;

                // Die Angabe der Verbindung zur Datenbank erfolgt immer via Connnections mit einem Connectionstring
                // dieser ist manchmal aufwendig, DB-Herstellerdoku oder www.connectionstrings.com helfen
                // https://stackoverflow.com/questions/1229691/what-is-the-difference-between-integrated-security-true-and-integrated-securit

                // Connection string for connecting to SQL Server Local Db, for other database servers the connection
                // string must be modified.
                // Inital Catalog -> name of database
                // Integrated Security=SSPI -> use Windows Authentication (wie im Connection Dialog von Visual Studio)
                // Integrated Security=false -> use SQL Server Authentication, you must have an SQL Server database user account
                // TO DO: it is best practice to specify the connection string in app.config/web.config
                // string connectionString = @"Data Source=delphin;Initial Catalog=FlightPlanner;Integrated Security=SSPI";
                //string connectionString = @"Data Source=(LocalDB)\\MSSQLLocalDb;Initial Catalog=FlightPlanner;Integrated Security=SSPI";
                //;uid=Reinhard;password=reinhard";
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDb;Initial Catalog=FlightPlanner;Integrated Security=SSPI;";
                //string connectionString = @"Data Source=delphin;Initial Catalog=FlightPlanner;Integrated Security=SSPI";


                // The script to execute must not contain GO!
                // Recreate the database each time the progaaram is run so that we always work with the same data for testing
                //TestHelper.InitializeDatabase(connectionString);

                // CRUD - Create, Read, Update, Delete
                FlightDataMapper flightDataMapper = new FlightDataMapper(connectionString);

                Console.WriteLine("select * from Flight:");
                List<Flight> flights = flightDataMapper.ReadFlights();

                foreach (Flight flight in flights)
                {
                    Console.WriteLine(flight.ToString());
                }

                Flight testFlight = new Flight
                {
                    Id = 1001,
                    Departure = "Vienna",
                    Destination = "Budapest",
                    DepartureDate = DateTime.Now,
                    Duration = 40,
                    PlaneId = 21
                };

                AirlineDataMapper airlineDataMapper = new AirlineDataMapper(connectionString);

                Console.WriteLine("select * from Airine:");
                List<Airline> airlines = airlineDataMapper.ReadAirlines();

                foreach (Airline airline in airlines)
                {
                    Console.WriteLine(airline.ToString());
                }

                // flightDataMapper.Create(testFlight);

                testFlight.Duration = 450;
                rowCount = flightDataMapper.Update(testFlight);

                // rowCount = flightDataMapper.Delete(testFlight);

                // Löschen auskommentiert, weil sonst beim erneuten aufruf flüge gelöscht werden, die gar nicht existieren
                /*FlightPlannerDataModel flightPlannerDataModel = new FlightPlannerDataModel(connectionString);
                flightPlannerDataModel.DeleteFlight(204);
                flightPlannerDataModel.DeleteAirline(2);*/
                #endregion

                #region New Customer
                Console.WriteLine();
                Console.WriteLine("--- Update your name ---");
                Console.WriteLine("Enter your new name: ");
                // Elon Musk's son's name: X Æ A-Xii
                // A nice name but this one is better to hack (SQL Injection) the database: 
                // X Æ A-Xii' where Customer.Id = 1003; update Booking set Booking.Price = 0 where Booking.CustomerId = 1003; --
                string newName = Console.ReadLine();
         
                CustomerDataMapper customerDataMapper = new CustomerDataMapper(connectionString);

                // changes more than 2 data records (rows)
                rowCount = customerDataMapper.UpdateLastName(1003, newName);
                if (rowCount < 1)
                {
                    Console.WriteLine($"{nameof(customerDataMapper.UpdateLastName)}: No rows were updated!");
                }
                #endregion
               
                #region Book Flight
                // BOOK FLIGHT
               
                BookingDataMapper bookingDataMapper = new BookingDataMapper(connectionString);
                BookingService bookingService = new BookingService(connectionString);
                Console.WriteLine();
                //bool bookingpossible = bookingService.Book(4, 2, 1, 1000);
                Console.WriteLine($"Booking possible: {bookingService.Book(203, 2, 1, 1000)}");
                #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\n\nPress enter to stop the program.");
           
            Console.ReadLine();
        }
    }
}