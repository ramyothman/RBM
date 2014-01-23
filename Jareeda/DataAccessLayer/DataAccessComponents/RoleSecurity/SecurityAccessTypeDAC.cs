using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.RoleSecurity
{
	/// <summary>
	/// This is a Data Access Class  for SecurityAccessType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the SecurityAccessType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SecurityAccessTypeDAC : DataAccessComponent
	{
		#region Constructors
        public SecurityAccessTypeDAC() : base("", "RoleSecurity.SecurityAccessType") { }
		public SecurityAccessTypeDAC(string connectionString): base(connectionString){}
		public SecurityAccessTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SecurityAccessType using Stored Procedure
		/// and return a DataTable containing all SecurityAccessType Data
		/// </summary>
		public DataTable GetAllSecurityAccessType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SecurityAccessType";
         string query = " select * from GetAllSecurityAccessType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SecurityAccessType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SecurityAccessType using Stored Procedure
		/// and return a DataTable containing all SecurityAccessType Data using a Transaction
		/// </summary>
		public DataTable GetAllSecurityAccessType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SecurityAccessType";
         string query = " select * from GetAllSecurityAccessType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SecurityAccessType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SecurityAccessType using Stored Procedure
		/// and return a DataTable containing all SecurityAccessType Data
		/// </summary>
		public DataTable GetAllSecurityAccessType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SecurityAccessType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSecurityAccessType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SecurityAccessType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SecurityAccessType using Stored Procedure
		/// and return a DataTable containing all SecurityAccessType Data using a Transaction
		/// </summary>
		public DataTable GetAllSecurityAccessType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SecurityAccessType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSecurityAccessType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SecurityAccessType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SecurityAccessType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSecurityAccessType( int securityAccessTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSecurityAccessType");
				    Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SecurityAccessType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSecurityAccessType( int securityAccessTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSecurityAccessType");
				    Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SecurityAccessType using Stored Procedure
		/// and return the auto number primary key of SecurityAccessType inserted row
		/// </summary>
		public bool InsertNewSecurityAccessType( ref int securityAccessTypeId,  string name,  Guid rowGuid,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSecurityAccessType");
				Database.AddOutParameter(command,"SecurityAccessTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 securityAccessTypeId = Convert.ToInt32(Database.GetParameterValue(command, "SecurityAccessTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SecurityAccessType using Stored Procedure
		/// and return the auto number primary key of SecurityAccessType inserted row using Transaction
		/// </summary>
		public bool InsertNewSecurityAccessType( ref int securityAccessTypeId,  string name,  Guid rowGuid,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSecurityAccessType");
				Database.AddOutParameter(command,"SecurityAccessTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 securityAccessTypeId = Convert.ToInt32(Database.GetParameterValue(command, "SecurityAccessTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for SecurityAccessType using Stored Procedure
		/// and return DbCommand of the SecurityAccessType
		/// </summary>
		public DbCommand InsertNewSecurityAccessTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSecurityAccessType");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SecurityAccessType using Stored Procedure
		/// </summary>
		public bool UpdateSecurityAccessType( string name, Guid rowGuid, DateTime modifiedDate, int oldsecurityAccessTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSecurityAccessType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSecurityAccessTypeId",DbType.Int32,oldsecurityAccessTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SecurityAccessType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSecurityAccessType( string name, Guid rowGuid, DateTime modifiedDate, int oldsecurityAccessTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSecurityAccessType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSecurityAccessTypeId",DbType.Int32,oldsecurityAccessTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from SecurityAccessType using Stored Procedure
		/// </summary>
		public DbCommand UpdateSecurityAccessTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSecurityAccessType");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSecurityAccessTypeId",DbType.Int32,"SecurityAccessTypeId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From SecurityAccessType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSecurityAccessType( int securityAccessTypeId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSecurityAccessType");
			Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From SecurityAccessType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSecurityAccessTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSecurityAccessType");
				Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,"SecurityAccessTypeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SecurityAccessType using Stored Procedure
		/// and return number of rows effected of the SecurityAccessType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SecurityAccessType",InsertNewSecurityAccessTypeCommand(),UpdateSecurityAccessTypeCommand(),DeleteSecurityAccessTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SecurityAccessType using Stored Procedure
		/// and return number of rows effected of the SecurityAccessType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SecurityAccessType",InsertNewSecurityAccessTypeCommand(),UpdateSecurityAccessTypeCommand(),DeleteSecurityAccessTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
