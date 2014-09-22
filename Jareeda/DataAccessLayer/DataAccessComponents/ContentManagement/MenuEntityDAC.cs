using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for MenuEntity table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the MenuEntity table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class MenuEntityDAC : DataAccessComponent
	{
		#region Constructors
        public MenuEntityDAC() : base("", "ContentManagement.MenuEntity") { }
		public MenuEntityDAC(string connectionString): base(connectionString){}
		public MenuEntityDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntity using Stored Procedure
		/// and return a DataTable containing all MenuEntity Data
		/// </summary>
		public DataTable GetAllMenuEntity()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntity";
         string query = " select * from GetAllMenuEntity";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MenuEntity"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntity using Stored Procedure
		/// and return a DataTable containing all MenuEntity Data using a Transaction
		/// </summary>
		public DataTable GetAllMenuEntity(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntity";
         string query = " select * from GetAllMenuEntity";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MenuEntity"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntity using Stored Procedure
		/// and return a DataTable containing all MenuEntity Data
		/// </summary>
		public DataTable GetAllMenuEntity(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntity";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllMenuEntity" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MenuEntity"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntity using Stored Procedure
		/// and return a DataTable containing all MenuEntity Data using a Transaction
		/// </summary>
		public DataTable GetAllMenuEntity(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntity";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllMenuEntity" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MenuEntity"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MenuEntity using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMenuEntity( int menuEntityId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMenuEntity");
				    Database.AddInParameter(command,"MenuEntityId",DbType.Int32,menuEntityId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MenuEntity using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMenuEntity( int menuEntityId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMenuEntity");
				    Database.AddInParameter(command,"MenuEntityId",DbType.Int32,menuEntityId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MenuEntity using Stored Procedure
		/// and return the auto number primary key of MenuEntity inserted row
		/// </summary>
		public bool InsertNewMenuEntity( ref int menuEntityId,  string menuName,  int contentEntityId,string displayType)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMenuEntity");
				Database.AddOutParameter(command,"MenuEntityId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"MenuName",DbType.String,menuName);
                if(contentEntityId == 0)
				    Database.AddInParameter(command,"ContentEntityId",DbType.Int32,DBNull.Value);
                else
                    Database.AddInParameter(command, "ContentEntityId", DbType.Int32, contentEntityId);
                Database.AddInParameter(command, "DisplayType", DbType.String, displayType);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 menuEntityId = Convert.ToInt32(Database.GetParameterValue(command, "MenuEntityId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MenuEntity using Stored Procedure
		/// and return the auto number primary key of MenuEntity inserted row using Transaction
		/// </summary>
        public bool InsertNewMenuEntity(ref int menuEntityId, string menuName, int contentEntityId, string displayType, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMenuEntity");
				Database.AddOutParameter(command,"MenuEntityId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"MenuName",DbType.String,menuName);
                if (contentEntityId == 0)
                    Database.AddInParameter(command, "ContentEntityId", DbType.Int32, DBNull.Value);
                else
                    Database.AddInParameter(command, "ContentEntityId", DbType.Int32, contentEntityId);
                Database.AddInParameter(command, "DisplayType", DbType.String, displayType);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 menuEntityId = Convert.ToInt32(Database.GetParameterValue(command, "MenuEntityId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for MenuEntity using Stored Procedure
		/// and return DbCommand of the MenuEntity
		/// </summary>
		public DbCommand InsertNewMenuEntityCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMenuEntity");

				Database.AddInParameter(command,"MenuName",DbType.String,"MenuName",DataRowVersion.Current);
				Database.AddInParameter(command,"ContentEntityId",DbType.Int32,"ContentEntityId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MenuEntity using Stored Procedure
		/// </summary>
        public bool UpdateMenuEntity(string menuName, int contentEntityId, string displayType, int oldmenuEntityId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMenuEntity");

		    		Database.AddInParameter(command,"MenuName",DbType.String,menuName);
                    if (contentEntityId == 0)
                        Database.AddInParameter(command, "ContentEntityId", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "ContentEntityId", DbType.Int32, contentEntityId);
                    Database.AddInParameter(command, "DisplayType", DbType.String, displayType);
				Database.AddInParameter(command,"oldMenuEntityId",DbType.Int32,oldmenuEntityId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MenuEntity using Stored Procedure By Transaction
		/// </summary>
        public bool UpdateMenuEntity(string menuName, int contentEntityId, string displayType, int oldmenuEntityId, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMenuEntity");

		    		Database.AddInParameter(command,"MenuName",DbType.String,menuName);
                    if (contentEntityId == 0)
                        Database.AddInParameter(command, "ContentEntityId", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "ContentEntityId", DbType.Int32, contentEntityId);
                    Database.AddInParameter(command, "DisplayType", DbType.String, displayType);
				Database.AddInParameter(command,"oldMenuEntityId",DbType.Int32,oldmenuEntityId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from MenuEntity using Stored Procedure
		/// </summary>
		public DbCommand UpdateMenuEntityCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMenuEntity");

		    		Database.AddInParameter(command,"MenuName",DbType.String,"MenuName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ContentEntityId",DbType.Int32,"ContentEntityId",DataRowVersion.Current);
				Database.AddInParameter(command,"oldMenuEntityId",DbType.Int32,"MenuEntityId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From MenuEntity using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteMenuEntity( int menuEntityId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteMenuEntity");
			Database.AddInParameter(command,"MenuEntityId",DbType.Int32,menuEntityId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From MenuEntity Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteMenuEntityCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteMenuEntity");
				Database.AddInParameter(command,"MenuEntityId",DbType.Int32,"MenuEntityId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MenuEntity using Stored Procedure
		/// and return number of rows effected of the MenuEntity
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MenuEntity",InsertNewMenuEntityCommand(),UpdateMenuEntityCommand(),DeleteMenuEntityCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MenuEntity using Stored Procedure
		/// and return number of rows effected of the MenuEntity
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MenuEntity",InsertNewMenuEntityCommand(),UpdateMenuEntityCommand(),DeleteMenuEntityCommand(), transaction);
          return rowsAffected;
		}


	}
}
