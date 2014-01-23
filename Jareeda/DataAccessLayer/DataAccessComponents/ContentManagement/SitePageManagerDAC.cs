using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for SitePageManager table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the SitePageManager table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SitePageManagerDAC : DataAccessComponent
	{
		#region Constructors
        public SitePageManagerDAC() : base("", "ContentManagement.SitePageManager") { }
		public SitePageManagerDAC(string connectionString): base(connectionString){}
		public SitePageManagerDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageManager using Stored Procedure
		/// and return a DataTable containing all SitePageManager Data
		/// </summary>
		public DataTable GetAllSitePageManager()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageManager";
         string query = " select * from GetAllSitePageManager";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SitePageManager"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageManager using Stored Procedure
		/// and return a DataTable containing all SitePageManager Data using a Transaction
		/// </summary>
		public DataTable GetAllSitePageManager(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageManager";
         string query = " select * from GetAllSitePageManager";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SitePageManager"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageManager using Stored Procedure
		/// and return a DataTable containing all SitePageManager Data
		/// </summary>
		public DataTable GetAllSitePageManager(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageManager";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSitePageManager" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SitePageManager"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageManager using Stored Procedure
		/// and return a DataTable containing all SitePageManager Data using a Transaction
		/// </summary>
		public DataTable GetAllSitePageManager(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageManager";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSitePageManager" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SitePageManager"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SitePageManager using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSitePageManager( int sitePageManagerID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSitePageManager");
				    Database.AddInParameter(command,"SitePageManagerID",DbType.Int32,sitePageManagerID);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}
        //[]
        public System.Data.IDataReader GetBySectionorDefaultSitePageManager(int SiteID,int SectionID, int SitePageTypeID)
        {
            DbCommand command = Database.GetStoredProcCommand("GetBySectionorDefaultSitePageManager");
            Database.AddInParameter(command, "SiteID", DbType.Int32, SiteID);
            Database.AddInParameter(command, "SectionID", DbType.Int32, SectionID);
            Database.AddInParameter(command, "SitePageTypeID", DbType.Int32, SitePageTypeID);
            IDataReader reader = Database.ExecuteReader(command);
            return reader;
        }

        public System.Data.IDataReader GetBySectionIDandTypeIDSitePageManager(int SectionID, int SitePageTypeID)
        {
            DbCommand command = Database.GetStoredProcCommand("GetBySectionIDandTypeIDSitePageManager");
            Database.AddInParameter(command, "SectionID", DbType.Int32, SectionID);
            Database.AddInParameter(command, "SitePageTypeID", DbType.Int32, SitePageTypeID);
            IDataReader reader = Database.ExecuteReader(command);
            return reader;
        }
        //[]
		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SitePageManager using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSitePageManager( int sitePageManagerID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSitePageManager");
				    Database.AddInParameter(command,"SitePageManagerID",DbType.Int32,sitePageManagerID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SitePageManager using Stored Procedure
		/// and return the auto number primary key of SitePageManager inserted row
		/// </summary>
		public bool InsertNewSitePageManager( ref int sitePageManagerID,  int sectionID,  int sitePageTypeID,  bool isMain)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePageManager");
				Database.AddOutParameter(command,"SitePageManagerID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
				Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,sitePageTypeID);
				Database.AddInParameter(command,"IsMain",DbType.Boolean,isMain);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 sitePageManagerID = Convert.ToInt32(Database.GetParameterValue(command, "SitePageManagerID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SitePageManager using Stored Procedure
		/// and return the auto number primary key of SitePageManager inserted row using Transaction
		/// </summary>
		public bool InsertNewSitePageManager( ref int sitePageManagerID,  int sectionID,  int sitePageTypeID,  bool isMain,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePageManager");
				Database.AddOutParameter(command,"SitePageManagerID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
				Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,sitePageTypeID);
				Database.AddInParameter(command,"IsMain",DbType.Boolean,isMain);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 sitePageManagerID = Convert.ToInt32(Database.GetParameterValue(command, "SitePageManagerID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for SitePageManager using Stored Procedure
		/// and return DbCommand of the SitePageManager
		/// </summary>
		public DbCommand InsertNewSitePageManagerCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePageManager");

				Database.AddInParameter(command,"SectionID",DbType.Int32,"SectionID",DataRowVersion.Current);
				Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,"SitePageTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"IsMain",DbType.Boolean,"IsMain",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SitePageManager using Stored Procedure
		/// </summary>
		public bool UpdateSitePageManager( int sectionID, int sitePageTypeID, bool isMain, int oldsitePageManagerID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePageManager");

		    		Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
		    		Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,sitePageTypeID);
		    		Database.AddInParameter(command,"IsMain",DbType.Boolean,isMain);
				Database.AddInParameter(command,"oldSitePageManagerID",DbType.Int32,oldsitePageManagerID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SitePageManager using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSitePageManager( int sectionID, int sitePageTypeID, bool isMain, int oldsitePageManagerID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePageManager");

		    		Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
		    		Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,sitePageTypeID);
		    		Database.AddInParameter(command,"IsMain",DbType.Boolean,isMain);
				Database.AddInParameter(command,"oldSitePageManagerID",DbType.Int32,oldsitePageManagerID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from SitePageManager using Stored Procedure
		/// </summary>
		public DbCommand UpdateSitePageManagerCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePageManager");

		    		Database.AddInParameter(command,"SectionID",DbType.Int32,"SectionID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,"SitePageTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsMain",DbType.Boolean,"IsMain",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSitePageManagerID",DbType.Int32,"SitePageManagerID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From SitePageManager using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSitePageManager( int sitePageManagerID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSitePageManager");
			Database.AddInParameter(command,"SitePageManagerID",DbType.Int32,sitePageManagerID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From SitePageManager Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSitePageManagerCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSitePageManager");
				Database.AddInParameter(command,"SitePageManagerID",DbType.Int32,"SitePageManagerID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SitePageManager using Stored Procedure
		/// and return number of rows effected of the SitePageManager
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SitePageManager",InsertNewSitePageManagerCommand(),UpdateSitePageManagerCommand(),DeleteSitePageManagerCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SitePageManager using Stored Procedure
		/// and return number of rows effected of the SitePageManager
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SitePageManager",InsertNewSitePageManagerCommand(),UpdateSitePageManagerCommand(),DeleteSitePageManagerCommand(), transaction);
          return rowsAffected;
		}


	}
}
