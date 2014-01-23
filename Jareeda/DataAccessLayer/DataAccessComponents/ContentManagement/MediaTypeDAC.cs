using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for MediaType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the MediaType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class MediaTypeDAC : DataAccessComponent
	{
		#region Constructors
        public MediaTypeDAC() : base("", "ContentManagement.MediaType") { }
		public MediaTypeDAC(string connectionString): base(connectionString){}
		public MediaTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MediaType using Stored Procedure
		/// and return a DataTable containing all MediaType Data
		/// </summary>
		public DataTable GetAllMediaType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MediaType";
         string query = " select * from GetAllMediaType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MediaType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MediaType using Stored Procedure
		/// and return a DataTable containing all MediaType Data using a Transaction
		/// </summary>
		public DataTable GetAllMediaType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MediaType";
         string query = " select * from GetAllMediaType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MediaType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MediaType using Stored Procedure
		/// and return a DataTable containing all MediaType Data
		/// </summary>
		public DataTable GetAllMediaType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MediaType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllMediaType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MediaType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MediaType using Stored Procedure
		/// and return a DataTable containing all MediaType Data using a Transaction
		/// </summary>
		public DataTable GetAllMediaType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MediaType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllMediaType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MediaType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MediaType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMediaType( int mediaTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMediaType");
				    Database.AddInParameter(command,"MediaTypeID",DbType.Int32,mediaTypeID);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MediaType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMediaType( int mediaTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMediaType");
				    Database.AddInParameter(command,"MediaTypeID",DbType.Int32,mediaTypeID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MediaType using Stored Procedure
		/// and return the auto number primary key of MediaType inserted row
		/// </summary>
		public bool InsertNewMediaType( ref int mediaTypeID,  string name)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMediaType");
				Database.AddOutParameter(command,"MediaTypeID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 mediaTypeID = Convert.ToInt32(Database.GetParameterValue(command, "MediaTypeID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MediaType using Stored Procedure
		/// and return the auto number primary key of MediaType inserted row using Transaction
		/// </summary>
		public bool InsertNewMediaType( ref int mediaTypeID,  string name,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMediaType");
				Database.AddOutParameter(command,"MediaTypeID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 mediaTypeID = Convert.ToInt32(Database.GetParameterValue(command, "MediaTypeID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for MediaType using Stored Procedure
		/// and return DbCommand of the MediaType
		/// </summary>
		public DbCommand InsertNewMediaTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMediaType");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MediaType using Stored Procedure
		/// </summary>
		public bool UpdateMediaType( string name, int oldmediaTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMediaType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldMediaTypeID",DbType.Int32,oldmediaTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MediaType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateMediaType( string name, int oldmediaTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMediaType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldMediaTypeID",DbType.Int32,oldmediaTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from MediaType using Stored Procedure
		/// </summary>
		public DbCommand UpdateMediaTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMediaType");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"oldMediaTypeID",DbType.Int32,"MediaTypeID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From MediaType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteMediaType( int mediaTypeID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteMediaType");
			Database.AddInParameter(command,"MediaTypeID",DbType.Int32,mediaTypeID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From MediaType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteMediaTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteMediaType");
				Database.AddInParameter(command,"MediaTypeID",DbType.Int32,"MediaTypeID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MediaType using Stored Procedure
		/// and return number of rows effected of the MediaType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MediaType",InsertNewMediaTypeCommand(),UpdateMediaTypeCommand(),DeleteMediaTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MediaType using Stored Procedure
		/// and return number of rows effected of the MediaType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MediaType",InsertNewMediaTypeCommand(),UpdateMediaTypeCommand(),DeleteMediaTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
