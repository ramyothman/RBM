using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents
{
	/// <summary>
	/// This is a Data Access Class  for ConferenceMediaReference table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferenceMediaReference table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceMediaReferenceDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceMediaReferenceDAC() : base("", "Conference.ConferenceMediaReference") { }
		public ConferenceMediaReferenceDAC(string connectionString): base(connectionString){}
		public ConferenceMediaReferenceDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceMediaReference using Stored Procedure
		/// and return a DataTable containing all ConferenceMediaReference Data
		/// </summary>
		public DataTable GetAllConferenceMediaReference()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceMediaReference";
         string query = " select * from GetAllConferenceMediaReference";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceMediaReference"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceMediaReference using Stored Procedure
		/// and return a DataTable containing all ConferenceMediaReference Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceMediaReference(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceMediaReference";
         string query = " select * from GetAllConferenceMediaReference";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceMediaReference"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceMediaReference using Stored Procedure
		/// and return a DataTable containing all ConferenceMediaReference Data
		/// </summary>
		public DataTable GetAllConferenceMediaReference(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceMediaReference";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferenceMediaReference" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceMediaReference"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceMediaReference using Stored Procedure
		/// and return a DataTable containing all ConferenceMediaReference Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceMediaReference(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceMediaReference";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferenceMediaReference" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceMediaReference"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceMediaReference using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceMediaReference( int conferenceMediaReferenceId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceMediaReference");
				    Database.AddInParameter(command,"ConferenceMediaReferenceId",DbType.Int32,conferenceMediaReferenceId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceMediaReference using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceMediaReference( int conferenceMediaReferenceId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceMediaReference");
				    Database.AddInParameter(command,"ConferenceMediaReferenceId",DbType.Int32,conferenceMediaReferenceId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceMediaReference using Stored Procedure
		/// and return the auto number primary key of ConferenceMediaReference inserted row
		/// </summary>
		public bool InsertNewConferenceMediaReference( ref int conferenceMediaReferenceId,  int conferenceId,  int languageId,  int referenceOrder,  string title,  string referenceUrl,  string referenceName,  string referenceLogo,  DateTime publishingDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceMediaReference");
				Database.AddOutParameter(command,"ConferenceMediaReferenceId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"ReferenceOrder",DbType.Int32,referenceOrder);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"ReferenceUrl",DbType.String,referenceUrl);
				Database.AddInParameter(command,"ReferenceName",DbType.String,referenceName);
				Database.AddInParameter(command,"ReferenceLogo",DbType.String,referenceLogo);
				Database.AddInParameter(command,"PublishingDate",DbType.DateTime,publishingDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceMediaReferenceId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceMediaReferenceId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceMediaReference using Stored Procedure
		/// and return the auto number primary key of ConferenceMediaReference inserted row using Transaction
		/// </summary>
		public bool InsertNewConferenceMediaReference( ref int conferenceMediaReferenceId,  int conferenceId,  int languageId,  int referenceOrder,  string title,  string referenceUrl,  string referenceName,  string referenceLogo,  DateTime publishingDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceMediaReference");
				Database.AddOutParameter(command,"ConferenceMediaReferenceId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"ReferenceOrder",DbType.Int32,referenceOrder);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"ReferenceUrl",DbType.String,referenceUrl);
				Database.AddInParameter(command,"ReferenceName",DbType.String,referenceName);
				Database.AddInParameter(command,"ReferenceLogo",DbType.String,referenceLogo);
				Database.AddInParameter(command,"PublishingDate",DbType.DateTime,publishingDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceMediaReferenceId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceMediaReferenceId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceMediaReference using Stored Procedure
		/// and return DbCommand of the ConferenceMediaReference
		/// </summary>
		public DbCommand InsertNewConferenceMediaReferenceCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceMediaReference");

				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
				Database.AddInParameter(command,"ReferenceOrder",DbType.Int32,"ReferenceOrder",DataRowVersion.Current);
				Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
				Database.AddInParameter(command,"ReferenceUrl",DbType.String,"ReferenceUrl",DataRowVersion.Current);
				Database.AddInParameter(command,"ReferenceName",DbType.String,"ReferenceName",DataRowVersion.Current);
				Database.AddInParameter(command,"ReferenceLogo",DbType.String,"ReferenceLogo",DataRowVersion.Current);
				Database.AddInParameter(command,"PublishingDate",DbType.DateTime,"PublishingDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceMediaReference using Stored Procedure
		/// </summary>
		public bool UpdateConferenceMediaReference( int conferenceId, int languageId, int referenceOrder, string title, string referenceUrl, string referenceName, string referenceLogo, DateTime publishingDate, int oldconferenceMediaReferenceId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceMediaReference");

		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"ReferenceOrder",DbType.Int32,referenceOrder);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"ReferenceUrl",DbType.String,referenceUrl);
		    		Database.AddInParameter(command,"ReferenceName",DbType.String,referenceName);
		    		Database.AddInParameter(command,"ReferenceLogo",DbType.String,referenceLogo);
		    		Database.AddInParameter(command,"PublishingDate",DbType.DateTime,publishingDate);
				Database.AddInParameter(command,"oldConferenceMediaReferenceId",DbType.Int32,oldconferenceMediaReferenceId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceMediaReference using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateConferenceMediaReference( int conferenceId, int languageId, int referenceOrder, string title, string referenceUrl, string referenceName, string referenceLogo, DateTime publishingDate, int oldconferenceMediaReferenceId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceMediaReference");

		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"ReferenceOrder",DbType.Int32,referenceOrder);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"ReferenceUrl",DbType.String,referenceUrl);
		    		Database.AddInParameter(command,"ReferenceName",DbType.String,referenceName);
		    		Database.AddInParameter(command,"ReferenceLogo",DbType.String,referenceLogo);
		    		Database.AddInParameter(command,"PublishingDate",DbType.DateTime,publishingDate);
				Database.AddInParameter(command,"oldConferenceMediaReferenceId",DbType.Int32,oldconferenceMediaReferenceId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceMediaReference using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceMediaReferenceCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceMediaReference");

		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ReferenceOrder",DbType.Int32,"ReferenceOrder",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ReferenceUrl",DbType.String,"ReferenceUrl",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ReferenceName",DbType.String,"ReferenceName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ReferenceLogo",DbType.String,"ReferenceLogo",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PublishingDate",DbType.DateTime,"PublishingDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldConferenceMediaReferenceId",DbType.Int32,"ConferenceMediaReferenceId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceMediaReference using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferenceMediaReference( int conferenceMediaReferenceId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferenceMediaReference");
			Database.AddInParameter(command,"ConferenceMediaReferenceId",DbType.Int32,conferenceMediaReferenceId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceMediaReference Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceMediaReferenceCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceMediaReference");
				Database.AddInParameter(command,"ConferenceMediaReferenceId",DbType.Int32,"ConferenceMediaReferenceId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceMediaReference using Stored Procedure
		/// and return number of rows effected of the ConferenceMediaReference
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceMediaReference",InsertNewConferenceMediaReferenceCommand(),UpdateConferenceMediaReferenceCommand(),DeleteConferenceMediaReferenceCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceMediaReference using Stored Procedure
		/// and return number of rows effected of the ConferenceMediaReference
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceMediaReference",InsertNewConferenceMediaReferenceCommand(),UpdateConferenceMediaReferenceCommand(),DeleteConferenceMediaReferenceCommand(), transaction);
          return rowsAffected;
		}


	}
}
