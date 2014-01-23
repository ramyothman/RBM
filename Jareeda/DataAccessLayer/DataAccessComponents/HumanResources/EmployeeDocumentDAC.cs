using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.HumanResources
{
	/// <summary>
	/// This is a Data Access Class  for EmployeeDocument table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the EmployeeDocument table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class EmployeeDocumentDAC : DataAccessComponent
	{
		#region Constructors
		public EmployeeDocumentDAC() : base("", "HumanResources.EmployeeDocument") { }
		public EmployeeDocumentDAC(string connectionString): base(connectionString){}
		public EmployeeDocumentDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeDocument using Stored Procedure
		/// and return a DataTable containing all EmployeeDocument Data
		/// </summary>
		public DataTable GetAllEmployeeDocument()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeDocument";
         string query = " select * from GetAllEmployeeDocument";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmployeeDocument"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeDocument using Stored Procedure
		/// and return a DataTable containing all EmployeeDocument Data using a Transaction
		/// </summary>
		public DataTable GetAllEmployeeDocument(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeDocument";
         string query = " select * from GetAllEmployeeDocument";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmployeeDocument"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeDocument using Stored Procedure
		/// and return a DataTable containing all EmployeeDocument Data
		/// </summary>
		public DataTable GetAllEmployeeDocument(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeDocument";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllEmployeeDocument" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmployeeDocument"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeDocument using Stored Procedure
		/// and return a DataTable containing all EmployeeDocument Data using a Transaction
		/// </summary>
		public DataTable GetAllEmployeeDocument(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeDocument";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllEmployeeDocument" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmployeeDocument"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmployeeDocument using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmployeeDocument( int employeeDocumentID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmployeeDocument");
				    Database.AddInParameter(command,"EmployeeDocumentID",DbType.Int32,employeeDocumentID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmployeeDocument using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmployeeDocument( int employeeDocumentID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmployeeDocument");
				    Database.AddInParameter(command,"EmployeeDocumentID",DbType.Int32,employeeDocumentID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmployeeDocument using Stored Procedure
		/// and return the auto number primary key of EmployeeDocument inserted row
		/// </summary>
		public bool InsertNewEmployeeDocument( ref int employeeDocumentID,  int employeeDocumentTypeID,  int employeeID,  string name,  string path)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployeeDocument");
				Database.AddOutParameter(command,"EmployeeDocumentID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"EmployeeDocumentTypeID",DbType.Int32,employeeDocumentTypeID);
				Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Path",DbType.String,path);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 employeeDocumentID = Convert.ToInt32(Database.GetParameterValue(command, "EmployeeDocumentID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmployeeDocument using Stored Procedure
		/// and return the auto number primary key of EmployeeDocument inserted row using Transaction
		/// </summary>
		public bool InsertNewEmployeeDocument( ref int employeeDocumentID,  int employeeDocumentTypeID,  int employeeID,  string name,  string path,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployeeDocument");
				Database.AddOutParameter(command,"EmployeeDocumentID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"EmployeeDocumentTypeID",DbType.Int32,employeeDocumentTypeID);
				Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Path",DbType.String,path);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 employeeDocumentID = Convert.ToInt32(Database.GetParameterValue(command, "EmployeeDocumentID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for EmployeeDocument using Stored Procedure
		/// and return DbCommand of the EmployeeDocument
		/// </summary>
		public DbCommand InsertNewEmployeeDocumentCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployeeDocument");

				Database.AddInParameter(command,"EmployeeDocumentTypeID",DbType.Int32,"EmployeeDocumentTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"EmployeeID",DbType.Int32,"EmployeeID",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"Path",DbType.String,"Path",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmployeeDocument using Stored Procedure
		/// </summary>
		public bool UpdateEmployeeDocument( int employeeDocumentTypeID, int employeeID, string name, string path, int oldemployeeDocumentID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployeeDocument");

		    		Database.AddInParameter(command,"EmployeeDocumentTypeID",DbType.Int32,employeeDocumentTypeID);
		    		Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Path",DbType.String,path);
				Database.AddInParameter(command,"oldEmployeeDocumentID",DbType.Int32,oldemployeeDocumentID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmployeeDocument using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateEmployeeDocument( int employeeDocumentTypeID, int employeeID, string name, string path, int oldemployeeDocumentID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployeeDocument");

		    		Database.AddInParameter(command,"EmployeeDocumentTypeID",DbType.Int32,employeeDocumentTypeID);
		    		Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Path",DbType.String,path);
				Database.AddInParameter(command,"oldEmployeeDocumentID",DbType.Int32,oldemployeeDocumentID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from EmployeeDocument using Stored Procedure
		/// </summary>
		public DbCommand UpdateEmployeeDocumentCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployeeDocument");

		    		Database.AddInParameter(command,"EmployeeDocumentTypeID",DbType.Int32,"EmployeeDocumentTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EmployeeID",DbType.Int32,"EmployeeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Path",DbType.String,"Path",DataRowVersion.Current);
				Database.AddInParameter(command,"oldEmployeeDocumentID",DbType.Int32,"EmployeeDocumentID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From EmployeeDocument using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteEmployeeDocument( int employeeDocumentID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteEmployeeDocument");
			Database.AddInParameter(command,"EmployeeDocumentID",DbType.Int32,employeeDocumentID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From EmployeeDocument Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteEmployeeDocumentCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteEmployeeDocument");
				Database.AddInParameter(command,"EmployeeDocumentID",DbType.Int32,"EmployeeDocumentID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmployeeDocument using Stored Procedure
		/// and return number of rows effected of the EmployeeDocument
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmployeeDocument",InsertNewEmployeeDocumentCommand(),UpdateEmployeeDocumentCommand(),DeleteEmployeeDocumentCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmployeeDocument using Stored Procedure
		/// and return number of rows effected of the EmployeeDocument
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmployeeDocument",InsertNewEmployeeDocumentCommand(),UpdateEmployeeDocumentCommand(),DeleteEmployeeDocumentCommand(), transaction);
          return rowsAffected;
		}


	}
}
