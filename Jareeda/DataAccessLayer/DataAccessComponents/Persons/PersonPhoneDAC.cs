using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for PersonPhone table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the PersonPhone table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PersonPhoneDAC : DataAccessComponent
	{
		#region Constructors
        public PersonPhoneDAC() : base("", "Person.PersonPhone") { }
		public PersonPhoneDAC(string connectionString): base(connectionString){}
		public PersonPhoneDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonPhone using Stored Procedure
		/// and return a DataTable containing all PersonPhone Data
		/// </summary>
		public DataTable GetAllPersonPhone()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonPhone";
         string query = " select * from GetAllPersonPhone";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonPhone"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonPhone using Stored Procedure
		/// and return a DataTable containing all PersonPhone Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonPhone(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonPhone";
         string query = " select * from GetAllPersonPhone";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonPhone"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonPhone using Stored Procedure
		/// and return a DataTable containing all PersonPhone Data
		/// </summary>
		public DataTable GetAllPersonPhone(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonPhone";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPersonPhone" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonPhone"];

		}


        public System.Data.IDataReader GetByPersonIdPersonPhones(int businessEntityId)
        {
            DbCommand command = Database.GetStoredProcCommand("GetByPersonIdPersonPhones");
            Database.AddInParameter(command, "BusinessEntityId", DbType.Int32, businessEntityId);
            IDataReader reader = Database.ExecuteReader(command);
            return reader;
        }
		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonPhone using Stored Procedure
		/// and return a DataTable containing all PersonPhone Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonPhone(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonPhone";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPersonPhone" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonPhone"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonPhone using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonPhone( int id)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonPhone");
				    Database.AddInParameter(command,"Id",DbType.Int32,id);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonPhone using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonPhone( int id,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonPhone");
				    Database.AddInParameter(command,"Id",DbType.Int32,id);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonPhone using Stored Procedure
		/// and return the auto number primary key of PersonPhone inserted row
		/// </summary>
		public bool InsertNewPersonPhone( ref int id,  int businessEntityId,  string phoneNumber,  int phoneNumberTypeId,  DateTime modifiedDate,  bool phoneVerified,  string phoneVerificationCode)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonPhone");
				Database.AddOutParameter(command,"Id",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				Database.AddInParameter(command,"PhoneNumber",DbType.String,phoneNumber);
				Database.AddInParameter(command,"PhoneNumberTypeId",DbType.Int32,phoneNumberTypeId);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"PhoneVerified",DbType.Boolean,phoneVerified);
				Database.AddInParameter(command,"PhoneVerificationCode",DbType.String,phoneVerificationCode);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 id = Convert.ToInt32(Database.GetParameterValue(command, "Id"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonPhone using Stored Procedure
		/// and return the auto number primary key of PersonPhone inserted row using Transaction
		/// </summary>
		public bool InsertNewPersonPhone( ref int id,  int businessEntityId,  string phoneNumber,  int phoneNumberTypeId,  DateTime modifiedDate,  bool phoneVerified,  string phoneVerificationCode,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonPhone");
				Database.AddOutParameter(command,"Id",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				Database.AddInParameter(command,"PhoneNumber",DbType.String,phoneNumber);
				Database.AddInParameter(command,"PhoneNumberTypeId",DbType.Int32,phoneNumberTypeId);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"PhoneVerified",DbType.Boolean,phoneVerified);
				Database.AddInParameter(command,"PhoneVerificationCode",DbType.String,phoneVerificationCode);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 id = Convert.ToInt32(Database.GetParameterValue(command, "Id"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for PersonPhone using Stored Procedure
		/// and return DbCommand of the PersonPhone
		/// </summary>
		public DbCommand InsertNewPersonPhoneCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonPhone");

				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);
				Database.AddInParameter(command,"PhoneNumber",DbType.String,"PhoneNumber",DataRowVersion.Current);
				Database.AddInParameter(command,"PhoneNumberTypeId",DbType.Int32,"PhoneNumberTypeId",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"PhoneVerified",DbType.Boolean,"PhoneVerified",DataRowVersion.Current);
				Database.AddInParameter(command,"PhoneVerificationCode",DbType.String,"PhoneVerificationCode",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonPhone using Stored Procedure
		/// </summary>
		public bool UpdatePersonPhone( int businessEntityId, string phoneNumber, int phoneNumberTypeId, DateTime modifiedDate, bool phoneVerified, string phoneVerificationCode, int oldid)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonPhone");

		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
		    		Database.AddInParameter(command,"PhoneNumber",DbType.String,phoneNumber);
		    		Database.AddInParameter(command,"PhoneNumberTypeId",DbType.Int32,phoneNumberTypeId);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
		    		Database.AddInParameter(command,"PhoneVerified",DbType.Boolean,phoneVerified);
		    		Database.AddInParameter(command,"PhoneVerificationCode",DbType.String,phoneVerificationCode);
				Database.AddInParameter(command,"oldId",DbType.Int32,oldid);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonPhone using Stored Procedure By Transaction
		/// </summary>
		public bool UpdatePersonPhone( int businessEntityId, string phoneNumber, int phoneNumberTypeId, DateTime modifiedDate, bool phoneVerified, string phoneVerificationCode, int oldid,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonPhone");

		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
		    		Database.AddInParameter(command,"PhoneNumber",DbType.String,phoneNumber);
		    		Database.AddInParameter(command,"PhoneNumberTypeId",DbType.Int32,phoneNumberTypeId);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
		    		Database.AddInParameter(command,"PhoneVerified",DbType.Boolean,phoneVerified);
		    		Database.AddInParameter(command,"PhoneVerificationCode",DbType.String,phoneVerificationCode);
				Database.AddInParameter(command,"oldId",DbType.Int32,oldid);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from PersonPhone using Stored Procedure
		/// </summary>
		public DbCommand UpdatePersonPhoneCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonPhone");

		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PhoneNumber",DbType.String,"PhoneNumber",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PhoneNumberTypeId",DbType.Int32,"PhoneNumberTypeId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PhoneVerified",DbType.Boolean,"PhoneVerified",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PhoneVerificationCode",DbType.String,"PhoneVerificationCode",DataRowVersion.Current);
				Database.AddInParameter(command,"oldId",DbType.Int32,"Id",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From PersonPhone using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePersonPhone( int id)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePersonPhone");
			Database.AddInParameter(command,"Id",DbType.Int32,id);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}
        public bool DeletePersonPhoneByPersonId(int PersonId)
        {
            DbCommand command = Database.GetStoredProcCommand("DeletePersonPhoneByPersonId");
            Database.AddInParameter(command, "PersonId", DbType.Int32, PersonId);
            bool status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                status = true;
            }
            return status;
        }
        //[DeletePersonPhoneByPersonId]

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From PersonPhone Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePersonPhoneCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePersonPhone");
				Database.AddInParameter(command,"Id",DbType.Int32,"Id",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonPhone using Stored Procedure
		/// and return number of rows effected of the PersonPhone
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonPhone",InsertNewPersonPhoneCommand(),UpdatePersonPhoneCommand(),DeletePersonPhoneCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonPhone using Stored Procedure
		/// and return number of rows effected of the PersonPhone
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonPhone",InsertNewPersonPhoneCommand(),UpdatePersonPhoneCommand(),DeletePersonPhoneCommand(), transaction);
          return rowsAffected;
		}


	}
}
