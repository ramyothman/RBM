using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
    /// <summary>
    /// This is a Data Access Class  for ConferenceSpeakers table This Class is used to
    /// Insert, Update, Delete, Select, GetByID Operations and dealing with
    /// with the database to retrieve or execute any commands on the ConferenceSpeakers table or related views
    /// Last Modified By: Ramy Mostafa
    /// </summary>
    public class ConferenceSpeakersDAC : DataAccessComponent
    {
        #region Constructors
        public ConferenceSpeakersDAC() : base("", "Conference.ConferenceSpeakers") { }
        public ConferenceSpeakersDAC(string connectionString) : base(connectionString) { }
        public ConferenceSpeakersDAC(string connectionStringKey, DatabaseType type) : base(connectionStringKey, type) { }
        #endregion


        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceSpeakers using Stored Procedure
        /// and return a DataTable containing all ConferenceSpeakers Data
        /// </summary>
        public DataTable GetAllConferenceSpeakers()
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ConferenceSpeakers";
            string query = " select * from GetAllConferenceSpeakers" + " Order By SpeakerOrder";
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["ConferenceSpeakers"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceSpeakers using Stored Procedure
        /// and return a DataTable containing all ConferenceSpeakers Data using a Transaction
        /// </summary>
        public DataTable GetAllConferenceSpeakers(DbTransaction transaction)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ConferenceSpeakers";
            string query = " select * from GetAllConferenceSpeakers" + " Order By SpeakerOrder";
            DbCommand command = Database.GetSqlStringCommand(query);
            Database.LoadDataSet(command, ds, tableNames, transaction);
            return ds.Tables["ConferenceSpeakers"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceSpeakers using Stored Procedure
        /// and return a DataTable containing all ConferenceSpeakers Data
        /// </summary>
        public DataTable GetAllConferenceSpeakers(string where)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ConferenceSpeakers";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = " select * from GetAllConferenceSpeakers" + whereClause + " Order By SpeakerOrder";
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["ConferenceSpeakers"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceSpeakers using Stored Procedure
        /// and return a DataTable containing all ConferenceSpeakers Data using a Transaction
        /// </summary>
        public DataTable GetAllConferenceSpeakers(string where, DbTransaction transaction)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ConferenceSpeakers";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = " select * from GetAllConferenceSpeakers" + whereClause;
            DbCommand command = Database.GetSqlStringCommand(query);
            Database.LoadDataSet(command, ds, tableNames, transaction);
            return ds.Tables["ConferenceSpeakers"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceSpeakers using Stored Procedure
        /// and return the Record Object
        /// </summary>
        public System.Data.IDataReader GetByIDConferenceSpeakers(int conferenceSpeakerId)
        {
            DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceSpeakers");
            Database.AddInParameter(command, "ConferenceSpeakerId", DbType.Int32, conferenceSpeakerId);
            IDataReader reader = Database.ExecuteReader(command);
            return reader;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceSpeakers using Stored Procedure
        /// and return the Record Object
        /// </summary>
        public System.Data.IDataReader GetByIDConferenceSpeakers(int conferenceSpeakerId, DbTransaction transaction)
        {
            DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceSpeakers");
            Database.AddInParameter(command, "ConferenceSpeakerId", DbType.Int32, conferenceSpeakerId);
            IDataReader reader = Database.ExecuteReader(command, transaction);
            return reader;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceSpeakers using Stored Procedure
        /// and return the auto number primary key of ConferenceSpeakers inserted row
        /// </summary>
        public bool InsertNewConferenceSpeakers(ref int conferenceSpeakerId, int personId, int conferenceId, DateTime dateRegistered, string speakerImage, string speakerPosition, string speakerBio, string flightfromCountry, string flightFromCity, string flightToCountry, string flightToCity, string flightNO, DateTime arrivalDate, string arrivalTime, DateTime depratureDate, string depratureTime, int airllineID, int hotelID, int responsiblePersonID, string ArrivalTimeAMorPM, string DepratureTimeAMorPM)
        {
            DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceSpeakers");
            Database.AddOutParameter(command, "ConferenceSpeakerId", DbType.Int32, Int32.MaxValue);
            Database.AddInParameter(command, "PersonId", DbType.Int32, personId);
            if(conferenceId==0)
            Database.AddInParameter(command, "ConferenceId", DbType.Int32, DBNull.Value);
            else
                Database.AddInParameter(command, "ConferenceId", DbType.Int32, conferenceId);
            if(dateRegistered==DateTime.MinValue)
                Database.AddInParameter(command, "DateRegistered", DbType.DateTime, DBNull.Value);
            else              
                Database.AddInParameter(command, "DateRegistered", DbType.DateTime, dateRegistered);
            Database.AddInParameter(command, "SpeakerImage", DbType.String, speakerImage);
            Database.AddInParameter(command, "SpeakerPosition", DbType.String, speakerPosition);
            Database.AddInParameter(command, "SpeakerBio", DbType.String, speakerBio);
            Database.AddInParameter(command, "FlightfromCountry", DbType.String, flightfromCountry);
            Database.AddInParameter(command, "FlightFromCity", DbType.String, flightFromCity);
            Database.AddInParameter(command, "FlightToCountry", DbType.String, flightToCountry);
            Database.AddInParameter(command, "FlightToCity", DbType.String, flightToCity);
            Database.AddInParameter(command, "FlightNO", DbType.String, flightNO);
            if (arrivalDate == DateTime.MinValue)
                Database.AddInParameter(command, "ArrivalDate", DbType.DateTime, DBNull.Value);
            else
                Database.AddInParameter(command, "ArrivalDate", DbType.DateTime, arrivalDate);
            Database.AddInParameter(command, "ArrivalTime", DbType.String, arrivalTime);
            if (depratureDate == DateTime.MinValue)
                Database.AddInParameter(command, "DepratureDate", DbType.DateTime, DBNull.Value);
            else
                Database.AddInParameter(command, "DepratureDate", DbType.DateTime, depratureDate);
            Database.AddInParameter(command, "DepratureTime", DbType.String, depratureTime);
            Database.AddInParameter(command, "AirllineID", DbType.Int32, airllineID);
            Database.AddInParameter(command, "HotelID", DbType.Int32, hotelID);
            Database.AddInParameter(command, "ResponsiblePersonID", DbType.Int32, responsiblePersonID);
            Database.AddInParameter(command, "DepratureTimeAMorPM", DbType.String, DepratureTimeAMorPM);
            Database.AddInParameter(command, "ArrivalTimeAMorPM", DbType.String, ArrivalTimeAMorPM);
            bool _status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                _status = true; conferenceSpeakerId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceSpeakerId"));
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceSpeakers using Stored Procedure
        /// and return the auto number primary key of ConferenceSpeakers inserted row using Transaction
        /// </summary>
        public bool InsertNewConferenceSpeakers(ref int conferenceSpeakerId, int personId, int conferenceId, DateTime dateRegistered, string speakerImage, string speakerPosition, string speakerBio, string flightfromCountry, string flightFromCity, string flightToCountry, string flightToCity, string flightNO, DateTime arrivalDate, string arrivalTime, DateTime depratureDate, string depratureTime, int airllineID, int hotelID, int responsiblePersonID, string ArrivalTimeAMorPM, string DepratureTimeAMorPM, DbTransaction transaction)
        {
            DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceSpeakers");
            Database.AddOutParameter(command, "ConferenceSpeakerId", DbType.Int32, Int32.MaxValue);
            Database.AddInParameter(command, "PersonId", DbType.Int32, personId);
            Database.AddInParameter(command, "ConferenceId", DbType.Int32, conferenceId);
            if(dateRegistered==DateTime.MinValue)
                Database.AddInParameter(command, "DateRegistered", DbType.DateTime, DBNull.Value);
            else
                Database.AddInParameter(command, "DateRegistered", DbType.DateTime,dateRegistered);
            Database.AddInParameter(command, "SpeakerImage", DbType.String, speakerImage);
            Database.AddInParameter(command, "SpeakerPosition", DbType.String, speakerPosition);
            Database.AddInParameter(command, "SpeakerBio", DbType.String, speakerBio);
            Database.AddInParameter(command, "FlightfromCountry", DbType.String, flightfromCountry);
            Database.AddInParameter(command, "FlightFromCity", DbType.String, flightFromCity);
            Database.AddInParameter(command, "FlightToCountry", DbType.String, flightToCountry);
            Database.AddInParameter(command, "FlightToCity", DbType.String, flightToCity);
            Database.AddInParameter(command, "FlightNO", DbType.String, flightNO);
            if(arrivalDate==DateTime.MinValue)
                Database.AddInParameter(command, "ArrivalDate", DbType.DateTime, DBNull.Value);
            else
                Database.AddInParameter(command, "ArrivalDate", DbType.DateTime, arrivalDate);
            Database.AddInParameter(command, "ArrivalTime", DbType.String, arrivalTime);
            if(depratureDate==DateTime.MinValue)
                Database.AddInParameter(command, "DepratureDate", DbType.DateTime, DBNull.Value);
            else
                Database.AddInParameter(command, "DepratureDate", DbType.DateTime, depratureDate);
            Database.AddInParameter(command, "DepratureTime", DbType.String, depratureTime);
            Database.AddInParameter(command, "AirllineID", DbType.Int32, airllineID);
            Database.AddInParameter(command, "HotelID", DbType.Int32, hotelID);
            Database.AddInParameter(command, "ResponsiblePersonID", DbType.Int32, responsiblePersonID);
            Database.AddInParameter(command, "DepratureTimeAMorPM", DbType.String, DepratureTimeAMorPM);
            Database.AddInParameter(command, "ArrivalTimeAMorPM", DbType.String, ArrivalTimeAMorPM);
            bool _status = false;
            if (Database.ExecuteNonQuery(command, transaction) > 0)
            {
                _status = true; conferenceSpeakerId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceSpeakerId"));
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceSpeakers using Stored Procedure
        /// and return DbCommand of the ConferenceSpeakers
        /// </summary>
        public DbCommand InsertNewConferenceSpeakersCommand()
        {
            try
            {
                DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceSpeakers");

                Database.AddInParameter(command, "PersonId", DbType.Int32, "PersonId", DataRowVersion.Current);
                Database.AddInParameter(command, "ConferenceId", DbType.Int32, "ConferenceId", DataRowVersion.Current);
                Database.AddInParameter(command, "DateRegistered", DbType.DateTime, "DateRegistered", DataRowVersion.Current);
                Database.AddInParameter(command, "SpeakerImage", DbType.String, "SpeakerImage", DataRowVersion.Current);
                Database.AddInParameter(command, "SpeakerPosition", DbType.String, "SpeakerPosition", DataRowVersion.Current);
                Database.AddInParameter(command, "SpeakerBio", DbType.String, "SpeakerBio", DataRowVersion.Current);
                Database.AddInParameter(command, "FlightfromCountry", DbType.String, "FlightfromCountry", DataRowVersion.Current);
                Database.AddInParameter(command, "FlightFromCity", DbType.String, "FlightFromCity", DataRowVersion.Current);
                Database.AddInParameter(command, "FlightToCountry", DbType.String, "FlightToCountry", DataRowVersion.Current);
                Database.AddInParameter(command, "FlightToCity", DbType.String, "FlightToCity", DataRowVersion.Current);
                Database.AddInParameter(command, "FlightNO", DbType.String, "FlightNO", DataRowVersion.Current);
                Database.AddInParameter(command, "ArrivalDate", DbType.DateTime, "ArrivalDate", DataRowVersion.Current);
                Database.AddInParameter(command, "ArrivalTime", DbType.String, "ArrivalTime", DataRowVersion.Current);
                Database.AddInParameter(command, "DepratureDate", DbType.DateTime, "DepratureDate", DataRowVersion.Current);
                Database.AddInParameter(command, "DepratureTime", DbType.String, "DepratureTime", DataRowVersion.Current);
                Database.AddInParameter(command, "AirllineID", DbType.Int32, "AirllineID", DataRowVersion.Current);
                Database.AddInParameter(command, "HotelID", DbType.Int32, "HotelID", DataRowVersion.Current);
                Database.AddInParameter(command, "ResponsiblePersonID", DbType.Int32, "ResponsiblePersonID", DataRowVersion.Current);
                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceSpeakers using Stored Procedure
        /// </summary>
        public bool UpdateConferenceSpeakers(int personId, int conferenceId, DateTime dateRegistered, string speakerImage, string speakerPosition, string speakerBio, string flightfromCountry, string flightFromCity, string flightToCountry, string flightToCity, string flightNO, DateTime arrivalDate, string arrivalTime, DateTime depratureDate, string depratureTime, int airllineID, int hotelID, int responsiblePersonID, string ArrivalTimeAMorPM, string DepratureTimeAMorPM, int oldconferenceSpeakerId)
        {
            DbCommand command = Database.GetStoredProcCommand("UpdateConferenceSpeakers");

            Database.AddInParameter(command, "PersonId", DbType.Int32, personId);
            Database.AddInParameter(command, "ConferenceId", DbType.Int32, conferenceId);
            if (dateRegistered == DateTime.MinValue)
                Database.AddInParameter(command, "DateRegistered", DbType.DateTime, DBNull.Value);
            else
                Database.AddInParameter(command, "DateRegistered", DbType.DateTime, dateRegistered);
            Database.AddInParameter(command, "SpeakerImage", DbType.String, speakerImage);
            Database.AddInParameter(command, "SpeakerPosition", DbType.String, speakerPosition);
            Database.AddInParameter(command, "SpeakerBio", DbType.String, speakerBio);
            Database.AddInParameter(command, "FlightfromCountry", DbType.String, flightfromCountry);
            Database.AddInParameter(command, "FlightFromCity", DbType.String, flightFromCity);
            Database.AddInParameter(command, "FlightToCountry", DbType.String, flightToCountry);
            Database.AddInParameter(command, "FlightToCity", DbType.String, flightToCity);
            Database.AddInParameter(command, "FlightNO", DbType.String, flightNO);
            if (arrivalDate == DateTime.MinValue)
                Database.AddInParameter(command, "ArrivalDate", DbType.DateTime, DBNull.Value);
            else
                Database.AddInParameter(command, "ArrivalDate", DbType.DateTime, arrivalDate);
            Database.AddInParameter(command, "ArrivalTime", DbType.String, arrivalTime);
            if (depratureDate == DateTime.MinValue)
                Database.AddInParameter(command, "DepratureDate", DbType.DateTime, DBNull.Value);
            else
                Database.AddInParameter(command, "DepratureDate", DbType.DateTime, depratureDate);
            Database.AddInParameter(command, "DepratureTime", DbType.String, depratureTime);
            Database.AddInParameter(command, "AirllineID", DbType.Int32, airllineID);
            Database.AddInParameter(command, "HotelID", DbType.Int32, hotelID);
            Database.AddInParameter(command, "ResponsiblePersonID", DbType.Int32, responsiblePersonID);
            Database.AddInParameter(command, "ArrivalTimeAMorPM", DbType.String, ArrivalTimeAMorPM);
            Database.AddInParameter(command, "DepratureTimeAMorPM", DbType.String, DepratureTimeAMorPM);
            Database.AddInParameter(command, "oldConferenceSpeakerId", DbType.Int32, oldconferenceSpeakerId);

            bool _status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                _status = true;
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceSpeakers using Stored Procedure By Transaction
        /// </summary>
        public bool UpdateConferenceSpeakers(int personId, int conferenceId, DateTime dateRegistered, string speakerImage, string speakerPosition, string speakerBio, string flightfromCountry, string flightFromCity, string flightToCountry, string flightToCity, string flightNO, DateTime arrivalDate, string arrivalTime, DateTime depratureDate, string depratureTime, int airllineID, int hotelID, int responsiblePersonID, int oldconferenceSpeakerId, DbTransaction transaction)
        {
            DbCommand command = Database.GetStoredProcCommand("UpdateConferenceSpeakers");

            Database.AddInParameter(command, "PersonId", DbType.Int32, personId);
            Database.AddInParameter(command, "ConferenceId", DbType.Int32, conferenceId);
            if (dateRegistered == DateTime.MinValue)
                Database.AddInParameter(command, "DateRegistered", DbType.DateTime, DBNull.Value);
            else
                Database.AddInParameter(command, "DateRegistered", DbType.DateTime, dateRegistered);
            Database.AddInParameter(command, "SpeakerImage", DbType.String, speakerImage);
            Database.AddInParameter(command, "SpeakerPosition", DbType.String, speakerPosition);
            Database.AddInParameter(command, "SpeakerBio", DbType.String, speakerBio);
            Database.AddInParameter(command, "FlightfromCountry", DbType.String, flightfromCountry);
            Database.AddInParameter(command, "FlightFromCity", DbType.String, flightFromCity);
            Database.AddInParameter(command, "FlightToCountry", DbType.String, flightToCountry);
            Database.AddInParameter(command, "FlightToCity", DbType.String, flightToCity);
            Database.AddInParameter(command, "FlightNO", DbType.String, flightNO);
            if (arrivalDate == DateTime.MinValue)
                Database.AddInParameter(command, "ArrivalDate", DbType.DateTime, DBNull.Value);
            else
                Database.AddInParameter(command, "ArrivalDate", DbType.DateTime, arrivalDate);
            Database.AddInParameter(command, "ArrivalTime", DbType.String, arrivalTime);
            if (depratureDate == DateTime.MinValue)
                Database.AddInParameter(command, "DepratureDate", DbType.DateTime, DBNull.Value);
            else
                Database.AddInParameter(command, "DepratureDate", DbType.DateTime, depratureDate);           
            Database.AddInParameter(command, "DepratureTime", DbType.String, depratureTime);
            Database.AddInParameter(command, "AirllineID", DbType.Int32, airllineID);
            Database.AddInParameter(command, "HotelID", DbType.Int32, hotelID);
            Database.AddInParameter(command, "ResponsiblePersonID", DbType.Int32, responsiblePersonID);

            Database.AddInParameter(command, "oldConferenceSpeakerId", DbType.Int32, oldconferenceSpeakerId);

            bool _status = false;
            if (Database.ExecuteNonQuery(command, transaction) > 0)
            {
                _status = true;
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceSpeakers using Stored Procedure
        /// </summary>
        public DbCommand UpdateConferenceSpeakersCommand()
        {
            try
            {
                DbCommand command = Database.GetStoredProcCommand("UpdateConferenceSpeakers");

                Database.AddInParameter(command, "PersonId", DbType.Int32, "PersonId", DataRowVersion.Current);
                Database.AddInParameter(command, "ConferenceId", DbType.Int32, "ConferenceId", DataRowVersion.Current);
                Database.AddInParameter(command, "DateRegistered", DbType.DateTime, "DateRegistered", DataRowVersion.Current);
                Database.AddInParameter(command, "SpeakerImage", DbType.String, "SpeakerImage", DataRowVersion.Current);
                Database.AddInParameter(command, "SpeakerPosition", DbType.String, "SpeakerPosition", DataRowVersion.Current);
                Database.AddInParameter(command, "SpeakerBio", DbType.String, "SpeakerBio", DataRowVersion.Current);
                Database.AddInParameter(command, "FlightfromCountry", DbType.String, "FlightfromCountry", DataRowVersion.Current);
                Database.AddInParameter(command, "FlightFromCity", DbType.String, "FlightFromCity", DataRowVersion.Current);
                Database.AddInParameter(command, "FlightToCountry", DbType.String, "FlightToCountry", DataRowVersion.Current);
                Database.AddInParameter(command, "FlightToCity", DbType.String, "FlightToCity", DataRowVersion.Current);
                Database.AddInParameter(command, "FlightNO", DbType.String, "FlightNO", DataRowVersion.Current);
                Database.AddInParameter(command, "ArrivalDate", DbType.DateTime, "ArrivalDate", DataRowVersion.Current);
                Database.AddInParameter(command, "ArrivalTime", DbType.String, "ArrivalTime", DataRowVersion.Current);
                Database.AddInParameter(command, "DepratureDate", DbType.DateTime, "DepratureDate", DataRowVersion.Current);
                Database.AddInParameter(command, "DepratureTime", DbType.String, "DepratureTime", DataRowVersion.Current);
                Database.AddInParameter(command, "AirllineID", DbType.Int32, "AirllineID", DataRowVersion.Current);
                Database.AddInParameter(command, "HotelID", DbType.Int32, "HotelID", DataRowVersion.Current);
                Database.AddInParameter(command, "ResponsiblePersonID", DbType.Int32, "ResponsiblePersonID", DataRowVersion.Current);
                Database.AddInParameter(command, "oldConferenceSpeakerId", DbType.Int32, "ConferenceSpeakerId", DataRowVersion.Current);

                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceSpeakers using Stored Procedure
        /// and return boolean Whether the record was deleted or not
        /// </summary>
        public bool DeleteConferenceSpeakers(int conferenceSpeakerId)
        {
            DbCommand command = Database.GetStoredProcCommand("DeleteConferenceSpeakers");
            Database.AddInParameter(command, "ConferenceSpeakerId", DbType.Int32, conferenceSpeakerId);
            bool status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                status = true;
            }
            return status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceSpeakers Delete Stored Procedure
        /// and return DbCommand Init the delete command
        /// </summary>
        public DbCommand DeleteConferenceSpeakersCommand()
        {
            try
            {
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceSpeakers");
                Database.AddInParameter(command, "ConferenceSpeakerId", DbType.Int32, "ConferenceSpeakerId", DataRowVersion.Current);
                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceSpeakers using Stored Procedure
        /// and return number of rows effected of the ConferenceSpeakers
        /// </summary>
        public int UpdateDataset(System.Data.DataSet dataset)
        {
            int rowsAffected = 0;
            rowsAffected = Database.UpdateDataSet(dataset, "ConferenceSpeakers", InsertNewConferenceSpeakersCommand(), UpdateConferenceSpeakersCommand(), DeleteConferenceSpeakersCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
            return rowsAffected;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceSpeakers using Stored Procedure
        /// and return number of rows effected of the ConferenceSpeakers
        /// </summary>
        public int UpdateDataset(System.Data.DataSet dataset, DbTransaction transaction)
        {
            int rowsAffected = 0;
            rowsAffected = Database.UpdateDataSet(dataset, "ConferenceSpeakers", InsertNewConferenceSpeakersCommand(), UpdateConferenceSpeakersCommand(), DeleteConferenceSpeakersCommand(), transaction);
            return rowsAffected;
        }


    }
}
