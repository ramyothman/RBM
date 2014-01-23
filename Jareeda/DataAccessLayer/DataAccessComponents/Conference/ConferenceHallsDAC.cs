using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferenceHalls table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferenceHalls table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceHallsDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceHallsDAC() : base("", "Conference.ConferenceHalls") { }
		public ConferenceHallsDAC(string connectionString): base(connectionString){}
		public ConferenceHallsDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceHalls using Stored Procedure
		/// and return a DataTable containing all ConferenceHalls Data
		/// </summary>
		public DataTable GetAllConferenceHalls()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceHalls";
         string query = " select * from GetAllConferenceHalls";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceHalls"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceHalls using Stored Procedure
		/// and return a DataTable containing all ConferenceHalls Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceHalls(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceHalls";
         string query = " select * from GetAllConferenceHalls";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceHalls"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceHalls using Stored Procedure
		/// and return a DataTable containing all ConferenceHalls Data
		/// </summary>
		public DataTable GetAllConferenceHalls(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceHalls";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferenceHalls" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceHalls"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceHalls using Stored Procedure
		/// and return a DataTable containing all ConferenceHalls Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceHalls(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceHalls";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferenceHalls" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceHalls"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceHalls using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceHalls( int conferenceHallsId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceHalls");
				    Database.AddInParameter(command,"ConferenceHallsId",DbType.Int32,conferenceHallsId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceHalls using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceHalls( int conferenceHallsId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceHalls");
				    Database.AddInParameter(command,"ConferenceHallsId",DbType.Int32,conferenceHallsId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceHalls using Stored Procedure
		/// and return the auto number primary key of ConferenceHalls inserted row
		/// </summary>
		public bool InsertNewConferenceHalls( ref int conferenceHallsId,  string name,  int conferenceId,  string mapPath)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceHalls");
				Database.AddOutParameter(command,"ConferenceHallsId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"MapPath",DbType.String,mapPath);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceHallsId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceHallsId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceHalls using Stored Procedure
		/// and return the auto number primary key of ConferenceHalls inserted row using Transaction
		/// </summary>
		public bool InsertNewConferenceHalls( ref int conferenceHallsId,  string name,  int conferenceId,  string mapPath,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceHalls");
				Database.AddOutParameter(command,"ConferenceHallsId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"MapPath",DbType.String,mapPath);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceHallsId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceHallsId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceHalls using Stored Procedure
		/// and return DbCommand of the ConferenceHalls
		/// </summary>
		public DbCommand InsertNewConferenceHallsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceHalls");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"MapPath",DbType.String,"MapPath",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceHalls using Stored Procedure
		/// </summary>
		public bool UpdateConferenceHalls( string name, int conferenceId, string mapPath, int oldconferenceHallsId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceHalls");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"MapPath",DbType.String,mapPath);
				Database.AddInParameter(command,"oldConferenceHallsId",DbType.Int32,oldconferenceHallsId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceHalls using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateConferenceHalls( string name, int conferenceId, string mapPath, int oldconferenceHallsId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceHalls");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"MapPath",DbType.String,mapPath);
				Database.AddInParameter(command,"oldConferenceHallsId",DbType.Int32,oldconferenceHallsId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceHalls using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceHallsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceHalls");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"MapPath",DbType.String,"MapPath",DataRowVersion.Current);
				Database.AddInParameter(command,"oldConferenceHallsId",DbType.Int32,"ConferenceHallsId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceHalls using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferenceHalls( int conferenceHallsId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferenceHalls");
			Database.AddInParameter(command,"ConferenceHallsId",DbType.Int32,conferenceHallsId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceHalls Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceHallsCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceHalls");
				Database.AddInParameter(command,"ConferenceHallsId",DbType.Int32,"ConferenceHallsId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceHalls using Stored Procedure
		/// and return number of rows effected of the ConferenceHalls
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceHalls",InsertNewConferenceHallsCommand(),UpdateConferenceHallsCommand(),DeleteConferenceHallsCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceHalls using Stored Procedure
		/// and return number of rows effected of the ConferenceHalls
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceHalls",InsertNewConferenceHallsCommand(),UpdateConferenceHallsCommand(),DeleteConferenceHallsCommand(), transaction);
          return rowsAffected;
		}


	}
}
