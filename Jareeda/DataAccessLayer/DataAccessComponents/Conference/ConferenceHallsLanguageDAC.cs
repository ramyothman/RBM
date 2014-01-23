using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferenceHallsLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferenceHallsLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceHallsLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceHallsLanguageDAC() : base("", "Conference.ConferenceHallsLanguage") { }
		public ConferenceHallsLanguageDAC(string connectionString): base(connectionString){}
		public ConferenceHallsLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceHallsLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceHallsLanguage Data
		/// </summary>
		public DataTable GetAllConferenceHallsLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceHallsLanguage";
         string query = " select * from GetAllConferenceHallsLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceHallsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceHallsLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceHallsLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceHallsLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceHallsLanguage";
         string query = " select * from GetAllConferenceHallsLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceHallsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceHallsLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceHallsLanguage Data
		/// </summary>
		public DataTable GetAllConferenceHallsLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceHallsLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferenceHallsLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceHallsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceHallsLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceHallsLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceHallsLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceHallsLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferenceHallsLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceHallsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceHallsLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceHallsLanguage( int conferenceHallsId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceHallsLanguage");
				    Database.AddInParameter(command,"ConferenceHallsId",DbType.Int32,conferenceHallsId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceHallsLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceHallsLanguage( int conferenceHallsId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceHallsLanguage");
				    Database.AddInParameter(command,"ConferenceHallsId",DbType.Int32,conferenceHallsId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceHallsLanguage using Stored Procedure
		/// and return the auto number primary key of ConferenceHallsLanguage inserted row
		/// </summary>
		public bool InsertNewConferenceHallsLanguage( ref int conferenceHallsId,  string name,  int conferenceId,  string mapPath,  int languageID,  int conferenceHallsParentID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceHallsLanguage");
				Database.AddOutParameter(command,"ConferenceHallsId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"MapPath",DbType.String,mapPath);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"ConferenceHallsParentID",DbType.Int32,conferenceHallsParentID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceHallsId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceHallsId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceHallsLanguage using Stored Procedure
		/// and return the auto number primary key of ConferenceHallsLanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewConferenceHallsLanguage( ref int conferenceHallsId,  string name,  int conferenceId,  string mapPath,  int languageID,  int conferenceHallsParentID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceHallsLanguage");
				Database.AddOutParameter(command,"ConferenceHallsId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"MapPath",DbType.String,mapPath);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"ConferenceHallsParentID",DbType.Int32,conferenceHallsParentID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceHallsId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceHallsId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceHallsLanguage using Stored Procedure
		/// and return DbCommand of the ConferenceHallsLanguage
		/// </summary>
		public DbCommand InsertNewConferenceHallsLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceHallsLanguage");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"MapPath",DbType.String,"MapPath",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceHallsParentID",DbType.Int32,"ConferenceHallsParentID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceHallsLanguage using Stored Procedure
		/// </summary>
		public bool UpdateConferenceHallsLanguage( string name, int conferenceId, string mapPath, int languageID, int conferenceHallsParentID, int oldconferenceHallsId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceHallsLanguage");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"MapPath",DbType.String,mapPath);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"ConferenceHallsParentID",DbType.Int32,conferenceHallsParentID);
				Database.AddInParameter(command,"oldConferenceHallsId",DbType.Int32,oldconferenceHallsId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceHallsLanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateConferenceHallsLanguage( string name, int conferenceId, string mapPath, int languageID, int conferenceHallsParentID, int oldconferenceHallsId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceHallsLanguage");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"MapPath",DbType.String,mapPath);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"ConferenceHallsParentID",DbType.Int32,conferenceHallsParentID);
				Database.AddInParameter(command,"oldConferenceHallsId",DbType.Int32,oldconferenceHallsId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceHallsLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceHallsLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceHallsLanguage");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"MapPath",DbType.String,"MapPath",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceHallsParentID",DbType.Int32,"ConferenceHallsParentID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldConferenceHallsId",DbType.Int32,"ConferenceHallsId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceHallsLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferenceHallsLanguage( int conferenceHallsId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferenceHallsLanguage");
			Database.AddInParameter(command,"ConferenceHallsId",DbType.Int32,conferenceHallsId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceHallsLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceHallsLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceHallsLanguage");
				Database.AddInParameter(command,"ConferenceHallsId",DbType.Int32,"ConferenceHallsId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceHallsLanguage using Stored Procedure
		/// and return number of rows effected of the ConferenceHallsLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceHallsLanguage",InsertNewConferenceHallsLanguageCommand(),UpdateConferenceHallsLanguageCommand(),DeleteConferenceHallsLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceHallsLanguage using Stored Procedure
		/// and return number of rows effected of the ConferenceHallsLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceHallsLanguage",InsertNewConferenceHallsLanguageCommand(),UpdateConferenceHallsLanguageCommand(),DeleteConferenceHallsLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
