using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for EmailTemplate table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the EmailTemplate table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class EmailTemplateDAC : DataAccessComponent
	{
		#region Constructors
        public EmailTemplateDAC() : base("", "Conference.EmailTemplate") { }
		public EmailTemplateDAC(string connectionString): base(connectionString){}
		public EmailTemplateDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmailTemplate using Stored Procedure
		/// and return a DataTable containing all EmailTemplate Data
		/// </summary>
		public DataTable GetAllEmailTemplate()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmailTemplate";
         string query = " select * from GetAllEmailTemplate";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmailTemplate"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmailTemplate using Stored Procedure
		/// and return a DataTable containing all EmailTemplate Data using a Transaction
		/// </summary>
		public DataTable GetAllEmailTemplate(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmailTemplate";
         string query = " select * from GetAllEmailTemplate";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmailTemplate"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmailTemplate using Stored Procedure
		/// and return a DataTable containing all EmailTemplate Data
		/// </summary>
		public DataTable GetAllEmailTemplate(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmailTemplate";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllEmailTemplate" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["EmailTemplate"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all EmailTemplate using Stored Procedure
		/// and return a DataTable containing all EmailTemplate Data using a Transaction
		/// </summary>
		public DataTable GetAllEmailTemplate(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "EmailTemplate";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllEmailTemplate" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["EmailTemplate"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmailTemplate using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmailTemplate( int emailTemplateID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmailTemplate");
				    Database.AddInParameter(command,"EmailTemplateID",DbType.Int32,emailTemplateID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmailTemplate using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmailTemplate( int emailTemplateID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmailTemplate");
				    Database.AddInParameter(command,"EmailTemplateID",DbType.Int32,emailTemplateID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmailTemplate using Stored Procedure
		/// and return the auto number primary key of EmailTemplate inserted row
		/// </summary>
		public bool InsertNewEmailTemplate( ref int emailTemplateID,  int systemEmailTypeID,  int conferenceID,  int languageID,  string name,  string description,  string emailContent)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmailTemplate");
				Database.AddOutParameter(command,"EmailTemplateID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,systemEmailTypeID);
				Database.AddInParameter(command,"ConferenceID",DbType.Int32,conferenceID);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"EmailContent",DbType.String,emailContent);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 emailTemplateID = Convert.ToInt32(Database.GetParameterValue(command, "EmailTemplateID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmailTemplate using Stored Procedure
		/// and return the auto number primary key of EmailTemplate inserted row using Transaction
		/// </summary>
		public bool InsertNewEmailTemplate( ref int emailTemplateID,  int systemEmailTypeID,  int conferenceID,  int languageID,  string name,  string description,  string emailContent,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmailTemplate");
				Database.AddOutParameter(command,"EmailTemplateID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,systemEmailTypeID);
				Database.AddInParameter(command,"ConferenceID",DbType.Int32,conferenceID);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"EmailContent",DbType.String,emailContent);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 emailTemplateID = Convert.ToInt32(Database.GetParameterValue(command, "EmailTemplateID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for EmailTemplate using Stored Procedure
		/// and return DbCommand of the EmailTemplate
		/// </summary>
		public DbCommand InsertNewEmailTemplateCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmailTemplate");

				Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,"SystemEmailTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceID",DbType.Int32,"ConferenceID",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
				Database.AddInParameter(command,"EmailContent",DbType.String,"EmailContent",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmailTemplate using Stored Procedure
		/// </summary>
		public bool UpdateEmailTemplate( int systemEmailTypeID, int conferenceID, int languageID, string name, string description, string emailContent, int oldemailTemplateID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmailTemplate");

		    		Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,systemEmailTypeID);
		    		Database.AddInParameter(command,"ConferenceID",DbType.Int32,conferenceID);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"EmailContent",DbType.String,emailContent);
				Database.AddInParameter(command,"oldEmailTemplateID",DbType.Int32,oldemailTemplateID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmailTemplate using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateEmailTemplate( int systemEmailTypeID, int conferenceID, int languageID, string name, string description, string emailContent, int oldemailTemplateID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmailTemplate");

		    		Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,systemEmailTypeID);
		    		Database.AddInParameter(command,"ConferenceID",DbType.Int32,conferenceID);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"EmailContent",DbType.String,emailContent);
				Database.AddInParameter(command,"oldEmailTemplateID",DbType.Int32,oldemailTemplateID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from EmailTemplate using Stored Procedure
		/// </summary>
		public DbCommand UpdateEmailTemplateCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmailTemplate");

		    		Database.AddInParameter(command,"SystemEmailTypeID",DbType.Int32,"SystemEmailTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceID",DbType.Int32,"ConferenceID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EmailContent",DbType.String,"EmailContent",DataRowVersion.Current);
				Database.AddInParameter(command,"oldEmailTemplateID",DbType.Int32,"EmailTemplateID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From EmailTemplate using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteEmailTemplate( int emailTemplateID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteEmailTemplate");
			Database.AddInParameter(command,"EmailTemplateID",DbType.Int32,emailTemplateID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From EmailTemplate Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteEmailTemplateCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteEmailTemplate");
				Database.AddInParameter(command,"EmailTemplateID",DbType.Int32,"EmailTemplateID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmailTemplate using Stored Procedure
		/// and return number of rows effected of the EmailTemplate
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmailTemplate",InsertNewEmailTemplateCommand(),UpdateEmailTemplateCommand(),DeleteEmailTemplateCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table EmailTemplate using Stored Procedure
		/// and return number of rows effected of the EmailTemplate
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"EmailTemplate",InsertNewEmailTemplateCommand(),UpdateEmailTemplateCommand(),DeleteEmailTemplateCommand(), transaction);
          return rowsAffected;
		}


	}
}
