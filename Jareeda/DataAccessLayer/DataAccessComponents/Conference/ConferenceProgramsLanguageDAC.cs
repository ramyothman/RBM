using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferenceProgramsLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferenceProgramsLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceProgramsLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceProgramsLanguageDAC() : base("", "Conference.ConferenceProgramsLanguage") { }
		public ConferenceProgramsLanguageDAC(string connectionString): base(connectionString){}
		public ConferenceProgramsLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceProgramsLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceProgramsLanguage Data
		/// </summary>
		public DataTable GetAllConferenceProgramsLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceProgramsLanguage";
         string query = " select * from GetAllConferenceProgramsLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceProgramsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceProgramsLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceProgramsLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceProgramsLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceProgramsLanguage";
         string query = " select * from GetAllConferenceProgramsLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceProgramsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceProgramsLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceProgramsLanguage Data
		/// </summary>
		public DataTable GetAllConferenceProgramsLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceProgramsLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferenceProgramsLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceProgramsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceProgramsLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceProgramsLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceProgramsLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceProgramsLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferenceProgramsLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceProgramsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceProgramsLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceProgramsLanguage( int conferenceProgramId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceProgramsLanguage");
				    Database.AddInParameter(command,"ConferenceProgramId",DbType.Int32,conferenceProgramId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceProgramsLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceProgramsLanguage( int conferenceProgramId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceProgramsLanguage");
				    Database.AddInParameter(command,"ConferenceProgramId",DbType.Int32,conferenceProgramId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceProgramsLanguage using Stored Procedure
		/// and return the auto number primary key of ConferenceProgramsLanguage inserted row
		/// </summary>
		public bool InsertNewConferenceProgramsLanguage( ref int conferenceProgramId,  string programName,  int conferenceId,  int languageID,  int conferenceProgramParentID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceProgramsLanguage");
				Database.AddOutParameter(command,"ConferenceProgramId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ProgramName",DbType.String,programName);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"ConferenceProgramParentID",DbType.Int32,conferenceProgramParentID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceProgramId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceProgramId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceProgramsLanguage using Stored Procedure
		/// and return the auto number primary key of ConferenceProgramsLanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewConferenceProgramsLanguage( ref int conferenceProgramId,  string programName,  int conferenceId,  int languageID,  int conferenceProgramParentID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceProgramsLanguage");
				Database.AddOutParameter(command,"ConferenceProgramId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ProgramName",DbType.String,programName);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"ConferenceProgramParentID",DbType.Int32,conferenceProgramParentID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceProgramId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceProgramId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceProgramsLanguage using Stored Procedure
		/// and return DbCommand of the ConferenceProgramsLanguage
		/// </summary>
		public DbCommand InsertNewConferenceProgramsLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceProgramsLanguage");

				Database.AddInParameter(command,"ProgramName",DbType.String,"ProgramName",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceProgramParentID",DbType.Int32,"ConferenceProgramParentID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceProgramsLanguage using Stored Procedure
		/// </summary>
		public bool UpdateConferenceProgramsLanguage( string programName, int conferenceId, int languageID, int conferenceProgramParentID, int oldconferenceProgramId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceProgramsLanguage");

		    		Database.AddInParameter(command,"ProgramName",DbType.String,programName);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"ConferenceProgramParentID",DbType.Int32,conferenceProgramParentID);
				Database.AddInParameter(command,"oldConferenceProgramId",DbType.Int32,oldconferenceProgramId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceProgramsLanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateConferenceProgramsLanguage( string programName, int conferenceId, int languageID, int conferenceProgramParentID, int oldconferenceProgramId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceProgramsLanguage");

		    		Database.AddInParameter(command,"ProgramName",DbType.String,programName);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"ConferenceProgramParentID",DbType.Int32,conferenceProgramParentID);
				Database.AddInParameter(command,"oldConferenceProgramId",DbType.Int32,oldconferenceProgramId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceProgramsLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceProgramsLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceProgramsLanguage");

		    		Database.AddInParameter(command,"ProgramName",DbType.String,"ProgramName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceProgramParentID",DbType.Int32,"ConferenceProgramParentID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldConferenceProgramId",DbType.Int32,"ConferenceProgramId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceProgramsLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferenceProgramsLanguage( int conferenceProgramId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferenceProgramsLanguage");
			Database.AddInParameter(command,"ConferenceProgramId",DbType.Int32,conferenceProgramId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceProgramsLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceProgramsLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceProgramsLanguage");
				Database.AddInParameter(command,"ConferenceProgramId",DbType.Int32,"ConferenceProgramId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceProgramsLanguage using Stored Procedure
		/// and return number of rows effected of the ConferenceProgramsLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceProgramsLanguage",InsertNewConferenceProgramsLanguageCommand(),UpdateConferenceProgramsLanguageCommand(),DeleteConferenceProgramsLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceProgramsLanguage using Stored Procedure
		/// and return number of rows effected of the ConferenceProgramsLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceProgramsLanguage",InsertNewConferenceProgramsLanguageCommand(),UpdateConferenceProgramsLanguageCommand(),DeleteConferenceProgramsLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
