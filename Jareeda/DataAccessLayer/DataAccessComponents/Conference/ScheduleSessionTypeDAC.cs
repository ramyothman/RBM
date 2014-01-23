using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ScheduleSessionType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ScheduleSessionType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ScheduleSessionTypeDAC : DataAccessComponent
	{
		#region Constructors
        public ScheduleSessionTypeDAC() : base("", "Conference.ScheduleSessionType") { }
		public ScheduleSessionTypeDAC(string connectionString): base(connectionString){}
		public ScheduleSessionTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ScheduleSessionType using Stored Procedure
		/// and return a DataTable containing all ScheduleSessionType Data
		/// </summary>
		public DataTable GetAllScheduleSessionType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ScheduleSessionType";
         string query = " select * from GetAllScheduleSessionType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ScheduleSessionType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ScheduleSessionType using Stored Procedure
		/// and return a DataTable containing all ScheduleSessionType Data using a Transaction
		/// </summary>
		public DataTable GetAllScheduleSessionType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ScheduleSessionType";
         string query = " select * from GetAllScheduleSessionType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ScheduleSessionType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ScheduleSessionType using Stored Procedure
		/// and return a DataTable containing all ScheduleSessionType Data
		/// </summary>
		public DataTable GetAllScheduleSessionType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ScheduleSessionType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllScheduleSessionType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ScheduleSessionType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ScheduleSessionType using Stored Procedure
		/// and return a DataTable containing all ScheduleSessionType Data using a Transaction
		/// </summary>
		public DataTable GetAllScheduleSessionType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ScheduleSessionType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllScheduleSessionType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ScheduleSessionType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ScheduleSessionType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDScheduleSessionType( int scheduleSessionTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDScheduleSessionType");
				    Database.AddInParameter(command,"ScheduleSessionTypeId",DbType.Int32,scheduleSessionTypeId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ScheduleSessionType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDScheduleSessionType( int scheduleSessionTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDScheduleSessionType");
				    Database.AddInParameter(command,"ScheduleSessionTypeId",DbType.Int32,scheduleSessionTypeId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ScheduleSessionType using Stored Procedure
		/// and return the auto number primary key of ScheduleSessionType inserted row
		/// </summary>
		public bool InsertNewScheduleSessionType( ref int scheduleSessionTypeId,  string name,  int conferenceId)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewScheduleSessionType");
				Database.AddOutParameter(command,"ScheduleSessionTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 scheduleSessionTypeId = Convert.ToInt32(Database.GetParameterValue(command, "ScheduleSessionTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ScheduleSessionType using Stored Procedure
		/// and return the auto number primary key of ScheduleSessionType inserted row using Transaction
		/// </summary>
		public bool InsertNewScheduleSessionType( ref int scheduleSessionTypeId,  string name,  int conferenceId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewScheduleSessionType");
				Database.AddOutParameter(command,"ScheduleSessionTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 scheduleSessionTypeId = Convert.ToInt32(Database.GetParameterValue(command, "ScheduleSessionTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ScheduleSessionType using Stored Procedure
		/// and return DbCommand of the ScheduleSessionType
		/// </summary>
		public DbCommand InsertNewScheduleSessionTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewScheduleSessionType");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ScheduleSessionType using Stored Procedure
		/// </summary>
		public bool UpdateScheduleSessionType( string name, int conferenceId, int oldscheduleSessionTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateScheduleSessionType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"oldScheduleSessionTypeId",DbType.Int32,oldscheduleSessionTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ScheduleSessionType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateScheduleSessionType( string name, int conferenceId, int oldscheduleSessionTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateScheduleSessionType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"oldScheduleSessionTypeId",DbType.Int32,oldscheduleSessionTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ScheduleSessionType using Stored Procedure
		/// </summary>
		public DbCommand UpdateScheduleSessionTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateScheduleSessionType");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"oldScheduleSessionTypeId",DbType.Int32,"ScheduleSessionTypeId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ScheduleSessionType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteScheduleSessionType( int scheduleSessionTypeId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteScheduleSessionType");
			Database.AddInParameter(command,"ScheduleSessionTypeId",DbType.Int32,scheduleSessionTypeId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ScheduleSessionType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteScheduleSessionTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteScheduleSessionType");
				Database.AddInParameter(command,"ScheduleSessionTypeId",DbType.Int32,"ScheduleSessionTypeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ScheduleSessionType using Stored Procedure
		/// and return number of rows effected of the ScheduleSessionType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ScheduleSessionType",InsertNewScheduleSessionTypeCommand(),UpdateScheduleSessionTypeCommand(),DeleteScheduleSessionTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ScheduleSessionType using Stored Procedure
		/// and return number of rows effected of the ScheduleSessionType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ScheduleSessionType",InsertNewScheduleSessionTypeCommand(),UpdateScheduleSessionTypeCommand(),DeleteScheduleSessionTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
