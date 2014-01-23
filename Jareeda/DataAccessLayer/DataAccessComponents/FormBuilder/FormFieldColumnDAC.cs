using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.FormBuilder
{
	/// <summary>
	/// This is a Data Access Class  for FormFieldColumn table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the FormFieldColumn table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class FormFieldColumnDAC : DataAccessComponent
	{
		#region Constructors
        public FormFieldColumnDAC() : base("", "FormBuilder.FormFieldColumn") { }
		public FormFieldColumnDAC(string connectionString): base(connectionString){}
		public FormFieldColumnDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormFieldColumn using Stored Procedure
		/// and return a DataTable containing all FormFieldColumn Data
		/// </summary>
		public DataTable GetAllFormFieldColumn()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormFieldColumn";
         string query = " select * from GetAllFormFieldColumn";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormFieldColumn"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormFieldColumn using Stored Procedure
		/// and return a DataTable containing all FormFieldColumn Data using a Transaction
		/// </summary>
		public DataTable GetAllFormFieldColumn(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormFieldColumn";
         string query = " select * from GetAllFormFieldColumn";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormFieldColumn"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormFieldColumn using Stored Procedure
		/// and return a DataTable containing all FormFieldColumn Data
		/// </summary>
		public DataTable GetAllFormFieldColumn(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormFieldColumn";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllFormFieldColumn" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormFieldColumn"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormFieldColumn using Stored Procedure
		/// and return a DataTable containing all FormFieldColumn Data using a Transaction
		/// </summary>
		public DataTable GetAllFormFieldColumn(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormFieldColumn";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllFormFieldColumn" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormFieldColumn"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormFieldColumn using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormFieldColumn( int formFieldColumnId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormFieldColumn");
				    Database.AddInParameter(command,"FormFieldColumnId",DbType.Int32,formFieldColumnId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormFieldColumn using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormFieldColumn( int formFieldColumnId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormFieldColumn");
				    Database.AddInParameter(command,"FormFieldColumnId",DbType.Int32,formFieldColumnId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormFieldColumn using Stored Procedure
		/// and return the auto number primary key of FormFieldColumn inserted row
		/// </summary>
		public bool InsertNewFormFieldColumn( ref int formFieldColumnId,  int formFieldId,  string fieldColumnValue,  string fieldColumnHelp,  int fieldColumnGrade)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormFieldColumn");
				Database.AddOutParameter(command,"FormFieldColumnId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"FormFieldId",DbType.Int32,formFieldId);
				Database.AddInParameter(command,"FieldColumnValue",DbType.String,fieldColumnValue);
				Database.AddInParameter(command,"FieldColumnHelp",DbType.String,fieldColumnHelp);
				Database.AddInParameter(command,"FieldColumnGrade",DbType.Int32,fieldColumnGrade);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 formFieldColumnId = Convert.ToInt32(Database.GetParameterValue(command, "FormFieldColumnId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormFieldColumn using Stored Procedure
		/// and return the auto number primary key of FormFieldColumn inserted row using Transaction
		/// </summary>
		public bool InsertNewFormFieldColumn( ref int formFieldColumnId,  int formFieldId,  string fieldColumnValue,  string fieldColumnHelp,  int fieldColumnGrade,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormFieldColumn");
				Database.AddOutParameter(command,"FormFieldColumnId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"FormFieldId",DbType.Int32,formFieldId);
				Database.AddInParameter(command,"FieldColumnValue",DbType.String,fieldColumnValue);
				Database.AddInParameter(command,"FieldColumnHelp",DbType.String,fieldColumnHelp);
				Database.AddInParameter(command,"FieldColumnGrade",DbType.Int32,fieldColumnGrade);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 formFieldColumnId = Convert.ToInt32(Database.GetParameterValue(command, "FormFieldColumnId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for FormFieldColumn using Stored Procedure
		/// and return DbCommand of the FormFieldColumn
		/// </summary>
		public DbCommand InsertNewFormFieldColumnCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormFieldColumn");

				Database.AddInParameter(command,"FormFieldId",DbType.Int32,"FormFieldId",DataRowVersion.Current);
				Database.AddInParameter(command,"FieldColumnValue",DbType.String,"FieldColumnValue",DataRowVersion.Current);
				Database.AddInParameter(command,"FieldColumnHelp",DbType.String,"FieldColumnHelp",DataRowVersion.Current);
				Database.AddInParameter(command,"FieldColumnGrade",DbType.Int32,"FieldColumnGrade",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormFieldColumn using Stored Procedure
		/// </summary>
		public bool UpdateFormFieldColumn( int formFieldId, string fieldColumnValue, string fieldColumnHelp, int fieldColumnGrade, int oldformFieldColumnId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormFieldColumn");

		    		Database.AddInParameter(command,"FormFieldId",DbType.Int32,formFieldId);
		    		Database.AddInParameter(command,"FieldColumnValue",DbType.String,fieldColumnValue);
		    		Database.AddInParameter(command,"FieldColumnHelp",DbType.String,fieldColumnHelp);
		    		Database.AddInParameter(command,"FieldColumnGrade",DbType.Int32,fieldColumnGrade);
				Database.AddInParameter(command,"oldFormFieldColumnId",DbType.Int32,oldformFieldColumnId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormFieldColumn using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateFormFieldColumn( int formFieldId, string fieldColumnValue, string fieldColumnHelp, int fieldColumnGrade, int oldformFieldColumnId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormFieldColumn");

		    		Database.AddInParameter(command,"FormFieldId",DbType.Int32,formFieldId);
		    		Database.AddInParameter(command,"FieldColumnValue",DbType.String,fieldColumnValue);
		    		Database.AddInParameter(command,"FieldColumnHelp",DbType.String,fieldColumnHelp);
		    		Database.AddInParameter(command,"FieldColumnGrade",DbType.Int32,fieldColumnGrade);
				Database.AddInParameter(command,"oldFormFieldColumnId",DbType.Int32,oldformFieldColumnId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from FormFieldColumn using Stored Procedure
		/// </summary>
		public DbCommand UpdateFormFieldColumnCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormFieldColumn");

		    		Database.AddInParameter(command,"FormFieldId",DbType.Int32,"FormFieldId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FieldColumnValue",DbType.String,"FieldColumnValue",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FieldColumnHelp",DbType.String,"FieldColumnHelp",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FieldColumnGrade",DbType.Int32,"FieldColumnGrade",DataRowVersion.Current);
				Database.AddInParameter(command,"oldFormFieldColumnId",DbType.Int32,"FormFieldColumnId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From FormFieldColumn using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteFormFieldColumn( int formFieldColumnId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteFormFieldColumn");
			Database.AddInParameter(command,"FormFieldColumnId",DbType.Int32,formFieldColumnId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From FormFieldColumn Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteFormFieldColumnCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteFormFieldColumn");
				Database.AddInParameter(command,"FormFieldColumnId",DbType.Int32,"FormFieldColumnId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormFieldColumn using Stored Procedure
		/// and return number of rows effected of the FormFieldColumn
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormFieldColumn",InsertNewFormFieldColumnCommand(),UpdateFormFieldColumnCommand(),DeleteFormFieldColumnCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormFieldColumn using Stored Procedure
		/// and return number of rows effected of the FormFieldColumn
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormFieldColumn",InsertNewFormFieldColumnCommand(),UpdateFormFieldColumnCommand(),DeleteFormFieldColumnCommand(), transaction);
          return rowsAffected;
		}


	}
}
