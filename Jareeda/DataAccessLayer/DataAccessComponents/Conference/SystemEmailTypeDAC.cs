using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for SystemEmailType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the SystemEmailType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SystemEmailTypeDAC : DataAccessComponent
	{
		#region Constructors
        public SystemEmailTypeDAC() : base("", "Conference.SystemEmailType") { }
		public SystemEmailTypeDAC(string connectionString): base(connectionString){}
		public SystemEmailTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemEmailType using Stored Procedure
		/// and return a DataTable containing all SystemEmailType Data
		/// </summary>
		public DataTable GetAllSystemEmailType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemEmailType";
         string query = " select * from GetAllSystemEmailType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SystemEmailType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemEmailType using Stored Procedure
		/// and return a DataTable containing all SystemEmailType Data using a Transaction
		/// </summary>
		public DataTable GetAllSystemEmailType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemEmailType";
         string query = " select * from GetAllSystemEmailType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SystemEmailType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemEmailType using Stored Procedure
		/// and return a DataTable containing all SystemEmailType Data
		/// </summary>
		public DataTable GetAllSystemEmailType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemEmailType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSystemEmailType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SystemEmailType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SystemEmailType using Stored Procedure
		/// and return a DataTable containing all SystemEmailType Data using a Transaction
		/// </summary>
		public DataTable GetAllSystemEmailType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SystemEmailType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSystemEmailType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SystemEmailType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SystemEmailType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSystemEmailType( int systemEmailTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSystemEmailType");
				    Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,systemEmailTypeID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SystemEmailType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSystemEmailType( int systemEmailTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSystemEmailType");
				    Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,systemEmailTypeID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SystemEmailType using Stored Procedure
		/// and return the auto number primary key of SystemEmailType inserted row
		/// </summary>
		public bool InsertNewSystemEmailType( int systemEmailTypeID,  string name)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSystemEmailType");
				Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,systemEmailTypeID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SystemEmailType using Stored Procedure
		/// and return the auto number primary key of SystemEmailType inserted row using Transaction
		/// </summary>
		public bool InsertNewSystemEmailType( int systemEmailTypeID,  string name,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSystemEmailType");
				Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,systemEmailTypeID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for SystemEmailType using Stored Procedure
		/// and return DbCommand of the SystemEmailType
		/// </summary>
		public DbCommand InsertNewSystemEmailTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSystemEmailType");
				Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,"SystemEmailTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SystemEmailType using Stored Procedure
		/// </summary>
		public bool UpdateSystemEmailType( int systemEmailTypeID, string name, int oldsystemEmailTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSystemEmailType");
		    		Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,systemEmailTypeID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldSystemEmailTypeID",DbType.Int32,oldsystemEmailTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SystemEmailType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSystemEmailType( int systemEmailTypeID, string name, int oldsystemEmailTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSystemEmailType");
		    		Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,systemEmailTypeID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldSystemEmailTypeID",DbType.Int32,oldsystemEmailTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from SystemEmailType using Stored Procedure
		/// </summary>
		public DbCommand UpdateSystemEmailTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSystemEmailType");
		    		Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,"SystemEmailTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSystemEmailTypeID",DbType.Int32,"SystemEmailTypeID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From SystemEmailType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSystemEmailType( int systemEmailTypeID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSystemEmailType");
			Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,systemEmailTypeID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From SystemEmailType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSystemEmailTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSystemEmailType");
				Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,"SystemEmailTypeID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SystemEmailType using Stored Procedure
		/// and return number of rows effected of the SystemEmailType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SystemEmailType",InsertNewSystemEmailTypeCommand(),UpdateSystemEmailTypeCommand(),DeleteSystemEmailTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SystemEmailType using Stored Procedure
		/// and return number of rows effected of the SystemEmailType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SystemEmailType",InsertNewSystemEmailTypeCommand(),UpdateSystemEmailTypeCommand(),DeleteSystemEmailTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
