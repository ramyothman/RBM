using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for HomePageGroup table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the HomePageGroup table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class HomePageGroupDAC : DataAccessComponent
	{
		#region Constructors
        public HomePageGroupDAC() : base("", "ContentManagement.HomePageGroup") { }
		public HomePageGroupDAC(string connectionString): base(connectionString){}
		public HomePageGroupDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all HomePageGroup using Stored Procedure
		/// and return a DataTable containing all HomePageGroup Data
		/// </summary>
		public DataTable GetAllHomePageGroup()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "HomePageGroup";
         string query = " select * from GetAllHomePageGroup";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["HomePageGroup"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all HomePageGroup using Stored Procedure
		/// and return a DataTable containing all HomePageGroup Data using a Transaction
		/// </summary>
		public DataTable GetAllHomePageGroup(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "HomePageGroup";
         string query = " select * from GetAllHomePageGroup";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["HomePageGroup"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all HomePageGroup using Stored Procedure
		/// and return a DataTable containing all HomePageGroup Data
		/// </summary>
		public DataTable GetAllHomePageGroup(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "HomePageGroup";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllHomePageGroup" + whereClause + " Order By OrderNumber ";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["HomePageGroup"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all HomePageGroup using Stored Procedure
		/// and return a DataTable containing all HomePageGroup Data using a Transaction
		/// </summary>
		public DataTable GetAllHomePageGroup(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "HomePageGroup";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllHomePageGroup" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["HomePageGroup"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From HomePageGroup using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDHomePageGroup( int homePageGroupID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDHomePageGroup");
				    Database.AddInParameter(command,"HomePageGroupID",DbType.Int32,homePageGroupID);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From HomePageGroup using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDHomePageGroup( int homePageGroupID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDHomePageGroup");
				    Database.AddInParameter(command,"HomePageGroupID",DbType.Int32,homePageGroupID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into HomePageGroup using Stored Procedure
		/// and return the auto number primary key of HomePageGroup inserted row
		/// </summary>
        public bool InsertNewHomePageGroup(ref int homePageGroupID, string groupName, string groupClass, int sectionID, int sitePageLayoutID, int OrderNumber, int SitePageManagerID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewHomePageGroup");
				Database.AddOutParameter(command,"HomePageGroupID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"GroupName",DbType.String,groupName);
				Database.AddInParameter(command,"GroupClass",DbType.String,groupClass);
				Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
				Database.AddInParameter(command,"SitePageLayoutID",DbType.Int32,sitePageLayoutID);
                Database.AddInParameter(command, "OrderNumber", DbType.Int32, OrderNumber);
                Database.AddInParameter(command, "SitePageManagerID", DbType.Int32, SitePageManagerID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 homePageGroupID = Convert.ToInt32(Database.GetParameterValue(command, "HomePageGroupID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into HomePageGroup using Stored Procedure
		/// and return the auto number primary key of HomePageGroup inserted row using Transaction
		/// </summary>
        public bool InsertNewHomePageGroup(ref int homePageGroupID, string groupName, string groupClass, int sectionID, int sitePageLayoutID, int OrderNumber, int SitePageManagerID, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewHomePageGroup");
				Database.AddOutParameter(command,"HomePageGroupID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"GroupName",DbType.String,groupName);
				Database.AddInParameter(command,"GroupClass",DbType.String,groupClass);
				Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
				Database.AddInParameter(command,"SitePageLayoutID",DbType.Int32,sitePageLayoutID);
                Database.AddInParameter(command, "OrderNumber", DbType.Int32, OrderNumber);
                Database.AddInParameter(command, "SitePageManagerID", DbType.Int32, SitePageManagerID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 homePageGroupID = Convert.ToInt32(Database.GetParameterValue(command, "HomePageGroupID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for HomePageGroup using Stored Procedure
		/// and return DbCommand of the HomePageGroup
		/// </summary>
		public DbCommand InsertNewHomePageGroupCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewHomePageGroup");

				Database.AddInParameter(command,"GroupName",DbType.String,"GroupName",DataRowVersion.Current);
				Database.AddInParameter(command,"GroupClass",DbType.String,"GroupClass",DataRowVersion.Current);
				Database.AddInParameter(command,"SectionID",DbType.Int32,"SectionID",DataRowVersion.Current);
				Database.AddInParameter(command,"SitePageLayoutID",DbType.Int32,"SitePageLayoutID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into HomePageGroup using Stored Procedure
		/// </summary>
        public bool UpdateHomePageGroup(string groupName, string groupClass, int sectionID, int sitePageLayoutID, int OrderNumber, int SitePageManagerID, int oldhomePageGroupID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateHomePageGroup");

		    		Database.AddInParameter(command,"GroupName",DbType.String,groupName);
		    		Database.AddInParameter(command,"GroupClass",DbType.String,groupClass);
		    		Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
		    		Database.AddInParameter(command,"SitePageLayoutID",DbType.Int32,sitePageLayoutID);
                    Database.AddInParameter(command, "OrderNumber", DbType.Int32, OrderNumber);
                    Database.AddInParameter(command, "SitePageManagerID", DbType.Int32, SitePageManagerID);
				Database.AddInParameter(command,"oldHomePageGroupID",DbType.Int32,oldhomePageGroupID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into HomePageGroup using Stored Procedure By Transaction
		/// </summary>
        public bool UpdateHomePageGroup(string groupName, string groupClass, int sectionID, int sitePageLayoutID, int OrderNumber, int SitePageManagerID, int oldhomePageGroupID, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateHomePageGroup");

		    		Database.AddInParameter(command,"GroupName",DbType.String,groupName);
		    		Database.AddInParameter(command,"GroupClass",DbType.String,groupClass);
		    		Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
		    		Database.AddInParameter(command,"SitePageLayoutID",DbType.Int32,sitePageLayoutID);
                    Database.AddInParameter(command, "OrderNumber", DbType.Int32, OrderNumber);
                    Database.AddInParameter(command, "SitePageManagerID", DbType.Int32, SitePageManagerID);
				Database.AddInParameter(command,"oldHomePageGroupID",DbType.Int32,oldhomePageGroupID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from HomePageGroup using Stored Procedure
		/// </summary>
		public DbCommand UpdateHomePageGroupCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateHomePageGroup");

		    		Database.AddInParameter(command,"GroupName",DbType.String,"GroupName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"GroupClass",DbType.String,"GroupClass",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SectionID",DbType.Int32,"SectionID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SitePageLayoutID",DbType.Int32,"SitePageLayoutID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldHomePageGroupID",DbType.Int32,"HomePageGroupID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From HomePageGroup using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteHomePageGroup( int homePageGroupID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteHomePageGroup");
			Database.AddInParameter(command,"HomePageGroupID",DbType.Int32,homePageGroupID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From HomePageGroup Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteHomePageGroupCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteHomePageGroup");
				Database.AddInParameter(command,"HomePageGroupID",DbType.Int32,"HomePageGroupID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table HomePageGroup using Stored Procedure
		/// and return number of rows effected of the HomePageGroup
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"HomePageGroup",InsertNewHomePageGroupCommand(),UpdateHomePageGroupCommand(),DeleteHomePageGroupCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table HomePageGroup using Stored Procedure
		/// and return number of rows effected of the HomePageGroup
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"HomePageGroup",InsertNewHomePageGroupCommand(),UpdateHomePageGroupCommand(),DeleteHomePageGroupCommand(), transaction);
          return rowsAffected;
		}


	}
}
