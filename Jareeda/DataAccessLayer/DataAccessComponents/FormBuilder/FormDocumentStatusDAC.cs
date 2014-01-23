using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.FormBuilder
{
	/// <summary>
	/// This is a Data Access Class  for FormDocumentStatus table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the FormDocumentStatus table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class FormDocumentStatusDAC : DataAccessComponent
	{
		#region Constructors
        public FormDocumentStatusDAC() : base("", "FormBuilder.FormDocumentStatus") { }
		public FormDocumentStatusDAC(string connectionString): base(connectionString){}
		public FormDocumentStatusDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormDocumentStatus using Stored Procedure
		/// and return a DataTable containing all FormDocumentStatus Data
		/// </summary>
		public DataTable GetAllFormDocumentStatus()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormDocumentStatus";
         string query = " select * from GetAllFormDocumentStatus";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormDocumentStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormDocumentStatus using Stored Procedure
		/// and return a DataTable containing all FormDocumentStatus Data using a Transaction
		/// </summary>
		public DataTable GetAllFormDocumentStatus(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormDocumentStatus";
         string query = " select * from GetAllFormDocumentStatus";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormDocumentStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormDocumentStatus using Stored Procedure
		/// and return a DataTable containing all FormDocumentStatus Data
		/// </summary>
		public DataTable GetAllFormDocumentStatus(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormDocumentStatus";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllFormDocumentStatus" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormDocumentStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormDocumentStatus using Stored Procedure
		/// and return a DataTable containing all FormDocumentStatus Data using a Transaction
		/// </summary>
		public DataTable GetAllFormDocumentStatus(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormDocumentStatus";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllFormDocumentStatus" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormDocumentStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormDocumentStatus using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormDocumentStatus( int formDocumentStatusID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormDocumentStatus");
				    Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,formDocumentStatusID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormDocumentStatus using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormDocumentStatus( int formDocumentStatusID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormDocumentStatus");
				    Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,formDocumentStatusID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormDocumentStatus using Stored Procedure
		/// and return the auto number primary key of FormDocumentStatus inserted row
		/// </summary>
		public bool InsertNewFormDocumentStatus( int formDocumentStatusID,  string statusName)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormDocumentStatus");
				Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,formDocumentStatusID);
				Database.AddInParameter(command,"StatusName",DbType.String,statusName);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormDocumentStatus using Stored Procedure
		/// and return the auto number primary key of FormDocumentStatus inserted row using Transaction
		/// </summary>
		public bool InsertNewFormDocumentStatus( int formDocumentStatusID,  string statusName,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormDocumentStatus");
				Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,formDocumentStatusID);
				Database.AddInParameter(command,"StatusName",DbType.String,statusName);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for FormDocumentStatus using Stored Procedure
		/// and return DbCommand of the FormDocumentStatus
		/// </summary>
		public DbCommand InsertNewFormDocumentStatusCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormDocumentStatus");
				Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,"FormDocumentStatusID",DataRowVersion.Current);
				Database.AddInParameter(command,"StatusName",DbType.String,"StatusName",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormDocumentStatus using Stored Procedure
		/// </summary>
		public bool UpdateFormDocumentStatus( int formDocumentStatusID, string statusName, int oldformDocumentStatusID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormDocumentStatus");
		    		Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,formDocumentStatusID);
		    		Database.AddInParameter(command,"StatusName",DbType.String,statusName);
				Database.AddInParameter(command,"oldFormDocumentStatusID",DbType.Int32,oldformDocumentStatusID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormDocumentStatus using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateFormDocumentStatus( int formDocumentStatusID, string statusName, int oldformDocumentStatusID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormDocumentStatus");
		    		Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,formDocumentStatusID);
		    		Database.AddInParameter(command,"StatusName",DbType.String,statusName);
				Database.AddInParameter(command,"oldFormDocumentStatusID",DbType.Int32,oldformDocumentStatusID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from FormDocumentStatus using Stored Procedure
		/// </summary>
		public DbCommand UpdateFormDocumentStatusCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormDocumentStatus");
		    		Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,"FormDocumentStatusID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"StatusName",DbType.String,"StatusName",DataRowVersion.Current);
				Database.AddInParameter(command,"oldFormDocumentStatusID",DbType.Int32,"FormDocumentStatusID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From FormDocumentStatus using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteFormDocumentStatus( int formDocumentStatusID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteFormDocumentStatus");
			Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,formDocumentStatusID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From FormDocumentStatus Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteFormDocumentStatusCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteFormDocumentStatus");
				Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,"FormDocumentStatusID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormDocumentStatus using Stored Procedure
		/// and return number of rows effected of the FormDocumentStatus
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormDocumentStatus",InsertNewFormDocumentStatusCommand(),UpdateFormDocumentStatusCommand(),DeleteFormDocumentStatusCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormDocumentStatus using Stored Procedure
		/// and return number of rows effected of the FormDocumentStatus
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormDocumentStatus",InsertNewFormDocumentStatusCommand(),UpdateFormDocumentStatusCommand(),DeleteFormDocumentStatusCommand(), transaction);
          return rowsAffected;
		}


	}
}
