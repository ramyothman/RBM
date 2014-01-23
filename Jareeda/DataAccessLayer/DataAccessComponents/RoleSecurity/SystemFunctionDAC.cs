using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.RoleSecurity
{
	/// <summary>
	/// This is a Data Access Class  for SystemFunction table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the SystemFunction table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SystemFunctionDAC : DataAccessComponent
	{
		#region Constructors
        public SystemFunctionDAC() : base("", "RoleSecurity.SystemFunction") { }
		public SystemFunctionDAC(string connectionString): base(connectionString){}
		public SystemFunctionDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemFunction using Stored Procedure
		/// and return a DataTable containing all SystemFunction Data
		/// </summary>
		public DataTable GetAllSystemFunction()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemFunction";
         string query = " select * from GetAllSystemFunction";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SystemFunction"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemFunction using Stored Procedure
		/// and return a DataTable containing all SystemFunction Data using a Transaction
		/// </summary>
		public DataTable GetAllSystemFunction(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemFunction";
         string query = " select * from GetAllSystemFunction";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SystemFunction"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemFunction using Stored Procedure
		/// and return a DataTable containing all SystemFunction Data
		/// </summary>
		public DataTable GetAllSystemFunction(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemFunction";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSystemFunction" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SystemFunction"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemFunction using Stored Procedure
		/// and return a DataTable containing all SystemFunction Data using a Transaction
		/// </summary>
		public DataTable GetAllSystemFunction(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemFunction";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSystemFunction" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SystemFunction"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SystemFunction using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSystemFunction( int systemFunctionId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSystemFunction");
				    Database.AddInParameter(command,"SystemFunctionId",DbType.Int32,systemFunctionId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SystemFunction using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSystemFunction( int systemFunctionId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSystemFunction");
				    Database.AddInParameter(command,"SystemFunctionId",DbType.Int32,systemFunctionId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SystemFunction using Stored Procedure
		/// and return the auto number primary key of SystemFunction inserted row
		/// </summary>
		public bool InsertNewSystemFunction( ref int systemFunctionId,  string name,  bool isActive,  bool isBackendFunction,  Guid rowGuid,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSystemFunction");
				Database.AddOutParameter(command,"SystemFunctionId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"IsBackendFunction",DbType.Boolean,isBackendFunction);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 systemFunctionId = Convert.ToInt32(Database.GetParameterValue(command, "SystemFunctionId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SystemFunction using Stored Procedure
		/// and return the auto number primary key of SystemFunction inserted row using Transaction
		/// </summary>
		public bool InsertNewSystemFunction( ref int systemFunctionId,  string name,  bool isActive,  bool isBackendFunction,  Guid rowGuid,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSystemFunction");
				Database.AddOutParameter(command,"SystemFunctionId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"IsBackendFunction",DbType.Boolean,isBackendFunction);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 systemFunctionId = Convert.ToInt32(Database.GetParameterValue(command, "SystemFunctionId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for SystemFunction using Stored Procedure
		/// and return DbCommand of the SystemFunction
		/// </summary>
		public DbCommand InsertNewSystemFunctionCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSystemFunction");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
				Database.AddInParameter(command,"IsBackendFunction",DbType.Boolean,"IsBackendFunction",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SystemFunction using Stored Procedure
		/// </summary>
		public bool UpdateSystemFunction( string name, bool isActive, bool isBackendFunction, Guid rowGuid, DateTime modifiedDate, int oldsystemFunctionId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSystemFunction");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
		    		Database.AddInParameter(command,"IsBackendFunction",DbType.Boolean,isBackendFunction);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSystemFunctionId",DbType.Int32,oldsystemFunctionId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SystemFunction using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSystemFunction( string name, bool isActive, bool isBackendFunction, Guid rowGuid, DateTime modifiedDate, int oldsystemFunctionId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSystemFunction");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
		    		Database.AddInParameter(command,"IsBackendFunction",DbType.Boolean,isBackendFunction);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSystemFunctionId",DbType.Int32,oldsystemFunctionId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from SystemFunction using Stored Procedure
		/// </summary>
		public DbCommand UpdateSystemFunctionCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSystemFunction");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsBackendFunction",DbType.Boolean,"IsBackendFunction",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSystemFunctionId",DbType.Int32,"SystemFunctionId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From SystemFunction using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSystemFunction( int systemFunctionId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSystemFunction");
			Database.AddInParameter(command,"SystemFunctionId",DbType.Int32,systemFunctionId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From SystemFunction Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSystemFunctionCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSystemFunction");
				Database.AddInParameter(command,"SystemFunctionId",DbType.Int32,"SystemFunctionId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SystemFunction using Stored Procedure
		/// and return number of rows effected of the SystemFunction
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SystemFunction",InsertNewSystemFunctionCommand(),UpdateSystemFunctionCommand(),DeleteSystemFunctionCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SystemFunction using Stored Procedure
		/// and return number of rows effected of the SystemFunction
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SystemFunction",InsertNewSystemFunctionCommand(),UpdateSystemFunctionCommand(),DeleteSystemFunctionCommand(), transaction);
          return rowsAffected;
		}


	}
}
