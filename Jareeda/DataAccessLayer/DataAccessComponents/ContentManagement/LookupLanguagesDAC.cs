using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for LookupLanguages table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the LookupLanguages table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class LookupLanguagesDAC : DataAccessComponent
	{
		#region Constructors
        public LookupLanguagesDAC() : base("", "ContentManagement.LookupLanguages") { }
		public LookupLanguagesDAC(string connectionString): base(connectionString){}
		public LookupLanguagesDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all LookupLanguages using Stored Procedure
		/// and return a DataTable containing all LookupLanguages Data
		/// </summary>
		public DataTable GetAllLookupLanguages()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "LookupLanguages";
         string query = " select * from GetAllLookupLanguages";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["LookupLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all LookupLanguages using Stored Procedure
		/// and return a DataTable containing all LookupLanguages Data using a Transaction
		/// </summary>
		public DataTable GetAllLookupLanguages(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "LookupLanguages";
         string query = " select * from GetAllLookupLanguages";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["LookupLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all LookupLanguages using Stored Procedure
		/// and return a DataTable containing all LookupLanguages Data
		/// </summary>
		public DataTable GetAllLookupLanguages(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "LookupLanguages";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllLookupLanguages" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["LookupLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all LookupLanguages using Stored Procedure
		/// and return a DataTable containing all LookupLanguages Data using a Transaction
		/// </summary>
		public DataTable GetAllLookupLanguages(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "LookupLanguages";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllLookupLanguages" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["LookupLanguages"];

		}


        public System.Data.IDataReader GetByLanguageIDLookupLanguages(string LookupName,int LanguageId)
        {
            DbCommand command = Database.GetStoredProcCommand("GetByLanguageIDLookupLanguages");
            Database.AddInParameter(command, "LanguageId", DbType.Int32, LanguageId);
            Database.AddInParameter(command, "LookupName", DbType.String, LookupName);
            IDataReader reader = Database.ExecuteReader(command);
            return reader;
        }
		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From LookupLanguages using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDLookupLanguages( int lookupLanguageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDLookupLanguages");
				    Database.AddInParameter(command,"LookupLanguageId",DbType.Int32,lookupLanguageId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From LookupLanguages using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDLookupLanguages( int lookupLanguageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDLookupLanguages");
				    Database.AddInParameter(command,"LookupLanguageId",DbType.Int32,lookupLanguageId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into LookupLanguages using Stored Procedure
		/// and return the auto number primary key of LookupLanguages inserted row
		/// </summary>
		public bool InsertNewLookupLanguages( ref int lookupLanguageId,  int lookupId,  int languageId,  int refId,  string lookupValue,  string lookupValueDescription)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewLookupLanguages");
				Database.AddOutParameter(command,"LookupLanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"LookupId",DbType.Int32,lookupId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"RefId",DbType.Int32,refId);
				Database.AddInParameter(command,"LookupValue",DbType.String,lookupValue);
				Database.AddInParameter(command,"LookupValueDescription",DbType.String,lookupValueDescription);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 lookupLanguageId = Convert.ToInt32(Database.GetParameterValue(command, "LookupLanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into LookupLanguages using Stored Procedure
		/// and return the auto number primary key of LookupLanguages inserted row using Transaction
		/// </summary>
		public bool InsertNewLookupLanguages( ref int lookupLanguageId,  int lookupId,  int languageId,  int refId,  string lookupValue,  string lookupValueDescription,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewLookupLanguages");
				Database.AddOutParameter(command,"LookupLanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"LookupId",DbType.Int32,lookupId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"RefId",DbType.Int32,refId);
				Database.AddInParameter(command,"LookupValue",DbType.String,lookupValue);
				Database.AddInParameter(command,"LookupValueDescription",DbType.String,lookupValueDescription);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 lookupLanguageId = Convert.ToInt32(Database.GetParameterValue(command, "LookupLanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for LookupLanguages using Stored Procedure
		/// and return DbCommand of the LookupLanguages
		/// </summary>
		public DbCommand InsertNewLookupLanguagesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewLookupLanguages");

				Database.AddInParameter(command,"LookupId",DbType.Int32,"LookupId",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
				Database.AddInParameter(command,"RefId",DbType.Int32,"RefId",DataRowVersion.Current);
				Database.AddInParameter(command,"LookupValue",DbType.String,"LookupValue",DataRowVersion.Current);
				Database.AddInParameter(command,"LookupValueDescription",DbType.String,"LookupValueDescription",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into LookupLanguages using Stored Procedure
		/// </summary>
		public bool UpdateLookupLanguages( int lookupId, int languageId, int refId, string lookupValue, string lookupValueDescription, int oldlookupLanguageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateLookupLanguages");

		    		Database.AddInParameter(command,"LookupId",DbType.Int32,lookupId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"RefId",DbType.Int32,refId);
		    		Database.AddInParameter(command,"LookupValue",DbType.String,lookupValue);
		    		Database.AddInParameter(command,"LookupValueDescription",DbType.String,lookupValueDescription);
				Database.AddInParameter(command,"oldLookupLanguageId",DbType.Int32,oldlookupLanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into LookupLanguages using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateLookupLanguages( int lookupId, int languageId, int refId, string lookupValue, string lookupValueDescription, int oldlookupLanguageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateLookupLanguages");

		    		Database.AddInParameter(command,"LookupId",DbType.Int32,lookupId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"RefId",DbType.Int32,refId);
		    		Database.AddInParameter(command,"LookupValue",DbType.String,lookupValue);
		    		Database.AddInParameter(command,"LookupValueDescription",DbType.String,lookupValueDescription);
				Database.AddInParameter(command,"oldLookupLanguageId",DbType.Int32,oldlookupLanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from LookupLanguages using Stored Procedure
		/// </summary>
		public DbCommand UpdateLookupLanguagesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateLookupLanguages");

		    		Database.AddInParameter(command,"LookupId",DbType.Int32,"LookupId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RefId",DbType.Int32,"RefId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LookupValue",DbType.String,"LookupValue",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LookupValueDescription",DbType.String,"LookupValueDescription",DataRowVersion.Current);
				Database.AddInParameter(command,"oldLookupLanguageId",DbType.Int32,"LookupLanguageId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From LookupLanguages using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteLookupLanguages( int lookupLanguageId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteLookupLanguages");
			Database.AddInParameter(command,"LookupLanguageId",DbType.Int32,lookupLanguageId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From LookupLanguages Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteLookupLanguagesCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteLookupLanguages");
				Database.AddInParameter(command,"LookupLanguageId",DbType.Int32,"LookupLanguageId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table LookupLanguages using Stored Procedure
		/// and return number of rows effected of the LookupLanguages
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"LookupLanguages",InsertNewLookupLanguagesCommand(),UpdateLookupLanguagesCommand(),DeleteLookupLanguagesCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table LookupLanguages using Stored Procedure
		/// and return number of rows effected of the LookupLanguages
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"LookupLanguages",InsertNewLookupLanguagesCommand(),UpdateLookupLanguagesCommand(),DeleteLookupLanguagesCommand(), transaction);
          return rowsAffected;
		}


	}
}
