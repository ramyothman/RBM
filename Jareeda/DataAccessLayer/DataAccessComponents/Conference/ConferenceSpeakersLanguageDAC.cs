using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferenceSpeakersLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferenceSpeakersLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceSpeakersLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceSpeakersLanguageDAC() : base("", "Conference.ConferenceSpeakersLanguage") { }
		public ConferenceSpeakersLanguageDAC(string connectionString): base(connectionString){}
		public ConferenceSpeakersLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceSpeakersLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceSpeakersLanguage Data
		/// </summary>
		public DataTable GetAllConferenceSpeakersLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceSpeakersLanguage";
         string query = " select * from GetAllConferenceSpeakersLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceSpeakersLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceSpeakersLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceSpeakersLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceSpeakersLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceSpeakersLanguage";
         string query = " select * from GetAllConferenceSpeakersLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceSpeakersLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceSpeakersLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceSpeakersLanguage Data
		/// </summary>
		public DataTable GetAllConferenceSpeakersLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceSpeakersLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferenceSpeakersLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceSpeakersLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceSpeakersLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceSpeakersLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceSpeakersLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceSpeakersLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferenceSpeakersLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceSpeakersLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceSpeakersLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceSpeakersLanguage( int conferenceSpeakerId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceSpeakersLanguage");
				    Database.AddInParameter(command,"ConferenceSpeakerId",DbType.Int32,conferenceSpeakerId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceSpeakersLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceSpeakersLanguage( int conferenceSpeakerId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceSpeakersLanguage");
				    Database.AddInParameter(command,"ConferenceSpeakerId",DbType.Int32,conferenceSpeakerId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceSpeakersLanguage using Stored Procedure
		/// and return the auto number primary key of ConferenceSpeakersLanguage inserted row
		/// </summary>
		public bool InsertNewConferenceSpeakersLanguage( ref int conferenceSpeakerId,  int personId,  int conferenceId,  DateTime dateRegistered,  string speakerImage,  string speakerPosition,  string speakerBio,  string flightfromCountry,  string flightFromCity,  string flightToCountry,  string flightToCity,  string flightNO,  DateTime arrivalDate,  string arrivalTime,  DateTime depratureDate,  string depratureTime,  int airllineID,  int hotelID,  int responsiblePersonID,  string arrivalTimeAMorPM,  string depratureTimeAMorPM,  int languageID,  int conferenceSpeakerParentId)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceSpeakersLanguage");
                 Database.AddOutParameter(command, "ConferenceSpeakerId", DbType.Int32, Int32.MaxValue);
                 Database.AddInParameter(command, "PersonId", DbType.Int32, personId);
                 if (conferenceId == 0)
                     Database.AddInParameter(command, "ConferenceId", DbType.Int32, DBNull.Value);
                 else
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
				Database.AddInParameter(command,"DepratureTime",DbType.String,depratureTime);
				Database.AddInParameter(command,"AirllineID",DbType.Int32,airllineID);
				Database.AddInParameter(command,"HotelID",DbType.Int32,hotelID);
				Database.AddInParameter(command,"ResponsiblePersonID",DbType.Int32,responsiblePersonID);
				Database.AddInParameter(command,"ArrivalTimeAMorPM",DbType.String,arrivalTimeAMorPM);
				Database.AddInParameter(command,"DepratureTimeAMorPM",DbType.String,depratureTimeAMorPM);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"ConferenceSpeakerParentId",DbType.Int32,conferenceSpeakerParentId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceSpeakerId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceSpeakerId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceSpeakersLanguage using Stored Procedure
		/// and return the auto number primary key of ConferenceSpeakersLanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewConferenceSpeakersLanguage( ref int conferenceSpeakerId,  int personId,  int conferenceId,  DateTime dateRegistered,  string speakerImage,  string speakerPosition,  string speakerBio,  string flightfromCountry,  string flightFromCity,  string flightToCountry,  string flightToCity,  string flightNO,  DateTime arrivalDate,  string arrivalTime,  DateTime depratureDate,  string depratureTime,  int airllineID,  int hotelID,  int responsiblePersonID,  string arrivalTimeAMorPM,  string depratureTimeAMorPM,  int languageID,  int conferenceSpeakerParentId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceSpeakersLanguage");
                 Database.AddOutParameter(command, "ConferenceSpeakerId", DbType.Int32, Int32.MaxValue);
                 Database.AddInParameter(command, "PersonId", DbType.Int32, personId);
                 if (conferenceId == 0)
                     Database.AddInParameter(command, "ConferenceId", DbType.Int32, DBNull.Value);
                 else
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
				Database.AddInParameter(command,"DepratureTime",DbType.String,depratureTime);
				Database.AddInParameter(command,"AirllineID",DbType.Int32,airllineID);
				Database.AddInParameter(command,"HotelID",DbType.Int32,hotelID);
				Database.AddInParameter(command,"ResponsiblePersonID",DbType.Int32,responsiblePersonID);
				Database.AddInParameter(command,"ArrivalTimeAMorPM",DbType.String,arrivalTimeAMorPM);
				Database.AddInParameter(command,"DepratureTimeAMorPM",DbType.String,depratureTimeAMorPM);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"ConferenceSpeakerParentId",DbType.Int32,conferenceSpeakerParentId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceSpeakerId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceSpeakerId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceSpeakersLanguage using Stored Procedure
		/// and return DbCommand of the ConferenceSpeakersLanguage
		/// </summary>
		public DbCommand InsertNewConferenceSpeakersLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceSpeakersLanguage");

				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"DateRegistered",DbType.DateTime,"DateRegistered",DataRowVersion.Current);
				Database.AddInParameter(command,"SpeakerImage",DbType.String,"SpeakerImage",DataRowVersion.Current);
				Database.AddInParameter(command,"SpeakerPosition",DbType.String,"SpeakerPosition",DataRowVersion.Current);
				Database.AddInParameter(command,"SpeakerBio",DbType.String,"SpeakerBio",DataRowVersion.Current);
				Database.AddInParameter(command,"FlightfromCountry",DbType.String,"FlightfromCountry",DataRowVersion.Current);
				Database.AddInParameter(command,"FlightFromCity",DbType.String,"FlightFromCity",DataRowVersion.Current);
				Database.AddInParameter(command,"FlightToCountry",DbType.String,"FlightToCountry",DataRowVersion.Current);
				Database.AddInParameter(command,"FlightToCity",DbType.String,"FlightToCity",DataRowVersion.Current);
				Database.AddInParameter(command,"FlightNO",DbType.String,"FlightNO",DataRowVersion.Current);
				Database.AddInParameter(command,"ArrivalDate",DbType.DateTime,"ArrivalDate",DataRowVersion.Current);
				Database.AddInParameter(command,"ArrivalTime",DbType.String,"ArrivalTime",DataRowVersion.Current);
				Database.AddInParameter(command,"DepratureDate",DbType.DateTime,"DepratureDate",DataRowVersion.Current);
				Database.AddInParameter(command,"DepratureTime",DbType.String,"DepratureTime",DataRowVersion.Current);
				Database.AddInParameter(command,"AirllineID",DbType.Int32,"AirllineID",DataRowVersion.Current);
				Database.AddInParameter(command,"HotelID",DbType.Int32,"HotelID",DataRowVersion.Current);
				Database.AddInParameter(command,"ResponsiblePersonID",DbType.Int32,"ResponsiblePersonID",DataRowVersion.Current);
				Database.AddInParameter(command,"ArrivalTimeAMorPM",DbType.String,"ArrivalTimeAMorPM",DataRowVersion.Current);
				Database.AddInParameter(command,"DepratureTimeAMorPM",DbType.String,"DepratureTimeAMorPM",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceSpeakerParentId",DbType.Int32,"ConferenceSpeakerParentId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceSpeakersLanguage using Stored Procedure
		/// </summary>
		public bool UpdateConferenceSpeakersLanguage( int personId, int conferenceId, DateTime dateRegistered, string speakerImage, string speakerPosition, string speakerBio, string flightfromCountry, string flightFromCity, string flightToCountry, string flightToCity, string flightNO, DateTime arrivalDate, string arrivalTime, DateTime depratureDate, string depratureTime, int airllineID, int hotelID, int responsiblePersonID, string arrivalTimeAMorPM, string depratureTimeAMorPM, int languageID, int conferenceSpeakerParentId, int oldconferenceSpeakerId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceSpeakersLanguage");

            
                 Database.AddInParameter(command, "PersonId", DbType.Int32, personId);
                 if (conferenceId == 0)
                     Database.AddInParameter(command, "ConferenceId", DbType.Int32, DBNull.Value);
                 else
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
		    		Database.AddInParameter(command,"DepratureTime",DbType.String,depratureTime);
		    		Database.AddInParameter(command,"AirllineID",DbType.Int32,airllineID);
		    		Database.AddInParameter(command,"HotelID",DbType.Int32,hotelID);
		    		Database.AddInParameter(command,"ResponsiblePersonID",DbType.Int32,responsiblePersonID);
		    		Database.AddInParameter(command,"ArrivalTimeAMorPM",DbType.String,arrivalTimeAMorPM);
		    		Database.AddInParameter(command,"DepratureTimeAMorPM",DbType.String,depratureTimeAMorPM);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"ConferenceSpeakerParentId",DbType.Int32,conferenceSpeakerParentId);
				Database.AddInParameter(command,"oldConferenceSpeakerId",DbType.Int32,oldconferenceSpeakerId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceSpeakersLanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateConferenceSpeakersLanguage( int personId, int conferenceId, DateTime dateRegistered, string speakerImage, string speakerPosition, string speakerBio, string flightfromCountry, string flightFromCity, string flightToCountry, string flightToCity, string flightNO, DateTime arrivalDate, string arrivalTime, DateTime depratureDate, string depratureTime, int airllineID, int hotelID, int responsiblePersonID, string arrivalTimeAMorPM, string depratureTimeAMorPM, int languageID, int conferenceSpeakerParentId, int oldconferenceSpeakerId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceSpeakersLanguage");

                 Database.AddOutParameter(command, "ConferenceSpeakerId", DbType.Int32, Int32.MaxValue);
                 Database.AddInParameter(command, "PersonId", DbType.Int32, personId);
                 if (conferenceId == 0)
                     Database.AddInParameter(command, "ConferenceId", DbType.Int32, DBNull.Value);
                 else
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
		    		Database.AddInParameter(command,"DepratureTime",DbType.String,depratureTime);
		    		Database.AddInParameter(command,"AirllineID",DbType.Int32,airllineID);
		    		Database.AddInParameter(command,"HotelID",DbType.Int32,hotelID);
		    		Database.AddInParameter(command,"ResponsiblePersonID",DbType.Int32,responsiblePersonID);
		    		Database.AddInParameter(command,"ArrivalTimeAMorPM",DbType.String,arrivalTimeAMorPM);
		    		Database.AddInParameter(command,"DepratureTimeAMorPM",DbType.String,depratureTimeAMorPM);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"ConferenceSpeakerParentId",DbType.Int32,conferenceSpeakerParentId);
				Database.AddInParameter(command,"oldConferenceSpeakerId",DbType.Int32,oldconferenceSpeakerId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceSpeakersLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceSpeakersLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceSpeakersLanguage");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DateRegistered",DbType.DateTime,"DateRegistered",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SpeakerImage",DbType.String,"SpeakerImage",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SpeakerPosition",DbType.String,"SpeakerPosition",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SpeakerBio",DbType.String,"SpeakerBio",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FlightfromCountry",DbType.String,"FlightfromCountry",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FlightFromCity",DbType.String,"FlightFromCity",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FlightToCountry",DbType.String,"FlightToCountry",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FlightToCity",DbType.String,"FlightToCity",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FlightNO",DbType.String,"FlightNO",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ArrivalDate",DbType.DateTime,"ArrivalDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ArrivalTime",DbType.String,"ArrivalTime",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DepratureDate",DbType.DateTime,"DepratureDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DepratureTime",DbType.String,"DepratureTime",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AirllineID",DbType.Int32,"AirllineID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"HotelID",DbType.Int32,"HotelID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ResponsiblePersonID",DbType.Int32,"ResponsiblePersonID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ArrivalTimeAMorPM",DbType.String,"ArrivalTimeAMorPM",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DepratureTimeAMorPM",DbType.String,"DepratureTimeAMorPM",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceSpeakerParentId",DbType.Int32,"ConferenceSpeakerParentId",DataRowVersion.Current);
				Database.AddInParameter(command,"oldConferenceSpeakerId",DbType.Int32,"ConferenceSpeakerId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceSpeakersLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferenceSpeakersLanguage( int conferenceSpeakerId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferenceSpeakersLanguage");
			Database.AddInParameter(command,"ConferenceSpeakerId",DbType.Int32,conferenceSpeakerId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceSpeakersLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceSpeakersLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceSpeakersLanguage");
				Database.AddInParameter(command,"ConferenceSpeakerId",DbType.Int32,"ConferenceSpeakerId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceSpeakersLanguage using Stored Procedure
		/// and return number of rows effected of the ConferenceSpeakersLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceSpeakersLanguage",InsertNewConferenceSpeakersLanguageCommand(),UpdateConferenceSpeakersLanguageCommand(),DeleteConferenceSpeakersLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceSpeakersLanguage using Stored Procedure
		/// and return number of rows effected of the ConferenceSpeakersLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceSpeakersLanguage",InsertNewConferenceSpeakersLanguageCommand(),UpdateConferenceSpeakersLanguageCommand(),DeleteConferenceSpeakersLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
