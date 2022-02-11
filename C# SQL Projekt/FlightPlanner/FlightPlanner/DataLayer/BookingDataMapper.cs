﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace FlightPlanner.DataLayer
{
    class BookingDataMapper
    {
        #region Props & constructor
        public String ConnectionString { get; set; }

        public BookingDataMapper(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private Booking ParseRecord(IDataReader bookingReader)
        {
            Booking booking = new Booking();

            booking.FlightId = bookingReader.GetInt32(0);
            booking.CustomerId = bookingReader.GetInt32(1);
            booking.Seats = bookingReader.GetInt32(2);
            booking.TravelClass = bookingReader.GetInt32(3);
            booking.Price = bookingReader.GetDouble(4);

            return booking;
        }

        /// <summary>
        /// A helper method to query the database so that the common code to access the database ist not duplicated
        /// among several methods.
        /// </summary>
        /// <param name="sqlCommandText">SQL command to execute.</param>
        /// <returns></returns>
        #endregion

        #region Read bookings
        private List<Booking> ReadBookings(string sqlCommandText)
        {
            List<Booking> bookings = new List<Booking>();

            using (DbConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                IDbCommand bookingReadCommand = databaseConnection.CreateCommand();

                bookingReadCommand.CommandText = sqlCommandText;

                databaseConnection.Open();

                IDataReader bookingReader = bookingReadCommand.ExecuteReader();

                while (bookingReader.Read())
                {
                    Booking booking = ParseRecord(bookingReader);
                    bookings.Add(booking);
                }

                return bookings;
            }
        }

        public List<Booking> ReadBookings()
        {
            List<Booking> bookings = ReadBookings("select * from Bookings;");
            return bookings;
        }

        /// <summary>
        /// Read a single flight record.
        /// </summary>
        /// <param name="Id">The primary key of the flight record.</param>
        /// <returns>Returns an object that stores the flight record.</returns>
        #endregion

        #region Read
        public Booking Read(int Id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read by lastname
        public List<Booking> ReadByLastName(string lastName)
        {
            String sqlCommandText = $"select * from Bookings where Bookings.LastName = '{lastName}';";
            List<Booking> bookings = ReadBookings(sqlCommandText);
            return bookings;
        }

        /// <summary>
        /// This time a stored procedure is used to create the data record.
        /// The stored procedure also performs some checks like if enough seats are available
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        /// 
        #endregion

        #region Create
        public void Create(Booking booking)
        {
            using (DbConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                // 1. create a command object identifying the stored procedure
                IDbCommand command = databaseConnection.CreateCommand();
                command.CommandText = "dbo.BookFlight";

                // 2. tell the command object to execute a stored procedure
                command.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                IDbDataParameter param;

                param = command.CreateParameter();
                param.ParameterName = "@FlightId";
                param.DbType = DbType.Int32;
                param.Value = booking.FlightId;
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CustomerId";
                param.DbType = DbType.Int32;
                param.Value = booking.CustomerId;
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Seats";
                param.DbType = DbType.Int32;
                param.Value = booking.Seats;
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@TravelClass";
                param.DbType = DbType.Int32;
                param.Value = booking.TravelClass;
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Price";
                param.DbType = DbType.Decimal;
                param.Value = booking.Price;
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);

                IDbDataParameter returnValue;
                returnValue = command.CreateParameter();
                returnValue.ParameterName = "@ReturnValue";
                returnValue.DbType = DbType.Int32;
                returnValue.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(returnValue);

                databaseConnection.Open();

                // if Price were an output parameter (ParameterDirection.Output) you 
                // could use cmd.Parameters["@Price"] to get its value

                // ExecuteNonQuery returns @@ROWCOUNT which is a variable of SQL Server
                int sqlServerRowCount = command.ExecuteNonQuery();

                int storedProcedureResult = (int)returnValue.Value;

                if (sqlServerRowCount < 1)
                {
                    throw new InvalidOperationException("The booking could not be created!");
                }
            }

        }
        #endregion

        #region TestStoredProcedure
        public int TestStoredProcedure()
        {
            using (DbConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                // 1. create a command object identifying the stored procedure
                IDbCommand command = databaseConnection.CreateCommand();
                command.CommandText = "Test";

                // 2. tell the command object to execute a stored procedure
                command.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                //IDbDataParameter param;

                //param = command.CreateParameter();
                //param.ParameterName = "@FlightId";
                //param.DbType = DbType.Int32;
                //param.Value = 320;
                //param.Direction = ParameterDirection.Input;
                //command.Parameters.Add(param);

                databaseConnection.Open();

                int rowCount = command.ExecuteNonQuery();
                return rowCount;
            }

        }
        #endregion

        #region Update
        public int Update(Booking booking)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete

        public int Delete(Booking booking)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete
        public int Delete(int FlightId, int CustomerId)
        {
            throw new NotImplementedException();
        }

        // Delete
        public int DeleteByFlightId(int FlightId)
        {
            using (DbConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                IDbCommand deleteBookingCommand = databaseConnection.CreateCommand();
                deleteBookingCommand.CommandText = $"delete from Booking where Booking.FlightId = {FlightId};";

                Console.WriteLine(deleteBookingCommand.CommandText);
                databaseConnection.Open();

                int rowCount = deleteBookingCommand.ExecuteNonQuery();
                return rowCount;
            }
        }
        #endregion  
    }
}

