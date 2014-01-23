using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for PersonType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the PersonType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PersonTypeDAC : DataAccessComponent
	{
		#region Constructors
        public PersonTypeDAC() : base("", "Person.PersonType") { }
		public PersonTypeDAC(string connectionString): base(connectionString){}
		public PersonTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonType using Stored Procedure
		/// and return a DataTable containing all PersonType Data
		/// </summary>
		public DataTable GetAllPersonType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonType";
         string query = " select * from GetAllPersonType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonType using Stored Procedure
		/// and return a DataTable containing all PersonType Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonType";
         string query = " select * from GetAllPersonType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonType using Stored Procedure
		/// and return a DataTable containing all PersonType Data
		/// </summary>
		public DataTable GetAllPersonType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPersonType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonType using Stored Procedure
		/// and return a DataTable containing all PersonType Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPersonType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonType( int personTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonType");
				    Database.AddInParameter(command,"PersonTypeId",DbType.Int32,personTypeId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonType( int personTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonType");
				    Database.AddInParameter(command,"PersonTypeId",DbType.Int32,personTypeId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonType using Stored Procedure
		/// and return the auto number primary key of PersonType inserted row
		/// </summary>
		public bool InsertNewPersonType( ref int personTypeId,  int businessEntityId,  int personPersonTypesId,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonType");
				Database.AddOutParameter(command,"PersonTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				Database.AddInParameter(command,"PersonPersonTypesId",DbType.Int32,personPersonTypesId);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 personTypeId = Convert.ToInt32(Database.GetParameterValue(command, "PersonTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonType using Stored Procedure
		/// and return the auto number primary key of PersonType inserted row using Transaction
		/// </summary>
		public bool InsertNewPersonType( ref int personTypeId,  int businessEntityId,  int personPersonTypesId,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonType");
				Database.AddOutParameter(command,"PersonTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				Database.AddInParameter(command,"PersonPersonTypesId",DbType.Int32,personPersonTypesId);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 personTypeId = Convert.ToInt32(Database.GetParameterValue(command, "PersonTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for PersonType using Stored Procedure
		/// and return DbCommand of the PersonType
		/// </summary>
		public DbCommand InsertNewPersonTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonType");

				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);
				Database.AddInParameter(command,"PersonPersonTypesId",DbType.Int32,"PersonPersonTypesId",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonType using Stored Procedure
		/// </summary>
		public bool UpdatePersonType( int businessEntityId, int personPersonTypesId, DateTime modifiedDate, int oldpersonTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonType");

		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
		    		Database.AddInParameter(command,"PersonPersonTypesId",DbType.Int32,personPersonTypesId);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldPersonTypeId",DbType.Int32,oldpersonTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdatePersonType( int businessEntityId, int personPersonTypesId, DateTime modifiedDate, int oldpersonTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonType");

		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
		    		Database.AddInParameter(command,"PersonPersonTypesId",DbType.Int32,personPersonTypesId);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldPersonTypeId",DbType.Int32,oldpersonTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from PersonType using Stored Procedure
		/// </summary>
		public DbCommand UpdatePersonTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonType");

		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PersonPersonTypesId",DbType.Int32,"PersonPersonTypesId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldPersonTypeId",DbType.Int32,"PersonTypeId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From PersonType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePersonType( int personTypeId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePersonType");
			Database.AddInParameter(command,"PersonTypeId",DbType.Int32,personTypeId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From PersonType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePersonTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePersonType");
				Database.AddInParameter(command,"PersonTypeId",DbType.Int32,"PersonTypeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonType using Stored Procedure
		/// and return number of rows effected of the PersonType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonType",InsertNewPersonTypeCommand(),UpdatePersonTypeCommand(),DeletePersonTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonType using Stored Procedure
		/// and return number of rows effected of the PersonType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonType",InsertNewPersonTypeCommand(),UpdatePersonTypeCommand(),DeletePersonTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
