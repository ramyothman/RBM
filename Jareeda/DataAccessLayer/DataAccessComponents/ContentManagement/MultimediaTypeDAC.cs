using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for MultimediaType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the MultimediaType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class MultimediaTypeDAC : DataAccessComponent
	{
		#region Constructors
        public MultimediaTypeDAC() : base("", "ContentManagement.MultimediaType") { }
		public MultimediaTypeDAC(string connectionString): base(connectionString){}
		public MultimediaTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MultimediaType using Stored Procedure
		/// and return a DataTable containing all MultimediaType Data
		/// </summary>
		public DataTable GetAllMultimediaType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MultimediaType";
         string query = " select * from GetAllMultimediaType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MultimediaType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MultimediaType using Stored Procedure
		/// and return a DataTable containing all MultimediaType Data using a Transaction
		/// </summary>
		public DataTable GetAllMultimediaType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MultimediaType";
         string query = " select * from GetAllMultimediaType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MultimediaType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MultimediaType using Stored Procedure
		/// and return a DataTable containing all MultimediaType Data
		/// </summary>
		public DataTable GetAllMultimediaType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MultimediaType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllMultimediaType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MultimediaType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MultimediaType using Stored Procedure
		/// and return a DataTable containing all MultimediaType Data using a Transaction
		/// </summary>
		public DataTable GetAllMultimediaType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MultimediaType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllMultimediaType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MultimediaType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MultimediaType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMultimediaType( int multimediaTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMultimediaType");
				    Database.AddInParameter(command,"MultimediaTypeID",DbType.Int32,multimediaTypeID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MultimediaType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMultimediaType( int multimediaTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMultimediaType");
				    Database.AddInParameter(command,"MultimediaTypeID",DbType.Int32,multimediaTypeID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MultimediaType using Stored Procedure
		/// and return the auto number primary key of MultimediaType inserted row
		/// </summary>
		public bool InsertNewMultimediaType( ref int multimediaTypeID,  string name)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMultimediaType");
				Database.AddOutParameter(command,"MultimediaTypeID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 multimediaTypeID = Convert.ToInt32(Database.GetParameterValue(command, "MultimediaTypeID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MultimediaType using Stored Procedure
		/// and return the auto number primary key of MultimediaType inserted row using Transaction
		/// </summary>
		public bool InsertNewMultimediaType( ref int multimediaTypeID,  string name,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMultimediaType");
				Database.AddOutParameter(command,"MultimediaTypeID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 multimediaTypeID = Convert.ToInt32(Database.GetParameterValue(command, "MultimediaTypeID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for MultimediaType using Stored Procedure
		/// and return DbCommand of the MultimediaType
		/// </summary>
		public DbCommand InsertNewMultimediaTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMultimediaType");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MultimediaType using Stored Procedure
		/// </summary>
		public bool UpdateMultimediaType( string name, int oldmultimediaTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMultimediaType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldMultimediaTypeID",DbType.Int32,oldmultimediaTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MultimediaType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateMultimediaType( string name, int oldmultimediaTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMultimediaType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldMultimediaTypeID",DbType.Int32,oldmultimediaTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from MultimediaType using Stored Procedure
		/// </summary>
		public DbCommand UpdateMultimediaTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMultimediaType");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"oldMultimediaTypeID",DbType.Int32,"MultimediaTypeID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From MultimediaType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteMultimediaType( int multimediaTypeID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteMultimediaType");
			Database.AddInParameter(command,"MultimediaTypeID",DbType.Int32,multimediaTypeID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From MultimediaType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteMultimediaTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteMultimediaType");
				Database.AddInParameter(command,"MultimediaTypeID",DbType.Int32,"MultimediaTypeID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MultimediaType using Stored Procedure
		/// and return number of rows effected of the MultimediaType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MultimediaType",InsertNewMultimediaTypeCommand(),UpdateMultimediaTypeCommand(),DeleteMultimediaTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MultimediaType using Stored Procedure
		/// and return number of rows effected of the MultimediaType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MultimediaType",InsertNewMultimediaTypeCommand(),UpdateMultimediaTypeCommand(),DeleteMultimediaTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
