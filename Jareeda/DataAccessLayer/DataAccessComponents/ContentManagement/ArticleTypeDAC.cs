using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for ArticleType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ArticleType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ArticleTypeDAC : DataAccessComponent
	{
		#region Constructors
        public ArticleTypeDAC() : base("", "ContentManagement.ArticleType") { }
		public ArticleTypeDAC(string connectionString): base(connectionString){}
		public ArticleTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleType using Stored Procedure
		/// and return a DataTable containing all ArticleType Data
		/// </summary>
		public DataTable GetAllArticleType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleType";
         string query = " select * from GetAllArticleType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ArticleType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleType using Stored Procedure
		/// and return a DataTable containing all ArticleType Data using a Transaction
		/// </summary>
		public DataTable GetAllArticleType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleType";
         string query = " select * from GetAllArticleType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ArticleType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleType using Stored Procedure
		/// and return a DataTable containing all ArticleType Data
		/// </summary>
		public DataTable GetAllArticleType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllArticleType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ArticleType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ArticleType using Stored Procedure
		/// and return a DataTable containing all ArticleType Data using a Transaction
		/// </summary>
		public DataTable GetAllArticleType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ArticleType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllArticleType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ArticleType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ArticleType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticleType( int articleTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticleType");
				    Database.AddInParameter(command,"ArticleTypeID",DbType.Int32,articleTypeID);
                    IDataReader reader = this.FromCache(command).CreateDataReader(); // Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ArticleType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDArticleType( int articleTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDArticleType");
				    Database.AddInParameter(command,"ArticleTypeID",DbType.Int32,articleTypeID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ArticleType using Stored Procedure
		/// and return the auto number primary key of ArticleType inserted row
		/// </summary>
		public bool InsertNewArticleType( int articleTypeID,  string name,  string code)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleType");
				Database.AddInParameter(command,"ArticleTypeID",DbType.Int32,articleTypeID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Code",DbType.String,code);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ArticleType using Stored Procedure
		/// and return the auto number primary key of ArticleType inserted row using Transaction
		/// </summary>
		public bool InsertNewArticleType( int articleTypeID,  string name,  string code,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleType");
				Database.AddInParameter(command,"ArticleTypeID",DbType.Int32,articleTypeID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Code",DbType.String,code);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ArticleType using Stored Procedure
		/// and return DbCommand of the ArticleType
		/// </summary>
		public DbCommand InsertNewArticleTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewArticleType");
				Database.AddInParameter(command,"ArticleTypeID",DbType.Int32,"ArticleTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"Code",DbType.String,"Code",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ArticleType using Stored Procedure
		/// </summary>
		public bool UpdateArticleType( int articleTypeID, string name, string code, int oldarticleTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleType");
		    		Database.AddInParameter(command,"ArticleTypeID",DbType.Int32,articleTypeID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Code",DbType.String,code);
				Database.AddInParameter(command,"oldArticleTypeID",DbType.Int32,oldarticleTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ArticleType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateArticleType( int articleTypeID, string name, string code, int oldarticleTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleType");
		    		Database.AddInParameter(command,"ArticleTypeID",DbType.Int32,articleTypeID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Code",DbType.String,code);
				Database.AddInParameter(command,"oldArticleTypeID",DbType.Int32,oldarticleTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ArticleType using Stored Procedure
		/// </summary>
		public DbCommand UpdateArticleTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateArticleType");
		    		Database.AddInParameter(command,"ArticleTypeID",DbType.Int32,"ArticleTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Code",DbType.String,"Code",DataRowVersion.Current);
				Database.AddInParameter(command,"oldArticleTypeID",DbType.Int32,"ArticleTypeID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ArticleType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteArticleType( int articleTypeID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteArticleType");
			Database.AddInParameter(command,"ArticleTypeID",DbType.Int32,articleTypeID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ArticleType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteArticleTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteArticleType");
				Database.AddInParameter(command,"ArticleTypeID",DbType.Int32,"ArticleTypeID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ArticleType using Stored Procedure
		/// and return number of rows effected of the ArticleType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ArticleType",InsertNewArticleTypeCommand(),UpdateArticleTypeCommand(),DeleteArticleTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ArticleType using Stored Procedure
		/// and return number of rows effected of the ArticleType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ArticleType",InsertNewArticleTypeCommand(),UpdateArticleTypeCommand(),DeleteArticleTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
