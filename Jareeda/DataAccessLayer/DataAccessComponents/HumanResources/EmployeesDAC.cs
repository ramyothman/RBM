using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.HumanResources
{
	/// <summary>
	/// This is a Data Access Class  for Employees table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Employees table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class EmployeesDAC : DataAccessComponent
	{
		#region Constructors
        public EmployeesDAC() : base("", "HumanResources.Employees") { }
		public EmployeesDAC(string connectionString): base(connectionString){}
		public EmployeesDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Employees using Stored Procedure
		/// and return a DataTable containing all Employees Data
		/// </summary>
		public DataTable GetAllEmployees()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Employees";
         string query = " select * from GetAllEmployees";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Employees"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Employees using Stored Procedure
		/// and return a DataTable containing all Employees Data using a Transaction
		/// </summary>
		public DataTable GetAllEmployees(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Employees";
         string query = " select * from GetAllEmployees";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Employees"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Employees using Stored Procedure
		/// and return a DataTable containing all Employees Data
		/// </summary>
		public DataTable GetAllEmployees(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Employees";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllEmployees" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Employees"];

		}

        public DataTable GetAllEmployeesView()
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ViewEmployees";
            string query = " select * from ViewEmployees";
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["ViewEmployees"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Employees using Stored Procedure
        /// and return a DataTable containing all Employees Data
        /// </summary>
        public DataTable GetAllEmployeesView(string where)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ViewEmployees";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = " select * from ViewEmployees" + whereClause;
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["ViewEmployees"];

        }



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Employees using Stored Procedure
		/// and return a DataTable containing all Employees Data using a Transaction
		/// </summary>
		public DataTable GetAllEmployees(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Employees";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllEmployees" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Employees"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Employees using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmployees( int employeeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmployees");
				    Database.AddInParameter(command,"EmployeeId",DbType.Int32,employeeId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Employees using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmployees( int employeeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmployees");
				    Database.AddInParameter(command,"EmployeeId",DbType.Int32,employeeId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Employees using Stored Procedure
		/// and return the auto number primary key of Employees inserted row
		/// </summary>
		public bool InsertNewEmployees( int employeeId,  string employeeNumber,  int departmentId,  int divisionId,  string formalSiteUrl,  string nationalIdNumber,  string nationalIdType,  int managerId,  DateTime birthDate,  string maritalStatus,  string gender,  DateTime hireDate,  bool salariedFlag,  short vacationHours,  short sickLeaveHours,  bool currentFlag,  Guid rowGuid,  DateTime modifiedDate,  string position)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployees");
				Database.AddInParameter(command,"EmployeeId",DbType.Int32,employeeId);
				Database.AddInParameter(command,"EmployeeNumber",DbType.String,employeeNumber);
				Database.AddInParameter(command,"DepartmentId",DbType.Int32,departmentId);
                if(divisionId == 0)
				    Database.AddInParameter(command,"DivisionId",DbType.Int32,DBNull.Value);
                else
                    Database.AddInParameter(command, "DivisionId", DbType.Int32, divisionId);
				Database.AddInParameter(command,"FormalSiteUrl",DbType.String,formalSiteUrl);
				Database.AddInParameter(command,"NationalIdNumber",DbType.String,nationalIdNumber);
				Database.AddInParameter(command,"NationalIdType",DbType.String,nationalIdType);
            if(managerId == 0)
				Database.AddInParameter(command,"ManagerId",DbType.Int32,DBNull.Value);
            else
                Database.AddInParameter(command, "ManagerId", DbType.Int32, managerId);
            if(birthDate == DateTime.MinValue)
				Database.AddInParameter(command,"BirthDate",DbType.DateTime,DBNull.Value);
            else
                Database.AddInParameter(command, "BirthDate", DbType.DateTime, birthDate);
				Database.AddInParameter(command,"MaritalStatus",DbType.String,maritalStatus);
				Database.AddInParameter(command,"Gender",DbType.String,gender);
            if(hireDate == DateTime.MinValue)
				Database.AddInParameter(command,"HireDate",DbType.DateTime,DBNull.Value);
            else
                Database.AddInParameter(command, "HireDate", DbType.DateTime, hireDate);
				Database.AddInParameter(command,"SalariedFlag",DbType.Boolean,salariedFlag);
				Database.AddInParameter(command,"VacationHours",DbType.Int16,vacationHours);
				Database.AddInParameter(command,"SickLeaveHours",DbType.Int16,sickLeaveHours);
				Database.AddInParameter(command,"CurrentFlag",DbType.Boolean,currentFlag);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,Guid.NewGuid());
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"Position",DbType.String,position);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Employees using Stored Procedure
		/// and return the auto number primary key of Employees inserted row using Transaction
		/// </summary>
		public bool InsertNewEmployees( int employeeId,  string employeeNumber,  int departmentId,  int divisionId,  string formalSiteUrl,  string nationalIdNumber,  string nationalIdType,  int managerId,  DateTime birthDate,  string maritalStatus,  string gender,  DateTime hireDate,  bool salariedFlag,  short vacationHours,  short sickLeaveHours,  bool currentFlag,  Guid rowGuid,  DateTime modifiedDate,  string position,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployees");
				Database.AddInParameter(command,"EmployeeId",DbType.Int32,employeeId);
				Database.AddInParameter(command,"EmployeeNumber",DbType.String,employeeNumber);
				Database.AddInParameter(command,"DepartmentId",DbType.Int32,departmentId);
                if (divisionId == 0)
                    Database.AddInParameter(command, "DivisionId", DbType.Int32, DBNull.Value);
                else
                    Database.AddInParameter(command, "DivisionId", DbType.Int32, divisionId);
				Database.AddInParameter(command,"FormalSiteUrl",DbType.String,formalSiteUrl);
				Database.AddInParameter(command,"NationalIdNumber",DbType.String,nationalIdNumber);
				Database.AddInParameter(command,"NationalIdType",DbType.String,nationalIdType);
                if (managerId == 0)
                    Database.AddInParameter(command, "ManagerId", DbType.Int32, DBNull.Value);
                else
                    Database.AddInParameter(command, "ManagerId", DbType.Int32, managerId);
                if (birthDate == DateTime.MinValue)
                    Database.AddInParameter(command, "BirthDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "BirthDate", DbType.DateTime, birthDate);
                Database.AddInParameter(command, "MaritalStatus", DbType.String, maritalStatus);
                Database.AddInParameter(command, "Gender", DbType.String, gender);
                if (hireDate == DateTime.MinValue)
                    Database.AddInParameter(command, "HireDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "HireDate", DbType.DateTime, hireDate);
				Database.AddInParameter(command,"SalariedFlag",DbType.Boolean,salariedFlag);
				Database.AddInParameter(command,"VacationHours",DbType.Int16,vacationHours);
				Database.AddInParameter(command,"SickLeaveHours",DbType.Int16,sickLeaveHours);
				Database.AddInParameter(command,"CurrentFlag",DbType.Boolean,currentFlag);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,Guid.NewGuid());
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"Position",DbType.String,position);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Employees using Stored Procedure
		/// and return DbCommand of the Employees
		/// </summary>
		public DbCommand InsertNewEmployeesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployees");
				Database.AddInParameter(command,"EmployeeId",DbType.Int32,"EmployeeId",DataRowVersion.Current);
				Database.AddInParameter(command,"EmployeeNumber",DbType.String,"EmployeeNumber",DataRowVersion.Current);
				Database.AddInParameter(command,"DepartmentId",DbType.Int32,"DepartmentId",DataRowVersion.Current);
				Database.AddInParameter(command,"DivisionId",DbType.Int32,"DivisionId",DataRowVersion.Current);
				Database.AddInParameter(command,"FormalSiteUrl",DbType.String,"FormalSiteUrl",DataRowVersion.Current);
				Database.AddInParameter(command,"NationalIdNumber",DbType.String,"NationalIdNumber",DataRowVersion.Current);
				Database.AddInParameter(command,"NationalIdType",DbType.String,"NationalIdType",DataRowVersion.Current);
				Database.AddInParameter(command,"ManagerId",DbType.Int32,"ManagerId",DataRowVersion.Current);
				Database.AddInParameter(command,"BirthDate",DbType.DateTime,"BirthDate",DataRowVersion.Current);
				Database.AddInParameter(command,"MaritalStatus",DbType.String,"MaritalStatus",DataRowVersion.Current);
				Database.AddInParameter(command,"Gender",DbType.String,"Gender",DataRowVersion.Current);
				Database.AddInParameter(command,"HireDate",DbType.DateTime,"HireDate",DataRowVersion.Current);
				Database.AddInParameter(command,"SalariedFlag",DbType.Boolean,"SalariedFlag",DataRowVersion.Current);
				Database.AddInParameter(command,"VacationHours",DbType.Int16,"VacationHours",DataRowVersion.Current);
				Database.AddInParameter(command,"SickLeaveHours",DbType.Int16,"SickLeaveHours",DataRowVersion.Current);
				Database.AddInParameter(command,"CurrentFlag",DbType.Boolean,"CurrentFlag",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"Position",DbType.String,"Position",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Employees using Stored Procedure
		/// </summary>
		public bool UpdateEmployees( int employeeId, string employeeNumber, int departmentId, int divisionId, string formalSiteUrl, string nationalIdNumber, string nationalIdType, int managerId, DateTime birthDate, string maritalStatus, string gender, DateTime hireDate, bool salariedFlag, short vacationHours, short sickLeaveHours, bool currentFlag, Guid rowGuid, DateTime modifiedDate, string position, int oldemployeeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployees");
		    		Database.AddInParameter(command,"EmployeeId",DbType.Int32,employeeId);
		    		Database.AddInParameter(command,"EmployeeNumber",DbType.String,employeeNumber);
		    		Database.AddInParameter(command,"DepartmentId",DbType.Int32,departmentId);
                    if (divisionId == 0)
                        Database.AddInParameter(command, "DivisionId", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "DivisionId", DbType.Int32, divisionId);
		    		Database.AddInParameter(command,"FormalSiteUrl",DbType.String,formalSiteUrl);
		    		Database.AddInParameter(command,"NationalIdNumber",DbType.String,nationalIdNumber);
		    		Database.AddInParameter(command,"NationalIdType",DbType.String,nationalIdType);
                    if (managerId == 0)
                        Database.AddInParameter(command, "ManagerId", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "ManagerId", DbType.Int32, managerId);
                    if (birthDate == DateTime.MinValue)
                        Database.AddInParameter(command, "BirthDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "BirthDate", DbType.DateTime, birthDate);
                    Database.AddInParameter(command, "MaritalStatus", DbType.String, maritalStatus);
                    Database.AddInParameter(command, "Gender", DbType.String, gender);
                    if (hireDate == DateTime.MinValue)
                        Database.AddInParameter(command, "HireDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "HireDate", DbType.DateTime, hireDate);
		    		Database.AddInParameter(command,"SalariedFlag",DbType.Boolean,salariedFlag);
		    		Database.AddInParameter(command,"VacationHours",DbType.Int16,vacationHours);
		    		Database.AddInParameter(command,"SickLeaveHours",DbType.Int16,sickLeaveHours);
		    		Database.AddInParameter(command,"CurrentFlag",DbType.Boolean,currentFlag);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
		    		Database.AddInParameter(command,"Position",DbType.String,position);
				Database.AddInParameter(command,"oldEmployeeId",DbType.Int32,oldemployeeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Employees using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateEmployees( int employeeId, string employeeNumber, int departmentId, int divisionId, string formalSiteUrl, string nationalIdNumber, string nationalIdType, int managerId, DateTime birthDate, string maritalStatus, string gender, DateTime hireDate, bool salariedFlag, short vacationHours, short sickLeaveHours, bool currentFlag, Guid rowGuid, DateTime modifiedDate, string position, int oldemployeeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployees");
		    		Database.AddInParameter(command,"EmployeeId",DbType.Int32,employeeId);
		    		Database.AddInParameter(command,"EmployeeNumber",DbType.String,employeeNumber);
		    		Database.AddInParameter(command,"DepartmentId",DbType.Int32,departmentId);
                    if (divisionId == 0)
                        Database.AddInParameter(command, "DivisionId", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "DivisionId", DbType.Int32, divisionId);
		    		Database.AddInParameter(command,"FormalSiteUrl",DbType.String,formalSiteUrl);
		    		Database.AddInParameter(command,"NationalIdNumber",DbType.String,nationalIdNumber);
		    		Database.AddInParameter(command,"NationalIdType",DbType.String,nationalIdType);
                    if (managerId == 0)
                        Database.AddInParameter(command, "ManagerId", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "ManagerId", DbType.Int32, managerId);
                    if (birthDate == DateTime.MinValue)
                        Database.AddInParameter(command, "BirthDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "BirthDate", DbType.DateTime, birthDate);
                    Database.AddInParameter(command, "MaritalStatus", DbType.String, maritalStatus);
                    Database.AddInParameter(command, "Gender", DbType.String, gender);
                    if (hireDate == DateTime.MinValue)
                        Database.AddInParameter(command, "HireDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "HireDate", DbType.DateTime, hireDate);
		    		Database.AddInParameter(command,"SalariedFlag",DbType.Boolean,salariedFlag);
		    		Database.AddInParameter(command,"VacationHours",DbType.Int16,vacationHours);
		    		Database.AddInParameter(command,"SickLeaveHours",DbType.Int16,sickLeaveHours);
		    		Database.AddInParameter(command,"CurrentFlag",DbType.Boolean,currentFlag);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
		    		Database.AddInParameter(command,"Position",DbType.String,position);
				Database.AddInParameter(command,"oldEmployeeId",DbType.Int32,oldemployeeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Employees using Stored Procedure
		/// </summary>
		public DbCommand UpdateEmployeesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployees");
		    		Database.AddInParameter(command,"EmployeeId",DbType.Int32,"EmployeeId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EmployeeNumber",DbType.String,"EmployeeNumber",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DepartmentId",DbType.Int32,"DepartmentId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DivisionId",DbType.Int32,"DivisionId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FormalSiteUrl",DbType.String,"FormalSiteUrl",DataRowVersion.Current);
		    		Database.AddInParameter(command,"NationalIdNumber",DbType.String,"NationalIdNumber",DataRowVersion.Current);
		    		Database.AddInParameter(command,"NationalIdType",DbType.String,"NationalIdType",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ManagerId",DbType.Int32,"ManagerId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"BirthDate",DbType.DateTime,"BirthDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"MaritalStatus",DbType.String,"MaritalStatus",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Gender",DbType.String,"Gender",DataRowVersion.Current);
		    		Database.AddInParameter(command,"HireDate",DbType.DateTime,"HireDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SalariedFlag",DbType.Boolean,"SalariedFlag",DataRowVersion.Current);
		    		Database.AddInParameter(command,"VacationHours",DbType.Int16,"VacationHours",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SickLeaveHours",DbType.Int16,"SickLeaveHours",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CurrentFlag",DbType.Boolean,"CurrentFlag",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Position",DbType.String,"Position",DataRowVersion.Current);
				Database.AddInParameter(command,"oldEmployeeId",DbType.Int32,"EmployeeId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Employees using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteEmployees( int employeeId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteEmployees");
			Database.AddInParameter(command,"EmployeeId",DbType.Int32,employeeId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Employees Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteEmployeesCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteEmployees");
				Database.AddInParameter(command,"EmployeeId",DbType.Int32,"EmployeeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Employees using Stored Procedure
		/// and return number of rows effected of the Employees
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Employees",InsertNewEmployeesCommand(),UpdateEmployeesCommand(),DeleteEmployeesCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Employees using Stored Procedure
		/// and return number of rows effected of the Employees
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Employees",InsertNewEmployeesCommand(),UpdateEmployeesCommand(),DeleteEmployeesCommand(), transaction);
          return rowsAffected;
		}


	}
}
