using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.FormBuilder
{
	/// <summary>
	/// This is a Data Access Class  for FormSubmissionAnswer table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the FormSubmissionAnswer table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class FormSubmissionAnswerDAC : DataAccessComponent
	{
		#region Constructors
        public FormSubmissionAnswerDAC() : base("", "FormBuilder.FormSubmissionAnswer") { }
		public FormSubmissionAnswerDAC(string connectionString): base(connectionString){}
		public FormSubmissionAnswerDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormSubmissionAnswer using Stored Procedure
		/// and return a DataTable containing all FormSubmissionAnswer Data
		/// </summary>
		public DataTable GetAllFormSubmissionAnswer()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormSubmissionAnswer";
         string query = " select * from GetAllFormSubmissionAnswer";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormSubmissionAnswer"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormSubmissionAnswer using Stored Procedure
		/// and return a DataTable containing all FormSubmissionAnswer Data using a Transaction
		/// </summary>
		public DataTable GetAllFormSubmissionAnswer(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormSubmissionAnswer";
         string query = " select * from GetAllFormSubmissionAnswer";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormSubmissionAnswer"];

		}

        public DataTable ViewSubmissionAnswers()
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ViewSubmissionAnswers";
            string query = " select * from ViewSubmissionAnswers";
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["ViewSubmissionAnswers"];

        }


        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormSubmissionAnswer using Stored Procedure
        /// and return a DataTable containing all FormSubmissionAnswer Data
        /// </summary>
        public DataTable ViewSubmissionAnswers(string where)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ViewSubmissionAnswers";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = " select * from ViewSubmissionAnswers" + whereClause;
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["ViewSubmissionAnswers"];

        }


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormSubmissionAnswer using Stored Procedure
		/// and return a DataTable containing all FormSubmissionAnswer Data
		/// </summary>
		public DataTable GetAllFormSubmissionAnswer(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormSubmissionAnswer";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllFormSubmissionAnswer" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormSubmissionAnswer"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormSubmissionAnswer using Stored Procedure
		/// and return a DataTable containing all FormSubmissionAnswer Data using a Transaction
		/// </summary>
		public DataTable GetAllFormSubmissionAnswer(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormSubmissionAnswer";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllFormSubmissionAnswer" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormSubmissionAnswer"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormSubmissionAnswer using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormSubmissionAnswer( int formSubmissionAnswerId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormSubmissionAnswer");
				    Database.AddInParameter(command,"FormSubmissionAnswerId",DbType.Int32,formSubmissionAnswerId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormSubmissionAnswer using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormSubmissionAnswer( int formSubmissionAnswerId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormSubmissionAnswer");
				    Database.AddInParameter(command,"FormSubmissionAnswerId",DbType.Int32,formSubmissionAnswerId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormSubmissionAnswer using Stored Procedure
		/// and return the auto number primary key of FormSubmissionAnswer inserted row
		/// </summary>
		public bool InsertNewFormSubmissionAnswer( ref int formSubmissionAnswerId,  int formSubmissionId,  int formFieldId,  string answer,  int formFieldColumnId,  int formFieldValueId,  int grade)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormSubmissionAnswer");
				Database.AddOutParameter(command,"FormSubmissionAnswerId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"FormSubmissionId",DbType.Int32,formSubmissionId);
				Database.AddInParameter(command,"FormFieldId",DbType.Int32,formFieldId);
				Database.AddInParameter(command,"Answer",DbType.String,answer);
				Database.AddInParameter(command,"FormFieldColumnId",DbType.Int32,formFieldColumnId);
				Database.AddInParameter(command,"FormFieldValueId",DbType.Int32,formFieldValueId);
				Database.AddInParameter(command,"Grade",DbType.Int32,grade);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 formSubmissionAnswerId = Convert.ToInt32(Database.GetParameterValue(command, "FormSubmissionAnswerId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormSubmissionAnswer using Stored Procedure
		/// and return the auto number primary key of FormSubmissionAnswer inserted row using Transaction
		/// </summary>
		public bool InsertNewFormSubmissionAnswer( ref int formSubmissionAnswerId,  int formSubmissionId,  int formFieldId,  string answer,  int formFieldColumnId,  int formFieldValueId,  int grade,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormSubmissionAnswer");
				Database.AddOutParameter(command,"FormSubmissionAnswerId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"FormSubmissionId",DbType.Int32,formSubmissionId);
				Database.AddInParameter(command,"FormFieldId",DbType.Int32,formFieldId);
				Database.AddInParameter(command,"Answer",DbType.String,answer);
				Database.AddInParameter(command,"FormFieldColumnId",DbType.Int32,formFieldColumnId);
				Database.AddInParameter(command,"FormFieldValueId",DbType.Int32,formFieldValueId);
				Database.AddInParameter(command,"Grade",DbType.Int32,grade);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 formSubmissionAnswerId = Convert.ToInt32(Database.GetParameterValue(command, "FormSubmissionAnswerId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for FormSubmissionAnswer using Stored Procedure
		/// and return DbCommand of the FormSubmissionAnswer
		/// </summary>
		public DbCommand InsertNewFormSubmissionAnswerCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormSubmissionAnswer");

				Database.AddInParameter(command,"FormSubmissionId",DbType.Int32,"FormSubmissionId",DataRowVersion.Current);
				Database.AddInParameter(command,"FormFieldId",DbType.Int32,"FormFieldId",DataRowVersion.Current);
				Database.AddInParameter(command,"Answer",DbType.String,"Answer",DataRowVersion.Current);
				Database.AddInParameter(command,"FormFieldColumnId",DbType.Int32,"FormFieldColumnId",DataRowVersion.Current);
				Database.AddInParameter(command,"FormFieldValueId",DbType.Int32,"FormFieldValueId",DataRowVersion.Current);
				Database.AddInParameter(command,"Grade",DbType.Int32,"Grade",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormSubmissionAnswer using Stored Procedure
		/// </summary>
		public bool UpdateFormSubmissionAnswer( int formSubmissionId, int formFieldId, string answer, int formFieldColumnId, int formFieldValueId, int grade, int oldformSubmissionAnswerId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormSubmissionAnswer");

		    		Database.AddInParameter(command,"FormSubmissionId",DbType.Int32,formSubmissionId);
		    		Database.AddInParameter(command,"FormFieldId",DbType.Int32,formFieldId);
		    		Database.AddInParameter(command,"Answer",DbType.String,answer);
		    		Database.AddInParameter(command,"FormFieldColumnId",DbType.Int32,formFieldColumnId);
		    		Database.AddInParameter(command,"FormFieldValueId",DbType.Int32,formFieldValueId);
		    		Database.AddInParameter(command,"Grade",DbType.Int32,grade);
				Database.AddInParameter(command,"oldFormSubmissionAnswerId",DbType.Int32,oldformSubmissionAnswerId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormSubmissionAnswer using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateFormSubmissionAnswer( int formSubmissionId, int formFieldId, string answer, int formFieldColumnId, int formFieldValueId, int grade, int oldformSubmissionAnswerId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormSubmissionAnswer");

		    		Database.AddInParameter(command,"FormSubmissionId",DbType.Int32,formSubmissionId);
		    		Database.AddInParameter(command,"FormFieldId",DbType.Int32,formFieldId);
		    		Database.AddInParameter(command,"Answer",DbType.String,answer);
		    		Database.AddInParameter(command,"FormFieldColumnId",DbType.Int32,formFieldColumnId);
		    		Database.AddInParameter(command,"FormFieldValueId",DbType.Int32,formFieldValueId);
		    		Database.AddInParameter(command,"Grade",DbType.Int32,grade);
				Database.AddInParameter(command,"oldFormSubmissionAnswerId",DbType.Int32,oldformSubmissionAnswerId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from FormSubmissionAnswer using Stored Procedure
		/// </summary>
		public DbCommand UpdateFormSubmissionAnswerCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormSubmissionAnswer");

		    		Database.AddInParameter(command,"FormSubmissionId",DbType.Int32,"FormSubmissionId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FormFieldId",DbType.Int32,"FormFieldId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Answer",DbType.String,"Answer",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FormFieldColumnId",DbType.Int32,"FormFieldColumnId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FormFieldValueId",DbType.Int32,"FormFieldValueId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Grade",DbType.Int32,"Grade",DataRowVersion.Current);
				Database.AddInParameter(command,"oldFormSubmissionAnswerId",DbType.Int32,"FormSubmissionAnswerId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From FormSubmissionAnswer using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteFormSubmissionAnswer( int formSubmissionAnswerId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteFormSubmissionAnswer");
			Database.AddInParameter(command,"FormSubmissionAnswerId",DbType.Int32,formSubmissionAnswerId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From FormSubmissionAnswer Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteFormSubmissionAnswerCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteFormSubmissionAnswer");
				Database.AddInParameter(command,"FormSubmissionAnswerId",DbType.Int32,"FormSubmissionAnswerId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormSubmissionAnswer using Stored Procedure
		/// and return number of rows effected of the FormSubmissionAnswer
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormSubmissionAnswer",InsertNewFormSubmissionAnswerCommand(),UpdateFormSubmissionAnswerCommand(),DeleteFormSubmissionAnswerCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormSubmissionAnswer using Stored Procedure
		/// and return number of rows effected of the FormSubmissionAnswer
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormSubmissionAnswer",InsertNewFormSubmissionAnswerCommand(),UpdateFormSubmissionAnswerCommand(),DeleteFormSubmissionAnswerCommand(), transaction);
          return rowsAffected;
		}


	}
}
