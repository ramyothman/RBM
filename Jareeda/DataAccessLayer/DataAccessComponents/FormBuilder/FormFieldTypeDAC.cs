using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.FormBuilder
{
	/// <summary>
	/// This is a Data Access Class  for FormFieldType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the FormFieldType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class FormFieldTypeDAC : DataAccessComponent
	{
		#region Constructors
        public FormFieldTypeDAC() : base("", "FormBuilder.FormFieldType") { }
		public FormFieldTypeDAC(string connectionString): base(connectionString){}
		public FormFieldTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormFieldType using Stored Procedure
		/// and return a DataTable containing all FormFieldType Data
		/// </summary>
		public DataTable GetAllFormFieldType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormFieldType";
         string query = " select * from GetAllFormFieldType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormFieldType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormFieldType using Stored Procedure
		/// and return a DataTable containing all FormFieldType Data using a Transaction
		/// </summary>
		public DataTable GetAllFormFieldType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormFieldType";
         string query = " select * from GetAllFormFieldType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormFieldType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormFieldType using Stored Procedure
		/// and return a DataTable containing all FormFieldType Data
		/// </summary>
		public DataTable GetAllFormFieldType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormFieldType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllFormFieldType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormFieldType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormFieldType using Stored Procedure
		/// and return a DataTable containing all FormFieldType Data using a Transaction
		/// </summary>
		public DataTable GetAllFormFieldType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormFieldType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllFormFieldType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormFieldType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormFieldType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormFieldType( int formFieldTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormFieldType");
				    Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,formFieldTypeId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormFieldType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormFieldType( int formFieldTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormFieldType");
				    Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,formFieldTypeId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormFieldType using Stored Procedure
		/// and return the auto number primary key of FormFieldType inserted row
		/// </summary>
		public bool InsertNewFormFieldType( int formFieldTypeId,  string name,  string template)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormFieldType");
				Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,formFieldTypeId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Template",DbType.String,template);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormFieldType using Stored Procedure
		/// and return the auto number primary key of FormFieldType inserted row using Transaction
		/// </summary>
		public bool InsertNewFormFieldType( int formFieldTypeId,  string name,  string template,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormFieldType");
				Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,formFieldTypeId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Template",DbType.String,template);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for FormFieldType using Stored Procedure
		/// and return DbCommand of the FormFieldType
		/// </summary>
		public DbCommand InsertNewFormFieldTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormFieldType");
				Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,"FormFieldTypeId",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"Template",DbType.String,"Template",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormFieldType using Stored Procedure
		/// </summary>
		public bool UpdateFormFieldType( int formFieldTypeId, string name, string template, int oldformFieldTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormFieldType");
		    		Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,formFieldTypeId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Template",DbType.String,template);
				Database.AddInParameter(command,"oldFormFieldTypeId",DbType.Int32,oldformFieldTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormFieldType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateFormFieldType( int formFieldTypeId, string name, string template, int oldformFieldTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormFieldType");
		    		Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,formFieldTypeId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Template",DbType.String,template);
				Database.AddInParameter(command,"oldFormFieldTypeId",DbType.Int32,oldformFieldTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from FormFieldType using Stored Procedure
		/// </summary>
		public DbCommand UpdateFormFieldTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormFieldType");
		    		Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,"FormFieldTypeId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Template",DbType.String,"Template",DataRowVersion.Current);
				Database.AddInParameter(command,"oldFormFieldTypeId",DbType.Int32,"FormFieldTypeId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From FormFieldType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteFormFieldType( int formFieldTypeId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteFormFieldType");
			Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,formFieldTypeId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From FormFieldType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteFormFieldTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteFormFieldType");
				Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,"FormFieldTypeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormFieldType using Stored Procedure
		/// and return number of rows effected of the FormFieldType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormFieldType",InsertNewFormFieldTypeCommand(),UpdateFormFieldTypeCommand(),DeleteFormFieldTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormFieldType using Stored Procedure
		/// and return number of rows effected of the FormFieldType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormFieldType",InsertNewFormFieldTypeCommand(),UpdateFormFieldTypeCommand(),DeleteFormFieldTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
