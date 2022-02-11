using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace FlightPlanner.DataLayer
{
    class PlaneDataMapper
    {
        #region Props & constructor
        public String ConnectionString { get; set; }

        public PlaneDataMapper(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        #endregion

        #region ParseRecord
        private Plane ParseRecord(IDataReader planeReader)
        {
            Plane plane = new Plane();

            plane.Id = planeReader.GetInt32(0);
            plane.Ownershipdate = planeReader.GetDateTime(1);
            plane.LastMaintenance = planeReader.GetDateTime(2);
            plane.PlaneTypeId = planeReader.GetInt32(3);
            plane.AirlineId = planeReader.GetInt32(4);

            return plane;
        }

        /// <summary>
        /// A helper method to query the database so that the common code to access the database ist not duplicated
        /// among several methods.
        /// </summary>
        /// <param name="sqlCommandText">SQL command to execute.</param>
        /// <returns></returns>
        #endregion

        #region Create
        public void Create(Plane plane)
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
                param.ParameterName = "@Id";
                param.DbType = DbType.Int32;
                param.Value = plane.Id;
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@LastMaintenance";
                param.DbType = DbType.DateTime;
                param.Value = plane.LastMaintenance;
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Ownershipdate";
                param.DbType = DbType.DateTime;
                param.Value = plane.Ownershipdate;
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@PlaneTypeId";
                param.DbType = DbType.Int32;
                param.Value = plane.PlaneTypeId;
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@AirlineId";
                param.DbType = DbType.Int32;
                param.Value = plane.AirlineId;
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
                    throw new InvalidOperationException("Plane could not be created.");
                }
            }

        }
        #endregion

        #region Read & TestStoredProcedure
        public Plane Read(int id)
        {
            using (DbConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                IDbCommand selectCommand = databaseConnection.CreateCommand();
                selectCommand.CommandText =
                    $"select * from Plane where Airline.Id = {id};";

                IDataReader planeReader = selectCommand.ExecuteReader();
                databaseConnection.Open();

                // https://docs.microsoft.com/en-us/dotnet/api/system.data.idatarecord.item
                Plane plane = new Plane();
                plane.Id = planeReader.GetInt32(0); // Column 0 of table Flight
                plane.LastMaintenance = planeReader.GetDateTime(1);
                plane.Ownershipdate = planeReader.GetDateTime(2);
                plane.PlaneTypeId = planeReader.GetInt32(3);
                plane.AirlineId = planeReader.GetInt32(4);

                return plane;
            }
        }
        public List<Plane> ReadPlanes()
        {
            List<Plane> planes = ReadPlanes("select * from Plane;");
            return planes;
        }
        /// <summary>
        /// Read a single flight record.
        /// </summary>
        /// <param name="Id">The primary key of the flight record.</param>
        /// <returns>Returns an object that stores the flight record.</returns>
        private List<Plane> ReadPlanes(string sqlCommandText)
        {
            List<Plane> planes = new List<Plane>();

            using (DbConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                IDbCommand planeReadCommand = databaseConnection.CreateCommand();

                planeReadCommand.CommandText = sqlCommandText;

                databaseConnection.Open();

                IDataReader planeReader = planeReadCommand.ExecuteReader();

                while (planeReader.Read())
                {
                    Plane plane = ParseRecord(planeReader);
                    planes.Add(plane);
                }

                return planes;
            }
        }
        public int TestStoredProcedure()
        {
            using (DbConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                // 1. create a command object identifying the stored procedure
                IDbCommand command = databaseConnection.CreateCommand();
                command.CommandText = "Test";

                // 2. tell the command object to execute a stored procedure
                command.CommandType = CommandType.StoredProcedure;

                databaseConnection.Open();

                int rowCount = command.ExecuteNonQuery();
                return rowCount;
            }
        }
        #endregion

        #region Update
        public int Update(Plane plane)
        {
            using (DbConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                // erzeuge zuerst ein zur Sql Server Connection passendes Command, weise Select Befehl zu
                IDbCommand updatePlaneCommand = databaseConnection.CreateCommand();
                updatePlaneCommand.CommandText =
                   $"update Plane set " +
                   $"OwnershipDate = '{plane.Ownershipdate}', " +
                   $"LastMaintenance = '{plane.LastMaintenance}', " +
                   $"PlaneTypeId = '{plane.PlaneTypeId};" + 
                   $"AirlineId = '{plane.AirlineId};";

                // Console.WriteLine NICHT an dieser Stelle in einem professionellen Programm verwenden, 
                // Methode soll auch bei GUI Anwendungen funktionieren
                Console.WriteLine(updatePlaneCommand.CommandText);

                databaseConnection.Open();

                int rowCount = updatePlaneCommand.ExecuteNonQuery();
                return rowCount;

            }
        }
        #endregion

        #region Delete
        public int Delete(Plane plane)
        {
            return Delete(plane.Id);
        }
        public int Delete(int id)
        {
            using (DbConnection databaseConnection = new SqlConnection(this.ConnectionString))
            {
                IDbCommand deletePlaneCommmand = databaseConnection.CreateCommand();
                deletePlaneCommmand.CommandText = $"delete from Plane where Plane.Id = {id};";

                // Console.WriteLine(deletePlaneCommmand.CommandText);
                databaseConnection.Open();

                int rowCount = deletePlaneCommmand.ExecuteNonQuery();
                return rowCount;
            }
        }
        #endregion
    }
}