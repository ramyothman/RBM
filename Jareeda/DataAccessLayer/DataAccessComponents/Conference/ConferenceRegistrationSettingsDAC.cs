using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferenceRegistrationSettings table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferenceRegistrationSettings table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceRegistrationSettingsDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceRegistrationSettingsDAC() : base("", "Conference.ConferenceRegistrationSettings") { }
		public ConferenceRegistrationSettingsDAC(string connectionString): base(connectionString){}
		public ConferenceRegistrationSettingsDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationSettings using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationSettings Data
		/// </summary>
		public DataTable GetAllConferenceRegistrationSettings()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationSettings";
         string query = " select * from GetAllConferenceRegistrationSettings";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceRegistrationSettings"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationSettings using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationSettings Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceRegistrationSettings(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationSettings";
         string query = " select * from GetAllConferenceRegistrationSettings";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceRegistrationSettings"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationSettings using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationSettings Data
		/// </summary>
		public DataTable GetAllConferenceRegistrationSettings(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationSettings";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferenceRegistrationSettings" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceRegistrationSettings"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationSettings using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationSettings Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceRegistrationSettings(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationSettings";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferenceRegistrationSettings" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceRegistrationSettings"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceRegistrationSettings using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceRegistrationSettings( int conferenceRegistrationSettingID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceRegistrationSettings");
				    Database.AddInParameter(command,"ConferenceRegistrationSettingID",DbType.Int32,conferenceRegistrationSettingID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceRegistrationSettings using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceRegistrationSettings( int conferenceRegistrationSettingID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceRegistrationSettings");
				    Database.AddInParameter(command,"ConferenceRegistrationSettingID",DbType.Int32,conferenceRegistrationSettingID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceRegistrationSettings using Stored Procedure
		/// and return the auto number primary key of ConferenceRegistrationSettings inserted row
		/// </summary>
		public bool InsertNewConferenceRegistrationSettings( ref int conferenceRegistrationSettingID,  int conferenceID,  DateTime registrationEndDate,  DateTime registrationStartDate,  bool isActive)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceRegistrationSettings");
				Database.AddOutParameter(command,"ConferenceRegistrationSettingID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceID",DbType.Int32,conferenceID);
				Database.AddInParameter(command,"RegistrationEndDate",DbType.DateTime,registrationEndDate);
				Database.AddInParameter(command,"RegistrationStartDate",DbType.DateTime,registrationStartDate);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceRegistrationSettingID = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceRegistrationSettingID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceRegistrationSettings using Stored Procedure
		/// and return the auto number primary key of ConferenceRegistrationSettings inserted row using Transaction
		/// </summary>
		public bool InsertNewConferenceRegistrationSettings( ref int conferenceRegistrationSettingID,  int conferenceID,  DateTime registrationEndDate,  DateTime registrationStartDate,  bool isActive,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceRegistrationSettings");
				Database.AddOutParameter(command,"ConferenceRegistrationSettingID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceID",DbType.Int32,conferenceID);
				Database.AddInParameter(command,"RegistrationEndDate",DbType.DateTime,registrationEndDate);
				Database.AddInParameter(command,"RegistrationStartDate",DbType.DateTime,registrationStartDate);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceRegistrationSettingID = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceRegistrationSettingID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceRegistrationSettings using Stored Procedure
		/// and return DbCommand of the ConferenceRegistrationSettings
		/// </summary>
		public DbCommand InsertNewConferenceRegistrationSettingsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceRegistrationSettings");

				Database.AddInParameter(command,"ConferenceID",DbType.Int32,"ConferenceID",DataRowVersion.Current);
				Database.AddInParameter(command,"RegistrationEndDate",DbType.DateTime,"RegistrationEndDate",DataRowVersion.Current);
				Database.AddInParameter(command,"RegistrationStartDate",DbType.DateTime,"RegistrationStartDate",DataRowVersion.Current);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceRegistrationSettings using Stored Procedure
		/// </summary>
		public bool UpdateConferenceRegistrationSettings( int conferenceID, DateTime registrationEndDate, DateTime registrationStartDate, bool isActive, int oldconferenceRegistrationSettingID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceRegistrationSettings");

		    		Database.AddInParameter(command,"ConferenceID",DbType.Int32,conferenceID);
		    		Database.AddInParameter(command,"RegistrationEndDate",DbType.DateTime,registrationEndDate);
		    		Database.AddInParameter(command,"RegistrationStartDate",DbType.DateTime,registrationStartDate);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"oldConferenceRegistrationSettingID",DbType.Int32,oldconferenceRegistrationSettingID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceRegistrationSettings using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateConferenceRegistrationSettings( int conferenceID, DateTime registrationEndDate, DateTime registrationStartDate, bool isActive, int oldconferenceRegistrationSettingID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceRegistrationSettings");

		    		Database.AddInParameter(command,"ConferenceID",DbType.Int32,conferenceID);
		    		Database.AddInParameter(command,"RegistrationEndDate",DbType.DateTime,registrationEndDate);
		    		Database.AddInParameter(command,"RegistrationStartDate",DbType.DateTime,registrationStartDate);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"oldConferenceRegistrationSettingID",DbType.Int32,oldconferenceRegistrationSettingID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceRegistrationSettings using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceRegistrationSettingsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceRegistrationSettings");

		    		Database.AddInParameter(command,"ConferenceID",DbType.Int32,"ConferenceID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RegistrationEndDate",DbType.DateTime,"RegistrationEndDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RegistrationStartDate",DbType.DateTime,"RegistrationStartDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
				Database.AddInParameter(command,"oldConferenceRegistrationSettingID",DbType.Int32,"ConferenceRegistrationSettingID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceRegistrationSettings using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferenceRegistrationSettings( int conferenceRegistrationSettingID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferenceRegistrationSettings");
			Database.AddInParameter(command,"ConferenceRegistrationSettingID",DbType.Int32,conferenceRegistrationSettingID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceRegistrationSettings Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceRegistrationSettingsCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceRegistrationSettings");
				Database.AddInParameter(command,"ConferenceRegistrationSettingID",DbType.Int32,"ConferenceRegistrationSettingID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceRegistrationSettings using Stored Procedure
		/// and return number of rows effected of the ConferenceRegistrationSettings
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceRegistrationSettings",InsertNewConferenceRegistrationSettingsCommand(),UpdateConferenceRegistrationSettingsCommand(),DeleteConferenceRegistrationSettingsCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceRegistrationSettings using Stored Procedure
		/// and return number of rows effected of the ConferenceRegistrationSettings
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceRegistrationSettings",InsertNewConferenceRegistrationSettingsCommand(),UpdateConferenceRegistrationSettingsCommand(),DeleteConferenceRegistrationSettingsCommand(), transaction);
          return rowsAffected;
		}


	}
}
