using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for ArticleSources table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ArticleSources table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ArticleSourcesDAC : DataAccessComponent
	{
		#region Constructors
        public ArticleSourcesDAC() : base("", "ContentManagement.ArticleSources") { }
		public ArticleSourcesDAC(string connectionString): base(connectionString){}
		public ArticleSourcesDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleSources using Stored Procedure
		/// and return a DataTable containing all ArticleSources Data
		/// </summary>
		public DataTable GetAllArticleSources()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleSources";
         string query = " select * from GetAllArticleSources";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ArticleSources"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleSources using Stored Procedure
		/// and return a DataTable containing all ArticleSources Data using a Transaction
		/// </summary>
		public DataTable GetAllArticleSources(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleSources";
         string query = " select * from GetAllArticleSources";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ArticleSources"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleSources using Stored Procedure
		/// and return a DataTable containing all ArticleSources Data
		/// </summary>
		public DataTable GetAllArticleSources(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleSources";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllArticleSources" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ArticleSources"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleSources using Stored Procedure
		/// and return a DataTable containing all ArticleSources Data using a Transaction
		/// </summary>
		public DataTable GetAllArticleSources(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleSources";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllArticleSources" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ArticleSources"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ArticleSources using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticleSources( int articleSourceID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticleSources");
				    Database.AddInParameter(command,"ArticleSourceID",DbType.Int32,articleSourceID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ArticleSources using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticleSources( int articleSourceID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticleSources");
				    Database.AddInParameter(command,"ArticleSourceID",DbType.Int32,articleSourceID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ArticleSources using Stored Procedure
		/// and return the auto number primary key of ArticleSources inserted row
		/// </summary>
		public bool InsertNewArticleSources( ref int articleSourceID,  int sourceID,  int articleID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleSources");
				Database.AddOutParameter(command,"ArticleSourceID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SourceID",DbType.Int32,sourceID);
				Database.AddInParameter(command,"ArticleID",DbType.Int32,articleID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 articleSourceID = Convert.ToInt32(Database.GetParameterValue(command, "ArticleSourceID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ArticleSources using Stored Procedure
		/// and return the auto number primary key of ArticleSources inserted row using Transaction
		/// </summary>
		public bool InsertNewArticleSources( ref int articleSourceID,  int sourceID,  int articleID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleSources");
				Database.AddOutParameter(command,"ArticleSourceID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SourceID",DbType.Int32,sourceID);
				Database.AddInParameter(command,"ArticleID",DbType.Int32,articleID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 articleSourceID = Convert.ToInt32(Database.GetParameterValue(command, "ArticleSourceID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ArticleSources using Stored Procedure
		/// and return DbCommand of the ArticleSources
		/// </summary>
		public DbCommand InsertNewArticleSourcesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleSources");

				Database.AddInParameter(command,"SourceID",DbType.Int32,"SourceID",DataRowVersion.Current);
				Database.AddInParameter(command,"ArticleID",DbType.Int32,"ArticleID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ArticleSources using Stored Procedure
		/// </summary>
		public bool UpdateArticleSources( int sourceID, int articleID, int oldarticleSourceID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleSources");

		    		Database.AddInParameter(command,"SourceID",DbType.Int32,sourceID);
		    		Database.AddInParameter(command,"ArticleID",DbType.Int32,articleID);
				Database.AddInParameter(command,"oldArticleSourceID",DbType.Int32,oldarticleSourceID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ArticleSources using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateArticleSources( int sourceID, int articleID, int oldarticleSourceID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleSources");

		    		Database.AddInParameter(command,"SourceID",DbType.Int32,sourceID);
		    		Database.AddInParameter(command,"ArticleID",DbType.Int32,articleID);
				Database.AddInParameter(command,"oldArticleSourceID",DbType.Int32,oldarticleSourceID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ArticleSources using Stored Procedure
		/// </summary>
		public DbCommand UpdateArticleSourcesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleSources");

		    		Database.AddInParameter(command,"SourceID",DbType.Int32,"SourceID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ArticleID",DbType.Int32,"ArticleID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldArticleSourceID",DbType.Int32,"ArticleSourceID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ArticleSources using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteArticleSources( int articleSourceID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteArticleSources");
			Database.AddInParameter(command,"ArticleSourceID",DbType.Int32,articleSourceID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ArticleSources Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteArticleSourcesCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteArticleSources");
				Database.AddInParameter(command,"ArticleSourceID",DbType.Int32,"ArticleSourceID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ArticleSources using Stored Procedure
		/// and return number of rows effected of the ArticleSources
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ArticleSources",InsertNewArticleSourcesCommand(),UpdateArticleSourcesCommand(),DeleteArticleSourcesCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ArticleSources using Stored Procedure
		/// and return number of rows effected of the ArticleSources
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ArticleSources",InsertNewArticleSourcesCommand(),UpdateArticleSourcesCommand(),DeleteArticleSourcesCommand(), transaction);
          return rowsAffected;
		}


	}
}
