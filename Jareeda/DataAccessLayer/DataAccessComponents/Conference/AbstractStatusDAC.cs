using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for AbstractStatus table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the AbstractStatus table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class AbstractStatusDAC : DataAccessComponent
	{
		#region Constructors
        public AbstractStatusDAC() : base("", "Conference.AbstractStatus") { }
		public AbstractStatusDAC(string connectionString): base(connectionString){}
		public AbstractStatusDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractStatus using Stored Procedure
		/// and return a DataTable containing all AbstractStatus Data
		/// </summary>
		public DataTable GetAllAbstractStatus()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractStatus";
         string query = " select * from GetAllAbstractStatus";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["AbstractStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractStatus using Stored Procedure
		/// and return a DataTable containing all AbstractStatus Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstractStatus(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractStatus";
         string query = " select * from GetAllAbstractStatus";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["AbstractStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractStatus using Stored Procedure
		/// and return a DataTable containing all AbstractStatus Data
		/// </summary>
		public DataTable GetAllAbstractStatus(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractStatus";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllAbstractStatus" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["AbstractStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractStatus using Stored Procedure
		/// and return a DataTable containing all AbstractStatus Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstractStatus(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractStatus";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllAbstractStatus" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["AbstractStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From AbstractStatus using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstractStatus( int abstractStatusId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstractStatus");
				    Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,abstractStatusId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From AbstractStatus using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstractStatus( int abstractStatusId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstractStatus");
				    Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,abstractStatusId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into AbstractStatus using Stored Procedure
		/// and return the auto number primary key of AbstractStatus inserted row
		/// </summary>
		public bool InsertNewAbstractStatus( int abstractStatusId,  string name,  string nameAr)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractStatus");
				Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,abstractStatusId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"NameAr",DbType.String,nameAr);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into AbstractStatus using Stored Procedure
		/// and return the auto number primary key of AbstractStatus inserted row using Transaction
		/// </summary>
		public bool InsertNewAbstractStatus( int abstractStatusId,  string name,  string nameAr,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractStatus");
				Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,abstractStatusId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"NameAr",DbType.String,nameAr);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for AbstractStatus using Stored Procedure
		/// and return DbCommand of the AbstractStatus
		/// </summary>
		public DbCommand InsertNewAbstractStatusCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractStatus");
				Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,"AbstractStatusId",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"NameAr",DbType.String,"NameAr",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into AbstractStatus using Stored Procedure
		/// </summary>
		public bool UpdateAbstractStatus( int abstractStatusId, string name, string nameAr, int oldabstractStatusId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractStatus");
		    		Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,abstractStatusId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"NameAr",DbType.String,nameAr);
				Database.AddInParameter(command,"oldAbstractStatusId",DbType.Int32,oldabstractStatusId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into AbstractStatus using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateAbstractStatus( int abstractStatusId, string name, string nameAr, int oldabstractStatusId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractStatus");
		    		Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,abstractStatusId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"NameAr",DbType.String,nameAr);
				Database.AddInParameter(command,"oldAbstractStatusId",DbType.Int32,oldabstractStatusId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from AbstractStatus using Stored Procedure
		/// </summary>
		public DbCommand UpdateAbstractStatusCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractStatus");
		    		Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,"AbstractStatusId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"NameAr",DbType.String,"NameAr",DataRowVersion.Current);
				Database.AddInParameter(command,"oldAbstractStatusId",DbType.Int32,"AbstractStatusId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From AbstractStatus using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteAbstractStatus( int abstractStatusId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteAbstractStatus");
			Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,abstractStatusId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From AbstractStatus Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteAbstractStatusCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteAbstractStatus");
				Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,"AbstractStatusId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table AbstractStatus using Stored Procedure
		/// and return number of rows effected of the AbstractStatus
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"AbstractStatus",InsertNewAbstractStatusCommand(),UpdateAbstractStatusCommand(),DeleteAbstractStatusCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table AbstractStatus using Stored Procedure
		/// and return number of rows effected of the AbstractStatus
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"AbstractStatus",InsertNewAbstractStatusCommand(),UpdateAbstractStatusCommand(),DeleteAbstractStatusCommand(), transaction);
          return rowsAffected;
		}


	}
}
