using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for BusinessEntityAddress table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the BusinessEntityAddress table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class BusinessEntityAddressDAC : DataAccessComponent
	{
		#region Constructors
        public BusinessEntityAddressDAC() : base("", "Person.BusinessEntityAddress") { }
		public BusinessEntityAddressDAC(string connectionString): base(connectionString){}
		public BusinessEntityAddressDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all BusinessEntityAddress using Stored Procedure
		/// and return a DataTable containing all BusinessEntityAddress Data
		/// </summary>
		public DataTable GetAllBusinessEntityAddress()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "BusinessEntityAddress";
         string query = " select * from GetAllBusinessEntityAddress";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["BusinessEntityAddress"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all BusinessEntityAddress using Stored Procedure
		/// and return a DataTable containing all BusinessEntityAddress Data using a Transaction
		/// </summary>
		public DataTable GetAllBusinessEntityAddress(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "BusinessEntityAddress";
         string query = " select * from GetAllBusinessEntityAddress";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["BusinessEntityAddress"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all BusinessEntityAddress using Stored Procedure
		/// and return a DataTable containing all BusinessEntityAddress Data
		/// </summary>
		public DataTable GetAllBusinessEntityAddress(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "BusinessEntityAddress";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllBusinessEntityAddress" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["BusinessEntityAddress"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all BusinessEntityAddress using Stored Procedure
		/// and return a DataTable containing all BusinessEntityAddress Data using a Transaction
		/// </summary>
		public DataTable GetAllBusinessEntityAddress(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "BusinessEntityAddress";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllBusinessEntityAddress" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["BusinessEntityAddress"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From BusinessEntityAddress using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDBusinessEntityAddress( int businessEntityAddressId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDBusinessEntityAddress");
				    Database.AddInParameter(command,"BusinessEntityAddressId",DbType.Int32,businessEntityAddressId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From BusinessEntityAddress using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDBusinessEntityAddress( int businessEntityAddressId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDBusinessEntityAddress");
				    Database.AddInParameter(command,"BusinessEntityAddressId",DbType.Int32,businessEntityAddressId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into BusinessEntityAddress using Stored Procedure
		/// and return the auto number primary key of BusinessEntityAddress inserted row
		/// </summary>
		public bool InsertNewBusinessEntityAddress( ref int businessEntityAddressId,  int businessEntityId,  int addressId,  int addressTypeId,  Guid rowGuid,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewBusinessEntityAddress");
				Database.AddOutParameter(command,"BusinessEntityAddressId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				Database.AddInParameter(command,"AddressId",DbType.Int32,addressId);
				Database.AddInParameter(command,"AddressTypeId",DbType.Int32,addressTypeId);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 businessEntityAddressId = Convert.ToInt32(Database.GetParameterValue(command, "BusinessEntityAddressId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into BusinessEntityAddress using Stored Procedure
		/// and return the auto number primary key of BusinessEntityAddress inserted row using Transaction
		/// </summary>
		public bool InsertNewBusinessEntityAddress( ref int businessEntityAddressId,  int businessEntityId,  int addressId,  int addressTypeId,  Guid rowGuid,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewBusinessEntityAddress");
				Database.AddOutParameter(command,"BusinessEntityAddressId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				Database.AddInParameter(command,"AddressId",DbType.Int32,addressId);
				Database.AddInParameter(command,"AddressTypeId",DbType.Int32,addressTypeId);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 businessEntityAddressId = Convert.ToInt32(Database.GetParameterValue(command, "BusinessEntityAddressId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for BusinessEntityAddress using Stored Procedure
		/// and return DbCommand of the BusinessEntityAddress
		/// </summary>
		public DbCommand InsertNewBusinessEntityAddressCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewBusinessEntityAddress");

				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);
				Database.AddInParameter(command,"AddressId",DbType.Int32,"AddressId",DataRowVersion.Current);
				Database.AddInParameter(command,"AddressTypeId",DbType.Int32,"AddressTypeId",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into BusinessEntityAddress using Stored Procedure
		/// </summary>
		public bool UpdateBusinessEntityAddress( int businessEntityId, int addressId, int addressTypeId, Guid rowGuid, DateTime modifiedDate, int oldbusinessEntityAddressId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateBusinessEntityAddress");

		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
		    		Database.AddInParameter(command,"AddressId",DbType.Int32,addressId);
		    		Database.AddInParameter(command,"AddressTypeId",DbType.Int32,addressTypeId);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldBusinessEntityAddressId",DbType.Int32,oldbusinessEntityAddressId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into BusinessEntityAddress using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateBusinessEntityAddress( int businessEntityId, int addressId, int addressTypeId, Guid rowGuid, DateTime modifiedDate, int oldbusinessEntityAddressId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateBusinessEntityAddress");

		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
		    		Database.AddInParameter(command,"AddressId",DbType.Int32,addressId);
		    		Database.AddInParameter(command,"AddressTypeId",DbType.Int32,addressTypeId);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldBusinessEntityAddressId",DbType.Int32,oldbusinessEntityAddressId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from BusinessEntityAddress using Stored Procedure
		/// </summary>
		public DbCommand UpdateBusinessEntityAddressCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateBusinessEntityAddress");

		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AddressId",DbType.Int32,"AddressId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AddressTypeId",DbType.Int32,"AddressTypeId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldBusinessEntityAddressId",DbType.Int32,"BusinessEntityAddressId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From BusinessEntityAddress using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteBusinessEntityAddress( int businessEntityAddressId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteBusinessEntityAddress");
			Database.AddInParameter(command,"BusinessEntityAddressId",DbType.Int32,businessEntityAddressId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From BusinessEntityAddress Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteBusinessEntityAddressCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteBusinessEntityAddress");
				Database.AddInParameter(command,"BusinessEntityAddressId",DbType.Int32,"BusinessEntityAddressId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table BusinessEntityAddress using Stored Procedure
		/// and return number of rows effected of the BusinessEntityAddress
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"BusinessEntityAddress",InsertNewBusinessEntityAddressCommand(),UpdateBusinessEntityAddressCommand(),DeleteBusinessEntityAddressCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table BusinessEntityAddress using Stored Procedure
		/// and return number of rows effected of the BusinessEntityAddress
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"BusinessEntityAddress",InsertNewBusinessEntityAddressCommand(),UpdateBusinessEntityAddressCommand(),DeleteBusinessEntityAddressCommand(), transaction);
          return rowsAffected;
		}


	}
}
