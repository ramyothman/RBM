using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.RoleSecurity
{
	/// <summary>
	/// This is a Data Access Class  for RolePrivilege table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the RolePrivilege table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class RolePrivilegeDAC : DataAccessComponent
	{
		#region Constructors
        public RolePrivilegeDAC() : base("", "RoleSecurity.RolePrivilege") { }
		public RolePrivilegeDAC(string connectionString): base(connectionString){}
		public RolePrivilegeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all RolePrivilege using Stored Procedure
		/// and return a DataTable containing all RolePrivilege Data
		/// </summary>
		public DataTable GetAllRolePrivilege()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "RolePrivilege";
         string query = " select * from GetAllRolePrivilege";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["RolePrivilege"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all RolePrivilege using Stored Procedure
		/// and return a DataTable containing all RolePrivilege Data using a Transaction
		/// </summary>
		public DataTable GetAllRolePrivilege(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "RolePrivilege";
         string query = " select * from GetAllRolePrivilege";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["RolePrivilege"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all RolePrivilege using Stored Procedure
		/// and return a DataTable containing all RolePrivilege Data
		/// </summary>
		public DataTable GetAllRolePrivilege(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "RolePrivilege";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllRolePrivilege" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["RolePrivilege"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all RolePrivilege using Stored Procedure
		/// and return a DataTable containing all RolePrivilege Data using a Transaction
		/// </summary>
		public DataTable GetAllRolePrivilege(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "RolePrivilege";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllRolePrivilege" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["RolePrivilege"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From RolePrivilege using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDRolePrivilege( int rolePrivilegeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDRolePrivilege");
				    Database.AddInParameter(command,"RolePrivilegeId",DbType.Int32,rolePrivilegeId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From RolePrivilege using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDRolePrivilege( int rolePrivilegeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDRolePrivilege");
				    Database.AddInParameter(command,"RolePrivilegeId",DbType.Int32,rolePrivilegeId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into RolePrivilege using Stored Procedure
		/// and return the auto number primary key of RolePrivilege inserted row
		/// </summary>
		public bool InsertNewRolePrivilege( ref int rolePrivilegeId,  int roleId,  int contentEntityId,  int systemFunctionId,  bool hasAccess,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewRolePrivilege");
				Database.AddOutParameter(command,"RolePrivilegeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"RoleId",DbType.Int32,roleId);
				Database.AddInParameter(command,"ContentEntityId",DbType.Int32,contentEntityId);
				Database.AddInParameter(command,"SystemFunctionId",DbType.Int32,systemFunctionId);
				Database.AddInParameter(command,"HasAccess",DbType.Boolean,hasAccess);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 rolePrivilegeId = Convert.ToInt32(Database.GetParameterValue(command, "RolePrivilegeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into RolePrivilege using Stored Procedure
		/// and return the auto number primary key of RolePrivilege inserted row using Transaction
		/// </summary>
		public bool InsertNewRolePrivilege( ref int rolePrivilegeId,  int roleId,  int contentEntityId,  int systemFunctionId,  bool hasAccess,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewRolePrivilege");
				Database.AddOutParameter(command,"RolePrivilegeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"RoleId",DbType.Int32,roleId);
				Database.AddInParameter(command,"ContentEntityId",DbType.Int32,contentEntityId);
				Database.AddInParameter(command,"SystemFunctionId",DbType.Int32,systemFunctionId);
				Database.AddInParameter(command,"HasAccess",DbType.Boolean,hasAccess);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 rolePrivilegeId = Convert.ToInt32(Database.GetParameterValue(command, "RolePrivilegeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for RolePrivilege using Stored Procedure
		/// and return DbCommand of the RolePrivilege
		/// </summary>
		public DbCommand InsertNewRolePrivilegeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewRolePrivilege");

				Database.AddInParameter(command,"RoleId",DbType.Int32,"RoleId",DataRowVersion.Current);
				Database.AddInParameter(command,"ContentEntityId",DbType.Int32,"ContentEntityId",DataRowVersion.Current);
				Database.AddInParameter(command,"SystemFunctionId",DbType.Int32,"SystemFunctionId",DataRowVersion.Current);
				Database.AddInParameter(command,"HasAccess",DbType.Boolean,"HasAccess",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into RolePrivilege using Stored Procedure
		/// </summary>
		public bool UpdateRolePrivilege( int roleId, int contentEntityId, int systemFunctionId, bool hasAccess, DateTime modifiedDate, int oldrolePrivilegeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateRolePrivilege");

		    		Database.AddInParameter(command,"RoleId",DbType.Int32,roleId);
		    		Database.AddInParameter(command,"ContentEntityId",DbType.Int32,contentEntityId);
		    		Database.AddInParameter(command,"SystemFunctionId",DbType.Int32,systemFunctionId);
		    		Database.AddInParameter(command,"HasAccess",DbType.Boolean,hasAccess);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldRolePrivilegeId",DbType.Int32,oldrolePrivilegeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into RolePrivilege using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateRolePrivilege( int roleId, int contentEntityId, int systemFunctionId, bool hasAccess, DateTime modifiedDate, int oldrolePrivilegeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateRolePrivilege");

		    		Database.AddInParameter(command,"RoleId",DbType.Int32,roleId);
		    		Database.AddInParameter(command,"ContentEntityId",DbType.Int32,contentEntityId);
		    		Database.AddInParameter(command,"SystemFunctionId",DbType.Int32,systemFunctionId);
		    		Database.AddInParameter(command,"HasAccess",DbType.Boolean,hasAccess);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldRolePrivilegeId",DbType.Int32,oldrolePrivilegeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from RolePrivilege using Stored Procedure
		/// </summary>
		public DbCommand UpdateRolePrivilegeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateRolePrivilege");

		    		Database.AddInParameter(command,"RoleId",DbType.Int32,"RoleId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ContentEntityId",DbType.Int32,"ContentEntityId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SystemFunctionId",DbType.Int32,"SystemFunctionId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"HasAccess",DbType.Boolean,"HasAccess",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldRolePrivilegeId",DbType.Int32,"RolePrivilegeId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From RolePrivilege using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteRolePrivilege( int rolePrivilegeId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteRolePrivilege");
			Database.AddInParameter(command,"RolePrivilegeId",DbType.Int32,rolePrivilegeId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From RolePrivilege Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteRolePrivilegeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteRolePrivilege");
				Database.AddInParameter(command,"RolePrivilegeId",DbType.Int32,"RolePrivilegeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table RolePrivilege using Stored Procedure
		/// and return number of rows effected of the RolePrivilege
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"RolePrivilege",InsertNewRolePrivilegeCommand(),UpdateRolePrivilegeCommand(),DeleteRolePrivilegeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table RolePrivilege using Stored Procedure
		/// and return number of rows effected of the RolePrivilege
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"RolePrivilege",InsertNewRolePrivilegeCommand(),UpdateRolePrivilegeCommand(),DeleteRolePrivilegeCommand(), transaction);
          return rowsAffected;
		}


	}
}
