using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.HumanResources
{
	/// <summary>
	/// This is a Data Access Class  for EmployeeVacationPermit table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the EmployeeVacationPermit table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class EmployeeVacationPermitDAC : DataAccessComponent
	{
		#region Constructors
        public EmployeeVacationPermitDAC() : base("", "HumanResources.EmployeeVacationPermit") { }
		public EmployeeVacationPermitDAC(string connectionString): base(connectionString){}
		public EmployeeVacationPermitDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeVacationPermit using Stored Procedure
		/// and return a DataTable containing all EmployeeVacationPermit Data
		/// </summary>
		public DataTable GetAllEmployeeVacationPermit()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeVacationPermit";
         string query = " select * from GetAllEmployeeVacationPermit";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmployeeVacationPermit"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeVacationPermit using Stored Procedure
		/// and return a DataTable containing all EmployeeVacationPermit Data using a Transaction
		/// </summary>
		public DataTable GetAllEmployeeVacationPermit(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeVacationPermit";
         string query = " select * from GetAllEmployeeVacationPermit";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmployeeVacationPermit"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeVacationPermit using Stored Procedure
		/// and return a DataTable containing all EmployeeVacationPermit Data
		/// </summary>
		public DataTable GetAllEmployeeVacationPermit(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeVacationPermit";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllEmployeeVacationPermit" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmployeeVacationPermit"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeVacationPermit using Stored Procedure
		/// and return a DataTable containing all EmployeeVacationPermit Data using a Transaction
		/// </summary>
		public DataTable GetAllEmployeeVacationPermit(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeVacationPermit";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllEmployeeVacationPermit" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmployeeVacationPermit"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmployeeVacationPermit using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmployeeVacationPermit( int employeeVacationPermitID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmployeeVacationPermit");
				    Database.AddInParameter(command,"EmployeeVacationPermitID",DbType.Int32,employeeVacationPermitID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmployeeVacationPermit using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmployeeVacationPermit( int employeeVacationPermitID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmployeeVacationPermit");
				    Database.AddInParameter(command,"EmployeeVacationPermitID",DbType.Int32,employeeVacationPermitID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmployeeVacationPermit using Stored Procedure
		/// and return the auto number primary key of EmployeeVacationPermit inserted row
		/// </summary>
		public bool InsertNewEmployeeVacationPermit( ref int employeeVacationPermitID,  string name,  int vacationTypeID,  int permitNumberinDays,  bool isMonthly,  bool isYearly)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployeeVacationPermit");
				Database.AddOutParameter(command,"EmployeeVacationPermitID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"VacationTypeID",DbType.Int32,vacationTypeID);
				Database.AddInParameter(command,"PermitNumberinDays",DbType.Int32,permitNumberinDays);
				Database.AddInParameter(command,"IsMonthly",DbType.Boolean,isMonthly);
				Database.AddInParameter(command,"IsYearly",DbType.Boolean,isYearly);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 employeeVacationPermitID = Convert.ToInt32(Database.GetParameterValue(command, "EmployeeVacationPermitID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmployeeVacationPermit using Stored Procedure
		/// and return the auto number primary key of EmployeeVacationPermit inserted row using Transaction
		/// </summary>
		public bool InsertNewEmployeeVacationPermit( ref int employeeVacationPermitID,  string name,  int vacationTypeID,  int permitNumberinDays,  bool isMonthly,  bool isYearly,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployeeVacationPermit");
				Database.AddOutParameter(command,"EmployeeVacationPermitID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"VacationTypeID",DbType.Int32,vacationTypeID);
				Database.AddInParameter(command,"PermitNumberinDays",DbType.Int32,permitNumberinDays);
				Database.AddInParameter(command,"IsMonthly",DbType.Boolean,isMonthly);
				Database.AddInParameter(command,"IsYearly",DbType.Boolean,isYearly);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 employeeVacationPermitID = Convert.ToInt32(Database.GetParameterValue(command, "EmployeeVacationPermitID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for EmployeeVacationPermit using Stored Procedure
		/// and return DbCommand of the EmployeeVacationPermit
		/// </summary>
		public DbCommand InsertNewEmployeeVacationPermitCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployeeVacationPermit");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"VacationTypeID",DbType.Int32,"VacationTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"PermitNumberinDays",DbType.Int32,"PermitNumberinDays",DataRowVersion.Current);
				Database.AddInParameter(command,"IsMonthly",DbType.Boolean,"IsMonthly",DataRowVersion.Current);
				Database.AddInParameter(command,"IsYearly",DbType.Boolean,"IsYearly",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmployeeVacationPermit using Stored Procedure
		/// </summary>
		public bool UpdateEmployeeVacationPermit( string name, int vacationTypeID, int permitNumberinDays, bool isMonthly, bool isYearly, int oldemployeeVacationPermitID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployeeVacationPermit");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"VacationTypeID",DbType.Int32,vacationTypeID);
		    		Database.AddInParameter(command,"PermitNumberinDays",DbType.Int32,permitNumberinDays);
		    		Database.AddInParameter(command,"IsMonthly",DbType.Boolean,isMonthly);
		    		Database.AddInParameter(command,"IsYearly",DbType.Boolean,isYearly);
				Database.AddInParameter(command,"oldEmployeeVacationPermitID",DbType.Int32,oldemployeeVacationPermitID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmployeeVacationPermit using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateEmployeeVacationPermit( string name, int vacationTypeID, int permitNumberinDays, bool isMonthly, bool isYearly, int oldemployeeVacationPermitID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployeeVacationPermit");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"VacationTypeID",DbType.Int32,vacationTypeID);
		    		Database.AddInParameter(command,"PermitNumberinDays",DbType.Int32,permitNumberinDays);
		    		Database.AddInParameter(command,"IsMonthly",DbType.Boolean,isMonthly);
		    		Database.AddInParameter(command,"IsYearly",DbType.Boolean,isYearly);
				Database.AddInParameter(command,"oldEmployeeVacationPermitID",DbType.Int32,oldemployeeVacationPermitID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from EmployeeVacationPermit using Stored Procedure
		/// </summary>
		public DbCommand UpdateEmployeeVacationPermitCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployeeVacationPermit");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"VacationTypeID",DbType.Int32,"VacationTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PermitNumberinDays",DbType.Int32,"PermitNumberinDays",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsMonthly",DbType.Boolean,"IsMonthly",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsYearly",DbType.Boolean,"IsYearly",DataRowVersion.Current);
				Database.AddInParameter(command,"oldEmployeeVacationPermitID",DbType.Int32,"EmployeeVacationPermitID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From EmployeeVacationPermit using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteEmployeeVacationPermit( int employeeVacationPermitID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteEmployeeVacationPermit");
			Database.AddInParameter(command,"EmployeeVacationPermitID",DbType.Int32,employeeVacationPermitID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From EmployeeVacationPermit Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteEmployeeVacationPermitCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteEmployeeVacationPermit");
				Database.AddInParameter(command,"EmployeeVacationPermitID",DbType.Int32,"EmployeeVacationPermitID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmployeeVacationPermit using Stored Procedure
		/// and return number of rows effected of the EmployeeVacationPermit
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmployeeVacationPermit",InsertNewEmployeeVacationPermitCommand(),UpdateEmployeeVacationPermitCommand(),DeleteEmployeeVacationPermitCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmployeeVacationPermit using Stored Procedure
		/// and return number of rows effected of the EmployeeVacationPermit
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmployeeVacationPermit",InsertNewEmployeeVacationPermitCommand(),UpdateEmployeeVacationPermitCommand(),DeleteEmployeeVacationPermitCommand(), transaction);
          return rowsAffected;
		}


	}
}
