using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferenceCategoryLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferenceCategoryLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceCategoryLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceCategoryLanguageDAC() : base("", "Conference.ConferenceCategoryLanguage") { }
		public ConferenceCategoryLanguageDAC(string connectionString): base(connectionString){}
		public ConferenceCategoryLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceCategoryLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceCategoryLanguage Data
		/// </summary>
		public DataTable GetAllConferenceCategoryLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceCategoryLanguage";
         string query = " select * from GetAllConferenceCategoryLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceCategoryLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceCategoryLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceCategoryLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceCategoryLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceCategoryLanguage";
         string query = " select * from GetAllConferenceCategoryLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceCategoryLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceCategoryLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceCategoryLanguage Data
		/// </summary>
		public DataTable GetAllConferenceCategoryLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceCategoryLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferenceCategoryLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceCategoryLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceCategoryLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceCategoryLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceCategoryLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceCategoryLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferenceCategoryLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceCategoryLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceCategoryLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceCategoryLanguage( int conferenceCategoryId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceCategoryLanguage");
				    Database.AddInParameter(command,"ConferenceCategoryId",DbType.Int32,conferenceCategoryId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceCategoryLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceCategoryLanguage( int conferenceCategoryId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceCategoryLanguage");
				    Database.AddInParameter(command,"ConferenceCategoryId",DbType.Int32,conferenceCategoryId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceCategoryLanguage using Stored Procedure
		/// and return the auto number primary key of ConferenceCategoryLanguage inserted row
		/// </summary>
		public bool InsertNewConferenceCategoryLanguage( ref int conferenceCategoryId,  string categoryName,  int conferenceId,  int languageID,  int conferenceCategoryParentID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceCategoryLanguage");
				Database.AddOutParameter(command,"ConferenceCategoryId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"CategoryName",DbType.String,categoryName);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"ConferenceCategoryParentID",DbType.Int32,conferenceCategoryParentID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceCategoryId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceCategoryId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceCategoryLanguage using Stored Procedure
		/// and return the auto number primary key of ConferenceCategoryLanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewConferenceCategoryLanguage( ref int conferenceCategoryId,  string categoryName,  int conferenceId,  int languageID,  int conferenceCategoryParentID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceCategoryLanguage");
				Database.AddOutParameter(command,"ConferenceCategoryId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"CategoryName",DbType.String,categoryName);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"ConferenceCategoryParentID",DbType.Int32,conferenceCategoryParentID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceCategoryId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceCategoryId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceCategoryLanguage using Stored Procedure
		/// and return DbCommand of the ConferenceCategoryLanguage
		/// </summary>
		public DbCommand InsertNewConferenceCategoryLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceCategoryLanguage");

				Database.AddInParameter(command,"CategoryName",DbType.String,"CategoryName",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceCategoryParentID",DbType.Int32,"ConferenceCategoryParentID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceCategoryLanguage using Stored Procedure
		/// </summary>
		public bool UpdateConferenceCategoryLanguage( string categoryName, int conferenceId, int languageID, int conferenceCategoryParentID, int oldconferenceCategoryId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceCategoryLanguage");

		    		Database.AddInParameter(command,"CategoryName",DbType.String,categoryName);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"ConferenceCategoryParentID",DbType.Int32,conferenceCategoryParentID);
				Database.AddInParameter(command,"oldConferenceCategoryId",DbType.Int32,oldconferenceCategoryId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceCategoryLanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateConferenceCategoryLanguage( string categoryName, int conferenceId, int languageID, int conferenceCategoryParentID, int oldconferenceCategoryId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceCategoryLanguage");

		    		Database.AddInParameter(command,"CategoryName",DbType.String,categoryName);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"ConferenceCategoryParentID",DbType.Int32,conferenceCategoryParentID);
				Database.AddInParameter(command,"oldConferenceCategoryId",DbType.Int32,oldconferenceCategoryId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceCategoryLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceCategoryLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceCategoryLanguage");

		    		Database.AddInParameter(command,"CategoryName",DbType.String,"CategoryName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceCategoryParentID",DbType.Int32,"ConferenceCategoryParentID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldConferenceCategoryId",DbType.Int32,"ConferenceCategoryId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceCategoryLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferenceCategoryLanguage( int conferenceCategoryId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferenceCategoryLanguage");
			Database.AddInParameter(command,"ConferenceCategoryId",DbType.Int32,conferenceCategoryId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceCategoryLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceCategoryLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceCategoryLanguage");
				Database.AddInParameter(command,"ConferenceCategoryId",DbType.Int32,"ConferenceCategoryId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceCategoryLanguage using Stored Procedure
		/// and return number of rows effected of the ConferenceCategoryLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceCategoryLanguage",InsertNewConferenceCategoryLanguageCommand(),UpdateConferenceCategoryLanguageCommand(),DeleteConferenceCategoryLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceCategoryLanguage using Stored Procedure
		/// and return number of rows effected of the ConferenceCategoryLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceCategoryLanguage",InsertNewConferenceCategoryLanguageCommand(),UpdateConferenceCategoryLanguageCommand(),DeleteConferenceCategoryLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
