using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for Site table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Site table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SiteDAC : DataAccessComponent
	{
		#region Constructors
        public SiteDAC() : base("", "ContentManagement.Site") { }
		public SiteDAC(string connectionString): base(connectionString){}
		public SiteDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Site using Stored Procedure
		/// and return a DataTable containing all Site Data
		/// </summary>
		public DataTable GetAllSite()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Site";
         string query = " select * from GetAllSite";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Site"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Site using Stored Procedure
		/// and return a DataTable containing all Site Data using a Transaction
		/// </summary>
		public DataTable GetAllSite(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Site";
         string query = " select * from GetAllSite";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Site"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Site using Stored Procedure
		/// and return a DataTable containing all Site Data
		/// </summary>
		public DataTable GetAllSite(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Site";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSite" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Site"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Site using Stored Procedure
		/// and return a DataTable containing all Site Data using a Transaction
		/// </summary>
		public DataTable GetAllSite(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Site";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSite" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Site"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Site using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSite( int siteId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSite");
				    Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Site using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSite( int siteId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSite");
				    Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Site using Stored Procedure
		/// and return the auto number primary key of Site inserted row
		/// </summary>
		public bool InsertNewSite( int siteId,  string name,  bool isActive,  string timeFormat,  string dateFormat,  int postSize,  int defaultSectionId,  int defaultCommentStatusId,  int defaultSecurityAccessTypeId,  int homeNewsCount,  int homeEventsCount,  int masterPageTemplateId,  bool showFullTextArticles,  bool allowPostingComments,  bool allowAnonymousComments,  Guid rowGuid,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSite");
				Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"TimeFormat",DbType.String,timeFormat);
				Database.AddInParameter(command,"DateFormat",DbType.String,dateFormat);
				Database.AddInParameter(command,"PostSize",DbType.Int32,postSize);
				Database.AddInParameter(command,"DefaultSectionId",DbType.Int32,defaultSectionId);
				Database.AddInParameter(command,"DefaultCommentStatusId",DbType.Int32,defaultCommentStatusId);
				Database.AddInParameter(command,"DefaultSecurityAccessTypeId",DbType.Int32,defaultSecurityAccessTypeId);
				Database.AddInParameter(command,"HomeNewsCount",DbType.Int32,homeNewsCount);
				Database.AddInParameter(command,"HomeEventsCount",DbType.Int32,homeEventsCount);
				Database.AddInParameter(command,"MasterPageTemplateId",DbType.Int32,masterPageTemplateId);
				Database.AddInParameter(command,"ShowFullTextArticles",DbType.Boolean,showFullTextArticles);
				Database.AddInParameter(command,"AllowPostingComments",DbType.Boolean,allowPostingComments);
				Database.AddInParameter(command,"AllowAnonymousComments",DbType.Boolean,allowAnonymousComments);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Site using Stored Procedure
		/// and return the auto number primary key of Site inserted row using Transaction
		/// </summary>
		public bool InsertNewSite( int siteId,  string name,  bool isActive,  string timeFormat,  string dateFormat,  int postSize,  int defaultSectionId,  int defaultCommentStatusId,  int defaultSecurityAccessTypeId,  int homeNewsCount,  int homeEventsCount,  int masterPageTemplateId,  bool showFullTextArticles,  bool allowPostingComments,  bool allowAnonymousComments,  Guid rowGuid,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSite");
				Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"TimeFormat",DbType.String,timeFormat);
				Database.AddInParameter(command,"DateFormat",DbType.String,dateFormat);
				Database.AddInParameter(command,"PostSize",DbType.Int32,postSize);
				Database.AddInParameter(command,"DefaultSectionId",DbType.Int32,defaultSectionId);
				Database.AddInParameter(command,"DefaultCommentStatusId",DbType.Int32,defaultCommentStatusId);
				Database.AddInParameter(command,"DefaultSecurityAccessTypeId",DbType.Int32,defaultSecurityAccessTypeId);
				Database.AddInParameter(command,"HomeNewsCount",DbType.Int32,homeNewsCount);
				Database.AddInParameter(command,"HomeEventsCount",DbType.Int32,homeEventsCount);
				Database.AddInParameter(command,"MasterPageTemplateId",DbType.Int32,masterPageTemplateId);
				Database.AddInParameter(command,"ShowFullTextArticles",DbType.Boolean,showFullTextArticles);
				Database.AddInParameter(command,"AllowPostingComments",DbType.Boolean,allowPostingComments);
				Database.AddInParameter(command,"AllowAnonymousComments",DbType.Boolean,allowAnonymousComments);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Site using Stored Procedure
		/// and return DbCommand of the Site
		/// </summary>
		public DbCommand InsertNewSiteCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSite");
				Database.AddInParameter(command,"SiteId",DbType.Int32,"SiteId",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
				Database.AddInParameter(command,"TimeFormat",DbType.String,"TimeFormat",DataRowVersion.Current);
				Database.AddInParameter(command,"DateFormat",DbType.String,"DateFormat",DataRowVersion.Current);
				Database.AddInParameter(command,"PostSize",DbType.Int32,"PostSize",DataRowVersion.Current);
				Database.AddInParameter(command,"DefaultSectionId",DbType.Int32,"DefaultSectionId",DataRowVersion.Current);
				Database.AddInParameter(command,"DefaultCommentStatusId",DbType.Int32,"DefaultCommentStatusId",DataRowVersion.Current);
				Database.AddInParameter(command,"DefaultSecurityAccessTypeId",DbType.Int32,"DefaultSecurityAccessTypeId",DataRowVersion.Current);
				Database.AddInParameter(command,"HomeNewsCount",DbType.Int32,"HomeNewsCount",DataRowVersion.Current);
				Database.AddInParameter(command,"HomeEventsCount",DbType.Int32,"HomeEventsCount",DataRowVersion.Current);
				Database.AddInParameter(command,"MasterPageTemplateId",DbType.Int32,"MasterPageTemplateId",DataRowVersion.Current);
				Database.AddInParameter(command,"ShowFullTextArticles",DbType.Boolean,"ShowFullTextArticles",DataRowVersion.Current);
				Database.AddInParameter(command,"AllowPostingComments",DbType.Boolean,"AllowPostingComments",DataRowVersion.Current);
				Database.AddInParameter(command,"AllowAnonymousComments",DbType.Boolean,"AllowAnonymousComments",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Site using Stored Procedure
		/// </summary>
		public bool UpdateSite( int siteId, string name, bool isActive, string timeFormat, string dateFormat, int postSize, int defaultSectionId, int defaultCommentStatusId, int defaultSecurityAccessTypeId, int homeNewsCount, int homeEventsCount, int masterPageTemplateId, bool showFullTextArticles, bool allowPostingComments, bool allowAnonymousComments, Guid rowGuid, DateTime modifiedDate, int oldsiteId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSite");
		    		Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
		    		Database.AddInParameter(command,"TimeFormat",DbType.String,timeFormat);
		    		Database.AddInParameter(command,"DateFormat",DbType.String,dateFormat);
		    		Database.AddInParameter(command,"PostSize",DbType.Int32,postSize);
		    		Database.AddInParameter(command,"DefaultSectionId",DbType.Int32,defaultSectionId);
		    		Database.AddInParameter(command,"DefaultCommentStatusId",DbType.Int32,defaultCommentStatusId);
		    		Database.AddInParameter(command,"DefaultSecurityAccessTypeId",DbType.Int32,defaultSecurityAccessTypeId);
		    		Database.AddInParameter(command,"HomeNewsCount",DbType.Int32,homeNewsCount);
		    		Database.AddInParameter(command,"HomeEventsCount",DbType.Int32,homeEventsCount);
		    		Database.AddInParameter(command,"MasterPageTemplateId",DbType.Int32,masterPageTemplateId);
		    		Database.AddInParameter(command,"ShowFullTextArticles",DbType.Boolean,showFullTextArticles);
		    		Database.AddInParameter(command,"AllowPostingComments",DbType.Boolean,allowPostingComments);
		    		Database.AddInParameter(command,"AllowAnonymousComments",DbType.Boolean,allowAnonymousComments);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSiteId",DbType.Int32,oldsiteId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Site using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSite( int siteId, string name, bool isActive, string timeFormat, string dateFormat, int postSize, int defaultSectionId, int defaultCommentStatusId, int defaultSecurityAccessTypeId, int homeNewsCount, int homeEventsCount, int masterPageTemplateId, bool showFullTextArticles, bool allowPostingComments, bool allowAnonymousComments, Guid rowGuid, DateTime modifiedDate, int oldsiteId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSite");
		    		Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
		    		Database.AddInParameter(command,"TimeFormat",DbType.String,timeFormat);
		    		Database.AddInParameter(command,"DateFormat",DbType.String,dateFormat);
		    		Database.AddInParameter(command,"PostSize",DbType.Int32,postSize);
		    		Database.AddInParameter(command,"DefaultSectionId",DbType.Int32,defaultSectionId);
		    		Database.AddInParameter(command,"DefaultCommentStatusId",DbType.Int32,defaultCommentStatusId);
		    		Database.AddInParameter(command,"DefaultSecurityAccessTypeId",DbType.Int32,defaultSecurityAccessTypeId);
		    		Database.AddInParameter(command,"HomeNewsCount",DbType.Int32,homeNewsCount);
		    		Database.AddInParameter(command,"HomeEventsCount",DbType.Int32,homeEventsCount);
		    		Database.AddInParameter(command,"MasterPageTemplateId",DbType.Int32,masterPageTemplateId);
		    		Database.AddInParameter(command,"ShowFullTextArticles",DbType.Boolean,showFullTextArticles);
		    		Database.AddInParameter(command,"AllowPostingComments",DbType.Boolean,allowPostingComments);
		    		Database.AddInParameter(command,"AllowAnonymousComments",DbType.Boolean,allowAnonymousComments);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSiteId",DbType.Int32,oldsiteId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Site using Stored Procedure
		/// </summary>
		public DbCommand UpdateSiteCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSite");
		    		Database.AddInParameter(command,"SiteId",DbType.Int32,"SiteId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
		    		Database.AddInParameter(command,"TimeFormat",DbType.String,"TimeFormat",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DateFormat",DbType.String,"DateFormat",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PostSize",DbType.Int32,"PostSize",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DefaultSectionId",DbType.Int32,"DefaultSectionId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DefaultCommentStatusId",DbType.Int32,"DefaultCommentStatusId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DefaultSecurityAccessTypeId",DbType.Int32,"DefaultSecurityAccessTypeId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"HomeNewsCount",DbType.Int32,"HomeNewsCount",DataRowVersion.Current);
		    		Database.AddInParameter(command,"HomeEventsCount",DbType.Int32,"HomeEventsCount",DataRowVersion.Current);
		    		Database.AddInParameter(command,"MasterPageTemplateId",DbType.Int32,"MasterPageTemplateId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ShowFullTextArticles",DbType.Boolean,"ShowFullTextArticles",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AllowPostingComments",DbType.Boolean,"AllowPostingComments",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AllowAnonymousComments",DbType.Boolean,"AllowAnonymousComments",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSiteId",DbType.Int32,"SiteId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Site using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSite( int siteId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSite");
			Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Site Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSiteCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSite");
				Database.AddInParameter(command,"SiteId",DbType.Int32,"SiteId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Site using Stored Procedure
		/// and return number of rows effected of the Site
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Site",InsertNewSiteCommand(),UpdateSiteCommand(),DeleteSiteCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Site using Stored Procedure
		/// and return number of rows effected of the Site
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Site",InsertNewSiteCommand(),UpdateSiteCommand(),DeleteSiteCommand(), transaction);
          return rowsAffected;
		}


	}
}
