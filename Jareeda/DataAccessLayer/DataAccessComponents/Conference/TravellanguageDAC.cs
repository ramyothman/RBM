using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for Travellanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Travellanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class TravellanguageDAC : DataAccessComponent
	{
		#region Constructors
        public TravellanguageDAC() : base("", "Conference.Travellanguage") { }
		public TravellanguageDAC(string connectionString): base(connectionString){}
		public TravellanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Travellanguage using Stored Procedure
		/// and return a DataTable containing all Travellanguage Data
		/// </summary>
		public DataTable GetAllTravellanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Travellanguage";
         string query = " select * from GetAllTravellanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Travellanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Travellanguage using Stored Procedure
		/// and return a DataTable containing all Travellanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllTravellanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Travellanguage";
         string query = " select * from GetAllTravellanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Travellanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Travellanguage using Stored Procedure
		/// and return a DataTable containing all Travellanguage Data
		/// </summary>
		public DataTable GetAllTravellanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Travellanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllTravellanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Travellanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Travellanguage using Stored Procedure
		/// and return a DataTable containing all Travellanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllTravellanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Travellanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllTravellanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Travellanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Travellanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDTravellanguage( int iD)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDTravellanguage");
				    Database.AddInParameter(command,"ID",DbType.Int32,iD);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Travellanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDTravellanguage( int iD,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDTravellanguage");
				    Database.AddInParameter(command,"ID",DbType.Int32,iD);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Travellanguage using Stored Procedure
		/// and return the auto number primary key of Travellanguage inserted row
		/// </summary>
		public bool InsertNewTravellanguage( ref int iD,  string name,  int transportationTypeID,  string description,  int parentID,  int languageID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewTravellanguage");
				Database.AddOutParameter(command,"ID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"TransportationTypeID",DbType.Int32,transportationTypeID);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"ParentID",DbType.Int32,parentID);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Travellanguage using Stored Procedure
		/// and return the auto number primary key of Travellanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewTravellanguage( ref int iD,  string name,  int transportationTypeID,  string description,  int parentID,  int languageID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewTravellanguage");
				Database.AddOutParameter(command,"ID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"TransportationTypeID",DbType.Int32,transportationTypeID);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"ParentID",DbType.Int32,parentID);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Travellanguage using Stored Procedure
		/// and return DbCommand of the Travellanguage
		/// </summary>
		public DbCommand InsertNewTravellanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewTravellanguage");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"TransportationTypeID",DbType.Int32,"TransportationTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
				Database.AddInParameter(command,"ParentID",DbType.Int32,"ParentID",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Travellanguage using Stored Procedure
		/// </summary>
		public bool UpdateTravellanguage( string name, int transportationTypeID, string description, int parentID, int languageID, int oldiD)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateTravellanguage");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"TransportationTypeID",DbType.Int32,transportationTypeID);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"ParentID",DbType.Int32,parentID);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"oldID",DbType.Int32,oldiD);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Travellanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateTravellanguage( string name, int transportationTypeID, string description, int parentID, int languageID, int oldiD,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateTravellanguage");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"TransportationTypeID",DbType.Int32,transportationTypeID);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"ParentID",DbType.Int32,parentID);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"oldID",DbType.Int32,oldiD);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Travellanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateTravellanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateTravellanguage");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"TransportationTypeID",DbType.Int32,"TransportationTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ParentID",DbType.Int32,"ParentID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldID",DbType.Int32,"ID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Travellanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteTravellanguage( int iD)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteTravellanguage");
			Database.AddInParameter(command,"ID",DbType.Int32,iD);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Travellanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteTravellanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteTravellanguage");
				Database.AddInParameter(command,"ID",DbType.Int32,"ID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Travellanguage using Stored Procedure
		/// and return number of rows effected of the Travellanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Travellanguage",InsertNewTravellanguageCommand(),UpdateTravellanguageCommand(),DeleteTravellanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Travellanguage using Stored Procedure
		/// and return number of rows effected of the Travellanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Travellanguage",InsertNewTravellanguageCommand(),UpdateTravellanguageCommand(),DeleteTravellanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
