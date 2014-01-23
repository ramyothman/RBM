using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for SitePage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the SitePage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SitePageDAC : DataAccessComponent
	{
		#region Constructors
        public SitePageDAC() : base("", "ContentManagement.SitePage") { }
		public SitePageDAC(string connectionString): base(connectionString){}
		public SitePageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePage using Stored Procedure
		/// and return a DataTable containing all SitePage Data
		/// </summary>
		public DataTable GetAllSitePage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePage";
         string query = " select * from GetAllSitePage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SitePage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePage using Stored Procedure
		/// and return a DataTable containing all SitePage Data using a Transaction
		/// </summary>
		public DataTable GetAllSitePage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePage";
         string query = " select * from GetAllSitePage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SitePage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePage using Stored Procedure
		/// and return a DataTable containing all SitePage Data
		/// </summary>
		public DataTable GetAllSitePage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSitePage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SitePage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePage using Stored Procedure
		/// and return a DataTable containing all SitePage Data using a Transaction
		/// </summary>
		public DataTable GetAllSitePage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSitePage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SitePage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SitePage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSitePage( int sitePageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSitePage");
				    Database.AddInParameter(command,"SitePageId",DbType.Int32,sitePageId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SitePage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSitePage( int sitePageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSitePage");
				    Database.AddInParameter(command,"SitePageId",DbType.Int32,sitePageId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SitePage using Stored Procedure
		/// and return the auto number primary key of SitePage inserted row
		/// </summary>
		public bool InsertNewSitePage( int sitePageId,  int sectionId,  int pageStatusId,  int securityAccessTypeId,  int creatorId,  string uniquePageName,  bool isMainPage,  Guid rowGuid,  DateTime revisionDate,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePage");
				Database.AddInParameter(command,"SitePageId",DbType.Int32,sitePageId);
				Database.AddInParameter(command,"SectionId",DbType.Int32,sectionId);
				Database.AddInParameter(command,"PageStatusId",DbType.Int32,pageStatusId);
				Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
				Database.AddInParameter(command,"CreatorId",DbType.Int32,creatorId);
				Database.AddInParameter(command,"UniquePageName",DbType.String,uniquePageName);
				Database.AddInParameter(command,"IsMainPage",DbType.Boolean,isMainPage);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"RevisionDate",DbType.DateTime,revisionDate);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SitePage using Stored Procedure
		/// and return the auto number primary key of SitePage inserted row using Transaction
		/// </summary>
		public bool InsertNewSitePage( int sitePageId,  int sectionId,  int pageStatusId,  int securityAccessTypeId,  int creatorId,  string uniquePageName,  bool isMainPage,  Guid rowGuid,  DateTime revisionDate,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePage");
				Database.AddInParameter(command,"SitePageId",DbType.Int32,sitePageId);
				Database.AddInParameter(command,"SectionId",DbType.Int32,sectionId);
				Database.AddInParameter(command,"PageStatusId",DbType.Int32,pageStatusId);
				Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
				Database.AddInParameter(command,"CreatorId",DbType.Int32,creatorId);
				Database.AddInParameter(command,"UniquePageName",DbType.String,uniquePageName);
				Database.AddInParameter(command,"IsMainPage",DbType.Boolean,isMainPage);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"RevisionDate",DbType.DateTime,revisionDate);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for SitePage using Stored Procedure
		/// and return DbCommand of the SitePage
		/// </summary>
		public DbCommand InsertNewSitePageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePage");
				Database.AddInParameter(command,"SitePageId",DbType.Int32,"SitePageId",DataRowVersion.Current);
				Database.AddInParameter(command,"SectionId",DbType.Int32,"SectionId",DataRowVersion.Current);
				Database.AddInParameter(command,"PageStatusId",DbType.Int32,"PageStatusId",DataRowVersion.Current);
				Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,"SecurityAccessTypeId",DataRowVersion.Current);
				Database.AddInParameter(command,"CreatorId",DbType.Int32,"CreatorId",DataRowVersion.Current);
				Database.AddInParameter(command,"UniquePageName",DbType.String,"UniquePageName",DataRowVersion.Current);
				Database.AddInParameter(command,"IsMainPage",DbType.Boolean,"IsMainPage",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"RevisionDate",DbType.DateTime,"RevisionDate",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SitePage using Stored Procedure
		/// </summary>
		public bool UpdateSitePage( int sitePageId, int sectionId, int pageStatusId, int securityAccessTypeId, int creatorId, string uniquePageName, bool isMainPage, Guid rowGuid, DateTime revisionDate, DateTime modifiedDate, int oldsitePageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePage");
		    		Database.AddInParameter(command,"SitePageId",DbType.Int32,sitePageId);
		    		Database.AddInParameter(command,"SectionId",DbType.Int32,sectionId);
		    		Database.AddInParameter(command,"PageStatusId",DbType.Int32,pageStatusId);
		    		Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
		    		Database.AddInParameter(command,"CreatorId",DbType.Int32,creatorId);
		    		Database.AddInParameter(command,"UniquePageName",DbType.String,uniquePageName);
		    		Database.AddInParameter(command,"IsMainPage",DbType.Boolean,isMainPage);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"RevisionDate",DbType.DateTime,revisionDate);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSitePageId",DbType.Int32,oldsitePageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SitePage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSitePage( int sitePageId, int sectionId, int pageStatusId, int securityAccessTypeId, int creatorId, string uniquePageName, bool isMainPage, Guid rowGuid, DateTime revisionDate, DateTime modifiedDate, int oldsitePageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePage");
		    		Database.AddInParameter(command,"SitePageId",DbType.Int32,sitePageId);
		    		Database.AddInParameter(command,"SectionId",DbType.Int32,sectionId);
		    		Database.AddInParameter(command,"PageStatusId",DbType.Int32,pageStatusId);
		    		Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
		    		Database.AddInParameter(command,"CreatorId",DbType.Int32,creatorId);
		    		Database.AddInParameter(command,"UniquePageName",DbType.String,uniquePageName);
		    		Database.AddInParameter(command,"IsMainPage",DbType.Boolean,isMainPage);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"RevisionDate",DbType.DateTime,revisionDate);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSitePageId",DbType.Int32,oldsitePageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from SitePage using Stored Procedure
		/// </summary>
		public DbCommand UpdateSitePageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePage");
		    		Database.AddInParameter(command,"SitePageId",DbType.Int32,"SitePageId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SectionId",DbType.Int32,"SectionId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PageStatusId",DbType.Int32,"PageStatusId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,"SecurityAccessTypeId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CreatorId",DbType.Int32,"CreatorId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"UniquePageName",DbType.String,"UniquePageName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsMainPage",DbType.Boolean,"IsMainPage",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RevisionDate",DbType.DateTime,"RevisionDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSitePageId",DbType.Int32,"SitePageId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From SitePage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSitePage( int sitePageId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSitePage");
			Database.AddInParameter(command,"SitePageId",DbType.Int32,sitePageId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From SitePage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSitePageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSitePage");
				Database.AddInParameter(command,"SitePageId",DbType.Int32,"SitePageId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SitePage using Stored Procedure
		/// and return number of rows effected of the SitePage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SitePage",InsertNewSitePageCommand(),UpdateSitePageCommand(),DeleteSitePageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SitePage using Stored Procedure
		/// and return number of rows effected of the SitePage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SitePage",InsertNewSitePageCommand(),UpdateSitePageCommand(),DeleteSitePageCommand(), transaction);
          return rowsAffected;
		}


	}
}
