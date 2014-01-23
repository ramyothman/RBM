using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for SitePageLayout table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the SitePageLayout table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SitePageLayoutDAC : DataAccessComponent
	{
		#region Constructors
        public SitePageLayoutDAC() : base("", "ContentManagement.SitePageLayout") { }
		public SitePageLayoutDAC(string connectionString): base(connectionString){}
		public SitePageLayoutDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageLayout using Stored Procedure
		/// and return a DataTable containing all SitePageLayout Data
		/// </summary>
		public DataTable GetAllSitePageLayout()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageLayout";
         string query = " select * from GetAllSitePageLayout";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SitePageLayout"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageLayout using Stored Procedure
		/// and return a DataTable containing all SitePageLayout Data using a Transaction
		/// </summary>
		public DataTable GetAllSitePageLayout(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageLayout";
         string query = " select * from GetAllSitePageLayout";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SitePageLayout"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageLayout using Stored Procedure
		/// and return a DataTable containing all SitePageLayout Data
		/// </summary>
		public DataTable GetAllSitePageLayout(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageLayout";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSitePageLayout" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SitePageLayout"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageLayout using Stored Procedure
		/// and return a DataTable containing all SitePageLayout Data using a Transaction
		/// </summary>
		public DataTable GetAllSitePageLayout(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageLayout";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSitePageLayout" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SitePageLayout"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SitePageLayout using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSitePageLayout( int sitePageLayoutID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSitePageLayout");
				    Database.AddInParameter(command,"SitePageLayoutID",DbType.Int32,sitePageLayoutID);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SitePageLayout using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSitePageLayout( int sitePageLayoutID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSitePageLayout");
				    Database.AddInParameter(command,"SitePageLayoutID",DbType.Int32,sitePageLayoutID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SitePageLayout using Stored Procedure
		/// and return the auto number primary key of SitePageLayout inserted row
		/// </summary>
		public bool InsertNewSitePageLayout( ref int sitePageLayoutID,  int siteID,  string name,  string designCode,  string previewCode,  string previewClass)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePageLayout");
				Database.AddOutParameter(command,"SitePageLayoutID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SiteID",DbType.Int32,siteID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"DesignCode",DbType.String,designCode);
				Database.AddInParameter(command,"PreviewCode",DbType.String,previewCode);
				Database.AddInParameter(command,"PreviewClass",DbType.String,previewClass);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 sitePageLayoutID = Convert.ToInt32(Database.GetParameterValue(command, "SitePageLayoutID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SitePageLayout using Stored Procedure
		/// and return the auto number primary key of SitePageLayout inserted row using Transaction
		/// </summary>
		public bool InsertNewSitePageLayout( ref int sitePageLayoutID,  int siteID,  string name,  string designCode,  string previewCode,  string previewClass,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePageLayout");
				Database.AddOutParameter(command,"SitePageLayoutID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SiteID",DbType.Int32,siteID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"DesignCode",DbType.String,designCode);
				Database.AddInParameter(command,"PreviewCode",DbType.String,previewCode);
				Database.AddInParameter(command,"PreviewClass",DbType.String,previewClass);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 sitePageLayoutID = Convert.ToInt32(Database.GetParameterValue(command, "SitePageLayoutID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for SitePageLayout using Stored Procedure
		/// and return DbCommand of the SitePageLayout
		/// </summary>
		public DbCommand InsertNewSitePageLayoutCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePageLayout");

				Database.AddInParameter(command,"SiteID",DbType.Int32,"SiteID",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"DesignCode",DbType.String,"DesignCode",DataRowVersion.Current);
				Database.AddInParameter(command,"PreviewCode",DbType.String,"PreviewCode",DataRowVersion.Current);
				Database.AddInParameter(command,"PreviewClass",DbType.String,"PreviewClass",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SitePageLayout using Stored Procedure
		/// </summary>
		public bool UpdateSitePageLayout( int siteID, string name, string designCode, string previewCode, string previewClass, int oldsitePageLayoutID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePageLayout");

		    		Database.AddInParameter(command,"SiteID",DbType.Int32,siteID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"DesignCode",DbType.String,designCode);
		    		Database.AddInParameter(command,"PreviewCode",DbType.String,previewCode);
		    		Database.AddInParameter(command,"PreviewClass",DbType.String,previewClass);
				Database.AddInParameter(command,"oldSitePageLayoutID",DbType.Int32,oldsitePageLayoutID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SitePageLayout using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSitePageLayout( int siteID, string name, string designCode, string previewCode, string previewClass, int oldsitePageLayoutID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePageLayout");

		    		Database.AddInParameter(command,"SiteID",DbType.Int32,siteID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"DesignCode",DbType.String,designCode);
		    		Database.AddInParameter(command,"PreviewCode",DbType.String,previewCode);
		    		Database.AddInParameter(command,"PreviewClass",DbType.String,previewClass);
				Database.AddInParameter(command,"oldSitePageLayoutID",DbType.Int32,oldsitePageLayoutID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from SitePageLayout using Stored Procedure
		/// </summary>
		public DbCommand UpdateSitePageLayoutCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePageLayout");

		    		Database.AddInParameter(command,"SiteID",DbType.Int32,"SiteID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DesignCode",DbType.String,"DesignCode",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PreviewCode",DbType.String,"PreviewCode",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PreviewClass",DbType.String,"PreviewClass",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSitePageLayoutID",DbType.Int32,"SitePageLayoutID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From SitePageLayout using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSitePageLayout( int sitePageLayoutID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSitePageLayout");
			Database.AddInParameter(command,"SitePageLayoutID",DbType.Int32,sitePageLayoutID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From SitePageLayout Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSitePageLayoutCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSitePageLayout");
				Database.AddInParameter(command,"SitePageLayoutID",DbType.Int32,"SitePageLayoutID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SitePageLayout using Stored Procedure
		/// and return number of rows effected of the SitePageLayout
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SitePageLayout",InsertNewSitePageLayoutCommand(),UpdateSitePageLayoutCommand(),DeleteSitePageLayoutCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SitePageLayout using Stored Procedure
		/// and return number of rows effected of the SitePageLayout
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SitePageLayout",InsertNewSitePageLayoutCommand(),UpdateSitePageLayoutCommand(),DeleteSitePageLayoutCommand(), transaction);
          return rowsAffected;
		}


	}
}
