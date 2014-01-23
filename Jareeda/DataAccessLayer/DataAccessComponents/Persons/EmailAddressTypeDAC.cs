using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for EmailAddressType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the EmailAddressType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class EmailAddressTypeDAC : DataAccessComponent
	{
		#region Constructors
        public EmailAddressTypeDAC() : base("", "Person.EmailAddressType") { }
		public EmailAddressTypeDAC(string connectionString): base(connectionString){}
		public EmailAddressTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmailAddressType using Stored Procedure
		/// and return a DataTable containing all EmailAddressType Data
		/// </summary>
		public DataTable GetAllEmailAddressType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmailAddressType";
         string query = " select * from GetAllEmailAddressType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmailAddressType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmailAddressType using Stored Procedure
		/// and return a DataTable containing all EmailAddressType Data using a Transaction
		/// </summary>
		public DataTable GetAllEmailAddressType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmailAddressType";
         string query = " select * from GetAllEmailAddressType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmailAddressType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmailAddressType using Stored Procedure
		/// and return a DataTable containing all EmailAddressType Data
		/// </summary>
		public DataTable GetAllEmailAddressType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmailAddressType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllEmailAddressType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmailAddressType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmailAddressType using Stored Procedure
		/// and return a DataTable containing all EmailAddressType Data using a Transaction
		/// </summary>
		public DataTable GetAllEmailAddressType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmailAddressType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllEmailAddressType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmailAddressType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmailAddressType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmailAddressType( int emailAddressTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmailAddressType");
				    Database.AddInParameter(command,"EmailAddressTypeId",DbType.Int32,emailAddressTypeId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmailAddressType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmailAddressType( int emailAddressTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmailAddressType");
				    Database.AddInParameter(command,"EmailAddressTypeId",DbType.Int32,emailAddressTypeId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmailAddressType using Stored Procedure
		/// and return the auto number primary key of EmailAddressType inserted row
		/// </summary>
		public bool InsertNewEmailAddressType( ref int emailAddressTypeId,  string name,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmailAddressType");
				Database.AddOutParameter(command,"EmailAddressTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 emailAddressTypeId = Convert.ToInt32(Database.GetParameterValue(command, "EmailAddressTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmailAddressType using Stored Procedure
		/// and return the auto number primary key of EmailAddressType inserted row using Transaction
		/// </summary>
		public bool InsertNewEmailAddressType( ref int emailAddressTypeId,  string name,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmailAddressType");
				Database.AddOutParameter(command,"EmailAddressTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 emailAddressTypeId = Convert.ToInt32(Database.GetParameterValue(command, "EmailAddressTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for EmailAddressType using Stored Procedure
		/// and return DbCommand of the EmailAddressType
		/// </summary>
		public DbCommand InsertNewEmailAddressTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmailAddressType");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmailAddressType using Stored Procedure
		/// </summary>
		public bool UpdateEmailAddressType( string name, DateTime modifiedDate, int oldemailAddressTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmailAddressType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldEmailAddressTypeId",DbType.Int32,oldemailAddressTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmailAddressType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateEmailAddressType( string name, DateTime modifiedDate, int oldemailAddressTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmailAddressType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldEmailAddressTypeId",DbType.Int32,oldemailAddressTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from EmailAddressType using Stored Procedure
		/// </summary>
		public DbCommand UpdateEmailAddressTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmailAddressType");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldEmailAddressTypeId",DbType.Int32,"EmailAddressTypeId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From EmailAddressType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteEmailAddressType( int emailAddressTypeId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteEmailAddressType");
			Database.AddInParameter(command,"EmailAddressTypeId",DbType.Int32,emailAddressTypeId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From EmailAddressType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteEmailAddressTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteEmailAddressType");
				Database.AddInParameter(command,"EmailAddressTypeId",DbType.Int32,"EmailAddressTypeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmailAddressType using Stored Procedure
		/// and return number of rows effected of the EmailAddressType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmailAddressType",InsertNewEmailAddressTypeCommand(),UpdateEmailAddressTypeCommand(),DeleteEmailAddressTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmailAddressType using Stored Procedure
		/// and return number of rows effected of the EmailAddressType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmailAddressType",InsertNewEmailAddressTypeCommand(),UpdateEmailAddressTypeCommand(),DeleteEmailAddressTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
