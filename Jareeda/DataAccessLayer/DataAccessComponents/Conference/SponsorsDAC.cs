using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for Sponsors table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Sponsors table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SponsorsDAC : DataAccessComponent
	{
		#region Constructors
        public SponsorsDAC() : base("", "Conference.Sponsors") { }
		public SponsorsDAC(string connectionString): base(connectionString){}
		public SponsorsDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Sponsors using Stored Procedure
		/// and return a DataTable containing all Sponsors Data
		/// </summary>
		public DataTable GetAllSponsors()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Sponsors";
         string query = " select * from GetAllSponsors";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Sponsors"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Sponsors using Stored Procedure
		/// and return a DataTable containing all Sponsors Data using a Transaction
		/// </summary>
		public DataTable GetAllSponsors(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Sponsors";
         string query = " select * from GetAllSponsors";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Sponsors"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Sponsors using Stored Procedure
		/// and return a DataTable containing all Sponsors Data
		/// </summary>
		public DataTable GetAllSponsors(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Sponsors";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSponsors" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Sponsors"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Sponsors using Stored Procedure
		/// and return a DataTable containing all Sponsors Data using a Transaction
		/// </summary>
		public DataTable GetAllSponsors(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Sponsors";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSponsors" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Sponsors"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Sponsors using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSponsors( int sponsorId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSponsors");
				    Database.AddInParameter(command,"SponsorId",DbType.Int32,sponsorId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Sponsors using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSponsors( int sponsorId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSponsors");
				    Database.AddInParameter(command,"SponsorId",DbType.Int32,sponsorId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Sponsors using Stored Procedure
		/// and return the auto number primary key of Sponsors inserted row
		/// </summary>
		public bool InsertNewSponsors( ref int sponsorId,  string sponsorName,  int conferenceId,  string sponsorType,  string sponsorImage)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSponsors");
				Database.AddOutParameter(command,"SponsorId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SponsorName",DbType.String,sponsorName);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"SponsorType",DbType.String,sponsorType);
				Database.AddInParameter(command,"SponsorImage",DbType.String,sponsorImage);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 sponsorId = Convert.ToInt32(Database.GetParameterValue(command, "SponsorId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Sponsors using Stored Procedure
		/// and return the auto number primary key of Sponsors inserted row using Transaction
		/// </summary>
		public bool InsertNewSponsors( ref int sponsorId,  string sponsorName,  int conferenceId,  string sponsorType,  string sponsorImage,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSponsors");
				Database.AddOutParameter(command,"SponsorId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SponsorName",DbType.String,sponsorName);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"SponsorType",DbType.String,sponsorType);
				Database.AddInParameter(command,"SponsorImage",DbType.String,sponsorImage);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 sponsorId = Convert.ToInt32(Database.GetParameterValue(command, "SponsorId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Sponsors using Stored Procedure
		/// and return DbCommand of the Sponsors
		/// </summary>
		public DbCommand InsertNewSponsorsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSponsors");

				Database.AddInParameter(command,"SponsorName",DbType.String,"SponsorName",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"SponsorType",DbType.String,"SponsorType",DataRowVersion.Current);
				Database.AddInParameter(command,"SponsorImage",DbType.String,"SponsorImage",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Sponsors using Stored Procedure
		/// </summary>
		public bool UpdateSponsors( string sponsorName, int conferenceId, string sponsorType, string sponsorImage, int oldsponsorId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSponsors");

		    		Database.AddInParameter(command,"SponsorName",DbType.String,sponsorName);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"SponsorType",DbType.String,sponsorType);
		    		Database.AddInParameter(command,"SponsorImage",DbType.String,sponsorImage);
				Database.AddInParameter(command,"oldSponsorId",DbType.Int32,oldsponsorId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Sponsors using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSponsors( string sponsorName, int conferenceId, string sponsorType, string sponsorImage, int oldsponsorId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSponsors");

		    		Database.AddInParameter(command,"SponsorName",DbType.String,sponsorName);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"SponsorType",DbType.String,sponsorType);
		    		Database.AddInParameter(command,"SponsorImage",DbType.String,sponsorImage);
				Database.AddInParameter(command,"oldSponsorId",DbType.Int32,oldsponsorId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Sponsors using Stored Procedure
		/// </summary>
		public DbCommand UpdateSponsorsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSponsors");

		    		Database.AddInParameter(command,"SponsorName",DbType.String,"SponsorName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SponsorType",DbType.String,"SponsorType",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SponsorImage",DbType.String,"SponsorImage",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSponsorId",DbType.Int32,"SponsorId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Sponsors using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSponsors( int sponsorId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSponsors");
			Database.AddInParameter(command,"SponsorId",DbType.Int32,sponsorId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Sponsors Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSponsorsCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSponsors");
				Database.AddInParameter(command,"SponsorId",DbType.Int32,"SponsorId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Sponsors using Stored Procedure
		/// and return number of rows effected of the Sponsors
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Sponsors",InsertNewSponsorsCommand(),UpdateSponsorsCommand(),DeleteSponsorsCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Sponsors using Stored Procedure
		/// and return number of rows effected of the Sponsors
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Sponsors",InsertNewSponsorsCommand(),UpdateSponsorsCommand(),DeleteSponsorsCommand(), transaction);
          return rowsAffected;
		}


	}
}
