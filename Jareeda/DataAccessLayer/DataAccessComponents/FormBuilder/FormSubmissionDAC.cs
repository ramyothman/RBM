using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.FormBuilder
{
	/// <summary>
	/// This is a Data Access Class  for FormSubmission table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the FormSubmission table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class FormSubmissionDAC : DataAccessComponent
	{
		#region Constructors
        public FormSubmissionDAC() : base("", "FormBuilder.FormSubmission") { }
		public FormSubmissionDAC(string connectionString): base(connectionString){}
		public FormSubmissionDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormSubmission using Stored Procedure
		/// and return a DataTable containing all FormSubmission Data
		/// </summary>
		public DataTable GetAllFormSubmission()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormSubmission";
         string query = " select * from GetAllFormSubmission";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormSubmission"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormSubmission using Stored Procedure
		/// and return a DataTable containing all FormSubmission Data using a Transaction
		/// </summary>
		public DataTable GetAllFormSubmission(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormSubmission";
         string query = " select * from GetAllFormSubmission";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormSubmission"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormSubmission using Stored Procedure
		/// and return a DataTable containing all FormSubmission Data
		/// </summary>
		public DataTable GetAllFormSubmission(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormSubmission";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllFormSubmission" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormSubmission"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormSubmission using Stored Procedure
		/// and return a DataTable containing all FormSubmission Data using a Transaction
		/// </summary>
		public DataTable GetAllFormSubmission(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormSubmission";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllFormSubmission" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormSubmission"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormSubmission using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormSubmission( int formSubmissionId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormSubmission");
				    Database.AddInParameter(command,"FormSubmissionId",DbType.Int32,formSubmissionId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormSubmission using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormSubmission( int formSubmissionId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormSubmission");
				    Database.AddInParameter(command,"FormSubmissionId",DbType.Int32,formSubmissionId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormSubmission using Stored Procedure
		/// and return the auto number primary key of FormSubmission inserted row
		/// </summary>
		public bool InsertNewFormSubmission( ref int formSubmissionId,  int userId,  bool isAnonymous,  DateTime submissionDate,  string iPAddress,  bool isValid,  bool emailSent,  bool sMSSent,  int formDocumentID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormSubmission");
				Database.AddOutParameter(command,"FormSubmissionId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"UserId",DbType.Int32,userId);
				Database.AddInParameter(command,"IsAnonymous",DbType.Boolean,isAnonymous);
				Database.AddInParameter(command,"SubmissionDate",DbType.DateTime,submissionDate);
				Database.AddInParameter(command,"IPAddress",DbType.String,iPAddress);
				Database.AddInParameter(command,"IsValid",DbType.Boolean,isValid);
				Database.AddInParameter(command,"EmailSent",DbType.Boolean,emailSent);
				Database.AddInParameter(command,"SMSSent",DbType.Boolean,sMSSent);
				Database.AddInParameter(command,"FormDocumentID",DbType.Int32,formDocumentID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 formSubmissionId = Convert.ToInt32(Database.GetParameterValue(command, "FormSubmissionId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormSubmission using Stored Procedure
		/// and return the auto number primary key of FormSubmission inserted row using Transaction
		/// </summary>
		public bool InsertNewFormSubmission( ref int formSubmissionId,  int userId,  bool isAnonymous,  DateTime submissionDate,  string iPAddress,  bool isValid,  bool emailSent,  bool sMSSent,  int formDocumentID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormSubmission");
				Database.AddOutParameter(command,"FormSubmissionId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"UserId",DbType.Int32,userId);
				Database.AddInParameter(command,"IsAnonymous",DbType.Boolean,isAnonymous);
				Database.AddInParameter(command,"SubmissionDate",DbType.DateTime,submissionDate);
				Database.AddInParameter(command,"IPAddress",DbType.String,iPAddress);
				Database.AddInParameter(command,"IsValid",DbType.Boolean,isValid);
				Database.AddInParameter(command,"EmailSent",DbType.Boolean,emailSent);
				Database.AddInParameter(command,"SMSSent",DbType.Boolean,sMSSent);
				Database.AddInParameter(command,"FormDocumentID",DbType.Int32,formDocumentID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 formSubmissionId = Convert.ToInt32(Database.GetParameterValue(command, "FormSubmissionId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for FormSubmission using Stored Procedure
		/// and return DbCommand of the FormSubmission
		/// </summary>
		public DbCommand InsertNewFormSubmissionCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormSubmission");

				Database.AddInParameter(command,"UserId",DbType.Int32,"UserId",DataRowVersion.Current);
				Database.AddInParameter(command,"IsAnonymous",DbType.Boolean,"IsAnonymous",DataRowVersion.Current);
				Database.AddInParameter(command,"SubmissionDate",DbType.DateTime,"SubmissionDate",DataRowVersion.Current);
				Database.AddInParameter(command,"IPAddress",DbType.String,"IPAddress",DataRowVersion.Current);
				Database.AddInParameter(command,"IsValid",DbType.Boolean,"IsValid",DataRowVersion.Current);
				Database.AddInParameter(command,"EmailSent",DbType.Boolean,"EmailSent",DataRowVersion.Current);
				Database.AddInParameter(command,"SMSSent",DbType.Boolean,"SMSSent",DataRowVersion.Current);
				Database.AddInParameter(command,"FormDocumentID",DbType.Int32,"FormDocumentID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormSubmission using Stored Procedure
		/// </summary>
		public bool UpdateFormSubmission( int userId, bool isAnonymous, DateTime submissionDate, string iPAddress, bool isValid, bool emailSent, bool sMSSent, int formDocumentID, int oldformSubmissionId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormSubmission");

		    		Database.AddInParameter(command,"UserId",DbType.Int32,userId);
		    		Database.AddInParameter(command,"IsAnonymous",DbType.Boolean,isAnonymous);
		    		Database.AddInParameter(command,"SubmissionDate",DbType.DateTime,submissionDate);
		    		Database.AddInParameter(command,"IPAddress",DbType.String,iPAddress);
		    		Database.AddInParameter(command,"IsValid",DbType.Boolean,isValid);
		    		Database.AddInParameter(command,"EmailSent",DbType.Boolean,emailSent);
		    		Database.AddInParameter(command,"SMSSent",DbType.Boolean,sMSSent);
		    		Database.AddInParameter(command,"FormDocumentID",DbType.Int32,formDocumentID);
				Database.AddInParameter(command,"oldFormSubmissionId",DbType.Int32,oldformSubmissionId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormSubmission using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateFormSubmission( int userId, bool isAnonymous, DateTime submissionDate, string iPAddress, bool isValid, bool emailSent, bool sMSSent, int formDocumentID, int oldformSubmissionId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormSubmission");

		    		Database.AddInParameter(command,"UserId",DbType.Int32,userId);
		    		Database.AddInParameter(command,"IsAnonymous",DbType.Boolean,isAnonymous);
		    		Database.AddInParameter(command,"SubmissionDate",DbType.DateTime,submissionDate);
		    		Database.AddInParameter(command,"IPAddress",DbType.String,iPAddress);
		    		Database.AddInParameter(command,"IsValid",DbType.Boolean,isValid);
		    		Database.AddInParameter(command,"EmailSent",DbType.Boolean,emailSent);
		    		Database.AddInParameter(command,"SMSSent",DbType.Boolean,sMSSent);
		    		Database.AddInParameter(command,"FormDocumentID",DbType.Int32,formDocumentID);
				Database.AddInParameter(command,"oldFormSubmissionId",DbType.Int32,oldformSubmissionId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from FormSubmission using Stored Procedure
		/// </summary>
		public DbCommand UpdateFormSubmissionCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormSubmission");

		    		Database.AddInParameter(command,"UserId",DbType.Int32,"UserId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsAnonymous",DbType.Boolean,"IsAnonymous",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SubmissionDate",DbType.DateTime,"SubmissionDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IPAddress",DbType.String,"IPAddress",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsValid",DbType.Boolean,"IsValid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EmailSent",DbType.Boolean,"EmailSent",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SMSSent",DbType.Boolean,"SMSSent",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FormDocumentID",DbType.Int32,"FormDocumentID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldFormSubmissionId",DbType.Int32,"FormSubmissionId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From FormSubmission using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteFormSubmission( int formSubmissionId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteFormSubmission");
			Database.AddInParameter(command,"FormSubmissionId",DbType.Int32,formSubmissionId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From FormSubmission Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteFormSubmissionCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteFormSubmission");
				Database.AddInParameter(command,"FormSubmissionId",DbType.Int32,"FormSubmissionId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormSubmission using Stored Procedure
		/// and return number of rows effected of the FormSubmission
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormSubmission",InsertNewFormSubmissionCommand(),UpdateFormSubmissionCommand(),DeleteFormSubmissionCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormSubmission using Stored Procedure
		/// and return number of rows effected of the FormSubmission
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormSubmission",InsertNewFormSubmissionCommand(),UpdateFormSubmissionCommand(),DeleteFormSubmissionCommand(), transaction);
          return rowsAffected;
		}


	}
}
