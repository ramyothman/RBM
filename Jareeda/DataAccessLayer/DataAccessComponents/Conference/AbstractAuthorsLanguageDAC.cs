using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for AbstractAuthorsLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the AbstractAuthorsLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class AbstractAuthorsLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public AbstractAuthorsLanguageDAC() : base("", "Conference.AbstractAuthorsLanguage") { }
		public AbstractAuthorsLanguageDAC(string connectionString): base(connectionString){}
		public AbstractAuthorsLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractAuthorsLanguage using Stored Procedure
		/// and return a DataTable containing all AbstractAuthorsLanguage Data
		/// </summary>
		public DataTable GetAllAbstractAuthorsLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractAuthorsLanguage";
         string query = " select * from GetAllAbstractAuthorsLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["AbstractAuthorsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractAuthorsLanguage using Stored Procedure
		/// and return a DataTable containing all AbstractAuthorsLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstractAuthorsLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractAuthorsLanguage";
         string query = " select * from GetAllAbstractAuthorsLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["AbstractAuthorsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractAuthorsLanguage using Stored Procedure
		/// and return a DataTable containing all AbstractAuthorsLanguage Data
		/// </summary>
		public DataTable GetAllAbstractAuthorsLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractAuthorsLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllAbstractAuthorsLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["AbstractAuthorsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractAuthorsLanguage using Stored Procedure
		/// and return a DataTable containing all AbstractAuthorsLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstractAuthorsLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractAuthorsLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllAbstractAuthorsLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["AbstractAuthorsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From AbstractAuthorsLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstractAuthorsLanguage( int abstractAuthorLanguageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstractAuthorsLanguage");
				    Database.AddInParameter(command,"AbstractAuthorLanguageId",DbType.Int32,abstractAuthorLanguageId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From AbstractAuthorsLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstractAuthorsLanguage( int abstractAuthorLanguageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstractAuthorsLanguage");
				    Database.AddInParameter(command,"AbstractAuthorLanguageId",DbType.Int32,abstractAuthorLanguageId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into AbstractAuthorsLanguage using Stored Procedure
		/// and return the auto number primary key of AbstractAuthorsLanguage inserted row
		/// </summary>
		public bool InsertNewAbstractAuthorsLanguage( ref int abstractAuthorLanguageId,  int abstractAuthorId,  string firstName,  string familyName,  string title,  string degree,  string email,  string address,  string affilitationDepartment,  string affilitationInstitutionHospital,  string affilitationCity,  string affilitationCountry,  string country,  string pOBox,  string zipCode,  string city,  int languageID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractAuthorsLanguage");
				Database.AddOutParameter(command,"AbstractAuthorLanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"AbstractAuthorId",DbType.Int32,abstractAuthorId);
				Database.AddInParameter(command,"FirstName",DbType.String,firstName);
				Database.AddInParameter(command,"FamilyName",DbType.String,familyName);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"Degree",DbType.String,degree);
				Database.AddInParameter(command,"Email",DbType.String,email);
				Database.AddInParameter(command,"Address",DbType.String,address);
				Database.AddInParameter(command,"AffilitationDepartment",DbType.String,affilitationDepartment);
				Database.AddInParameter(command,"AffilitationInstitutionHospital",DbType.String,affilitationInstitutionHospital);
				Database.AddInParameter(command,"AffilitationCity",DbType.String,affilitationCity);
				Database.AddInParameter(command,"AffilitationCountry",DbType.String,affilitationCountry);
				Database.AddInParameter(command,"Country",DbType.String,country);
				Database.AddInParameter(command,"POBox",DbType.String,pOBox);
				Database.AddInParameter(command,"ZipCode",DbType.String,zipCode);
				Database.AddInParameter(command,"City",DbType.String,city);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 abstractAuthorLanguageId = Convert.ToInt32(Database.GetParameterValue(command, "AbstractAuthorLanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into AbstractAuthorsLanguage using Stored Procedure
		/// and return the auto number primary key of AbstractAuthorsLanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewAbstractAuthorsLanguage( ref int abstractAuthorLanguageId,  int abstractAuthorId,  string firstName,  string familyName,  string title,  string degree,  string email,  string address,  string affilitationDepartment,  string affilitationInstitutionHospital,  string affilitationCity,  string affilitationCountry,  string country,  string pOBox,  string zipCode,  string city,  int languageID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractAuthorsLanguage");
				Database.AddOutParameter(command,"AbstractAuthorLanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"AbstractAuthorId",DbType.Int32,abstractAuthorId);
				Database.AddInParameter(command,"FirstName",DbType.String,firstName);
				Database.AddInParameter(command,"FamilyName",DbType.String,familyName);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"Degree",DbType.String,degree);
				Database.AddInParameter(command,"Email",DbType.String,email);
				Database.AddInParameter(command,"Address",DbType.String,address);
				Database.AddInParameter(command,"AffilitationDepartment",DbType.String,affilitationDepartment);
				Database.AddInParameter(command,"AffilitationInstitutionHospital",DbType.String,affilitationInstitutionHospital);
				Database.AddInParameter(command,"AffilitationCity",DbType.String,affilitationCity);
				Database.AddInParameter(command,"AffilitationCountry",DbType.String,affilitationCountry);
				Database.AddInParameter(command,"Country",DbType.String,country);
				Database.AddInParameter(command,"POBox",DbType.String,pOBox);
				Database.AddInParameter(command,"ZipCode",DbType.String,zipCode);
				Database.AddInParameter(command,"City",DbType.String,city);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 abstractAuthorLanguageId = Convert.ToInt32(Database.GetParameterValue(command, "AbstractAuthorLanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for AbstractAuthorsLanguage using Stored Procedure
		/// and return DbCommand of the AbstractAuthorsLanguage
		/// </summary>
		public DbCommand InsertNewAbstractAuthorsLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractAuthorsLanguage");

				Database.AddInParameter(command,"AbstractAuthorId",DbType.Int32,"AbstractAuthorId",DataRowVersion.Current);
				Database.AddInParameter(command,"FirstName",DbType.String,"FirstName",DataRowVersion.Current);
				Database.AddInParameter(command,"FamilyName",DbType.String,"FamilyName",DataRowVersion.Current);
				Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
				Database.AddInParameter(command,"Degree",DbType.String,"Degree",DataRowVersion.Current);
				Database.AddInParameter(command,"Email",DbType.String,"Email",DataRowVersion.Current);
				Database.AddInParameter(command,"Address",DbType.String,"Address",DataRowVersion.Current);
				Database.AddInParameter(command,"AffilitationDepartment",DbType.String,"AffilitationDepartment",DataRowVersion.Current);
				Database.AddInParameter(command,"AffilitationInstitutionHospital",DbType.String,"AffilitationInstitutionHospital",DataRowVersion.Current);
				Database.AddInParameter(command,"AffilitationCity",DbType.String,"AffilitationCity",DataRowVersion.Current);
				Database.AddInParameter(command,"AffilitationCountry",DbType.String,"AffilitationCountry",DataRowVersion.Current);
				Database.AddInParameter(command,"Country",DbType.String,"Country",DataRowVersion.Current);
				Database.AddInParameter(command,"POBox",DbType.String,"POBox",DataRowVersion.Current);
				Database.AddInParameter(command,"ZipCode",DbType.String,"ZipCode",DataRowVersion.Current);
				Database.AddInParameter(command,"City",DbType.String,"City",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into AbstractAuthorsLanguage using Stored Procedure
		/// </summary>
		public bool UpdateAbstractAuthorsLanguage( int abstractAuthorId, string firstName, string familyName, string title, string degree, string email, string address, string affilitationDepartment, string affilitationInstitutionHospital, string affilitationCity, string affilitationCountry, string country, string pOBox, string zipCode, string city, int languageID, int oldabstractAuthorLanguageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractAuthorsLanguage");

		    		Database.AddInParameter(command,"AbstractAuthorId",DbType.Int32,abstractAuthorId);
		    		Database.AddInParameter(command,"FirstName",DbType.String,firstName);
		    		Database.AddInParameter(command,"FamilyName",DbType.String,familyName);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"Degree",DbType.String,degree);
		    		Database.AddInParameter(command,"Email",DbType.String,email);
		    		Database.AddInParameter(command,"Address",DbType.String,address);
		    		Database.AddInParameter(command,"AffilitationDepartment",DbType.String,affilitationDepartment);
		    		Database.AddInParameter(command,"AffilitationInstitutionHospital",DbType.String,affilitationInstitutionHospital);
		    		Database.AddInParameter(command,"AffilitationCity",DbType.String,affilitationCity);
		    		Database.AddInParameter(command,"AffilitationCountry",DbType.String,affilitationCountry);
		    		Database.AddInParameter(command,"Country",DbType.String,country);
		    		Database.AddInParameter(command,"POBox",DbType.String,pOBox);
		    		Database.AddInParameter(command,"ZipCode",DbType.String,zipCode);
		    		Database.AddInParameter(command,"City",DbType.String,city);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"oldAbstractAuthorLanguageId",DbType.Int32,oldabstractAuthorLanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into AbstractAuthorsLanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateAbstractAuthorsLanguage( int abstractAuthorId, string firstName, string familyName, string title, string degree, string email, string address, string affilitationDepartment, string affilitationInstitutionHospital, string affilitationCity, string affilitationCountry, string country, string pOBox, string zipCode, string city, int languageID, int oldabstractAuthorLanguageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractAuthorsLanguage");

		    		Database.AddInParameter(command,"AbstractAuthorId",DbType.Int32,abstractAuthorId);
		    		Database.AddInParameter(command,"FirstName",DbType.String,firstName);
		    		Database.AddInParameter(command,"FamilyName",DbType.String,familyName);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"Degree",DbType.String,degree);
		    		Database.AddInParameter(command,"Email",DbType.String,email);
		    		Database.AddInParameter(command,"Address",DbType.String,address);
		    		Database.AddInParameter(command,"AffilitationDepartment",DbType.String,affilitationDepartment);
		    		Database.AddInParameter(command,"AffilitationInstitutionHospital",DbType.String,affilitationInstitutionHospital);
		    		Database.AddInParameter(command,"AffilitationCity",DbType.String,affilitationCity);
		    		Database.AddInParameter(command,"AffilitationCountry",DbType.String,affilitationCountry);
		    		Database.AddInParameter(command,"Country",DbType.String,country);
		    		Database.AddInParameter(command,"POBox",DbType.String,pOBox);
		    		Database.AddInParameter(command,"ZipCode",DbType.String,zipCode);
		    		Database.AddInParameter(command,"City",DbType.String,city);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"oldAbstractAuthorLanguageId",DbType.Int32,oldabstractAuthorLanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from AbstractAuthorsLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateAbstractAuthorsLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractAuthorsLanguage");

		    		Database.AddInParameter(command,"AbstractAuthorId",DbType.Int32,"AbstractAuthorId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FirstName",DbType.String,"FirstName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FamilyName",DbType.String,"FamilyName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Degree",DbType.String,"Degree",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Email",DbType.String,"Email",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Address",DbType.String,"Address",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AffilitationDepartment",DbType.String,"AffilitationDepartment",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AffilitationInstitutionHospital",DbType.String,"AffilitationInstitutionHospital",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AffilitationCity",DbType.String,"AffilitationCity",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AffilitationCountry",DbType.String,"AffilitationCountry",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Country",DbType.String,"Country",DataRowVersion.Current);
		    		Database.AddInParameter(command,"POBox",DbType.String,"POBox",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ZipCode",DbType.String,"ZipCode",DataRowVersion.Current);
		    		Database.AddInParameter(command,"City",DbType.String,"City",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldAbstractAuthorLanguageId",DbType.Int32,"AbstractAuthorLanguageId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From AbstractAuthorsLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteAbstractAuthorsLanguage( int abstractAuthorLanguageId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteAbstractAuthorsLanguage");
			Database.AddInParameter(command,"AbstractAuthorLanguageId",DbType.Int32,abstractAuthorLanguageId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From AbstractAuthorsLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteAbstractAuthorsLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteAbstractAuthorsLanguage");
				Database.AddInParameter(command,"AbstractAuthorLanguageId",DbType.Int32,"AbstractAuthorLanguageId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table AbstractAuthorsLanguage using Stored Procedure
		/// and return number of rows effected of the AbstractAuthorsLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"AbstractAuthorsLanguage",InsertNewAbstractAuthorsLanguageCommand(),UpdateAbstractAuthorsLanguageCommand(),DeleteAbstractAuthorsLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table AbstractAuthorsLanguage using Stored Procedure
		/// and return number of rows effected of the AbstractAuthorsLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"AbstractAuthorsLanguage",InsertNewAbstractAuthorsLanguageCommand(),UpdateAbstractAuthorsLanguageCommand(),DeleteAbstractAuthorsLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
