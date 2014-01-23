using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for ArticleComment table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ArticleComment table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ArticleCommentDAC : DataAccessComponent
	{
		#region Constructors
        public ArticleCommentDAC() : base("", "ContentManagement.ArticleComment") { }
		public ArticleCommentDAC(string connectionString): base(connectionString){}
		public ArticleCommentDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleComment using Stored Procedure
		/// and return a DataTable containing all ArticleComment Data
		/// </summary>
		public DataTable GetAllArticleComment()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleComment";
         string query = " select * from GetAllArticleComment";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ArticleComment"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleComment using Stored Procedure
		/// and return a DataTable containing all ArticleComment Data using a Transaction
		/// </summary>
		public DataTable GetAllArticleComment(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleComment";
         string query = " select * from GetAllArticleComment";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ArticleComment"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleComment using Stored Procedure
		/// and return a DataTable containing all ArticleComment Data
		/// </summary>
		public DataTable GetAllArticleComment(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleComment";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllArticleComment" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ArticleComment"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleComment using Stored Procedure
		/// and return a DataTable containing all ArticleComment Data using a Transaction
		/// </summary>
		public DataTable GetAllArticleComment(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleComment";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllArticleComment" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ArticleComment"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ArticleComment using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticleComment( int articleCommentId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticleComment");
				    Database.AddInParameter(command,"ArticleCommentId",DbType.Int32,articleCommentId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ArticleComment using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticleComment( int articleCommentId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticleComment");
				    Database.AddInParameter(command,"ArticleCommentId",DbType.Int32,articleCommentId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ArticleComment using Stored Procedure
		/// and return the auto number primary key of ArticleComment inserted row
		/// </summary>
		public bool InsertNewArticleComment( ref int articleCommentId,  int articleId,  string articleComment,  DateTime modifiedDate,  int personId,  int commentStatusId)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleComment");
				Database.AddOutParameter(command,"ArticleCommentId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
				Database.AddInParameter(command,"ArticleComment",DbType.String,articleComment);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"CommentStatusId",DbType.Int32,commentStatusId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 articleCommentId = Convert.ToInt32(Database.GetParameterValue(command, "ArticleCommentId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ArticleComment using Stored Procedure
		/// and return the auto number primary key of ArticleComment inserted row using Transaction
		/// </summary>
		public bool InsertNewArticleComment( ref int articleCommentId,  int articleId,  string articleComment,  DateTime modifiedDate,  int personId,  int commentStatusId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleComment");
				Database.AddOutParameter(command,"ArticleCommentId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
				Database.AddInParameter(command,"ArticleComment",DbType.String,articleComment);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"CommentStatusId",DbType.Int32,commentStatusId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 articleCommentId = Convert.ToInt32(Database.GetParameterValue(command, "ArticleCommentId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ArticleComment using Stored Procedure
		/// and return DbCommand of the ArticleComment
		/// </summary>
		public DbCommand InsertNewArticleCommentCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleComment");

				Database.AddInParameter(command,"ArticleId",DbType.Int32,"ArticleId",DataRowVersion.Current);
				Database.AddInParameter(command,"ArticleComment",DbType.String,"ArticleComment",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				Database.AddInParameter(command,"CommentStatusId",DbType.Int32,"CommentStatusId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ArticleComment using Stored Procedure
		/// </summary>
		public bool UpdateArticleComment( int articleId, string articleComment, DateTime modifiedDate, int personId, int commentStatusId, int oldarticleCommentId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleComment");

		    		Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
		    		Database.AddInParameter(command,"ArticleComment",DbType.String,articleComment);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"CommentStatusId",DbType.Int32,commentStatusId);
				Database.AddInParameter(command,"oldArticleCommentId",DbType.Int32,oldarticleCommentId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ArticleComment using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateArticleComment( int articleId, string articleComment, DateTime modifiedDate, int personId, int commentStatusId, int oldarticleCommentId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleComment");

		    		Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
		    		Database.AddInParameter(command,"ArticleComment",DbType.String,articleComment);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"CommentStatusId",DbType.Int32,commentStatusId);
				Database.AddInParameter(command,"oldArticleCommentId",DbType.Int32,oldarticleCommentId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ArticleComment using Stored Procedure
		/// </summary>
		public DbCommand UpdateArticleCommentCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleComment");

		    		Database.AddInParameter(command,"ArticleId",DbType.Int32,"ArticleId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ArticleComment",DbType.String,"ArticleComment",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CommentStatusId",DbType.Int32,"CommentStatusId",DataRowVersion.Current);
				Database.AddInParameter(command,"oldArticleCommentId",DbType.Int32,"ArticleCommentId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ArticleComment using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteArticleComment( int articleCommentId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteArticleComment");
			Database.AddInParameter(command,"ArticleCommentId",DbType.Int32,articleCommentId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ArticleComment Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteArticleCommentCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteArticleComment");
				Database.AddInParameter(command,"ArticleCommentId",DbType.Int32,"ArticleCommentId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ArticleComment using Stored Procedure
		/// and return number of rows effected of the ArticleComment
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ArticleComment",InsertNewArticleCommentCommand(),UpdateArticleCommentCommand(),DeleteArticleCommentCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ArticleComment using Stored Procedure
		/// and return number of rows effected of the ArticleComment
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ArticleComment",InsertNewArticleCommentCommand(),UpdateArticleCommentCommand(),DeleteArticleCommentCommand(), transaction);
          return rowsAffected;
		}


	}
}
