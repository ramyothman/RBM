using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.HumanResources
{
	/// <summary>
	/// This is a Data Access Class  for PaymentMethod table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the PaymentMethod table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PaymentMethodDAC : DataAccessComponent
	{
		#region Constructors
        public PaymentMethodDAC() : base("", "HumanResources.PaymentMethod") { }
		public PaymentMethodDAC(string connectionString): base(connectionString){}
		public PaymentMethodDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PaymentMethod using Stored Procedure
		/// and return a DataTable containing all PaymentMethod Data
		/// </summary>
		public DataTable GetAllPaymentMethod()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PaymentMethod";
         string query = " select * from GetAllPaymentMethod";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PaymentMethod"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PaymentMethod using Stored Procedure
		/// and return a DataTable containing all PaymentMethod Data using a Transaction
		/// </summary>
		public DataTable GetAllPaymentMethod(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PaymentMethod";
         string query = " select * from GetAllPaymentMethod";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PaymentMethod"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PaymentMethod using Stored Procedure
		/// and return a DataTable containing all PaymentMethod Data
		/// </summary>
		public DataTable GetAllPaymentMethod(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PaymentMethod";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPaymentMethod" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PaymentMethod"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PaymentMethod using Stored Procedure
		/// and return a DataTable containing all PaymentMethod Data using a Transaction
		/// </summary>
		public DataTable GetAllPaymentMethod(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PaymentMethod";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPaymentMethod" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PaymentMethod"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PaymentMethod using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPaymentMethod( int paymentMethodID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPaymentMethod");
				    Database.AddInParameter(command,"PaymentMethodID",DbType.Int32,paymentMethodID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PaymentMethod using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPaymentMethod( int paymentMethodID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPaymentMethod");
				    Database.AddInParameter(command,"PaymentMethodID",DbType.Int32,paymentMethodID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PaymentMethod using Stored Procedure
		/// and return the auto number primary key of PaymentMethod inserted row
		/// </summary>
		public bool InsertNewPaymentMethod( ref int paymentMethodID,  string name)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPaymentMethod");
				Database.AddOutParameter(command,"PaymentMethodID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 paymentMethodID = Convert.ToInt32(Database.GetParameterValue(command, "PaymentMethodID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PaymentMethod using Stored Procedure
		/// and return the auto number primary key of PaymentMethod inserted row using Transaction
		/// </summary>
		public bool InsertNewPaymentMethod( ref int paymentMethodID,  string name,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPaymentMethod");
				Database.AddOutParameter(command,"PaymentMethodID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 paymentMethodID = Convert.ToInt32(Database.GetParameterValue(command, "PaymentMethodID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for PaymentMethod using Stored Procedure
		/// and return DbCommand of the PaymentMethod
		/// </summary>
		public DbCommand InsertNewPaymentMethodCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPaymentMethod");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PaymentMethod using Stored Procedure
		/// </summary>
		public bool UpdatePaymentMethod( string name, int oldpaymentMethodID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePaymentMethod");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldPaymentMethodID",DbType.Int32,oldpaymentMethodID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PaymentMethod using Stored Procedure By Transaction
		/// </summary>
		public bool UpdatePaymentMethod( string name, int oldpaymentMethodID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePaymentMethod");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldPaymentMethodID",DbType.Int32,oldpaymentMethodID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from PaymentMethod using Stored Procedure
		/// </summary>
		public DbCommand UpdatePaymentMethodCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePaymentMethod");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"oldPaymentMethodID",DbType.Int32,"PaymentMethodID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From PaymentMethod using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePaymentMethod( int paymentMethodID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePaymentMethod");
			Database.AddInParameter(command,"PaymentMethodID",DbType.Int32,paymentMethodID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From PaymentMethod Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePaymentMethodCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePaymentMethod");
				Database.AddInParameter(command,"PaymentMethodID",DbType.Int32,"PaymentMethodID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PaymentMethod using Stored Procedure
		/// and return number of rows effected of the PaymentMethod
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PaymentMethod",InsertNewPaymentMethodCommand(),UpdatePaymentMethodCommand(),DeletePaymentMethodCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PaymentMethod using Stored Procedure
		/// and return number of rows effected of the PaymentMethod
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PaymentMethod",InsertNewPaymentMethodCommand(),UpdatePaymentMethodCommand(),DeletePaymentMethodCommand(), transaction);
          return rowsAffected;
		}


	}
}
