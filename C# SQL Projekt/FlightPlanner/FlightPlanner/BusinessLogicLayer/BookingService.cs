using FlightPlanner.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.BusinessLogicLayer
{
    class BookingService
    {
        // verwendet BookingRepository
        public BookingRepository bookingRepository { get; set; }

        public BookingService(string connectionString)
        {
            bookingRepository = new BookingRepository(connectionString);
        }

        public bool Book(int flightId, int seats, int travelClass, int customerId)
        {
            bool success = false;

            int numberOfPlaneSeats = bookingRepository.GetNumberOfPlaneSeats(flightId);
            int numberOfBookedSeats = bookingRepository.GetNumberOfBookedSeats(flightId);

            if ((numberOfBookedSeats + seats) <= numberOfPlaneSeats)
            {
                // Booking possible 
                double price = GetPrice();

                Booking booking = new Booking(flightId, seats, travelClass, customerId, GetPrice());
                bookingRepository.CreateBooking(booking);
                success = true;
            }

            // Booking not possible 
            return success;
        }

        private double GetPrice()
        {
            Random rnd = new Random();
            return rnd.Next(50, 350);
        }
    }
}