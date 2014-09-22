using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for Article table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Article table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ArticleDAC : DataAccessComponent
	{
		#region Constructors
        public ArticleDAC() : base("", "ContentManagement.Article", "ContentManagement.ArticleLanguage") { }
		public ArticleDAC(string connectionString): base(connectionString){}
		public ArticleDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Article using Stored Procedure
		/// and return a DataTable containing all Article Data
		/// </summary>
		public DataTable GetAllArticle()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Article";
         string query = " select * from GetAllArticle";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Article"];

		}





		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Article using Stored Procedure
		/// and return a DataTable containing all Article Data using a Transaction
		/// </summary>
		public DataTable GetAllArticle(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Article";
         string query = " select * from GetAllArticle";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Article"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Article using Stored Procedure
		/// and return a DataTable containing all Article Data
		/// </summary>
		public DataTable GetAllArticle(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Article";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllArticle" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Article"];

		}

        public DataTable GetAllArticleNew(string where)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "Article";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = " select Top 200 * from GetAllArticle" + whereClause + " Order By PostDate desc";
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["Article"];

        }

        public DataTable GetAllArticleByCountandOrder(string where,int Count)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "Article";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = " select Top  " + Count + " * from GetAllArticle" + whereClause + " and ArticleStatusID = 1 Order By PostDate desc";
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["Article"];

        }

        public DataTable GetAllArticleByCount(string where, int Count,string orderBy)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "Article";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = String.Format(" select Top  {0} * from GetAllArticle {1} and ArticleStatusID = 1 {2}", Count, whereClause, orderBy);
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["Article"];

        }



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Article using Stored Procedure
		/// and return a DataTable containing all Article Data using a Transaction
		/// </summary>
		public DataTable GetAllArticle(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Article";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllArticle" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Article"];

		}

        public DataTable GetAllArticleView()
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ViewCurrentArticles";
            string query = " select * from ViewCurrentArticles";
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["ViewCurrentArticles"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Article using Stored Procedure
        /// and return a DataTable containing all Article Data
        /// </summary>
        public DataTable GetAllArticleView(string where)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ViewCurrentArticles";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = " select * from ViewCurrentArticles" + whereClause;
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["ViewCurrentArticles"];

        }
        public DataTable ViewAllArticles()
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ViewAllArticles";
            string query = " select * from ViewAllArticles";
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["ViewAllArticles"];

        }
        public DataTable ViewAllArticles(string where)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ViewAllArticles";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = " select * from ViewAllArticles" + whereClause;
            DbCommand command = Database.GetSqlStringCommand(query);
            
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["ViewAllArticles"];

        }

        //ViewAllArticles

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Article using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticle( int articleId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticle");
				    Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

        public System.Data.IDataReader GetTotalArticlesByDate(int SiteID, DateTime date)
		{
            DbCommand command = Database.GetStoredProcCommand("GetTotalArticlesByDate");
                 Database.AddInParameter(command, "SiteID", DbType.Int32, SiteID);
                if(date == DateTime.MinValue)
                    Database.AddInParameter(command, "DateSelected", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "DateSelected", DbType.DateTime, date);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}
        
        public DateTime GetLastArticleDate(int SiteId)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "GetLastArticleDate";
            string query = " select dbo.GetLastArticleDate(" + SiteId + ")";
            DbCommand command = Database.GetSqlStringCommand(query);
            Database.LoadDataSet(command, ds, tableNames);
            DateTime dt = DateTime.MinValue;
            if (ds.Tables["GetLastArticleDate"].Rows.Count > 0)
            {
                dt = Convert.ToDateTime(ds.Tables["GetLastArticleDate"].Rows[0][0].ToString());
            }
            return dt;

        }
        public System.Data.IDataReader FindArticles(string LanguageID,string SiteID,string SearchCriteria)
        {
            DbCommand command = Database.GetStoredProcCommand("FindArticles");
            Database.AddInParameter(command, "LanguageID", DbType.String, LanguageID);
            Database.AddInParameter(command, "SearchCriteria", DbType.String, SearchCriteria);
            Database.AddInParameter(command, "SiteID", DbType.String, SiteID);
            IDataReader reader = this.FromCache(command).CreateDataReader();//Database.ExecuteReader(command);
            return reader;
        }

        public System.Data.IDataReader FindLastArticles(string LanguageID, string SiteID)
        {
            DbCommand command = Database.GetStoredProcCommand("FindLastArticles");
            Database.AddInParameter(command, "LanguageID", DbType.String, LanguageID);
            Database.AddInParameter(command, "SiteID", DbType.String, SiteID);
            IDataReader reader = this.FromCache(command).CreateDataReader();//Database.ExecuteReader(command);
            return reader;
        }


        public System.Data.IDataReader FindArticlesBySection(string LanguageID, string SiteID, string SearchCriteria)
        {
            DbCommand command = Database.GetStoredProcCommand("FindArticlesBySection");
            Database.AddInParameter(command, "LanguageID", DbType.String, LanguageID);
            Database.AddInParameter(command, "SearchCriteria", DbType.String, SearchCriteria);
            Database.AddInParameter(command, "SiteID", DbType.String, SiteID);
            IDataReader reader = this.FromCache(command).CreateDataReader();//Database.ExecuteReader(command);
            return reader;
        }

        public System.Data.IDataReader FindArticlesByAuthor(string LanguageID, string SiteID, string SearchCriteria)
        {
            DbCommand command = Database.GetStoredProcCommand("FindArticlesByAuthor");
            Database.AddInParameter(command, "LanguageID", DbType.String, LanguageID);
            Database.AddInParameter(command, "SearchCriteria", DbType.String, SearchCriteria);
            Database.AddInParameter(command, "SiteID", DbType.String, SiteID);
            IDataReader reader = this.FromCache(command).CreateDataReader();//Database.ExecuteReader(command);
            return reader;
        }

        /// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Article using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticle( int articleId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticle");
				    Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}
        public System.Data.IDataReader GetCurrentAnnouncement()
        {
            DbCommand command = Database.GetStoredProcCommand("GetCurrentAnnouncement");
            IDataReader reader =  Database.ExecuteReader(command);
            return reader;
        }
        
		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Article using Stored Procedure
		/// and return the auto number primary key of Article inserted row
		/// </summary>
        public bool InsertNewArticle(int articleId, int siteSectionId, int creatorId, int articleStatusId, int authorId, DateTime postDate, bool allowLanguageSpecificTags, Guid rowGuid, DateTime modifiedDate, int commentsTypeId, bool enableModeteration, int ArticleTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticle");
				Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
				Database.AddInParameter(command,"SiteSectionId",DbType.Int32,siteSectionId);
				Database.AddInParameter(command,"CreatorId",DbType.Int32,creatorId);
				Database.AddInParameter(command,"ArticleStatusId",DbType.Int32,articleStatusId);
				Database.AddInParameter(command,"AuthorId",DbType.Int32,authorId);
            if(postDate == DateTime.MinValue)
				Database.AddInParameter(command,"PostDate",DbType.DateTime,DBNull.Value);
            else
                Database.AddInParameter(command, "PostDate", DbType.DateTime, postDate);
            
				Database.AddInParameter(command,"AllowLanguageSpecificTags",DbType.Boolean,allowLanguageSpecificTags);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
            if(modifiedDate == DateTime.MinValue)
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,DBNull.Value);
            else
                Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, modifiedDate);
				Database.AddInParameter(command,"CommentsTypeId",DbType.Int32,commentsTypeId);
				Database.AddInParameter(command,"EnableModeteration",DbType.Boolean,enableModeteration);
                Database.AddInParameter(command, "ArticleTypeID", DbType.Int32, ArticleTypeID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Article using Stored Procedure
		/// and return the auto number primary key of Article inserted row using Transaction
		/// </summary>
        public bool InsertNewArticle(int articleId, int siteSectionId, int creatorId, int articleStatusId, int authorId, DateTime postDate, bool allowLanguageSpecificTags, Guid rowGuid, DateTime modifiedDate, int commentsTypeId, bool enableModeteration, int ArticleTypeID, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticle");
				Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
				Database.AddInParameter(command,"SiteSectionId",DbType.Int32,siteSectionId);
				Database.AddInParameter(command,"CreatorId",DbType.Int32,creatorId);
				Database.AddInParameter(command,"ArticleStatusId",DbType.Int32,articleStatusId);
				Database.AddInParameter(command,"AuthorId",DbType.Int32,authorId);
				Database.AddInParameter(command,"PostDate",DbType.DateTime,postDate);
				Database.AddInParameter(command,"AllowLanguageSpecificTags",DbType.Boolean,allowLanguageSpecificTags);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"CommentsTypeId",DbType.Int32,commentsTypeId);
				Database.AddInParameter(command,"EnableModeteration",DbType.Boolean,enableModeteration);
                Database.AddInParameter(command, "ArticleTypeID", DbType.Int32, ArticleTypeID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Article using Stored Procedure
		/// and return DbCommand of the Article
		/// </summary>
		public DbCommand InsertNewArticleCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticle");
				Database.AddInParameter(command,"ArticleId",DbType.Int32,"ArticleId",DataRowVersion.Current);
				Database.AddInParameter(command,"SiteSectionId",DbType.Int32,"SiteSectionId",DataRowVersion.Current);
				Database.AddInParameter(command,"CreatorId",DbType.Int32,"CreatorId",DataRowVersion.Current);
				Database.AddInParameter(command,"ArticleStatusId",DbType.Int32,"ArticleStatusId",DataRowVersion.Current);
				Database.AddInParameter(command,"AuthorId",DbType.Int32,"AuthorId",DataRowVersion.Current);
				Database.AddInParameter(command,"PostDate",DbType.DateTime,"PostDate",DataRowVersion.Current);
				Database.AddInParameter(command,"AllowLanguageSpecificTags",DbType.Boolean,"AllowLanguageSpecificTags",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"CommentsTypeId",DbType.Int32,"CommentsTypeId",DataRowVersion.Current);
				Database.AddInParameter(command,"EnableModeteration",DbType.Boolean,"EnableModeteration",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Article using Stored Procedure
		/// </summary>
        public bool UpdateArticle(int articleId, int siteSectionId, int creatorId, int articleStatusId, int authorId, DateTime postDate, bool allowLanguageSpecificTags, Guid rowGuid, DateTime modifiedDate, int commentsTypeId, bool enableModeteration, int ArticleTypeID, int oldarticleId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticle");
		    		Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
		    		Database.AddInParameter(command,"SiteSectionId",DbType.Int32,siteSectionId);
		    		Database.AddInParameter(command,"CreatorId",DbType.Int32,creatorId);
		    		Database.AddInParameter(command,"ArticleStatusId",DbType.Int32,articleStatusId);
		    		Database.AddInParameter(command,"AuthorId",DbType.Int32,authorId);
		    		Database.AddInParameter(command,"PostDate",DbType.DateTime,postDate);
		    		Database.AddInParameter(command,"AllowLanguageSpecificTags",DbType.Boolean,allowLanguageSpecificTags);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
		    		Database.AddInParameter(command,"CommentsTypeId",DbType.Int32,commentsTypeId);
		    		Database.AddInParameter(command,"EnableModeteration",DbType.Boolean,enableModeteration);
                    Database.AddInParameter(command, "ArticleTypeID", DbType.Int32, ArticleTypeID);
				Database.AddInParameter(command,"oldArticleId",DbType.Int32,oldarticleId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Article using Stored Procedure By Transaction
		/// </summary>
        public bool UpdateArticle(int articleId, int siteSectionId, int creatorId, int articleStatusId, int authorId, DateTime postDate, bool allowLanguageSpecificTags, Guid rowGuid, DateTime modifiedDate, int commentsTypeId, bool enableModeteration, int ArticleTypeID, int oldarticleId, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticle");
		    		Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
		    		Database.AddInParameter(command,"SiteSectionId",DbType.Int32,siteSectionId);
		    		Database.AddInParameter(command,"CreatorId",DbType.Int32,creatorId);
		    		Database.AddInParameter(command,"ArticleStatusId",DbType.Int32,articleStatusId);
		    		Database.AddInParameter(command,"AuthorId",DbType.Int32,authorId);
		    		Database.AddInParameter(command,"PostDate",DbType.DateTime,postDate);
		    		Database.AddInParameter(command,"AllowLanguageSpecificTags",DbType.Boolean,allowLanguageSpecificTags);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
		    		Database.AddInParameter(command,"CommentsTypeId",DbType.Int32,commentsTypeId);
		    		Database.AddInParameter(command,"EnableModeteration",DbType.Boolean,enableModeteration);
                    Database.AddInParameter(command, "ArticleTypeID", DbType.Int32, ArticleTypeID);
				Database.AddInParameter(command,"oldArticleId",DbType.Int32,oldarticleId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Article using Stored Procedure
		/// </summary>
		public DbCommand UpdateArticleCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticle");
		    		Database.AddInParameter(command,"ArticleId",DbType.Int32,"ArticleId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SiteSectionId",DbType.Int32,"SiteSectionId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CreatorId",DbType.Int32,"CreatorId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ArticleStatusId",DbType.Int32,"ArticleStatusId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AuthorId",DbType.Int32,"AuthorId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PostDate",DbType.DateTime,"PostDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AllowLanguageSpecificTags",DbType.Boolean,"AllowLanguageSpecificTags",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CommentsTypeId",DbType.Int32,"CommentsTypeId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EnableModeteration",DbType.Boolean,"EnableModeteration",DataRowVersion.Current);
				Database.AddInParameter(command,"oldArticleId",DbType.Int32,"ArticleId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Article using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteArticle( int articleId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteArticle");
			Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Article Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteArticleCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteArticle");
				Database.AddInParameter(command,"ArticleId",DbType.Int32,"ArticleId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Article using Stored Procedure
		/// and return number of rows effected of the Article
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Article",InsertNewArticleCommand(),UpdateArticleCommand(),DeleteArticleCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Article using Stored Procedure
		/// and return number of rows effected of the Article
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Article",InsertNewArticleCommand(),UpdateArticleCommand(),DeleteArticleCommand(), transaction);
          return rowsAffected;
		}


	}
}
