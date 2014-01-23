using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for AbstractAuthors table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the AbstractAuthors table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class AbstractAuthorsDAC : DataAccessComponent
	{
		#region Constructors
        public AbstractAuthorsDAC() : base("", "Conference.AbstractAuthors") { }
		public AbstractAuthorsDAC(string connectionString): base(connectionString){}
		public AbstractAuthorsDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractAuthors using Stored Procedure
		/// and return a DataTable containing all AbstractAuthors Data
		/// </summary>
		public DataTable GetAllAbstractAuthors()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractAuthors";
         string query = " select * from GetAllAbstractAuthors";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["AbstractAuthors"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractAuthors using Stored Procedure
		/// and return a DataTable containing all AbstractAuthors Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstractAuthors(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractAuthors";
         string query = " select * from GetAllAbstractAuthors";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["AbstractAuthors"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractAuthors using Stored Procedure
		/// and return a DataTable containing all AbstractAuthors Data
		/// </summary>
		public DataTable GetAllAbstractAuthors(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractAuthors";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllAbstractAuthors" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["AbstractAuthors"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractAuthors using Stored Procedure
		/// and return a DataTable containing all AbstractAuthors Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstractAuthors(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractAuthors";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllAbstractAuthors" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["AbstractAuthors"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From AbstractAuthors using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstractAuthors( int abstractAuthorId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstractAuthors");
				    Database.AddInParameter(command,"AbstractAuthorId",DbType.Int32,abstractAuthorId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From AbstractAuthors using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstractAuthors( int abstractAuthorId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstractAuthors");
				    Database.AddInParameter(command,"AbstractAuthorId",DbType.Int32,abstractAuthorId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into AbstractAuthors using Stored Procedure
		/// and return the auto number primary key of AbstractAuthors inserted row
		/// </summary>
		public bool InsertNewAbstractAuthors( ref int abstractAuthorId,  int abstractId,  string firstName,  string familyName,  string title,  string degree,  string email,  string address,  string phoneNumber,  string affilitationDepartment,  string affilitationInstitutionHospital,  string affilitationCity,  string affilitationCountry,  string country,  string pOBox,  string zipCode,  string city,  bool isMainAuthor,  string phoneNumberAreaCode)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractAuthors");
				Database.AddOutParameter(command,"AbstractAuthorId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"AbstractId",DbType.Int32,abstractId);
				Database.AddInParameter(command,"FirstName",DbType.String,firstName);
				Database.AddInParameter(command,"FamilyName",DbType.String,familyName);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"Degree",DbType.String,degree);
				Database.AddInParameter(command,"Email",DbType.String,email);
				Database.AddInParameter(command,"Address",DbType.String,address);
				Database.AddInParameter(command,"PhoneNumber",DbType.String,phoneNumber);
				Database.AddInParameter(command,"AffilitationDepartment",DbType.String,affilitationDepartment);
				Database.AddInParameter(command,"AffilitationInstitutionHospital",DbType.String,affilitationInstitutionHospital);
				Database.AddInParameter(command,"AffilitationCity",DbType.String,affilitationCity);
				Database.AddInParameter(command,"AffilitationCountry",DbType.String,affilitationCountry);
				Database.AddInParameter(command,"Country",DbType.String,country);
				Database.AddInParameter(command,"POBox",DbType.String,pOBox);
				Database.AddInParameter(command,"ZipCode",DbType.String,zipCode);
				Database.AddInParameter(command,"City",DbType.String,city);
				Database.AddInParameter(command,"IsMainAuthor",DbType.Boolean,isMainAuthor);
				Database.AddInParameter(command,"PhoneNumberAreaCode",DbType.String,phoneNumberAreaCode);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 abstractAuthorId = Convert.ToInt32(Database.GetParameterValue(command, "AbstractAuthorId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into AbstractAuthors using Stored Procedure
		/// and return the auto number primary key of AbstractAuthors inserted row using Transaction
		/// </summary>
		public bool InsertNewAbstractAuthors( ref int abstractAuthorId,  int abstractId,  string firstName,  string familyName,  string title,  string degree,  string email,  string address,  string phoneNumber,  string affilitationDepartment,  string affilitationInstitutionHospital,  string affilitationCity,  string affilitationCountry,  string country,  string pOBox,  string zipCode,  string city,  bool isMainAuthor,  string phoneNumberAreaCode,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractAuthors");
				Database.AddOutParameter(command,"AbstractAuthorId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"AbstractId",DbType.Int32,abstractId);
				Database.AddInParameter(command,"FirstName",DbType.String,firstName);
				Database.AddInParameter(command,"FamilyName",DbType.String,familyName);
				Database.AddInParameter(command,"Title",DbType.String,title);
				Database.AddInParameter(command,"Degree",DbType.String,degree);
				Database.AddInParameter(command,"Email",DbType.String,email);
				Database.AddInParameter(command,"Address",DbType.String,address);
				Database.AddInParameter(command,"PhoneNumber",DbType.String,phoneNumber);
				Database.AddInParameter(command,"AffilitationDepartment",DbType.String,affilitationDepartment);
				Database.AddInParameter(command,"AffilitationInstitutionHospital",DbType.String,affilitationInstitutionHospital);
				Database.AddInParameter(command,"AffilitationCity",DbType.String,affilitationCity);
				Database.AddInParameter(command,"AffilitationCountry",DbType.String,affilitationCountry);
				Database.AddInParameter(command,"Country",DbType.String,country);
				Database.AddInParameter(command,"POBox",DbType.String,pOBox);
				Database.AddInParameter(command,"ZipCode",DbType.String,zipCode);
				Database.AddInParameter(command,"City",DbType.String,city);
				Database.AddInParameter(command,"IsMainAuthor",DbType.Boolean,isMainAuthor);
				Database.AddInParameter(command,"PhoneNumberAreaCode",DbType.String,phoneNumberAreaCode);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 abstractAuthorId = Convert.ToInt32(Database.GetParameterValue(command, "AbstractAuthorId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for AbstractAuthors using Stored Procedure
		/// and return DbCommand of the AbstractAuthors
		/// </summary>
		public DbCommand InsertNewAbstractAuthorsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractAuthors");

				Database.AddInParameter(command,"AbstractId",DbType.Int32,"AbstractId",DataRowVersion.Current);
				Database.AddInParameter(command,"FirstName",DbType.String,"FirstName",DataRowVersion.Current);
				Database.AddInParameter(command,"FamilyName",DbType.String,"FamilyName",DataRowVersion.Current);
				Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
				Database.AddInParameter(command,"Degree",DbType.String,"Degree",DataRowVersion.Current);
				Database.AddInParameter(command,"Email",DbType.String,"Email",DataRowVersion.Current);
				Database.AddInParameter(command,"Address",DbType.String,"Address",DataRowVersion.Current);
				Database.AddInParameter(command,"PhoneNumber",DbType.String,"PhoneNumber",DataRowVersion.Current);
				Database.AddInParameter(command,"AffilitationDepartment",DbType.String,"AffilitationDepartment",DataRowVersion.Current);
				Database.AddInParameter(command,"AffilitationInstitutionHospital",DbType.String,"AffilitationInstitutionHospital",DataRowVersion.Current);
				Database.AddInParameter(command,"AffilitationCity",DbType.String,"AffilitationCity",DataRowVersion.Current);
				Database.AddInParameter(command,"AffilitationCountry",DbType.String,"AffilitationCountry",DataRowVersion.Current);
				Database.AddInParameter(command,"Country",DbType.String,"Country",DataRowVersion.Current);
				Database.AddInParameter(command,"POBox",DbType.String,"POBox",DataRowVersion.Current);
				Database.AddInParameter(command,"ZipCode",DbType.String,"ZipCode",DataRowVersion.Current);
				Database.AddInParameter(command,"City",DbType.String,"City",DataRowVersion.Current);
				Database.AddInParameter(command,"IsMainAuthor",DbType.Boolean,"IsMainAuthor",DataRowVersion.Current);
				Database.AddInParameter(command,"PhoneNumberAreaCode",DbType.String,"PhoneNumberAreaCode",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into AbstractAuthors using Stored Procedure
		/// </summary>
		public bool UpdateAbstractAuthors( int abstractId, string firstName, string familyName, string title, string degree, string email, string address, string phoneNumber, string affilitationDepartment, string affilitationInstitutionHospital, string affilitationCity, string affilitationCountry, string country, string pOBox, string zipCode, string city, bool isMainAuthor, string phoneNumberAreaCode, int oldabstractAuthorId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractAuthors");

		    		Database.AddInParameter(command,"AbstractId",DbType.Int32,abstractId);
		    		Database.AddInParameter(command,"FirstName",DbType.String,firstName);
		    		Database.AddInParameter(command,"FamilyName",DbType.String,familyName);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"Degree",DbType.String,degree);
		    		Database.AddInParameter(command,"Email",DbType.String,email);
		    		Database.AddInParameter(command,"Address",DbType.String,address);
		    		Database.AddInParameter(command,"PhoneNumber",DbType.String,phoneNumber);
		    		Database.AddInParameter(command,"AffilitationDepartment",DbType.String,affilitationDepartment);
		    		Database.AddInParameter(command,"AffilitationInstitutionHospital",DbType.String,affilitationInstitutionHospital);
		    		Database.AddInParameter(command,"AffilitationCity",DbType.String,affilitationCity);
		    		Database.AddInParameter(command,"AffilitationCountry",DbType.String,affilitationCountry);
		    		Database.AddInParameter(command,"Country",DbType.String,country);
		    		Database.AddInParameter(command,"POBox",DbType.String,pOBox);
		    		Database.AddInParameter(command,"ZipCode",DbType.String,zipCode);
		    		Database.AddInParameter(command,"City",DbType.String,city);
		    		Database.AddInParameter(command,"IsMainAuthor",DbType.Boolean,isMainAuthor);
		    		Database.AddInParameter(command,"PhoneNumberAreaCode",DbType.String,phoneNumberAreaCode);
				Database.AddInParameter(command,"oldAbstractAuthorId",DbType.Int32,oldabstractAuthorId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into AbstractAuthors using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateAbstractAuthors( int abstractId, string firstName, string familyName, string title, string degree, string email, string address, string phoneNumber, string affilitationDepartment, string affilitationInstitutionHospital, string affilitationCity, string affilitationCountry, string country, string pOBox, string zipCode, string city, bool isMainAuthor, string phoneNumberAreaCode, int oldabstractAuthorId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractAuthors");

		    		Database.AddInParameter(command,"AbstractId",DbType.Int32,abstractId);
		    		Database.AddInParameter(command,"FirstName",DbType.String,firstName);
		    		Database.AddInParameter(command,"FamilyName",DbType.String,familyName);
		    		Database.AddInParameter(command,"Title",DbType.String,title);
		    		Database.AddInParameter(command,"Degree",DbType.String,degree);
		    		Database.AddInParameter(command,"Email",DbType.String,email);
		    		Database.AddInParameter(command,"Address",DbType.String,address);
		    		Database.AddInParameter(command,"PhoneNumber",DbType.String,phoneNumber);
		    		Database.AddInParameter(command,"AffilitationDepartment",DbType.String,affilitationDepartment);
		    		Database.AddInParameter(command,"AffilitationInstitutionHospital",DbType.String,affilitationInstitutionHospital);
		    		Database.AddInParameter(command,"AffilitationCity",DbType.String,affilitationCity);
		    		Database.AddInParameter(command,"AffilitationCountry",DbType.String,affilitationCountry);
		    		Database.AddInParameter(command,"Country",DbType.String,country);
		    		Database.AddInParameter(command,"POBox",DbType.String,pOBox);
		    		Database.AddInParameter(command,"ZipCode",DbType.String,zipCode);
		    		Database.AddInParameter(command,"City",DbType.String,city);
		    		Database.AddInParameter(command,"IsMainAuthor",DbType.Boolean,isMainAuthor);
		    		Database.AddInParameter(command,"PhoneNumberAreaCode",DbType.String,phoneNumberAreaCode);
				Database.AddInParameter(command,"oldAbstractAuthorId",DbType.Int32,oldabstractAuthorId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from AbstractAuthors using Stored Procedure
		/// </summary>
		public DbCommand UpdateAbstractAuthorsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractAuthors");

		    		Database.AddInParameter(command,"AbstractId",DbType.Int32,"AbstractId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FirstName",DbType.String,"FirstName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FamilyName",DbType.String,"FamilyName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Title",DbType.String,"Title",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Degree",DbType.String,"Degree",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Email",DbType.String,"Email",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Address",DbType.String,"Address",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PhoneNumber",DbType.String,"PhoneNumber",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AffilitationDepartment",DbType.String,"AffilitationDepartment",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AffilitationInstitutionHospital",DbType.String,"AffilitationInstitutionHospital",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AffilitationCity",DbType.String,"AffilitationCity",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AffilitationCountry",DbType.String,"AffilitationCountry",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Country",DbType.String,"Country",DataRowVersion.Current);
		    		Database.AddInParameter(command,"POBox",DbType.String,"POBox",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ZipCode",DbType.String,"ZipCode",DataRowVersion.Current);
		    		Database.AddInParameter(command,"City",DbType.String,"City",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsMainAuthor",DbType.Boolean,"IsMainAuthor",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PhoneNumberAreaCode",DbType.String,"PhoneNumberAreaCode",DataRowVersion.Current);
				Database.AddInParameter(command,"oldAbstractAuthorId",DbType.Int32,"AbstractAuthorId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From AbstractAuthors using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteAbstractAuthors( int abstractAuthorId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteAbstractAuthors");
			Database.AddInParameter(command,"AbstractAuthorId",DbType.Int32,abstractAuthorId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From AbstractAuthors Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteAbstractAuthorsCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteAbstractAuthors");
				Database.AddInParameter(command,"AbstractAuthorId",DbType.Int32,"AbstractAuthorId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table AbstractAuthors using Stored Procedure
		/// and return number of rows effected of the AbstractAuthors
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"AbstractAuthors",InsertNewAbstractAuthorsCommand(),UpdateAbstractAuthorsCommand(),DeleteAbstractAuthorsCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table AbstractAuthors using Stored Procedure
		/// and return number of rows effected of the AbstractAuthors
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"AbstractAuthors",InsertNewAbstractAuthorsCommand(),UpdateAbstractAuthorsCommand(),DeleteAbstractAuthorsCommand(), transaction);
          return rowsAffected;
		}


	}
}
