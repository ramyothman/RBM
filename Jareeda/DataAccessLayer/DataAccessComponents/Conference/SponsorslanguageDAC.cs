using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for Sponsorslanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Sponsorslanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SponsorslanguageDAC : DataAccessComponent
	{
		#region Constructors
        public SponsorslanguageDAC() : base("", "Conference.Sponsorslanguage") { }
		public SponsorslanguageDAC(string connectionString): base(connectionString){}
		public SponsorslanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Sponsorslanguage using Stored Procedure
		/// and return a DataTable containing all Sponsorslanguage Data
		/// </summary>
		public DataTable GetAllSponsorslanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Sponsorslanguage";
         string query = " select * from GetAllSponsorslanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Sponsorslanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Sponsorslanguage using Stored Procedure
		/// and return a DataTable containing all Sponsorslanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllSponsorslanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Sponsorslanguage";
         string query = " select * from GetAllSponsorslanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Sponsorslanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Sponsorslanguage using Stored Procedure
		/// and return a DataTable containing all Sponsorslanguage Data
		/// </summary>
		public DataTable GetAllSponsorslanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Sponsorslanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSponsorslanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Sponsorslanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Sponsorslanguage using Stored Procedure
		/// and return a DataTable containing all Sponsorslanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllSponsorslanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Sponsorslanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSponsorslanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Sponsorslanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Sponsorslanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSponsorslanguage( int sponsorId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSponsorslanguage");
				    Database.AddInParameter(command,"SponsorId",DbType.Int32,sponsorId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Sponsorslanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSponsorslanguage( int sponsorId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSponsorslanguage");
				    Database.AddInParameter(command,"SponsorId",DbType.Int32,sponsorId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Sponsorslanguage using Stored Procedure
		/// and return the auto number primary key of Sponsorslanguage inserted row
		/// </summary>
		public bool InsertNewSponsorslanguage( ref int sponsorId,  string sponsorName,  int conferenceId,  string sponsorType,  string sponsorImage,  int languageID,  int sponsorParentID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSponsorslanguage");
				Database.AddOutParameter(command,"SponsorId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SponsorName",DbType.String,sponsorName);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"SponsorType",DbType.String,sponsorType);
				Database.AddInParameter(command,"SponsorImage",DbType.String,sponsorImage);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"SponsorParentID",DbType.Int32,sponsorParentID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 sponsorId = Convert.ToInt32(Database.GetParameterValue(command, "SponsorId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Sponsorslanguage using Stored Procedure
		/// and return the auto number primary key of Sponsorslanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewSponsorslanguage( ref int sponsorId,  string sponsorName,  int conferenceId,  string sponsorType,  string sponsorImage,  int languageID,  int sponsorParentID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSponsorslanguage");
				Database.AddOutParameter(command,"SponsorId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SponsorName",DbType.String,sponsorName);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"SponsorType",DbType.String,sponsorType);
				Database.AddInParameter(command,"SponsorImage",DbType.String,sponsorImage);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"SponsorParentID",DbType.Int32,sponsorParentID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 sponsorId = Convert.ToInt32(Database.GetParameterValue(command, "SponsorId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Sponsorslanguage using Stored Procedure
		/// and return DbCommand of the Sponsorslanguage
		/// </summary>
		public DbCommand InsertNewSponsorslanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSponsorslanguage");

				Database.AddInParameter(command,"SponsorName",DbType.String,"SponsorName",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"SponsorType",DbType.String,"SponsorType",DataRowVersion.Current);
				Database.AddInParameter(command,"SponsorImage",DbType.String,"SponsorImage",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"SponsorParentID",DbType.Int32,"SponsorParentID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Sponsorslanguage using Stored Procedure
		/// </summary>
		public bool UpdateSponsorslanguage( string sponsorName, int conferenceId, string sponsorType, string sponsorImage, int languageID, int sponsorParentID, int oldsponsorId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSponsorslanguage");

		    		Database.AddInParameter(command,"SponsorName",DbType.String,sponsorName);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"SponsorType",DbType.String,sponsorType);
		    		Database.AddInParameter(command,"SponsorImage",DbType.String,sponsorImage);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"SponsorParentID",DbType.Int32,sponsorParentID);
				Database.AddInParameter(command,"oldSponsorId",DbType.Int32,oldsponsorId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Sponsorslanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSponsorslanguage( string sponsorName, int conferenceId, string sponsorType, string sponsorImage, int languageID, int sponsorParentID, int oldsponsorId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSponsorslanguage");

		    		Database.AddInParameter(command,"SponsorName",DbType.String,sponsorName);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"SponsorType",DbType.String,sponsorType);
		    		Database.AddInParameter(command,"SponsorImage",DbType.String,sponsorImage);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"SponsorParentID",DbType.Int32,sponsorParentID);
				Database.AddInParameter(command,"oldSponsorId",DbType.Int32,oldsponsorId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Sponsorslanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateSponsorslanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSponsorslanguage");

		    		Database.AddInParameter(command,"SponsorName",DbType.String,"SponsorName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SponsorType",DbType.String,"SponsorType",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SponsorImage",DbType.String,"SponsorImage",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SponsorParentID",DbType.Int32,"SponsorParentID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSponsorId",DbType.Int32,"SponsorId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Sponsorslanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSponsorslanguage( int sponsorId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSponsorslanguage");
			Database.AddInParameter(command,"SponsorId",DbType.Int32,sponsorId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Sponsorslanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSponsorslanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSponsorslanguage");
				Database.AddInParameter(command,"SponsorId",DbType.Int32,"SponsorId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Sponsorslanguage using Stored Procedure
		/// and return number of rows effected of the Sponsorslanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Sponsorslanguage",InsertNewSponsorslanguageCommand(),UpdateSponsorslanguageCommand(),DeleteSponsorslanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Sponsorslanguage using Stored Procedure
		/// and return number of rows effected of the Sponsorslanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Sponsorslanguage",InsertNewSponsorslanguageCommand(),UpdateSponsorslanguageCommand(),DeleteSponsorslanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
