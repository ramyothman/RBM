using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferenceMainImages table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferenceMainImages table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceMainImagesDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceMainImagesDAC() : base("", "Conference.ConferenceMainImages") { }
		public ConferenceMainImagesDAC(string connectionString): base(connectionString){}
		public ConferenceMainImagesDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceMainImages using Stored Procedure
		/// and return a DataTable containing all ConferenceMainImages Data
		/// </summary>
		public DataTable GetAllConferenceMainImages()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceMainImages";
         string query = " select * from GetAllConferenceMainImages";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceMainImages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceMainImages using Stored Procedure
		/// and return a DataTable containing all ConferenceMainImages Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceMainImages(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceMainImages";
         string query = " select * from GetAllConferenceMainImages";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceMainImages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceMainImages using Stored Procedure
		/// and return a DataTable containing all ConferenceMainImages Data
		/// </summary>
		public DataTable GetAllConferenceMainImages(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceMainImages";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferenceMainImages" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceMainImages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceMainImages using Stored Procedure
		/// and return a DataTable containing all ConferenceMainImages Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceMainImages(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceMainImages";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferenceMainImages" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceMainImages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceMainImages using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceMainImages( int conferenceMainImageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceMainImages");
				    Database.AddInParameter(command,"ConferenceMainImageId",DbType.Int32,conferenceMainImageId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceMainImages using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceMainImages( int conferenceMainImageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceMainImages");
				    Database.AddInParameter(command,"ConferenceMainImageId",DbType.Int32,conferenceMainImageId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceMainImages using Stored Procedure
		/// and return the auto number primary key of ConferenceMainImages inserted row
		/// </summary>
		public bool InsertNewConferenceMainImages( ref int conferenceMainImageId,  string photoPath,  int conferenceId,  int languageId,  string photoLink,  string photoTitle,  string photoDescription)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceMainImages");
				Database.AddOutParameter(command,"ConferenceMainImageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PhotoPath",DbType.String,photoPath);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"PhotoLink",DbType.String,photoLink);
				Database.AddInParameter(command,"PhotoTitle",DbType.String,photoTitle);
				Database.AddInParameter(command,"PhotoDescription",DbType.String,photoDescription);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceMainImageId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceMainImageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceMainImages using Stored Procedure
		/// and return the auto number primary key of ConferenceMainImages inserted row using Transaction
		/// </summary>
		public bool InsertNewConferenceMainImages( ref int conferenceMainImageId,  string photoPath,  int conferenceId,  int languageId,  string photoLink,  string photoTitle,  string photoDescription,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceMainImages");
				Database.AddOutParameter(command,"ConferenceMainImageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PhotoPath",DbType.String,photoPath);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"PhotoLink",DbType.String,photoLink);
				Database.AddInParameter(command,"PhotoTitle",DbType.String,photoTitle);
				Database.AddInParameter(command,"PhotoDescription",DbType.String,photoDescription);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceMainImageId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceMainImageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceMainImages using Stored Procedure
		/// and return DbCommand of the ConferenceMainImages
		/// </summary>
		public DbCommand InsertNewConferenceMainImagesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceMainImages");

				Database.AddInParameter(command,"PhotoPath",DbType.String,"PhotoPath",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
				Database.AddInParameter(command,"PhotoLink",DbType.String,"PhotoLink",DataRowVersion.Current);
				Database.AddInParameter(command,"PhotoTitle",DbType.String,"PhotoTitle",DataRowVersion.Current);
				Database.AddInParameter(command,"PhotoDescription",DbType.String,"PhotoDescription",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceMainImages using Stored Procedure
		/// </summary>
		public bool UpdateConferenceMainImages( string photoPath, int conferenceId, int languageId, string photoLink, string photoTitle, string photoDescription, int oldconferenceMainImageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceMainImages");

		    		Database.AddInParameter(command,"PhotoPath",DbType.String,photoPath);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"PhotoLink",DbType.String,photoLink);
		    		Database.AddInParameter(command,"PhotoTitle",DbType.String,photoTitle);
		    		Database.AddInParameter(command,"PhotoDescription",DbType.String,photoDescription);
				Database.AddInParameter(command,"oldConferenceMainImageId",DbType.Int32,oldconferenceMainImageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceMainImages using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateConferenceMainImages( string photoPath, int conferenceId, int languageId, string photoLink, string photoTitle, string photoDescription, int oldconferenceMainImageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceMainImages");

		    		Database.AddInParameter(command,"PhotoPath",DbType.String,photoPath);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"PhotoLink",DbType.String,photoLink);
		    		Database.AddInParameter(command,"PhotoTitle",DbType.String,photoTitle);
		    		Database.AddInParameter(command,"PhotoDescription",DbType.String,photoDescription);
				Database.AddInParameter(command,"oldConferenceMainImageId",DbType.Int32,oldconferenceMainImageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceMainImages using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceMainImagesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceMainImages");

		    		Database.AddInParameter(command,"PhotoPath",DbType.String,"PhotoPath",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PhotoLink",DbType.String,"PhotoLink",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PhotoTitle",DbType.String,"PhotoTitle",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PhotoDescription",DbType.String,"PhotoDescription",DataRowVersion.Current);
				Database.AddInParameter(command,"oldConferenceMainImageId",DbType.Int32,"ConferenceMainImageId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceMainImages using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferenceMainImages( int conferenceMainImageId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferenceMainImages");
			Database.AddInParameter(command,"ConferenceMainImageId",DbType.Int32,conferenceMainImageId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceMainImages Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceMainImagesCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceMainImages");
				Database.AddInParameter(command,"ConferenceMainImageId",DbType.Int32,"ConferenceMainImageId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceMainImages using Stored Procedure
		/// and return number of rows effected of the ConferenceMainImages
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceMainImages",InsertNewConferenceMainImagesCommand(),UpdateConferenceMainImagesCommand(),DeleteConferenceMainImagesCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceMainImages using Stored Procedure
		/// and return number of rows effected of the ConferenceMainImages
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceMainImages",InsertNewConferenceMainImagesCommand(),UpdateConferenceMainImagesCommand(),DeleteConferenceMainImagesCommand(), transaction);
          return rowsAffected;
		}


	}
}
