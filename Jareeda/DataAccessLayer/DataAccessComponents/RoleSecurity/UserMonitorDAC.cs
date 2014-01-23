using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents
{
	/// <summary>
	/// This is a Data Access Class  for UserMonitor table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the UserMonitor table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class UserMonitorDAC : DataAccessComponent
	{
		#region Constructors
		public UserMonitorDAC(): base("", "RoleSecurity.UserMonitor") { }
        
		public UserMonitorDAC(string connectionString): base(connectionString){}
		public UserMonitorDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all UserMonitor using Stored Procedure
		/// and return a DataTable containing all UserMonitor Data
		/// </summary>
		public DataTable GetAllUserMonitor()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "UserMonitor";
            
            
         string query = " select * from GetAllUserMonitor";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["UserMonitor"];

		}

        public int GetUserMonitorCountInPeriod(string UserName,string UserIP)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "UserMonitorCount";
            string query = " select dbo.GetUserMonitorCountInPeriod(@UserName,@UserIP,@StartDate,@EndDate)";
            
            DbCommand command = Database.GetSqlStringCommand(query);
            Database.AddInParameter(command, "UserName", DbType.String, UserName);
            Database.AddInParameter(command, "UserIP", DbType.String, UserIP);
            Database.AddInParameter(command, "StartDate", DbType.DateTime, DateTime.Now.AddHours(-1));
            Database.AddInParameter(command, "EndDate", DbType.DateTime, DateTime.Now);

            IDataReader reader = Database.ExecuteReader(command); ;
            int result = 0;
            while (reader.Read())
            {
                result = reader.GetInt32(0);
            }
            return result;
            

        }



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all UserMonitor using Stored Procedure
		/// and return a DataTable containing all UserMonitor Data using a Transaction
		/// </summary>
		public DataTable GetAllUserMonitor(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "UserMonitor";
         string query = " select * from GetAllUserMonitor";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["UserMonitor"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all UserMonitor using Stored Procedure
		/// and return a DataTable containing all UserMonitor Data
		/// </summary>
		public DataTable GetAllUserMonitor(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "UserMonitor";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllUserMonitor" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["UserMonitor"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all UserMonitor using Stored Procedure
		/// and return a DataTable containing all UserMonitor Data using a Transaction
		/// </summary>
		public DataTable GetAllUserMonitor(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "UserMonitor";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllUserMonitor" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["UserMonitor"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From UserMonitor using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDUserMonitor( int userMonitorId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDUserMonitor");
				    Database.AddInParameter(command,"UserMonitorId",DbType.Int32,userMonitorId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From UserMonitor using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDUserMonitor( int userMonitorId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDUserMonitor");
				    Database.AddInParameter(command,"UserMonitorId",DbType.Int32,userMonitorId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into UserMonitor using Stored Procedure
		/// and return the auto number primary key of UserMonitor inserted row
		/// </summary>
		public bool InsertNewUserMonitor( ref int userMonitorId,  int personId,  bool isSuccess,  string userIP,  string userName,  DateTime dateCreated)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewUserMonitor");
				Database.AddOutParameter(command,"UserMonitorId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"IsSuccess",DbType.Boolean,isSuccess);
				Database.AddInParameter(command,"UserIP",DbType.String,userIP);
				Database.AddInParameter(command,"UserName",DbType.String,userName);
				Database.AddInParameter(command,"DateCreated",DbType.DateTime,dateCreated);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 userMonitorId = Convert.ToInt32(Database.GetParameterValue(command, "UserMonitorId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into UserMonitor using Stored Procedure
		/// and return the auto number primary key of UserMonitor inserted row using Transaction
		/// </summary>
		public bool InsertNewUserMonitor( ref int userMonitorId,  int personId,  bool isSuccess,  string userIP,  string userName,  DateTime dateCreated,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewUserMonitor");
				Database.AddOutParameter(command,"UserMonitorId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"IsSuccess",DbType.Boolean,isSuccess);
				Database.AddInParameter(command,"UserIP",DbType.String,userIP);
				Database.AddInParameter(command,"UserName",DbType.String,userName);
				Database.AddInParameter(command,"DateCreated",DbType.DateTime,dateCreated);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 userMonitorId = Convert.ToInt32(Database.GetParameterValue(command, "UserMonitorId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for UserMonitor using Stored Procedure
		/// and return DbCommand of the UserMonitor
		/// </summary>
		public DbCommand InsertNewUserMonitorCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewUserMonitor");

				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				Database.AddInParameter(command,"IsSuccess",DbType.Boolean,"IsSuccess",DataRowVersion.Current);
				Database.AddInParameter(command,"UserIP",DbType.String,"UserIP",DataRowVersion.Current);
				Database.AddInParameter(command,"UserName",DbType.String,"UserName",DataRowVersion.Current);
				Database.AddInParameter(command,"DateCreated",DbType.DateTime,"DateCreated",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into UserMonitor using Stored Procedure
		/// </summary>
		public bool UpdateUserMonitor( int personId, bool isSuccess, string userIP, string userName, DateTime dateCreated, int olduserMonitorId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateUserMonitor");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"IsSuccess",DbType.Boolean,isSuccess);
		    		Database.AddInParameter(command,"UserIP",DbType.String,userIP);
		    		Database.AddInParameter(command,"UserName",DbType.String,userName);
		    		Database.AddInParameter(command,"DateCreated",DbType.DateTime,dateCreated);
				Database.AddInParameter(command,"oldUserMonitorId",DbType.Int32,olduserMonitorId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into UserMonitor using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateUserMonitor( int personId, bool isSuccess, string userIP, string userName, DateTime dateCreated, int olduserMonitorId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateUserMonitor");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"IsSuccess",DbType.Boolean,isSuccess);
		    		Database.AddInParameter(command,"UserIP",DbType.String,userIP);
		    		Database.AddInParameter(command,"UserName",DbType.String,userName);
		    		Database.AddInParameter(command,"DateCreated",DbType.DateTime,dateCreated);
				Database.AddInParameter(command,"oldUserMonitorId",DbType.Int32,olduserMonitorId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from UserMonitor using Stored Procedure
		/// </summary>
		public DbCommand UpdateUserMonitorCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateUserMonitor");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsSuccess",DbType.Boolean,"IsSuccess",DataRowVersion.Current);
		    		Database.AddInParameter(command,"UserIP",DbType.String,"UserIP",DataRowVersion.Current);
		    		Database.AddInParameter(command,"UserName",DbType.String,"UserName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DateCreated",DbType.DateTime,"DateCreated",DataRowVersion.Current);
				Database.AddInParameter(command,"oldUserMonitorId",DbType.Int32,"UserMonitorId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From UserMonitor using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteUserMonitor( int userMonitorId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteUserMonitor");
			Database.AddInParameter(command,"UserMonitorId",DbType.Int32,userMonitorId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From UserMonitor Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteUserMonitorCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteUserMonitor");
				Database.AddInParameter(command,"UserMonitorId",DbType.Int32,"UserMonitorId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table UserMonitor using Stored Procedure
		/// and return number of rows effected of the UserMonitor
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"UserMonitor",InsertNewUserMonitorCommand(),UpdateUserMonitorCommand(),DeleteUserMonitorCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table UserMonitor using Stored Procedure
		/// and return number of rows effected of the UserMonitor
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"UserMonitor",InsertNewUserMonitorCommand(),UpdateUserMonitorCommand(),DeleteUserMonitorCommand(), transaction);
          return rowsAffected;
		}


	}
}
