using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.HumanResources
{
	/// <summary>
	/// This is a Data Access Class  for DepartmentLanguages table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the DepartmentLanguages table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class DepartmentLanguagesDAC : DataAccessComponent
	{
		#region Constructors
        public DepartmentLanguagesDAC() : base("", "HumanResources.DepartmentLanguages") { }
		public DepartmentLanguagesDAC(string connectionString): base(connectionString){}
		public DepartmentLanguagesDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all DepartmentLanguages using Stored Procedure
		/// and return a DataTable containing all DepartmentLanguages Data
		/// </summary>
		public DataTable GetAllDepartmentLanguages()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "DepartmentLanguages";
         string query = " select * from GetAllDepartmentLanguages";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["DepartmentLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all DepartmentLanguages using Stored Procedure
		/// and return a DataTable containing all DepartmentLanguages Data using a Transaction
		/// </summary>
		public DataTable GetAllDepartmentLanguages(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "DepartmentLanguages";
         string query = " select * from GetAllDepartmentLanguages";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["DepartmentLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all DepartmentLanguages using Stored Procedure
		/// and return a DataTable containing all DepartmentLanguages Data
		/// </summary>
		public DataTable GetAllDepartmentLanguages(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "DepartmentLanguages";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllDepartmentLanguages" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["DepartmentLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all DepartmentLanguages using Stored Procedure
		/// and return a DataTable containing all DepartmentLanguages Data using a Transaction
		/// </summary>
		public DataTable GetAllDepartmentLanguages(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "DepartmentLanguages";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllDepartmentLanguages" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["DepartmentLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From DepartmentLanguages using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDDepartmentLanguages( int departmentLanguagesId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDDepartmentLanguages");
				    Database.AddInParameter(command,"DepartmentLanguagesId",DbType.Int32,departmentLanguagesId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From DepartmentLanguages using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDDepartmentLanguages( int departmentLanguagesId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDDepartmentLanguages");
				    Database.AddInParameter(command,"DepartmentLanguagesId",DbType.Int32,departmentLanguagesId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into DepartmentLanguages using Stored Procedure
		/// and return the auto number primary key of DepartmentLanguages inserted row
		/// </summary>
		public bool InsertNewDepartmentLanguages( ref int departmentLanguagesId,  int departmentId,  int languageId,  string departmentName,  string departmentDescription,  string addressLine1,  string addressLine2)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewDepartmentLanguages");
				Database.AddOutParameter(command,"DepartmentLanguagesId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"DepartmentId",DbType.Int32,departmentId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"DepartmentName",DbType.String,departmentName);
				Database.AddInParameter(command,"DepartmentDescription",DbType.String,departmentDescription);
				Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
				Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 departmentLanguagesId = Convert.ToInt32(Database.GetParameterValue(command, "DepartmentLanguagesId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into DepartmentLanguages using Stored Procedure
		/// and return the auto number primary key of DepartmentLanguages inserted row using Transaction
		/// </summary>
		public bool InsertNewDepartmentLanguages( ref int departmentLanguagesId,  int departmentId,  int languageId,  string departmentName,  string departmentDescription,  string addressLine1,  string addressLine2,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewDepartmentLanguages");
				Database.AddOutParameter(command,"DepartmentLanguagesId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"DepartmentId",DbType.Int32,departmentId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"DepartmentName",DbType.String,departmentName);
				Database.AddInParameter(command,"DepartmentDescription",DbType.String,departmentDescription);
				Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
				Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 departmentLanguagesId = Convert.ToInt32(Database.GetParameterValue(command, "DepartmentLanguagesId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for DepartmentLanguages using Stored Procedure
		/// and return DbCommand of the DepartmentLanguages
		/// </summary>
		public DbCommand InsertNewDepartmentLanguagesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewDepartmentLanguages");

				Database.AddInParameter(command,"DepartmentId",DbType.Int32,"DepartmentId",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
				Database.AddInParameter(command,"DepartmentName",DbType.String,"DepartmentName",DataRowVersion.Current);
				Database.AddInParameter(command,"DepartmentDescription",DbType.String,"DepartmentDescription",DataRowVersion.Current);
				Database.AddInParameter(command,"AddressLine1",DbType.String,"AddressLine1",DataRowVersion.Current);
				Database.AddInParameter(command,"AddressLine2",DbType.String,"AddressLine2",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into DepartmentLanguages using Stored Procedure
		/// </summary>
		public bool UpdateDepartmentLanguages( int departmentId, int languageId, string departmentName, string departmentDescription, string addressLine1, string addressLine2, int olddepartmentLanguagesId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateDepartmentLanguages");

		    		Database.AddInParameter(command,"DepartmentId",DbType.Int32,departmentId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"DepartmentName",DbType.String,departmentName);
		    		Database.AddInParameter(command,"DepartmentDescription",DbType.String,departmentDescription);
		    		Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
		    		Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
				Database.AddInParameter(command,"oldDepartmentLanguagesId",DbType.Int32,olddepartmentLanguagesId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into DepartmentLanguages using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateDepartmentLanguages( int departmentId, int languageId, string departmentName, string departmentDescription, string addressLine1, string addressLine2, int olddepartmentLanguagesId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateDepartmentLanguages");

		    		Database.AddInParameter(command,"DepartmentId",DbType.Int32,departmentId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"DepartmentName",DbType.String,departmentName);
		    		Database.AddInParameter(command,"DepartmentDescription",DbType.String,departmentDescription);
		    		Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
		    		Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
				Database.AddInParameter(command,"oldDepartmentLanguagesId",DbType.Int32,olddepartmentLanguagesId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from DepartmentLanguages using Stored Procedure
		/// </summary>
		public DbCommand UpdateDepartmentLanguagesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateDepartmentLanguages");

		    		Database.AddInParameter(command,"DepartmentId",DbType.Int32,"DepartmentId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DepartmentName",DbType.String,"DepartmentName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DepartmentDescription",DbType.String,"DepartmentDescription",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AddressLine1",DbType.String,"AddressLine1",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AddressLine2",DbType.String,"AddressLine2",DataRowVersion.Current);
				Database.AddInParameter(command,"oldDepartmentLanguagesId",DbType.Int32,"DepartmentLanguagesId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From DepartmentLanguages using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteDepartmentLanguages( int departmentLanguagesId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteDepartmentLanguages");
			Database.AddInParameter(command,"DepartmentLanguagesId",DbType.Int32,departmentLanguagesId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From DepartmentLanguages Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteDepartmentLanguagesCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteDepartmentLanguages");
				Database.AddInParameter(command,"DepartmentLanguagesId",DbType.Int32,"DepartmentLanguagesId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table DepartmentLanguages using Stored Procedure
		/// and return number of rows effected of the DepartmentLanguages
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"DepartmentLanguages",InsertNewDepartmentLanguagesCommand(),UpdateDepartmentLanguagesCommand(),DeleteDepartmentLanguagesCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table DepartmentLanguages using Stored Procedure
		/// and return number of rows effected of the DepartmentLanguages
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"DepartmentLanguages",InsertNewDepartmentLanguagesCommand(),UpdateDepartmentLanguagesCommand(),DeleteDepartmentLanguagesCommand(), transaction);
          return rowsAffected;
		}


	}
}
