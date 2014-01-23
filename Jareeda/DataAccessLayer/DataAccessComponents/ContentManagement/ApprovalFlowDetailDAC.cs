using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for ApprovalFlowDetail table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ApprovalFlowDetail table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ApprovalFlowDetailDAC : DataAccessComponent
	{
		#region Constructors
        public ApprovalFlowDetailDAC() : base("", "ContentManagement.ApprovalFlowDetail") { }
		public ApprovalFlowDetailDAC(string connectionString): base(connectionString){}
		public ApprovalFlowDetailDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ApprovalFlowDetail using Stored Procedure
		/// and return a DataTable containing all ApprovalFlowDetail Data
		/// </summary>
		public DataTable GetAllApprovalFlowDetail()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ApprovalFlowDetail";
         string query = " select * from GetAllApprovalFlowDetail";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ApprovalFlowDetail"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ApprovalFlowDetail using Stored Procedure
		/// and return a DataTable containing all ApprovalFlowDetail Data using a Transaction
		/// </summary>
		public DataTable GetAllApprovalFlowDetail(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ApprovalFlowDetail";
         string query = " select * from GetAllApprovalFlowDetail";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ApprovalFlowDetail"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ApprovalFlowDetail using Stored Procedure
		/// and return a DataTable containing all ApprovalFlowDetail Data
		/// </summary>
		public DataTable GetAllApprovalFlowDetail(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ApprovalFlowDetail";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllApprovalFlowDetail" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ApprovalFlowDetail"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ApprovalFlowDetail using Stored Procedure
		/// and return a DataTable containing all ApprovalFlowDetail Data using a Transaction
		/// </summary>
		public DataTable GetAllApprovalFlowDetail(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ApprovalFlowDetail";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllApprovalFlowDetail" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ApprovalFlowDetail"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ApprovalFlowDetail using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDApprovalFlowDetail( int approvalFlowDetailID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDApprovalFlowDetail");
				    Database.AddInParameter(command,"ApprovalFlowDetailID",DbType.Int32,approvalFlowDetailID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ApprovalFlowDetail using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDApprovalFlowDetail( int approvalFlowDetailID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDApprovalFlowDetail");
				    Database.AddInParameter(command,"ApprovalFlowDetailID",DbType.Int32,approvalFlowDetailID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ApprovalFlowDetail using Stored Procedure
		/// and return the auto number primary key of ApprovalFlowDetail inserted row
		/// </summary>
		public bool InsertNewApprovalFlowDetail( int approvalFlowDetailID,  int approvalFlowID,  int orderNumber,  int articleStatusID,  int userID,  int statusDurationInHours)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewApprovalFlowDetail");
				Database.AddInParameter(command,"ApprovalFlowDetailID",DbType.Int32,approvalFlowDetailID);
				Database.AddInParameter(command,"ApprovalFlowID",DbType.Int32,approvalFlowID);
				Database.AddInParameter(command,"OrderNumber",DbType.Int32,orderNumber);
				Database.AddInParameter(command,"ArticleStatusID",DbType.Int32,articleStatusID);
				Database.AddInParameter(command,"UserID",DbType.Int32,userID);
				Database.AddInParameter(command,"StatusDurationInHours",DbType.Int32,statusDurationInHours);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ApprovalFlowDetail using Stored Procedure
		/// and return the auto number primary key of ApprovalFlowDetail inserted row using Transaction
		/// </summary>
		public bool InsertNewApprovalFlowDetail( int approvalFlowDetailID,  int approvalFlowID,  int orderNumber,  int articleStatusID,  int userID,  int statusDurationInHours,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewApprovalFlowDetail");
				Database.AddInParameter(command,"ApprovalFlowDetailID",DbType.Int32,approvalFlowDetailID);
				Database.AddInParameter(command,"ApprovalFlowID",DbType.Int32,approvalFlowID);
				Database.AddInParameter(command,"OrderNumber",DbType.Int32,orderNumber);
				Database.AddInParameter(command,"ArticleStatusID",DbType.Int32,articleStatusID);
				Database.AddInParameter(command,"UserID",DbType.Int32,userID);
				Database.AddInParameter(command,"StatusDurationInHours",DbType.Int32,statusDurationInHours);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ApprovalFlowDetail using Stored Procedure
		/// and return DbCommand of the ApprovalFlowDetail
		/// </summary>
		public DbCommand InsertNewApprovalFlowDetailCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewApprovalFlowDetail");
				Database.AddInParameter(command,"ApprovalFlowDetailID",DbType.Int32,"ApprovalFlowDetailID",DataRowVersion.Current);
				Database.AddInParameter(command,"ApprovalFlowID",DbType.Int32,"ApprovalFlowID",DataRowVersion.Current);
				Database.AddInParameter(command,"OrderNumber",DbType.Int32,"OrderNumber",DataRowVersion.Current);
				Database.AddInParameter(command,"ArticleStatusID",DbType.Int32,"ArticleStatusID",DataRowVersion.Current);
				Database.AddInParameter(command,"UserID",DbType.Int32,"UserID",DataRowVersion.Current);
				Database.AddInParameter(command,"StatusDurationInHours",DbType.Int32,"StatusDurationInHours",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ApprovalFlowDetail using Stored Procedure
		/// </summary>
		public bool UpdateApprovalFlowDetail( int approvalFlowDetailID, int approvalFlowID, int orderNumber, int articleStatusID, int userID, int statusDurationInHours, int oldapprovalFlowDetailID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateApprovalFlowDetail");
		    		Database.AddInParameter(command,"ApprovalFlowDetailID",DbType.Int32,approvalFlowDetailID);
		    		Database.AddInParameter(command,"ApprovalFlowID",DbType.Int32,approvalFlowID);
		    		Database.AddInParameter(command,"OrderNumber",DbType.Int32,orderNumber);
		    		Database.AddInParameter(command,"ArticleStatusID",DbType.Int32,articleStatusID);
		    		Database.AddInParameter(command,"UserID",DbType.Int32,userID);
		    		Database.AddInParameter(command,"StatusDurationInHours",DbType.Int32,statusDurationInHours);
				Database.AddInParameter(command,"oldApprovalFlowDetailID",DbType.Int32,oldapprovalFlowDetailID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ApprovalFlowDetail using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateApprovalFlowDetail( int approvalFlowDetailID, int approvalFlowID, int orderNumber, int articleStatusID, int userID, int statusDurationInHours, int oldapprovalFlowDetailID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateApprovalFlowDetail");
		    		Database.AddInParameter(command,"ApprovalFlowDetailID",DbType.Int32,approvalFlowDetailID);
		    		Database.AddInParameter(command,"ApprovalFlowID",DbType.Int32,approvalFlowID);
		    		Database.AddInParameter(command,"OrderNumber",DbType.Int32,orderNumber);
		    		Database.AddInParameter(command,"ArticleStatusID",DbType.Int32,articleStatusID);
		    		Database.AddInParameter(command,"UserID",DbType.Int32,userID);
		    		Database.AddInParameter(command,"StatusDurationInHours",DbType.Int32,statusDurationInHours);
				Database.AddInParameter(command,"oldApprovalFlowDetailID",DbType.Int32,oldapprovalFlowDetailID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ApprovalFlowDetail using Stored Procedure
		/// </summary>
		public DbCommand UpdateApprovalFlowDetailCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateApprovalFlowDetail");
		    		Database.AddInParameter(command,"ApprovalFlowDetailID",DbType.Int32,"ApprovalFlowDetailID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ApprovalFlowID",DbType.Int32,"ApprovalFlowID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"OrderNumber",DbType.Int32,"OrderNumber",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ArticleStatusID",DbType.Int32,"ArticleStatusID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"UserID",DbType.Int32,"UserID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"StatusDurationInHours",DbType.Int32,"StatusDurationInHours",DataRowVersion.Current);
				Database.AddInParameter(command,"oldApprovalFlowDetailID",DbType.Int32,"ApprovalFlowDetailID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ApprovalFlowDetail using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteApprovalFlowDetail( int approvalFlowDetailID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteApprovalFlowDetail");
			Database.AddInParameter(command,"ApprovalFlowDetailID",DbType.Int32,approvalFlowDetailID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ApprovalFlowDetail Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteApprovalFlowDetailCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteApprovalFlowDetail");
				Database.AddInParameter(command,"ApprovalFlowDetailID",DbType.Int32,"ApprovalFlowDetailID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ApprovalFlowDetail using Stored Procedure
		/// and return number of rows effected of the ApprovalFlowDetail
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ApprovalFlowDetail",InsertNewApprovalFlowDetailCommand(),UpdateApprovalFlowDetailCommand(),DeleteApprovalFlowDetailCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ApprovalFlowDetail using Stored Procedure
		/// and return number of rows effected of the ApprovalFlowDetail
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ApprovalFlowDetail",InsertNewApprovalFlowDetailCommand(),UpdateApprovalFlowDetailCommand(),DeleteApprovalFlowDetailCommand(), transaction);
          return rowsAffected;
		}


	}
}
