using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for MediaSource table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the MediaSource table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class MediaSourceDAC : DataAccessComponent
	{
		#region Constructors
        public MediaSourceDAC() : base("", "ContentManagement.MediaSource") { }
		public MediaSourceDAC(string connectionString): base(connectionString){}
		public MediaSourceDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MediaSource using Stored Procedure
		/// and return a DataTable containing all MediaSource Data
		/// </summary>
		public DataTable GetAllMediaSource()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MediaSource";
         string query = " select * from GetAllMediaSource";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MediaSource"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MediaSource using Stored Procedure
		/// and return a DataTable containing all MediaSource Data using a Transaction
		/// </summary>
		public DataTable GetAllMediaSource(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MediaSource";
         string query = " select * from GetAllMediaSource";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MediaSource"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MediaSource using Stored Procedure
		/// and return a DataTable containing all MediaSource Data
		/// </summary>
		public DataTable GetAllMediaSource(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MediaSource";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllMediaSource" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MediaSource"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MediaSource using Stored Procedure
		/// and return a DataTable containing all MediaSource Data using a Transaction
		/// </summary>
		public DataTable GetAllMediaSource(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MediaSource";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllMediaSource" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MediaSource"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MediaSource using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMediaSource( int mediaSourceID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMediaSource");
				    Database.AddInParameter(command,"MediaSourceID",DbType.Int32,mediaSourceID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MediaSource using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMediaSource( int mediaSourceID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMediaSource");
				    Database.AddInParameter(command,"MediaSourceID",DbType.Int32,mediaSourceID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MediaSource using Stored Procedure
		/// and return the auto number primary key of MediaSource inserted row
		/// </summary>
		public bool InsertNewMediaSource( ref int mediaSourceID,  string name,  string site,  string rss,  string privateUrl)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMediaSource");
				Database.AddOutParameter(command,"MediaSourceID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Site",DbType.String,site);
				Database.AddInParameter(command,"Rss",DbType.String,rss);
				Database.AddInParameter(command,"PrivateUrl",DbType.String,privateUrl);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 mediaSourceID = Convert.ToInt32(Database.GetParameterValue(command, "MediaSourceID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MediaSource using Stored Procedure
		/// and return the auto number primary key of MediaSource inserted row using Transaction
		/// </summary>
		public bool InsertNewMediaSource( ref int mediaSourceID,  string name,  string site,  string rss,  string privateUrl,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMediaSource");
				Database.AddOutParameter(command,"MediaSourceID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Site",DbType.String,site);
				Database.AddInParameter(command,"Rss",DbType.String,rss);
				Database.AddInParameter(command,"PrivateUrl",DbType.String,privateUrl);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 mediaSourceID = Convert.ToInt32(Database.GetParameterValue(command, "MediaSourceID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for MediaSource using Stored Procedure
		/// and return DbCommand of the MediaSource
		/// </summary>
		public DbCommand InsertNewMediaSourceCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMediaSource");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"Site",DbType.String,"Site",DataRowVersion.Current);
				Database.AddInParameter(command,"Rss",DbType.String,"Rss",DataRowVersion.Current);
				Database.AddInParameter(command,"PrivateUrl",DbType.String,"PrivateUrl",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MediaSource using Stored Procedure
		/// </summary>
		public bool UpdateMediaSource( string name, string site, string rss, string privateUrl, int oldmediaSourceID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMediaSource");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Site",DbType.String,site);
		    		Database.AddInParameter(command,"Rss",DbType.String,rss);
		    		Database.AddInParameter(command,"PrivateUrl",DbType.String,privateUrl);
				Database.AddInParameter(command,"oldMediaSourceID",DbType.Int32,oldmediaSourceID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MediaSource using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateMediaSource( string name, string site, string rss, string privateUrl, int oldmediaSourceID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMediaSource");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Site",DbType.String,site);
		    		Database.AddInParameter(command,"Rss",DbType.String,rss);
		    		Database.AddInParameter(command,"PrivateUrl",DbType.String,privateUrl);
				Database.AddInParameter(command,"oldMediaSourceID",DbType.Int32,oldmediaSourceID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from MediaSource using Stored Procedure
		/// </summary>
		public DbCommand UpdateMediaSourceCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMediaSource");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Site",DbType.String,"Site",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Rss",DbType.String,"Rss",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PrivateUrl",DbType.String,"PrivateUrl",DataRowVersion.Current);
				Database.AddInParameter(command,"oldMediaSourceID",DbType.Int32,"MediaSourceID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From MediaSource using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteMediaSource( int mediaSourceID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteMediaSource");
			Database.AddInParameter(command,"MediaSourceID",DbType.Int32,mediaSourceID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From MediaSource Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteMediaSourceCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteMediaSource");
				Database.AddInParameter(command,"MediaSourceID",DbType.Int32,"MediaSourceID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MediaSource using Stored Procedure
		/// and return number of rows effected of the MediaSource
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MediaSource",InsertNewMediaSourceCommand(),UpdateMediaSourceCommand(),DeleteMediaSourceCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MediaSource using Stored Procedure
		/// and return number of rows effected of the MediaSource
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MediaSource",InsertNewMediaSourceCommand(),UpdateMediaSourceCommand(),DeleteMediaSourceCommand(), transaction);
          return rowsAffected;
		}


	}
}
