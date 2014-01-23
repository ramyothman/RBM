using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.HumanResources
{
	/// <summary>
	/// This is a Data Access Class  for EmployeeContract table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the EmployeeContract table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class EmployeeContractDAC : DataAccessComponent
	{
		#region Constructors
        public EmployeeContractDAC() : base("", "HumanResources.EmployeeContract") { }
		public EmployeeContractDAC(string connectionString): base(connectionString){}
		public EmployeeContractDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeContract using Stored Procedure
		/// and return a DataTable containing all EmployeeContract Data
		/// </summary>
		public DataTable GetAllEmployeeContract()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeContract";
         string query = " select * from GetAllEmployeeContract";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmployeeContract"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeContract using Stored Procedure
		/// and return a DataTable containing all EmployeeContract Data using a Transaction
		/// </summary>
		public DataTable GetAllEmployeeContract(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeContract";
         string query = " select * from GetAllEmployeeContract";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmployeeContract"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeContract using Stored Procedure
		/// and return a DataTable containing all EmployeeContract Data
		/// </summary>
		public DataTable GetAllEmployeeContract(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeContract";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllEmployeeContract" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmployeeContract"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeeContract using Stored Procedure
		/// and return a DataTable containing all EmployeeContract Data using a Transaction
		/// </summary>
		public DataTable GetAllEmployeeContract(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeeContract";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllEmployeeContract" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmployeeContract"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmployeeContract using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmployeeContract( int employeeContractID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmployeeContract");
				    Database.AddInParameter(command,"EmployeeContractID",DbType.Int32,employeeContractID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmployeeContract using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmployeeContract( int employeeContractID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmployeeContract");
				    Database.AddInParameter(command,"EmployeeContractID",DbType.Int32,employeeContractID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmployeeContract using Stored Procedure
		/// and return the auto number primary key of EmployeeContract inserted row
		/// </summary>
		public bool InsertNewEmployeeContract( ref int employeeContractID,  int employeeID,  int contractID,  int contractStatusTypeID,  decimal netSalary,  decimal grossSalary,  DateTime offerDate,  DateTime acceptanceDate,  bool isAccepted,  DateTime startDate,  DateTime endDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployeeContract");
				Database.AddOutParameter(command,"EmployeeContractID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
				Database.AddInParameter(command,"ContractID",DbType.Int32,contractID);
				Database.AddInParameter(command,"ContractStatusTypeID",DbType.Int32,contractStatusTypeID);
				Database.AddInParameter(command,"NetSalary",DbType.Decimal,netSalary);
				Database.AddInParameter(command,"GrossSalary",DbType.Decimal,grossSalary);
				Database.AddInParameter(command,"OfferDate",DbType.DateTime,offerDate);
				Database.AddInParameter(command,"AcceptanceDate",DbType.DateTime,acceptanceDate);
				Database.AddInParameter(command,"IsAccepted",DbType.Boolean,isAccepted);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 employeeContractID = Convert.ToInt32(Database.GetParameterValue(command, "EmployeeContractID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmployeeContract using Stored Procedure
		/// and return the auto number primary key of EmployeeContract inserted row using Transaction
		/// </summary>
		public bool InsertNewEmployeeContract( ref int employeeContractID,  int employeeID,  int contractID,  int contractStatusTypeID,  decimal netSalary,  decimal grossSalary,  DateTime offerDate,  DateTime acceptanceDate,  bool isAccepted,  DateTime startDate,  DateTime endDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployeeContract");
				Database.AddOutParameter(command,"EmployeeContractID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
				Database.AddInParameter(command,"ContractID",DbType.Int32,contractID);
				Database.AddInParameter(command,"ContractStatusTypeID",DbType.Int32,contractStatusTypeID);
				Database.AddInParameter(command,"NetSalary",DbType.Decimal,netSalary);
				Database.AddInParameter(command,"GrossSalary",DbType.Decimal,grossSalary);
				Database.AddInParameter(command,"OfferDate",DbType.DateTime,offerDate);
				Database.AddInParameter(command,"AcceptanceDate",DbType.DateTime,acceptanceDate);
				Database.AddInParameter(command,"IsAccepted",DbType.Boolean,isAccepted);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 employeeContractID = Convert.ToInt32(Database.GetParameterValue(command, "EmployeeContractID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for EmployeeContract using Stored Procedure
		/// and return DbCommand of the EmployeeContract
		/// </summary>
		public DbCommand InsertNewEmployeeContractCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployeeContract");

				Database.AddInParameter(command,"EmployeeID",DbType.Int32,"EmployeeID",DataRowVersion.Current);
				Database.AddInParameter(command,"ContractID",DbType.Int32,"ContractID",DataRowVersion.Current);
				Database.AddInParameter(command,"ContractStatusTypeID",DbType.Int32,"ContractStatusTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"NetSalary",DbType.Decimal,"NetSalary",DataRowVersion.Current);
				Database.AddInParameter(command,"GrossSalary",DbType.Decimal,"GrossSalary",DataRowVersion.Current);
				Database.AddInParameter(command,"OfferDate",DbType.DateTime,"OfferDate",DataRowVersion.Current);
				Database.AddInParameter(command,"AcceptanceDate",DbType.DateTime,"AcceptanceDate",DataRowVersion.Current);
				Database.AddInParameter(command,"IsAccepted",DbType.Boolean,"IsAccepted",DataRowVersion.Current);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,"StartDate",DataRowVersion.Current);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,"EndDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmployeeContract using Stored Procedure
		/// </summary>
		public bool UpdateEmployeeContract( int employeeID, int contractID, int contractStatusTypeID, decimal netSalary, decimal grossSalary, DateTime offerDate, DateTime acceptanceDate, bool isAccepted, DateTime startDate, DateTime endDate, int oldemployeeContractID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployeeContract");

		    		Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
		    		Database.AddInParameter(command,"ContractID",DbType.Int32,contractID);
		    		Database.AddInParameter(command,"ContractStatusTypeID",DbType.Int32,contractStatusTypeID);
		    		Database.AddInParameter(command,"NetSalary",DbType.Decimal,netSalary);
		    		Database.AddInParameter(command,"GrossSalary",DbType.Decimal,grossSalary);
		    		Database.AddInParameter(command,"OfferDate",DbType.DateTime,offerDate);
		    		Database.AddInParameter(command,"AcceptanceDate",DbType.DateTime,acceptanceDate);
		    		Database.AddInParameter(command,"IsAccepted",DbType.Boolean,isAccepted);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				Database.AddInParameter(command,"oldEmployeeContractID",DbType.Int32,oldemployeeContractID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmployeeContract using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateEmployeeContract( int employeeID, int contractID, int contractStatusTypeID, decimal netSalary, decimal grossSalary, DateTime offerDate, DateTime acceptanceDate, bool isAccepted, DateTime startDate, DateTime endDate, int oldemployeeContractID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployeeContract");

		    		Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
		    		Database.AddInParameter(command,"ContractID",DbType.Int32,contractID);
		    		Database.AddInParameter(command,"ContractStatusTypeID",DbType.Int32,contractStatusTypeID);
		    		Database.AddInParameter(command,"NetSalary",DbType.Decimal,netSalary);
		    		Database.AddInParameter(command,"GrossSalary",DbType.Decimal,grossSalary);
		    		Database.AddInParameter(command,"OfferDate",DbType.DateTime,offerDate);
		    		Database.AddInParameter(command,"AcceptanceDate",DbType.DateTime,acceptanceDate);
		    		Database.AddInParameter(command,"IsAccepted",DbType.Boolean,isAccepted);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				Database.AddInParameter(command,"oldEmployeeContractID",DbType.Int32,oldemployeeContractID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from EmployeeContract using Stored Procedure
		/// </summary>
		public DbCommand UpdateEmployeeContractCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployeeContract");

		    		Database.AddInParameter(command,"EmployeeID",DbType.Int32,"EmployeeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ContractID",DbType.Int32,"ContractID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ContractStatusTypeID",DbType.Int32,"ContractStatusTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"NetSalary",DbType.Decimal,"NetSalary",DataRowVersion.Current);
		    		Database.AddInParameter(command,"GrossSalary",DbType.Decimal,"GrossSalary",DataRowVersion.Current);
		    		Database.AddInParameter(command,"OfferDate",DbType.DateTime,"OfferDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AcceptanceDate",DbType.DateTime,"AcceptanceDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsAccepted",DbType.Boolean,"IsAccepted",DataRowVersion.Current);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,"StartDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,"EndDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldEmployeeContractID",DbType.Int32,"EmployeeContractID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From EmployeeContract using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteEmployeeContract( int employeeContractID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteEmployeeContract");
			Database.AddInParameter(command,"EmployeeContractID",DbType.Int32,employeeContractID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From EmployeeContract Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteEmployeeContractCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteEmployeeContract");
				Database.AddInParameter(command,"EmployeeContractID",DbType.Int32,"EmployeeContractID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmployeeContract using Stored Procedure
		/// and return number of rows effected of the EmployeeContract
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmployeeContract",InsertNewEmployeeContractCommand(),UpdateEmployeeContractCommand(),DeleteEmployeeContractCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmployeeContract using Stored Procedure
		/// and return number of rows effected of the EmployeeContract
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmployeeContract",InsertNewEmployeeContractCommand(),UpdateEmployeeContractCommand(),DeleteEmployeeContractCommand(), transaction);
          return rowsAffected;
		}


	}
}
