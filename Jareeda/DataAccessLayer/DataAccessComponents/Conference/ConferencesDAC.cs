using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for Conferences table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Conferences table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferencesDAC : DataAccessComponent
	{
		#region Constructors
        public ConferencesDAC() : base("", "Conference.Conferences") { }
		public ConferencesDAC(string connectionString): base(connectionString){}
		public ConferencesDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Conferences using Stored Procedure
		/// and return a DataTable containing all Conferences Data
		/// </summary>
		public DataTable GetAllConferences()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Conferences";
         string query = " select * from GetAllConferences";
         DbCommand command = Database.GetSqlStringCommand(query);

         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Conferences"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Conferences using Stored Procedure
		/// and return a DataTable containing all Conferences Data using a Transaction
		/// </summary>
		public DataTable GetAllConferences(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Conferences";
         string query = " select * from GetAllConferences";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Conferences"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Conferences using Stored Procedure
		/// and return a DataTable containing all Conferences Data
		/// </summary>
		public DataTable GetAllConferences(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Conferences";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferences" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);

         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Conferences"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Conferences using Stored Procedure
		/// and return a DataTable containing all Conferences Data using a Transaction
		/// </summary>
		public DataTable GetAllConferences(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Conferences";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferences" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Conferences"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Conferences using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferences( int conferenceId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferences");
				    Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Conferences using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferences( int conferenceId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferences");
				    Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Conferences using Stored Procedure
		/// and return the auto number primary key of Conferences inserted row
		/// </summary>
        public bool InsertNewConferences(ref int conferenceId, int siteId, string conferenceName, string conferenceLogo, DateTime startDate, DateTime endDate, bool isActive, string location, string locationName, string locationLogo, decimal locationLongitude, decimal locationLatitude, string conferenceDomain, string ConferenceCode, string ConferenceAlias, int ConferenceVenueID, bool IsDefault, DateTime AbstractSubmissionStartDate, DateTime AbstractSubmissionEndDate, int AbstractSubmissionEndMessagePageID, int AbstractSubmissionNotStartedPageID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferences");
				Database.AddOutParameter(command,"ConferenceId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
				Database.AddInParameter(command,"ConferenceName",DbType.String,conferenceName);
				Database.AddInParameter(command,"ConferenceLogo",DbType.String,conferenceLogo);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
                if(endDate == DateTime.MinValue)
				    Database.AddInParameter(command,"EndDate",DbType.DateTime,DBNull.Value);
                else
                    Database.AddInParameter(command, "EndDate", DbType.DateTime, endDate);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"Location",DbType.String,location);
				Database.AddInParameter(command,"LocationName",DbType.String,locationName);
				Database.AddInParameter(command,"LocationLogo",DbType.String,locationLogo);
				Database.AddInParameter(command,"LocationLongitude",DbType.Decimal,locationLongitude);
				Database.AddInParameter(command,"LocationLatitude",DbType.Decimal,locationLatitude);
				Database.AddInParameter(command,"ConferenceDomain",DbType.String,conferenceDomain);
                Database.AddInParameter(command, "ConferenceCode", DbType.String, ConferenceCode);
                Database.AddInParameter(command, "ConferenceAlias", DbType.String, ConferenceAlias);
                Database.AddInParameter(command, "ConferenceVenueID", DbType.Int32, ConferenceVenueID);
                Database.AddInParameter(command, "IsDefault", DbType.Boolean, IsDefault);
                if (AbstractSubmissionStartDate == DateTime.MinValue)
                    Database.AddInParameter(command, "AbstractSubmissionStartDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "AbstractSubmissionStartDate", DbType.DateTime, AbstractSubmissionStartDate);
                if (AbstractSubmissionEndDate == DateTime.MinValue)
                    Database.AddInParameter(command, "AbstractSubmissionEndDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "AbstractSubmissionEndDate", DbType.DateTime, AbstractSubmissionEndDate);

                if(AbstractSubmissionEndMessagePageID == 0)
                    Database.AddInParameter(command, "AbstractSubmissionEndMessagePageID", DbType.Int32, DBNull.Value);
                else
                    Database.AddInParameter(command, "AbstractSubmissionEndMessagePageID", DbType.Int32, AbstractSubmissionEndMessagePageID);

                if (AbstractSubmissionNotStartedPageID == 0)
                    Database.AddInParameter(command, "AbstractSubmissionNotStartedPageID", DbType.Int32, DBNull.Value);
                else
                    Database.AddInParameter(command, "AbstractSubmissionNotStartedPageID", DbType.Int32, AbstractSubmissionNotStartedPageID);
                
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Conferences using Stored Procedure
		/// and return the auto number primary key of Conferences inserted row using Transaction
		/// </summary>
        public bool InsertNewConferences(ref int conferenceId, int siteId, string conferenceName, string conferenceLogo, DateTime startDate, DateTime endDate, bool isActive, string location, string locationName, string locationLogo, decimal locationLongitude, decimal locationLatitude, string conferenceDomain, string ConferenceCode, string ConferenceAlias, int ConferenceVenueID, bool IsDefault, DateTime AbstractSubmissionStartDate, DateTime AbstractSubmissionEndDate, int AbstractSubmissionEndMessagePageID, int AbstractSubmissionNotStartedPageID, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferences");
				Database.AddOutParameter(command,"ConferenceId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
				Database.AddInParameter(command,"ConferenceName",DbType.String,conferenceName);
				Database.AddInParameter(command,"ConferenceLogo",DbType.String,conferenceLogo);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
                if (endDate == DateTime.MinValue)
                    Database.AddInParameter(command, "EndDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "EndDate", DbType.DateTime, endDate);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"Location",DbType.String,location);
				Database.AddInParameter(command,"LocationName",DbType.String,locationName);
				Database.AddInParameter(command,"LocationLogo",DbType.String,locationLogo);
				Database.AddInParameter(command,"LocationLongitude",DbType.Decimal,locationLongitude);
				Database.AddInParameter(command,"LocationLatitude",DbType.Decimal,locationLatitude);
				Database.AddInParameter(command,"ConferenceDomain",DbType.String,conferenceDomain);
                Database.AddInParameter(command, "ConferenceCode", DbType.String, ConferenceCode);
                Database.AddInParameter(command, "ConferenceAlias", DbType.String, ConferenceAlias);
                Database.AddInParameter(command, "ConferenceVenueID", DbType.Int32, ConferenceVenueID);
                Database.AddInParameter(command, "IsDefault", DbType.Boolean, IsDefault);
                if (AbstractSubmissionStartDate == DateTime.MinValue)
                    Database.AddInParameter(command, "AbstractSubmissionStartDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "AbstractSubmissionStartDate", DbType.DateTime, AbstractSubmissionStartDate);
                if (AbstractSubmissionEndDate == DateTime.MinValue)
                    Database.AddInParameter(command, "AbstractSubmissionEndDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "AbstractSubmissionEndDate", DbType.DateTime, AbstractSubmissionEndDate);

                if (AbstractSubmissionEndMessagePageID == 0)
                    Database.AddInParameter(command, "AbstractSubmissionEndMessagePageID", DbType.Int32, DBNull.Value);
                else
                    Database.AddInParameter(command, "AbstractSubmissionEndMessagePageID", DbType.Int32, AbstractSubmissionEndMessagePageID);

                if (AbstractSubmissionNotStartedPageID == 0)
                    Database.AddInParameter(command, "AbstractSubmissionNotStartedPageID", DbType.Int32, DBNull.Value);
                else
                    Database.AddInParameter(command, "AbstractSubmissionNotStartedPageID", DbType.Int32, AbstractSubmissionNotStartedPageID);
                
            bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Conferences using Stored Procedure
		/// and return DbCommand of the Conferences
		/// </summary>
		public DbCommand InsertNewConferencesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferences");

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
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Conferences using Stored Procedure
		/// </summary>
        public bool UpdateConferences(int siteId, string conferenceName, string conferenceLogo, DateTime startDate, DateTime endDate, bool isActive, string location, string locationName, string locationLogo, decimal locationLongitude, decimal locationLatitude, string conferenceDomain, string ConferenceCode, string ConferenceAlias, int ConferenceVenueID, bool IsDefault, DateTime AbstractSubmissionStartDate, DateTime AbstractSubmissionEndDate, int AbstractSubmissionEndMessagePageID, int AbstractSubmissionNotStartedPageID, int oldconferenceId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferences");

		    		Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
		    		Database.AddInParameter(command,"ConferenceName",DbType.String,conferenceName);
		    		Database.AddInParameter(command,"ConferenceLogo",DbType.String,conferenceLogo);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
                    if (endDate == DateTime.MinValue)
                        Database.AddInParameter(command, "EndDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "EndDate", DbType.DateTime, endDate);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
		    		Database.AddInParameter(command,"Location",DbType.String,location);
		    		Database.AddInParameter(command,"LocationName",DbType.String,locationName);
		    		Database.AddInParameter(command,"LocationLogo",DbType.String,locationLogo);
		    		Database.AddInParameter(command,"LocationLongitude",DbType.Decimal,locationLongitude);
		    		Database.AddInParameter(command,"LocationLatitude",DbType.Decimal,locationLatitude);
		    		Database.AddInParameter(command,"ConferenceDomain",DbType.String,conferenceDomain);
                    Database.AddInParameter(command, "ConferenceCode", DbType.String, ConferenceCode);
                    Database.AddInParameter(command, "ConferenceAlias", DbType.String, ConferenceAlias);
                    Database.AddInParameter(command, "ConferenceVenueID", DbType.Int32, ConferenceVenueID);
                    Database.AddInParameter(command, "IsDefault", DbType.Boolean, IsDefault);
                    if (AbstractSubmissionStartDate == DateTime.MinValue)
                        Database.AddInParameter(command, "AbstractSubmissionStartDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "AbstractSubmissionStartDate", DbType.DateTime, AbstractSubmissionStartDate);
                    if (AbstractSubmissionEndDate == DateTime.MinValue)
                        Database.AddInParameter(command, "AbstractSubmissionEndDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "AbstractSubmissionEndDate", DbType.DateTime, AbstractSubmissionEndDate);

                    if (AbstractSubmissionEndMessagePageID == 0)
                        Database.AddInParameter(command, "AbstractSubmissionEndMessagePageID", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "AbstractSubmissionEndMessagePageID", DbType.Int32, AbstractSubmissionEndMessagePageID);

                    if (AbstractSubmissionNotStartedPageID == 0)
                        Database.AddInParameter(command, "AbstractSubmissionNotStartedPageID", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "AbstractSubmissionNotStartedPageID", DbType.Int32, AbstractSubmissionNotStartedPageID);
                
            Database.AddInParameter(command,"oldConferenceId",DbType.Int32,oldconferenceId);


				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Conferences using Stored Procedure By Transaction
		/// </summary>
        public bool UpdateConferences(int siteId, string conferenceName, string conferenceLogo, DateTime startDate, DateTime endDate, bool isActive, string location, string locationName, string locationLogo, decimal locationLongitude, decimal locationLatitude, string conferenceDomain, string ConferenceCode, string ConferenceAlias, int ConferenceVenueID, bool IsDefault, DateTime AbstractSubmissionStartDate, DateTime AbstractSubmissionEndDate, int AbstractSubmissionEndMessagePageID, int AbstractSubmissionNotStartedPageID, int oldconferenceId, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferences");

		    		Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
		    		Database.AddInParameter(command,"ConferenceName",DbType.String,conferenceName);
		    		Database.AddInParameter(command,"ConferenceLogo",DbType.String,conferenceLogo);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
                    if (endDate == DateTime.MinValue)
                        Database.AddInParameter(command, "EndDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "EndDate", DbType.DateTime, endDate);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
		    		Database.AddInParameter(command,"Location",DbType.String,location);
		    		Database.AddInParameter(command,"LocationName",DbType.String,locationName);
		    		Database.AddInParameter(command,"LocationLogo",DbType.String,locationLogo);
		    		Database.AddInParameter(command,"LocationLongitude",DbType.Decimal,locationLongitude);
		    		Database.AddInParameter(command,"LocationLatitude",DbType.Decimal,locationLatitude);
		    		Database.AddInParameter(command,"ConferenceDomain",DbType.String,conferenceDomain);
                    Database.AddInParameter(command, "ConferenceCode", DbType.String, ConferenceCode);
                    Database.AddInParameter(command, "ConferenceAlias", DbType.String, ConferenceAlias);
                    Database.AddInParameter(command, "ConferenceVenueID", DbType.Int32, ConferenceVenueID);
                    Database.AddInParameter(command, "IsDefault", DbType.Boolean, IsDefault);
                    if (AbstractSubmissionStartDate == DateTime.MinValue)
                        Database.AddInParameter(command, "AbstractSubmissionStartDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "AbstractSubmissionStartDate", DbType.DateTime, AbstractSubmissionStartDate);
                    if (AbstractSubmissionEndDate == DateTime.MinValue)
                        Database.AddInParameter(command, "AbstractSubmissionEndDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "AbstractSubmissionEndDate", DbType.DateTime, AbstractSubmissionEndDate);

                    if (AbstractSubmissionEndMessagePageID == 0)
                        Database.AddInParameter(command, "AbstractSubmissionEndMessagePageID", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "AbstractSubmissionEndMessagePageID", DbType.Int32, AbstractSubmissionEndMessagePageID);

                    if (AbstractSubmissionNotStartedPageID == 0)
                        Database.AddInParameter(command, "AbstractSubmissionNotStartedPageID", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "AbstractSubmissionNotStartedPageID", DbType.Int32, AbstractSubmissionNotStartedPageID);
                
				Database.AddInParameter(command,"oldConferenceId",DbType.Int32,oldconferenceId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Conferences using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferencesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferences");

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
				Database.AddInParameter(command,"oldConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Conferences using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferences( int conferenceId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferences");
			Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Conferences Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferencesCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferences");
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Conferences using Stored Procedure
		/// and return number of rows effected of the Conferences
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Conferences",InsertNewConferencesCommand(),UpdateConferencesCommand(),DeleteConferencesCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Conferences using Stored Procedure
		/// and return number of rows effected of the Conferences
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Conferences",InsertNewConferencesCommand(),UpdateConferencesCommand(),DeleteConferencesCommand(), transaction);
          return rowsAffected;
		}


	}
}
