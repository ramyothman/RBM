using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for ContentModuleArticle table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ContentModuleArticle table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ContentModuleArticleDAC : DataAccessComponent
	{
		#region Constructors
        public ContentModuleArticleDAC() : base("", "ContentManagement.ContentModuleArticle") { }
		public ContentModuleArticleDAC(string connectionString): base(connectionString){}
		public ContentModuleArticleDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContentModuleArticle using Stored Procedure
		/// and return a DataTable containing all ContentModuleArticle Data
		/// </summary>
		public DataTable GetAllContentModuleArticle()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContentModuleArticle";
         string query = " select * from GetAllContentModuleArticle";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ContentModuleArticle"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContentModuleArticle using Stored Procedure
		/// and return a DataTable containing all ContentModuleArticle Data using a Transaction
		/// </summary>
		public DataTable GetAllContentModuleArticle(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContentModuleArticle";
         string query = " select * from GetAllContentModuleArticle";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ContentModuleArticle"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContentModuleArticle using Stored Procedure
		/// and return a DataTable containing all ContentModuleArticle Data
		/// </summary>
		public DataTable GetAllContentModuleArticle(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContentModuleArticle";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllContentModuleArticle" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ContentModuleArticle"];

		}

        public DataTable GetAllContentModuleArticleOrdered(string where)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ContentModuleArticle";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = " select * from GetAllContentModuleArticle" + whereClause + " Order By ArticleOrder, ContentModuleArticleID desc";
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["ContentModuleArticle"];

        }



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContentModuleArticle using Stored Procedure
		/// and return a DataTable containing all ContentModuleArticle Data using a Transaction
		/// </summary>
		public DataTable GetAllContentModuleArticle(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContentModuleArticle";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllContentModuleArticle" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ContentModuleArticle"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ContentModuleArticle using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDContentModuleArticle( int contentModuleArticleID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDContentModuleArticle");
				    Database.AddInParameter(command,"ContentModuleArticleID",DbType.Int32,contentModuleArticleID);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ContentModuleArticle using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDContentModuleArticle( int contentModuleArticleID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDContentModuleArticle");
				    Database.AddInParameter(command,"ContentModuleArticleID",DbType.Int32,contentModuleArticleID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ContentModuleArticle using Stored Procedure
		/// and return the auto number primary key of ContentModuleArticle inserted row
		/// </summary>
		public bool InsertNewContentModuleArticle( ref int contentModuleArticleID,  int homePageID,  int articleID,  int articleOrder)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewContentModuleArticle");
				Database.AddOutParameter(command,"ContentModuleArticleID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"HomePageID",DbType.Int32,homePageID);
				Database.AddInParameter(command,"ArticleID",DbType.Int32,articleID);
				Database.AddInParameter(command,"ArticleOrder",DbType.Int32,articleOrder);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 contentModuleArticleID = Convert.ToInt32(Database.GetParameterValue(command, "ContentModuleArticleID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ContentModuleArticle using Stored Procedure
		/// and return the auto number primary key of ContentModuleArticle inserted row using Transaction
		/// </summary>
		public bool InsertNewContentModuleArticle( ref int contentModuleArticleID,  int homePageID,  int articleID,  int articleOrder,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewContentModuleArticle");
				Database.AddOutParameter(command,"ContentModuleArticleID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"HomePageID",DbType.Int32,homePageID);
				Database.AddInParameter(command,"ArticleID",DbType.Int32,articleID);
				Database.AddInParameter(command,"ArticleOrder",DbType.Int32,articleOrder);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 contentModuleArticleID = Convert.ToInt32(Database.GetParameterValue(command, "ContentModuleArticleID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ContentModuleArticle using Stored Procedure
		/// and return DbCommand of the ContentModuleArticle
		/// </summary>
		public DbCommand InsertNewContentModuleArticleCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewContentModuleArticle");

				Database.AddInParameter(command,"HomePageID",DbType.Int32,"HomePageID",DataRowVersion.Current);
				Database.AddInParameter(command,"ArticleID",DbType.Int32,"ArticleID",DataRowVersion.Current);
				Database.AddInParameter(command,"ArticleOrder",DbType.Int32,"ArticleOrder",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ContentModuleArticle using Stored Procedure
		/// </summary>
		public bool UpdateContentModuleArticle( int homePageID, int articleID, int articleOrder, int oldcontentModuleArticleID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateContentModuleArticle");

		    		Database.AddInParameter(command,"HomePageID",DbType.Int32,homePageID);
		    		Database.AddInParameter(command,"ArticleID",DbType.Int32,articleID);
		    		Database.AddInParameter(command,"ArticleOrder",DbType.Int32,articleOrder);
				Database.AddInParameter(command,"oldContentModuleArticleID",DbType.Int32,oldcontentModuleArticleID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ContentModuleArticle using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateContentModuleArticle( int homePageID, int articleID, int articleOrder, int oldcontentModuleArticleID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateContentModuleArticle");

		    		Database.AddInParameter(command,"HomePageID",DbType.Int32,homePageID);
		    		Database.AddInParameter(command,"ArticleID",DbType.Int32,articleID);
		    		Database.AddInParameter(command,"ArticleOrder",DbType.Int32,articleOrder);
				Database.AddInParameter(command,"oldContentModuleArticleID",DbType.Int32,oldcontentModuleArticleID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ContentModuleArticle using Stored Procedure
		/// </summary>
		public DbCommand UpdateContentModuleArticleCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateContentModuleArticle");

		    		Database.AddInParameter(command,"HomePageID",DbType.Int32,"HomePageID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ArticleID",DbType.Int32,"ArticleID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ArticleOrder",DbType.Int32,"ArticleOrder",DataRowVersion.Current);
				Database.AddInParameter(command,"oldContentModuleArticleID",DbType.Int32,"ContentModuleArticleID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ContentModuleArticle using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteContentModuleArticle( int contentModuleArticleID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteContentModuleArticle");
			Database.AddInParameter(command,"ContentModuleArticleID",DbType.Int32,contentModuleArticleID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ContentModuleArticle Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteContentModuleArticleCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteContentModuleArticle");
				Database.AddInParameter(command,"ContentModuleArticleID",DbType.Int32,"ContentModuleArticleID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ContentModuleArticle using Stored Procedure
		/// and return number of rows effected of the ContentModuleArticle
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ContentModuleArticle",InsertNewContentModuleArticleCommand(),UpdateContentModuleArticleCommand(),DeleteContentModuleArticleCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ContentModuleArticle using Stored Procedure
		/// and return number of rows effected of the ContentModuleArticle
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ContentModuleArticle",InsertNewContentModuleArticleCommand(),UpdateContentModuleArticleCommand(),DeleteContentModuleArticleCommand(), transaction);
          return rowsAffected;
		}


	}
}
