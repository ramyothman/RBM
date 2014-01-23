using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferenceScheduleLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferenceScheduleLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceScheduleLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceScheduleLanguageDAC() : base("", "Conference.ConferenceScheduleLanguage") { }
		public ConferenceScheduleLanguageDAC(string connectionString): base(connectionString){}
		public ConferenceScheduleLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceScheduleLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceScheduleLanguage Data
		/// </summary>
		public DataTable GetAllConferenceScheduleLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceScheduleLanguage";
         string query = " select * from GetAllConferenceScheduleLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceScheduleLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceScheduleLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceScheduleLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceScheduleLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceScheduleLanguage";
         string query = " select * from GetAllConferenceScheduleLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceScheduleLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceScheduleLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceScheduleLanguage Data
		/// </summary>
		public DataTable GetAllConferenceScheduleLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceScheduleLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferenceScheduleLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceScheduleLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceScheduleLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceScheduleLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceScheduleLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceScheduleLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferenceScheduleLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceScheduleLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceScheduleLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceScheduleLanguage( int scheduleId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceScheduleLanguage");
				    Database.AddInParameter(command,"ScheduleId",DbType.Int32,scheduleId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceScheduleLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceScheduleLanguage( int scheduleId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceScheduleLanguage");
				    Database.AddInParameter(command,"ScheduleId",DbType.Int32,scheduleId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceScheduleLanguage using Stored Procedure
		/// and return the auto number primary key of ConferenceScheduleLanguage inserted row
		/// </summary>
		public bool InsertNewConferenceScheduleLanguage( ref int scheduleId,  int conferenceProgramId,  string title,  int scheduleSessionTypeId,  DateTime startTime,  DateTime endTime,  string speakerName,  int conferenceHallId,  string description,  string allDescription,  int speakerID,  string docPath,  int scheduleparentID,  int languageID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceScheduleLanguage");
				Database.AddOutParameter(command,"ScheduleId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceProgramId",DbType.Int32,conferenceProgramId);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"ScheduleSessionTypeId",DbType.Int32,scheduleSessionTypeId);
                if(startTime == DateTime.MinValue)
				    Database.AddInParameter(command,"StartTime",DbType.DateTime,DBNull.Value);
                else
                    Database.AddInParameter(command, "StartTime", DbType.DateTime, startTime);
                if(endTime == DateTime.MinValue)
				    Database.AddInParameter(command,"EndTime",DbType.DateTime,DBNull.Value);
                else
                    Database.AddInParameter(command, "EndTime", DbType.DateTime, endTime);
				Database.AddInParameter(command,"SpeakerName",DbType.String,speakerName);
				Database.AddInParameter(command,"ConferenceHallId",DbType.Int32,conferenceHallId);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"AllDescription",DbType.String,allDescription);
				Database.AddInParameter(command,"SpeakerID",DbType.Int32,speakerID);
				Database.AddInParameter(command,"DocPath",DbType.String,docPath);
				Database.AddInParameter(command,"ScheduleparentID",DbType.Int32,scheduleparentID);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 scheduleId = Convert.ToInt32(Database.GetParameterValue(command, "ScheduleId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceScheduleLanguage using Stored Procedure
		/// and return the auto number primary key of ConferenceScheduleLanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewConferenceScheduleLanguage( ref int scheduleId,  int conferenceProgramId,  string title,  int scheduleSessionTypeId,  DateTime startTime,  DateTime endTime,  string speakerName,  int conferenceHallId,  string description,  string allDescription,  int speakerID,  string docPath,  int scheduleparentID,  int languageID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceScheduleLanguage");
				Database.AddOutParameter(command,"ScheduleId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceProgramId",DbType.Int32,conferenceProgramId);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"ScheduleSessionTypeId",DbType.Int32,scheduleSessionTypeId);
				Database.AddInParameter(command,"StartTime",DbType.DateTime,startTime);
				Database.AddInParameter(command,"EndTime",DbType.DateTime,endTime);
				Database.AddInParameter(command,"SpeakerName",DbType.String,speakerName);
				Database.AddInParameter(command,"ConferenceHallId",DbType.Int32,conferenceHallId);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"AllDescription",DbType.String,allDescription);
				Database.AddInParameter(command,"SpeakerID",DbType.Int32,speakerID);
				Database.AddInParameter(command,"DocPath",DbType.String,docPath);
				Database.AddInParameter(command,"ScheduleparentID",DbType.Int32,scheduleparentID);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 scheduleId = Convert.ToInt32(Database.GetParameterValue(command, "ScheduleId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceScheduleLanguage using Stored Procedure
		/// and return DbCommand of the ConferenceScheduleLanguage
		/// </summary>
		public DbCommand InsertNewConferenceScheduleLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceScheduleLanguage");

				Database.AddInParameter(command,"ConferenceProgramId",DbType.Int32,"ConferenceProgramId",DataRowVersion.Current);
				Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
				Database.AddInParameter(command,"ScheduleSessionTypeId",DbType.Int32,"ScheduleSessionTypeId",DataRowVersion.Current);
				Database.AddInParameter(command,"StartTime",DbType.DateTime,"StartTime",DataRowVersion.Current);
				Database.AddInParameter(command,"EndTime",DbType.DateTime,"EndTime",DataRowVersion.Current);
				Database.AddInParameter(command,"SpeakerName",DbType.String,"SpeakerName",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceHallId",DbType.Int32,"ConferenceHallId",DataRowVersion.Current);
				Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
				Database.AddInParameter(command,"AllDescription",DbType.String,"AllDescription",DataRowVersion.Current);
				Database.AddInParameter(command,"SpeakerID",DbType.Int32,"SpeakerID",DataRowVersion.Current);
				Database.AddInParameter(command,"DocPath",DbType.String,"DocPath",DataRowVersion.Current);
				Database.AddInParameter(command,"ScheduleparentID",DbType.Int32,"ScheduleparentID",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceScheduleLanguage using Stored Procedure
		/// </summary>
		public bool UpdateConferenceScheduleLanguage( int conferenceProgramId, string title, int scheduleSessionTypeId, DateTime startTime, DateTime endTime, string speakerName, int conferenceHallId, string description, string allDescription, int speakerID, string docPath, int scheduleparentID, int languageID, int oldscheduleId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceScheduleLanguage");

		    		Database.AddInParameter(command,"ConferenceProgramId",DbType.Int32,conferenceProgramId);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"ScheduleSessionTypeId",DbType.Int32,scheduleSessionTypeId);
                    if (startTime == DateTime.MinValue)
                        Database.AddInParameter(command, "StartTime", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "StartTime", DbType.DateTime, startTime);
                    if (endTime == DateTime.MinValue)
                        Database.AddInParameter(command, "EndTime", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "EndTime", DbType.DateTime, endTime);
		    		Database.AddInParameter(command,"SpeakerName",DbType.String,speakerName);
		    		Database.AddInParameter(command,"ConferenceHallId",DbType.Int32,conferenceHallId);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"AllDescription",DbType.String,allDescription);
		    		Database.AddInParameter(command,"SpeakerID",DbType.Int32,speakerID);
		    		Database.AddInParameter(command,"DocPath",DbType.String,docPath);
		    		Database.AddInParameter(command,"ScheduleparentID",DbType.Int32,scheduleparentID);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"oldScheduleId",DbType.Int32,oldscheduleId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceScheduleLanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateConferenceScheduleLanguage( int conferenceProgramId, string title, int scheduleSessionTypeId, DateTime startTime, DateTime endTime, string speakerName, int conferenceHallId, string description, string allDescription, int speakerID, string docPath, int scheduleparentID, int languageID, int oldscheduleId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceScheduleLanguage");

		    		Database.AddInParameter(command,"ConferenceProgramId",DbType.Int32,conferenceProgramId);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"ScheduleSessionTypeId",DbType.Int32,scheduleSessionTypeId);
		    		Database.AddInParameter(command,"StartTime",DbType.DateTime,startTime);
		    		Database.AddInParameter(command,"EndTime",DbType.DateTime,endTime);
		    		Database.AddInParameter(command,"SpeakerName",DbType.String,speakerName);
		    		Database.AddInParameter(command,"ConferenceHallId",DbType.Int32,conferenceHallId);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"AllDescription",DbType.String,allDescription);
		    		Database.AddInParameter(command,"SpeakerID",DbType.Int32,speakerID);
		    		Database.AddInParameter(command,"DocPath",DbType.String,docPath);
		    		Database.AddInParameter(command,"ScheduleparentID",DbType.Int32,scheduleparentID);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"oldScheduleId",DbType.Int32,oldscheduleId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceScheduleLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceScheduleLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceScheduleLanguage");

		    		Database.AddInParameter(command,"ConferenceProgramId",DbType.Int32,"ConferenceProgramId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ScheduleSessionTypeId",DbType.Int32,"ScheduleSessionTypeId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"StartTime",DbType.DateTime,"StartTime",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EndTime",DbType.DateTime,"EndTime",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SpeakerName",DbType.String,"SpeakerName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceHallId",DbType.Int32,"ConferenceHallId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AllDescription",DbType.String,"AllDescription",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SpeakerID",DbType.Int32,"SpeakerID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DocPath",DbType.String,"DocPath",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ScheduleparentID",DbType.Int32,"ScheduleparentID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldScheduleId",DbType.Int32,"ScheduleId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceScheduleLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferenceScheduleLanguage( int scheduleId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferenceScheduleLanguage");
			Database.AddInParameter(command,"ScheduleId",DbType.Int32,scheduleId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceScheduleLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceScheduleLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceScheduleLanguage");
				Database.AddInParameter(command,"ScheduleId",DbType.Int32,"ScheduleId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceScheduleLanguage using Stored Procedure
		/// and return number of rows effected of the ConferenceScheduleLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceScheduleLanguage",InsertNewConferenceScheduleLanguageCommand(),UpdateConferenceScheduleLanguageCommand(),DeleteConferenceScheduleLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceScheduleLanguage using Stored Procedure
		/// and return number of rows effected of the ConferenceScheduleLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceScheduleLanguage",InsertNewConferenceScheduleLanguageCommand(),UpdateConferenceScheduleLanguageCommand(),DeleteConferenceScheduleLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
