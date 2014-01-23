using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.HumanResources
{
	/// <summary>
	/// This is a Data Access Class  for Contract table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Contract table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ContractDAC : DataAccessComponent
	{
		#region Constructors
        public ContractDAC() : base("", "HumanResources.Contract") { }
		public ContractDAC(string connectionString): base(connectionString){}
		public ContractDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Contract using Stored Procedure
		/// and return a DataTable containing all Contract Data
		/// </summary>
		public DataTable GetAllContract()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Contract";
         string query = " select * from GetAllContract";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Contract"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Contract using Stored Procedure
		/// and return a DataTable containing all Contract Data using a Transaction
		/// </summary>
		public DataTable GetAllContract(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Contract";
         string query = " select * from GetAllContract";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Contract"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Contract using Stored Procedure
		/// and return a DataTable containing all Contract Data
		/// </summary>
		public DataTable GetAllContract(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Contract";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllContract" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Contract"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Contract using Stored Procedure
		/// and return a DataTable containing all Contract Data using a Transaction
		/// </summary>
		public DataTable GetAllContract(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Contract";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllContract" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Contract"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Contract using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDContract( int contractID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDContract");
				    Database.AddInParameter(command,"ContractID",DbType.Int32,contractID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Contract using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDContract( int contractID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDContract");
				    Database.AddInParameter(command,"ContractID",DbType.Int32,contractID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Contract using Stored Procedure
		/// and return the auto number primary key of Contract inserted row
		/// </summary>
		public bool InsertNewContract( ref int contractID,  int contractTypeID,  string name,  string contractTemplate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewContract");
				Database.AddOutParameter(command,"ContractID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ContractTypeID",DbType.Int32,contractTypeID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ContractTemplate",DbType.String,contractTemplate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 contractID = Convert.ToInt32(Database.GetParameterValue(command, "ContractID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Contract using Stored Procedure
		/// and return the auto number primary key of Contract inserted row using Transaction
		/// </summary>
		public bool InsertNewContract( ref int contractID,  int contractTypeID,  string name,  string contractTemplate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewContract");
				Database.AddOutParameter(command,"ContractID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ContractTypeID",DbType.Int32,contractTypeID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ContractTemplate",DbType.String,contractTemplate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 contractID = Convert.ToInt32(Database.GetParameterValue(command, "ContractID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Contract using Stored Procedure
		/// and return DbCommand of the Contract
		/// </summary>
		public DbCommand InsertNewContractCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewContract");

				Database.AddInParameter(command,"ContractTypeID",DbType.Int32,"ContractTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"ContractTemplate",DbType.String,"ContractTemplate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Contract using Stored Procedure
		/// </summary>
		public bool UpdateContract( int contractTypeID, string name, string contractTemplate, int oldcontractID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateContract");

		    		Database.AddInParameter(command,"ContractTypeID",DbType.Int32,contractTypeID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ContractTemplate",DbType.String,contractTemplate);
				Database.AddInParameter(command,"oldContractID",DbType.Int32,oldcontractID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Contract using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateContract( int contractTypeID, string name, string contractTemplate, int oldcontractID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateContract");

		    		Database.AddInParameter(command,"ContractTypeID",DbType.Int32,contractTypeID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ContractTemplate",DbType.String,contractTemplate);
				Database.AddInParameter(command,"oldContractID",DbType.Int32,oldcontractID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Contract using Stored Procedure
		/// </summary>
		public DbCommand UpdateContractCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateContract");

		    		Database.AddInParameter(command,"ContractTypeID",DbType.Int32,"ContractTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ContractTemplate",DbType.String,"ContractTemplate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldContractID",DbType.Int32,"ContractID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Contract using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteContract( int contractID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteContract");
			Database.AddInParameter(command,"ContractID",DbType.Int32,contractID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Contract Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteContractCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteContract");
				Database.AddInParameter(command,"ContractID",DbType.Int32,"ContractID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Contract using Stored Procedure
		/// and return number of rows effected of the Contract
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Contract",InsertNewContractCommand(),UpdateContractCommand(),DeleteContractCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Contract using Stored Procedure
		/// and return number of rows effected of the Contract
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Contract",InsertNewContractCommand(),UpdateContractCommand(),DeleteContractCommand(), transaction);
          return rowsAffected;
		}


	}
}
