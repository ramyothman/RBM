using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for BusinessEntity table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the BusinessEntity table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class BusinessEntityDAC : DataAccessComponent
	{
		#region Constructors
        public BusinessEntityDAC() : base("", "Person.BusinessEntity") { }
		public BusinessEntityDAC(string connectionString): base(connectionString){}
		public BusinessEntityDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all BusinessEntity using Stored Procedure
		/// and return a DataTable containing all BusinessEntity Data
		/// </summary>
		public DataTable GetAllBusinessEntity()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "BusinessEntity";
         string query = " select * from GetAllBusinessEntity";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["BusinessEntity"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all BusinessEntity using Stored Procedure
		/// and return a DataTable containing all BusinessEntity Data using a Transaction
		/// </summary>
		public DataTable GetAllBusinessEntity(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "BusinessEntity";
         string query = " select * from GetAllBusinessEntity";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["BusinessEntity"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all BusinessEntity using Stored Procedure
		/// and return a DataTable containing all BusinessEntity Data
		/// </summary>
		public DataTable GetAllBusinessEntity(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "BusinessEntity";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllBusinessEntity" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["BusinessEntity"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all BusinessEntity using Stored Procedure
		/// and return a DataTable containing all BusinessEntity Data using a Transaction
		/// </summary>
		public DataTable GetAllBusinessEntity(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "BusinessEntity";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllBusinessEntity" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["BusinessEntity"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From BusinessEntity using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDBusinessEntity( int businessEntityId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDBusinessEntity");
				    Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
                    IDataReader reader = this.FromCache(command).CreateDataReader(); //Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From BusinessEntity using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDBusinessEntity( int businessEntityId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDBusinessEntity");
				    Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into BusinessEntity using Stored Procedure
		/// and return the auto number primary key of BusinessEntity inserted row
		/// </summary>
		public bool InsertNewBusinessEntity( ref int businessEntityId,  Guid rowGuid,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewBusinessEntity");
				Database.AddOutParameter(command,"BusinessEntityId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 businessEntityId = Convert.ToInt32(Database.GetParameterValue(command, "BusinessEntityId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into BusinessEntity using Stored Procedure
		/// and return the auto number primary key of BusinessEntity inserted row using Transaction
		/// </summary>
		public bool InsertNewBusinessEntity( ref int businessEntityId,  Guid rowGuid,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewBusinessEntity");
				Database.AddOutParameter(command,"BusinessEntityId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 businessEntityId = Convert.ToInt32(Database.GetParameterValue(command, "BusinessEntityId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for BusinessEntity using Stored Procedure
		/// and return DbCommand of the BusinessEntity
		/// </summary>
		public DbCommand InsertNewBusinessEntityCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewBusinessEntity");

				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into BusinessEntity using Stored Procedure
		/// </summary>
		public bool UpdateBusinessEntity( Guid rowGuid, DateTime modifiedDate, int oldbusinessEntityId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateBusinessEntity");

		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldBusinessEntityId",DbType.Int32,oldbusinessEntityId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into BusinessEntity using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateBusinessEntity( Guid rowGuid, DateTime modifiedDate, int oldbusinessEntityId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateBusinessEntity");

		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldBusinessEntityId",DbType.Int32,oldbusinessEntityId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from BusinessEntity using Stored Procedure
		/// </summary>
		public DbCommand UpdateBusinessEntityCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateBusinessEntity");

		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldBusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From BusinessEntity using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteBusinessEntity( int businessEntityId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteBusinessEntity");
			Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From BusinessEntity Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteBusinessEntityCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteBusinessEntity");
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table BusinessEntity using Stored Procedure
		/// and return number of rows effected of the BusinessEntity
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"BusinessEntity",InsertNewBusinessEntityCommand(),UpdateBusinessEntityCommand(),DeleteBusinessEntityCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table BusinessEntity using Stored Procedure
		/// and return number of rows effected of the BusinessEntity
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"BusinessEntity",InsertNewBusinessEntityCommand(),UpdateBusinessEntityCommand(),DeleteBusinessEntityCommand(), transaction);
          return rowsAffected;
		}


	}
}
