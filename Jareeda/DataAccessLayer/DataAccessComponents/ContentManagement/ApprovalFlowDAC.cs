using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for ApprovalFlow table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ApprovalFlow table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ApprovalFlowDAC : DataAccessComponent
	{
		#region Constructors
        public ApprovalFlowDAC() : base("", "ContentManagement.ApprovalFlow") { }
		public ApprovalFlowDAC(string connectionString): base(connectionString){}
		public ApprovalFlowDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ApprovalFlow using Stored Procedure
		/// and return a DataTable containing all ApprovalFlow Data
		/// </summary>
		public DataTable GetAllApprovalFlow()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ApprovalFlow";
         string query = " select * from GetAllApprovalFlow";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ApprovalFlow"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ApprovalFlow using Stored Procedure
		/// and return a DataTable containing all ApprovalFlow Data using a Transaction
		/// </summary>
		public DataTable GetAllApprovalFlow(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ApprovalFlow";
         string query = " select * from GetAllApprovalFlow";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ApprovalFlow"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ApprovalFlow using Stored Procedure
		/// and return a DataTable containing all ApprovalFlow Data
		/// </summary>
		public DataTable GetAllApprovalFlow(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ApprovalFlow";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllApprovalFlow" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ApprovalFlow"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ApprovalFlow using Stored Procedure
		/// and return a DataTable containing all ApprovalFlow Data using a Transaction
		/// </summary>
		public DataTable GetAllApprovalFlow(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ApprovalFlow";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllApprovalFlow" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ApprovalFlow"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ApprovalFlow using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDApprovalFlow( int approvalFlowID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDApprovalFlow");
				    Database.AddInParameter(command,"ApprovalFlowID",DbType.Int32,approvalFlowID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ApprovalFlow using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDApprovalFlow( int approvalFlowID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDApprovalFlow");
				    Database.AddInParameter(command,"ApprovalFlowID",DbType.Int32,approvalFlowID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ApprovalFlow using Stored Procedure
		/// and return the auto number primary key of ApprovalFlow inserted row
		/// </summary>
		public bool InsertNewApprovalFlow( ref int approvalFlowID,  int sectionID,  string title,  DateTime dateStart,  DateTime dateEnd,  int approvedBy)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewApprovalFlow");
				Database.AddOutParameter(command,"ApprovalFlowID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"DateStart",DbType.DateTime,dateStart);
				Database.AddInParameter(command,"DateEnd",DbType.DateTime,dateEnd);
				Database.AddInParameter(command,"ApprovedBy",DbType.Int32,approvedBy);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 approvalFlowID = Convert.ToInt32(Database.GetParameterValue(command, "ApprovalFlowID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ApprovalFlow using Stored Procedure
		/// and return the auto number primary key of ApprovalFlow inserted row using Transaction
		/// </summary>
		public bool InsertNewApprovalFlow( ref int approvalFlowID,  int sectionID,  string title,  DateTime dateStart,  DateTime dateEnd,  int approvedBy,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewApprovalFlow");
				Database.AddOutParameter(command,"ApprovalFlowID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"DateStart",DbType.DateTime,dateStart);
				Database.AddInParameter(command,"DateEnd",DbType.DateTime,dateEnd);
				Database.AddInParameter(command,"ApprovedBy",DbType.Int32,approvedBy);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 approvalFlowID = Convert.ToInt32(Database.GetParameterValue(command, "ApprovalFlowID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ApprovalFlow using Stored Procedure
		/// and return DbCommand of the ApprovalFlow
		/// </summary>
		public DbCommand InsertNewApprovalFlowCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewApprovalFlow");

				Database.AddInParameter(command,"SectionID",DbType.Int32,"SectionID",DataRowVersion.Current);
				Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
				Database.AddInParameter(command,"DateStart",DbType.DateTime,"DateStart",DataRowVersion.Current);
				Database.AddInParameter(command,"DateEnd",DbType.DateTime,"DateEnd",DataRowVersion.Current);
				Database.AddInParameter(command,"ApprovedBy",DbType.Int32,"ApprovedBy",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ApprovalFlow using Stored Procedure
		/// </summary>
		public bool UpdateApprovalFlow( int sectionID, string title, DateTime dateStart, DateTime dateEnd, int approvedBy, int oldapprovalFlowID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateApprovalFlow");

		    		Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"DateStart",DbType.DateTime,dateStart);
		    		Database.AddInParameter(command,"DateEnd",DbType.DateTime,dateEnd);
		    		Database.AddInParameter(command,"ApprovedBy",DbType.Int32,approvedBy);
				Database.AddInParameter(command,"oldApprovalFlowID",DbType.Int32,oldapprovalFlowID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ApprovalFlow using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateApprovalFlow( int sectionID, string title, DateTime dateStart, DateTime dateEnd, int approvedBy, int oldapprovalFlowID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateApprovalFlow");

		    		Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"DateStart",DbType.DateTime,dateStart);
		    		Database.AddInParameter(command,"DateEnd",DbType.DateTime,dateEnd);
		    		Database.AddInParameter(command,"ApprovedBy",DbType.Int32,approvedBy);
				Database.AddInParameter(command,"oldApprovalFlowID",DbType.Int32,oldapprovalFlowID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ApprovalFlow using Stored Procedure
		/// </summary>
		public DbCommand UpdateApprovalFlowCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateApprovalFlow");

		    		Database.AddInParameter(command,"SectionID",DbType.Int32,"SectionID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DateStart",DbType.DateTime,"DateStart",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DateEnd",DbType.DateTime,"DateEnd",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ApprovedBy",DbType.Int32,"ApprovedBy",DataRowVersion.Current);
				Database.AddInParameter(command,"oldApprovalFlowID",DbType.Int32,"ApprovalFlowID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ApprovalFlow using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteApprovalFlow( int approvalFlowID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteApprovalFlow");
			Database.AddInParameter(command,"ApprovalFlowID",DbType.Int32,approvalFlowID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ApprovalFlow Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteApprovalFlowCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteApprovalFlow");
				Database.AddInParameter(command,"ApprovalFlowID",DbType.Int32,"ApprovalFlowID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ApprovalFlow using Stored Procedure
		/// and return number of rows effected of the ApprovalFlow
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ApprovalFlow",InsertNewApprovalFlowCommand(),UpdateApprovalFlowCommand(),DeleteApprovalFlowCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ApprovalFlow using Stored Procedure
		/// and return number of rows effected of the ApprovalFlow
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ApprovalFlow",InsertNewApprovalFlowCommand(),UpdateApprovalFlowCommand(),DeleteApprovalFlowCommand(), transaction);
          return rowsAffected;
		}


	}
}
