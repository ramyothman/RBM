using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for SystemPage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the SystemPage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SystemPageDAC : DataAccessComponent
	{
		#region Constructors
        public SystemPageDAC() : base("", "ContentManagement.SystemPage") { }
		public SystemPageDAC(string connectionString): base(connectionString){}
		public SystemPageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemPage using Stored Procedure
		/// and return a DataTable containing all SystemPage Data
		/// </summary>
		public DataTable GetAllSystemPage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemPage";
         string query = " select * from GetAllSystemPage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SystemPage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemPage using Stored Procedure
		/// and return a DataTable containing all SystemPage Data using a Transaction
		/// </summary>
		public DataTable GetAllSystemPage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemPage";
         string query = " select * from GetAllSystemPage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SystemPage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemPage using Stored Procedure
		/// and return a DataTable containing all SystemPage Data
		/// </summary>
		public DataTable GetAllSystemPage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemPage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSystemPage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SystemPage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemPage using Stored Procedure
		/// and return a DataTable containing all SystemPage Data using a Transaction
		/// </summary>
		public DataTable GetAllSystemPage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemPage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSystemPage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SystemPage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SystemPage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSystemPage( int systemPageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSystemPage");
				    Database.AddInParameter(command,"SystemPageId",DbType.Int32,systemPageId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SystemPage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSystemPage( int systemPageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSystemPage");
				    Database.AddInParameter(command,"SystemPageId",DbType.Int32,systemPageId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SystemPage using Stored Procedure
		/// and return the auto number primary key of SystemPage inserted row
		/// </summary>
		public bool InsertNewSystemPage( int systemPageId,  string name,  string path,  int securityAccessTypeId,  bool isActive,  Guid rowGuid,  DateTime modifiedDate,  int systemFolderId)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSystemPage");
				Database.AddInParameter(command,"SystemPageId",DbType.Int32,systemPageId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Path",DbType.String,path);
				Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"SystemFolderId",DbType.Int32,systemFolderId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SystemPage using Stored Procedure
		/// and return the auto number primary key of SystemPage inserted row using Transaction
		/// </summary>
		public bool InsertNewSystemPage( int systemPageId,  string name,  string path,  int securityAccessTypeId,  bool isActive,  Guid rowGuid,  DateTime modifiedDate,  int systemFolderId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSystemPage");
				Database.AddInParameter(command,"SystemPageId",DbType.Int32,systemPageId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Path",DbType.String,path);
				Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"SystemFolderId",DbType.Int32,systemFolderId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for SystemPage using Stored Procedure
		/// and return DbCommand of the SystemPage
		/// </summary>
		public DbCommand InsertNewSystemPageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSystemPage");
				Database.AddInParameter(command,"SystemPageId",DbType.Int32,"SystemPageId",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"Path",DbType.String,"Path",DataRowVersion.Current);
				Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,"SecurityAccessTypeId",DataRowVersion.Current);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"SystemFolderId",DbType.Int32,"SystemFolderId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SystemPage using Stored Procedure
		/// </summary>
		public bool UpdateSystemPage( int systemPageId, string name, string path, int securityAccessTypeId, bool isActive, Guid rowGuid, DateTime modifiedDate, int systemFolderId, int oldsystemPageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSystemPage");
		    		Database.AddInParameter(command,"SystemPageId",DbType.Int32,systemPageId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Path",DbType.String,path);
		    		Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
		    		Database.AddInParameter(command,"SystemFolderId",DbType.Int32,systemFolderId);
				Database.AddInParameter(command,"oldSystemPageId",DbType.Int32,oldsystemPageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SystemPage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSystemPage( int systemPageId, string name, string path, int securityAccessTypeId, bool isActive, Guid rowGuid, DateTime modifiedDate, int systemFolderId, int oldsystemPageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSystemPage");
		    		Database.AddInParameter(command,"SystemPageId",DbType.Int32,systemPageId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Path",DbType.String,path);
		    		Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
		    		Database.AddInParameter(command,"SystemFolderId",DbType.Int32,systemFolderId);
				Database.AddInParameter(command,"oldSystemPageId",DbType.Int32,oldsystemPageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from SystemPage using Stored Procedure
		/// </summary>
		public DbCommand UpdateSystemPageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSystemPage");
		    		Database.AddInParameter(command,"SystemPageId",DbType.Int32,"SystemPageId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Path",DbType.String,"Path",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,"SecurityAccessTypeId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SystemFolderId",DbType.Int32,"SystemFolderId",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSystemPageId",DbType.Int32,"SystemPageId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From SystemPage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSystemPage( int systemPageId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSystemPage");
			Database.AddInParameter(command,"SystemPageId",DbType.Int32,systemPageId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From SystemPage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSystemPageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSystemPage");
				Database.AddInParameter(command,"SystemPageId",DbType.Int32,"SystemPageId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SystemPage using Stored Procedure
		/// and return number of rows effected of the SystemPage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SystemPage",InsertNewSystemPageCommand(),UpdateSystemPageCommand(),DeleteSystemPageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SystemPage using Stored Procedure
		/// and return number of rows effected of the SystemPage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SystemPage",InsertNewSystemPageCommand(),UpdateSystemPageCommand(),DeleteSystemPageCommand(), transaction);
          return rowsAffected;
		}


	}
}
