using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for MenuEntityItemLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the MenuEntityItemLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class MenuEntityItemLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public MenuEntityItemLanguageDAC() : base("", "ContentManagement.MenuEntityItemLanguage") { }
		public MenuEntityItemLanguageDAC(string connectionString): base(connectionString){}
		public MenuEntityItemLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityItemLanguage using Stored Procedure
		/// and return a DataTable containing all MenuEntityItemLanguage Data
		/// </summary>
		public DataTable GetAllMenuEntityItemLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityItemLanguage";
         string query = " select * from GetAllMenuEntityItemLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MenuEntityItemLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityItemLanguage using Stored Procedure
		/// and return a DataTable containing all MenuEntityItemLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllMenuEntityItemLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityItemLanguage";
         string query = " select * from GetAllMenuEntityItemLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MenuEntityItemLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityItemLanguage using Stored Procedure
		/// and return a DataTable containing all MenuEntityItemLanguage Data
		/// </summary>
		public DataTable GetAllMenuEntityItemLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityItemLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllMenuEntityItemLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MenuEntityItemLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityItemLanguage using Stored Procedure
		/// and return a DataTable containing all MenuEntityItemLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllMenuEntityItemLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityItemLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllMenuEntityItemLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MenuEntityItemLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MenuEntityItemLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMenuEntityItemLanguage( int menuEntityItemId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMenuEntityItemLanguage");
				    Database.AddInParameter(command,"MenuEntityItemId",DbType.Int32,menuEntityItemId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MenuEntityItemLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMenuEntityItemLanguage( int menuEntityItemId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMenuEntityItemLanguage");
				    Database.AddInParameter(command,"MenuEntityItemId",DbType.Int32,menuEntityItemId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MenuEntityItemLanguage using Stored Procedure
		/// and return the auto number primary key of MenuEntityItemLanguage inserted row
		/// </summary>
		public bool InsertNewMenuEntityItemLanguage( ref int menuEntityItemId,  string name,  int languageID,  int parentId)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMenuEntityItemLanguage");
				Database.AddOutParameter(command,"MenuEntityItemId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"ParentId",DbType.Int32,parentId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 menuEntityItemId = Convert.ToInt32(Database.GetParameterValue(command, "MenuEntityItemId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MenuEntityItemLanguage using Stored Procedure
		/// and return the auto number primary key of MenuEntityItemLanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewMenuEntityItemLanguage( ref int menuEntityItemId,  string name,  int languageID,  int parentId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMenuEntityItemLanguage");
				Database.AddOutParameter(command,"MenuEntityItemId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"ParentId",DbType.Int32,parentId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 menuEntityItemId = Convert.ToInt32(Database.GetParameterValue(command, "MenuEntityItemId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for MenuEntityItemLanguage using Stored Procedure
		/// and return DbCommand of the MenuEntityItemLanguage
		/// </summary>
		public DbCommand InsertNewMenuEntityItemLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMenuEntityItemLanguage");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"ParentId",DbType.Int32,"ParentId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MenuEntityItemLanguage using Stored Procedure
		/// </summary>
		public bool UpdateMenuEntityItemLanguage( string name, int languageID, int parentId, int oldmenuEntityItemId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMenuEntityItemLanguage");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"ParentId",DbType.Int32,parentId);
				Database.AddInParameter(command,"oldMenuEntityItemId",DbType.Int32,oldmenuEntityItemId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MenuEntityItemLanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateMenuEntityItemLanguage( string name, int languageID, int parentId, int oldmenuEntityItemId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMenuEntityItemLanguage");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"ParentId",DbType.Int32,parentId);
				Database.AddInParameter(command,"oldMenuEntityItemId",DbType.Int32,oldmenuEntityItemId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from MenuEntityItemLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateMenuEntityItemLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMenuEntityItemLanguage");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ParentId",DbType.Int32,"ParentId",DataRowVersion.Current);
				Database.AddInParameter(command,"oldMenuEntityItemId",DbType.Int32,"MenuEntityItemId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From MenuEntityItemLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteMenuEntityItemLanguage( int menuEntityItemId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteMenuEntityItemLanguage");
			Database.AddInParameter(command,"MenuEntityItemId",DbType.Int32,menuEntityItemId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From MenuEntityItemLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteMenuEntityItemLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteMenuEntityItemLanguage");
				Database.AddInParameter(command,"MenuEntityItemId",DbType.Int32,"MenuEntityItemId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MenuEntityItemLanguage using Stored Procedure
		/// and return number of rows effected of the MenuEntityItemLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MenuEntityItemLanguage",InsertNewMenuEntityItemLanguageCommand(),UpdateMenuEntityItemLanguageCommand(),DeleteMenuEntityItemLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MenuEntityItemLanguage using Stored Procedure
		/// and return number of rows effected of the MenuEntityItemLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MenuEntityItemLanguage",InsertNewMenuEntityItemLanguageCommand(),UpdateMenuEntityItemLanguageCommand(),DeleteMenuEntityItemLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
