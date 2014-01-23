using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for Lookups table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Lookups table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class LookupsDAC : DataAccessComponent
	{
		#region Constructors
        public LookupsDAC() : base("", "ContentManagement.Lookups") { }
		public LookupsDAC(string connectionString): base(connectionString){}
		public LookupsDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Lookups using Stored Procedure
		/// and return a DataTable containing all Lookups Data
		/// </summary>
		public DataTable GetAllLookups()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Lookups";
         string query = " select * from GetAllLookups";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Lookups"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Lookups using Stored Procedure
		/// and return a DataTable containing all Lookups Data using a Transaction
		/// </summary>
		public DataTable GetAllLookups(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Lookups";
         string query = " select * from GetAllLookups";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Lookups"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Lookups using Stored Procedure
		/// and return a DataTable containing all Lookups Data
		/// </summary>
		public DataTable GetAllLookups(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Lookups";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllLookups" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Lookups"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Lookups using Stored Procedure
		/// and return a DataTable containing all Lookups Data using a Transaction
		/// </summary>
		public DataTable GetAllLookups(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Lookups";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllLookups" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Lookups"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Lookups using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDLookups( int lookupId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDLookups");
				    Database.AddInParameter(command,"LookupId",DbType.Int32,lookupId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Lookups using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDLookups( int lookupId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDLookups");
				    Database.AddInParameter(command,"LookupId",DbType.Int32,lookupId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Lookups using Stored Procedure
		/// and return the auto number primary key of Lookups inserted row
		/// </summary>
		public bool InsertNewLookups( ref int lookupId,  string lookupName,  string lookupFriendlyName)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewLookups");
				Database.AddOutParameter(command,"LookupId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"LookupName",DbType.String,lookupName);
				Database.AddInParameter(command,"LookupFriendlyName",DbType.String,lookupFriendlyName);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 lookupId = Convert.ToInt32(Database.GetParameterValue(command, "LookupId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Lookups using Stored Procedure
		/// and return the auto number primary key of Lookups inserted row using Transaction
		/// </summary>
		public bool InsertNewLookups( ref int lookupId,  string lookupName,  string lookupFriendlyName,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewLookups");
				Database.AddOutParameter(command,"LookupId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"LookupName",DbType.String,lookupName);
				Database.AddInParameter(command,"LookupFriendlyName",DbType.String,lookupFriendlyName);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 lookupId = Convert.ToInt32(Database.GetParameterValue(command, "LookupId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Lookups using Stored Procedure
		/// and return DbCommand of the Lookups
		/// </summary>
		public DbCommand InsertNewLookupsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewLookups");

				Database.AddInParameter(command,"LookupName",DbType.String,"LookupName",DataRowVersion.Current);
				Database.AddInParameter(command,"LookupFriendlyName",DbType.String,"LookupFriendlyName",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Lookups using Stored Procedure
		/// </summary>
		public bool UpdateLookups( string lookupName, string lookupFriendlyName, int oldlookupId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateLookups");

		    		Database.AddInParameter(command,"LookupName",DbType.String,lookupName);
		    		Database.AddInParameter(command,"LookupFriendlyName",DbType.String,lookupFriendlyName);
				Database.AddInParameter(command,"oldLookupId",DbType.Int32,oldlookupId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Lookups using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateLookups( string lookupName, string lookupFriendlyName, int oldlookupId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateLookups");

		    		Database.AddInParameter(command,"LookupName",DbType.String,lookupName);
		    		Database.AddInParameter(command,"LookupFriendlyName",DbType.String,lookupFriendlyName);
				Database.AddInParameter(command,"oldLookupId",DbType.Int32,oldlookupId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Lookups using Stored Procedure
		/// </summary>
		public DbCommand UpdateLookupsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateLookups");

		    		Database.AddInParameter(command,"LookupName",DbType.String,"LookupName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LookupFriendlyName",DbType.String,"LookupFriendlyName",DataRowVersion.Current);
				Database.AddInParameter(command,"oldLookupId",DbType.Int32,"LookupId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Lookups using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteLookups( int lookupId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteLookups");
			Database.AddInParameter(command,"LookupId",DbType.Int32,lookupId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Lookups Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteLookupsCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteLookups");
				Database.AddInParameter(command,"LookupId",DbType.Int32,"LookupId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Lookups using Stored Procedure
		/// and return number of rows effected of the Lookups
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Lookups",InsertNewLookupsCommand(),UpdateLookupsCommand(),DeleteLookupsCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Lookups using Stored Procedure
		/// and return number of rows effected of the Lookups
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Lookups",InsertNewLookupsCommand(),UpdateLookupsCommand(),DeleteLookupsCommand(), transaction);
          return rowsAffected;
		}


	}
}
