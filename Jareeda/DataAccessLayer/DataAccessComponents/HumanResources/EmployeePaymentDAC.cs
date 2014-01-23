using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.HumanResources
{
	/// <summary>
	/// This is a Data Access Class  for EmployeePayment table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the EmployeePayment table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class EmployeePaymentDAC : DataAccessComponent
	{
		#region Constructors
		public EmployeePaymentDAC() : base("", "HumanResources.EmployeePayment") { }
		public EmployeePaymentDAC(string connectionString): base(connectionString){}
		public EmployeePaymentDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeePayment using Stored Procedure
		/// and return a DataTable containing all EmployeePayment Data
		/// </summary>
		public DataTable GetAllEmployeePayment()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeePayment";
         string query = " select * from GetAllEmployeePayment";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmployeePayment"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeePayment using Stored Procedure
		/// and return a DataTable containing all EmployeePayment Data using a Transaction
		/// </summary>
		public DataTable GetAllEmployeePayment(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeePayment";
         string query = " select * from GetAllEmployeePayment";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmployeePayment"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeePayment using Stored Procedure
		/// and return a DataTable containing all EmployeePayment Data
		/// </summary>
		public DataTable GetAllEmployeePayment(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeePayment";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllEmployeePayment" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmployeePayment"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmployeePayment using Stored Procedure
		/// and return a DataTable containing all EmployeePayment Data using a Transaction
		/// </summary>
		public DataTable GetAllEmployeePayment(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmployeePayment";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllEmployeePayment" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmployeePayment"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmployeePayment using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmployeePayment( int employeePaymentID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmployeePayment");
				    Database.AddInParameter(command,"EmployeePaymentID",DbType.Int32,employeePaymentID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmployeePayment using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmployeePayment( int employeePaymentID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmployeePayment");
				    Database.AddInParameter(command,"EmployeePaymentID",DbType.Int32,employeePaymentID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmployeePayment using Stored Procedure
		/// and return the auto number primary key of EmployeePayment inserted row
		/// </summary>
		public bool InsertNewEmployeePayment( ref int employeePaymentID,  int employeeID,  int paymentTypeID,  int paymentMethodID,  decimal amount,  string reason,  string details,  bool isPaid,  DateTime datePaid)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployeePayment");
				Database.AddOutParameter(command,"EmployeePaymentID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
				Database.AddInParameter(command,"PaymentTypeID",DbType.Int32,paymentTypeID);
				Database.AddInParameter(command,"PaymentMethodID",DbType.Int32,paymentMethodID);
				Database.AddInParameter(command,"Amount",DbType.Decimal,amount);
				Database.AddInParameter(command,"Reason",DbType.String,reason);
				Database.AddInParameter(command,"Details",DbType.String,details);
				Database.AddInParameter(command,"IsPaid",DbType.Boolean,isPaid);
				Database.AddInParameter(command,"DatePaid",DbType.DateTime,datePaid);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 employeePaymentID = Convert.ToInt32(Database.GetParameterValue(command, "EmployeePaymentID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmployeePayment using Stored Procedure
		/// and return the auto number primary key of EmployeePayment inserted row using Transaction
		/// </summary>
		public bool InsertNewEmployeePayment( ref int employeePaymentID,  int employeeID,  int paymentTypeID,  int paymentMethodID,  decimal amount,  string reason,  string details,  bool isPaid,  DateTime datePaid,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployeePayment");
				Database.AddOutParameter(command,"EmployeePaymentID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
				Database.AddInParameter(command,"PaymentTypeID",DbType.Int32,paymentTypeID);
				Database.AddInParameter(command,"PaymentMethodID",DbType.Int32,paymentMethodID);
				Database.AddInParameter(command,"Amount",DbType.Decimal,amount);
				Database.AddInParameter(command,"Reason",DbType.String,reason);
				Database.AddInParameter(command,"Details",DbType.String,details);
				Database.AddInParameter(command,"IsPaid",DbType.Boolean,isPaid);
				Database.AddInParameter(command,"DatePaid",DbType.DateTime,datePaid);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 employeePaymentID = Convert.ToInt32(Database.GetParameterValue(command, "EmployeePaymentID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for EmployeePayment using Stored Procedure
		/// and return DbCommand of the EmployeePayment
		/// </summary>
		public DbCommand InsertNewEmployeePaymentCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmployeePayment");

				Database.AddInParameter(command,"EmployeeID",DbType.Int32,"EmployeeID",DataRowVersion.Current);
				Database.AddInParameter(command,"PaymentTypeID",DbType.Int32,"PaymentTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"PaymentMethodID",DbType.Int32,"PaymentMethodID",DataRowVersion.Current);
				Database.AddInParameter(command,"Amount",DbType.Decimal,"Amount",DataRowVersion.Current);
				Database.AddInParameter(command,"Reason",DbType.String,"Reason",DataRowVersion.Current);
				Database.AddInParameter(command,"Details",DbType.String,"Details",DataRowVersion.Current);
				Database.AddInParameter(command,"IsPaid",DbType.Boolean,"IsPaid",DataRowVersion.Current);
				Database.AddInParameter(command,"DatePaid",DbType.DateTime,"DatePaid",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmployeePayment using Stored Procedure
		/// </summary>
		public bool UpdateEmployeePayment( int employeeID, int paymentTypeID, int paymentMethodID, decimal amount, string reason, string details, bool isPaid, DateTime datePaid, int oldemployeePaymentID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployeePayment");

		    		Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
		    		Database.AddInParameter(command,"PaymentTypeID",DbType.Int32,paymentTypeID);
		    		Database.AddInParameter(command,"PaymentMethodID",DbType.Int32,paymentMethodID);
		    		Database.AddInParameter(command,"Amount",DbType.Decimal,amount);
		    		Database.AddInParameter(command,"Reason",DbType.String,reason);
		    		Database.AddInParameter(command,"Details",DbType.String,details);
		    		Database.AddInParameter(command,"IsPaid",DbType.Boolean,isPaid);
		    		Database.AddInParameter(command,"DatePaid",DbType.DateTime,datePaid);
				Database.AddInParameter(command,"oldEmployeePaymentID",DbType.Int32,oldemployeePaymentID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmployeePayment using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateEmployeePayment( int employeeID, int paymentTypeID, int paymentMethodID, decimal amount, string reason, string details, bool isPaid, DateTime datePaid, int oldemployeePaymentID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployeePayment");

		    		Database.AddInParameter(command,"EmployeeID",DbType.Int32,employeeID);
		    		Database.AddInParameter(command,"PaymentTypeID",DbType.Int32,paymentTypeID);
		    		Database.AddInParameter(command,"PaymentMethodID",DbType.Int32,paymentMethodID);
		    		Database.AddInParameter(command,"Amount",DbType.Decimal,amount);
		    		Database.AddInParameter(command,"Reason",DbType.String,reason);
		    		Database.AddInParameter(command,"Details",DbType.String,details);
		    		Database.AddInParameter(command,"IsPaid",DbType.Boolean,isPaid);
		    		Database.AddInParameter(command,"DatePaid",DbType.DateTime,datePaid);
				Database.AddInParameter(command,"oldEmployeePaymentID",DbType.Int32,oldemployeePaymentID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from EmployeePayment using Stored Procedure
		/// </summary>
		public DbCommand UpdateEmployeePaymentCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmployeePayment");

		    		Database.AddInParameter(command,"EmployeeID",DbType.Int32,"EmployeeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PaymentTypeID",DbType.Int32,"PaymentTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PaymentMethodID",DbType.Int32,"PaymentMethodID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Amount",DbType.Decimal,"Amount",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Reason",DbType.String,"Reason",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Details",DbType.String,"Details",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsPaid",DbType.Boolean,"IsPaid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DatePaid",DbType.DateTime,"DatePaid",DataRowVersion.Current);
				Database.AddInParameter(command,"oldEmployeePaymentID",DbType.Int32,"EmployeePaymentID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From EmployeePayment using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteEmployeePayment( int employeePaymentID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteEmployeePayment");
			Database.AddInParameter(command,"EmployeePaymentID",DbType.Int32,employeePaymentID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From EmployeePayment Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteEmployeePaymentCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteEmployeePayment");
				Database.AddInParameter(command,"EmployeePaymentID",DbType.Int32,"EmployeePaymentID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmployeePayment using Stored Procedure
		/// and return number of rows effected of the EmployeePayment
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmployeePayment",InsertNewEmployeePaymentCommand(),UpdateEmployeePaymentCommand(),DeleteEmployeePaymentCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmployeePayment using Stored Procedure
		/// and return number of rows effected of the EmployeePayment
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmployeePayment",InsertNewEmployeePaymentCommand(),UpdateEmployeePaymentCommand(),DeleteEmployeePaymentCommand(), transaction);
          return rowsAffected;
		}


	}
}
