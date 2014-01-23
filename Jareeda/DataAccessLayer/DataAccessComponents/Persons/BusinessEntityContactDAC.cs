using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for BusinessEntityContact table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the BusinessEntityContact table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class BusinessEntityContactDAC : DataAccessComponent
	{
		#region Constructors
        public BusinessEntityContactDAC() : base("", "Person.BusinessEntityContact") { }
		public BusinessEntityContactDAC(string connectionString): base(connectionString){}
		public BusinessEntityContactDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all BusinessEntityContact using Stored Procedure
		/// and return a DataTable containing all BusinessEntityContact Data
		/// </summary>
		public DataTable GetAllBusinessEntityContact()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "BusinessEntityContact";
         string query = " select * from GetAllBusinessEntityContact";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["BusinessEntityContact"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all BusinessEntityContact using Stored Procedure
		/// and return a DataTable containing all BusinessEntityContact Data using a Transaction
		/// </summary>
		public DataTable GetAllBusinessEntityContact(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "BusinessEntityContact";
         string query = " select * from GetAllBusinessEntityContact";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["BusinessEntityContact"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all BusinessEntityContact using Stored Procedure
		/// and return a DataTable containing all BusinessEntityContact Data
		/// </summary>
		public DataTable GetAllBusinessEntityContact(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "BusinessEntityContact";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllBusinessEntityContact" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["BusinessEntityContact"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all BusinessEntityContact using Stored Procedure
		/// and return a DataTable containing all BusinessEntityContact Data using a Transaction
		/// </summary>
		public DataTable GetAllBusinessEntityContact(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "BusinessEntityContact";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllBusinessEntityContact" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["BusinessEntityContact"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From BusinessEntityContact using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDBusinessEntityContact( int personId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDBusinessEntityContact");
				    Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From BusinessEntityContact using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDBusinessEntityContact( int personId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDBusinessEntityContact");
				    Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into BusinessEntityContact using Stored Procedure
		/// and return the auto number primary key of BusinessEntityContact inserted row
		/// </summary>
		public bool InsertNewBusinessEntityContact( int contactTypeId,  Guid rowGuid,  DateTime modifiedDate,  int personId)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewBusinessEntityContact");
				Database.AddInParameter(command,"ContactTypeId",DbType.Int32,contactTypeId);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into BusinessEntityContact using Stored Procedure
		/// and return the auto number primary key of BusinessEntityContact inserted row using Transaction
		/// </summary>
		public bool InsertNewBusinessEntityContact( int contactTypeId,  Guid rowGuid,  DateTime modifiedDate,  int personId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewBusinessEntityContact");
				Database.AddInParameter(command,"ContactTypeId",DbType.Int32,contactTypeId);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for BusinessEntityContact using Stored Procedure
		/// and return DbCommand of the BusinessEntityContact
		/// </summary>
		public DbCommand InsertNewBusinessEntityContactCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewBusinessEntityContact");
				Database.AddInParameter(command,"ContactTypeId",DbType.Int32,"ContactTypeId",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into BusinessEntityContact using Stored Procedure
		/// </summary>
		public bool UpdateBusinessEntityContact( int contactTypeId, Guid rowGuid, DateTime modifiedDate, int personId, int oldpersonId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateBusinessEntityContact");
		    		Database.AddInParameter(command,"ContactTypeId",DbType.Int32,contactTypeId);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"oldPersonId",DbType.Int32,oldpersonId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into BusinessEntityContact using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateBusinessEntityContact( int contactTypeId, Guid rowGuid, DateTime modifiedDate, int personId, int oldpersonId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateBusinessEntityContact");
		    		Database.AddInParameter(command,"ContactTypeId",DbType.Int32,contactTypeId);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"oldPersonId",DbType.Int32,oldpersonId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from BusinessEntityContact using Stored Procedure
		/// </summary>
		public DbCommand UpdateBusinessEntityContactCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateBusinessEntityContact");
		    		Database.AddInParameter(command,"ContactTypeId",DbType.Int32,"ContactTypeId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				Database.AddInParameter(command,"oldPersonId",DbType.Int32,"PersonId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From BusinessEntityContact using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteBusinessEntityContact( int personId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteBusinessEntityContact");
			Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From BusinessEntityContact Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteBusinessEntityContactCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteBusinessEntityContact");
				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table BusinessEntityContact using Stored Procedure
		/// and return number of rows effected of the BusinessEntityContact
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"BusinessEntityContact",InsertNewBusinessEntityContactCommand(),UpdateBusinessEntityContactCommand(),DeleteBusinessEntityContactCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table BusinessEntityContact using Stored Procedure
		/// and return number of rows effected of the BusinessEntityContact
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"BusinessEntityContact",InsertNewBusinessEntityContactCommand(),UpdateBusinessEntityContactCommand(),DeleteBusinessEntityContactCommand(), transaction);
          return rowsAffected;
		}


	}
}
