using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for AbstractReviewerAssignment table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the AbstractReviewerAssignment table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class AbstractReviewerAssignmentDAC : DataAccessComponent
	{
		#region Constructors
        public AbstractReviewerAssignmentDAC() : base("", "Conference.AbstractReviewerAssignment") { }
		public AbstractReviewerAssignmentDAC(string connectionString): base(connectionString){}
		public AbstractReviewerAssignmentDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractReviewerAssignment using Stored Procedure
		/// and return a DataTable containing all AbstractReviewerAssignment Data
		/// </summary>
		public DataTable GetAllAbstractReviewerAssignment()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractReviewerAssignment";
         string query = " select * from GetAllAbstractReviewerAssignment";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["AbstractReviewerAssignment"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractReviewerAssignment using Stored Procedure
		/// and return a DataTable containing all AbstractReviewerAssignment Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstractReviewerAssignment(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractReviewerAssignment";
         string query = " select * from GetAllAbstractReviewerAssignment";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["AbstractReviewerAssignment"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractReviewerAssignment using Stored Procedure
		/// and return a DataTable containing all AbstractReviewerAssignment Data
		/// </summary>
		public DataTable GetAllAbstractReviewerAssignment(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractReviewerAssignment";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllAbstractReviewerAssignment" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["AbstractReviewerAssignment"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractReviewerAssignment using Stored Procedure
		/// and return a DataTable containing all AbstractReviewerAssignment Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstractReviewerAssignment(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractReviewerAssignment";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllAbstractReviewerAssignment" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["AbstractReviewerAssignment"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From AbstractReviewerAssignment using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstractReviewerAssignment( int abstractReviewerAssignmentId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstractReviewerAssignment");
				    Database.AddInParameter(command,"AbstractReviewerAssignmentId",DbType.Int32,abstractReviewerAssignmentId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From AbstractReviewerAssignment using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstractReviewerAssignment( int abstractReviewerAssignmentId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstractReviewerAssignment");
				    Database.AddInParameter(command,"AbstractReviewerAssignmentId",DbType.Int32,abstractReviewerAssignmentId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into AbstractReviewerAssignment using Stored Procedure
		/// and return the auto number primary key of AbstractReviewerAssignment inserted row
		/// </summary>
		public bool InsertNewAbstractReviewerAssignment( ref int abstractReviewerAssignmentId,  int abstractReviewerId,  int abstractId,  bool hasAcceptedReview,  DateTime dateAssigned,  DateTime dateAccepted)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractReviewerAssignment");
				Database.AddOutParameter(command,"AbstractReviewerAssignmentId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"AbstractReviewerId",DbType.Int32,abstractReviewerId);
				Database.AddInParameter(command,"AbstractId",DbType.Int32,abstractId);
				Database.AddInParameter(command,"HasAcceptedReview",DbType.Boolean,hasAcceptedReview);
				Database.AddInParameter(command,"DateAssigned",DbType.DateTime,dateAssigned);
                if(dateAccepted == DateTime.MinValue)
				    Database.AddInParameter(command,"DateAccepted",DbType.DateTime,DBNull.Value);
                else
                    Database.AddInParameter(command, "DateAccepted", DbType.DateTime, dateAccepted);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 abstractReviewerAssignmentId = Convert.ToInt32(Database.GetParameterValue(command, "AbstractReviewerAssignmentId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into AbstractReviewerAssignment using Stored Procedure
		/// and return the auto number primary key of AbstractReviewerAssignment inserted row using Transaction
		/// </summary>
		public bool InsertNewAbstractReviewerAssignment( ref int abstractReviewerAssignmentId,  int abstractReviewerId,  int abstractId,  bool hasAcceptedReview,  DateTime dateAssigned,  DateTime dateAccepted,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractReviewerAssignment");
				Database.AddOutParameter(command,"AbstractReviewerAssignmentId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"AbstractReviewerId",DbType.Int32,abstractReviewerId);
				Database.AddInParameter(command,"AbstractId",DbType.Int32,abstractId);
				Database.AddInParameter(command,"HasAcceptedReview",DbType.Boolean,hasAcceptedReview);
				Database.AddInParameter(command,"DateAssigned",DbType.DateTime,dateAssigned);
                if (dateAccepted == DateTime.MinValue)
                    Database.AddInParameter(command, "DateAccepted", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "DateAccepted", DbType.DateTime, dateAccepted);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 abstractReviewerAssignmentId = Convert.ToInt32(Database.GetParameterValue(command, "AbstractReviewerAssignmentId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for AbstractReviewerAssignment using Stored Procedure
		/// and return DbCommand of the AbstractReviewerAssignment
		/// </summary>
		public DbCommand InsertNewAbstractReviewerAssignmentCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractReviewerAssignment");

				Database.AddInParameter(command,"AbstractReviewerId",DbType.Int32,"AbstractReviewerId",DataRowVersion.Current);
				Database.AddInParameter(command,"AbstractId",DbType.Int32,"AbstractId",DataRowVersion.Current);
				Database.AddInParameter(command,"HasAcceptedReview",DbType.Boolean,"HasAcceptedReview",DataRowVersion.Current);
				Database.AddInParameter(command,"DateAssigned",DbType.DateTime,"DateAssigned",DataRowVersion.Current);
				Database.AddInParameter(command,"DateAccepted",DbType.DateTime,"DateAccepted",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into AbstractReviewerAssignment using Stored Procedure
		/// </summary>
		public bool UpdateAbstractReviewerAssignment( int abstractReviewerId, int abstractId, bool hasAcceptedReview, DateTime dateAssigned, DateTime dateAccepted, int oldabstractReviewerAssignmentId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractReviewerAssignment");

		    		Database.AddInParameter(command,"AbstractReviewerId",DbType.Int32,abstractReviewerId);
		    		Database.AddInParameter(command,"AbstractId",DbType.Int32,abstractId);
		    		Database.AddInParameter(command,"HasAcceptedReview",DbType.Boolean,hasAcceptedReview);
		    		Database.AddInParameter(command,"DateAssigned",DbType.DateTime,dateAssigned);
                    if (dateAccepted == DateTime.MinValue)
                        Database.AddInParameter(command, "DateAccepted", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "DateAccepted", DbType.DateTime, dateAccepted);
				Database.AddInParameter(command,"oldAbstractReviewerAssignmentId",DbType.Int32,oldabstractReviewerAssignmentId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into AbstractReviewerAssignment using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateAbstractReviewerAssignment( int abstractReviewerId, int abstractId, bool hasAcceptedReview, DateTime dateAssigned, DateTime dateAccepted, int oldabstractReviewerAssignmentId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractReviewerAssignment");

		    		Database.AddInParameter(command,"AbstractReviewerId",DbType.Int32,abstractReviewerId);
		    		Database.AddInParameter(command,"AbstractId",DbType.Int32,abstractId);
		    		Database.AddInParameter(command,"HasAcceptedReview",DbType.Boolean,hasAcceptedReview);
		    		Database.AddInParameter(command,"DateAssigned",DbType.DateTime,dateAssigned);
                    if (dateAccepted == DateTime.MinValue)
                        Database.AddInParameter(command, "DateAccepted", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "DateAccepted", DbType.DateTime, dateAccepted);
				Database.AddInParameter(command,"oldAbstractReviewerAssignmentId",DbType.Int32,oldabstractReviewerAssignmentId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from AbstractReviewerAssignment using Stored Procedure
		/// </summary>
		public DbCommand UpdateAbstractReviewerAssignmentCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractReviewerAssignment");

		    		Database.AddInParameter(command,"AbstractReviewerId",DbType.Int32,"AbstractReviewerId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AbstractId",DbType.Int32,"AbstractId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"HasAcceptedReview",DbType.Boolean,"HasAcceptedReview",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DateAssigned",DbType.DateTime,"DateAssigned",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DateAccepted",DbType.DateTime,"DateAccepted",DataRowVersion.Current);
				Database.AddInParameter(command,"oldAbstractReviewerAssignmentId",DbType.Int32,"AbstractReviewerAssignmentId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From AbstractReviewerAssignment using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteAbstractReviewerAssignment( int abstractReviewerAssignmentId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteAbstractReviewerAssignment");
			Database.AddInParameter(command,"AbstractReviewerAssignmentId",DbType.Int32,abstractReviewerAssignmentId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From AbstractReviewerAssignment Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteAbstractReviewerAssignmentCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteAbstractReviewerAssignment");
				Database.AddInParameter(command,"AbstractReviewerAssignmentId",DbType.Int32,"AbstractReviewerAssignmentId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table AbstractReviewerAssignment using Stored Procedure
		/// and return number of rows effected of the AbstractReviewerAssignment
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"AbstractReviewerAssignment",InsertNewAbstractReviewerAssignmentCommand(),UpdateAbstractReviewerAssignmentCommand(),DeleteAbstractReviewerAssignmentCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table AbstractReviewerAssignment using Stored Procedure
		/// and return number of rows effected of the AbstractReviewerAssignment
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"AbstractReviewerAssignment",InsertNewAbstractReviewerAssignmentCommand(),UpdateAbstractReviewerAssignmentCommand(),DeleteAbstractReviewerAssignmentCommand(), transaction);
          return rowsAffected;
		}


	}
}
