using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
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
        public EmailTemplateDAC() : base("", "ContentManagement.EmailTemplate") { }
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
		public System.Data.IDataReader GetByIDEmailTemplate( int emailTemplateId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmailTemplate");
				    Database.AddInParameter(command,"EmailTemplateId",DbType.Int32,emailTemplateId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From EmailTemplate using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDEmailTemplate( int emailTemplateId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDEmailTemplate");
				    Database.AddInParameter(command,"EmailTemplateId",DbType.Int32,emailTemplateId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmailTemplate using Stored Procedure
		/// and return the auto number primary key of EmailTemplate inserted row
		/// </summary>
		public bool InsertNewEmailTemplate( ref int emailTemplateId,  int siteId,  string title,  string templateContent)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmailTemplate");
				Database.AddOutParameter(command,"EmailTemplateId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"TemplateContent",DbType.String,templateContent);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 emailTemplateId = Convert.ToInt32(Database.GetParameterValue(command, "EmailTemplateId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into EmailTemplate using Stored Procedure
		/// and return the auto number primary key of EmailTemplate inserted row using Transaction
		/// </summary>
		public bool InsertNewEmailTemplate( ref int emailTemplateId,  int siteId,  string title,  string templateContent,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewEmailTemplate");
				Database.AddOutParameter(command,"EmailTemplateId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"TemplateContent",DbType.String,templateContent);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 emailTemplateId = Convert.ToInt32(Database.GetParameterValue(command, "EmailTemplateId"));
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

				Database.AddInParameter(command,"SiteId",DbType.Int32,"SiteId",DataRowVersion.Current);
				Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
				Database.AddInParameter(command,"TemplateContent",DbType.String,"TemplateContent",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into EmailTemplate using Stored Procedure
		/// </summary>
		public bool UpdateEmailTemplate( int siteId, string title, string templateContent, int oldemailTemplateId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmailTemplate");

		    		Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"TemplateContent",DbType.String,templateContent);
				Database.AddInParameter(command,"oldEmailTemplateId",DbType.Int32,oldemailTemplateId);

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
		public bool UpdateEmailTemplate( int siteId, string title, string templateContent, int oldemailTemplateId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateEmailTemplate");

		    		Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"TemplateContent",DbType.String,templateContent);
				Database.AddInParameter(command,"oldEmailTemplateId",DbType.Int32,oldemailTemplateId);

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

		    		Database.AddInParameter(command,"SiteId",DbType.Int32,"SiteId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
		    		Database.AddInParameter(command,"TemplateContent",DbType.String,"TemplateContent",DataRowVersion.Current);
				Database.AddInParameter(command,"oldEmailTemplateId",DbType.Int32,"EmailTemplateId",DataRowVersion.Current);

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
		public bool DeleteEmailTemplate( int emailTemplateId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteEmailTemplate");
			Database.AddInParameter(command,"EmailTemplateId",DbType.Int32,emailTemplateId);
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
				Database.AddInParameter(command,"EmailTemplateId",DbType.Int32,"EmailTemplateId",DataRowVersion.Current);
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
