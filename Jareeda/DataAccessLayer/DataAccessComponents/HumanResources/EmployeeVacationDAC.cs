using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.HumanResources
{
	/// <summary>
	/// This is a Data Access Class  for EmployeeVacation table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the EmployeeVacation table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class EmployeeVacationDAC : DataAccessComponent
	{
		#region Constructors
        public EmployeeVacationDAC() : base("", "HumanResources.EmployeeVacation") { }
		public EmployeeVacationDAC(string connectionString): base(connectionString){}
		public EmployeeVacationDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeVacation using Stored Procedure
		/// and return a DataTable containing all EmployeeVacation Data
		/// </summary>
		public DataTable GetAllEmployeeVacation()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeVacation";
         string query = " select * from GetAllEmployeeVacation";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmployeeVacation"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeVacation using Stored Procedure
		/// and return a DataTable containing all EmployeeVacation Data using a Transaction
		/// </summary>
		public DataTable GetAllEmployeeVacation(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeVacation";
         string query = " select * from GetAllEmployeeVacation";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmployeeVacation"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeVacation using Stored Procedure
		/// and return a DataTable containing all EmployeeVacation Data
		/// </summary>
		public DataTable GetAllEmployeeVacation(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeVacation";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllEmployeeVacation" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmployeeVacation"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeVacation using Stored Procedure
		/// and return a DataTable containing all EmployeeVacation Data using a Transaction
		/// </summary>
		public DataTable GetAllEmployeeVacation(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeVacation";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllEmployeeVacation" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmployeeVacation"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmployeeVacation using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmployeeVacation( int employeeVacationID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmployeeVacation");
				    Database.AddInParameter(command,"EmployeeVacationID",DbType.Int32,employeeVacationID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmployeeVacation using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmployeeVacation( int employeeVacationID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmployeeVacation");
				    Database.AddInParameter(command,"EmployeeVacationID",DbType.Int32,employeeVacationID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmployeeVacation using Stored Procedure
		/// and return the auto number primary key of EmployeeVacation inserted row
		/// </summary>
		public bool InsertNewEmployeeVacation( ref int employeeVacationID,  int employeeID,  int vacationTypeID,  DateTime startDate,  DateTime endDate,  int durationInDays,  DateTime requestDate,  DateTime approvalDate,  int approvedBy)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployeeVacation");
				Database.AddOutParameter(command,"EmployeeVacationID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
				Database.AddInParameter(command,"VacationTypeID",DbType.Int32,vacationTypeID);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				Database.AddInParameter(command,"DurationInDays",DbType.Int32,durationInDays);
				Database.AddInParameter(command,"RequestDate",DbType.DateTime,requestDate);
				Database.AddInParameter(command,"ApprovalDate",DbType.DateTime,approvalDate);
				Database.AddInParameter(command,"ApprovedBy",DbType.Int32,approvedBy);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 employeeVacationID = Convert.ToInt32(Database.GetParameterValue(command, "EmployeeVacationID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmployeeVacation using Stored Procedure
		/// and return the auto number primary key of EmployeeVacation inserted row using Transaction
		/// </summary>
		public bool InsertNewEmployeeVacation( ref int employeeVacationID,  int employeeID,  int vacationTypeID,  DateTime startDate,  DateTime endDate,  int durationInDays,  DateTime requestDate,  DateTime approvalDate,  int approvedBy,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployeeVacation");
				Database.AddOutParameter(command,"EmployeeVacationID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
				Database.AddInParameter(command,"VacationTypeID",DbType.Int32,vacationTypeID);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				Database.AddInParameter(command,"DurationInDays",DbType.Int32,durationInDays);
				Database.AddInParameter(command,"RequestDate",DbType.DateTime,requestDate);
				Database.AddInParameter(command,"ApprovalDate",DbType.DateTime,approvalDate);
				Database.AddInParameter(command,"ApprovedBy",DbType.Int32,approvedBy);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 employeeVacationID = Convert.ToInt32(Database.GetParameterValue(command, "EmployeeVacationID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for EmployeeVacation using Stored Procedure
		/// and return DbCommand of the EmployeeVacation
		/// </summary>
		public DbCommand InsertNewEmployeeVacationCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployeeVacation");

				Database.AddInParameter(command,"EmployeeID",DbType.Int32,"EmployeeID",DataRowVersion.Current);
				Database.AddInParameter(command,"VacationTypeID",DbType.Int32,"VacationTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,"StartDate",DataRowVersion.Current);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,"EndDate",DataRowVersion.Current);
				Database.AddInParameter(command,"DurationInDays",DbType.Int32,"DurationInDays",DataRowVersion.Current);
				Database.AddInParameter(command,"RequestDate",DbType.DateTime,"RequestDate",DataRowVersion.Current);
				Database.AddInParameter(command,"ApprovalDate",DbType.DateTime,"ApprovalDate",DataRowVersion.Current);
				Database.AddInParameter(command,"ApprovedBy",DbType.Int32,"ApprovedBy",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmployeeVacation using Stored Procedure
		/// </summary>
		public bool UpdateEmployeeVacation( int employeeID, int vacationTypeID, DateTime startDate, DateTime endDate, int durationInDays, DateTime requestDate, DateTime approvalDate, int approvedBy, int oldemployeeVacationID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployeeVacation");

		    		Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
		    		Database.AddInParameter(command,"VacationTypeID",DbType.Int32,vacationTypeID);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
		    		Database.AddInParameter(command,"DurationInDays",DbType.Int32,durationInDays);
		    		Database.AddInParameter(command,"RequestDate",DbType.DateTime,requestDate);
		    		Database.AddInParameter(command,"ApprovalDate",DbType.DateTime,approvalDate);
		    		Database.AddInParameter(command,"ApprovedBy",DbType.Int32,approvedBy);
				Database.AddInParameter(command,"oldEmployeeVacationID",DbType.Int32,oldemployeeVacationID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmployeeVacation using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateEmployeeVacation( int employeeID, int vacationTypeID, DateTime startDate, DateTime endDate, int durationInDays, DateTime requestDate, DateTime approvalDate, int approvedBy, int oldemployeeVacationID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployeeVacation");

		    		Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
		    		Database.AddInParameter(command,"VacationTypeID",DbType.Int32,vacationTypeID);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
		    		Database.AddInParameter(command,"DurationInDays",DbType.Int32,durationInDays);
		    		Database.AddInParameter(command,"RequestDate",DbType.DateTime,requestDate);
		    		Database.AddInParameter(command,"ApprovalDate",DbType.DateTime,approvalDate);
		    		Database.AddInParameter(command,"ApprovedBy",DbType.Int32,approvedBy);
				Database.AddInParameter(command,"oldEmployeeVacationID",DbType.Int32,oldemployeeVacationID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from EmployeeVacation using Stored Procedure
		/// </summary>
		public DbCommand UpdateEmployeeVacationCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployeeVacation");

		    		Database.AddInParameter(command,"EmployeeID",DbType.Int32,"EmployeeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"VacationTypeID",DbType.Int32,"VacationTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,"StartDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,"EndDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DurationInDays",DbType.Int32,"DurationInDays",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RequestDate",DbType.DateTime,"RequestDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ApprovalDate",DbType.DateTime,"ApprovalDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ApprovedBy",DbType.Int32,"ApprovedBy",DataRowVersion.Current);
				Database.AddInParameter(command,"oldEmployeeVacationID",DbType.Int32,"EmployeeVacationID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From EmployeeVacation using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteEmployeeVacation( int employeeVacationID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteEmployeeVacation");
			Database.AddInParameter(command,"EmployeeVacationID",DbType.Int32,employeeVacationID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From EmployeeVacation Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteEmployeeVacationCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteEmployeeVacation");
				Database.AddInParameter(command,"EmployeeVacationID",DbType.Int32,"EmployeeVacationID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmployeeVacation using Stored Procedure
		/// and return number of rows effected of the EmployeeVacation
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmployeeVacation",InsertNewEmployeeVacationCommand(),UpdateEmployeeVacationCommand(),DeleteEmployeeVacationCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmployeeVacation using Stored Procedure
		/// and return number of rows effected of the EmployeeVacation
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmployeeVacation",InsertNewEmployeeVacationCommand(),UpdateEmployeeVacationCommand(),DeleteEmployeeVacationCommand(), transaction);
          return rowsAffected;
		}


	}
}
