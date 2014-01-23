using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for ArticleCategory table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ArticleCategory table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ArticleCategoryDAC : DataAccessComponent
	{
		#region Constructors
        public ArticleCategoryDAC() : base("", "ContentManagement.ArticleCategory") { }
		public ArticleCategoryDAC(string connectionString): base(connectionString){}
		public ArticleCategoryDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleCategory using Stored Procedure
		/// and return a DataTable containing all ArticleCategory Data
		/// </summary>
		public DataTable GetAllArticleCategory()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleCategory";
         string query = " select * from GetAllArticleCategory";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ArticleCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleCategory using Stored Procedure
		/// and return a DataTable containing all ArticleCategory Data using a Transaction
		/// </summary>
		public DataTable GetAllArticleCategory(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleCategory";
         string query = " select * from GetAllArticleCategory";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ArticleCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleCategory using Stored Procedure
		/// and return a DataTable containing all ArticleCategory Data
		/// </summary>
		public DataTable GetAllArticleCategory(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleCategory";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllArticleCategory" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ArticleCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleCategory using Stored Procedure
		/// and return a DataTable containing all ArticleCategory Data using a Transaction
		/// </summary>
		public DataTable GetAllArticleCategory(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleCategory";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllArticleCategory" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ArticleCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ArticleCategory using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticleCategory( int articleCategoryId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticleCategory");
				    Database.AddInParameter(command,"ArticleCategoryId",DbType.Int32,articleCategoryId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ArticleCategory using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticleCategory( int articleCategoryId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticleCategory");
				    Database.AddInParameter(command,"ArticleCategoryId",DbType.Int32,articleCategoryId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ArticleCategory using Stored Procedure
		/// and return the auto number primary key of ArticleCategory inserted row
		/// </summary>
		public bool InsertNewArticleCategory( ref int articleCategoryId,  int siteCategoryId,  int articleId,  DateTime postDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleCategory");
				Database.AddOutParameter(command,"ArticleCategoryId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,siteCategoryId);
				Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
				Database.AddInParameter(command,"PostDate",DbType.DateTime,postDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 articleCategoryId = Convert.ToInt32(Database.GetParameterValue(command, "ArticleCategoryId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ArticleCategory using Stored Procedure
		/// and return the auto number primary key of ArticleCategory inserted row using Transaction
		/// </summary>
		public bool InsertNewArticleCategory( ref int articleCategoryId,  int siteCategoryId,  int articleId,  DateTime postDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleCategory");
				Database.AddOutParameter(command,"ArticleCategoryId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,siteCategoryId);
				Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
				Database.AddInParameter(command,"PostDate",DbType.DateTime,postDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 articleCategoryId = Convert.ToInt32(Database.GetParameterValue(command, "ArticleCategoryId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ArticleCategory using Stored Procedure
		/// and return DbCommand of the ArticleCategory
		/// </summary>
		public DbCommand InsertNewArticleCategoryCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleCategory");

				Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,"SiteCategoryId",DataRowVersion.Current);
				Database.AddInParameter(command,"ArticleId",DbType.Int32,"ArticleId",DataRowVersion.Current);
				Database.AddInParameter(command,"PostDate",DbType.DateTime,"PostDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ArticleCategory using Stored Procedure
		/// </summary>
		public bool UpdateArticleCategory( int siteCategoryId, int articleId, DateTime postDate, int oldarticleCategoryId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleCategory");

		    		Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,siteCategoryId);
		    		Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
		    		Database.AddInParameter(command,"PostDate",DbType.DateTime,postDate);
				Database.AddInParameter(command,"oldArticleCategoryId",DbType.Int32,oldarticleCategoryId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ArticleCategory using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateArticleCategory( int siteCategoryId, int articleId, DateTime postDate, int oldarticleCategoryId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleCategory");

		    		Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,siteCategoryId);
		    		Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
		    		Database.AddInParameter(command,"PostDate",DbType.DateTime,postDate);
				Database.AddInParameter(command,"oldArticleCategoryId",DbType.Int32,oldarticleCategoryId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ArticleCategory using Stored Procedure
		/// </summary>
		public DbCommand UpdateArticleCategoryCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleCategory");

		    		Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,"SiteCategoryId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ArticleId",DbType.Int32,"ArticleId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PostDate",DbType.DateTime,"PostDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldArticleCategoryId",DbType.Int32,"ArticleCategoryId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ArticleCategory using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteArticleCategory( int articleCategoryId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteArticleCategory");
			Database.AddInParameter(command,"ArticleCategoryId",DbType.Int32,articleCategoryId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

        public bool DeleteArticleCategoryByArticleId(int articleId)
        {
            DbCommand command = Database.GetStoredProcCommand("DeleteArticleCategoryByArticleId");
            Database.AddInParameter(command, "ArticleId", DbType.Int32, articleId);
            bool status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                status = true;
            }
            return status;
        }

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ArticleCategory Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteArticleCategoryCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteArticleCategory");
				Database.AddInParameter(command,"ArticleCategoryId",DbType.Int32,"ArticleCategoryId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ArticleCategory using Stored Procedure
		/// and return number of rows effected of the ArticleCategory
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ArticleCategory",InsertNewArticleCategoryCommand(),UpdateArticleCategoryCommand(),DeleteArticleCategoryCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ArticleCategory using Stored Procedure
		/// and return number of rows effected of the ArticleCategory
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ArticleCategory",InsertNewArticleCategoryCommand(),UpdateArticleCategoryCommand(),DeleteArticleCategoryCommand(), transaction);
          return rowsAffected;
		}


	}
}
