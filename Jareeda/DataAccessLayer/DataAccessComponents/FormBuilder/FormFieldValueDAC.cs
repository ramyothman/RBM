using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.FormBuilder
{
	/// <summary>
	/// This is a Data Access Class  for FormFieldValue table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the FormFieldValue table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class FormFieldValueDAC : DataAccessComponent
	{
		#region Constructors
        public FormFieldValueDAC() : base("", "FormBuilder.FormFieldValue") { }
		public FormFieldValueDAC(string connectionString): base(connectionString){}
		public FormFieldValueDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormFieldValue using Stored Procedure
		/// and return a DataTable containing all FormFieldValue Data
		/// </summary>
		public DataTable GetAllFormFieldValue()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormFieldValue";
         string query = " select * from GetAllFormFieldValue";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormFieldValue"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormFieldValue using Stored Procedure
		/// and return a DataTable containing all FormFieldValue Data using a Transaction
		/// </summary>
		public DataTable GetAllFormFieldValue(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormFieldValue";
         string query = " select * from GetAllFormFieldValue";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormFieldValue"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormFieldValue using Stored Procedure
		/// and return a DataTable containing all FormFieldValue Data
		/// </summary>
		public DataTable GetAllFormFieldValue(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormFieldValue";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllFormFieldValue" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormFieldValue"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormFieldValue using Stored Procedure
		/// and return a DataTable containing all FormFieldValue Data using a Transaction
		/// </summary>
		public DataTable GetAllFormFieldValue(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormFieldValue";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllFormFieldValue" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormFieldValue"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormFieldValue using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormFieldValue( int formFieldValueId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormFieldValue");
				    Database.AddInParameter(command,"FormFieldValueId",DbType.Int32,formFieldValueId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormFieldValue using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormFieldValue( int formFieldValueId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormFieldValue");
				    Database.AddInParameter(command,"FormFieldValueId",DbType.Int32,formFieldValueId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}
        public int GetFieldValueTotalSubmissions(int FormFieldValueId)
        {
            int Total = 0;
            DbCommand command = Database.GetStoredProcCommand("GetFieldValueTotalSubmissions");
            Database.AddOutParameter(command, "Total", DbType.Int32, 0);
            Database.AddInParameter(command, "FormFieldValueId", DbType.Int32, FormFieldValueId);


            Database.ExecuteNonQuery(command);
            Total = Convert.ToInt32(Database.GetParameterValue(command, "Total"));
            return Total;
        }
		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormFieldValue using Stored Procedure
		/// and return the auto number primary key of FormFieldValue inserted row
		/// </summary>
		public bool InsertNewFormFieldValue( ref int formFieldValueId,  int formFieldId,  string fieldValue,  string fieldValueHelp,  int fieldGrade,  bool isOther,  decimal scaleStart,  decimal scaleEnd)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormFieldValue");
				Database.AddOutParameter(command,"FormFieldValueId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"FormFieldId",DbType.Int32,formFieldId);
				Database.AddInParameter(command,"FieldValue",DbType.String,fieldValue);
				Database.AddInParameter(command,"FieldValueHelp",DbType.String,fieldValueHelp);
				Database.AddInParameter(command,"FieldGrade",DbType.Int32,fieldGrade);
				Database.AddInParameter(command,"IsOther",DbType.Boolean,isOther);
				Database.AddInParameter(command,"ScaleStart",DbType.Decimal,scaleStart);
				Database.AddInParameter(command,"ScaleEnd",DbType.Decimal,scaleEnd);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 formFieldValueId = Convert.ToInt32(Database.GetParameterValue(command, "FormFieldValueId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormFieldValue using Stored Procedure
		/// and return the auto number primary key of FormFieldValue inserted row using Transaction
		/// </summary>
		public bool InsertNewFormFieldValue( ref int formFieldValueId,  int formFieldId,  string fieldValue,  string fieldValueHelp,  int fieldGrade,  bool isOther,  decimal scaleStart,  decimal scaleEnd,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormFieldValue");
				Database.AddOutParameter(command,"FormFieldValueId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"FormFieldId",DbType.Int32,formFieldId);
				Database.AddInParameter(command,"FieldValue",DbType.String,fieldValue);
				Database.AddInParameter(command,"FieldValueHelp",DbType.String,fieldValueHelp);
				Database.AddInParameter(command,"FieldGrade",DbType.Int32,fieldGrade);
				Database.AddInParameter(command,"IsOther",DbType.Boolean,isOther);
				Database.AddInParameter(command,"ScaleStart",DbType.Decimal,scaleStart);
				Database.AddInParameter(command,"ScaleEnd",DbType.Decimal,scaleEnd);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 formFieldValueId = Convert.ToInt32(Database.GetParameterValue(command, "FormFieldValueId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for FormFieldValue using Stored Procedure
		/// and return DbCommand of the FormFieldValue
		/// </summary>
		public DbCommand InsertNewFormFieldValueCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormFieldValue");

				Database.AddInParameter(command,"FormFieldId",DbType.Int32,"FormFieldId",DataRowVersion.Current);
				Database.AddInParameter(command,"FieldValue",DbType.String,"FieldValue",DataRowVersion.Current);
				Database.AddInParameter(command,"FieldValueHelp",DbType.String,"FieldValueHelp",DataRowVersion.Current);
				Database.AddInParameter(command,"FieldGrade",DbType.Int32,"FieldGrade",DataRowVersion.Current);
				Database.AddInParameter(command,"IsOther",DbType.Boolean,"IsOther",DataRowVersion.Current);
				Database.AddInParameter(command,"ScaleStart",DbType.Decimal,"ScaleStart",DataRowVersion.Current);
				Database.AddInParameter(command,"ScaleEnd",DbType.Decimal,"ScaleEnd",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormFieldValue using Stored Procedure
		/// </summary>
		public bool UpdateFormFieldValue( int formFieldId, string fieldValue, string fieldValueHelp, int fieldGrade, bool isOther, decimal scaleStart, decimal scaleEnd, int oldformFieldValueId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormFieldValue");

		    		Database.AddInParameter(command,"FormFieldId",DbType.Int32,formFieldId);
		    		Database.AddInParameter(command,"FieldValue",DbType.String,fieldValue);
		    		Database.AddInParameter(command,"FieldValueHelp",DbType.String,fieldValueHelp);
		    		Database.AddInParameter(command,"FieldGrade",DbType.Int32,fieldGrade);
		    		Database.AddInParameter(command,"IsOther",DbType.Boolean,isOther);
		    		Database.AddInParameter(command,"ScaleStart",DbType.Decimal,scaleStart);
		    		Database.AddInParameter(command,"ScaleEnd",DbType.Decimal,scaleEnd);
				Database.AddInParameter(command,"oldFormFieldValueId",DbType.Int32,oldformFieldValueId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormFieldValue using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateFormFieldValue( int formFieldId, string fieldValue, string fieldValueHelp, int fieldGrade, bool isOther, decimal scaleStart, decimal scaleEnd, int oldformFieldValueId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormFieldValue");

		    		Database.AddInParameter(command,"FormFieldId",DbType.Int32,formFieldId);
		    		Database.AddInParameter(command,"FieldValue",DbType.String,fieldValue);
		    		Database.AddInParameter(command,"FieldValueHelp",DbType.String,fieldValueHelp);
		    		Database.AddInParameter(command,"FieldGrade",DbType.Int32,fieldGrade);
		    		Database.AddInParameter(command,"IsOther",DbType.Boolean,isOther);
		    		Database.AddInParameter(command,"ScaleStart",DbType.Decimal,scaleStart);
		    		Database.AddInParameter(command,"ScaleEnd",DbType.Decimal,scaleEnd);
				Database.AddInParameter(command,"oldFormFieldValueId",DbType.Int32,oldformFieldValueId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from FormFieldValue using Stored Procedure
		/// </summary>
		public DbCommand UpdateFormFieldValueCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormFieldValue");

		    		Database.AddInParameter(command,"FormFieldId",DbType.Int32,"FormFieldId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FieldValue",DbType.String,"FieldValue",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FieldValueHelp",DbType.String,"FieldValueHelp",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FieldGrade",DbType.Int32,"FieldGrade",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsOther",DbType.Boolean,"IsOther",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ScaleStart",DbType.Decimal,"ScaleStart",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ScaleEnd",DbType.Decimal,"ScaleEnd",DataRowVersion.Current);
				Database.AddInParameter(command,"oldFormFieldValueId",DbType.Int32,"FormFieldValueId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From FormFieldValue using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteFormFieldValue( int formFieldValueId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteFormFieldValue");
			Database.AddInParameter(command,"FormFieldValueId",DbType.Int32,formFieldValueId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From FormFieldValue Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteFormFieldValueCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteFormFieldValue");
				Database.AddInParameter(command,"FormFieldValueId",DbType.Int32,"FormFieldValueId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormFieldValue using Stored Procedure
		/// and return number of rows effected of the FormFieldValue
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormFieldValue",InsertNewFormFieldValueCommand(),UpdateFormFieldValueCommand(),DeleteFormFieldValueCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormFieldValue using Stored Procedure
		/// and return number of rows effected of the FormFieldValue
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormFieldValue",InsertNewFormFieldValueCommand(),UpdateFormFieldValueCommand(),DeleteFormFieldValueCommand(), transaction);
          return rowsAffected;
		}


	}
}
