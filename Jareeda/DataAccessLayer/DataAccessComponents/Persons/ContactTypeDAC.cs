using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for ContactType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ContactType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ContactTypeDAC : DataAccessComponent
	{
		#region Constructors
        public ContactTypeDAC() : base("", "Person.ContactType") { }
		public ContactTypeDAC(string connectionString): base(connectionString){}
		public ContactTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContactType using Stored Procedure
		/// and return a DataTable containing all ContactType Data
		/// </summary>
		public DataTable GetAllContactType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContactType";
         string query = " select * from GetAllContactType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ContactType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContactType using Stored Procedure
		/// and return a DataTable containing all ContactType Data using a Transaction
		/// </summary>
		public DataTable GetAllContactType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContactType";
         string query = " select * from GetAllContactType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ContactType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContactType using Stored Procedure
		/// and return a DataTable containing all ContactType Data
		/// </summary>
		public DataTable GetAllContactType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContactType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllContactType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ContactType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContactType using Stored Procedure
		/// and return a DataTable containing all ContactType Data using a Transaction
		/// </summary>
		public DataTable GetAllContactType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContactType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllContactType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ContactType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ContactType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDContactType( int contactTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDContactType");
				    Database.AddInParameter(command,"ContactTypeId",DbType.Int32,contactTypeId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ContactType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDContactType( int contactTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDContactType");
				    Database.AddInParameter(command,"ContactTypeId",DbType.Int32,contactTypeId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ContactType using Stored Procedure
		/// and return the auto number primary key of ContactType inserted row
		/// </summary>
		public bool InsertNewContactType( int contactTypeId,  string name,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewContactType");
				Database.AddInParameter(command,"ContactTypeId",DbType.Int32,contactTypeId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ContactType using Stored Procedure
		/// and return the auto number primary key of ContactType inserted row using Transaction
		/// </summary>
		public bool InsertNewContactType( int contactTypeId,  string name,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewContactType");
				Database.AddInParameter(command,"ContactTypeId",DbType.Int32,contactTypeId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ContactType using Stored Procedure
		/// and return DbCommand of the ContactType
		/// </summary>
		public DbCommand InsertNewContactTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewContactType");
				Database.AddInParameter(command,"ContactTypeId",DbType.Int32,"ContactTypeId",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ContactType using Stored Procedure
		/// </summary>
		public bool UpdateContactType( int contactTypeId, string name, DateTime modifiedDate, int oldcontactTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateContactType");
		    		Database.AddInParameter(command,"ContactTypeId",DbType.Int32,contactTypeId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldContactTypeId",DbType.Int32,oldcontactTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ContactType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateContactType( int contactTypeId, string name, DateTime modifiedDate, int oldcontactTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateContactType");
		    		Database.AddInParameter(command,"ContactTypeId",DbType.Int32,contactTypeId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldContactTypeId",DbType.Int32,oldcontactTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ContactType using Stored Procedure
		/// </summary>
		public DbCommand UpdateContactTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateContactType");
		    		Database.AddInParameter(command,"ContactTypeId",DbType.Int32,"ContactTypeId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldContactTypeId",DbType.Int32,"ContactTypeId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ContactType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteContactType( int contactTypeId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteContactType");
			Database.AddInParameter(command,"ContactTypeId",DbType.Int32,contactTypeId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ContactType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteContactTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteContactType");
				Database.AddInParameter(command,"ContactTypeId",DbType.Int32,"ContactTypeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ContactType using Stored Procedure
		/// and return number of rows effected of the ContactType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ContactType",InsertNewContactTypeCommand(),UpdateContactTypeCommand(),DeleteContactTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ContactType using Stored Procedure
		/// and return number of rows effected of the ContactType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ContactType",InsertNewContactTypeCommand(),UpdateContactTypeCommand(),DeleteContactTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
