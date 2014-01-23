using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for PhoneNumberType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the PhoneNumberType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PhoneNumberTypeDAC : DataAccessComponent
	{
		#region Constructors
        public PhoneNumberTypeDAC() : base("", "Person.PhoneNumberType") { }
		public PhoneNumberTypeDAC(string connectionString): base(connectionString){}
		public PhoneNumberTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PhoneNumberType using Stored Procedure
		/// and return a DataTable containing all PhoneNumberType Data
		/// </summary>
		public DataTable GetAllPhoneNumberType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PhoneNumberType";
         string query = " select * from GetAllPhoneNumberType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PhoneNumberType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PhoneNumberType using Stored Procedure
		/// and return a DataTable containing all PhoneNumberType Data using a Transaction
		/// </summary>
		public DataTable GetAllPhoneNumberType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PhoneNumberType";
         string query = " select * from GetAllPhoneNumberType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PhoneNumberType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PhoneNumberType using Stored Procedure
		/// and return a DataTable containing all PhoneNumberType Data
		/// </summary>
		public DataTable GetAllPhoneNumberType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PhoneNumberType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPhoneNumberType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PhoneNumberType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PhoneNumberType using Stored Procedure
		/// and return a DataTable containing all PhoneNumberType Data using a Transaction
		/// </summary>
		public DataTable GetAllPhoneNumberType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PhoneNumberType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPhoneNumberType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PhoneNumberType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PhoneNumberType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPhoneNumberType( int phoneNumberTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPhoneNumberType");
				    Database.AddInParameter(command,"PhoneNumberTypeId",DbType.Int32,phoneNumberTypeId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PhoneNumberType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPhoneNumberType( int phoneNumberTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPhoneNumberType");
				    Database.AddInParameter(command,"PhoneNumberTypeId",DbType.Int32,phoneNumberTypeId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PhoneNumberType using Stored Procedure
		/// and return the auto number primary key of PhoneNumberType inserted row
		/// </summary>
		public bool InsertNewPhoneNumberType( ref int phoneNumberTypeId,  string name,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPhoneNumberType");
				Database.AddOutParameter(command,"PhoneNumberTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 phoneNumberTypeId = Convert.ToInt32(Database.GetParameterValue(command, "PhoneNumberTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PhoneNumberType using Stored Procedure
		/// and return the auto number primary key of PhoneNumberType inserted row using Transaction
		/// </summary>
		public bool InsertNewPhoneNumberType( ref int phoneNumberTypeId,  string name,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPhoneNumberType");
				Database.AddOutParameter(command,"PhoneNumberTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 phoneNumberTypeId = Convert.ToInt32(Database.GetParameterValue(command, "PhoneNumberTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for PhoneNumberType using Stored Procedure
		/// and return DbCommand of the PhoneNumberType
		/// </summary>
		public DbCommand InsertNewPhoneNumberTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPhoneNumberType");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PhoneNumberType using Stored Procedure
		/// </summary>
		public bool UpdatePhoneNumberType( string name, DateTime modifiedDate, int oldphoneNumberTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePhoneNumberType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldPhoneNumberTypeId",DbType.Int32,oldphoneNumberTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PhoneNumberType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdatePhoneNumberType( string name, DateTime modifiedDate, int oldphoneNumberTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePhoneNumberType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldPhoneNumberTypeId",DbType.Int32,oldphoneNumberTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from PhoneNumberType using Stored Procedure
		/// </summary>
		public DbCommand UpdatePhoneNumberTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePhoneNumberType");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldPhoneNumberTypeId",DbType.Int32,"PhoneNumberTypeId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From PhoneNumberType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePhoneNumberType( int phoneNumberTypeId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePhoneNumberType");
			Database.AddInParameter(command,"PhoneNumberTypeId",DbType.Int32,phoneNumberTypeId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From PhoneNumberType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePhoneNumberTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePhoneNumberType");
				Database.AddInParameter(command,"PhoneNumberTypeId",DbType.Int32,"PhoneNumberTypeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PhoneNumberType using Stored Procedure
		/// and return number of rows effected of the PhoneNumberType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PhoneNumberType",InsertNewPhoneNumberTypeCommand(),UpdatePhoneNumberTypeCommand(),DeletePhoneNumberTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PhoneNumberType using Stored Procedure
		/// and return number of rows effected of the PhoneNumberType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PhoneNumberType",InsertNewPhoneNumberTypeCommand(),UpdatePhoneNumberTypeCommand(),DeletePhoneNumberTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
