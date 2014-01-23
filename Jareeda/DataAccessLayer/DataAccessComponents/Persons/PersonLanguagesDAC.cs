using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for PersonLanguages table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the PersonLanguages table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PersonLanguagesDAC : DataAccessComponent
	{
		#region Constructors
        public PersonLanguagesDAC() : base("", "Person.PersonLanguages") { }
		public PersonLanguagesDAC(string connectionString): base(connectionString){}
		public PersonLanguagesDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonLanguages using Stored Procedure
		/// and return a DataTable containing all PersonLanguages Data
		/// </summary>
		public DataTable GetAllPersonLanguages()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonLanguages";
         string query = " select * from GetAllPersonLanguages";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonLanguages using Stored Procedure
		/// and return a DataTable containing all PersonLanguages Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonLanguages(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonLanguages";
         string query = " select * from GetAllPersonLanguages";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonLanguages using Stored Procedure
		/// and return a DataTable containing all PersonLanguages Data
		/// </summary>
		public DataTable GetAllPersonLanguages(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonLanguages";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPersonLanguages" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonLanguages using Stored Procedure
		/// and return a DataTable containing all PersonLanguages Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonLanguages(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonLanguages";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPersonLanguages" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonLanguages"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonLanguages using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonLanguages( int personLanguageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonLanguages");
				    Database.AddInParameter(command,"PersonLanguageId",DbType.Int32,personLanguageId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonLanguages using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonLanguages( int personLanguageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonLanguages");
				    Database.AddInParameter(command,"PersonLanguageId",DbType.Int32,personLanguageId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonLanguages using Stored Procedure
		/// and return the auto number primary key of PersonLanguages inserted row
		/// </summary>
		public bool InsertNewPersonLanguages( ref int personLanguageId,  int personId,  int languageId,  string title,  string firstName,  string middleName,  string lastName,  string suffix,  string displayName)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonLanguages");
				Database.AddOutParameter(command,"PersonLanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"FirstName",DbType.String,firstName);
				Database.AddInParameter(command,"MiddleName",DbType.String,middleName);
				Database.AddInParameter(command,"LastName",DbType.String,lastName);
				Database.AddInParameter(command,"Suffix",DbType.String,suffix);
				Database.AddInParameter(command,"DisplayName",DbType.String,displayName);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 personLanguageId = Convert.ToInt32(Database.GetParameterValue(command, "PersonLanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonLanguages using Stored Procedure
		/// and return the auto number primary key of PersonLanguages inserted row using Transaction
		/// </summary>
		public bool InsertNewPersonLanguages( ref int personLanguageId,  int personId,  int languageId,  string title,  string firstName,  string middleName,  string lastName,  string suffix,  string displayName,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonLanguages");
				Database.AddOutParameter(command,"PersonLanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"FirstName",DbType.String,firstName);
				Database.AddInParameter(command,"MiddleName",DbType.String,middleName);
				Database.AddInParameter(command,"LastName",DbType.String,lastName);
				Database.AddInParameter(command,"Suffix",DbType.String,suffix);
				Database.AddInParameter(command,"DisplayName",DbType.String,displayName);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 personLanguageId = Convert.ToInt32(Database.GetParameterValue(command, "PersonLanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for PersonLanguages using Stored Procedure
		/// and return DbCommand of the PersonLanguages
		/// </summary>
		public DbCommand InsertNewPersonLanguagesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonLanguages");

				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
				Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
				Database.AddInParameter(command,"FirstName",DbType.String,"FirstName",DataRowVersion.Current);
				Database.AddInParameter(command,"MiddleName",DbType.String,"MiddleName",DataRowVersion.Current);
				Database.AddInParameter(command,"LastName",DbType.String,"LastName",DataRowVersion.Current);
				Database.AddInParameter(command,"Suffix",DbType.String,"Suffix",DataRowVersion.Current);
				Database.AddInParameter(command,"DisplayName",DbType.String,"DisplayName",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonLanguages using Stored Procedure
		/// </summary>
		public bool UpdatePersonLanguages( int personId, int languageId, string title, string firstName, string middleName, string lastName, string suffix, string displayName, int oldpersonLanguageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonLanguages");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"FirstName",DbType.String,firstName);
		    		Database.AddInParameter(command,"MiddleName",DbType.String,middleName);
		    		Database.AddInParameter(command,"LastName",DbType.String,lastName);
		    		Database.AddInParameter(command,"Suffix",DbType.String,suffix);
		    		Database.AddInParameter(command,"DisplayName",DbType.String,displayName);
				Database.AddInParameter(command,"oldPersonLanguageId",DbType.Int32,oldpersonLanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonLanguages using Stored Procedure By Transaction
		/// </summary>
		public bool UpdatePersonLanguages( int personId, int languageId, string title, string firstName, string middleName, string lastName, string suffix, string displayName, int oldpersonLanguageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonLanguages");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"FirstName",DbType.String,firstName);
		    		Database.AddInParameter(command,"MiddleName",DbType.String,middleName);
		    		Database.AddInParameter(command,"LastName",DbType.String,lastName);
		    		Database.AddInParameter(command,"Suffix",DbType.String,suffix);
		    		Database.AddInParameter(command,"DisplayName",DbType.String,displayName);
				Database.AddInParameter(command,"oldPersonLanguageId",DbType.Int32,oldpersonLanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from PersonLanguages using Stored Procedure
		/// </summary>
		public DbCommand UpdatePersonLanguagesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonLanguages");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FirstName",DbType.String,"FirstName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"MiddleName",DbType.String,"MiddleName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LastName",DbType.String,"LastName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Suffix",DbType.String,"Suffix",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DisplayName",DbType.String,"DisplayName",DataRowVersion.Current);
				Database.AddInParameter(command,"oldPersonLanguageId",DbType.Int32,"PersonLanguageId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From PersonLanguages using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePersonLanguages( int personLanguageId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePersonLanguages");
			Database.AddInParameter(command,"PersonLanguageId",DbType.Int32,personLanguageId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From PersonLanguages Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePersonLanguagesCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePersonLanguages");
				Database.AddInParameter(command,"PersonLanguageId",DbType.Int32,"PersonLanguageId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonLanguages using Stored Procedure
		/// and return number of rows effected of the PersonLanguages
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonLanguages",InsertNewPersonLanguagesCommand(),UpdatePersonLanguagesCommand(),DeletePersonLanguagesCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonLanguages using Stored Procedure
		/// and return number of rows effected of the PersonLanguages
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonLanguages",InsertNewPersonLanguagesCommand(),UpdatePersonLanguagesCommand(),DeletePersonLanguagesCommand(), transaction);
          return rowsAffected;
		}


	}
}
