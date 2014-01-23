using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for PersonPersonTypes table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the PersonPersonTypes table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PersonPersonTypesDAC : DataAccessComponent
	{
		#region Constructors
        public PersonPersonTypesDAC() : base("", "Person.PersonPersonTypes") { }
		public PersonPersonTypesDAC(string connectionString): base(connectionString){}
		public PersonPersonTypesDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonPersonTypes using Stored Procedure
		/// and return a DataTable containing all PersonPersonTypes Data
		/// </summary>
		public DataTable GetAllPersonPersonTypes()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonPersonTypes";
         string query = " select * from GetAllPersonPersonTypes";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonPersonTypes"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonPersonTypes using Stored Procedure
		/// and return a DataTable containing all PersonPersonTypes Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonPersonTypes(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonPersonTypes";
         string query = " select * from GetAllPersonPersonTypes";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonPersonTypes"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonPersonTypes using Stored Procedure
		/// and return a DataTable containing all PersonPersonTypes Data
		/// </summary>
		public DataTable GetAllPersonPersonTypes(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonPersonTypes";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPersonPersonTypes" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonPersonTypes"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonPersonTypes using Stored Procedure
		/// and return a DataTable containing all PersonPersonTypes Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonPersonTypes(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonPersonTypes";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPersonPersonTypes" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonPersonTypes"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonPersonTypes using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonPersonTypes( int personPersonTypesId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonPersonTypes");
				    Database.AddInParameter(command,"PersonPersonTypesId",DbType.Int32,personPersonTypesId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonPersonTypes using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonPersonTypes( int personPersonTypesId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonPersonTypes");
				    Database.AddInParameter(command,"PersonPersonTypesId",DbType.Int32,personPersonTypesId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonPersonTypes using Stored Procedure
		/// and return the auto number primary key of PersonPersonTypes inserted row
		/// </summary>
		public bool InsertNewPersonPersonTypes( ref int personPersonTypesId,  string name,  Guid rowGuid,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonPersonTypes");
				Database.AddOutParameter(command,"PersonPersonTypesId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 personPersonTypesId = Convert.ToInt32(Database.GetParameterValue(command, "PersonPersonTypesId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonPersonTypes using Stored Procedure
		/// and return the auto number primary key of PersonPersonTypes inserted row using Transaction
		/// </summary>
		public bool InsertNewPersonPersonTypes( ref int personPersonTypesId,  string name,  Guid rowGuid,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonPersonTypes");
				Database.AddOutParameter(command,"PersonPersonTypesId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 personPersonTypesId = Convert.ToInt32(Database.GetParameterValue(command, "PersonPersonTypesId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for PersonPersonTypes using Stored Procedure
		/// and return DbCommand of the PersonPersonTypes
		/// </summary>
		public DbCommand InsertNewPersonPersonTypesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonPersonTypes");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonPersonTypes using Stored Procedure
		/// </summary>
		public bool UpdatePersonPersonTypes( string name, Guid rowGuid, DateTime modifiedDate, int oldpersonPersonTypesId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonPersonTypes");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldPersonPersonTypesId",DbType.Int32,oldpersonPersonTypesId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonPersonTypes using Stored Procedure By Transaction
		/// </summary>
		public bool UpdatePersonPersonTypes( string name, Guid rowGuid, DateTime modifiedDate, int oldpersonPersonTypesId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonPersonTypes");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldPersonPersonTypesId",DbType.Int32,oldpersonPersonTypesId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from PersonPersonTypes using Stored Procedure
		/// </summary>
		public DbCommand UpdatePersonPersonTypesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonPersonTypes");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldPersonPersonTypesId",DbType.Int32,"PersonPersonTypesId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From PersonPersonTypes using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePersonPersonTypes( int personPersonTypesId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePersonPersonTypes");
			Database.AddInParameter(command,"PersonPersonTypesId",DbType.Int32,personPersonTypesId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From PersonPersonTypes Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePersonPersonTypesCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePersonPersonTypes");
				Database.AddInParameter(command,"PersonPersonTypesId",DbType.Int32,"PersonPersonTypesId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonPersonTypes using Stored Procedure
		/// and return number of rows effected of the PersonPersonTypes
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonPersonTypes",InsertNewPersonPersonTypesCommand(),UpdatePersonPersonTypesCommand(),DeletePersonPersonTypesCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonPersonTypes using Stored Procedure
		/// and return number of rows effected of the PersonPersonTypes
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonPersonTypes",InsertNewPersonPersonTypesCommand(),UpdatePersonPersonTypesCommand(),DeletePersonPersonTypesCommand(), transaction);
          return rowsAffected;
		}


	}
}
