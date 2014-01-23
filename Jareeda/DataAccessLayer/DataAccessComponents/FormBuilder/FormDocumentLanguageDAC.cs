using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.FormBuilder
{
	/// <summary>
	/// This is a Data Access Class  for FormDocumentLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the FormDocumentLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class FormDocumentLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public FormDocumentLanguageDAC() : base("", "FormBuilder.FormDocumentLanguage") { }
		public FormDocumentLanguageDAC(string connectionString): base(connectionString){}
		public FormDocumentLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormDocumentLanguage using Stored Procedure
		/// and return a DataTable containing all FormDocumentLanguage Data
		/// </summary>
		public DataTable GetAllFormDocumentLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormDocumentLanguage";
         string query = " select * from GetAllFormDocumentLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormDocumentLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormDocumentLanguage using Stored Procedure
		/// and return a DataTable containing all FormDocumentLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllFormDocumentLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormDocumentLanguage";
         string query = " select * from GetAllFormDocumentLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormDocumentLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormDocumentLanguage using Stored Procedure
		/// and return a DataTable containing all FormDocumentLanguage Data
		/// </summary>
		public DataTable GetAllFormDocumentLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormDocumentLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllFormDocumentLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormDocumentLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormDocumentLanguage using Stored Procedure
		/// and return a DataTable containing all FormDocumentLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllFormDocumentLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormDocumentLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllFormDocumentLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormDocumentLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormDocumentLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormDocumentLanguage( int formDocumentLanguageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormDocumentLanguage");
				    Database.AddInParameter(command,"FormDocumentLanguageId",DbType.Int32,formDocumentLanguageId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormDocumentLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormDocumentLanguage( int formDocumentLanguageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormDocumentLanguage");
				    Database.AddInParameter(command,"FormDocumentLanguageId",DbType.Int32,formDocumentLanguageId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormDocumentLanguage using Stored Procedure
		/// and return the auto number primary key of FormDocumentLanguage inserted row
		/// </summary>
		public bool InsertNewFormDocumentLanguage( ref int formDocumentLanguageId,  int documentId,  int languageId,  string title,  string description,  string confirmationText)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormDocumentLanguage");
				Database.AddOutParameter(command,"FormDocumentLanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"DocumentId",DbType.Int32,documentId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"ConfirmationText",DbType.String,confirmationText);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 formDocumentLanguageId = Convert.ToInt32(Database.GetParameterValue(command, "FormDocumentLanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormDocumentLanguage using Stored Procedure
		/// and return the auto number primary key of FormDocumentLanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewFormDocumentLanguage( ref int formDocumentLanguageId,  int documentId,  int languageId,  string title,  string description,  string confirmationText,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormDocumentLanguage");
				Database.AddOutParameter(command,"FormDocumentLanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"DocumentId",DbType.Int32,documentId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"ConfirmationText",DbType.String,confirmationText);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 formDocumentLanguageId = Convert.ToInt32(Database.GetParameterValue(command, "FormDocumentLanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for FormDocumentLanguage using Stored Procedure
		/// and return DbCommand of the FormDocumentLanguage
		/// </summary>
		public DbCommand InsertNewFormDocumentLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormDocumentLanguage");

				Database.AddInParameter(command,"DocumentId",DbType.Int32,"DocumentId",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
				Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
				Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
				Database.AddInParameter(command,"ConfirmationText",DbType.String,"ConfirmationText",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormDocumentLanguage using Stored Procedure
		/// </summary>
		public bool UpdateFormDocumentLanguage( int documentId, int languageId, string title, string description, string confirmationText, int oldformDocumentLanguageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormDocumentLanguage");

		    		Database.AddInParameter(command,"DocumentId",DbType.Int32,documentId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"ConfirmationText",DbType.String,confirmationText);
				Database.AddInParameter(command,"oldFormDocumentLanguageId",DbType.Int32,oldformDocumentLanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormDocumentLanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateFormDocumentLanguage( int documentId, int languageId, string title, string description, string confirmationText, int oldformDocumentLanguageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormDocumentLanguage");

		    		Database.AddInParameter(command,"DocumentId",DbType.Int32,documentId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"ConfirmationText",DbType.String,confirmationText);
				Database.AddInParameter(command,"oldFormDocumentLanguageId",DbType.Int32,oldformDocumentLanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from FormDocumentLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateFormDocumentLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormDocumentLanguage");

		    		Database.AddInParameter(command,"DocumentId",DbType.Int32,"DocumentId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConfirmationText",DbType.String,"ConfirmationText",DataRowVersion.Current);
				Database.AddInParameter(command,"oldFormDocumentLanguageId",DbType.Int32,"FormDocumentLanguageId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From FormDocumentLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteFormDocumentLanguage( int formDocumentLanguageId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteFormDocumentLanguage");
			Database.AddInParameter(command,"FormDocumentLanguageId",DbType.Int32,formDocumentLanguageId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From FormDocumentLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteFormDocumentLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteFormDocumentLanguage");
				Database.AddInParameter(command,"FormDocumentLanguageId",DbType.Int32,"FormDocumentLanguageId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormDocumentLanguage using Stored Procedure
		/// and return number of rows effected of the FormDocumentLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormDocumentLanguage",InsertNewFormDocumentLanguageCommand(),UpdateFormDocumentLanguageCommand(),DeleteFormDocumentLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormDocumentLanguage using Stored Procedure
		/// and return number of rows effected of the FormDocumentLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormDocumentLanguage",InsertNewFormDocumentLanguageCommand(),UpdateFormDocumentLanguageCommand(),DeleteFormDocumentLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
