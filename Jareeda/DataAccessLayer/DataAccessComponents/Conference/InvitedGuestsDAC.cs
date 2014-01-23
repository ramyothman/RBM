using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
    /// <summary>
    /// This is a Data Access Class  for InvitedGuests table This Class is used to
    /// Insert, Update, Delete, Select, GetByID Operations and dealing with
    /// with the database to retrieve or execute any commands on the InvitedGuests table or related views
    /// Last Modified By: Ramy Mostafa
    /// </summary>
    public class InvitedGuestsDAC : DataAccessComponent
    {
        #region Constructors
        public InvitedGuestsDAC() : base("", "Conference.InvitedGuests") { }
        public InvitedGuestsDAC(string connectionString) : base(connectionString) { }
        public InvitedGuestsDAC(string connectionStringKey, DatabaseType type) : base(connectionStringKey, type) { }
        #endregion


        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all InvitedGuests using Stored Procedure
        /// and return a DataTable containing all InvitedGuests Data
        /// </summary>
        public DataTable GetAllInvitedGuests()
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "InvitedGuests";
            string query = " select * from GetAllInvitedGuests";
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["InvitedGuests"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all InvitedGuests using Stored Procedure
        /// and return a DataTable containing all InvitedGuests Data using a Transaction
        /// </summary>
        public DataTable GetAllInvitedGuests(DbTransaction transaction)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "InvitedGuests";
            string query = " select * from GetAllInvitedGuests";
            DbCommand command = Database.GetSqlStringCommand(query);
            Database.LoadDataSet(command, ds, tableNames, transaction);
            return ds.Tables["InvitedGuests"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all InvitedGuests using Stored Procedure
        /// and return a DataTable containing all InvitedGuests Data
        /// </summary>
        public DataTable GetAllInvitedGuests(string where)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "InvitedGuests";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = " select * from GetAllInvitedGuests" + whereClause;
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["InvitedGuests"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all InvitedGuests using Stored Procedure
        /// and return a DataTable containing all InvitedGuests Data using a Transaction
        /// </summary>
        public DataTable GetAllInvitedGuests(string where, DbTransaction transaction)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "InvitedGuests";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = " select * from GetAllInvitedGuests" + whereClause;
            DbCommand command = Database.GetSqlStringCommand(query);
            Database.LoadDataSet(command, ds, tableNames, transaction);
            return ds.Tables["InvitedGuests"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From InvitedGuests using Stored Procedure
        /// and return the Record Object
        /// </summary>
        public System.Data.IDataReader GetByIDInvitedGuests(int iD)
        {
            DbCommand command = Database.GetStoredProcCommand("GetByIDInvitedGuests");
            Database.AddInParameter(command, "ID", DbType.Int32, iD);
            IDataReader reader = Database.ExecuteReader(command);
            return reader;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From InvitedGuests using Stored Procedure
        /// and return the Record Object
        /// </summary>
        public System.Data.IDataReader GetByIDInvitedGuests(int iD, DbTransaction transaction)
        {
            DbCommand command = Database.GetStoredProcCommand("GetByIDInvitedGuests");
            Database.AddInParameter(command, "ID", DbType.Int32, iD);
            IDataReader reader = Database.ExecuteReader(command, transaction);
            return reader;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into InvitedGuests using Stored Procedure
        /// and return the auto number primary key of InvitedGuests inserted row
        /// </summary>
        public bool InsertNewInvitedGuests(ref int iD, int personId, int conferenceId, DateTime dateRegistered, string speakerImage, string speakerPosition, string speakerBio, string flightfromCountry, string flightFromCity, string flightToCountry, string flightToCity, string flightNO, DateTime arrivalDate, string arrivalTime, DateTime depratureDate, string depratureTime, int airllineID, int hotelID, int responsiblePersonID,string ArrivalTimeAMorPM, string DepratureTimeAMorPM)
        {
            DbCommand command = Database.GetStoredProcCommand("InsertNewInvitedGuests");
            Database.AddOutParameter(command, "ID", DbType.Int32, Int32.MaxValue);
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
            bool _status = false;

            if (Database.ExecuteNonQuery(command) > 0)
            {
                _status = true; iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into InvitedGuests using Stored Procedure
        /// and return the auto number primary key of InvitedGuests inserted row using Transaction
        /// </summary>
        public bool InsertNewInvitedGuests(ref int iD, int personId, int conferenceId, DateTime dateRegistered, string speakerImage, string speakerPosition, string speakerBio, string flightfromCountry, string flightFromCity, string flightToCountry, string flightToCity, string flightNO, DateTime arrivalDate, string arrivalTime, DateTime depratureDate, string depratureTime, int airllineID, int hotelID, int responsiblePersonID, DbTransaction transaction)
        {
            DbCommand command = Database.GetStoredProcCommand("InsertNewInvitedGuests");
            Database.AddOutParameter(command, "ID", DbType.Int32, Int32.MaxValue);
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
            bool _status = false;
            if (Database.ExecuteNonQuery(command, transaction) > 0)
            {
                _status = true; iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for InvitedGuests using Stored Procedure
        /// and return DbCommand of the InvitedGuests
        /// </summary>
        public DbCommand InsertNewInvitedGuestsCommand()
        {
            try
            {
                DbCommand command = Database.GetStoredProcCommand("InsertNewInvitedGuests");

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
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into InvitedGuests using Stored Procedure
        /// </summary>
        public bool UpdateInvitedGuests(int personId, int conferenceId, DateTime dateRegistered, string speakerImage, string speakerPosition, string speakerBio, string flightfromCountry, string flightFromCity, string flightToCountry, string flightToCity, string flightNO, DateTime arrivalDate, string arrivalTime, DateTime depratureDate, string depratureTime, int airllineID, int hotelID, int responsiblePersonID, string ArrivalTimeAMorPM, string DepratureTimeAMorPM, int oldiD)
        {
            DbCommand command = Database.GetStoredProcCommand("UpdateInvitedGuests");

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
            Database.AddInParameter(command, "oldID", DbType.Int32, oldiD);

            bool _status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                _status = true;
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into InvitedGuests using Stored Procedure By Transaction
        /// </summary>
        public bool UpdateInvitedGuests(int personId, int conferenceId, DateTime dateRegistered, string speakerImage, string speakerPosition, string speakerBio, string flightfromCountry, string flightFromCity, string flightToCountry, string flightToCity, string flightNO, DateTime arrivalDate, string arrivalTime, DateTime depratureDate, string depratureTime, int airllineID, int hotelID, int responsiblePersonID, int oldiD, DbTransaction transaction)
        {
            DbCommand command = Database.GetStoredProcCommand("UpdateInvitedGuests");

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
            Database.AddInParameter(command, "oldID", DbType.Int32, oldiD);

            bool _status = false;
            if (Database.ExecuteNonQuery(command, transaction) > 0)
            {
                _status = true;
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from InvitedGuests using Stored Procedure
        /// </summary>
        public DbCommand UpdateInvitedGuestsCommand()
        {
            try
            {
                DbCommand command = Database.GetStoredProcCommand("UpdateInvitedGuests");

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
                Database.AddInParameter(command, "oldID", DbType.Int32, "ID", DataRowVersion.Current);

                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From InvitedGuests using Stored Procedure
        /// and return boolean Whether the record was deleted or not
        /// </summary>
        public bool DeleteInvitedGuests(int iD)
        {
            DbCommand command = Database.GetStoredProcCommand("DeleteInvitedGuests");
            Database.AddInParameter(command, "ID", DbType.Int32, iD);
            bool status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                status = true;
            }
            return status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From InvitedGuests Delete Stored Procedure
        /// and return DbCommand Init the delete command
        /// </summary>
        public DbCommand DeleteInvitedGuestsCommand()
        {
            try
            {
                DbCommand command = Database.GetStoredProcCommand("DeleteInvitedGuests");
                Database.AddInParameter(command, "ID", DbType.Int32, "ID", DataRowVersion.Current);
                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table InvitedGuests using Stored Procedure
        /// and return number of rows effected of the InvitedGuests
        /// </summary>
        public int UpdateDataset(System.Data.DataSet dataset)
        {
            int rowsAffected = 0;
            rowsAffected = Database.UpdateDataSet(dataset, "InvitedGuests", InsertNewInvitedGuestsCommand(), UpdateInvitedGuestsCommand(), DeleteInvitedGuestsCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
            return rowsAffected;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table InvitedGuests using Stored Procedure
        /// and return number of rows effected of the InvitedGuests
        /// </summary>
        public int UpdateDataset(System.Data.DataSet dataset, DbTransaction transaction)
        {
            int rowsAffected = 0;
            rowsAffected = Database.UpdateDataSet(dataset, "InvitedGuests", InsertNewInvitedGuestsCommand(), UpdateInvitedGuestsCommand(), DeleteInvitedGuestsCommand(), transaction);
            return rowsAffected;
        }


    }
}
