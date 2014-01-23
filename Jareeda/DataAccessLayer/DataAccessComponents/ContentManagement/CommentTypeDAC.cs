using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for CommentType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the CommentType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class CommentTypeDAC : DataAccessComponent
	{
		#region Constructors
        public CommentTypeDAC() : base("", "ContentManagement.CommentType") { }
		public CommentTypeDAC(string connectionString): base(connectionString){}
		public CommentTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all CommentType using Stored Procedure
		/// and return a DataTable containing all CommentType Data
		/// </summary>
		public DataTable GetAllCommentType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "CommentType";
         string query = " select * from GetAllCommentType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["CommentType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all CommentType using Stored Procedure
		/// and return a DataTable containing all CommentType Data using a Transaction
		/// </summary>
		public DataTable GetAllCommentType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "CommentType";
         string query = " select * from GetAllCommentType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["CommentType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all CommentType using Stored Procedure
		/// and return a DataTable containing all CommentType Data
		/// </summary>
		public DataTable GetAllCommentType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "CommentType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllCommentType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["CommentType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all CommentType using Stored Procedure
		/// and return a DataTable containing all CommentType Data using a Transaction
		/// </summary>
		public DataTable GetAllCommentType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "CommentType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllCommentType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["CommentType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From CommentType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDCommentType( int commentTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDCommentType");
				    Database.AddInParameter(command,"CommentTypeId",DbType.Int32,commentTypeId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From CommentType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDCommentType( int commentTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDCommentType");
				    Database.AddInParameter(command,"CommentTypeId",DbType.Int32,commentTypeId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into CommentType using Stored Procedure
		/// and return the auto number primary key of CommentType inserted row
		/// </summary>
		public bool InsertNewCommentType( ref int commentTypeId,  string commentTypeName)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewCommentType");
				Database.AddOutParameter(command,"CommentTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"CommentTypeName",DbType.String,commentTypeName);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 commentTypeId = Convert.ToInt32(Database.GetParameterValue(command, "CommentTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into CommentType using Stored Procedure
		/// and return the auto number primary key of CommentType inserted row using Transaction
		/// </summary>
		public bool InsertNewCommentType( ref int commentTypeId,  string commentTypeName,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewCommentType");
				Database.AddOutParameter(command,"CommentTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"CommentTypeName",DbType.String,commentTypeName);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 commentTypeId = Convert.ToInt32(Database.GetParameterValue(command, "CommentTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for CommentType using Stored Procedure
		/// and return DbCommand of the CommentType
		/// </summary>
		public DbCommand InsertNewCommentTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewCommentType");

				Database.AddInParameter(command,"CommentTypeName",DbType.String,"CommentTypeName",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into CommentType using Stored Procedure
		/// </summary>
		public bool UpdateCommentType( string commentTypeName, int oldcommentTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateCommentType");

		    		Database.AddInParameter(command,"CommentTypeName",DbType.String,commentTypeName);
				Database.AddInParameter(command,"oldCommentTypeId",DbType.Int32,oldcommentTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into CommentType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateCommentType( string commentTypeName, int oldcommentTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateCommentType");

		    		Database.AddInParameter(command,"CommentTypeName",DbType.String,commentTypeName);
				Database.AddInParameter(command,"oldCommentTypeId",DbType.Int32,oldcommentTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from CommentType using Stored Procedure
		/// </summary>
		public DbCommand UpdateCommentTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateCommentType");

		    		Database.AddInParameter(command,"CommentTypeName",DbType.String,"CommentTypeName",DataRowVersion.Current);
				Database.AddInParameter(command,"oldCommentTypeId",DbType.Int32,"CommentTypeId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From CommentType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteCommentType( int commentTypeId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteCommentType");
			Database.AddInParameter(command,"CommentTypeId",DbType.Int32,commentTypeId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From CommentType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteCommentTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteCommentType");
				Database.AddInParameter(command,"CommentTypeId",DbType.Int32,"CommentTypeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table CommentType using Stored Procedure
		/// and return number of rows effected of the CommentType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"CommentType",InsertNewCommentTypeCommand(),UpdateCommentTypeCommand(),DeleteCommentTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table CommentType using Stored Procedure
		/// and return number of rows effected of the CommentType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"CommentType",InsertNewCommentTypeCommand(),UpdateCommentTypeCommand(),DeleteCommentTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
