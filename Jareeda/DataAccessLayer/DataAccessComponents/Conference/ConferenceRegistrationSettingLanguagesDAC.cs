using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferenceRegistrationSettingLanguages table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferenceRegistrationSettingLanguages table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceRegistrationSettingLanguagesDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceRegistrationSettingLanguagesDAC() : base("", "Conference.ConferenceRegistrationSettingLanguages") { }
		public ConferenceRegistrationSettingLanguagesDAC(string connectionString): base(connectionString){}
		public ConferenceRegistrationSettingLanguagesDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationSettingLanguages using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationSettingLanguages Data
		/// </summary>
		public DataTable GetAllConferenceRegistrationSettingLanguages()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationSettingLanguages";
         string query = " select * from GetAllConferenceRegistrationSettingLanguages";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceRegistrationSettingLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationSettingLanguages using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationSettingLanguages Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceRegistrationSettingLanguages(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationSettingLanguages";
         string query = " select * from GetAllConferenceRegistrationSettingLanguages";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceRegistrationSettingLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationSettingLanguages using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationSettingLanguages Data
		/// </summary>
		public DataTable GetAllConferenceRegistrationSettingLanguages(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationSettingLanguages";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferenceRegistrationSettingLanguages" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceRegistrationSettingLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationSettingLanguages using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationSettingLanguages Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceRegistrationSettingLanguages(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationSettingLanguages";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferenceRegistrationSettingLanguages" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceRegistrationSettingLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceRegistrationSettingLanguages using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceRegistrationSettingLanguages( int conferenceRegistrationSettingLanguageID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceRegistrationSettingLanguages");
				    Database.AddInParameter(command,"ConferenceRegistrationSettingLanguageID",DbType.Int32,conferenceRegistrationSettingLanguageID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceRegistrationSettingLanguages using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceRegistrationSettingLanguages( int conferenceRegistrationSettingLanguageID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceRegistrationSettingLanguages");
				    Database.AddInParameter(command,"ConferenceRegistrationSettingLanguageID",DbType.Int32,conferenceRegistrationSettingLanguageID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceRegistrationSettingLanguages using Stored Procedure
		/// and return the auto number primary key of ConferenceRegistrationSettingLanguages inserted row
		/// </summary>
		public bool InsertNewConferenceRegistrationSettingLanguages( ref int conferenceRegistrationSettingLanguageID,  int conferenceRegistrationSettingID,  string registrationShorInstructions,  string registrationInstructionsInFormPre,  string registrationInstructionsInFormPost,  string postRegistrationInstructions,  int languageID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceRegistrationSettingLanguages");
				Database.AddOutParameter(command,"ConferenceRegistrationSettingLanguageID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceRegistrationSettingID",DbType.Int32,conferenceRegistrationSettingID);
				Database.AddInParameter(command,"RegistrationShorInstructions",DbType.String,registrationShorInstructions);
				Database.AddInParameter(command,"RegistrationInstructionsInFormPre",DbType.String,registrationInstructionsInFormPre);
				Database.AddInParameter(command,"RegistrationInstructionsInFormPost",DbType.String,registrationInstructionsInFormPost);
				Database.AddInParameter(command,"PostRegistrationInstructions",DbType.String,postRegistrationInstructions);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceRegistrationSettingLanguageID = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceRegistrationSettingLanguageID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceRegistrationSettingLanguages using Stored Procedure
		/// and return the auto number primary key of ConferenceRegistrationSettingLanguages inserted row using Transaction
		/// </summary>
		public bool InsertNewConferenceRegistrationSettingLanguages( ref int conferenceRegistrationSettingLanguageID,  int conferenceRegistrationSettingID,  string registrationShorInstructions,  string registrationInstructionsInFormPre,  string registrationInstructionsInFormPost,  string postRegistrationInstructions,  int languageID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceRegistrationSettingLanguages");
				Database.AddOutParameter(command,"ConferenceRegistrationSettingLanguageID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceRegistrationSettingID",DbType.Int32,conferenceRegistrationSettingID);
				Database.AddInParameter(command,"RegistrationShorInstructions",DbType.String,registrationShorInstructions);
				Database.AddInParameter(command,"RegistrationInstructionsInFormPre",DbType.String,registrationInstructionsInFormPre);
				Database.AddInParameter(command,"RegistrationInstructionsInFormPost",DbType.String,registrationInstructionsInFormPost);
				Database.AddInParameter(command,"PostRegistrationInstructions",DbType.String,postRegistrationInstructions);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceRegistrationSettingLanguageID = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceRegistrationSettingLanguageID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceRegistrationSettingLanguages using Stored Procedure
		/// and return DbCommand of the ConferenceRegistrationSettingLanguages
		/// </summary>
		public DbCommand InsertNewConferenceRegistrationSettingLanguagesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceRegistrationSettingLanguages");

				Database.AddInParameter(command,"ConferenceRegistrationSettingID",DbType.Int32,"ConferenceRegistrationSettingID",DataRowVersion.Current);
				Database.AddInParameter(command,"RegistrationShorInstructions",DbType.String,"RegistrationShorInstructions",DataRowVersion.Current);
				Database.AddInParameter(command,"RegistrationInstructionsInFormPre",DbType.String,"RegistrationInstructionsInFormPre",DataRowVersion.Current);
				Database.AddInParameter(command,"RegistrationInstructionsInFormPost",DbType.String,"RegistrationInstructionsInFormPost",DataRowVersion.Current);
				Database.AddInParameter(command,"PostRegistrationInstructions",DbType.String,"PostRegistrationInstructions",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceRegistrationSettingLanguages using Stored Procedure
		/// </summary>
		public bool UpdateConferenceRegistrationSettingLanguages( int conferenceRegistrationSettingID, string registrationShorInstructions, string registrationInstructionsInFormPre, string registrationInstructionsInFormPost, string postRegistrationInstructions, int languageID, int oldconferenceRegistrationSettingLanguageID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceRegistrationSettingLanguages");

		    		Database.AddInParameter(command,"ConferenceRegistrationSettingID",DbType.Int32,conferenceRegistrationSettingID);
		    		Database.AddInParameter(command,"RegistrationShorInstructions",DbType.String,registrationShorInstructions);
		    		Database.AddInParameter(command,"RegistrationInstructionsInFormPre",DbType.String,registrationInstructionsInFormPre);
		    		Database.AddInParameter(command,"RegistrationInstructionsInFormPost",DbType.String,registrationInstructionsInFormPost);
		    		Database.AddInParameter(command,"PostRegistrationInstructions",DbType.String,postRegistrationInstructions);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"oldConferenceRegistrationSettingLanguageID",DbType.Int32,oldconferenceRegistrationSettingLanguageID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceRegistrationSettingLanguages using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateConferenceRegistrationSettingLanguages( int conferenceRegistrationSettingID, string registrationShorInstructions, string registrationInstructionsInFormPre, string registrationInstructionsInFormPost, string postRegistrationInstructions, int languageID, int oldconferenceRegistrationSettingLanguageID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceRegistrationSettingLanguages");

		    		Database.AddInParameter(command,"ConferenceRegistrationSettingID",DbType.Int32,conferenceRegistrationSettingID);
		    		Database.AddInParameter(command,"RegistrationShorInstructions",DbType.String,registrationShorInstructions);
		    		Database.AddInParameter(command,"RegistrationInstructionsInFormPre",DbType.String,registrationInstructionsInFormPre);
		    		Database.AddInParameter(command,"RegistrationInstructionsInFormPost",DbType.String,registrationInstructionsInFormPost);
		    		Database.AddInParameter(command,"PostRegistrationInstructions",DbType.String,postRegistrationInstructions);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"oldConferenceRegistrationSettingLanguageID",DbType.Int32,oldconferenceRegistrationSettingLanguageID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceRegistrationSettingLanguages using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceRegistrationSettingLanguagesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceRegistrationSettingLanguages");

		    		Database.AddInParameter(command,"ConferenceRegistrationSettingID",DbType.Int32,"ConferenceRegistrationSettingID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RegistrationShorInstructions",DbType.String,"RegistrationShorInstructions",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RegistrationInstructionsInFormPre",DbType.String,"RegistrationInstructionsInFormPre",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RegistrationInstructionsInFormPost",DbType.String,"RegistrationInstructionsInFormPost",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PostRegistrationInstructions",DbType.String,"PostRegistrationInstructions",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldConferenceRegistrationSettingLanguageID",DbType.Int32,"ConferenceRegistrationSettingLanguageID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceRegistrationSettingLanguages using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferenceRegistrationSettingLanguages( int conferenceRegistrationSettingLanguageID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferenceRegistrationSettingLanguages");
			Database.AddInParameter(command,"ConferenceRegistrationSettingLanguageID",DbType.Int32,conferenceRegistrationSettingLanguageID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceRegistrationSettingLanguages Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceRegistrationSettingLanguagesCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceRegistrationSettingLanguages");
				Database.AddInParameter(command,"ConferenceRegistrationSettingLanguageID",DbType.Int32,"ConferenceRegistrationSettingLanguageID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceRegistrationSettingLanguages using Stored Procedure
		/// and return number of rows effected of the ConferenceRegistrationSettingLanguages
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceRegistrationSettingLanguages",InsertNewConferenceRegistrationSettingLanguagesCommand(),UpdateConferenceRegistrationSettingLanguagesCommand(),DeleteConferenceRegistrationSettingLanguagesCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceRegistrationSettingLanguages using Stored Procedure
		/// and return number of rows effected of the ConferenceRegistrationSettingLanguages
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceRegistrationSettingLanguages",InsertNewConferenceRegistrationSettingLanguagesCommand(),UpdateConferenceRegistrationSettingLanguagesCommand(),DeleteConferenceRegistrationSettingLanguagesCommand(), transaction);
          return rowsAffected;
		}


	}
}
