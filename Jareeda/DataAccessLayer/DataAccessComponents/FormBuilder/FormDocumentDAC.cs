using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.FormBuilder
{
	/// <summary>
	/// This is a Data Access Class  for FormDocument table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the FormDocument table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class FormDocumentDAC : DataAccessComponent
	{
		#region Constructors
        public FormDocumentDAC() : base("", "FormBuilder.FormDocument") { }
		public FormDocumentDAC(string connectionString): base(connectionString){}
		public FormDocumentDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormDocument using Stored Procedure
		/// and return a DataTable containing all FormDocument Data
		/// </summary>
		public DataTable GetAllFormDocument()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormDocument";
         string query = " select * from GetAllFormDocument";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormDocument"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormDocument using Stored Procedure
		/// and return a DataTable containing all FormDocument Data using a Transaction
		/// </summary>
		public DataTable GetAllFormDocument(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormDocument";
         string query = " select * from GetAllFormDocument";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormDocument"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormDocument using Stored Procedure
		/// and return a DataTable containing all FormDocument Data
		/// </summary>
		public DataTable GetAllFormDocument(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormDocument";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllFormDocument" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormDocument"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormDocument using Stored Procedure
		/// and return a DataTable containing all FormDocument Data using a Transaction
		/// </summary>
		public DataTable GetAllFormDocument(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormDocument";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllFormDocument" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormDocument"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormDocument using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormDocument( int formDocumentID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormDocument");
				    Database.AddInParameter(command,"FormDocumentID",DbType.Int32,formDocumentID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormDocument using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormDocument( int formDocumentID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormDocument");
				    Database.AddInParameter(command,"FormDocumentID",DbType.Int32,formDocumentID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormDocument using Stored Procedure
		/// and return the auto number primary key of FormDocument inserted row
		/// </summary>
		public bool InsertNewFormDocument( ref int formDocumentID,  int formDocumentStatusID,  string title,  string description,  DateTime startDate,  DateTime endDate,  string confirmationText,  int creatorID,  DateTime creationDate,  bool sendEmail,  bool sendSMS,  bool allowModify)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormDocument");
				Database.AddOutParameter(command,"FormDocumentID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,formDocumentStatusID);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"Description",DbType.String,description);
                if(startDate == DateTime.MinValue)
				    Database.AddInParameter(command,"StartDate",DbType.DateTime,DBNull.Value);
                else
                    Database.AddInParameter(command, "StartDate", DbType.DateTime, startDate);
                if(endDate == DateTime.MinValue)
				    Database.AddInParameter(command,"EndDate",DbType.DateTime,DBNull.Value);
                else
                    Database.AddInParameter(command, "EndDate", DbType.DateTime, endDate);
				Database.AddInParameter(command,"ConfirmationText",DbType.String,confirmationText);
                if(creatorID == 0)
				    Database.AddInParameter(command,"CreatorID",DbType.Int32,DBNull.Value);
                else
                    Database.AddInParameter(command, "CreatorID", DbType.Int32, creatorID);
                if(creationDate == DateTime.MinValue)
				    Database.AddInParameter(command,"CreationDate",DbType.DateTime,DateTime.Now);
                else
                    Database.AddInParameter(command, "CreationDate", DbType.DateTime, creationDate);
				Database.AddInParameter(command,"SendEmail",DbType.Boolean,sendEmail);
				Database.AddInParameter(command,"SendSMS",DbType.Boolean,sendSMS);
				Database.AddInParameter(command,"AllowModify",DbType.Boolean,allowModify);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 formDocumentID = Convert.ToInt32(Database.GetParameterValue(command, "FormDocumentID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormDocument using Stored Procedure
		/// and return the auto number primary key of FormDocument inserted row using Transaction
		/// </summary>
		public bool InsertNewFormDocument( ref int formDocumentID,  int formDocumentStatusID,  string title,  string description,  DateTime startDate,  DateTime endDate,  string confirmationText,  int creatorID,  DateTime creationDate,  bool sendEmail,  bool sendSMS,  bool allowModify,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormDocument");
				Database.AddOutParameter(command,"FormDocumentID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,formDocumentStatusID);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"Description",DbType.String,description);
                if (startDate == DateTime.MinValue)
                    Database.AddInParameter(command, "StartDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "StartDate", DbType.DateTime, startDate);
                if (endDate == DateTime.MinValue)
                    Database.AddInParameter(command, "EndDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "EndDate", DbType.DateTime, endDate);
                Database.AddInParameter(command, "ConfirmationText", DbType.String, confirmationText);
                if (creatorID == 0)
                    Database.AddInParameter(command, "CreatorID", DbType.Int32, DBNull.Value);
                else
                    Database.AddInParameter(command, "CreatorID", DbType.Int32, creatorID);
                if (creationDate == DateTime.MinValue)
                    Database.AddInParameter(command, "CreationDate", DbType.DateTime, DateTime.Now);
                else
                    Database.AddInParameter(command, "CreationDate", DbType.DateTime, creationDate);
				Database.AddInParameter(command,"SendEmail",DbType.Boolean,sendEmail);
				Database.AddInParameter(command,"SendSMS",DbType.Boolean,sendSMS);
				Database.AddInParameter(command,"AllowModify",DbType.Boolean,allowModify);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 formDocumentID = Convert.ToInt32(Database.GetParameterValue(command, "FormDocumentID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for FormDocument using Stored Procedure
		/// and return DbCommand of the FormDocument
		/// </summary>
		public DbCommand InsertNewFormDocumentCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormDocument");

				Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,"FormDocumentStatusID",DataRowVersion.Current);
				Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
				Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,"StartDate",DataRowVersion.Current);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,"EndDate",DataRowVersion.Current);
				Database.AddInParameter(command,"ConfirmationText",DbType.String,"ConfirmationText",DataRowVersion.Current);
				Database.AddInParameter(command,"CreatorID",DbType.Int32,"CreatorID",DataRowVersion.Current);
				Database.AddInParameter(command,"CreationDate",DbType.DateTime,"CreationDate",DataRowVersion.Current);
				Database.AddInParameter(command,"SendEmail",DbType.Boolean,"SendEmail",DataRowVersion.Current);
				Database.AddInParameter(command,"SendSMS",DbType.Boolean,"SendSMS",DataRowVersion.Current);
				Database.AddInParameter(command,"AllowModify",DbType.Boolean,"AllowModify",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormDocument using Stored Procedure
		/// </summary>
		public bool UpdateFormDocument( int formDocumentStatusID, string title, string description, DateTime startDate, DateTime endDate, string confirmationText, int creatorID, DateTime creationDate, bool sendEmail, bool sendSMS, bool allowModify, int oldformDocumentID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormDocument");

		    		Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,formDocumentStatusID);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
                    if (startDate == DateTime.MinValue)
                        Database.AddInParameter(command, "StartDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "StartDate", DbType.DateTime, startDate);
                    if (endDate == DateTime.MinValue)
                        Database.AddInParameter(command, "EndDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "EndDate", DbType.DateTime, endDate);
                    Database.AddInParameter(command, "ConfirmationText", DbType.String, confirmationText);
                    if (creatorID == 0)
                        Database.AddInParameter(command, "CreatorID", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "CreatorID", DbType.Int32, creatorID);
                    if (creationDate == DateTime.MinValue)
                        Database.AddInParameter(command, "CreationDate", DbType.DateTime, DateTime.Now);
                    else
                        Database.AddInParameter(command, "CreationDate", DbType.DateTime, creationDate);
		    		Database.AddInParameter(command,"SendEmail",DbType.Boolean,sendEmail);
		    		Database.AddInParameter(command,"SendSMS",DbType.Boolean,sendSMS);
		    		Database.AddInParameter(command,"AllowModify",DbType.Boolean,allowModify);
				Database.AddInParameter(command,"oldFormDocumentID",DbType.Int32,oldformDocumentID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormDocument using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateFormDocument( int formDocumentStatusID, string title, string description, DateTime startDate, DateTime endDate, string confirmationText, int creatorID, DateTime creationDate, bool sendEmail, bool sendSMS, bool allowModify, int oldformDocumentID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormDocument");

		    		Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,formDocumentStatusID);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
                    if (startDate == DateTime.MinValue)
                        Database.AddInParameter(command, "StartDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "StartDate", DbType.DateTime, startDate);
                    if (endDate == DateTime.MinValue)
                        Database.AddInParameter(command, "EndDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "EndDate", DbType.DateTime, endDate);
                    Database.AddInParameter(command, "ConfirmationText", DbType.String, confirmationText);
                    if (creatorID == 0)
                        Database.AddInParameter(command, "CreatorID", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "CreatorID", DbType.Int32, creatorID);
                    if (creationDate == DateTime.MinValue)
                        Database.AddInParameter(command, "CreationDate", DbType.DateTime, DateTime.Now);
                    else
                        Database.AddInParameter(command, "CreationDate", DbType.DateTime, creationDate);
		    		Database.AddInParameter(command,"SendEmail",DbType.Boolean,sendEmail);
		    		Database.AddInParameter(command,"SendSMS",DbType.Boolean,sendSMS);
		    		Database.AddInParameter(command,"AllowModify",DbType.Boolean,allowModify);
				Database.AddInParameter(command,"oldFormDocumentID",DbType.Int32,oldformDocumentID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from FormDocument using Stored Procedure
		/// </summary>
		public DbCommand UpdateFormDocumentCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormDocument");

		    		Database.AddInParameter(command,"FormDocumentStatusID",DbType.Int32,"FormDocumentStatusID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,"StartDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,"EndDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConfirmationText",DbType.String,"ConfirmationText",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CreatorID",DbType.Int32,"CreatorID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CreationDate",DbType.DateTime,"CreationDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SendEmail",DbType.Boolean,"SendEmail",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SendSMS",DbType.Boolean,"SendSMS",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AllowModify",DbType.Boolean,"AllowModify",DataRowVersion.Current);
				Database.AddInParameter(command,"oldFormDocumentID",DbType.Int32,"FormDocumentID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From FormDocument using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteFormDocument( int formDocumentID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteFormDocument");
			Database.AddInParameter(command,"FormDocumentID",DbType.Int32,formDocumentID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From FormDocument Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteFormDocumentCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteFormDocument");
				Database.AddInParameter(command,"FormDocumentID",DbType.Int32,"FormDocumentID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormDocument using Stored Procedure
		/// and return number of rows effected of the FormDocument
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormDocument",InsertNewFormDocumentCommand(),UpdateFormDocumentCommand(),DeleteFormDocumentCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormDocument using Stored Procedure
		/// and return number of rows effected of the FormDocument
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormDocument",InsertNewFormDocumentCommand(),UpdateFormDocumentCommand(),DeleteFormDocumentCommand(), transaction);
          return rowsAffected;
		}


	}
}
