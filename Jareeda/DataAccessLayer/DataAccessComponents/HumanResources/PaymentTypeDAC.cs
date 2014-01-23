using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.HumanResources
{
	/// <summary>
	/// This is a Data Access Class  for PaymentType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the PaymentType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PaymentTypeDAC : DataAccessComponent
	{
		#region Constructors
        public PaymentTypeDAC() : base("", "HumanResources.PaymentType") { }
		public PaymentTypeDAC(string connectionString): base(connectionString){}
		public PaymentTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PaymentType using Stored Procedure
		/// and return a DataTable containing all PaymentType Data
		/// </summary>
		public DataTable GetAllPaymentType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PaymentType";
         string query = " select * from GetAllPaymentType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PaymentType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PaymentType using Stored Procedure
		/// and return a DataTable containing all PaymentType Data using a Transaction
		/// </summary>
		public DataTable GetAllPaymentType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PaymentType";
         string query = " select * from GetAllPaymentType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PaymentType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PaymentType using Stored Procedure
		/// and return a DataTable containing all PaymentType Data
		/// </summary>
		public DataTable GetAllPaymentType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PaymentType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPaymentType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PaymentType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PaymentType using Stored Procedure
		/// and return a DataTable containing all PaymentType Data using a Transaction
		/// </summary>
		public DataTable GetAllPaymentType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PaymentType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPaymentType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PaymentType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PaymentType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPaymentType( int paymentTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPaymentType");
				    Database.AddInParameter(command,"PaymentTypeID",DbType.Int32,paymentTypeID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PaymentType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPaymentType( int paymentTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPaymentType");
				    Database.AddInParameter(command,"PaymentTypeID",DbType.Int32,paymentTypeID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PaymentType using Stored Procedure
		/// and return the auto number primary key of PaymentType inserted row
		/// </summary>
		public bool InsertNewPaymentType( ref int paymentTypeID,  string name,  bool isRecurring,  int recurringNumberinDays,  bool isPerItem,  int itemNumber)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPaymentType");
				Database.AddOutParameter(command,"PaymentTypeID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"IsRecurring",DbType.Boolean,isRecurring);
				Database.AddInParameter(command,"RecurringNumberinDays",DbType.Int32,recurringNumberinDays);
				Database.AddInParameter(command,"IsPerItem",DbType.Boolean,isPerItem);
				Database.AddInParameter(command,"ItemNumber",DbType.Int32,itemNumber);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 paymentTypeID = Convert.ToInt32(Database.GetParameterValue(command, "PaymentTypeID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PaymentType using Stored Procedure
		/// and return the auto number primary key of PaymentType inserted row using Transaction
		/// </summary>
		public bool InsertNewPaymentType( ref int paymentTypeID,  string name,  bool isRecurring,  int recurringNumberinDays,  bool isPerItem,  int itemNumber,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPaymentType");
				Database.AddOutParameter(command,"PaymentTypeID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"IsRecurring",DbType.Boolean,isRecurring);
				Database.AddInParameter(command,"RecurringNumberinDays",DbType.Int32,recurringNumberinDays);
				Database.AddInParameter(command,"IsPerItem",DbType.Boolean,isPerItem);
				Database.AddInParameter(command,"ItemNumber",DbType.Int32,itemNumber);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 paymentTypeID = Convert.ToInt32(Database.GetParameterValue(command, "PaymentTypeID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for PaymentType using Stored Procedure
		/// and return DbCommand of the PaymentType
		/// </summary>
		public DbCommand InsertNewPaymentTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPaymentType");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"IsRecurring",DbType.Boolean,"IsRecurring",DataRowVersion.Current);
				Database.AddInParameter(command,"RecurringNumberinDays",DbType.Int32,"RecurringNumberinDays",DataRowVersion.Current);
				Database.AddInParameter(command,"IsPerItem",DbType.Boolean,"IsPerItem",DataRowVersion.Current);
				Database.AddInParameter(command,"ItemNumber",DbType.Int32,"ItemNumber",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PaymentType using Stored Procedure
		/// </summary>
		public bool UpdatePaymentType( string name, bool isRecurring, int recurringNumberinDays, bool isPerItem, int itemNumber, int oldpaymentTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePaymentType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"IsRecurring",DbType.Boolean,isRecurring);
		    		Database.AddInParameter(command,"RecurringNumberinDays",DbType.Int32,recurringNumberinDays);
		    		Database.AddInParameter(command,"IsPerItem",DbType.Boolean,isPerItem);
		    		Database.AddInParameter(command,"ItemNumber",DbType.Int32,itemNumber);
				Database.AddInParameter(command,"oldPaymentTypeID",DbType.Int32,oldpaymentTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PaymentType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdatePaymentType( string name, bool isRecurring, int recurringNumberinDays, bool isPerItem, int itemNumber, int oldpaymentTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePaymentType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"IsRecurring",DbType.Boolean,isRecurring);
		    		Database.AddInParameter(command,"RecurringNumberinDays",DbType.Int32,recurringNumberinDays);
		    		Database.AddInParameter(command,"IsPerItem",DbType.Boolean,isPerItem);
		    		Database.AddInParameter(command,"ItemNumber",DbType.Int32,itemNumber);
				Database.AddInParameter(command,"oldPaymentTypeID",DbType.Int32,oldpaymentTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from PaymentType using Stored Procedure
		/// </summary>
		public DbCommand UpdatePaymentTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePaymentType");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsRecurring",DbType.Boolean,"IsRecurring",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RecurringNumberinDays",DbType.Int32,"RecurringNumberinDays",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsPerItem",DbType.Boolean,"IsPerItem",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ItemNumber",DbType.Int32,"ItemNumber",DataRowVersion.Current);
				Database.AddInParameter(command,"oldPaymentTypeID",DbType.Int32,"PaymentTypeID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From PaymentType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePaymentType( int paymentTypeID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePaymentType");
			Database.AddInParameter(command,"PaymentTypeID",DbType.Int32,paymentTypeID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From PaymentType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePaymentTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePaymentType");
				Database.AddInParameter(command,"PaymentTypeID",DbType.Int32,"PaymentTypeID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PaymentType using Stored Procedure
		/// and return number of rows effected of the PaymentType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PaymentType",InsertNewPaymentTypeCommand(),UpdatePaymentTypeCommand(),DeletePaymentTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PaymentType using Stored Procedure
		/// and return number of rows effected of the PaymentType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PaymentType",InsertNewPaymentTypeCommand(),UpdatePaymentTypeCommand(),DeletePaymentTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
