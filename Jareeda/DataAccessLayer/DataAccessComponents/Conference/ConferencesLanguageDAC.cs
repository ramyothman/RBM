using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferencesLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferencesLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferencesLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public ConferencesLanguageDAC() : base("", "Conference.ConferencesLanguage") { }
		public ConferencesLanguageDAC(string connectionString): base(connectionString){}
		public ConferencesLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferencesLanguage using Stored Procedure
		/// and return a DataTable containing all ConferencesLanguage Data
		/// </summary>
		public DataTable GetAllConferencesLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferencesLanguage";
         string query = " select * from GetAllConferencesLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);

         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferencesLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferencesLanguage using Stored Procedure
		/// and return a DataTable containing all ConferencesLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllConferencesLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferencesLanguage";
         string query = " select * from GetAllConferencesLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferencesLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferencesLanguage using Stored Procedure
		/// and return a DataTable containing all ConferencesLanguage Data
		/// </summary>
		public DataTable GetAllConferencesLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferencesLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferencesLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferencesLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferencesLanguage using Stored Procedure
		/// and return a DataTable containing all ConferencesLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllConferencesLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferencesLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferencesLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferencesLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferencesLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferencesLanguage( int conferenceId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferencesLanguage");
				    Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferencesLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferencesLanguage( int conferenceId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferencesLanguage");
				    Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferencesLanguage using Stored Procedure
		/// and return the auto number primary key of ConferencesLanguage inserted row
		/// </summary>
		public bool InsertNewConferencesLanguage( ref int conferenceId,  int siteId,  string conferenceName,  string conferenceLogo,  DateTime startDate,  DateTime endDate,  bool isActive,  string location,  string locationName,  string locationLogo,  decimal locationLongitude,  decimal locationLatitude,  string conferenceDomain,  int conferenceParentId,  int languageID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferencesLanguage");
				Database.AddOutParameter(command,"ConferenceId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
				Database.AddInParameter(command,"ConferenceName",DbType.String,conferenceName);
				Database.AddInParameter(command,"ConferenceLogo",DbType.String,conferenceLogo);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"Location",DbType.String,location);
				Database.AddInParameter(command,"LocationName",DbType.String,locationName);
				Database.AddInParameter(command,"LocationLogo",DbType.String,locationLogo);
				Database.AddInParameter(command,"LocationLongitude",DbType.Decimal,locationLongitude);
				Database.AddInParameter(command,"LocationLatitude",DbType.Decimal,locationLatitude);
				Database.AddInParameter(command,"ConferenceDomain",DbType.String,conferenceDomain);
				Database.AddInParameter(command,"ConferenceParentId",DbType.Int32,conferenceParentId);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferencesLanguage using Stored Procedure
		/// and return the auto number primary key of ConferencesLanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewConferencesLanguage( ref int conferenceId,  int siteId,  string conferenceName,  string conferenceLogo,  DateTime startDate,  DateTime endDate,  bool isActive,  string location,  string locationName,  string locationLogo,  decimal locationLongitude,  decimal locationLatitude,  string conferenceDomain,  int conferenceParentId,  int languageID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferencesLanguage");
				Database.AddOutParameter(command,"ConferenceId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
				Database.AddInParameter(command,"ConferenceName",DbType.String,conferenceName);
				Database.AddInParameter(command,"ConferenceLogo",DbType.String,conferenceLogo);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"Location",DbType.String,location);
				Database.AddInParameter(command,"LocationName",DbType.String,locationName);
				Database.AddInParameter(command,"LocationLogo",DbType.String,locationLogo);
				Database.AddInParameter(command,"LocationLongitude",DbType.Decimal,locationLongitude);
				Database.AddInParameter(command,"LocationLatitude",DbType.Decimal,locationLatitude);
				Database.AddInParameter(command,"ConferenceDomain",DbType.String,conferenceDomain);
				Database.AddInParameter(command,"ConferenceParentId",DbType.Int32,conferenceParentId);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferencesLanguage using Stored Procedure
		/// and return DbCommand of the ConferencesLanguage
		/// </summary>
		public DbCommand InsertNewConferencesLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferencesLanguage");

				Database.AddInParameter(command,"SiteId",DbType.Int32,"SiteId",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceName",DbType.String,"ConferenceName",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceLogo",DbType.String,"ConferenceLogo",DataRowVersion.Current);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,"StartDate",DataRowVersion.Current);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,"EndDate",DataRowVersion.Current);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
				Database.AddInParameter(command,"Location",DbType.String,"Location",DataRowVersion.Current);
				Database.AddInParameter(command,"LocationName",DbType.String,"LocationName",DataRowVersion.Current);
				Database.AddInParameter(command,"LocationLogo",DbType.String,"LocationLogo",DataRowVersion.Current);
				Database.AddInParameter(command,"LocationLongitude",DbType.Decimal,"LocationLongitude",DataRowVersion.Current);
				Database.AddInParameter(command,"LocationLatitude",DbType.Decimal,"LocationLatitude",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceDomain",DbType.String,"ConferenceDomain",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceParentId",DbType.Int32,"ConferenceParentId",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferencesLanguage using Stored Procedure
		/// </summary>
		public bool UpdateConferencesLanguage( int siteId, string conferenceName, string conferenceLogo, DateTime startDate, DateTime endDate, bool isActive, string location, string locationName, string locationLogo, decimal locationLongitude, decimal locationLatitude, string conferenceDomain, int conferenceParentId, int languageID, int oldconferenceId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferencesLanguage");

		    		Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
		    		Database.AddInParameter(command,"ConferenceName",DbType.String,conferenceName);
		    		Database.AddInParameter(command,"ConferenceLogo",DbType.String,conferenceLogo);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
		    		Database.AddInParameter(command,"Location",DbType.String,location);
		    		Database.AddInParameter(command,"LocationName",DbType.String,locationName);
		    		Database.AddInParameter(command,"LocationLogo",DbType.String,locationLogo);
		    		Database.AddInParameter(command,"LocationLongitude",DbType.Decimal,locationLongitude);
		    		Database.AddInParameter(command,"LocationLatitude",DbType.Decimal,locationLatitude);
		    		Database.AddInParameter(command,"ConferenceDomain",DbType.String,conferenceDomain);
		    		Database.AddInParameter(command,"ConferenceParentId",DbType.Int32,conferenceParentId);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"oldConferenceId",DbType.Int32,oldconferenceId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferencesLanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateConferencesLanguage( int siteId, string conferenceName, string conferenceLogo, DateTime startDate, DateTime endDate, bool isActive, string location, string locationName, string locationLogo, decimal locationLongitude, decimal locationLatitude, string conferenceDomain, int conferenceParentId, int languageID, int oldconferenceId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferencesLanguage");

		    		Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
		    		Database.AddInParameter(command,"ConferenceName",DbType.String,conferenceName);
		    		Database.AddInParameter(command,"ConferenceLogo",DbType.String,conferenceLogo);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
		    		Database.AddInParameter(command,"Location",DbType.String,location);
		    		Database.AddInParameter(command,"LocationName",DbType.String,locationName);
		    		Database.AddInParameter(command,"LocationLogo",DbType.String,locationLogo);
		    		Database.AddInParameter(command,"LocationLongitude",DbType.Decimal,locationLongitude);
		    		Database.AddInParameter(command,"LocationLatitude",DbType.Decimal,locationLatitude);
		    		Database.AddInParameter(command,"ConferenceDomain",DbType.String,conferenceDomain);
		    		Database.AddInParameter(command,"ConferenceParentId",DbType.Int32,conferenceParentId);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"oldConferenceId",DbType.Int32,oldconferenceId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferencesLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferencesLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferencesLanguage");

		    		Database.AddInParameter(command,"SiteId",DbType.Int32,"SiteId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceName",DbType.String,"ConferenceName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceLogo",DbType.String,"ConferenceLogo",DataRowVersion.Current);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,"StartDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,"EndDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Location",DbType.String,"Location",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LocationName",DbType.String,"LocationName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LocationLogo",DbType.String,"LocationLogo",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LocationLongitude",DbType.Decimal,"LocationLongitude",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LocationLatitude",DbType.Decimal,"LocationLatitude",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceDomain",DbType.String,"ConferenceDomain",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceParentId",DbType.Int32,"ConferenceParentId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferencesLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferencesLanguage( int conferenceId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferencesLanguage");
			Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferencesLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferencesLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferencesLanguage");
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferencesLanguage using Stored Procedure
		/// and return number of rows effected of the ConferencesLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferencesLanguage",InsertNewConferencesLanguageCommand(),UpdateConferencesLanguageCommand(),DeleteConferencesLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferencesLanguage using Stored Procedure
		/// and return number of rows effected of the ConferencesLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferencesLanguage",InsertNewConferencesLanguageCommand(),UpdateConferencesLanguageCommand(),DeleteConferencesLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
