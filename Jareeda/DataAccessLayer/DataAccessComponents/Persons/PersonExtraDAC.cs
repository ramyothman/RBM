using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for PersonExtra table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the PersonExtra table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PersonExtraDAC : DataAccessComponent
	{
		#region Constructors
        public PersonExtraDAC() : base("", "Person.PersonExtra") { }
		public PersonExtraDAC(string connectionString): base(connectionString){}
		public PersonExtraDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonExtra using Stored Procedure
		/// and return a DataTable containing all PersonExtra Data
		/// </summary>
		public DataTable GetAllPersonExtra()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonExtra";
         string query = " select * from GetAllPersonExtra";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonExtra"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonExtra using Stored Procedure
		/// and return a DataTable containing all PersonExtra Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonExtra(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonExtra";
         string query = " select * from GetAllPersonExtra";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonExtra"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonExtra using Stored Procedure
		/// and return a DataTable containing all PersonExtra Data
		/// </summary>
		public DataTable GetAllPersonExtra(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonExtra";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPersonExtra" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonExtra"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonExtra using Stored Procedure
		/// and return a DataTable containing all PersonExtra Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonExtra(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonExtra";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPersonExtra" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonExtra"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonExtra using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonExtra( int personExtraId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonExtra");
				    Database.AddInParameter(command,"PersonExtraId",DbType.Int32,personExtraId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonExtra using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonExtra( int personExtraId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonExtra");
				    Database.AddInParameter(command,"PersonExtraId",DbType.Int32,personExtraId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonExtra using Stored Procedure
		/// and return the auto number primary key of PersonExtra inserted row
		/// </summary>
		public bool InsertNewPersonExtra( int personExtraId,  string nationalIdType,  string nationalId,  string gender,  string religion,  DateTime birthDate,  string birthPlace,  string maritalStatus,  string spauseName,  string fatherGuardianName,  string fatherGuardianAddress,  string fatherGuardianContactNumber,  string emergencyContactName,  string emergencyContactAddress,  string emergencyContactNumber,  string emergencyContactEmail,  int sponsorId,  DateTime sponsorStartDate,  DateTime sponsorEndDate,  int sponsorCategoryId,  bool isGraduateTransfer,  string reasonForSeekingTransfer,  string levelRequired,  string otherInformation)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonExtra");
				Database.AddInParameter(command,"PersonExtraId",DbType.Int32,personExtraId);
				Database.AddInParameter(command,"NationalIdType",DbType.String,nationalIdType);
				Database.AddInParameter(command,"NationalId",DbType.String,nationalId);
				Database.AddInParameter(command,"Gender",DbType.String,gender);
				Database.AddInParameter(command,"Religion",DbType.String,religion);
				Database.AddInParameter(command,"BirthDate",DbType.DateTime,birthDate);
				Database.AddInParameter(command,"BirthPlace",DbType.String,birthPlace);
				Database.AddInParameter(command,"MaritalStatus",DbType.String,maritalStatus);
				Database.AddInParameter(command,"SpauseName",DbType.String,spauseName);
				Database.AddInParameter(command,"FatherGuardianName",DbType.String,fatherGuardianName);
				Database.AddInParameter(command,"FatherGuardianAddress",DbType.String,fatherGuardianAddress);
				Database.AddInParameter(command,"FatherGuardianContactNumber",DbType.String,fatherGuardianContactNumber);
				Database.AddInParameter(command,"EmergencyContactName",DbType.String,emergencyContactName);
				Database.AddInParameter(command,"EmergencyContactAddress",DbType.String,emergencyContactAddress);
				Database.AddInParameter(command,"EmergencyContactNumber",DbType.String,emergencyContactNumber);
				Database.AddInParameter(command,"EmergencyContactEmail",DbType.String,emergencyContactEmail);
				Database.AddInParameter(command,"SponsorId",DbType.Int32,sponsorId);
				Database.AddInParameter(command,"SponsorStartDate",DbType.DateTime,sponsorStartDate);
				Database.AddInParameter(command,"SponsorEndDate",DbType.DateTime,sponsorEndDate);
				Database.AddInParameter(command,"SponsorCategoryId",DbType.Int32,sponsorCategoryId);
				Database.AddInParameter(command,"IsGraduateTransfer",DbType.Boolean,isGraduateTransfer);
				Database.AddInParameter(command,"ReasonForSeekingTransfer",DbType.String,reasonForSeekingTransfer);
				Database.AddInParameter(command,"LevelRequired",DbType.String,levelRequired);
				Database.AddInParameter(command,"OtherInformation",DbType.String,otherInformation);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonExtra using Stored Procedure
		/// and return the auto number primary key of PersonExtra inserted row using Transaction
		/// </summary>
		public bool InsertNewPersonExtra( int personExtraId,  string nationalIdType,  string nationalId,  string gender,  string religion,  DateTime birthDate,  string birthPlace,  string maritalStatus,  string spauseName,  string fatherGuardianName,  string fatherGuardianAddress,  string fatherGuardianContactNumber,  string emergencyContactName,  string emergencyContactAddress,  string emergencyContactNumber,  string emergencyContactEmail,  int sponsorId,  DateTime sponsorStartDate,  DateTime sponsorEndDate,  int sponsorCategoryId,  bool isGraduateTransfer,  string reasonForSeekingTransfer,  string levelRequired,  string otherInformation,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonExtra");
				Database.AddInParameter(command,"PersonExtraId",DbType.Int32,personExtraId);
				Database.AddInParameter(command,"NationalIdType",DbType.String,nationalIdType);
				Database.AddInParameter(command,"NationalId",DbType.String,nationalId);
				Database.AddInParameter(command,"Gender",DbType.String,gender);
				Database.AddInParameter(command,"Religion",DbType.String,religion);
				Database.AddInParameter(command,"BirthDate",DbType.DateTime,birthDate);
				Database.AddInParameter(command,"BirthPlace",DbType.String,birthPlace);
				Database.AddInParameter(command,"MaritalStatus",DbType.String,maritalStatus);
				Database.AddInParameter(command,"SpauseName",DbType.String,spauseName);
				Database.AddInParameter(command,"FatherGuardianName",DbType.String,fatherGuardianName);
				Database.AddInParameter(command,"FatherGuardianAddress",DbType.String,fatherGuardianAddress);
				Database.AddInParameter(command,"FatherGuardianContactNumber",DbType.String,fatherGuardianContactNumber);
				Database.AddInParameter(command,"EmergencyContactName",DbType.String,emergencyContactName);
				Database.AddInParameter(command,"EmergencyContactAddress",DbType.String,emergencyContactAddress);
				Database.AddInParameter(command,"EmergencyContactNumber",DbType.String,emergencyContactNumber);
				Database.AddInParameter(command,"EmergencyContactEmail",DbType.String,emergencyContactEmail);
				Database.AddInParameter(command,"SponsorId",DbType.Int32,sponsorId);
				Database.AddInParameter(command,"SponsorStartDate",DbType.DateTime,sponsorStartDate);
				Database.AddInParameter(command,"SponsorEndDate",DbType.DateTime,sponsorEndDate);
				Database.AddInParameter(command,"SponsorCategoryId",DbType.Int32,sponsorCategoryId);
				Database.AddInParameter(command,"IsGraduateTransfer",DbType.Boolean,isGraduateTransfer);
				Database.AddInParameter(command,"ReasonForSeekingTransfer",DbType.String,reasonForSeekingTransfer);
				Database.AddInParameter(command,"LevelRequired",DbType.String,levelRequired);
				Database.AddInParameter(command,"OtherInformation",DbType.String,otherInformation);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for PersonExtra using Stored Procedure
		/// and return DbCommand of the PersonExtra
		/// </summary>
		public DbCommand InsertNewPersonExtraCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonExtra");
				Database.AddInParameter(command,"PersonExtraId",DbType.Int32,"PersonExtraId",DataRowVersion.Current);
				Database.AddInParameter(command,"NationalIdType",DbType.String,"NationalIdType",DataRowVersion.Current);
				Database.AddInParameter(command,"NationalId",DbType.String,"NationalId",DataRowVersion.Current);
				Database.AddInParameter(command,"Gender",DbType.String,"Gender",DataRowVersion.Current);
				Database.AddInParameter(command,"Religion",DbType.String,"Religion",DataRowVersion.Current);
				Database.AddInParameter(command,"BirthDate",DbType.DateTime,"BirthDate",DataRowVersion.Current);
				Database.AddInParameter(command,"BirthPlace",DbType.String,"BirthPlace",DataRowVersion.Current);
				Database.AddInParameter(command,"MaritalStatus",DbType.String,"MaritalStatus",DataRowVersion.Current);
				Database.AddInParameter(command,"SpauseName",DbType.String,"SpauseName",DataRowVersion.Current);
				Database.AddInParameter(command,"FatherGuardianName",DbType.String,"FatherGuardianName",DataRowVersion.Current);
				Database.AddInParameter(command,"FatherGuardianAddress",DbType.String,"FatherGuardianAddress",DataRowVersion.Current);
				Database.AddInParameter(command,"FatherGuardianContactNumber",DbType.String,"FatherGuardianContactNumber",DataRowVersion.Current);
				Database.AddInParameter(command,"EmergencyContactName",DbType.String,"EmergencyContactName",DataRowVersion.Current);
				Database.AddInParameter(command,"EmergencyContactAddress",DbType.String,"EmergencyContactAddress",DataRowVersion.Current);
				Database.AddInParameter(command,"EmergencyContactNumber",DbType.String,"EmergencyContactNumber",DataRowVersion.Current);
				Database.AddInParameter(command,"EmergencyContactEmail",DbType.String,"EmergencyContactEmail",DataRowVersion.Current);
				Database.AddInParameter(command,"SponsorId",DbType.Int32,"SponsorId",DataRowVersion.Current);
				Database.AddInParameter(command,"SponsorStartDate",DbType.DateTime,"SponsorStartDate",DataRowVersion.Current);
				Database.AddInParameter(command,"SponsorEndDate",DbType.DateTime,"SponsorEndDate",DataRowVersion.Current);
				Database.AddInParameter(command,"SponsorCategoryId",DbType.Int32,"SponsorCategoryId",DataRowVersion.Current);
				Database.AddInParameter(command,"IsGraduateTransfer",DbType.Boolean,"IsGraduateTransfer",DataRowVersion.Current);
				Database.AddInParameter(command,"ReasonForSeekingTransfer",DbType.String,"ReasonForSeekingTransfer",DataRowVersion.Current);
				Database.AddInParameter(command,"LevelRequired",DbType.String,"LevelRequired",DataRowVersion.Current);
				Database.AddInParameter(command,"OtherInformation",DbType.String,"OtherInformation",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonExtra using Stored Procedure
		/// </summary>
		public bool UpdatePersonExtra( int personExtraId, string nationalIdType, string nationalId, string gender, string religion, DateTime birthDate, string birthPlace, string maritalStatus, string spauseName, string fatherGuardianName, string fatherGuardianAddress, string fatherGuardianContactNumber, string emergencyContactName, string emergencyContactAddress, string emergencyContactNumber, string emergencyContactEmail, int sponsorId, DateTime sponsorStartDate, DateTime sponsorEndDate, int sponsorCategoryId, bool isGraduateTransfer, string reasonForSeekingTransfer, string levelRequired, string otherInformation, int oldpersonExtraId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonExtra");
		    		Database.AddInParameter(command,"PersonExtraId",DbType.Int32,personExtraId);
		    		Database.AddInParameter(command,"NationalIdType",DbType.String,nationalIdType);
		    		Database.AddInParameter(command,"NationalId",DbType.String,nationalId);
		    		Database.AddInParameter(command,"Gender",DbType.String,gender);
		    		Database.AddInParameter(command,"Religion",DbType.String,religion);
		    		Database.AddInParameter(command,"BirthDate",DbType.DateTime,birthDate);
		    		Database.AddInParameter(command,"BirthPlace",DbType.String,birthPlace);
		    		Database.AddInParameter(command,"MaritalStatus",DbType.String,maritalStatus);
		    		Database.AddInParameter(command,"SpauseName",DbType.String,spauseName);
		    		Database.AddInParameter(command,"FatherGuardianName",DbType.String,fatherGuardianName);
		    		Database.AddInParameter(command,"FatherGuardianAddress",DbType.String,fatherGuardianAddress);
		    		Database.AddInParameter(command,"FatherGuardianContactNumber",DbType.String,fatherGuardianContactNumber);
		    		Database.AddInParameter(command,"EmergencyContactName",DbType.String,emergencyContactName);
		    		Database.AddInParameter(command,"EmergencyContactAddress",DbType.String,emergencyContactAddress);
		    		Database.AddInParameter(command,"EmergencyContactNumber",DbType.String,emergencyContactNumber);
		    		Database.AddInParameter(command,"EmergencyContactEmail",DbType.String,emergencyContactEmail);
		    		Database.AddInParameter(command,"SponsorId",DbType.Int32,sponsorId);
		    		Database.AddInParameter(command,"SponsorStartDate",DbType.DateTime,sponsorStartDate);
		    		Database.AddInParameter(command,"SponsorEndDate",DbType.DateTime,sponsorEndDate);
		    		Database.AddInParameter(command,"SponsorCategoryId",DbType.Int32,sponsorCategoryId);
		    		Database.AddInParameter(command,"IsGraduateTransfer",DbType.Boolean,isGraduateTransfer);
		    		Database.AddInParameter(command,"ReasonForSeekingTransfer",DbType.String,reasonForSeekingTransfer);
		    		Database.AddInParameter(command,"LevelRequired",DbType.String,levelRequired);
		    		Database.AddInParameter(command,"OtherInformation",DbType.String,otherInformation);
				Database.AddInParameter(command,"oldPersonExtraId",DbType.Int32,oldpersonExtraId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonExtra using Stored Procedure By Transaction
		/// </summary>
		public bool UpdatePersonExtra( int personExtraId, string nationalIdType, string nationalId, string gender, string religion, DateTime birthDate, string birthPlace, string maritalStatus, string spauseName, string fatherGuardianName, string fatherGuardianAddress, string fatherGuardianContactNumber, string emergencyContactName, string emergencyContactAddress, string emergencyContactNumber, string emergencyContactEmail, int sponsorId, DateTime sponsorStartDate, DateTime sponsorEndDate, int sponsorCategoryId, bool isGraduateTransfer, string reasonForSeekingTransfer, string levelRequired, string otherInformation, int oldpersonExtraId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonExtra");
		    		Database.AddInParameter(command,"PersonExtraId",DbType.Int32,personExtraId);
		    		Database.AddInParameter(command,"NationalIdType",DbType.String,nationalIdType);
		    		Database.AddInParameter(command,"NationalId",DbType.String,nationalId);
		    		Database.AddInParameter(command,"Gender",DbType.String,gender);
		    		Database.AddInParameter(command,"Religion",DbType.String,religion);
		    		Database.AddInParameter(command,"BirthDate",DbType.DateTime,birthDate);
		    		Database.AddInParameter(command,"BirthPlace",DbType.String,birthPlace);
		    		Database.AddInParameter(command,"MaritalStatus",DbType.String,maritalStatus);
		    		Database.AddInParameter(command,"SpauseName",DbType.String,spauseName);
		    		Database.AddInParameter(command,"FatherGuardianName",DbType.String,fatherGuardianName);
		    		Database.AddInParameter(command,"FatherGuardianAddress",DbType.String,fatherGuardianAddress);
		    		Database.AddInParameter(command,"FatherGuardianContactNumber",DbType.String,fatherGuardianContactNumber);
		    		Database.AddInParameter(command,"EmergencyContactName",DbType.String,emergencyContactName);
		    		Database.AddInParameter(command,"EmergencyContactAddress",DbType.String,emergencyContactAddress);
		    		Database.AddInParameter(command,"EmergencyContactNumber",DbType.String,emergencyContactNumber);
		    		Database.AddInParameter(command,"EmergencyContactEmail",DbType.String,emergencyContactEmail);
		    		Database.AddInParameter(command,"SponsorId",DbType.Int32,sponsorId);
		    		Database.AddInParameter(command,"SponsorStartDate",DbType.DateTime,sponsorStartDate);
		    		Database.AddInParameter(command,"SponsorEndDate",DbType.DateTime,sponsorEndDate);
		    		Database.AddInParameter(command,"SponsorCategoryId",DbType.Int32,sponsorCategoryId);
		    		Database.AddInParameter(command,"IsGraduateTransfer",DbType.Boolean,isGraduateTransfer);
		    		Database.AddInParameter(command,"ReasonForSeekingTransfer",DbType.String,reasonForSeekingTransfer);
		    		Database.AddInParameter(command,"LevelRequired",DbType.String,levelRequired);
		    		Database.AddInParameter(command,"OtherInformation",DbType.String,otherInformation);
				Database.AddInParameter(command,"oldPersonExtraId",DbType.Int32,oldpersonExtraId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from PersonExtra using Stored Procedure
		/// </summary>
		public DbCommand UpdatePersonExtraCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonExtra");
		    		Database.AddInParameter(command,"PersonExtraId",DbType.Int32,"PersonExtraId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"NationalIdType",DbType.String,"NationalIdType",DataRowVersion.Current);
		    		Database.AddInParameter(command,"NationalId",DbType.String,"NationalId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Gender",DbType.String,"Gender",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Religion",DbType.String,"Religion",DataRowVersion.Current);
		    		Database.AddInParameter(command,"BirthDate",DbType.DateTime,"BirthDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"BirthPlace",DbType.String,"BirthPlace",DataRowVersion.Current);
		    		Database.AddInParameter(command,"MaritalStatus",DbType.String,"MaritalStatus",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SpauseName",DbType.String,"SpauseName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FatherGuardianName",DbType.String,"FatherGuardianName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FatherGuardianAddress",DbType.String,"FatherGuardianAddress",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FatherGuardianContactNumber",DbType.String,"FatherGuardianContactNumber",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EmergencyContactName",DbType.String,"EmergencyContactName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EmergencyContactAddress",DbType.String,"EmergencyContactAddress",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EmergencyContactNumber",DbType.String,"EmergencyContactNumber",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EmergencyContactEmail",DbType.String,"EmergencyContactEmail",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SponsorId",DbType.Int32,"SponsorId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SponsorStartDate",DbType.DateTime,"SponsorStartDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SponsorEndDate",DbType.DateTime,"SponsorEndDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SponsorCategoryId",DbType.Int32,"SponsorCategoryId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsGraduateTransfer",DbType.Boolean,"IsGraduateTransfer",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ReasonForSeekingTransfer",DbType.String,"ReasonForSeekingTransfer",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LevelRequired",DbType.String,"LevelRequired",DataRowVersion.Current);
		    		Database.AddInParameter(command,"OtherInformation",DbType.String,"OtherInformation",DataRowVersion.Current);
				Database.AddInParameter(command,"oldPersonExtraId",DbType.Int32,"PersonExtraId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From PersonExtra using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePersonExtra( int personExtraId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePersonExtra");
			Database.AddInParameter(command,"PersonExtraId",DbType.Int32,personExtraId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From PersonExtra Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePersonExtraCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePersonExtra");
				Database.AddInParameter(command,"PersonExtraId",DbType.Int32,"PersonExtraId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonExtra using Stored Procedure
		/// and return number of rows effected of the PersonExtra
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonExtra",InsertNewPersonExtraCommand(),UpdatePersonExtraCommand(),DeletePersonExtraCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonExtra using Stored Procedure
		/// and return number of rows effected of the PersonExtra
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonExtra",InsertNewPersonExtraCommand(),UpdatePersonExtraCommand(),DeletePersonExtraCommand(), transaction);
          return rowsAffected;
		}


	}
}
