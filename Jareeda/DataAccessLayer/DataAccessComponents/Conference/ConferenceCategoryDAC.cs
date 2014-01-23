using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferenceCategory table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferenceCategory table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceCategoryDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceCategoryDAC() : base("", "Conference.ConferenceCategory") { }
		public ConferenceCategoryDAC(string connectionString): base(connectionString){}
		public ConferenceCategoryDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceCategory using Stored Procedure
		/// and return a DataTable containing all ConferenceCategory Data
		/// </summary>
		public DataTable GetAllConferenceCategory()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceCategory";
         string query = " select * from GetAllConferenceCategory";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceCategory using Stored Procedure
		/// and return a DataTable containing all ConferenceCategory Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceCategory(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceCategory";
         string query = " select * from GetAllConferenceCategory";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceCategory using Stored Procedure
		/// and return a DataTable containing all ConferenceCategory Data
		/// </summary>
		public DataTable GetAllConferenceCategory(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceCategory";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferenceCategory" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceCategory using Stored Procedure
		/// and return a DataTable containing all ConferenceCategory Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceCategory(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceCategory";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferenceCategory" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceCategory using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceCategory( int conferenceCategoryId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceCategory");
				    Database.AddInParameter(command,"ConferenceCategoryId",DbType.Int32,conferenceCategoryId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceCategory using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceCategory( int conferenceCategoryId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceCategory");
				    Database.AddInParameter(command,"ConferenceCategoryId",DbType.Int32,conferenceCategoryId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceCategory using Stored Procedure
		/// and return the auto number primary key of ConferenceCategory inserted row
		/// </summary>
		public bool InsertNewConferenceCategory( ref int conferenceCategoryId,  string categoryName,  int conferenceId)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceCategory");
				Database.AddOutParameter(command,"ConferenceCategoryId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"CategoryName",DbType.String,categoryName);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceCategoryId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceCategoryId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceCategory using Stored Procedure
		/// and return the auto number primary key of ConferenceCategory inserted row using Transaction
		/// </summary>
		public bool InsertNewConferenceCategory( ref int conferenceCategoryId,  string categoryName,  int conferenceId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceCategory");
				Database.AddOutParameter(command,"ConferenceCategoryId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"CategoryName",DbType.String,categoryName);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceCategoryId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceCategoryId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceCategory using Stored Procedure
		/// and return DbCommand of the ConferenceCategory
		/// </summary>
		public DbCommand InsertNewConferenceCategoryCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceCategory");

				Database.AddInParameter(command,"CategoryName",DbType.String,"CategoryName",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceCategory using Stored Procedure
		/// </summary>
		public bool UpdateConferenceCategory( string categoryName, int conferenceId, int oldconferenceCategoryId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceCategory");

		    		Database.AddInParameter(command,"CategoryName",DbType.String,categoryName);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"oldConferenceCategoryId",DbType.Int32,oldconferenceCategoryId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceCategory using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateConferenceCategory( string categoryName, int conferenceId, int oldconferenceCategoryId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceCategory");

		    		Database.AddInParameter(command,"CategoryName",DbType.String,categoryName);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"oldConferenceCategoryId",DbType.Int32,oldconferenceCategoryId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceCategory using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceCategoryCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceCategory");

		    		Database.AddInParameter(command,"CategoryName",DbType.String,"CategoryName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"oldConferenceCategoryId",DbType.Int32,"ConferenceCategoryId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceCategory using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferenceCategory( int conferenceCategoryId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferenceCategory");
			Database.AddInParameter(command,"ConferenceCategoryId",DbType.Int32,conferenceCategoryId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceCategory Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceCategoryCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceCategory");
				Database.AddInParameter(command,"ConferenceCategoryId",DbType.Int32,"ConferenceCategoryId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceCategory using Stored Procedure
		/// and return number of rows effected of the ConferenceCategory
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceCategory",InsertNewConferenceCategoryCommand(),UpdateConferenceCategoryCommand(),DeleteConferenceCategoryCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceCategory using Stored Procedure
		/// and return number of rows effected of the ConferenceCategory
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceCategory",InsertNewConferenceCategoryCommand(),UpdateConferenceCategoryCommand(),DeleteConferenceCategoryCommand(), transaction);
          return rowsAffected;
		}


	}
}
