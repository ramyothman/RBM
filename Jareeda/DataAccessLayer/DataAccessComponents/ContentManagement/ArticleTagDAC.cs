using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for ArticleTag table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ArticleTag table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ArticleTagDAC : DataAccessComponent
	{
		#region Constructors
        public ArticleTagDAC() : base("", "ContentManagement.ArticleTag") { }
		public ArticleTagDAC(string connectionString): base(connectionString){}
		public ArticleTagDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleTag using Stored Procedure
		/// and return a DataTable containing all ArticleTag Data
		/// </summary>
		public DataTable GetAllArticleTag()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleTag";
         string query = " select * from GetAllArticleTag";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ArticleTag"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleTag using Stored Procedure
		/// and return a DataTable containing all ArticleTag Data using a Transaction
		/// </summary>
		public DataTable GetAllArticleTag(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleTag";
         string query = " select * from GetAllArticleTag";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ArticleTag"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleTag using Stored Procedure
		/// and return a DataTable containing all ArticleTag Data
		/// </summary>
		public DataTable GetAllArticleTag(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleTag";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllArticleTag" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ArticleTag"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleTag using Stored Procedure
		/// and return a DataTable containing all ArticleTag Data using a Transaction
		/// </summary>
		public DataTable GetAllArticleTag(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleTag";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllArticleTag" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ArticleTag"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ArticleTag using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticleTag( int articleTagId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticleTag");
				    Database.AddInParameter(command,"ArticleTagId",DbType.Int32,articleTagId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ArticleTag using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticleTag( int articleTagId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticleTag");
				    Database.AddInParameter(command,"ArticleTagId",DbType.Int32,articleTagId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ArticleTag using Stored Procedure
		/// and return the auto number primary key of ArticleTag inserted row
		/// </summary>
		public bool InsertNewArticleTag( ref int articleTagId,  int articleId,  string name,  int languageId,  DateTime postDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleTag");
				Database.AddOutParameter(command,"ArticleTagId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"PostDate",DbType.DateTime,postDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 articleTagId = Convert.ToInt32(Database.GetParameterValue(command, "ArticleTagId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ArticleTag using Stored Procedure
		/// and return the auto number primary key of ArticleTag inserted row using Transaction
		/// </summary>
		public bool InsertNewArticleTag( ref int articleTagId,  int articleId,  string name,  int languageId,  DateTime postDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleTag");
				Database.AddOutParameter(command,"ArticleTagId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"PostDate",DbType.DateTime,postDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 articleTagId = Convert.ToInt32(Database.GetParameterValue(command, "ArticleTagId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ArticleTag using Stored Procedure
		/// and return DbCommand of the ArticleTag
		/// </summary>
		public DbCommand InsertNewArticleTagCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleTag");

				Database.AddInParameter(command,"ArticleId",DbType.Int32,"ArticleId",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
				Database.AddInParameter(command,"PostDate",DbType.DateTime,"PostDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ArticleTag using Stored Procedure
		/// </summary>
		public bool UpdateArticleTag( int articleId, string name, int languageId, DateTime postDate, int oldarticleTagId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleTag");

		    		Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"PostDate",DbType.DateTime,postDate);
				Database.AddInParameter(command,"oldArticleTagId",DbType.Int32,oldarticleTagId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ArticleTag using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateArticleTag( int articleId, string name, int languageId, DateTime postDate, int oldarticleTagId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleTag");

		    		Database.AddInParameter(command,"ArticleId",DbType.Int32,articleId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"PostDate",DbType.DateTime,postDate);
				Database.AddInParameter(command,"oldArticleTagId",DbType.Int32,oldarticleTagId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ArticleTag using Stored Procedure
		/// </summary>
		public DbCommand UpdateArticleTagCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleTag");

		    		Database.AddInParameter(command,"ArticleId",DbType.Int32,"ArticleId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PostDate",DbType.DateTime,"PostDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldArticleTagId",DbType.Int32,"ArticleTagId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ArticleTag using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteArticleTag( int articleTagId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteArticleTag");
			Database.AddInParameter(command,"ArticleTagId",DbType.Int32,articleTagId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ArticleTag Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteArticleTagCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteArticleTag");
				Database.AddInParameter(command,"ArticleTagId",DbType.Int32,"ArticleTagId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ArticleTag using Stored Procedure
		/// and return number of rows effected of the ArticleTag
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ArticleTag",InsertNewArticleTagCommand(),UpdateArticleTagCommand(),DeleteArticleTagCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ArticleTag using Stored Procedure
		/// and return number of rows effected of the ArticleTag
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ArticleTag",InsertNewArticleTagCommand(),UpdateArticleTagCommand(),DeleteArticleTagCommand(), transaction);
          return rowsAffected;
		}


	}
}
