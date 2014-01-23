using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferenceSchedule table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferenceSchedule table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceScheduleDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceScheduleDAC() : base("", "Conference.ConferenceSchedule") { }
		public ConferenceScheduleDAC(string connectionString): base(connectionString){}
		public ConferenceScheduleDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceSchedule using Stored Procedure
		/// and return a DataTable containing all ConferenceSchedule Data
		/// </summary>
		public DataTable GetAllConferenceSchedule()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceSchedule";
         string query = " select * from GetAllConferenceSchedule";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceSchedule"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceSchedule using Stored Procedure
		/// and return a DataTable containing all ConferenceSchedule Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceSchedule(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceSchedule";
         string query = " select * from GetAllConferenceSchedule";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceSchedule"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceSchedule using Stored Procedure
		/// and return a DataTable containing all ConferenceSchedule Data
		/// </summary>
		public DataTable GetAllConferenceSchedule(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceSchedule";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferenceSchedule" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceSchedule"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceSchedule using Stored Procedure
		/// and return a DataTable containing all ConferenceSchedule Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceSchedule(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceSchedule";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferenceSchedule" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceSchedule"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceSchedule using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceSchedule( int scheduleId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceSchedule");
				    Database.AddInParameter(command,"ScheduleId",DbType.Int32,scheduleId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceSchedule using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceSchedule( int scheduleId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceSchedule");
				    Database.AddInParameter(command,"ScheduleId",DbType.Int32,scheduleId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceSchedule using Stored Procedure
		/// and return the auto number primary key of ConferenceSchedule inserted row
		/// </summary>
		public bool InsertNewConferenceSchedule( ref int scheduleId,  int conferenceProgramId,  string title,  int scheduleSessionTypeId,  DateTime startTime,  DateTime endTime,  string speakerName,  int conferenceHallId,  string description,  string allDescription,  int speakerID,  string docPath)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceSchedule");
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
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 scheduleId = Convert.ToInt32(Database.GetParameterValue(command, "ScheduleId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceSchedule using Stored Procedure
		/// and return the auto number primary key of ConferenceSchedule inserted row using Transaction
		/// </summary>
		public bool InsertNewConferenceSchedule( ref int scheduleId,  int conferenceProgramId,  string title,  int scheduleSessionTypeId,  DateTime startTime,  DateTime endTime,  string speakerName,  int conferenceHallId,  string description,  string allDescription,  int speakerID,  string docPath,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceSchedule");
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
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 scheduleId = Convert.ToInt32(Database.GetParameterValue(command, "ScheduleId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceSchedule using Stored Procedure
		/// and return DbCommand of the ConferenceSchedule
		/// </summary>
		public DbCommand InsertNewConferenceScheduleCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceSchedule");

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
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceSchedule using Stored Procedure
		/// </summary>
		public bool UpdateConferenceSchedule( int conferenceProgramId, string title, int scheduleSessionTypeId, DateTime startTime, DateTime endTime, string speakerName, int conferenceHallId, string description, string allDescription, int speakerID, string docPath, int oldscheduleId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceSchedule");

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
				Database.AddInParameter(command,"oldScheduleId",DbType.Int32,oldscheduleId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceSchedule using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateConferenceSchedule( int conferenceProgramId, string title, int scheduleSessionTypeId, DateTime startTime, DateTime endTime, string speakerName, int conferenceHallId, string description, string allDescription, int speakerID, string docPath, int oldscheduleId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceSchedule");

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
				Database.AddInParameter(command,"oldScheduleId",DbType.Int32,oldscheduleId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceSchedule using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceScheduleCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceSchedule");

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
				Database.AddInParameter(command,"oldScheduleId",DbType.Int32,"ScheduleId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceSchedule using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferenceSchedule( int scheduleId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferenceSchedule");
			Database.AddInParameter(command,"ScheduleId",DbType.Int32,scheduleId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceSchedule Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceScheduleCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceSchedule");
				Database.AddInParameter(command,"ScheduleId",DbType.Int32,"ScheduleId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceSchedule using Stored Procedure
		/// and return number of rows effected of the ConferenceSchedule
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceSchedule",InsertNewConferenceScheduleCommand(),UpdateConferenceScheduleCommand(),DeleteConferenceScheduleCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceSchedule using Stored Procedure
		/// and return number of rows effected of the ConferenceSchedule
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceSchedule",InsertNewConferenceScheduleCommand(),UpdateConferenceScheduleCommand(),DeleteConferenceScheduleCommand(), transaction);
          return rowsAffected;
		}


	}
}
