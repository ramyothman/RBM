using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.HumanResources
{
	/// <summary>
	/// This is a Data Access Class  for OrganizationLanguages table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the OrganizationLanguages table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class OrganizationLanguagesDAC : DataAccessComponent
	{
		#region Constructors
        public OrganizationLanguagesDAC() : base("", "HumanResources.OrganizationLanguages") { }
		public OrganizationLanguagesDAC(string connectionString): base(connectionString){}
		public OrganizationLanguagesDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all OrganizationLanguages using Stored Procedure
		/// and return a DataTable containing all OrganizationLanguages Data
		/// </summary>
		public DataTable GetAllOrganizationLanguages()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "OrganizationLanguages";
         string query = " select * from GetAllOrganizationLanguages";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["OrganizationLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all OrganizationLanguages using Stored Procedure
		/// and return a DataTable containing all OrganizationLanguages Data using a Transaction
		/// </summary>
		public DataTable GetAllOrganizationLanguages(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "OrganizationLanguages";
         string query = " select * from GetAllOrganizationLanguages";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["OrganizationLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all OrganizationLanguages using Stored Procedure
		/// and return a DataTable containing all OrganizationLanguages Data
		/// </summary>
		public DataTable GetAllOrganizationLanguages(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "OrganizationLanguages";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllOrganizationLanguages" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["OrganizationLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all OrganizationLanguages using Stored Procedure
		/// and return a DataTable containing all OrganizationLanguages Data using a Transaction
		/// </summary>
		public DataTable GetAllOrganizationLanguages(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "OrganizationLanguages";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllOrganizationLanguages" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["OrganizationLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From OrganizationLanguages using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDOrganizationLanguages( int organizationLanguagesId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDOrganizationLanguages");
				    Database.AddInParameter(command,"OrganizationLanguagesId",DbType.Int32,organizationLanguagesId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From OrganizationLanguages using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDOrganizationLanguages( int organizationLanguagesId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDOrganizationLanguages");
				    Database.AddInParameter(command,"OrganizationLanguagesId",DbType.Int32,organizationLanguagesId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into OrganizationLanguages using Stored Procedure
		/// and return the auto number primary key of OrganizationLanguages inserted row
		/// </summary>
		public bool InsertNewOrganizationLanguages( ref int organizationLanguagesId,  int organizationId,  int languageId,  string organizationName,  string organizationDescription,  string addressLine1,  string addressLine2)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewOrganizationLanguages");
				Database.AddOutParameter(command,"OrganizationLanguagesId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"OrganizationId",DbType.Int32,organizationId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"OrganizationName",DbType.String,organizationName);
				Database.AddInParameter(command,"OrganizationDescription",DbType.String,organizationDescription);
				Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
				Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 organizationLanguagesId = Convert.ToInt32(Database.GetParameterValue(command, "OrganizationLanguagesId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into OrganizationLanguages using Stored Procedure
		/// and return the auto number primary key of OrganizationLanguages inserted row using Transaction
		/// </summary>
		public bool InsertNewOrganizationLanguages( ref int organizationLanguagesId,  int organizationId,  int languageId,  string organizationName,  string organizationDescription,  string addressLine1,  string addressLine2,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewOrganizationLanguages");
				Database.AddOutParameter(command,"OrganizationLanguagesId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"OrganizationId",DbType.Int32,organizationId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"OrganizationName",DbType.String,organizationName);
				Database.AddInParameter(command,"OrganizationDescription",DbType.String,organizationDescription);
				Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
				Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 organizationLanguagesId = Convert.ToInt32(Database.GetParameterValue(command, "OrganizationLanguagesId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for OrganizationLanguages using Stored Procedure
		/// and return DbCommand of the OrganizationLanguages
		/// </summary>
		public DbCommand InsertNewOrganizationLanguagesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewOrganizationLanguages");

				Database.AddInParameter(command,"OrganizationId",DbType.Int32,"OrganizationId",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
				Database.AddInParameter(command,"OrganizationName",DbType.String,"OrganizationName",DataRowVersion.Current);
				Database.AddInParameter(command,"OrganizationDescription",DbType.String,"OrganizationDescription",DataRowVersion.Current);
				Database.AddInParameter(command,"AddressLine1",DbType.String,"AddressLine1",DataRowVersion.Current);
				Database.AddInParameter(command,"AddressLine2",DbType.String,"AddressLine2",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into OrganizationLanguages using Stored Procedure
		/// </summary>
		public bool UpdateOrganizationLanguages( int organizationId, int languageId, string organizationName, string organizationDescription, string addressLine1, string addressLine2, int oldorganizationLanguagesId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateOrganizationLanguages");

		    		Database.AddInParameter(command,"OrganizationId",DbType.Int32,organizationId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"OrganizationName",DbType.String,organizationName);
		    		Database.AddInParameter(command,"OrganizationDescription",DbType.String,organizationDescription);
		    		Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
		    		Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
				Database.AddInParameter(command,"oldOrganizationLanguagesId",DbType.Int32,oldorganizationLanguagesId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into OrganizationLanguages using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateOrganizationLanguages( int organizationId, int languageId, string organizationName, string organizationDescription, string addressLine1, string addressLine2, int oldorganizationLanguagesId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateOrganizationLanguages");

		    		Database.AddInParameter(command,"OrganizationId",DbType.Int32,organizationId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"OrganizationName",DbType.String,organizationName);
		    		Database.AddInParameter(command,"OrganizationDescription",DbType.String,organizationDescription);
		    		Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
		    		Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
				Database.AddInParameter(command,"oldOrganizationLanguagesId",DbType.Int32,oldorganizationLanguagesId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from OrganizationLanguages using Stored Procedure
		/// </summary>
		public DbCommand UpdateOrganizationLanguagesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateOrganizationLanguages");

		    		Database.AddInParameter(command,"OrganizationId",DbType.Int32,"OrganizationId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"OrganizationName",DbType.String,"OrganizationName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"OrganizationDescription",DbType.String,"OrganizationDescription",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AddressLine1",DbType.String,"AddressLine1",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AddressLine2",DbType.String,"AddressLine2",DataRowVersion.Current);
				Database.AddInParameter(command,"oldOrganizationLanguagesId",DbType.Int32,"OrganizationLanguagesId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From OrganizationLanguages using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteOrganizationLanguages( int organizationLanguagesId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteOrganizationLanguages");
			Database.AddInParameter(command,"OrganizationLanguagesId",DbType.Int32,organizationLanguagesId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From OrganizationLanguages Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteOrganizationLanguagesCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteOrganizationLanguages");
				Database.AddInParameter(command,"OrganizationLanguagesId",DbType.Int32,"OrganizationLanguagesId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table OrganizationLanguages using Stored Procedure
		/// and return number of rows effected of the OrganizationLanguages
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"OrganizationLanguages",InsertNewOrganizationLanguagesCommand(),UpdateOrganizationLanguagesCommand(),DeleteOrganizationLanguagesCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table OrganizationLanguages using Stored Procedure
		/// and return number of rows effected of the OrganizationLanguages
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"OrganizationLanguages",InsertNewOrganizationLanguagesCommand(),UpdateOrganizationLanguagesCommand(),DeleteOrganizationLanguagesCommand(), transaction);
          return rowsAffected;
		}


	}
}
