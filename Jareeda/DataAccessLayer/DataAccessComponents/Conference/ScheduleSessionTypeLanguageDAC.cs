using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ScheduleSessionTypeLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ScheduleSessionTypeLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ScheduleSessionTypeLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public ScheduleSessionTypeLanguageDAC() : base("", "Conference.ScheduleSessionTypeLanguage") { }
		public ScheduleSessionTypeLanguageDAC(string connectionString): base(connectionString){}
		public ScheduleSessionTypeLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ScheduleSessionTypeLanguage using Stored Procedure
		/// and return a DataTable containing all ScheduleSessionTypeLanguage Data
		/// </summary>
		public DataTable GetAllScheduleSessionTypeLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ScheduleSessionTypeLanguage";
         string query = " select * from GetAllScheduleSessionTypeLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ScheduleSessionTypeLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ScheduleSessionTypeLanguage using Stored Procedure
		/// and return a DataTable containing all ScheduleSessionTypeLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllScheduleSessionTypeLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ScheduleSessionTypeLanguage";
         string query = " select * from GetAllScheduleSessionTypeLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ScheduleSessionTypeLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ScheduleSessionTypeLanguage using Stored Procedure
		/// and return a DataTable containing all ScheduleSessionTypeLanguage Data
		/// </summary>
		public DataTable GetAllScheduleSessionTypeLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ScheduleSessionTypeLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllScheduleSessionTypeLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ScheduleSessionTypeLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ScheduleSessionTypeLanguage using Stored Procedure
		/// and return a DataTable containing all ScheduleSessionTypeLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllScheduleSessionTypeLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ScheduleSessionTypeLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllScheduleSessionTypeLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ScheduleSessionTypeLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ScheduleSessionTypeLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDScheduleSessionTypeLanguage( int scheduleSessionTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDScheduleSessionTypeLanguage");
				    Database.AddInParameter(command,"ScheduleSessionTypeId",DbType.Int32,scheduleSessionTypeId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ScheduleSessionTypeLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDScheduleSessionTypeLanguage( int scheduleSessionTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDScheduleSessionTypeLanguage");
				    Database.AddInParameter(command,"ScheduleSessionTypeId",DbType.Int32,scheduleSessionTypeId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ScheduleSessionTypeLanguage using Stored Procedure
		/// and return the auto number primary key of ScheduleSessionTypeLanguage inserted row
		/// </summary>
		public bool InsertNewScheduleSessionTypeLanguage( ref int scheduleSessionTypeId,  string name,  int conferenceId,  int languageID,  int scheduleSessionTypeParentId)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewScheduleSessionTypeLanguage");
				Database.AddOutParameter(command,"ScheduleSessionTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"ScheduleSessionTypeParentId",DbType.Int32,scheduleSessionTypeParentId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 scheduleSessionTypeId = Convert.ToInt32(Database.GetParameterValue(command, "ScheduleSessionTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ScheduleSessionTypeLanguage using Stored Procedure
		/// and return the auto number primary key of ScheduleSessionTypeLanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewScheduleSessionTypeLanguage( ref int scheduleSessionTypeId,  string name,  int conferenceId,  int languageID,  int scheduleSessionTypeParentId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewScheduleSessionTypeLanguage");
				Database.AddOutParameter(command,"ScheduleSessionTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"ScheduleSessionTypeParentId",DbType.Int32,scheduleSessionTypeParentId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 scheduleSessionTypeId = Convert.ToInt32(Database.GetParameterValue(command, "ScheduleSessionTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ScheduleSessionTypeLanguage using Stored Procedure
		/// and return DbCommand of the ScheduleSessionTypeLanguage
		/// </summary>
		public DbCommand InsertNewScheduleSessionTypeLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewScheduleSessionTypeLanguage");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"ScheduleSessionTypeParentId",DbType.Int32,"ScheduleSessionTypeParentId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ScheduleSessionTypeLanguage using Stored Procedure
		/// </summary>
		public bool UpdateScheduleSessionTypeLanguage( string name, int conferenceId, int languageID, int scheduleSessionTypeParentId, int oldscheduleSessionTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateScheduleSessionTypeLanguage");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"ScheduleSessionTypeParentId",DbType.Int32,scheduleSessionTypeParentId);
				Database.AddInParameter(command,"oldScheduleSessionTypeId",DbType.Int32,oldscheduleSessionTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ScheduleSessionTypeLanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateScheduleSessionTypeLanguage( string name, int conferenceId, int languageID, int scheduleSessionTypeParentId, int oldscheduleSessionTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateScheduleSessionTypeLanguage");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"ScheduleSessionTypeParentId",DbType.Int32,scheduleSessionTypeParentId);
				Database.AddInParameter(command,"oldScheduleSessionTypeId",DbType.Int32,oldscheduleSessionTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ScheduleSessionTypeLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateScheduleSessionTypeLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateScheduleSessionTypeLanguage");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ScheduleSessionTypeParentId",DbType.Int32,"ScheduleSessionTypeParentId",DataRowVersion.Current);
				Database.AddInParameter(command,"oldScheduleSessionTypeId",DbType.Int32,"ScheduleSessionTypeId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ScheduleSessionTypeLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteScheduleSessionTypeLanguage( int scheduleSessionTypeId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteScheduleSessionTypeLanguage");
			Database.AddInParameter(command,"ScheduleSessionTypeId",DbType.Int32,scheduleSessionTypeId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ScheduleSessionTypeLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteScheduleSessionTypeLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteScheduleSessionTypeLanguage");
				Database.AddInParameter(command,"ScheduleSessionTypeId",DbType.Int32,"ScheduleSessionTypeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ScheduleSessionTypeLanguage using Stored Procedure
		/// and return number of rows effected of the ScheduleSessionTypeLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ScheduleSessionTypeLanguage",InsertNewScheduleSessionTypeLanguageCommand(),UpdateScheduleSessionTypeLanguageCommand(),DeleteScheduleSessionTypeLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ScheduleSessionTypeLanguage using Stored Procedure
		/// and return number of rows effected of the ScheduleSessionTypeLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ScheduleSessionTypeLanguage",InsertNewScheduleSessionTypeLanguageCommand(),UpdateScheduleSessionTypeLanguageCommand(),DeleteScheduleSessionTypeLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
