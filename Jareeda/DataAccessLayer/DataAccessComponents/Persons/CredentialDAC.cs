using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for Credential table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Credential table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class CredentialDAC : DataAccessComponent
	{
		#region Constructors
        public CredentialDAC() : base("", "Person.Credential") { }
		public CredentialDAC(string connectionString): base(connectionString){}
		public CredentialDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Credential using Stored Procedure
		/// and return a DataTable containing all Credential Data
		/// </summary>
		public DataTable GetAllCredential()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Credential";
         string query = " select * from GetAllCredential";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Credential"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Credential using Stored Procedure
		/// and return a DataTable containing all Credential Data using a Transaction
		/// </summary>
		public DataTable GetAllCredential(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Credential";
         string query = " select * from GetAllCredential";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Credential"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Credential using Stored Procedure
		/// and return a DataTable containing all Credential Data
		/// </summary>
		public DataTable GetAllCredential(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Credential";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllCredential" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Credential"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Credential using Stored Procedure
		/// and return a DataTable containing all Credential Data using a Transaction
		/// </summary>
		public DataTable GetAllCredential(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Credential";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllCredential" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Credential"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Credential using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDCredential( int businessEntityId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDCredential");
				    Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Credential using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDCredential( int businessEntityId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDCredential");
				    Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Credential using Stored Procedure
		/// and return the auto number primary key of Credential inserted row
		/// </summary>
		public bool InsertNewCredential( int businessEntityId,  string username,  string passwordHash,  string passwordSalt,  string activationCode,  bool isActivated,  bool isActive,  Guid rowGuid,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewCredential");
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				Database.AddInParameter(command,"Username",DbType.String,username);
				Database.AddInParameter(command,"PasswordHash",DbType.String,passwordHash);
				Database.AddInParameter(command,"PasswordSalt",DbType.String,passwordSalt);
				Database.AddInParameter(command,"ActivationCode",DbType.String,activationCode);
				Database.AddInParameter(command,"IsActivated",DbType.Boolean,isActivated);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Credential using Stored Procedure
		/// and return the auto number primary key of Credential inserted row using Transaction
		/// </summary>
		public bool InsertNewCredential( int businessEntityId,  string username,  string passwordHash,  string passwordSalt,  string activationCode,  bool isActivated,  bool isActive,  Guid rowGuid,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewCredential");
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				Database.AddInParameter(command,"Username",DbType.String,username);
				Database.AddInParameter(command,"PasswordHash",DbType.String,passwordHash);
				Database.AddInParameter(command,"PasswordSalt",DbType.String,passwordSalt);
				Database.AddInParameter(command,"ActivationCode",DbType.String,activationCode);
				Database.AddInParameter(command,"IsActivated",DbType.Boolean,isActivated);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Credential using Stored Procedure
		/// and return DbCommand of the Credential
		/// </summary>
		public DbCommand InsertNewCredentialCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewCredential");
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);
				Database.AddInParameter(command,"Username",DbType.String,"Username",DataRowVersion.Current);
				Database.AddInParameter(command,"PasswordHash",DbType.String,"PasswordHash",DataRowVersion.Current);
				Database.AddInParameter(command,"PasswordSalt",DbType.String,"PasswordSalt",DataRowVersion.Current);
				Database.AddInParameter(command,"ActivationCode",DbType.String,"ActivationCode",DataRowVersion.Current);
				Database.AddInParameter(command,"IsActivated",DbType.Boolean,"IsActivated",DataRowVersion.Current);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Credential using Stored Procedure
		/// </summary>
		public bool UpdateCredential( int businessEntityId, string username, string passwordHash, string passwordSalt, string activationCode, bool isActivated, bool isActive, Guid rowGuid, DateTime modifiedDate, int oldbusinessEntityId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateCredential");
		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
		    		Database.AddInParameter(command,"Username",DbType.String,username);
		    		Database.AddInParameter(command,"PasswordHash",DbType.String,passwordHash);
		    		Database.AddInParameter(command,"PasswordSalt",DbType.String,passwordSalt);
		    		Database.AddInParameter(command,"ActivationCode",DbType.String,activationCode);
		    		Database.AddInParameter(command,"IsActivated",DbType.Boolean,isActivated);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
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
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Credential using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateCredential( int businessEntityId, string username, string passwordHash, string passwordSalt, string activationCode, bool isActivated, bool isActive, Guid rowGuid, DateTime modifiedDate, int oldbusinessEntityId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateCredential");
		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
		    		Database.AddInParameter(command,"Username",DbType.String,username);
		    		Database.AddInParameter(command,"PasswordHash",DbType.String,passwordHash);
		    		Database.AddInParameter(command,"PasswordSalt",DbType.String,passwordSalt);
		    		Database.AddInParameter(command,"ActivationCode",DbType.String,activationCode);
		    		Database.AddInParameter(command,"IsActivated",DbType.Boolean,isActivated);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
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
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Credential using Stored Procedure
		/// </summary>
		public DbCommand UpdateCredentialCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateCredential");
		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Username",DbType.String,"Username",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PasswordHash",DbType.String,"PasswordHash",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PasswordSalt",DbType.String,"PasswordSalt",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ActivationCode",DbType.String,"ActivationCode",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsActivated",DbType.Boolean,"IsActivated",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
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
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Credential using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteCredential( int businessEntityId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteCredential");
			Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Credential Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteCredentialCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteCredential");
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Credential using Stored Procedure
		/// and return number of rows effected of the Credential
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Credential",InsertNewCredentialCommand(),UpdateCredentialCommand(),DeleteCredentialCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Credential using Stored Procedure
		/// and return number of rows effected of the Credential
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Credential",InsertNewCredentialCommand(),UpdateCredentialCommand(),DeleteCredentialCommand(), transaction);
          return rowsAffected;
		}


	}
}
