using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for Multimedia table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Multimedia table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class MultimediaDAC : DataAccessComponent
	{
		#region Constructors
        public MultimediaDAC() : base("", "ContentManagement.Multimedia") { }
		public MultimediaDAC(string connectionString): base(connectionString){}
		public MultimediaDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Multimedia using Stored Procedure
		/// and return a DataTable containing all Multimedia Data
		/// </summary>
		public DataTable GetAllMultimedia()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Multimedia";
         string query = " select * from GetAllMultimedia";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Multimedia"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Multimedia using Stored Procedure
		/// and return a DataTable containing all Multimedia Data using a Transaction
		/// </summary>
		public DataTable GetAllMultimedia(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Multimedia";
         string query = " select * from GetAllMultimedia";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Multimedia"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Multimedia using Stored Procedure
		/// and return a DataTable containing all Multimedia Data
		/// </summary>
		public DataTable GetAllMultimedia(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Multimedia";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllMultimedia" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Multimedia"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Multimedia using Stored Procedure
		/// and return a DataTable containing all Multimedia Data using a Transaction
		/// </summary>
		public DataTable GetAllMultimedia(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Multimedia";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllMultimedia" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Multimedia"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Multimedia using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMultimedia( int multimediaID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMultimedia");
				    Database.AddInParameter(command,"MultimediaID",DbType.Int32,multimediaID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Multimedia using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMultimedia( int multimediaID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMultimedia");
				    Database.AddInParameter(command,"MultimediaID",DbType.Int32,multimediaID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Multimedia using Stored Procedure
		/// and return the auto number primary key of Multimedia inserted row
		/// </summary>
		public bool InsertNewMultimedia( ref int multimediaID,  int multimediaTypeID,  string url,  string thumbnainUrl,  string title,  string description,  DateTime publishDate,  DateTime createdDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMultimedia");
				Database.AddOutParameter(command,"MultimediaID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"MultimediaTypeID",DbType.Int32,multimediaTypeID);
				Database.AddInParameter(command,"Url",DbType.String,url);
				Database.AddInParameter(command,"ThumbnainUrl",DbType.String,thumbnainUrl);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"PublishDate",DbType.DateTime,publishDate);
				Database.AddInParameter(command,"CreatedDate",DbType.DateTime,DateTime.Now);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 multimediaID = Convert.ToInt32(Database.GetParameterValue(command, "MultimediaID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Multimedia using Stored Procedure
		/// and return the auto number primary key of Multimedia inserted row using Transaction
		/// </summary>
		public bool InsertNewMultimedia( ref int multimediaID,  int multimediaTypeID,  string url,  string thumbnainUrl,  string title,  string description,  DateTime publishDate,  DateTime createdDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMultimedia");
				Database.AddOutParameter(command,"MultimediaID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"MultimediaTypeID",DbType.Int32,multimediaTypeID);
				Database.AddInParameter(command,"Url",DbType.String,url);
				Database.AddInParameter(command,"ThumbnainUrl",DbType.String,thumbnainUrl);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"PublishDate",DbType.DateTime,publishDate);
				Database.AddInParameter(command,"CreatedDate",DbType.DateTime,DateTime.Now);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 multimediaID = Convert.ToInt32(Database.GetParameterValue(command, "MultimediaID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Multimedia using Stored Procedure
		/// and return DbCommand of the Multimedia
		/// </summary>
		public DbCommand InsertNewMultimediaCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMultimedia");

				Database.AddInParameter(command,"MultimediaTypeID",DbType.Int32,"MultimediaTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"Url",DbType.String,"Url",DataRowVersion.Current);
				Database.AddInParameter(command,"ThumbnainUrl",DbType.String,"ThumbnainUrl",DataRowVersion.Current);
				Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
				Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
				Database.AddInParameter(command,"PublishDate",DbType.DateTime,"PublishDate",DataRowVersion.Current);
				Database.AddInParameter(command,"CreatedDate",DbType.DateTime,"CreatedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Multimedia using Stored Procedure
		/// </summary>
		public bool UpdateMultimedia( int multimediaTypeID, string url, string thumbnainUrl, string title, string description, DateTime publishDate, DateTime createdDate, int oldmultimediaID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMultimedia");

		    		Database.AddInParameter(command,"MultimediaTypeID",DbType.Int32,multimediaTypeID);
		    		Database.AddInParameter(command,"Url",DbType.String,url);
		    		Database.AddInParameter(command,"ThumbnainUrl",DbType.String,thumbnainUrl);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"PublishDate",DbType.DateTime,publishDate);
		    		Database.AddInParameter(command,"CreatedDate",DbType.DateTime,DateTime.Now);
				Database.AddInParameter(command,"oldMultimediaID",DbType.Int32,oldmultimediaID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Multimedia using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateMultimedia( int multimediaTypeID, string url, string thumbnainUrl, string title, string description, DateTime publishDate, DateTime createdDate, int oldmultimediaID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMultimedia");

		    		Database.AddInParameter(command,"MultimediaTypeID",DbType.Int32,multimediaTypeID);
		    		Database.AddInParameter(command,"Url",DbType.String,url);
		    		Database.AddInParameter(command,"ThumbnainUrl",DbType.String,thumbnainUrl);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"PublishDate",DbType.DateTime,publishDate);
		    		Database.AddInParameter(command,"CreatedDate",DbType.DateTime,createdDate);
				Database.AddInParameter(command,"oldMultimediaID",DbType.Int32,oldmultimediaID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Multimedia using Stored Procedure
		/// </summary>
		public DbCommand UpdateMultimediaCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMultimedia");

		    		Database.AddInParameter(command,"MultimediaTypeID",DbType.Int32,"MultimediaTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Url",DbType.String,"Url",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ThumbnainUrl",DbType.String,"ThumbnainUrl",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PublishDate",DbType.DateTime,"PublishDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CreatedDate",DbType.DateTime,"CreatedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldMultimediaID",DbType.Int32,"MultimediaID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Multimedia using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteMultimedia( int multimediaID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteMultimedia");
			Database.AddInParameter(command,"MultimediaID",DbType.Int32,multimediaID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Multimedia Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteMultimediaCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteMultimedia");
				Database.AddInParameter(command,"MultimediaID",DbType.Int32,"MultimediaID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Multimedia using Stored Procedure
		/// and return number of rows effected of the Multimedia
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Multimedia",InsertNewMultimediaCommand(),UpdateMultimediaCommand(),DeleteMultimediaCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Multimedia using Stored Procedure
		/// and return number of rows effected of the Multimedia
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Multimedia",InsertNewMultimediaCommand(),UpdateMultimediaCommand(),DeleteMultimediaCommand(), transaction);
          return rowsAffected;
		}


	}
}
