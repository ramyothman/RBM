using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferencePrograms table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferencePrograms table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceProgramsDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceProgramsDAC() : base("", "Conference.ConferencePrograms") { }
		public ConferenceProgramsDAC(string connectionString): base(connectionString){}
		public ConferenceProgramsDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferencePrograms using Stored Procedure
		/// and return a DataTable containing all ConferencePrograms Data
		/// </summary>
		public DataTable GetAllConferencePrograms()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferencePrograms";
         string query = " select * from GetAllConferencePrograms";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferencePrograms"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferencePrograms using Stored Procedure
		/// and return a DataTable containing all ConferencePrograms Data using a Transaction
		/// </summary>
		public DataTable GetAllConferencePrograms(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferencePrograms";
         string query = " select * from GetAllConferencePrograms";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferencePrograms"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferencePrograms using Stored Procedure
		/// and return a DataTable containing all ConferencePrograms Data
		/// </summary>
		public DataTable GetAllConferencePrograms(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferencePrograms";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferencePrograms" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferencePrograms"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferencePrograms using Stored Procedure
		/// and return a DataTable containing all ConferencePrograms Data using a Transaction
		/// </summary>
		public DataTable GetAllConferencePrograms(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferencePrograms";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferencePrograms" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferencePrograms"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferencePrograms using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferencePrograms( int conferenceProgramId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferencePrograms");
				    Database.AddInParameter(command,"ConferenceProgramId",DbType.Int32,conferenceProgramId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferencePrograms using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferencePrograms( int conferenceProgramId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferencePrograms");
				    Database.AddInParameter(command,"ConferenceProgramId",DbType.Int32,conferenceProgramId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferencePrograms using Stored Procedure
		/// and return the auto number primary key of ConferencePrograms inserted row
		/// </summary>
		public bool InsertNewConferencePrograms( ref int conferenceProgramId,  string programName,  int conferenceId)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferencePrograms");
				Database.AddOutParameter(command,"ConferenceProgramId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ProgramName",DbType.String,programName);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceProgramId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceProgramId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferencePrograms using Stored Procedure
		/// and return the auto number primary key of ConferencePrograms inserted row using Transaction
		/// </summary>
		public bool InsertNewConferencePrograms( ref int conferenceProgramId,  string programName,  int conferenceId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferencePrograms");
				Database.AddOutParameter(command,"ConferenceProgramId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ProgramName",DbType.String,programName);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceProgramId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceProgramId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferencePrograms using Stored Procedure
		/// and return DbCommand of the ConferencePrograms
		/// </summary>
		public DbCommand InsertNewConferenceProgramsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferencePrograms");

				Database.AddInParameter(command,"ProgramName",DbType.String,"ProgramName",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferencePrograms using Stored Procedure
		/// </summary>
		public bool UpdateConferencePrograms( string programName, int conferenceId, int oldconferenceProgramId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferencePrograms");

		    		Database.AddInParameter(command,"ProgramName",DbType.String,programName);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"oldConferenceProgramId",DbType.Int32,oldconferenceProgramId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferencePrograms using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateConferencePrograms( string programName, int conferenceId, int oldconferenceProgramId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferencePrograms");

		    		Database.AddInParameter(command,"ProgramName",DbType.String,programName);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"oldConferenceProgramId",DbType.Int32,oldconferenceProgramId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferencePrograms using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceProgramsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferencePrograms");

		    		Database.AddInParameter(command,"ProgramName",DbType.String,"ProgramName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"oldConferenceProgramId",DbType.Int32,"ConferenceProgramId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferencePrograms using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferencePrograms( int conferenceProgramId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferencePrograms");
			Database.AddInParameter(command,"ConferenceProgramId",DbType.Int32,conferenceProgramId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferencePrograms Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceProgramsCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferencePrograms");
				Database.AddInParameter(command,"ConferenceProgramId",DbType.Int32,"ConferenceProgramId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferencePrograms using Stored Procedure
		/// and return number of rows effected of the ConferencePrograms
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferencePrograms",InsertNewConferenceProgramsCommand(),UpdateConferenceProgramsCommand(),DeleteConferenceProgramsCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferencePrograms using Stored Procedure
		/// and return number of rows effected of the ConferencePrograms
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferencePrograms",InsertNewConferenceProgramsCommand(),UpdateConferenceProgramsCommand(),DeleteConferenceProgramsCommand(), transaction);
          return rowsAffected;
		}


	}
}
