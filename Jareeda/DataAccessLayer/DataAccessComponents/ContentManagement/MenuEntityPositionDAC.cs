using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for MenuEntityPosition table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the MenuEntityPosition table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class MenuEntityPositionDAC : DataAccessComponent
	{
		#region Constructors
        public MenuEntityPositionDAC() : base("", "ContentManagement.MenuEntityPosition") { }
		public MenuEntityPositionDAC(string connectionString): base(connectionString){}
		public MenuEntityPositionDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityPosition using Stored Procedure
		/// and return a DataTable containing all MenuEntityPosition Data
		/// </summary>
		public DataTable GetAllMenuEntityPosition()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityPosition";
         string query = " select * from GetAllMenuEntityPosition";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MenuEntityPosition"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityPosition using Stored Procedure
		/// and return a DataTable containing all MenuEntityPosition Data using a Transaction
		/// </summary>
		public DataTable GetAllMenuEntityPosition(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityPosition";
         string query = " select * from GetAllMenuEntityPosition";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MenuEntityPosition"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityPosition using Stored Procedure
		/// and return a DataTable containing all MenuEntityPosition Data
		/// </summary>
		public DataTable GetAllMenuEntityPosition(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityPosition";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllMenuEntityPosition" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MenuEntityPosition"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityPosition using Stored Procedure
		/// and return a DataTable containing all MenuEntityPosition Data using a Transaction
		/// </summary>
		public DataTable GetAllMenuEntityPosition(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityPosition";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllMenuEntityPosition" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MenuEntityPosition"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MenuEntityPosition using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMenuEntityPosition( int menuEntityPositionID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMenuEntityPosition");
				    Database.AddInParameter(command,"MenuEntityPositionID",DbType.Int32,menuEntityPositionID);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MenuEntityPosition using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMenuEntityPosition( int menuEntityPositionID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMenuEntityPosition");
				    Database.AddInParameter(command,"MenuEntityPositionID",DbType.Int32,menuEntityPositionID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MenuEntityPosition using Stored Procedure
		/// and return the auto number primary key of MenuEntityPosition inserted row
		/// </summary>
		public bool InsertNewMenuEntityPosition( int menuEntityPositionID,  string name)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMenuEntityPosition");
				Database.AddInParameter(command,"MenuEntityPositionID",DbType.Int32,menuEntityPositionID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MenuEntityPosition using Stored Procedure
		/// and return the auto number primary key of MenuEntityPosition inserted row using Transaction
		/// </summary>
		public bool InsertNewMenuEntityPosition( int menuEntityPositionID,  string name,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMenuEntityPosition");
				Database.AddInParameter(command,"MenuEntityPositionID",DbType.Int32,menuEntityPositionID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for MenuEntityPosition using Stored Procedure
		/// and return DbCommand of the MenuEntityPosition
		/// </summary>
		public DbCommand InsertNewMenuEntityPositionCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMenuEntityPosition");
				Database.AddInParameter(command,"MenuEntityPositionID",DbType.Int32,"MenuEntityPositionID",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MenuEntityPosition using Stored Procedure
		/// </summary>
		public bool UpdateMenuEntityPosition( int menuEntityPositionID, string name, int oldmenuEntityPositionID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMenuEntityPosition");
		    		Database.AddInParameter(command,"MenuEntityPositionID",DbType.Int32,menuEntityPositionID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldMenuEntityPositionID",DbType.Int32,oldmenuEntityPositionID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MenuEntityPosition using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateMenuEntityPosition( int menuEntityPositionID, string name, int oldmenuEntityPositionID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMenuEntityPosition");
		    		Database.AddInParameter(command,"MenuEntityPositionID",DbType.Int32,menuEntityPositionID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldMenuEntityPositionID",DbType.Int32,oldmenuEntityPositionID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from MenuEntityPosition using Stored Procedure
		/// </summary>
		public DbCommand UpdateMenuEntityPositionCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMenuEntityPosition");
		    		Database.AddInParameter(command,"MenuEntityPositionID",DbType.Int32,"MenuEntityPositionID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"oldMenuEntityPositionID",DbType.Int32,"MenuEntityPositionID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From MenuEntityPosition using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteMenuEntityPosition( int menuEntityPositionID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteMenuEntityPosition");
			Database.AddInParameter(command,"MenuEntityPositionID",DbType.Int32,menuEntityPositionID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From MenuEntityPosition Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteMenuEntityPositionCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteMenuEntityPosition");
				Database.AddInParameter(command,"MenuEntityPositionID",DbType.Int32,"MenuEntityPositionID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MenuEntityPosition using Stored Procedure
		/// and return number of rows effected of the MenuEntityPosition
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MenuEntityPosition",InsertNewMenuEntityPositionCommand(),UpdateMenuEntityPositionCommand(),DeleteMenuEntityPositionCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MenuEntityPosition using Stored Procedure
		/// and return number of rows effected of the MenuEntityPosition
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MenuEntityPosition",InsertNewMenuEntityPositionCommand(),UpdateMenuEntityPositionCommand(),DeleteMenuEntityPositionCommand(), transaction);
          return rowsAffected;
		}


	}
}
