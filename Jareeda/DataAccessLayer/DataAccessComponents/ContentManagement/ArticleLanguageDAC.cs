using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for ArticleLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ArticleLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ArticleLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public ArticleLanguageDAC() : base("", "ContentManagement.ArticleLanguage") { }
		public ArticleLanguageDAC(string connectionString): base(connectionString){}
		public ArticleLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleLanguage using Stored Procedure
		/// and return a DataTable containing all ArticleLanguage Data
		/// </summary>
		public DataTable GetAllArticleLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleLanguage";
         string query = " select * from GetAllArticleLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ArticleLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleLanguage using Stored Procedure
		/// and return a DataTable containing all ArticleLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllArticleLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleLanguage";
         string query = " select * from GetAllArticleLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ArticleLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleLanguage using Stored Procedure
		/// and return a DataTable containing all ArticleLanguage Data
		/// </summary>
		public DataTable GetAllArticleLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllArticleLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ArticleLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleLanguage using Stored Procedure
		/// and return a DataTable containing all ArticleLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllArticleLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllArticleLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ArticleLanguage"];

		}


        public System.Data.IDataReader GetByIDArticleIdLanguageIdArticlelanguage(int ArticleId,int LanguageId)
        {
            DbCommand command = Database.GetStoredProcCommand("GetByIDArticleIdLanguageIdArticlelanguage");
            Database.AddInParameter(command, "ArticleId", DbType.Int32, ArticleId);
            Database.AddInParameter(command, "LanguageId", DbType.Int32, LanguageId);
            IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
            return reader;
        }

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ArticleLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticleLanguage( int articleLanguageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticleLanguage");
				    Database.AddInParameter(command,"ArticleLanguageId",DbType.Int32,articleLanguageId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ArticleLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticleLanguage( int articleLanguageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticleLanguage");
				    Database.AddInParameter(command,"ArticleLanguageId",DbType.Int32,articleLanguageId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ArticleLanguage using Stored Procedure
		/// and return the auto number primary key of ArticleLanguage inserted row
		/// </summary>
		public bool InsertNewArticleLanguage( ref int articleLanguageId,  int articleId,  int languageId,  string articleName,  string articleContent,  string articleAttachment,  string authorAlias,  string articleAlias,  DateTime postDate,  DateTime publishStartDate,  DateTime publishEndDate,  DateTime revisionDate,  DateTime modifiedDate,string ArticleSummary,string ArticleSubTitle,string ArticleShortTitle)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleLanguage");
				Database.AddOutParameter(command,"ArticleLanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"ArticleName",DbType.String,articleName);
				Database.AddInParameter(command,"ArticleContent",DbType.String,articleContent);
				Database.AddInParameter(command,"ArticleAttachment",DbType.String,articleAttachment);
				Database.AddInParameter(command,"AuthorAlias",DbType.String,authorAlias);
				Database.AddInParameter(command,"ArticleAlias",DbType.String,articleAlias);
            if(postDate == DateTime.MinValue)
				Database.AddInParameter(command,"PostDate",DbType.DateTime,DBNull.Value);
            else
                Database.AddInParameter(command, "PostDate", DbType.DateTime, postDate);
            if(publishStartDate == DateTime.MinValue)
				Database.AddInParameter(command,"PublishStartDate",DbType.DateTime,DBNull.Value);
            else
                Database.AddInParameter(command, "PublishStartDate", DbType.DateTime, publishStartDate);
            if(publishEndDate == DateTime.MinValue)
				Database.AddInParameter(command,"PublishEndDate",DbType.DateTime,DBNull.Value);
            else
                Database.AddInParameter(command, "PublishEndDate", DbType.DateTime, publishEndDate);
            if(revisionDate == DateTime.MinValue)
				Database.AddInParameter(command,"RevisionDate",DbType.DateTime,DBNull.Value);
            else
                Database.AddInParameter(command, "RevisionDate", DbType.DateTime, revisionDate);
            if(modifiedDate == DateTime.MinValue)
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,DBNull.Value);
            else
                Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, modifiedDate);
            Database.AddInParameter(command, "ArticleSummary", DbType.String, ArticleSummary);
            Database.AddInParameter(command, "ArticleSubTitle", DbType.String, ArticleSubTitle);
            Database.AddInParameter(command, "ArticleShortTitle", DbType.String, ArticleShortTitle);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 articleLanguageId = Convert.ToInt32(Database.GetParameterValue(command, "ArticleLanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ArticleLanguage using Stored Procedure
		/// and return the auto number primary key of ArticleLanguage inserted row using Transaction
		/// </summary>
        public bool InsertNewArticleLanguage(ref int articleLanguageId, int articleId, int languageId, string articleName, string articleContent, string articleAttachment, string authorAlias, string articleAlias, DateTime postDate, DateTime publishStartDate, DateTime publishEndDate, DateTime revisionDate, DateTime modifiedDate, string ArticleSummary, string ArticleSubTitle, string ArticleShortTitle, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleLanguage");
				Database.AddOutParameter(command,"ArticleLanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"ArticleName",DbType.String,articleName);
				Database.AddInParameter(command,"ArticleContent",DbType.String,articleContent);
				Database.AddInParameter(command,"ArticleAttachment",DbType.String,articleAttachment);
				Database.AddInParameter(command,"AuthorAlias",DbType.String,authorAlias);
				Database.AddInParameter(command,"ArticleAlias",DbType.String,articleAlias);
                if (postDate == DateTime.MinValue)
                    Database.AddInParameter(command, "PostDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "PostDate", DbType.DateTime, postDate);
                if (publishStartDate == DateTime.MinValue)
                    Database.AddInParameter(command, "PublishStartDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "PublishStartDate", DbType.DateTime, publishStartDate);
                if (publishEndDate == DateTime.MinValue)
                    Database.AddInParameter(command, "PublishEndDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "PublishEndDate", DbType.DateTime, publishEndDate);
                if (revisionDate == DateTime.MinValue)
                    Database.AddInParameter(command, "RevisionDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "RevisionDate", DbType.DateTime, revisionDate);
                if (modifiedDate == DateTime.MinValue)
                    Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, modifiedDate);
                Database.AddInParameter(command, "ArticleSummary", DbType.String, ArticleSummary);
                Database.AddInParameter(command, "ArticleSubTitle", DbType.String, ArticleSubTitle);
                Database.AddInParameter(command, "ArticleShortTitle", DbType.String, ArticleShortTitle);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 articleLanguageId = Convert.ToInt32(Database.GetParameterValue(command, "ArticleLanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ArticleLanguage using Stored Procedure
		/// and return DbCommand of the ArticleLanguage
		/// </summary>
		public DbCommand InsertNewArticleLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleLanguage");

				Database.AddInParameter(command,"ArticleId",DbType.Int32,"ArticleId",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
				Database.AddInParameter(command,"ArticleName",DbType.String,"ArticleName",DataRowVersion.Current);
				Database.AddInParameter(command,"ArticleContent",DbType.String,"ArticleContent",DataRowVersion.Current);
				Database.AddInParameter(command,"ArticleAttachment",DbType.String,"ArticleAttachment",DataRowVersion.Current);
				Database.AddInParameter(command,"AuthorAlias",DbType.String,"AuthorAlias",DataRowVersion.Current);
				Database.AddInParameter(command,"ArticleAlias",DbType.String,"ArticleAlias",DataRowVersion.Current);
                
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ArticleLanguage using Stored Procedure
		/// </summary>
        public bool UpdateArticleLanguage(int articleId, int languageId, string articleName, string articleContent, string articleAttachment, string authorAlias, string articleAlias, DateTime postDate, DateTime publishStartDate, DateTime publishEndDate, DateTime revisionDate, DateTime modifiedDate, string ArticleSummary, string ArticleSubTitle, string ArticleShortTitle, int oldarticleLanguageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleLanguage");

		    		Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"ArticleName",DbType.String,articleName);
		    		Database.AddInParameter(command,"ArticleContent",DbType.String,articleContent);
		    		Database.AddInParameter(command,"ArticleAttachment",DbType.String,articleAttachment);
		    		Database.AddInParameter(command,"AuthorAlias",DbType.String,authorAlias);
		    		Database.AddInParameter(command,"ArticleAlias",DbType.String,articleAlias);
                    if (postDate == DateTime.MinValue)
                        Database.AddInParameter(command, "PostDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "PostDate", DbType.DateTime, postDate);
                    if (publishStartDate == DateTime.MinValue)
                        Database.AddInParameter(command, "PublishStartDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "PublishStartDate", DbType.DateTime, publishStartDate);
                    if (publishEndDate == DateTime.MinValue)
                        Database.AddInParameter(command, "PublishEndDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "PublishEndDate", DbType.DateTime, publishEndDate);
                    if (revisionDate == DateTime.MinValue)
                        Database.AddInParameter(command, "RevisionDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "RevisionDate", DbType.DateTime, revisionDate);
                    if (modifiedDate == DateTime.MinValue)
                        Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, modifiedDate);
                    Database.AddInParameter(command, "ArticleSummary", DbType.String, ArticleSummary);
                    Database.AddInParameter(command, "ArticleSubTitle", DbType.String, ArticleSubTitle);
                    Database.AddInParameter(command, "ArticleShortTitle", DbType.String, ArticleShortTitle);
				Database.AddInParameter(command,"oldArticleLanguageId",DbType.Int32,oldarticleLanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ArticleLanguage using Stored Procedure By Transaction
		/// </summary>
        public bool UpdateArticleLanguage(int articleId, int languageId, string articleName, string articleContent, string articleAttachment, string authorAlias, string articleAlias, DateTime postDate, DateTime publishStartDate, DateTime publishEndDate, DateTime revisionDate, DateTime modifiedDate, string ArticleSummary, string ArticleSubTitle, string ArticleShortTitle, int oldarticleLanguageId, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleLanguage");

		    		Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"ArticleName",DbType.String,articleName);
		    		Database.AddInParameter(command,"ArticleContent",DbType.String,articleContent);
		    		Database.AddInParameter(command,"ArticleAttachment",DbType.String,articleAttachment);
		    		Database.AddInParameter(command,"AuthorAlias",DbType.String,authorAlias);
		    		Database.AddInParameter(command,"ArticleAlias",DbType.String,articleAlias);
                    if (postDate == DateTime.MinValue)
                        Database.AddInParameter(command, "PostDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "PostDate", DbType.DateTime, postDate);
                    if (publishStartDate == DateTime.MinValue)
                        Database.AddInParameter(command, "PublishStartDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "PublishStartDate", DbType.DateTime, publishStartDate);
                    if (publishEndDate == DateTime.MinValue)
                        Database.AddInParameter(command, "PublishEndDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "PublishEndDate", DbType.DateTime, publishEndDate);
                    if (revisionDate == DateTime.MinValue)
                        Database.AddInParameter(command, "RevisionDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "RevisionDate", DbType.DateTime, revisionDate);
                    if (modifiedDate == DateTime.MinValue)
                        Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, modifiedDate);
                    Database.AddInParameter(command, "ArticleSummary", DbType.String, ArticleSummary);
                    Database.AddInParameter(command, "ArticleSubTitle", DbType.String, ArticleSubTitle);
                    Database.AddInParameter(command, "ArticleShortTitle", DbType.String, ArticleShortTitle);
				Database.AddInParameter(command,"oldArticleLanguageId",DbType.Int32,oldarticleLanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ArticleLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateArticleLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleLanguage");

		    		Database.AddInParameter(command,"ArticleId",DbType.Int32,"ArticleId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ArticleName",DbType.String,"ArticleName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ArticleContent",DbType.String,"ArticleContent",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ArticleAttachment",DbType.String,"ArticleAttachment",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AuthorAlias",DbType.String,"AuthorAlias",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ArticleAlias",DbType.String,"ArticleAlias",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PostDate",DbType.DateTime,"PostDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PublishStartDate",DbType.DateTime,"PublishStartDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PublishEndDate",DbType.DateTime,"PublishEndDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RevisionDate",DbType.DateTime,"RevisionDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldArticleLanguageId",DbType.Int32,"ArticleLanguageId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ArticleLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteArticleLanguage( int articleLanguageId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteArticleLanguage");
			Database.AddInParameter(command,"ArticleLanguageId",DbType.Int32,articleLanguageId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ArticleLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteArticleLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteArticleLanguage");
				Database.AddInParameter(command,"ArticleLanguageId",DbType.Int32,"ArticleLanguageId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ArticleLanguage using Stored Procedure
		/// and return number of rows effected of the ArticleLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ArticleLanguage",InsertNewArticleLanguageCommand(),UpdateArticleLanguageCommand(),DeleteArticleLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ArticleLanguage using Stored Procedure
		/// and return number of rows effected of the ArticleLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ArticleLanguage",InsertNewArticleLanguageCommand(),UpdateArticleLanguageCommand(),DeleteArticleLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
