using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for MenuEntityType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the MenuEntityType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class MenuEntityTypeDAC : DataAccessComponent
	{
		#region Constructors
        public MenuEntityTypeDAC() : base("", "ContentManagement.MenuEntityType") { }
		public MenuEntityTypeDAC(string connectionString): base(connectionString){}
		public MenuEntityTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityType using Stored Procedure
		/// and return a DataTable containing all MenuEntityType Data
		/// </summary>
		public DataTable GetAllMenuEntityType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityType";
         string query = " select * from GetAllMenuEntityType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MenuEntityType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityType using Stored Procedure
		/// and return a DataTable containing all MenuEntityType Data using a Transaction
		/// </summary>
		public DataTable GetAllMenuEntityType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityType";
         string query = " select * from GetAllMenuEntityType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MenuEntityType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityType using Stored Procedure
		/// and return a DataTable containing all MenuEntityType Data
		/// </summary>
		public DataTable GetAllMenuEntityType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllMenuEntityType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MenuEntityType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MenuEntityType using Stored Procedure
		/// and return a DataTable containing all MenuEntityType Data using a Transaction
		/// </summary>
		public DataTable GetAllMenuEntityType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MenuEntityType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllMenuEntityType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MenuEntityType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MenuEntityType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMenuEntityType( int menuEntityTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMenuEntityType");
				    Database.AddInParameter(command,"MenuEntityTypeId",DbType.Int32,menuEntityTypeId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MenuEntityType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMenuEntityType( int menuEntityTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMenuEntityType");
				    Database.AddInParameter(command,"MenuEntityTypeId",DbType.Int32,menuEntityTypeId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MenuEntityType using Stored Procedure
		/// and return the auto number primary key of MenuEntityType inserted row
		/// </summary>
		public bool InsertNewMenuEntityType( ref int menuEntityTypeId,  string name)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMenuEntityType");
				Database.AddOutParameter(command,"MenuEntityTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 menuEntityTypeId = Convert.ToInt32(Database.GetParameterValue(command, "MenuEntityTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MenuEntityType using Stored Procedure
		/// and return the auto number primary key of MenuEntityType inserted row using Transaction
		/// </summary>
		public bool InsertNewMenuEntityType( ref int menuEntityTypeId,  string name,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMenuEntityType");
				Database.AddOutParameter(command,"MenuEntityTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 menuEntityTypeId = Convert.ToInt32(Database.GetParameterValue(command, "MenuEntityTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for MenuEntityType using Stored Procedure
		/// and return DbCommand of the MenuEntityType
		/// </summary>
		public DbCommand InsertNewMenuEntityTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMenuEntityType");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MenuEntityType using Stored Procedure
		/// </summary>
		public bool UpdateMenuEntityType( string name, int oldmenuEntityTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMenuEntityType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldMenuEntityTypeId",DbType.Int32,oldmenuEntityTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MenuEntityType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateMenuEntityType( string name, int oldmenuEntityTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMenuEntityType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldMenuEntityTypeId",DbType.Int32,oldmenuEntityTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from MenuEntityType using Stored Procedure
		/// </summary>
		public DbCommand UpdateMenuEntityTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMenuEntityType");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"oldMenuEntityTypeId",DbType.Int32,"MenuEntityTypeId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From MenuEntityType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteMenuEntityType( int menuEntityTypeId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteMenuEntityType");
			Database.AddInParameter(command,"MenuEntityTypeId",DbType.Int32,menuEntityTypeId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From MenuEntityType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteMenuEntityTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteMenuEntityType");
				Database.AddInParameter(command,"MenuEntityTypeId",DbType.Int32,"MenuEntityTypeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MenuEntityType using Stored Procedure
		/// and return number of rows effected of the MenuEntityType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MenuEntityType",InsertNewMenuEntityTypeCommand(),UpdateMenuEntityTypeCommand(),DeleteMenuEntityTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MenuEntityType using Stored Procedure
		/// and return number of rows effected of the MenuEntityType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MenuEntityType",InsertNewMenuEntityTypeCommand(),UpdateMenuEntityTypeCommand(),DeleteMenuEntityTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
