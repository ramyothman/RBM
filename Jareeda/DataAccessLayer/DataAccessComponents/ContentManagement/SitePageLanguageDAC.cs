using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for SitePageLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the SitePageLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SitePageLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public SitePageLanguageDAC() : base("", "ContentManagement.SitePageLanguage") { }
		public SitePageLanguageDAC(string connectionString): base(connectionString){}
		public SitePageLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageLanguage using Stored Procedure
		/// and return a DataTable containing all SitePageLanguage Data
		/// </summary>
		public DataTable GetAllSitePageLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageLanguage";
         string query = " select * from GetAllSitePageLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SitePageLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageLanguage using Stored Procedure
		/// and return a DataTable containing all SitePageLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllSitePageLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageLanguage";
         string query = " select * from GetAllSitePageLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SitePageLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageLanguage using Stored Procedure
		/// and return a DataTable containing all SitePageLanguage Data
		/// </summary>
		public DataTable GetAllSitePageLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSitePageLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SitePageLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageLanguage using Stored Procedure
		/// and return a DataTable containing all SitePageLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllSitePageLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSitePageLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SitePageLanguage"];

		}


        public System.Data.IDataReader GetByPageIDLanguageIdSitePageLanguage(int SitePageId,int LanguageId)
		{
            DbCommand command = Database.GetStoredProcCommand("GetByPageIDLanguageIdSitePageLanguage");
            Database.AddInParameter(command, "SitePageId", DbType.Int32, SitePageId);
            Database.AddInParameter(command, "LanguageId", DbType.Int32, LanguageId);
            IDataReader reader = this.FromCache(command).CreateDataReader(); //Database.ExecuteReader(command);
				return reader;
		}
		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SitePageLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSitePageLanguage( int sitePageLanguageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSitePageLanguage");
				    Database.AddInParameter(command,"SitePageLanguageId",DbType.Int32,sitePageLanguageId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SitePageLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSitePageLanguage( int sitePageLanguageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSitePageLanguage");
				    Database.AddInParameter(command,"SitePageLanguageId",DbType.Int32,sitePageLanguageId);
				IDataReader reader  =  Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SitePageLanguage using Stored Procedure
		/// and return the auto number primary key of SitePageLanguage inserted row
		/// </summary>
		public bool InsertNewSitePageLanguage( ref int sitePageLanguageId,  int sitePageId,  int languageId,  string pageName,  string pageContent,  string authorAlias,  string pageAlias,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePageLanguage");
				Database.AddOutParameter(command,"SitePageLanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SitePageId",DbType.Int32,sitePageId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"PageName",DbType.String,pageName);
				Database.AddInParameter(command,"PageContent",DbType.String,pageContent);
				Database.AddInParameter(command,"AuthorAlias",DbType.String,authorAlias);
				Database.AddInParameter(command,"PageAlias",DbType.String,pageAlias);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 sitePageLanguageId = Convert.ToInt32(Database.GetParameterValue(command, "SitePageLanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SitePageLanguage using Stored Procedure
		/// and return the auto number primary key of SitePageLanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewSitePageLanguage( ref int sitePageLanguageId,  int sitePageId,  int languageId,  string pageName,  string pageContent,  string authorAlias,  string pageAlias,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePageLanguage");
				Database.AddOutParameter(command,"SitePageLanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SitePageId",DbType.Int32,sitePageId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"PageName",DbType.String,pageName);
				Database.AddInParameter(command,"PageContent",DbType.String,pageContent);
				Database.AddInParameter(command,"AuthorAlias",DbType.String,authorAlias);
				Database.AddInParameter(command,"PageAlias",DbType.String,pageAlias);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 sitePageLanguageId = Convert.ToInt32(Database.GetParameterValue(command, "SitePageLanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for SitePageLanguage using Stored Procedure
		/// and return DbCommand of the SitePageLanguage
		/// </summary>
		public DbCommand InsertNewSitePageLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePageLanguage");

				Database.AddInParameter(command,"SitePageId",DbType.Int32,"SitePageId",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
				Database.AddInParameter(command,"PageName",DbType.String,"PageName",DataRowVersion.Current);
				Database.AddInParameter(command,"PageContent",DbType.String,"PageContent",DataRowVersion.Current);
				Database.AddInParameter(command,"AuthorAlias",DbType.String,"AuthorAlias",DataRowVersion.Current);
				Database.AddInParameter(command,"PageAlias",DbType.String,"PageAlias",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SitePageLanguage using Stored Procedure
		/// </summary>
		public bool UpdateSitePageLanguage( int sitePageId, int languageId, string pageName, string pageContent, string authorAlias, string pageAlias, DateTime modifiedDate, int oldsitePageLanguageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePageLanguage");

		    		Database.AddInParameter(command,"SitePageId",DbType.Int32,sitePageId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"PageName",DbType.String,pageName);
		    		Database.AddInParameter(command,"PageContent",DbType.String,pageContent);
		    		Database.AddInParameter(command,"AuthorAlias",DbType.String,authorAlias);
		    		Database.AddInParameter(command,"PageAlias",DbType.String,pageAlias);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSitePageLanguageId",DbType.Int32,oldsitePageLanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SitePageLanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSitePageLanguage( int sitePageId, int languageId, string pageName, string pageContent, string authorAlias, string pageAlias, DateTime modifiedDate, int oldsitePageLanguageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePageLanguage");

		    		Database.AddInParameter(command,"SitePageId",DbType.Int32,sitePageId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"PageName",DbType.String,pageName);
		    		Database.AddInParameter(command,"PageContent",DbType.String,pageContent);
		    		Database.AddInParameter(command,"AuthorAlias",DbType.String,authorAlias);
		    		Database.AddInParameter(command,"PageAlias",DbType.String,pageAlias);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSitePageLanguageId",DbType.Int32,oldsitePageLanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from SitePageLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateSitePageLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePageLanguage");

		    		Database.AddInParameter(command,"SitePageId",DbType.Int32,"SitePageId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PageName",DbType.String,"PageName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PageContent",DbType.String,"PageContent",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AuthorAlias",DbType.String,"AuthorAlias",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PageAlias",DbType.String,"PageAlias",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSitePageLanguageId",DbType.Int32,"SitePageLanguageId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From SitePageLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSitePageLanguage( int sitePageLanguageId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSitePageLanguage");
			Database.AddInParameter(command,"SitePageLanguageId",DbType.Int32,sitePageLanguageId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From SitePageLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSitePageLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSitePageLanguage");
				Database.AddInParameter(command,"SitePageLanguageId",DbType.Int32,"SitePageLanguageId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SitePageLanguage using Stored Procedure
		/// and return number of rows effected of the SitePageLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SitePageLanguage",InsertNewSitePageLanguageCommand(),UpdateSitePageLanguageCommand(),DeleteSitePageLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SitePageLanguage using Stored Procedure
		/// and return number of rows effected of the SitePageLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SitePageLanguage",InsertNewSitePageLanguageCommand(),UpdateSitePageLanguageCommand(),DeleteSitePageLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
