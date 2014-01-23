using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.HumanResources
{
	/// <summary>
	/// This is a Data Access Class  for ContractType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ContractType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ContractTypeDAC : DataAccessComponent
	{
		#region Constructors
        public ContractTypeDAC() : base("", "HumanResources.ContractType") { }
		public ContractTypeDAC(string connectionString): base(connectionString){}
		public ContractTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContractType using Stored Procedure
		/// and return a DataTable containing all ContractType Data
		/// </summary>
		public DataTable GetAllContractType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContractType";
         string query = " select * from GetAllContractType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ContractType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContractType using Stored Procedure
		/// and return a DataTable containing all ContractType Data using a Transaction
		/// </summary>
		public DataTable GetAllContractType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContractType";
         string query = " select * from GetAllContractType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ContractType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContractType using Stored Procedure
		/// and return a DataTable containing all ContractType Data
		/// </summary>
		public DataTable GetAllContractType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContractType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllContractType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ContractType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContractType using Stored Procedure
		/// and return a DataTable containing all ContractType Data using a Transaction
		/// </summary>
		public DataTable GetAllContractType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContractType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllContractType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ContractType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ContractType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDContractType( int contractTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDContractType");
				    Database.AddInParameter(command,"ContractTypeID",DbType.Int32,contractTypeID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ContractType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDContractType( int contractTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDContractType");
				    Database.AddInParameter(command,"ContractTypeID",DbType.Int32,contractTypeID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ContractType using Stored Procedure
		/// and return the auto number primary key of ContractType inserted row
		/// </summary>
		public bool InsertNewContractType( int contractTypeID,  string name)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewContractType");
				Database.AddInParameter(command,"ContractTypeID",DbType.Int32,contractTypeID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ContractType using Stored Procedure
		/// and return the auto number primary key of ContractType inserted row using Transaction
		/// </summary>
		public bool InsertNewContractType( int contractTypeID,  string name,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewContractType");
				Database.AddInParameter(command,"ContractTypeID",DbType.Int32,contractTypeID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ContractType using Stored Procedure
		/// and return DbCommand of the ContractType
		/// </summary>
		public DbCommand InsertNewContractTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewContractType");
				Database.AddInParameter(command,"ContractTypeID",DbType.Int32,"ContractTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ContractType using Stored Procedure
		/// </summary>
		public bool UpdateContractType( int contractTypeID, string name, int oldcontractTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateContractType");
		    		Database.AddInParameter(command,"ContractTypeID",DbType.Int32,contractTypeID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldContractTypeID",DbType.Int32,oldcontractTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ContractType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateContractType( int contractTypeID, string name, int oldcontractTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateContractType");
		    		Database.AddInParameter(command,"ContractTypeID",DbType.Int32,contractTypeID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldContractTypeID",DbType.Int32,oldcontractTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ContractType using Stored Procedure
		/// </summary>
		public DbCommand UpdateContractTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateContractType");
		    		Database.AddInParameter(command,"ContractTypeID",DbType.Int32,"ContractTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"oldContractTypeID",DbType.Int32,"ContractTypeID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ContractType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteContractType( int contractTypeID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteContractType");
			Database.AddInParameter(command,"ContractTypeID",DbType.Int32,contractTypeID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ContractType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteContractTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteContractType");
				Database.AddInParameter(command,"ContractTypeID",DbType.Int32,"ContractTypeID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ContractType using Stored Procedure
		/// and return number of rows effected of the ContractType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ContractType",InsertNewContractTypeCommand(),UpdateContractTypeCommand(),DeleteContractTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ContractType using Stored Procedure
		/// and return number of rows effected of the ContractType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ContractType",InsertNewContractTypeCommand(),UpdateContractTypeCommand(),DeleteContractTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
