using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for AbstractReviewer table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the AbstractReviewer table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class AbstractReviewerDAC : DataAccessComponent
	{
		#region Constructors
        public AbstractReviewerDAC() : base("", "Conference.AbstractReviewer") { }
		public AbstractReviewerDAC(string connectionString): base(connectionString){}
		public AbstractReviewerDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractReviewer using Stored Procedure
		/// and return a DataTable containing all AbstractReviewer Data
		/// </summary>
		public DataTable GetAllAbstractReviewer()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractReviewer";
         string query = " select * from GetAllAbstractReviewer";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["AbstractReviewer"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractReviewer using Stored Procedure
		/// and return a DataTable containing all AbstractReviewer Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstractReviewer(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractReviewer";
         string query = " select * from GetAllAbstractReviewer";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["AbstractReviewer"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractReviewer using Stored Procedure
		/// and return a DataTable containing all AbstractReviewer Data
		/// </summary>
		public DataTable GetAllAbstractReviewer(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractReviewer";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllAbstractReviewer" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["AbstractReviewer"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractReviewer using Stored Procedure
		/// and return a DataTable containing all AbstractReviewer Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstractReviewer(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractReviewer";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllAbstractReviewer" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["AbstractReviewer"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From AbstractReviewer using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstractReviewer( int abstractReviewerId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstractReviewer");
				    Database.AddInParameter(command,"AbstractReviewerId",DbType.Int32,abstractReviewerId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From AbstractReviewer using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstractReviewer( int abstractReviewerId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstractReviewer");
				    Database.AddInParameter(command,"AbstractReviewerId",DbType.Int32,abstractReviewerId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into AbstractReviewer using Stored Procedure
		/// and return the auto number primary key of AbstractReviewer inserted row
		/// </summary>
		public bool InsertNewAbstractReviewer( ref int abstractReviewerId,  int personId,  bool isInternal,  DateTime dateCreated,  bool isActive)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractReviewer");
				Database.AddOutParameter(command,"AbstractReviewerId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"IsInternal",DbType.Boolean,isInternal);
				Database.AddInParameter(command,"DateCreated",DbType.DateTime,dateCreated);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 abstractReviewerId = Convert.ToInt32(Database.GetParameterValue(command, "AbstractReviewerId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into AbstractReviewer using Stored Procedure
		/// and return the auto number primary key of AbstractReviewer inserted row using Transaction
		/// </summary>
		public bool InsertNewAbstractReviewer( ref int abstractReviewerId,  int personId,  bool isInternal,  DateTime dateCreated,  bool isActive,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractReviewer");
				Database.AddOutParameter(command,"AbstractReviewerId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"IsInternal",DbType.Boolean,isInternal);
				Database.AddInParameter(command,"DateCreated",DbType.DateTime,dateCreated);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 abstractReviewerId = Convert.ToInt32(Database.GetParameterValue(command, "AbstractReviewerId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for AbstractReviewer using Stored Procedure
		/// and return DbCommand of the AbstractReviewer
		/// </summary>
		public DbCommand InsertNewAbstractReviewerCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractReviewer");

				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				Database.AddInParameter(command,"IsInternal",DbType.Boolean,"IsInternal",DataRowVersion.Current);
				Database.AddInParameter(command,"DateCreated",DbType.DateTime,"DateCreated",DataRowVersion.Current);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into AbstractReviewer using Stored Procedure
		/// </summary>
		public bool UpdateAbstractReviewer( int personId, bool isInternal, DateTime dateCreated, bool isActive, int oldabstractReviewerId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractReviewer");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"IsInternal",DbType.Boolean,isInternal);
		    		Database.AddInParameter(command,"DateCreated",DbType.DateTime,dateCreated);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"oldAbstractReviewerId",DbType.Int32,oldabstractReviewerId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into AbstractReviewer using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateAbstractReviewer( int personId, bool isInternal, DateTime dateCreated, bool isActive, int oldabstractReviewerId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractReviewer");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"IsInternal",DbType.Boolean,isInternal);
		    		Database.AddInParameter(command,"DateCreated",DbType.DateTime,dateCreated);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"oldAbstractReviewerId",DbType.Int32,oldabstractReviewerId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from AbstractReviewer using Stored Procedure
		/// </summary>
		public DbCommand UpdateAbstractReviewerCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractReviewer");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsInternal",DbType.Boolean,"IsInternal",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DateCreated",DbType.DateTime,"DateCreated",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
				Database.AddInParameter(command,"oldAbstractReviewerId",DbType.Int32,"AbstractReviewerId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From AbstractReviewer using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteAbstractReviewer( int abstractReviewerId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteAbstractReviewer");
			Database.AddInParameter(command,"AbstractReviewerId",DbType.Int32,abstractReviewerId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From AbstractReviewer Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteAbstractReviewerCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteAbstractReviewer");
				Database.AddInParameter(command,"AbstractReviewerId",DbType.Int32,"AbstractReviewerId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table AbstractReviewer using Stored Procedure
		/// and return number of rows effected of the AbstractReviewer
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"AbstractReviewer",InsertNewAbstractReviewerCommand(),UpdateAbstractReviewerCommand(),DeleteAbstractReviewerCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table AbstractReviewer using Stored Procedure
		/// and return number of rows effected of the AbstractReviewer
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"AbstractReviewer",InsertNewAbstractReviewerCommand(),UpdateAbstractReviewerCommand(),DeleteAbstractReviewerCommand(), transaction);
          return rowsAffected;
		}


	}
}
