using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.FormBuilder
{
	/// <summary>
	/// This is a Data Access Class  for FormField table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the FormField table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class FormFieldDAC : DataAccessComponent
	{
		#region Constructors
        public FormFieldDAC() : base("", "FormBuilder.FormField") { }
		public FormFieldDAC(string connectionString): base(connectionString){}
		public FormFieldDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormField using Stored Procedure
		/// and return a DataTable containing all FormField Data
		/// </summary>
		public DataTable GetAllFormField()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormField";
         string query = " select * from GetAllFormField";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormField"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormField using Stored Procedure
		/// and return a DataTable containing all FormField Data using a Transaction
		/// </summary>
		public DataTable GetAllFormField(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormField";
         string query = " select * from GetAllFormField";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormField"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormField using Stored Procedure
		/// and return a DataTable containing all FormField Data
		/// </summary>
		public DataTable GetAllFormField(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormField";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllFormField" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["FormField"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all FormField using Stored Procedure
		/// and return a DataTable containing all FormField Data using a Transaction
		/// </summary>
		public DataTable GetAllFormField(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "FormField";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllFormField" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["FormField"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormField using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormField( int formFieldId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormField");
				    Database.AddInParameter(command,"FormFieldId",DbType.Int32,formFieldId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From FormField using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDFormField( int formFieldId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDFormField");
				    Database.AddInParameter(command,"FormFieldId",DbType.Int32,formFieldId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormField using Stored Procedure
		/// and return the auto number primary key of FormField inserted row
		/// </summary>
		public bool InsertNewFormField( ref int formFieldId,  int formDocumentId,  int formFieldTypeId,  int fieldParentId,  string title,  string helpText,  int formFieldOrder,  int fieldDegree,  bool hasOther,  string defaultValue,  bool isRequired,  string regularExpValidation,  string errorText,  bool isContactEmail,  bool isContactMobile,  int columnCount,  bool isSection,  bool isPageBreak)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormField");
				Database.AddOutParameter(command,"FormFieldId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"FormDocumentId",DbType.Int32,formDocumentId);
				Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,formFieldTypeId);
                if(fieldParentId == 0)                
				    Database.AddInParameter(command,"FieldParentId",DbType.Int32,DBNull.Value);
                else
                    Database.AddInParameter(command, "FieldParentId", DbType.Int32, fieldParentId);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"HelpText",DbType.String,helpText);
				Database.AddInParameter(command,"FormFieldOrder",DbType.Int32,formFieldOrder);
				Database.AddInParameter(command,"FieldDegree",DbType.Int32,fieldDegree);
				Database.AddInParameter(command,"HasOther",DbType.Boolean,hasOther);
				Database.AddInParameter(command,"DefaultValue",DbType.String,defaultValue);
				Database.AddInParameter(command,"IsRequired",DbType.Boolean,isRequired);
				Database.AddInParameter(command,"RegularExpValidation",DbType.String,regularExpValidation);
				Database.AddInParameter(command,"ErrorText",DbType.String,errorText);
				Database.AddInParameter(command,"IsContactEmail",DbType.Boolean,isContactEmail);
				Database.AddInParameter(command,"IsContactMobile",DbType.Boolean,isContactMobile);
				Database.AddInParameter(command,"ColumnCount",DbType.Int32,columnCount);
				Database.AddInParameter(command,"IsSection",DbType.Boolean,isSection);
				Database.AddInParameter(command,"IsPageBreak",DbType.Boolean,isPageBreak);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 formFieldId = Convert.ToInt32(Database.GetParameterValue(command, "FormFieldId"));
				}
				return _status;
		}


        public int GetFieldTotalSubmissions( int formFieldId)
        {
            int Total = 0;
            DbCommand command = Database.GetStoredProcCommand("GetFieldTotalSubmissions");
            Database.AddOutParameter(command, "Total", DbType.Int32, 0);
            Database.AddInParameter(command, "FormFieldId", DbType.Int32, formFieldId);



            Database.ExecuteNonQuery(command);
            Total = Convert.ToInt32(Database.GetParameterValue(command, "Total"));
            return Total;
        }

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into FormField using Stored Procedure
		/// and return the auto number primary key of FormField inserted row using Transaction
		/// </summary>
		public bool InsertNewFormField( ref int formFieldId,  int formDocumentId,  int formFieldTypeId,  int fieldParentId,  string title,  string helpText,  int formFieldOrder,  int fieldDegree,  bool hasOther,  string defaultValue,  bool isRequired,  string regularExpValidation,  string errorText,  bool isContactEmail,  bool isContactMobile,  int columnCount,  bool isSection,  bool isPageBreak,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormField");
				Database.AddOutParameter(command,"FormFieldId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"FormDocumentId",DbType.Int32,formDocumentId);
				Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,formFieldTypeId);
                if (fieldParentId == 0)
                    Database.AddInParameter(command, "FieldParentId", DbType.Int32, DBNull.Value);
                else
                    Database.AddInParameter(command, "FieldParentId", DbType.Int32, fieldParentId);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"HelpText",DbType.String,helpText);
				Database.AddInParameter(command,"FormFieldOrder",DbType.Int32,formFieldOrder);
				Database.AddInParameter(command,"FieldDegree",DbType.Int32,fieldDegree);
				Database.AddInParameter(command,"HasOther",DbType.Boolean,hasOther);
				Database.AddInParameter(command,"DefaultValue",DbType.String,defaultValue);
				Database.AddInParameter(command,"IsRequired",DbType.Boolean,isRequired);
				Database.AddInParameter(command,"RegularExpValidation",DbType.String,regularExpValidation);
				Database.AddInParameter(command,"ErrorText",DbType.String,errorText);
				Database.AddInParameter(command,"IsContactEmail",DbType.Boolean,isContactEmail);
				Database.AddInParameter(command,"IsContactMobile",DbType.Boolean,isContactMobile);
				Database.AddInParameter(command,"ColumnCount",DbType.Int32,columnCount);
				Database.AddInParameter(command,"IsSection",DbType.Boolean,isSection);
				Database.AddInParameter(command,"IsPageBreak",DbType.Boolean,isPageBreak);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 formFieldId = Convert.ToInt32(Database.GetParameterValue(command, "FormFieldId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for FormField using Stored Procedure
		/// and return DbCommand of the FormField
		/// </summary>
		public DbCommand InsertNewFormFieldCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewFormField");

				Database.AddInParameter(command,"FormDocumentId",DbType.Int32,"FormDocumentId",DataRowVersion.Current);
				Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,"FormFieldTypeId",DataRowVersion.Current);
				Database.AddInParameter(command,"FieldParentId",DbType.Int32,"FieldParentId",DataRowVersion.Current);
				Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
				Database.AddInParameter(command,"HelpText",DbType.String,"HelpText",DataRowVersion.Current);
				Database.AddInParameter(command,"FormFieldOrder",DbType.Int32,"FormFieldOrder",DataRowVersion.Current);
				Database.AddInParameter(command,"FieldDegree",DbType.Int32,"FieldDegree",DataRowVersion.Current);
				Database.AddInParameter(command,"HasOther",DbType.Boolean,"HasOther",DataRowVersion.Current);
				Database.AddInParameter(command,"DefaultValue",DbType.String,"DefaultValue",DataRowVersion.Current);
				Database.AddInParameter(command,"IsRequired",DbType.Boolean,"IsRequired",DataRowVersion.Current);
				Database.AddInParameter(command,"RegularExpValidation",DbType.String,"RegularExpValidation",DataRowVersion.Current);
				Database.AddInParameter(command,"ErrorText",DbType.String,"ErrorText",DataRowVersion.Current);
				Database.AddInParameter(command,"IsContactEmail",DbType.Boolean,"IsContactEmail",DataRowVersion.Current);
				Database.AddInParameter(command,"IsContactMobile",DbType.Boolean,"IsContactMobile",DataRowVersion.Current);
				Database.AddInParameter(command,"ColumnCount",DbType.Int32,"ColumnCount",DataRowVersion.Current);
				Database.AddInParameter(command,"IsSection",DbType.Boolean,"IsSection",DataRowVersion.Current);
				Database.AddInParameter(command,"IsPageBreak",DbType.Boolean,"IsPageBreak",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormField using Stored Procedure
		/// </summary>
		public bool UpdateFormField( int formDocumentId, int formFieldTypeId, int fieldParentId, string title, string helpText, int formFieldOrder, int fieldDegree, bool hasOther, string defaultValue, bool isRequired, string regularExpValidation, string errorText, bool isContactEmail, bool isContactMobile, int columnCount, bool isSection, bool isPageBreak, int oldformFieldId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormField");

		    		Database.AddInParameter(command,"FormDocumentId",DbType.Int32,formDocumentId);
		    		Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,formFieldTypeId);
                    if (fieldParentId == 0)
                        Database.AddInParameter(command, "FieldParentId", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "FieldParentId", DbType.Int32, fieldParentId);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"HelpText",DbType.String,helpText);
		    		Database.AddInParameter(command,"FormFieldOrder",DbType.Int32,formFieldOrder);
		    		Database.AddInParameter(command,"FieldDegree",DbType.Int32,fieldDegree);
		    		Database.AddInParameter(command,"HasOther",DbType.Boolean,hasOther);
		    		Database.AddInParameter(command,"DefaultValue",DbType.String,defaultValue);
		    		Database.AddInParameter(command,"IsRequired",DbType.Boolean,isRequired);
		    		Database.AddInParameter(command,"RegularExpValidation",DbType.String,regularExpValidation);
		    		Database.AddInParameter(command,"ErrorText",DbType.String,errorText);
		    		Database.AddInParameter(command,"IsContactEmail",DbType.Boolean,isContactEmail);
		    		Database.AddInParameter(command,"IsContactMobile",DbType.Boolean,isContactMobile);
		    		Database.AddInParameter(command,"ColumnCount",DbType.Int32,columnCount);
		    		Database.AddInParameter(command,"IsSection",DbType.Boolean,isSection);
		    		Database.AddInParameter(command,"IsPageBreak",DbType.Boolean,isPageBreak);
				Database.AddInParameter(command,"oldFormFieldId",DbType.Int32,oldformFieldId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into FormField using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateFormField( int formDocumentId, int formFieldTypeId, int fieldParentId, string title, string helpText, int formFieldOrder, int fieldDegree, bool hasOther, string defaultValue, bool isRequired, string regularExpValidation, string errorText, bool isContactEmail, bool isContactMobile, int columnCount, bool isSection, bool isPageBreak, int oldformFieldId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormField");

		    		Database.AddInParameter(command,"FormDocumentId",DbType.Int32,formDocumentId);
		    		Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,formFieldTypeId);
                    if (fieldParentId == 0)
                        Database.AddInParameter(command, "FieldParentId", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "FieldParentId", DbType.Int32, fieldParentId);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"HelpText",DbType.String,helpText);
		    		Database.AddInParameter(command,"FormFieldOrder",DbType.Int32,formFieldOrder);
		    		Database.AddInParameter(command,"FieldDegree",DbType.Int32,fieldDegree);
		    		Database.AddInParameter(command,"HasOther",DbType.Boolean,hasOther);
		    		Database.AddInParameter(command,"DefaultValue",DbType.String,defaultValue);
		    		Database.AddInParameter(command,"IsRequired",DbType.Boolean,isRequired);
		    		Database.AddInParameter(command,"RegularExpValidation",DbType.String,regularExpValidation);
		    		Database.AddInParameter(command,"ErrorText",DbType.String,errorText);
		    		Database.AddInParameter(command,"IsContactEmail",DbType.Boolean,isContactEmail);
		    		Database.AddInParameter(command,"IsContactMobile",DbType.Boolean,isContactMobile);
		    		Database.AddInParameter(command,"ColumnCount",DbType.Int32,columnCount);
		    		Database.AddInParameter(command,"IsSection",DbType.Boolean,isSection);
		    		Database.AddInParameter(command,"IsPageBreak",DbType.Boolean,isPageBreak);
				Database.AddInParameter(command,"oldFormFieldId",DbType.Int32,oldformFieldId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from FormField using Stored Procedure
		/// </summary>
		public DbCommand UpdateFormFieldCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateFormField");

		    		Database.AddInParameter(command,"FormDocumentId",DbType.Int32,"FormDocumentId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FormFieldTypeId",DbType.Int32,"FormFieldTypeId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FieldParentId",DbType.Int32,"FieldParentId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
		    		Database.AddInParameter(command,"HelpText",DbType.String,"HelpText",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FormFieldOrder",DbType.Int32,"FormFieldOrder",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FieldDegree",DbType.Int32,"FieldDegree",DataRowVersion.Current);
		    		Database.AddInParameter(command,"HasOther",DbType.Boolean,"HasOther",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DefaultValue",DbType.String,"DefaultValue",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsRequired",DbType.Boolean,"IsRequired",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RegularExpValidation",DbType.String,"RegularExpValidation",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ErrorText",DbType.String,"ErrorText",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsContactEmail",DbType.Boolean,"IsContactEmail",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsContactMobile",DbType.Boolean,"IsContactMobile",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ColumnCount",DbType.Int32,"ColumnCount",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsSection",DbType.Boolean,"IsSection",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsPageBreak",DbType.Boolean,"IsPageBreak",DataRowVersion.Current);
				Database.AddInParameter(command,"oldFormFieldId",DbType.Int32,"FormFieldId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From FormField using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteFormField( int formFieldId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteFormField");
			Database.AddInParameter(command,"FormFieldId",DbType.Int32,formFieldId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From FormField Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteFormFieldCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteFormField");
				Database.AddInParameter(command,"FormFieldId",DbType.Int32,"FormFieldId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormField using Stored Procedure
		/// and return number of rows effected of the FormField
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormField",InsertNewFormFieldCommand(),UpdateFormFieldCommand(),DeleteFormFieldCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table FormField using Stored Procedure
		/// and return number of rows effected of the FormField
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"FormField",InsertNewFormFieldCommand(),UpdateFormFieldCommand(),DeleteFormFieldCommand(), transaction);
          return rowsAffected;
		}


	}
}
