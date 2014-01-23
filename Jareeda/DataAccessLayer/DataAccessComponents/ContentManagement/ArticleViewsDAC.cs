using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for ArticleViews table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ArticleViews table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ArticleViewsDAC : DataAccessComponent
	{
		#region Constructors
        public ArticleViewsDAC() : base("", "ContentManagement.ArticleViews") { }
		public ArticleViewsDAC(string connectionString): base(connectionString){}
		public ArticleViewsDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleViews using Stored Procedure
		/// and return a DataTable containing all ArticleViews Data
		/// </summary>
		public DataTable GetAllArticleViews()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleViews";
         string query = " select * from GetAllArticleViews";
         DbCommand command = Database.GetSqlStringCommand(query);
         
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ArticleViews"];
		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleViews using Stored Procedure
		/// and return a DataTable containing all ArticleViews Data using a Transaction
		/// </summary>
		public DataTable GetAllArticleViews(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleViews";
         string query = " select * from GetAllArticleViews";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ArticleViews"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleViews using Stored Procedure
		/// and return a DataTable containing all ArticleViews Data
		/// </summary>
		public DataTable GetAllArticleViews(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleViews";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllArticleViews" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ArticleViews"];
		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleViews using Stored Procedure
		/// and return a DataTable containing all ArticleViews Data using a Transaction
		/// </summary>
		public DataTable GetAllArticleViews(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleViews";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllArticleViews" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ArticleViews"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ArticleViews using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticleViews( int articleViewID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticleViews");
				    Database.AddInParameter(command,"ArticleViewID",DbType.Int32,articleViewID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ArticleViews using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticleViews( int articleViewID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticleViews");
				    Database.AddInParameter(command,"ArticleViewID",DbType.Int32,articleViewID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ArticleViews using Stored Procedure
		/// and return the auto number primary key of ArticleViews inserted row
		/// </summary>
		public bool InsertNewArticleViews( ref int articleViewID,  int articleID,  string iPString,  DateTime dateViewed)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleViews");
				Database.AddOutParameter(command,"ArticleViewID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ArticleID",DbType.Int32,articleID);
				Database.AddInParameter(command,"IPString",DbType.String,iPString);
				Database.AddInParameter(command,"DateViewed",DbType.DateTime,dateViewed);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 articleViewID = Convert.ToInt32(Database.GetParameterValue(command, "ArticleViewID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ArticleViews using Stored Procedure
		/// and return the auto number primary key of ArticleViews inserted row using Transaction
		/// </summary>
		public bool InsertNewArticleViews( ref int articleViewID,  int articleID,  string iPString,  DateTime dateViewed,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleViews");
				Database.AddOutParameter(command,"ArticleViewID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ArticleID",DbType.Int32,articleID);
				Database.AddInParameter(command,"IPString",DbType.String,iPString);
				Database.AddInParameter(command,"DateViewed",DbType.DateTime,dateViewed);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 articleViewID = Convert.ToInt32(Database.GetParameterValue(command, "ArticleViewID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ArticleViews using Stored Procedure
		/// and return DbCommand of the ArticleViews
		/// </summary>
		public DbCommand InsertNewArticleViewsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleViews");

				Database.AddInParameter(command,"ArticleID",DbType.Int32,"ArticleID",DataRowVersion.Current);
				Database.AddInParameter(command,"IPString",DbType.String,"IPString",DataRowVersion.Current);
				Database.AddInParameter(command,"DateViewed",DbType.DateTime,"DateViewed",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ArticleViews using Stored Procedure
		/// </summary>
		public bool UpdateArticleViews( int articleID, string iPString, DateTime dateViewed, int oldarticleViewID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleViews");

		    		Database.AddInParameter(command,"ArticleID",DbType.Int32,articleID);
		    		Database.AddInParameter(command,"IPString",DbType.String,iPString);
		    		Database.AddInParameter(command,"DateViewed",DbType.DateTime,dateViewed);
				Database.AddInParameter(command,"oldArticleViewID",DbType.Int32,oldarticleViewID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ArticleViews using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateArticleViews( int articleID, string iPString, DateTime dateViewed, int oldarticleViewID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleViews");

		    		Database.AddInParameter(command,"ArticleID",DbType.Int32,articleID);
		    		Database.AddInParameter(command,"IPString",DbType.String,iPString);
		    		Database.AddInParameter(command,"DateViewed",DbType.DateTime,dateViewed);
				Database.AddInParameter(command,"oldArticleViewID",DbType.Int32,oldarticleViewID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ArticleViews using Stored Procedure
		/// </summary>
		public DbCommand UpdateArticleViewsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleViews");

		    		Database.AddInParameter(command,"ArticleID",DbType.Int32,"ArticleID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IPString",DbType.String,"IPString",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DateViewed",DbType.DateTime,"DateViewed",DataRowVersion.Current);
				Database.AddInParameter(command,"oldArticleViewID",DbType.Int32,"ArticleViewID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ArticleViews using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteArticleViews( int articleViewID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteArticleViews");
			Database.AddInParameter(command,"ArticleViewID",DbType.Int32,articleViewID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ArticleViews Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteArticleViewsCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteArticleViews");
				Database.AddInParameter(command,"ArticleViewID",DbType.Int32,"ArticleViewID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ArticleViews using Stored Procedure
		/// and return number of rows effected of the ArticleViews
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ArticleViews",InsertNewArticleViewsCommand(),UpdateArticleViewsCommand(),DeleteArticleViewsCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ArticleViews using Stored Procedure
		/// and return number of rows effected of the ArticleViews
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ArticleViews",InsertNewArticleViewsCommand(),UpdateArticleViewsCommand(),DeleteArticleViewsCommand(), transaction);
          return rowsAffected;
		}


	}
}
