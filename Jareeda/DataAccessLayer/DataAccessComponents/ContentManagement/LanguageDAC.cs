using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for Language table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Language table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class LanguageDAC : DataAccessComponent
	{
		#region Constructors
        public LanguageDAC() : base("", "ContentManagement.Language") { }
		public LanguageDAC(string connectionString): base(connectionString){}
		public LanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Language using Stored Procedure
		/// and return a DataTable containing all Language Data
		/// </summary>
		public DataTable GetAllLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Language";
         string query = " select * from GetAllLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Language"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Language using Stored Procedure
		/// and return a DataTable containing all Language Data using a Transaction
		/// </summary>
		public DataTable GetAllLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Language";
         string query = " select * from GetAllLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Language"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Language using Stored Procedure
		/// and return a DataTable containing all Language Data
		/// </summary>
		public DataTable GetAllLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Language";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Language"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Language using Stored Procedure
		/// and return a DataTable containing all Language Data using a Transaction
		/// </summary>
		public DataTable GetAllLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Language";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Language"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Language using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDLanguage( int languageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDLanguage");
				    Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Language using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDLanguage( int languageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDLanguage");
				    Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

        public System.Data.IDataReader GetByCodeLanguage(string languageCode)
        {
            DbCommand command = Database.GetStoredProcCommand("GetByCodeLanguage");
            Database.AddInParameter(command, "LanguageCode", DbType.String, languageCode);
            IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
            return reader;
        }


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Language using Stored Procedure
		/// and return the auto number primary key of Language inserted row
		/// </summary>
		public bool InsertNewLanguage( ref int languageId,  string languageCode,  string name)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewLanguage");
				Database.AddOutParameter(command,"LanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"LanguageCode",DbType.String,languageCode);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 languageId = Convert.ToInt32(Database.GetParameterValue(command, "LanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Language using Stored Procedure
		/// and return the auto number primary key of Language inserted row using Transaction
		/// </summary>
		public bool InsertNewLanguage( ref int languageId,  string languageCode,  string name,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewLanguage");
				Database.AddOutParameter(command,"LanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"LanguageCode",DbType.String,languageCode);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 languageId = Convert.ToInt32(Database.GetParameterValue(command, "LanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Language using Stored Procedure
		/// and return DbCommand of the Language
		/// </summary>
		public DbCommand InsertNewLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewLanguage");

				Database.AddInParameter(command,"LanguageCode",DbType.String,"LanguageCode",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Language using Stored Procedure
		/// </summary>
		public bool UpdateLanguage( string languageCode, string name, int oldlanguageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateLanguage");

		    		Database.AddInParameter(command,"LanguageCode",DbType.String,languageCode);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldLanguageId",DbType.Int32,oldlanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Language using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateLanguage( string languageCode, string name, int oldlanguageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateLanguage");

		    		Database.AddInParameter(command,"LanguageCode",DbType.String,languageCode);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldLanguageId",DbType.Int32,oldlanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Language using Stored Procedure
		/// </summary>
		public DbCommand UpdateLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateLanguage");

		    		Database.AddInParameter(command,"LanguageCode",DbType.String,"LanguageCode",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"oldLanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Language using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteLanguage( int languageId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteLanguage");
			Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Language Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteLanguage");
				Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Language using Stored Procedure
		/// and return number of rows effected of the Language
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Language",InsertNewLanguageCommand(),UpdateLanguageCommand(),DeleteLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Language using Stored Procedure
		/// and return number of rows effected of the Language
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Language",InsertNewLanguageCommand(),UpdateLanguageCommand(),DeleteLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
