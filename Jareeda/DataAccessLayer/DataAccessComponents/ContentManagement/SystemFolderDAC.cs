using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for SystemFolder table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the SystemFolder table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SystemFolderDAC : DataAccessComponent
	{
		#region Constructors
        public SystemFolderDAC() : base("", "ContentManagement.SystemFolder") { }
		public SystemFolderDAC(string connectionString): base(connectionString){}
		public SystemFolderDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemFolder using Stored Procedure
		/// and return a DataTable containing all SystemFolder Data
		/// </summary>
		public DataTable GetAllSystemFolder()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemFolder";
         string query = " select * from GetAllSystemFolder";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SystemFolder"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemFolder using Stored Procedure
		/// and return a DataTable containing all SystemFolder Data using a Transaction
		/// </summary>
		public DataTable GetAllSystemFolder(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemFolder";
         string query = " select * from GetAllSystemFolder";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SystemFolder"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemFolder using Stored Procedure
		/// and return a DataTable containing all SystemFolder Data
		/// </summary>
		public DataTable GetAllSystemFolder(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemFolder";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSystemFolder" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SystemFolder"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemFolder using Stored Procedure
		/// and return a DataTable containing all SystemFolder Data using a Transaction
		/// </summary>
		public DataTable GetAllSystemFolder(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemFolder";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSystemFolder" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SystemFolder"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SystemFolder using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSystemFolder( int systemFolderId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSystemFolder");
				    Database.AddInParameter(command,"SystemFolderId",DbType.Int32,systemFolderId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SystemFolder using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSystemFolder( int systemFolderId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSystemFolder");
				    Database.AddInParameter(command,"SystemFolderId",DbType.Int32,systemFolderId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SystemFolder using Stored Procedure
		/// and return the auto number primary key of SystemFolder inserted row
		/// </summary>
		public bool InsertNewSystemFolder( int systemFolderId,  string name,  string path)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSystemFolder");
				Database.AddInParameter(command,"SystemFolderId",DbType.Int32,systemFolderId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Path",DbType.String,path);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SystemFolder using Stored Procedure
		/// and return the auto number primary key of SystemFolder inserted row using Transaction
		/// </summary>
		public bool InsertNewSystemFolder( int systemFolderId,  string name,  string path,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSystemFolder");
				Database.AddInParameter(command,"SystemFolderId",DbType.Int32,systemFolderId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Path",DbType.String,path);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for SystemFolder using Stored Procedure
		/// and return DbCommand of the SystemFolder
		/// </summary>
		public DbCommand InsertNewSystemFolderCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSystemFolder");
				Database.AddInParameter(command,"SystemFolderId",DbType.Int32,"SystemFolderId",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"Path",DbType.String,"Path",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SystemFolder using Stored Procedure
		/// </summary>
		public bool UpdateSystemFolder( int systemFolderId, string name, string path, int oldsystemFolderId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSystemFolder");
		    		Database.AddInParameter(command,"SystemFolderId",DbType.Int32,systemFolderId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Path",DbType.String,path);
				Database.AddInParameter(command,"oldSystemFolderId",DbType.Int32,oldsystemFolderId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SystemFolder using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSystemFolder( int systemFolderId, string name, string path, int oldsystemFolderId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSystemFolder");
		    		Database.AddInParameter(command,"SystemFolderId",DbType.Int32,systemFolderId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Path",DbType.String,path);
				Database.AddInParameter(command,"oldSystemFolderId",DbType.Int32,oldsystemFolderId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from SystemFolder using Stored Procedure
		/// </summary>
		public DbCommand UpdateSystemFolderCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSystemFolder");
		    		Database.AddInParameter(command,"SystemFolderId",DbType.Int32,"SystemFolderId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Path",DbType.String,"Path",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSystemFolderId",DbType.Int32,"SystemFolderId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From SystemFolder using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSystemFolder( int systemFolderId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSystemFolder");
			Database.AddInParameter(command,"SystemFolderId",DbType.Int32,systemFolderId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From SystemFolder Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSystemFolderCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSystemFolder");
				Database.AddInParameter(command,"SystemFolderId",DbType.Int32,"SystemFolderId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SystemFolder using Stored Procedure
		/// and return number of rows effected of the SystemFolder
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SystemFolder",InsertNewSystemFolderCommand(),UpdateSystemFolderCommand(),DeleteSystemFolderCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SystemFolder using Stored Procedure
		/// and return number of rows effected of the SystemFolder
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SystemFolder",InsertNewSystemFolderCommand(),UpdateSystemFolderCommand(),DeleteSystemFolderCommand(), transaction);
          return rowsAffected;
		}


	}
}
