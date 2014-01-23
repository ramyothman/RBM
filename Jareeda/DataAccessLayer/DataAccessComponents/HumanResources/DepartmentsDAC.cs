using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.HumanResources
{
	/// <summary>
	/// This is a Data Access Class  for Departments table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Departments table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class DepartmentsDAC : DataAccessComponent
	{
		#region Constructors
        public DepartmentsDAC() : base("", "HumanResources.Departments") { }
		public DepartmentsDAC(string connectionString): base(connectionString){}
		public DepartmentsDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Departments using Stored Procedure
		/// and return a DataTable containing all Departments Data
		/// </summary>
		public DataTable GetAllDepartments()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Departments";
         string query = " select * from GetAllDepartments";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Departments"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Departments using Stored Procedure
		/// and return a DataTable containing all Departments Data using a Transaction
		/// </summary>
		public DataTable GetAllDepartments(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Departments";
         string query = " select * from GetAllDepartments";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Departments"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Departments using Stored Procedure
		/// and return a DataTable containing all Departments Data
		/// </summary>
		public DataTable GetAllDepartments(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Departments";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllDepartments" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Departments"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Departments using Stored Procedure
		/// and return a DataTable containing all Departments Data using a Transaction
		/// </summary>
		public DataTable GetAllDepartments(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Departments";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllDepartments" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Departments"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Departments using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDDepartments( int departmentId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDDepartments");
				    Database.AddInParameter(command,"DepartmentId",DbType.Int32,departmentId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Departments using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDDepartments( int departmentId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDDepartments");
				    Database.AddInParameter(command,"DepartmentId",DbType.Int32,departmentId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Departments using Stored Procedure
		/// and return the auto number primary key of Departments inserted row
		/// </summary>
		public bool InsertNewDepartments( ref int departmentId,  int organizationId,  string departmentName,  string departmentDescription,  string phone1,  string phone2,  string fax1,  string fax2,  string addressLine1,  string addressLine2)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewDepartments");
				Database.AddOutParameter(command,"DepartmentId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"OrganizationId",DbType.Int32,organizationId);
				Database.AddInParameter(command,"DepartmentName",DbType.String,departmentName);
				Database.AddInParameter(command,"DepartmentDescription",DbType.String,departmentDescription);
				Database.AddInParameter(command,"Phone1",DbType.String,phone1);
				Database.AddInParameter(command,"Phone2",DbType.String,phone2);
				Database.AddInParameter(command,"Fax1",DbType.String,fax1);
				Database.AddInParameter(command,"Fax2",DbType.String,fax2);
				Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
				Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 departmentId = Convert.ToInt32(Database.GetParameterValue(command, "DepartmentId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Departments using Stored Procedure
		/// and return the auto number primary key of Departments inserted row using Transaction
		/// </summary>
		public bool InsertNewDepartments( ref int departmentId,  int organizationId,  string departmentName,  string departmentDescription,  string phone1,  string phone2,  string fax1,  string fax2,  string addressLine1,  string addressLine2,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewDepartments");
				Database.AddOutParameter(command,"DepartmentId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"OrganizationId",DbType.Int32,organizationId);
				Database.AddInParameter(command,"DepartmentName",DbType.String,departmentName);
				Database.AddInParameter(command,"DepartmentDescription",DbType.String,departmentDescription);
				Database.AddInParameter(command,"Phone1",DbType.String,phone1);
				Database.AddInParameter(command,"Phone2",DbType.String,phone2);
				Database.AddInParameter(command,"Fax1",DbType.String,fax1);
				Database.AddInParameter(command,"Fax2",DbType.String,fax2);
				Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
				Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 departmentId = Convert.ToInt32(Database.GetParameterValue(command, "DepartmentId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Departments using Stored Procedure
		/// and return DbCommand of the Departments
		/// </summary>
		public DbCommand InsertNewDepartmentsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewDepartments");

				Database.AddInParameter(command,"OrganizationId",DbType.Int32,"OrganizationId",DataRowVersion.Current);
				Database.AddInParameter(command,"DepartmentName",DbType.String,"DepartmentName",DataRowVersion.Current);
				Database.AddInParameter(command,"DepartmentDescription",DbType.String,"DepartmentDescription",DataRowVersion.Current);
				Database.AddInParameter(command,"Phone1",DbType.String,"Phone1",DataRowVersion.Current);
				Database.AddInParameter(command,"Phone2",DbType.String,"Phone2",DataRowVersion.Current);
				Database.AddInParameter(command,"Fax1",DbType.String,"Fax1",DataRowVersion.Current);
				Database.AddInParameter(command,"Fax2",DbType.String,"Fax2",DataRowVersion.Current);
				Database.AddInParameter(command,"AddressLine1",DbType.String,"AddressLine1",DataRowVersion.Current);
				Database.AddInParameter(command,"AddressLine2",DbType.String,"AddressLine2",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Departments using Stored Procedure
		/// </summary>
		public bool UpdateDepartments( int organizationId, string departmentName, string departmentDescription, string phone1, string phone2, string fax1, string fax2, string addressLine1, string addressLine2, int olddepartmentId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateDepartments");

		    		Database.AddInParameter(command,"OrganizationId",DbType.Int32,organizationId);
		    		Database.AddInParameter(command,"DepartmentName",DbType.String,departmentName);
		    		Database.AddInParameter(command,"DepartmentDescription",DbType.String,departmentDescription);
		    		Database.AddInParameter(command,"Phone1",DbType.String,phone1);
		    		Database.AddInParameter(command,"Phone2",DbType.String,phone2);
		    		Database.AddInParameter(command,"Fax1",DbType.String,fax1);
		    		Database.AddInParameter(command,"Fax2",DbType.String,fax2);
		    		Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
		    		Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
				Database.AddInParameter(command,"oldDepartmentId",DbType.Int32,olddepartmentId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Departments using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateDepartments( int organizationId, string departmentName, string departmentDescription, string phone1, string phone2, string fax1, string fax2, string addressLine1, string addressLine2, int olddepartmentId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateDepartments");

		    		Database.AddInParameter(command,"OrganizationId",DbType.Int32,organizationId);
		    		Database.AddInParameter(command,"DepartmentName",DbType.String,departmentName);
		    		Database.AddInParameter(command,"DepartmentDescription",DbType.String,departmentDescription);
		    		Database.AddInParameter(command,"Phone1",DbType.String,phone1);
		    		Database.AddInParameter(command,"Phone2",DbType.String,phone2);
		    		Database.AddInParameter(command,"Fax1",DbType.String,fax1);
		    		Database.AddInParameter(command,"Fax2",DbType.String,fax2);
		    		Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
		    		Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
				Database.AddInParameter(command,"oldDepartmentId",DbType.Int32,olddepartmentId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Departments using Stored Procedure
		/// </summary>
		public DbCommand UpdateDepartmentsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateDepartments");

		    		Database.AddInParameter(command,"OrganizationId",DbType.Int32,"OrganizationId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DepartmentName",DbType.String,"DepartmentName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DepartmentDescription",DbType.String,"DepartmentDescription",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Phone1",DbType.String,"Phone1",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Phone2",DbType.String,"Phone2",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Fax1",DbType.String,"Fax1",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Fax2",DbType.String,"Fax2",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AddressLine1",DbType.String,"AddressLine1",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AddressLine2",DbType.String,"AddressLine2",DataRowVersion.Current);
				Database.AddInParameter(command,"oldDepartmentId",DbType.Int32,"DepartmentId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Departments using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteDepartments( int departmentId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteDepartments");
			Database.AddInParameter(command,"DepartmentId",DbType.Int32,departmentId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Departments Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteDepartmentsCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteDepartments");
				Database.AddInParameter(command,"DepartmentId",DbType.Int32,"DepartmentId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Departments using Stored Procedure
		/// and return number of rows effected of the Departments
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Departments",InsertNewDepartmentsCommand(),UpdateDepartmentsCommand(),DeleteDepartmentsCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Departments using Stored Procedure
		/// and return number of rows effected of the Departments
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Departments",InsertNewDepartmentsCommand(),UpdateDepartmentsCommand(),DeleteDepartmentsCommand(), transaction);
          return rowsAffected;
		}


	}
}
