using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for HomePage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the HomePage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class HomePageDAC : DataAccessComponent
	{
		#region Constructors
        public HomePageDAC() : base("", "ContentManagement.HomePage") { }
		public HomePageDAC(string connectionString): base(connectionString){}
		public HomePageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all HomePage using Stored Procedure
		/// and return a DataTable containing all HomePage Data
		/// </summary>
		public DataTable GetAllHomePage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "HomePage";
         string query = " select * from GetAllHomePage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["HomePage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all HomePage using Stored Procedure
		/// and return a DataTable containing all HomePage Data using a Transaction
		/// </summary>
		public DataTable GetAllHomePage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "HomePage";
         string query = " select * from GetAllHomePage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["HomePage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all HomePage using Stored Procedure
		/// and return a DataTable containing all HomePage Data
		/// </summary>
		public DataTable GetAllHomePage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "HomePage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllHomePage" + whereClause + " Order By OrderNumber";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["HomePage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all HomePage using Stored Procedure
		/// and return a DataTable containing all HomePage Data using a Transaction
		/// </summary>
		public DataTable GetAllHomePage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "HomePage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllHomePage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["HomePage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From HomePage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDHomePage( int homePageID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDHomePage");
				    Database.AddInParameter(command,"HomePageID",DbType.Int32,homePageID);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From HomePage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDHomePage( int homePageID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDHomePage");
				    Database.AddInParameter(command,"HomePageID",DbType.Int32,homePageID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into HomePage using Stored Procedure
		/// and return the auto number primary key of HomePage inserted row
		/// </summary>
        public bool InsertNewHomePage(ref int homePageID, int sectionID, int contentModuleTypeID, int positionID, int orderNumber, bool isFullWidth, int itemsNumber, int itemsPerPage, bool isActive, string Title, int LanguageID, int HomePageGroupID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewHomePage");
				Database.AddOutParameter(command,"HomePageID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
				Database.AddInParameter(command,"ContentModuleTypeID",DbType.Int32,contentModuleTypeID);
				Database.AddInParameter(command,"PositionID",DbType.Int32,positionID);
				Database.AddInParameter(command,"OrderNumber",DbType.Int32,orderNumber);
				Database.AddInParameter(command,"IsFullWidth",DbType.Boolean,isFullWidth);
				Database.AddInParameter(command,"ItemsNumber",DbType.Int32,itemsNumber);
				Database.AddInParameter(command,"ItemsPerPage",DbType.Int32,itemsPerPage);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
                Database.AddInParameter(command, "Title", DbType.String, Title);
                Database.AddInParameter(command, "LanguageID", DbType.Int32, LanguageID);
                Database.AddInParameter(command, "HomePageGroupID", DbType.Int32, HomePageGroupID);
				bool _status = false;
				
            if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 homePageID = Convert.ToInt32(Database.GetParameterValue(command, "HomePageID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into HomePage using Stored Procedure
		/// and return the auto number primary key of HomePage inserted row using Transaction
		/// </summary>
        public bool InsertNewHomePage(ref int homePageID, int sectionID, int contentModuleTypeID, int positionID, int orderNumber, bool isFullWidth, int itemsNumber, int itemsPerPage, bool isActive, string Title, int LanguageID, int HomePageGroupID, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewHomePage");
				Database.AddOutParameter(command,"HomePageID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
				Database.AddInParameter(command,"ContentModuleTypeID",DbType.Int32,contentModuleTypeID);
				Database.AddInParameter(command,"PositionID",DbType.Int32,positionID);
				Database.AddInParameter(command,"OrderNumber",DbType.Int32,orderNumber);
				Database.AddInParameter(command,"IsFullWidth",DbType.Boolean,isFullWidth);
				Database.AddInParameter(command,"ItemsNumber",DbType.Int32,itemsNumber);
				Database.AddInParameter(command,"ItemsPerPage",DbType.Int32,itemsPerPage);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
                Database.AddInParameter(command, "Title", DbType.String, Title);
                Database.AddInParameter(command, "LanguageID", DbType.Int32, LanguageID);
                Database.AddInParameter(command, "HomePageGroupID", DbType.Int32, HomePageGroupID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 homePageID = Convert.ToInt32(Database.GetParameterValue(command, "HomePageID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for HomePage using Stored Procedure
		/// and return DbCommand of the HomePage
		/// </summary>
		public DbCommand InsertNewHomePageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewHomePage");

				Database.AddInParameter(command,"SectionID",DbType.Int32,"SectionID",DataRowVersion.Current);
				Database.AddInParameter(command,"ContentModuleTypeID",DbType.Int32,"ContentModuleTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"PositionID",DbType.Int32,"PositionID",DataRowVersion.Current);
				Database.AddInParameter(command,"OrderNumber",DbType.Int32,"OrderNumber",DataRowVersion.Current);
				Database.AddInParameter(command,"IsFullWidth",DbType.Boolean,"IsFullWidth",DataRowVersion.Current);
				Database.AddInParameter(command,"ItemsNumber",DbType.Int32,"ItemsNumber",DataRowVersion.Current);
				Database.AddInParameter(command,"ItemsPerPage",DbType.Int32,"ItemsPerPage",DataRowVersion.Current);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into HomePage using Stored Procedure
		/// </summary>
        public bool UpdateHomePage(int sectionID, int contentModuleTypeID, int positionID, int orderNumber, bool isFullWidth, int itemsNumber, int itemsPerPage, bool isActive, string Title, int LanguageID, int HomePageGroupID, int oldhomePageID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateHomePage");

		    		Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
		    		Database.AddInParameter(command,"ContentModuleTypeID",DbType.Int32,contentModuleTypeID);
		    		Database.AddInParameter(command,"PositionID",DbType.Int32,positionID);
		    		Database.AddInParameter(command,"OrderNumber",DbType.Int32,orderNumber);
		    		Database.AddInParameter(command,"IsFullWidth",DbType.Boolean,isFullWidth);
		    		Database.AddInParameter(command,"ItemsNumber",DbType.Int32,itemsNumber);
		    		Database.AddInParameter(command,"ItemsPerPage",DbType.Int32,itemsPerPage);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
                    Database.AddInParameter(command, "Title", DbType.String, Title);
                    Database.AddInParameter(command, "LanguageID", DbType.Int32, LanguageID);
                    Database.AddInParameter(command, "HomePageGroupID", DbType.Int32, HomePageGroupID);
				Database.AddInParameter(command,"oldHomePageID",DbType.Int32,oldhomePageID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into HomePage using Stored Procedure By Transaction
		/// </summary>
        public bool UpdateHomePage(int sectionID, int contentModuleTypeID, int positionID, int orderNumber, bool isFullWidth, int itemsNumber, int itemsPerPage, bool isActive, string Title, int LanguageID, int HomePageGroupID, int oldhomePageID, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateHomePage");

		    		Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
		    		Database.AddInParameter(command,"ContentModuleTypeID",DbType.Int32,contentModuleTypeID);
		    		Database.AddInParameter(command,"PositionID",DbType.Int32,positionID);
		    		Database.AddInParameter(command,"OrderNumber",DbType.Int32,orderNumber);
		    		Database.AddInParameter(command,"IsFullWidth",DbType.Boolean,isFullWidth);
		    		Database.AddInParameter(command,"ItemsNumber",DbType.Int32,itemsNumber);
		    		Database.AddInParameter(command,"ItemsPerPage",DbType.Int32,itemsPerPage);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
                    Database.AddInParameter(command, "Title", DbType.String, Title);
                    Database.AddInParameter(command, "LanguageID", DbType.Int32, LanguageID);
                    Database.AddInParameter(command, "HomePageGroupID", DbType.Int32, HomePageGroupID);
				Database.AddInParameter(command,"oldHomePageID",DbType.Int32,oldhomePageID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from HomePage using Stored Procedure
		/// </summary>
		public DbCommand UpdateHomePageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateHomePage");

		    		Database.AddInParameter(command,"SectionID",DbType.Int32,"SectionID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ContentModuleTypeID",DbType.Int32,"ContentModuleTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PositionID",DbType.Int32,"PositionID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"OrderNumber",DbType.Int32,"OrderNumber",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsFullWidth",DbType.Boolean,"IsFullWidth",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ItemsNumber",DbType.Int32,"ItemsNumber",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ItemsPerPage",DbType.Int32,"ItemsPerPage",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
				Database.AddInParameter(command,"oldHomePageID",DbType.Int32,"HomePageID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From HomePage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteHomePage( int homePageID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteHomePage");
			Database.AddInParameter(command,"HomePageID",DbType.Int32,homePageID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From HomePage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteHomePageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteHomePage");
				Database.AddInParameter(command,"HomePageID",DbType.Int32,"HomePageID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table HomePage using Stored Procedure
		/// and return number of rows effected of the HomePage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"HomePage",InsertNewHomePageCommand(),UpdateHomePageCommand(),DeleteHomePageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table HomePage using Stored Procedure
		/// and return number of rows effected of the HomePage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"HomePage",InsertNewHomePageCommand(),UpdateHomePageCommand(),DeleteHomePageCommand(), transaction);
          return rowsAffected;
		}


	}
}
