using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferenceRegistrationTypeLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferenceRegistrationTypeLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceRegistrationTypeLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceRegistrationTypeLanguageDAC() : base("", "Conference.ConferenceRegistrationTypeLanguage") { }
		public ConferenceRegistrationTypeLanguageDAC(string connectionString): base(connectionString){}
		public ConferenceRegistrationTypeLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationTypeLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationTypeLanguage Data
		/// </summary>
		public DataTable GetAllConferenceRegistrationTypeLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationTypeLanguage";
         string query = " select * from GetAllConferenceRegistrationTypeLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceRegistrationTypeLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationTypeLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationTypeLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceRegistrationTypeLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationTypeLanguage";
         string query = " select * from GetAllConferenceRegistrationTypeLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceRegistrationTypeLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationTypeLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationTypeLanguage Data
		/// </summary>
		public DataTable GetAllConferenceRegistrationTypeLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationTypeLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferenceRegistrationTypeLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceRegistrationTypeLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationTypeLanguage using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationTypeLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceRegistrationTypeLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationTypeLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferenceRegistrationTypeLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceRegistrationTypeLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceRegistrationTypeLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceRegistrationTypeLanguage( int conferenceRegistrationTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceRegistrationTypeLanguage");
				    Database.AddInParameter(command,"ConferenceRegistrationTypeId",DbType.Int32,conferenceRegistrationTypeId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceRegistrationTypeLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceRegistrationTypeLanguage( int conferenceRegistrationTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceRegistrationTypeLanguage");
				    Database.AddInParameter(command,"ConferenceRegistrationTypeId",DbType.Int32,conferenceRegistrationTypeId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceRegistrationTypeLanguage using Stored Procedure
		/// and return the auto number primary key of ConferenceRegistrationTypeLanguage inserted row
		/// </summary>
        public bool InsertNewConferenceRegistrationTypeLanguage(ref int conferenceRegistrationTypeId, int conferenceId, string name, decimal fee, int conferenceRegistrationTypeParentId, int languageID, string Description, string OfferMessage)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceRegistrationTypeLanguage");
				Database.AddOutParameter(command,"ConferenceRegistrationTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Fee",DbType.Decimal,fee);
				Database.AddInParameter(command,"ConferenceRegistrationTypeParentId",DbType.Int32,conferenceRegistrationTypeParentId);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
                Database.AddInParameter(command, "Description", DbType.String, Description);
                Database.AddInParameter(command, "OfferMessage", DbType.String, OfferMessage);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceRegistrationTypeId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceRegistrationTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceRegistrationTypeLanguage using Stored Procedure
		/// and return the auto number primary key of ConferenceRegistrationTypeLanguage inserted row using Transaction
		/// </summary>
        public bool InsertNewConferenceRegistrationTypeLanguage(ref int conferenceRegistrationTypeId, int conferenceId, string name, decimal fee, int conferenceRegistrationTypeParentId, int languageID, string Description, string OfferMessage, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceRegistrationTypeLanguage");
				Database.AddOutParameter(command,"ConferenceRegistrationTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Fee",DbType.Decimal,fee);
				Database.AddInParameter(command,"ConferenceRegistrationTypeParentId",DbType.Int32,conferenceRegistrationTypeParentId);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
                Database.AddInParameter(command, "Description", DbType.String, Description);
                Database.AddInParameter(command, "OfferMessage", DbType.String, OfferMessage);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceRegistrationTypeId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceRegistrationTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceRegistrationTypeLanguage using Stored Procedure
		/// and return DbCommand of the ConferenceRegistrationTypeLanguage
		/// </summary>
		public DbCommand InsertNewConferenceRegistrationTypeLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceRegistrationTypeLanguage");

				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"Fee",DbType.Decimal,"Fee",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceRegistrationTypeParentId",DbType.Int32,"ConferenceRegistrationTypeParentId",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceRegistrationTypeLanguage using Stored Procedure
		/// </summary>
        public bool UpdateConferenceRegistrationTypeLanguage(int conferenceId, string name, decimal fee, int conferenceRegistrationTypeParentId, int languageID, string Description, string OfferMessage, int oldconferenceRegistrationTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceRegistrationTypeLanguage");

		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Fee",DbType.Decimal,fee);
		    		Database.AddInParameter(command,"ConferenceRegistrationTypeParentId",DbType.Int32,conferenceRegistrationTypeParentId);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
                    Database.AddInParameter(command, "Description", DbType.String, Description);
                    Database.AddInParameter(command, "OfferMessage", DbType.String, OfferMessage);
				Database.AddInParameter(command,"oldConferenceRegistrationTypeId",DbType.Int32,oldconferenceRegistrationTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceRegistrationTypeLanguage using Stored Procedure By Transaction
		/// </summary>
        public bool UpdateConferenceRegistrationTypeLanguage(int conferenceId, string name, decimal fee, int conferenceRegistrationTypeParentId, int languageID, string Description, string OfferMessage, int oldconferenceRegistrationTypeId, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceRegistrationTypeLanguage");

		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Fee",DbType.Decimal,fee);
		    		Database.AddInParameter(command,"ConferenceRegistrationTypeParentId",DbType.Int32,conferenceRegistrationTypeParentId);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
                    Database.AddInParameter(command, "Description", DbType.String, Description);
                    Database.AddInParameter(command, "OfferMessage", DbType.String, OfferMessage);
				Database.AddInParameter(command,"oldConferenceRegistrationTypeId",DbType.Int32,oldconferenceRegistrationTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceRegistrationTypeLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceRegistrationTypeLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceRegistrationTypeLanguage");

		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Fee",DbType.Decimal,"Fee",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceRegistrationTypeParentId",DbType.Int32,"ConferenceRegistrationTypeParentId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldConferenceRegistrationTypeId",DbType.Int32,"ConferenceRegistrationTypeId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceRegistrationTypeLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferenceRegistrationTypeLanguage( int conferenceRegistrationTypeId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferenceRegistrationTypeLanguage");
			Database.AddInParameter(command,"ConferenceRegistrationTypeId",DbType.Int32,conferenceRegistrationTypeId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceRegistrationTypeLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceRegistrationTypeLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceRegistrationTypeLanguage");
				Database.AddInParameter(command,"ConferenceRegistrationTypeId",DbType.Int32,"ConferenceRegistrationTypeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceRegistrationTypeLanguage using Stored Procedure
		/// and return number of rows effected of the ConferenceRegistrationTypeLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceRegistrationTypeLanguage",InsertNewConferenceRegistrationTypeLanguageCommand(),UpdateConferenceRegistrationTypeLanguageCommand(),DeleteConferenceRegistrationTypeLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceRegistrationTypeLanguage using Stored Procedure
		/// and return number of rows effected of the ConferenceRegistrationTypeLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceRegistrationTypeLanguage",InsertNewConferenceRegistrationTypeLanguageCommand(),UpdateConferenceRegistrationTypeLanguageCommand(),DeleteConferenceRegistrationTypeLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
