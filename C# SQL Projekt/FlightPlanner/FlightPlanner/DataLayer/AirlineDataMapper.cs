using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace FlightPlanner.DataLayer
{
    /// <summary>
    /// Data mapper design pattern: https://en.wikipedia.org/wiki/Data_mapper_pattern    
    /// </summary>
    class AirlineDataMapper
    {
        #region Probs & constructor
        public String ConnectionString { get; set; }

        public AirlineDataMapper(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        #endregion

        #region ParseRecord
        private Airline ParseRecord(IDataReader airlineReader)
        {
            Airline airline = new Airline();
            // public Airline(int idAirline, string country, string headquatarts, string label)

            airline.Id = airlineReader.GetInt32(0);
            airline.Country = airlineReader.GetString(1);
            airline.Headquarters = airlineReader.GetString(2);
            airline.Label = airlineReader.GetString(3);

            return airline;
        }
        #endregion

        #region Create
        public void Create(Airline airline)
        {
            using (DbConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                // 1. create a command object identifying the stored procedure
                IDbCommand command = databaseConnection.CreateCommand();
                command.CommandText = "dbo.Airline";

                // 2. tell the command object to execute a stored procedure
                command.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                IDbDataParameter param;

                param = command.CreateParameter();
                param.ParameterName = "@IdAirline";
                param.DbType = DbType.Int32;
                param.Value = airline.Id;
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);
                //public Airline(int idAirline, string country, string headquatarts, string label)

                param = command.CreateParameter();
                param.ParameterName = "@Country";
                param.DbType = DbType.String;
                param.Value = airline.Country;
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Headquatarts";
                param.DbType = DbType.String;
                param.Value = airline.Headquarters;
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Label";
                param.DbType = DbType.String;
                param.Value = airline.Label;
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
                    throw new InvalidOperationException("Airline could not be created.");
                }
            }

        }
        #endregion

        #region Read / TestStoredProcedure
        public Airline Read(int id)
        {
            using (DbConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                IDbCommand selectCommand = databaseConnection.CreateCommand();
                selectCommand.CommandText =
                    $"select * from Airline where Airline.Id = {id};";

                IDataReader airlineReader = selectCommand.ExecuteReader();
                databaseConnection.Open();

                // https://docs.microsoft.com/en-us/dotnet/api/system.data.idatarecord.item
                Airline airline = new Airline();
                airline.Id = airlineReader.GetInt32(0); // Column 0 of table Flight
                airline.Label = airlineReader.GetValue(1).ToString();
                airline.Country = airlineReader.GetValue(2).ToString();
                airline.Headquarters = airlineReader.GetValue(3).ToString();

                return airline;
            }
        }
        public List<Airline> ReadAirlines()
        {
            List<Airline> airlines = ReadAirlines("select * from Airline;");
            return airlines;
        }
        public List<Airline> ReadAirlines(string sqlCommandText)
        {
            // Ignore:
            // Using OleDbConnection instead of SqlConection, e.g. for Microsoft Access
            // DbConnection databaseConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\schule2000.mdb"); 
            List<Airline> airlines = new List<Airline>();

            // Declare the variable as DbConnection not as SqlConnection so you can easier replace SQL Server by an Oracle Database Server, etc.
            // There is also a design principle: "Program to an interface (= base class OR C#-interface) not an implementation."
            using (DbConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                // erzeuge zuerst ein zur Sql Server Connection passendes Command, weise Select Befehl zu
                IDbCommand selectFlightCommand = databaseConnection.CreateCommand();

                // Aus Performance Gründen alle Datensätze auf einmal lesen, nicht die Methode Read() dieser Klasse verwenden.
                selectFlightCommand.CommandText = sqlCommandText;

                databaseConnection.Open();

                // erzeuge den DataReader (der das zeilenweise Auslesen erlaubt) aus dem Command
                IDataReader airlineReader = selectFlightCommand.ExecuteReader();
                // gibt es nur einen Wert ist auch .ExecuteScalar möglich
                // für update, insert, ...  ist aCommand.ExecuteNonQuery  zuständig

                //jetzt in der Schleife durch das Ergebnis des Select Befehls
                while (airlineReader.Read())
                {
                    Airline airline = ParseRecord(airlineReader);
                    airlines.Add(airline);
                }

                return airlines;
            }
            // finally
        }
        /// <summary>
        /// Read a single flight record.
        /// </summary>
        /// <param name="Id">The primary key of the flight record.</param>
        /// <returns>Returns an object that stores the flight record.</returns>
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
        public int Update(Airline airline)
        {
            using (DbConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                // erzeuge zuerst ein zur Sql Server Connection passendes Command, weise Select Befehl zu
                IDbCommand updateAirlineCommand = databaseConnection.CreateCommand();
                updateAirlineCommand.CommandText =
                   $"update Airline set Label = '{airline.Label}', " +
                   $"Country = '{airline.Country}', " +
                   $"Headquarters = '{airline.Headquarters};";

                // Console.WriteLine NICHT an dieser Stelle in einem professionellen Programm verwenden, 
                // Methode soll auch bei GUI Anwendungen funktionieren
                Console.WriteLine(updateAirlineCommand.CommandText);

                databaseConnection.Open();

                int rowCount = updateAirlineCommand.ExecuteNonQuery();
                return rowCount;

            }
        }
        #endregion

        #region Delete
        public int Delete(Airline airline)
        {
            return Delete(airline.Id);
        }

        public int Delete(int id)
        {
            using (DbConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                IDbCommand deleteBookingCommand = databaseConnection.CreateCommand();
                deleteBookingCommand.CommandText = $"delete from Airline where Airline.Id = {id};";

                // Console.WriteLine(deleteBookingCommand.CommandText);
                databaseConnection.Open();

                int rowCount = deleteBookingCommand.ExecuteNonQuery();
                return rowCount;
            }
        }
        #endregion
    }
}
