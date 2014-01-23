using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for SitePageCategory table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the SitePageCategory table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SitePageCategoryDAC : DataAccessComponent
	{
		#region Constructors
        public SitePageCategoryDAC() : base("", "ContentManagement.SitePageCategory") { }
		public SitePageCategoryDAC(string connectionString): base(connectionString){}
		public SitePageCategoryDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageCategory using Stored Procedure
		/// and return a DataTable containing all SitePageCategory Data
		/// </summary>
		public DataTable GetAllSitePageCategory()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageCategory";
         string query = " select * from GetAllSitePageCategory";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SitePageCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageCategory using Stored Procedure
		/// and return a DataTable containing all SitePageCategory Data using a Transaction
		/// </summary>
		public DataTable GetAllSitePageCategory(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageCategory";
         string query = " select * from GetAllSitePageCategory";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SitePageCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageCategory using Stored Procedure
		/// and return a DataTable containing all SitePageCategory Data
		/// </summary>
		public DataTable GetAllSitePageCategory(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageCategory";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSitePageCategory" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SitePageCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageCategory using Stored Procedure
		/// and return a DataTable containing all SitePageCategory Data using a Transaction
		/// </summary>
		public DataTable GetAllSitePageCategory(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageCategory";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSitePageCategory" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SitePageCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SitePageCategory using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSitePageCategory( int sitePageCategoryId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSitePageCategory");
				    Database.AddInParameter(command,"SitePageCategoryId",DbType.Int32,sitePageCategoryId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SitePageCategory using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSitePageCategory( int sitePageCategoryId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSitePageCategory");
				    Database.AddInParameter(command,"SitePageCategoryId",DbType.Int32,sitePageCategoryId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SitePageCategory using Stored Procedure
		/// and return the auto number primary key of SitePageCategory inserted row
		/// </summary>
		public bool InsertNewSitePageCategory( ref int sitePageCategoryId,  int siteCategoryId,  int sitePageId,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePageCategory");
				Database.AddOutParameter(command,"SitePageCategoryId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,siteCategoryId);
				Database.AddInParameter(command,"SitePageId",DbType.Int32,sitePageId);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 sitePageCategoryId = Convert.ToInt32(Database.GetParameterValue(command, "SitePageCategoryId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SitePageCategory using Stored Procedure
		/// and return the auto number primary key of SitePageCategory inserted row using Transaction
		/// </summary>
		public bool InsertNewSitePageCategory( ref int sitePageCategoryId,  int siteCategoryId,  int sitePageId,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePageCategory");
				Database.AddOutParameter(command,"SitePageCategoryId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,siteCategoryId);
				Database.AddInParameter(command,"SitePageId",DbType.Int32,sitePageId);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 sitePageCategoryId = Convert.ToInt32(Database.GetParameterValue(command, "SitePageCategoryId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for SitePageCategory using Stored Procedure
		/// and return DbCommand of the SitePageCategory
		/// </summary>
		public DbCommand InsertNewSitePageCategoryCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePageCategory");

				Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,"SiteCategoryId",DataRowVersion.Current);
				Database.AddInParameter(command,"SitePageId",DbType.Int32,"SitePageId",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SitePageCategory using Stored Procedure
		/// </summary>
		public bool UpdateSitePageCategory( int siteCategoryId, int sitePageId, DateTime modifiedDate, int oldsitePageCategoryId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePageCategory");

		    		Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,siteCategoryId);
		    		Database.AddInParameter(command,"SitePageId",DbType.Int32,sitePageId);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSitePageCategoryId",DbType.Int32,oldsitePageCategoryId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SitePageCategory using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSitePageCategory( int siteCategoryId, int sitePageId, DateTime modifiedDate, int oldsitePageCategoryId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePageCategory");

		    		Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,siteCategoryId);
		    		Database.AddInParameter(command,"SitePageId",DbType.Int32,sitePageId);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSitePageCategoryId",DbType.Int32,oldsitePageCategoryId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from SitePageCategory using Stored Procedure
		/// </summary>
		public DbCommand UpdateSitePageCategoryCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePageCategory");

		    		Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,"SiteCategoryId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SitePageId",DbType.Int32,"SitePageId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSitePageCategoryId",DbType.Int32,"SitePageCategoryId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From SitePageCategory using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSitePageCategory( int sitePageCategoryId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSitePageCategory");
			Database.AddInParameter(command,"SitePageCategoryId",DbType.Int32,sitePageCategoryId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

        public bool DeleteSitePageCategoryBySitePageId(int sitePageId)
        {
            DbCommand command = Database.GetStoredProcCommand("DeleteSitePageCategoryBySitePageId");
            Database.AddInParameter(command, "SitePageId", DbType.Int32, sitePageId);
            bool status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                status = true;
            }
            return status;
        }

        

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From SitePageCategory Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSitePageCategoryCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSitePageCategory");
				Database.AddInParameter(command,"SitePageCategoryId",DbType.Int32,"SitePageCategoryId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SitePageCategory using Stored Procedure
		/// and return number of rows effected of the SitePageCategory
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SitePageCategory",InsertNewSitePageCategoryCommand(),UpdateSitePageCategoryCommand(),DeleteSitePageCategoryCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SitePageCategory using Stored Procedure
		/// and return number of rows effected of the SitePageCategory
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SitePageCategory",InsertNewSitePageCategoryCommand(),UpdateSitePageCategoryCommand(),DeleteSitePageCategoryCommand(), transaction);
          return rowsAffected;
		}


	}
}
