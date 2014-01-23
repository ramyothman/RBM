using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for Travel table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Travel table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class TravelDAC : DataAccessComponent
	{
		#region Constructors
        public TravelDAC() : base("", "Conference.Travel") { }
		public TravelDAC(string connectionString): base(connectionString){}
		public TravelDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Travel using Stored Procedure
		/// and return a DataTable containing all Travel Data
		/// </summary>
		public DataTable GetAllTravel()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Travel";
         string query = " select * from GetAllTravel";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Travel"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Travel using Stored Procedure
		/// and return a DataTable containing all Travel Data using a Transaction
		/// </summary>
		public DataTable GetAllTravel(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Travel";
         string query = " select * from GetAllTravel";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Travel"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Travel using Stored Procedure
		/// and return a DataTable containing all Travel Data
		/// </summary>
		public DataTable GetAllTravel(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Travel";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllTravel" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Travel"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Travel using Stored Procedure
		/// and return a DataTable containing all Travel Data using a Transaction
		/// </summary>
		public DataTable GetAllTravel(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Travel";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllTravel" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Travel"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Travel using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDTravel( int iD)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDTravel");
				    Database.AddInParameter(command,"ID",DbType.Int32,iD);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Travel using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDTravel( int iD,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDTravel");
				    Database.AddInParameter(command,"ID",DbType.Int32,iD);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Travel using Stored Procedure
		/// and return the auto number primary key of Travel inserted row
		/// </summary>
        public bool InsertNewTravel(ref int iD, string name, int transportationTypeID, string description, int ConferenceID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewTravel");
				Database.AddOutParameter(command,"ID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"TransportationTypeID",DbType.Int32,transportationTypeID);
				Database.AddInParameter(command,"Description",DbType.String,description);
                Database.AddInParameter(command, "ConferenceID", DbType.Int32, ConferenceID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Travel using Stored Procedure
		/// and return the auto number primary key of Travel inserted row using Transaction
		/// </summary>
        public bool InsertNewTravel(ref int iD, string name, int transportationTypeID, string description, int ConferenceID, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewTravel");
				Database.AddOutParameter(command,"ID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"TransportationTypeID",DbType.Int32,transportationTypeID);
				Database.AddInParameter(command,"Description",DbType.String,description);
                Database.AddInParameter(command, "ConferenceID", DbType.Int32, ConferenceID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Travel using Stored Procedure
		/// and return DbCommand of the Travel
		/// </summary>
		public DbCommand InsertNewTravelCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewTravel");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"TransportationTypeID",DbType.Int32,"TransportationTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Travel using Stored Procedure
		/// </summary>
        public bool UpdateTravel(string name, int transportationTypeID, string description, int ConferenceID, int oldiD)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateTravel");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"TransportationTypeID",DbType.Int32,transportationTypeID);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
                    Database.AddInParameter(command, "ConferenceID", DbType.Int32, ConferenceID);
				Database.AddInParameter(command,"oldID",DbType.Int32,oldiD);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Travel using Stored Procedure By Transaction
		/// </summary>
        public bool UpdateTravel(string name, int transportationTypeID, string description, int ConferenceID, int oldiD, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateTravel");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"TransportationTypeID",DbType.Int32,transportationTypeID);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
                    Database.AddInParameter(command, "ConferenceID", DbType.Int32, ConferenceID);
				Database.AddInParameter(command,"oldID",DbType.Int32,oldiD);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Travel using Stored Procedure
		/// </summary>
		public DbCommand UpdateTravelCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateTravel");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"TransportationTypeID",DbType.Int32,"TransportationTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
				Database.AddInParameter(command,"oldID",DbType.Int32,"ID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Travel using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteTravel( int iD)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteTravel");
			Database.AddInParameter(command,"ID",DbType.Int32,iD);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Travel Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteTravelCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteTravel");
				Database.AddInParameter(command,"ID",DbType.Int32,"ID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Travel using Stored Procedure
		/// and return number of rows effected of the Travel
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Travel",InsertNewTravelCommand(),UpdateTravelCommand(),DeleteTravelCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Travel using Stored Procedure
		/// and return number of rows effected of the Travel
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Travel",InsertNewTravelCommand(),UpdateTravelCommand(),DeleteTravelCommand(), transaction);
          return rowsAffected;
		}


	}
}
