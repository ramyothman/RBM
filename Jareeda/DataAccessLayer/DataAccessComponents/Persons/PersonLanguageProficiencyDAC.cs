using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for PersonLanguageProficiency table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the PersonLanguageProficiency table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PersonLanguageProficiencyDAC : DataAccessComponent
	{
		#region Constructors
        public PersonLanguageProficiencyDAC() : base("", "Person.PersonLanguageProficiency") { }
		public PersonLanguageProficiencyDAC(string connectionString): base(connectionString){}
		public PersonLanguageProficiencyDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonLanguageProficiency using Stored Procedure
		/// and return a DataTable containing all PersonLanguageProficiency Data
		/// </summary>
		public DataTable GetAllPersonLanguageProficiency()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonLanguageProficiency";
         string query = " select * from GetAllPersonLanguageProficiency";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonLanguageProficiency"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonLanguageProficiency using Stored Procedure
		/// and return a DataTable containing all PersonLanguageProficiency Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonLanguageProficiency(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonLanguageProficiency";
         string query = " select * from GetAllPersonLanguageProficiency";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonLanguageProficiency"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonLanguageProficiency using Stored Procedure
		/// and return a DataTable containing all PersonLanguageProficiency Data
		/// </summary>
		public DataTable GetAllPersonLanguageProficiency(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonLanguageProficiency";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPersonLanguageProficiency" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonLanguageProficiency"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonLanguageProficiency using Stored Procedure
		/// and return a DataTable containing all PersonLanguageProficiency Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonLanguageProficiency(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonLanguageProficiency";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPersonLanguageProficiency" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonLanguageProficiency"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonLanguageProficiency using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonLanguageProficiency( int personLanguageProficiencyId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonLanguageProficiency");
				    Database.AddInParameter(command,"PersonLanguageProficiencyId",DbType.Int32,personLanguageProficiencyId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonLanguageProficiency using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonLanguageProficiency( int personLanguageProficiencyId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonLanguageProficiency");
				    Database.AddInParameter(command,"PersonLanguageProficiencyId",DbType.Int32,personLanguageProficiencyId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonLanguageProficiency using Stored Procedure
		/// and return the auto number primary key of PersonLanguageProficiency inserted row
		/// </summary>
		public bool InsertNewPersonLanguageProficiency( ref int personLanguageProficiencyId,  int personId,  int languageId,  bool canRead,  bool canWrite,  bool canSpeak)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonLanguageProficiency");
				Database.AddOutParameter(command,"PersonLanguageProficiencyId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"CanRead",DbType.Boolean,canRead);
				Database.AddInParameter(command,"CanWrite",DbType.Boolean,canWrite);
				Database.AddInParameter(command,"CanSpeak",DbType.Boolean,canSpeak);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 personLanguageProficiencyId = Convert.ToInt32(Database.GetParameterValue(command, "PersonLanguageProficiencyId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonLanguageProficiency using Stored Procedure
		/// and return the auto number primary key of PersonLanguageProficiency inserted row using Transaction
		/// </summary>
		public bool InsertNewPersonLanguageProficiency( ref int personLanguageProficiencyId,  int personId,  int languageId,  bool canRead,  bool canWrite,  bool canSpeak,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonLanguageProficiency");
				Database.AddOutParameter(command,"PersonLanguageProficiencyId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
				Database.AddInParameter(command,"CanRead",DbType.Boolean,canRead);
				Database.AddInParameter(command,"CanWrite",DbType.Boolean,canWrite);
				Database.AddInParameter(command,"CanSpeak",DbType.Boolean,canSpeak);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 personLanguageProficiencyId = Convert.ToInt32(Database.GetParameterValue(command, "PersonLanguageProficiencyId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for PersonLanguageProficiency using Stored Procedure
		/// and return DbCommand of the PersonLanguageProficiency
		/// </summary>
		public DbCommand InsertNewPersonLanguageProficiencyCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonLanguageProficiency");

				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
				Database.AddInParameter(command,"CanRead",DbType.Boolean,"CanRead",DataRowVersion.Current);
				Database.AddInParameter(command,"CanWrite",DbType.Boolean,"CanWrite",DataRowVersion.Current);
				Database.AddInParameter(command,"CanSpeak",DbType.Boolean,"CanSpeak",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonLanguageProficiency using Stored Procedure
		/// </summary>
		public bool UpdatePersonLanguageProficiency( int personId, int languageId, bool canRead, bool canWrite, bool canSpeak, int oldpersonLanguageProficiencyId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonLanguageProficiency");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"CanRead",DbType.Boolean,canRead);
		    		Database.AddInParameter(command,"CanWrite",DbType.Boolean,canWrite);
		    		Database.AddInParameter(command,"CanSpeak",DbType.Boolean,canSpeak);
				Database.AddInParameter(command,"oldPersonLanguageProficiencyId",DbType.Int32,oldpersonLanguageProficiencyId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonLanguageProficiency using Stored Procedure By Transaction
		/// </summary>
		public bool UpdatePersonLanguageProficiency( int personId, int languageId, bool canRead, bool canWrite, bool canSpeak, int oldpersonLanguageProficiencyId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonLanguageProficiency");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,languageId);
		    		Database.AddInParameter(command,"CanRead",DbType.Boolean,canRead);
		    		Database.AddInParameter(command,"CanWrite",DbType.Boolean,canWrite);
		    		Database.AddInParameter(command,"CanSpeak",DbType.Boolean,canSpeak);
				Database.AddInParameter(command,"oldPersonLanguageProficiencyId",DbType.Int32,oldpersonLanguageProficiencyId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from PersonLanguageProficiency using Stored Procedure
		/// </summary>
		public DbCommand UpdatePersonLanguageProficiencyCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonLanguageProficiency");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageId",DbType.Int32,"LanguageId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CanRead",DbType.Boolean,"CanRead",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CanWrite",DbType.Boolean,"CanWrite",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CanSpeak",DbType.Boolean,"CanSpeak",DataRowVersion.Current);
				Database.AddInParameter(command,"oldPersonLanguageProficiencyId",DbType.Int32,"PersonLanguageProficiencyId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From PersonLanguageProficiency using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePersonLanguageProficiency( int personLanguageProficiencyId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePersonLanguageProficiency");
			Database.AddInParameter(command,"PersonLanguageProficiencyId",DbType.Int32,personLanguageProficiencyId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From PersonLanguageProficiency Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePersonLanguageProficiencyCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePersonLanguageProficiency");
				Database.AddInParameter(command,"PersonLanguageProficiencyId",DbType.Int32,"PersonLanguageProficiencyId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonLanguageProficiency using Stored Procedure
		/// and return number of rows effected of the PersonLanguageProficiency
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonLanguageProficiency",InsertNewPersonLanguageProficiencyCommand(),UpdatePersonLanguageProficiencyCommand(),DeletePersonLanguageProficiencyCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonLanguageProficiency using Stored Procedure
		/// and return number of rows effected of the PersonLanguageProficiency
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonLanguageProficiency",InsertNewPersonLanguageProficiencyCommand(),UpdatePersonLanguageProficiencyCommand(),DeletePersonLanguageProficiencyCommand(), transaction);
          return rowsAffected;
		}


	}
}
