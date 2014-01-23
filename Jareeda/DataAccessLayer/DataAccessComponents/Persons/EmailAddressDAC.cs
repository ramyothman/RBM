using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for EmailAddress table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the EmailAddress table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class EmailAddressDAC : DataAccessComponent
	{
		#region Constructors
        public EmailAddressDAC() : base("", "Person.EmailAddress") { }
		public EmailAddressDAC(string connectionString): base(connectionString){}
		public EmailAddressDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmailAddress using Stored Procedure
		/// and return a DataTable containing all EmailAddress Data
		/// </summary>
		public DataTable GetAllEmailAddress()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmailAddress";
         string query = " select * from GetAllEmailAddress";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmailAddress"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmailAddress using Stored Procedure
		/// and return a DataTable containing all EmailAddress Data using a Transaction
		/// </summary>
		public DataTable GetAllEmailAddress(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmailAddress";
         string query = " select * from GetAllEmailAddress";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmailAddress"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmailAddress using Stored Procedure
		/// and return a DataTable containing all EmailAddress Data
		/// </summary>
		public DataTable GetAllEmailAddress(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmailAddress";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllEmailAddress" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmailAddress"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmailAddress using Stored Procedure
		/// and return a DataTable containing all EmailAddress Data using a Transaction
		/// </summary>
		public DataTable GetAllEmailAddress(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmailAddress";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllEmailAddress" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmailAddress"];

		}


        public System.Data.IDataReader GetByPersonIDEmailAddress(int BusinessEntityId)
        {
            DbCommand command = Database.GetStoredProcCommand("GetByPersonIDEmailAddress");
            Database.AddInParameter(command, "BusinessEntityId", DbType.Int32, BusinessEntityId);
            IDataReader reader = Database.ExecuteReader(command);
            return reader;
        }
		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmailAddress using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmailAddress( int emailAddressId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmailAddress");
				    Database.AddInParameter(command,"EmailAddressId",DbType.Int32,emailAddressId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmailAddress using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmailAddress( int emailAddressId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmailAddress");
				    Database.AddInParameter(command,"EmailAddressId",DbType.Int32,emailAddressId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmailAddress using Stored Procedure
		/// and return the auto number primary key of EmailAddress inserted row
		/// </summary>
		public bool InsertNewEmailAddress( ref int emailAddressId,  int businessEntityId,  int emailAddressTypeId,  string email,  bool emailVerified,  string emailVerificationHash,  Guid rowGuid,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmailAddress");
				Database.AddOutParameter(command,"EmailAddressId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				Database.AddInParameter(command,"EmailAddressTypeId",DbType.Int32,emailAddressTypeId);
				Database.AddInParameter(command,"Email",DbType.String,email);
				Database.AddInParameter(command,"EmailVerified",DbType.Boolean,emailVerified);
				Database.AddInParameter(command,"EmailVerificationHash",DbType.String,emailVerificationHash);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 emailAddressId = Convert.ToInt32(Database.GetParameterValue(command, "EmailAddressId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmailAddress using Stored Procedure
		/// and return the auto number primary key of EmailAddress inserted row using Transaction
		/// </summary>
		public bool InsertNewEmailAddress( ref int emailAddressId,  int businessEntityId,  int emailAddressTypeId,  string email,  bool emailVerified,  string emailVerificationHash,  Guid rowGuid,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmailAddress");
				Database.AddOutParameter(command,"EmailAddressId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				Database.AddInParameter(command,"EmailAddressTypeId",DbType.Int32,emailAddressTypeId);
				Database.AddInParameter(command,"Email",DbType.String,email);
				Database.AddInParameter(command,"EmailVerified",DbType.Boolean,emailVerified);
				Database.AddInParameter(command,"EmailVerificationHash",DbType.String,emailVerificationHash);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 emailAddressId = Convert.ToInt32(Database.GetParameterValue(command, "EmailAddressId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for EmailAddress using Stored Procedure
		/// and return DbCommand of the EmailAddress
		/// </summary>
		public DbCommand InsertNewEmailAddressCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmailAddress");

				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);
				Database.AddInParameter(command,"EmailAddressTypeId",DbType.Int32,"EmailAddressTypeId",DataRowVersion.Current);
				Database.AddInParameter(command,"Email",DbType.String,"Email",DataRowVersion.Current);
				Database.AddInParameter(command,"EmailVerified",DbType.Boolean,"EmailVerified",DataRowVersion.Current);
				Database.AddInParameter(command,"EmailVerificationHash",DbType.String,"EmailVerificationHash",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmailAddress using Stored Procedure
		/// </summary>
		public bool UpdateEmailAddress( int businessEntityId, int emailAddressTypeId, string email, bool emailVerified, string emailVerificationHash, Guid rowGuid, DateTime modifiedDate, int oldemailAddressId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmailAddress");

		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
		    		Database.AddInParameter(command,"EmailAddressTypeId",DbType.Int32,emailAddressTypeId);
		    		Database.AddInParameter(command,"Email",DbType.String,email);
		    		Database.AddInParameter(command,"EmailVerified",DbType.Boolean,emailVerified);
		    		Database.AddInParameter(command,"EmailVerificationHash",DbType.String,emailVerificationHash);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldEmailAddressId",DbType.Int32,oldemailAddressId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmailAddress using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateEmailAddress( int businessEntityId, int emailAddressTypeId, string email, bool emailVerified, string emailVerificationHash, Guid rowGuid, DateTime modifiedDate, int oldemailAddressId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmailAddress");

		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
		    		Database.AddInParameter(command,"EmailAddressTypeId",DbType.Int32,emailAddressTypeId);
		    		Database.AddInParameter(command,"Email",DbType.String,email);
		    		Database.AddInParameter(command,"EmailVerified",DbType.Boolean,emailVerified);
		    		Database.AddInParameter(command,"EmailVerificationHash",DbType.String,emailVerificationHash);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldEmailAddressId",DbType.Int32,oldemailAddressId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from EmailAddress using Stored Procedure
		/// </summary>
		public DbCommand UpdateEmailAddressCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmailAddress");

		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EmailAddressTypeId",DbType.Int32,"EmailAddressTypeId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Email",DbType.String,"Email",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EmailVerified",DbType.Boolean,"EmailVerified",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EmailVerificationHash",DbType.String,"EmailVerificationHash",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldEmailAddressId",DbType.Int32,"EmailAddressId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From EmailAddress using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteEmailAddress( int emailAddressId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteEmailAddress");
			Database.AddInParameter(command,"EmailAddressId",DbType.Int32,emailAddressId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}
        public bool DeleteEmailAddressByPersonId(int PersonId)
        {
            DbCommand command = Database.GetStoredProcCommand("DeleteEmailAddressByPersonId");
            Database.AddInParameter(command, "PersonId", DbType.Int32, PersonId);
            bool status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                status = true;
            }
            return status;
        }
        
		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From EmailAddress Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteEmailAddressCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteEmailAddress");
				Database.AddInParameter(command,"EmailAddressId",DbType.Int32,"EmailAddressId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmailAddress using Stored Procedure
		/// and return number of rows effected of the EmailAddress
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmailAddress",InsertNewEmailAddressCommand(),UpdateEmailAddressCommand(),DeleteEmailAddressCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmailAddress using Stored Procedure
		/// and return number of rows effected of the EmailAddress
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmailAddress",InsertNewEmailAddressCommand(),UpdateEmailAddressCommand(),DeleteEmailAddressCommand(), transaction);
          return rowsAffected;
		}


	}
}
