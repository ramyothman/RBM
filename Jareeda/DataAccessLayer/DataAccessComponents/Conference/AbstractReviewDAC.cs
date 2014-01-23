using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for AbstractReview table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the AbstractReview table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class AbstractReviewDAC : DataAccessComponent
	{
		#region Constructors
        public AbstractReviewDAC() : base("", "Conference.AbstractReview") { }
		public AbstractReviewDAC(string connectionString): base(connectionString){}
		public AbstractReviewDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractReview using Stored Procedure
		/// and return a DataTable containing all AbstractReview Data
		/// </summary>
		public DataTable GetAllAbstractReview()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractReview";
         string query = " select * from GetAllAbstractReview";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["AbstractReview"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractReview using Stored Procedure
		/// and return a DataTable containing all AbstractReview Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstractReview(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractReview";
         string query = " select * from GetAllAbstractReview";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["AbstractReview"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractReview using Stored Procedure
		/// and return a DataTable containing all AbstractReview Data
		/// </summary>
		public DataTable GetAllAbstractReview(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractReview";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllAbstractReview" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["AbstractReview"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractReview using Stored Procedure
		/// and return a DataTable containing all AbstractReview Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstractReview(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractReview";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllAbstractReview" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["AbstractReview"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From AbstractReview using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstractReview( int abstractReviewId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstractReview");
				    Database.AddInParameter(command,"AbstractReviewId",DbType.Int32,abstractReviewId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From AbstractReview using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstractReview( int abstractReviewId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstractReview");
				    Database.AddInParameter(command,"AbstractReviewId",DbType.Int32,abstractReviewId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into AbstractReview using Stored Procedure
		/// and return the auto number primary key of AbstractReview inserted row
		/// </summary>
		public bool InsertNewAbstractReview( int abstractReviewId,  int abstractReviewerAssignmentId,  int abstractStatusId,  string reviewerFeedback,  DateTime dateSubmitted)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractReview");
				Database.AddInParameter(command,"AbstractReviewId",DbType.Int32,abstractReviewId);
				Database.AddInParameter(command,"AbstractReviewerAssignmentId",DbType.Int32,abstractReviewerAssignmentId);
				Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,abstractStatusId);
				Database.AddInParameter(command,"ReviewerFeedback",DbType.String,reviewerFeedback);
				Database.AddInParameter(command,"DateSubmitted",DbType.DateTime,dateSubmitted);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into AbstractReview using Stored Procedure
		/// and return the auto number primary key of AbstractReview inserted row using Transaction
		/// </summary>
		public bool InsertNewAbstractReview( int abstractReviewId,  int abstractReviewerAssignmentId,  int abstractStatusId,  string reviewerFeedback,  DateTime dateSubmitted,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractReview");
				Database.AddInParameter(command,"AbstractReviewId",DbType.Int32,abstractReviewId);
				Database.AddInParameter(command,"AbstractReviewerAssignmentId",DbType.Int32,abstractReviewerAssignmentId);
				Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,abstractStatusId);
				Database.AddInParameter(command,"ReviewerFeedback",DbType.String,reviewerFeedback);
				Database.AddInParameter(command,"DateSubmitted",DbType.DateTime,dateSubmitted);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for AbstractReview using Stored Procedure
		/// and return DbCommand of the AbstractReview
		/// </summary>
		public DbCommand InsertNewAbstractReviewCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractReview");
				Database.AddInParameter(command,"AbstractReviewId",DbType.Int32,"AbstractReviewId",DataRowVersion.Current);
				Database.AddInParameter(command,"AbstractReviewerAssignmentId",DbType.Int32,"AbstractReviewerAssignmentId",DataRowVersion.Current);
				Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,"AbstractStatusId",DataRowVersion.Current);
				Database.AddInParameter(command,"ReviewerFeedback",DbType.String,"ReviewerFeedback",DataRowVersion.Current);
				Database.AddInParameter(command,"DateSubmitted",DbType.DateTime,"DateSubmitted",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into AbstractReview using Stored Procedure
		/// </summary>
		public bool UpdateAbstractReview( int abstractReviewId, int abstractReviewerAssignmentId, int abstractStatusId, string reviewerFeedback, DateTime dateSubmitted, int oldabstractReviewId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractReview");
		    		Database.AddInParameter(command,"AbstractReviewId",DbType.Int32,abstractReviewId);
		    		Database.AddInParameter(command,"AbstractReviewerAssignmentId",DbType.Int32,abstractReviewerAssignmentId);
		    		Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,abstractStatusId);
		    		Database.AddInParameter(command,"ReviewerFeedback",DbType.String,reviewerFeedback);
		    		Database.AddInParameter(command,"DateSubmitted",DbType.DateTime,dateSubmitted);
				Database.AddInParameter(command,"oldAbstractReviewId",DbType.Int32,oldabstractReviewId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into AbstractReview using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateAbstractReview( int abstractReviewId, int abstractReviewerAssignmentId, int abstractStatusId, string reviewerFeedback, DateTime dateSubmitted, int oldabstractReviewId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractReview");
		    		Database.AddInParameter(command,"AbstractReviewId",DbType.Int32,abstractReviewId);
		    		Database.AddInParameter(command,"AbstractReviewerAssignmentId",DbType.Int32,abstractReviewerAssignmentId);
		    		Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,abstractStatusId);
		    		Database.AddInParameter(command,"ReviewerFeedback",DbType.String,reviewerFeedback);
		    		Database.AddInParameter(command,"DateSubmitted",DbType.DateTime,dateSubmitted);
				Database.AddInParameter(command,"oldAbstractReviewId",DbType.Int32,oldabstractReviewId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from AbstractReview using Stored Procedure
		/// </summary>
		public DbCommand UpdateAbstractReviewCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractReview");
		    		Database.AddInParameter(command,"AbstractReviewId",DbType.Int32,"AbstractReviewId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AbstractReviewerAssignmentId",DbType.Int32,"AbstractReviewerAssignmentId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,"AbstractStatusId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ReviewerFeedback",DbType.String,"ReviewerFeedback",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DateSubmitted",DbType.DateTime,"DateSubmitted",DataRowVersion.Current);
				Database.AddInParameter(command,"oldAbstractReviewId",DbType.Int32,"AbstractReviewId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From AbstractReview using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteAbstractReview( int abstractReviewId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteAbstractReview");
			Database.AddInParameter(command,"AbstractReviewId",DbType.Int32,abstractReviewId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From AbstractReview Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteAbstractReviewCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteAbstractReview");
				Database.AddInParameter(command,"AbstractReviewId",DbType.Int32,"AbstractReviewId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table AbstractReview using Stored Procedure
		/// and return number of rows effected of the AbstractReview
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"AbstractReview",InsertNewAbstractReviewCommand(),UpdateAbstractReviewCommand(),DeleteAbstractReviewCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table AbstractReview using Stored Procedure
		/// and return number of rows effected of the AbstractReview
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"AbstractReview",InsertNewAbstractReviewCommand(),UpdateAbstractReviewCommand(),DeleteAbstractReviewCommand(), transaction);
          return rowsAffected;
		}


	}
}
