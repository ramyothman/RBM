using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for CommentStatus table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the CommentStatus table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class CommentStatusDAC : DataAccessComponent
	{
		#region Constructors
        public CommentStatusDAC() : base("", "ContentManagement.CommentStatus") { }
		public CommentStatusDAC(string connectionString): base(connectionString){}
		public CommentStatusDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all CommentStatus using Stored Procedure
		/// and return a DataTable containing all CommentStatus Data
		/// </summary>
		public DataTable GetAllCommentStatus()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "CommentStatus";
         string query = " select * from GetAllCommentStatus";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["CommentStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all CommentStatus using Stored Procedure
		/// and return a DataTable containing all CommentStatus Data using a Transaction
		/// </summary>
		public DataTable GetAllCommentStatus(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "CommentStatus";
         string query = " select * from GetAllCommentStatus";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["CommentStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all CommentStatus using Stored Procedure
		/// and return a DataTable containing all CommentStatus Data
		/// </summary>
		public DataTable GetAllCommentStatus(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "CommentStatus";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllCommentStatus" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["CommentStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all CommentStatus using Stored Procedure
		/// and return a DataTable containing all CommentStatus Data using a Transaction
		/// </summary>
		public DataTable GetAllCommentStatus(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "CommentStatus";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllCommentStatus" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["CommentStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From CommentStatus using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDCommentStatus( int commentStatusId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDCommentStatus");
				    Database.AddInParameter(command,"CommentStatusId",DbType.Int32,commentStatusId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From CommentStatus using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDCommentStatus( int commentStatusId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDCommentStatus");
				    Database.AddInParameter(command,"CommentStatusId",DbType.Int32,commentStatusId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into CommentStatus using Stored Procedure
		/// and return the auto number primary key of CommentStatus inserted row
		/// </summary>
		public bool InsertNewCommentStatus( ref int commentStatusId,  string commentStatusName)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewCommentStatus");
				Database.AddOutParameter(command,"CommentStatusId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"CommentStatusName",DbType.String,commentStatusName);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 commentStatusId = Convert.ToInt32(Database.GetParameterValue(command, "CommentStatusId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into CommentStatus using Stored Procedure
		/// and return the auto number primary key of CommentStatus inserted row using Transaction
		/// </summary>
		public bool InsertNewCommentStatus( ref int commentStatusId,  string commentStatusName,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewCommentStatus");
				Database.AddOutParameter(command,"CommentStatusId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"CommentStatusName",DbType.String,commentStatusName);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 commentStatusId = Convert.ToInt32(Database.GetParameterValue(command, "CommentStatusId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for CommentStatus using Stored Procedure
		/// and return DbCommand of the CommentStatus
		/// </summary>
		public DbCommand InsertNewCommentStatusCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewCommentStatus");

				Database.AddInParameter(command,"CommentStatusName",DbType.String,"CommentStatusName",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into CommentStatus using Stored Procedure
		/// </summary>
		public bool UpdateCommentStatus( string commentStatusName, int oldcommentStatusId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateCommentStatus");

		    		Database.AddInParameter(command,"CommentStatusName",DbType.String,commentStatusName);
				Database.AddInParameter(command,"oldCommentStatusId",DbType.Int32,oldcommentStatusId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into CommentStatus using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateCommentStatus( string commentStatusName, int oldcommentStatusId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateCommentStatus");

		    		Database.AddInParameter(command,"CommentStatusName",DbType.String,commentStatusName);
				Database.AddInParameter(command,"oldCommentStatusId",DbType.Int32,oldcommentStatusId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from CommentStatus using Stored Procedure
		/// </summary>
		public DbCommand UpdateCommentStatusCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateCommentStatus");

		    		Database.AddInParameter(command,"CommentStatusName",DbType.String,"CommentStatusName",DataRowVersion.Current);
				Database.AddInParameter(command,"oldCommentStatusId",DbType.Int32,"CommentStatusId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From CommentStatus using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteCommentStatus( int commentStatusId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteCommentStatus");
			Database.AddInParameter(command,"CommentStatusId",DbType.Int32,commentStatusId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From CommentStatus Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteCommentStatusCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteCommentStatus");
				Database.AddInParameter(command,"CommentStatusId",DbType.Int32,"CommentStatusId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table CommentStatus using Stored Procedure
		/// and return number of rows effected of the CommentStatus
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"CommentStatus",InsertNewCommentStatusCommand(),UpdateCommentStatusCommand(),DeleteCommentStatusCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table CommentStatus using Stored Procedure
		/// and return number of rows effected of the CommentStatus
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"CommentStatus",InsertNewCommentStatusCommand(),UpdateCommentStatusCommand(),DeleteCommentStatusCommand(), transaction);
          return rowsAffected;
		}


	}
}
