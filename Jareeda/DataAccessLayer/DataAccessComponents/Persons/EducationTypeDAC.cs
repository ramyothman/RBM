using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for EducationType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the EducationType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class EducationTypeDAC : DataAccessComponent
	{
		#region Constructors
        public EducationTypeDAC() : base("", "Person.EducationType") { }
		public EducationTypeDAC(string connectionString): base(connectionString){}
		public EducationTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EducationType using Stored Procedure
		/// and return a DataTable containing all EducationType Data
		/// </summary>
		public DataTable GetAllEducationType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EducationType";
         string query = " select * from GetAllEducationType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EducationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EducationType using Stored Procedure
		/// and return a DataTable containing all EducationType Data using a Transaction
		/// </summary>
		public DataTable GetAllEducationType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EducationType";
         string query = " select * from GetAllEducationType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EducationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EducationType using Stored Procedure
		/// and return a DataTable containing all EducationType Data
		/// </summary>
		public DataTable GetAllEducationType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EducationType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllEducationType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EducationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EducationType using Stored Procedure
		/// and return a DataTable containing all EducationType Data using a Transaction
		/// </summary>
		public DataTable GetAllEducationType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EducationType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllEducationType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EducationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EducationType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEducationType( int educationTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEducationType");
				    Database.AddInParameter(command,"EducationTypeId",DbType.Int32,educationTypeId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EducationType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEducationType( int educationTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEducationType");
				    Database.AddInParameter(command,"EducationTypeId",DbType.Int32,educationTypeId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EducationType using Stored Procedure
		/// and return the auto number primary key of EducationType inserted row
		/// </summary>
		public bool InsertNewEducationType( ref int educationTypeId,  string educationTypeName)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEducationType");
				Database.AddOutParameter(command,"EducationTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"EducationTypeName",DbType.String,educationTypeName);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 educationTypeId = Convert.ToInt32(Database.GetParameterValue(command, "EducationTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EducationType using Stored Procedure
		/// and return the auto number primary key of EducationType inserted row using Transaction
		/// </summary>
		public bool InsertNewEducationType( ref int educationTypeId,  string educationTypeName,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEducationType");
				Database.AddOutParameter(command,"EducationTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"EducationTypeName",DbType.String,educationTypeName);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 educationTypeId = Convert.ToInt32(Database.GetParameterValue(command, "EducationTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for EducationType using Stored Procedure
		/// and return DbCommand of the EducationType
		/// </summary>
		public DbCommand InsertNewEducationTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEducationType");

				Database.AddInParameter(command,"EducationTypeName",DbType.String,"EducationTypeName",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EducationType using Stored Procedure
		/// </summary>
		public bool UpdateEducationType( string educationTypeName, int oldeducationTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEducationType");

		    		Database.AddInParameter(command,"EducationTypeName",DbType.String,educationTypeName);
				Database.AddInParameter(command,"oldEducationTypeId",DbType.Int32,oldeducationTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EducationType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateEducationType( string educationTypeName, int oldeducationTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEducationType");

		    		Database.AddInParameter(command,"EducationTypeName",DbType.String,educationTypeName);
				Database.AddInParameter(command,"oldEducationTypeId",DbType.Int32,oldeducationTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from EducationType using Stored Procedure
		/// </summary>
		public DbCommand UpdateEducationTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEducationType");

		    		Database.AddInParameter(command,"EducationTypeName",DbType.String,"EducationTypeName",DataRowVersion.Current);
				Database.AddInParameter(command,"oldEducationTypeId",DbType.Int32,"EducationTypeId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From EducationType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteEducationType( int educationTypeId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteEducationType");
			Database.AddInParameter(command,"EducationTypeId",DbType.Int32,educationTypeId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From EducationType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteEducationTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteEducationType");
				Database.AddInParameter(command,"EducationTypeId",DbType.Int32,"EducationTypeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EducationType using Stored Procedure
		/// and return number of rows effected of the EducationType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EducationType",InsertNewEducationTypeCommand(),UpdateEducationTypeCommand(),DeleteEducationTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EducationType using Stored Procedure
		/// and return number of rows effected of the EducationType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EducationType",InsertNewEducationTypeCommand(),UpdateEducationTypeCommand(),DeleteEducationTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
