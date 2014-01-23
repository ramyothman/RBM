using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for MenuEntityItem table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the MenuEntityItem table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class MenuEntityItemDAC : DataAccessComponent
	{
		#region Constructors
        public MenuEntityItemDAC() : base("", "ContentManagement.MenuEntityItem") { }
		public MenuEntityItemDAC(string connectionString): base(connectionString){}
		public MenuEntityItemDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityItem using Stored Procedure
		/// and return a DataTable containing all MenuEntityItem Data
		/// </summary>
		public DataTable GetAllMenuEntityItem()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityItem";
         string query = " select * from GetAllMenuEntityItem";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MenuEntityItem"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityItem using Stored Procedure
		/// and return a DataTable containing all MenuEntityItem Data using a Transaction
		/// </summary>
		public DataTable GetAllMenuEntityItem(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityItem";
         string query = " select * from GetAllMenuEntityItem";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MenuEntityItem"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityItem using Stored Procedure
		/// and return a DataTable containing all MenuEntityItem Data
		/// </summary>
		public DataTable GetAllMenuEntityItem(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityItem";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllMenuEntityItem" + whereClause + " Order By DisplayOrder";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MenuEntityItem"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityItem using Stored Procedure
		/// and return a DataTable containing all MenuEntityItem Data using a Transaction
		/// </summary>
		public DataTable GetAllMenuEntityItem(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityItem";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where ;
         string query = String.Format(" select * from GetAllMenuEntityItem {0} Order By DisplayOrder", whereClause);
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MenuEntityItem"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MenuEntityItem using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMenuEntityItem( int menuEntityItemId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMenuEntityItem");
				    Database.AddInParameter(command,"MenuEntityItemId",DbType.Int32,menuEntityItemId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MenuEntityItem using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMenuEntityItem( int menuEntityItemId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMenuEntityItem");
				    Database.AddInParameter(command,"MenuEntityItemId",DbType.Int32,menuEntityItemId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MenuEntityItem using Stored Procedure
		/// and return the auto number primary key of MenuEntityItem inserted row
		/// </summary>
        public bool InsertNewMenuEntityItem(ref int menuEntityItemId, int menuEntityParentId, string name, string pagePath, int contentEntityId, bool displayAlways, bool isActive, string iconPath, int displayOrder, DateTime modifiedDate, int menuEntityTypeId, int menuEntityId, int LanguageID, int MenuEntityPositionID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMenuEntityItem");
				Database.AddOutParameter(command,"MenuEntityItemId",DbType.Int32,Int32.MaxValue);
            if(menuEntityParentId == 0)
				Database.AddInParameter(command,"MenuEntityParentId",DbType.Int32,DBNull.Value);
            else
                Database.AddInParameter(command, "MenuEntityParentId", DbType.Int32, menuEntityParentId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"PagePath",DbType.String,pagePath);
            if(contentEntityId == 0)
				Database.AddInParameter(command,"ContentEntityId",DbType.Int32,DBNull.Value);
            else
                Database.AddInParameter(command, "ContentEntityId", DbType.Int32, contentEntityId);
				Database.AddInParameter(command,"DisplayAlways",DbType.Boolean,displayAlways);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"IconPath",DbType.String,iconPath);
				Database.AddInParameter(command,"DisplayOrder",DbType.Int32,displayOrder);
            if(modifiedDate == DateTime.MinValue)
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,DateTime.Now);
            else
                Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, modifiedDate);
            if(menuEntityTypeId == 0)
				Database.AddInParameter(command,"MenuEntityTypeId",DbType.Int32,DBNull.Value);
            else
                Database.AddInParameter(command, "MenuEntityTypeId", DbType.Int32, menuEntityTypeId);
            if(menuEntityId == 0)
				Database.AddInParameter(command,"MenuEntityId",DbType.Int32,DBNull.Value);
            else
                Database.AddInParameter(command, "MenuEntityId", DbType.Int32, menuEntityId);
            if (LanguageID == 0)
                Database.AddInParameter(command, "LanguageID", DbType.Int32, DBNull.Value);
            else
                Database.AddInParameter(command, "LanguageID", DbType.Int32, LanguageID);
            if (MenuEntityPositionID == 0)
                Database.AddInParameter(command, "MenuEntityPositionID", DbType.Int32, DBNull.Value);
            else
                Database.AddInParameter(command, "MenuEntityPositionID", DbType.Int32, MenuEntityPositionID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 menuEntityItemId = Convert.ToInt32(Database.GetParameterValue(command, "MenuEntityItemId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MenuEntityItem using Stored Procedure
		/// and return the auto number primary key of MenuEntityItem inserted row using Transaction
		/// </summary>
        public bool InsertNewMenuEntityItem(ref int menuEntityItemId, int menuEntityParentId, string name, string pagePath, int contentEntityId, bool displayAlways, bool isActive, string iconPath, int displayOrder, DateTime modifiedDate, int menuEntityTypeId, int menuEntityId, int LanguageID, int MenuEntityPositionID, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMenuEntityItem");
                 Database.AddOutParameter(command, "MenuEntityItemId", DbType.Int32, Int32.MaxValue);
                 if (menuEntityParentId == 0)
                     Database.AddInParameter(command, "MenuEntityParentId", DbType.Int32, DBNull.Value);
                 else
                     Database.AddInParameter(command, "MenuEntityParentId", DbType.Int32, menuEntityParentId);
                 Database.AddInParameter(command, "Name", DbType.String, name);
                 Database.AddInParameter(command, "PagePath", DbType.String, pagePath);
                 if (contentEntityId == 0)
                     Database.AddInParameter(command, "ContentEntityId", DbType.Int32, DBNull.Value);
                 else
                     Database.AddInParameter(command, "ContentEntityId", DbType.Int32, contentEntityId);
                 Database.AddInParameter(command, "DisplayAlways", DbType.Boolean, displayAlways);
                 Database.AddInParameter(command, "IsActive", DbType.Boolean, isActive);
                 Database.AddInParameter(command, "IconPath", DbType.String, iconPath);
                 Database.AddInParameter(command, "DisplayOrder", DbType.Int32, displayOrder);
                 if (modifiedDate == DateTime.MinValue)
                     Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, DateTime.Now);
                 else
                     Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, modifiedDate);
                 Database.AddInParameter(command, "MenuEntityTypeId", DbType.Int32, menuEntityTypeId);
                 Database.AddInParameter(command, "MenuEntityId", DbType.Int32, menuEntityId);
                 if (LanguageID == 0)
                     Database.AddInParameter(command, "LanguageID", DbType.Int32, DBNull.Value);
                 else
                     Database.AddInParameter(command, "LanguageID", DbType.Int32, LanguageID);
                 if (MenuEntityPositionID == 0)
                     Database.AddInParameter(command, "MenuEntityPositionID", DbType.Int32, DBNull.Value);
                 else
                     Database.AddInParameter(command, "MenuEntityPositionID", DbType.Int32, MenuEntityPositionID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 menuEntityItemId = Convert.ToInt32(Database.GetParameterValue(command, "MenuEntityItemId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for MenuEntityItem using Stored Procedure
		/// and return DbCommand of the MenuEntityItem
		/// </summary>
		public DbCommand InsertNewMenuEntityItemCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMenuEntityItem");

				Database.AddInParameter(command,"MenuEntityParentId",DbType.Int32,"MenuEntityParentId",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"PagePath",DbType.String,"PagePath",DataRowVersion.Current);
				Database.AddInParameter(command,"ContentEntityId",DbType.Int32,"ContentEntityId",DataRowVersion.Current);
				Database.AddInParameter(command,"DisplayAlways",DbType.Boolean,"DisplayAlways",DataRowVersion.Current);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
				Database.AddInParameter(command,"IconPath",DbType.String,"IconPath",DataRowVersion.Current);
				Database.AddInParameter(command,"DisplayOrder",DbType.Int32,"DisplayOrder",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"MenuEntityTypeId",DbType.Int32,"MenuEntityTypeId",DataRowVersion.Current);
				Database.AddInParameter(command,"MenuEntityId",DbType.Int32,"MenuEntityId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MenuEntityItem using Stored Procedure
		/// </summary>
        public bool UpdateMenuEntityItem(int menuEntityParentId, string name, string pagePath, int contentEntityId, bool displayAlways, bool isActive, string iconPath, int displayOrder, DateTime modifiedDate, int menuEntityTypeId, int menuEntityId, int LanguageID, int MenuEntityPositionID, int oldmenuEntityItemId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMenuEntityItem");

                 if (menuEntityParentId == 0)
                     Database.AddInParameter(command, "MenuEntityParentId", DbType.Int32, DBNull.Value);
                 else
                     Database.AddInParameter(command, "MenuEntityParentId", DbType.Int32, menuEntityParentId);
                 Database.AddInParameter(command, "Name", DbType.String, name);
                 Database.AddInParameter(command, "PagePath", DbType.String, pagePath);
                 if (contentEntityId == 0)
                     Database.AddInParameter(command, "ContentEntityId", DbType.Int32, DBNull.Value);
                 else
                     Database.AddInParameter(command, "ContentEntityId", DbType.Int32, contentEntityId);
                 Database.AddInParameter(command, "DisplayAlways", DbType.Boolean, displayAlways);
                 Database.AddInParameter(command, "IsActive", DbType.Boolean, isActive);
                 Database.AddInParameter(command, "IconPath", DbType.String, iconPath);
                 Database.AddInParameter(command, "DisplayOrder", DbType.Int32, displayOrder);
                 if (modifiedDate == DateTime.MinValue)
                     Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, DateTime.Now);
                 else
                     Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, modifiedDate);
                 if (menuEntityTypeId == 0)
                     Database.AddInParameter(command, "MenuEntityTypeId", DbType.Int32, DBNull.Value);
                 else
                     Database.AddInParameter(command, "MenuEntityTypeId", DbType.Int32, menuEntityTypeId);
                 if (menuEntityId == 0)
                     Database.AddInParameter(command, "MenuEntityId", DbType.Int32, DBNull.Value);
                 else
                     Database.AddInParameter(command, "MenuEntityId", DbType.Int32, menuEntityId);
                 if (LanguageID == 0)
                     Database.AddInParameter(command, "LanguageID", DbType.Int32, DBNull.Value);
                 else
                     Database.AddInParameter(command, "LanguageID", DbType.Int32, LanguageID);
                 if (MenuEntityPositionID == 0)
                     Database.AddInParameter(command, "MenuEntityPositionID", DbType.Int32, DBNull.Value);
                 else
                     Database.AddInParameter(command, "MenuEntityPositionID", DbType.Int32, MenuEntityPositionID);
				Database.AddInParameter(command,"oldMenuEntityItemId",DbType.Int32,oldmenuEntityItemId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MenuEntityItem using Stored Procedure By Transaction
		/// </summary>
        public bool UpdateMenuEntityItem(int menuEntityParentId, string name, string pagePath, int contentEntityId, bool displayAlways, bool isActive, string iconPath, int displayOrder, DateTime modifiedDate, int menuEntityTypeId, int menuEntityId, int LanguageID, int MenuEntityPositionID, int oldmenuEntityItemId, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMenuEntityItem");

                 if (menuEntityParentId == 0)
                     Database.AddInParameter(command, "MenuEntityParentId", DbType.Int32, DBNull.Value);
                 else
                     Database.AddInParameter(command, "MenuEntityParentId", DbType.Int32, menuEntityParentId);
                 Database.AddInParameter(command, "Name", DbType.String, name);
                 Database.AddInParameter(command, "PagePath", DbType.String, pagePath);
                 if (contentEntityId == 0)
                     Database.AddInParameter(command, "ContentEntityId", DbType.Int32, DBNull.Value);
                 else
                     Database.AddInParameter(command, "ContentEntityId", DbType.Int32, contentEntityId);
                 Database.AddInParameter(command, "DisplayAlways", DbType.Boolean, displayAlways);
                 Database.AddInParameter(command, "IsActive", DbType.Boolean, isActive);
                 Database.AddInParameter(command, "IconPath", DbType.String, iconPath);
                 Database.AddInParameter(command, "DisplayOrder", DbType.Int32, displayOrder);
                 if (modifiedDate == DateTime.MinValue)
                     Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, DateTime.Now);
                 else
                     Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, modifiedDate);
                 Database.AddInParameter(command, "MenuEntityTypeId", DbType.Int32, menuEntityTypeId);
                 Database.AddInParameter(command, "MenuEntityId", DbType.Int32, menuEntityId);
                 if (LanguageID == 0)
                     Database.AddInParameter(command, "LanguageID", DbType.Int32, DBNull.Value);
                 else
                     Database.AddInParameter(command, "LanguageID", DbType.Int32, LanguageID);
                 if (MenuEntityPositionID == 0)
                     Database.AddInParameter(command, "MenuEntityPositionID", DbType.Int32, DBNull.Value);
                 else
                     Database.AddInParameter(command, "MenuEntityPositionID", DbType.Int32, MenuEntityPositionID);
				Database.AddInParameter(command,"oldMenuEntityItemId",DbType.Int32,oldmenuEntityItemId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from MenuEntityItem using Stored Procedure
		/// </summary>
		public DbCommand UpdateMenuEntityItemCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMenuEntityItem");

		    		Database.AddInParameter(command,"MenuEntityParentId",DbType.Int32,"MenuEntityParentId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PagePath",DbType.String,"PagePath",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ContentEntityId",DbType.Int32,"ContentEntityId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DisplayAlways",DbType.Boolean,"DisplayAlways",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IconPath",DbType.String,"IconPath",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DisplayOrder",DbType.Int32,"DisplayOrder",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"MenuEntityTypeId",DbType.Int32,"MenuEntityTypeId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"MenuEntityId",DbType.Int32,"MenuEntityId",DataRowVersion.Current);
				Database.AddInParameter(command,"oldMenuEntityItemId",DbType.Int32,"MenuEntityItemId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From MenuEntityItem using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteMenuEntityItem( int menuEntityItemId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteMenuEntityItem");
			Database.AddInParameter(command,"MenuEntityItemId",DbType.Int32,menuEntityItemId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From MenuEntityItem Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteMenuEntityItemCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteMenuEntityItem");
				Database.AddInParameter(command,"MenuEntityItemId",DbType.Int32,"MenuEntityItemId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MenuEntityItem using Stored Procedure
		/// and return number of rows effected of the MenuEntityItem
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MenuEntityItem",InsertNewMenuEntityItemCommand(),UpdateMenuEntityItemCommand(),DeleteMenuEntityItemCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MenuEntityItem using Stored Procedure
		/// and return number of rows effected of the MenuEntityItem
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MenuEntityItem",InsertNewMenuEntityItemCommand(),UpdateMenuEntityItemCommand(),DeleteMenuEntityItemCommand(), transaction);
          return rowsAffected;
		}


	}
}
