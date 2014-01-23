using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferenceRegistrationItems table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferenceRegistrationItems table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceRegistrationItemsDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceRegistrationItemsDAC() : base("", "Conference.ConferenceRegistrationItems") { }
		public ConferenceRegistrationItemsDAC(string connectionString): base(connectionString){}
		public ConferenceRegistrationItemsDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationItems using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationItems Data
		/// </summary>
		public DataTable GetAllConferenceRegistrationItems()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationItems";
         string query = " select * from GetAllConferenceRegistrationItems";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceRegistrationItems"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationItems using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationItems Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceRegistrationItems(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationItems";
         string query = " select * from GetAllConferenceRegistrationItems";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceRegistrationItems"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationItems using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationItems Data
		/// </summary>
		public DataTable GetAllConferenceRegistrationItems(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationItems";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferenceRegistrationItems" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceRegistrationItems"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationItems using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationItems Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceRegistrationItems(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationItems";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferenceRegistrationItems" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceRegistrationItems"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceRegistrationItems using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceRegistrationItems( int conferenceRegistrationItemID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceRegistrationItems");
				    Database.AddInParameter(command,"ConferenceRegistrationItemID",DbType.Int32,conferenceRegistrationItemID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceRegistrationItems using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceRegistrationItems( int conferenceRegistrationItemID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceRegistrationItems");
				    Database.AddInParameter(command,"ConferenceRegistrationItemID",DbType.Int32,conferenceRegistrationItemID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceRegistrationItems using Stored Procedure
		/// and return the auto number primary key of ConferenceRegistrationItems inserted row
		/// </summary>
		public bool InsertNewConferenceRegistrationItems( ref int conferenceRegistrationItemID,  int conferenceRegistrationTypeID,  int conferenceRegistererId,  DateTime createdDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceRegistrationItems");
				Database.AddOutParameter(command,"ConferenceRegistrationItemID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceRegistrationTypeID",DbType.Int32,conferenceRegistrationTypeID);
				Database.AddInParameter(command,"ConferenceRegistererId",DbType.Int32,conferenceRegistererId);
				Database.AddInParameter(command,"CreatedDate",DbType.DateTime,createdDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceRegistrationItemID = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceRegistrationItemID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceRegistrationItems using Stored Procedure
		/// and return the auto number primary key of ConferenceRegistrationItems inserted row using Transaction
		/// </summary>
		public bool InsertNewConferenceRegistrationItems( ref int conferenceRegistrationItemID,  int conferenceRegistrationTypeID,  int conferenceRegistererId,  DateTime createdDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceRegistrationItems");
				Database.AddOutParameter(command,"ConferenceRegistrationItemID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceRegistrationTypeID",DbType.Int32,conferenceRegistrationTypeID);
				Database.AddInParameter(command,"ConferenceRegistererId",DbType.Int32,conferenceRegistererId);
				Database.AddInParameter(command,"CreatedDate",DbType.DateTime,createdDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceRegistrationItemID = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceRegistrationItemID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceRegistrationItems using Stored Procedure
		/// and return DbCommand of the ConferenceRegistrationItems
		/// </summary>
		public DbCommand InsertNewConferenceRegistrationItemsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceRegistrationItems");

				Database.AddInParameter(command,"ConferenceRegistrationTypeID",DbType.Int32,"ConferenceRegistrationTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceRegistererId",DbType.Int32,"ConferenceRegistererId",DataRowVersion.Current);
				Database.AddInParameter(command,"CreatedDate",DbType.DateTime,"CreatedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceRegistrationItems using Stored Procedure
		/// </summary>
		public bool UpdateConferenceRegistrationItems( int conferenceRegistrationTypeID, int conferenceRegistererId, DateTime createdDate, int oldconferenceRegistrationItemID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceRegistrationItems");

		    		Database.AddInParameter(command,"ConferenceRegistrationTypeID",DbType.Int32,conferenceRegistrationTypeID);
		    		Database.AddInParameter(command,"ConferenceRegistererId",DbType.Int32,conferenceRegistererId);
		    		Database.AddInParameter(command,"CreatedDate",DbType.DateTime,createdDate);
				Database.AddInParameter(command,"oldConferenceRegistrationItemID",DbType.Int32,oldconferenceRegistrationItemID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceRegistrationItems using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateConferenceRegistrationItems( int conferenceRegistrationTypeID, int conferenceRegistererId, DateTime createdDate, int oldconferenceRegistrationItemID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceRegistrationItems");

		    		Database.AddInParameter(command,"ConferenceRegistrationTypeID",DbType.Int32,conferenceRegistrationTypeID);
		    		Database.AddInParameter(command,"ConferenceRegistererId",DbType.Int32,conferenceRegistererId);
		    		Database.AddInParameter(command,"CreatedDate",DbType.DateTime,createdDate);
				Database.AddInParameter(command,"oldConferenceRegistrationItemID",DbType.Int32,oldconferenceRegistrationItemID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceRegistrationItems using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceRegistrationItemsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceRegistrationItems");

		    		Database.AddInParameter(command,"ConferenceRegistrationTypeID",DbType.Int32,"ConferenceRegistrationTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceRegistererId",DbType.Int32,"ConferenceRegistererId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CreatedDate",DbType.DateTime,"CreatedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldConferenceRegistrationItemID",DbType.Int32,"ConferenceRegistrationItemID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceRegistrationItems using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferenceRegistrationItems( int conferenceRegistrationItemID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferenceRegistrationItems");
			Database.AddInParameter(command,"ConferenceRegistrationItemID",DbType.Int32,conferenceRegistrationItemID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

        public bool DeleteConferenceRegistrationItemsByConferenceRegistererId(int ConferenceRegistererId)
        {
            DbCommand command = Database.GetStoredProcCommand("DeleteConferenceRegistrationItemsByConferenceRegistererId");
            Database.AddInParameter(command, "ConferenceRegistererId", DbType.Int32, ConferenceRegistererId);
            bool status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                status = true;
            }
            return status;
        }

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceRegistrationItems Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceRegistrationItemsCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceRegistrationItems");
				Database.AddInParameter(command,"ConferenceRegistrationItemID",DbType.Int32,"ConferenceRegistrationItemID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceRegistrationItems using Stored Procedure
		/// and return number of rows effected of the ConferenceRegistrationItems
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceRegistrationItems",InsertNewConferenceRegistrationItemsCommand(),UpdateConferenceRegistrationItemsCommand(),DeleteConferenceRegistrationItemsCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceRegistrationItems using Stored Procedure
		/// and return number of rows effected of the ConferenceRegistrationItems
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceRegistrationItems",InsertNewConferenceRegistrationItemsCommand(),UpdateConferenceRegistrationItemsCommand(),DeleteConferenceRegistrationItemsCommand(), transaction);
          return rowsAffected;
		}


	}
}
