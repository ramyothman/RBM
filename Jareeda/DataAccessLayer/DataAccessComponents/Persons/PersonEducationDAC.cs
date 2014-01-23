using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for PersonEducation table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the PersonEducation table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PersonEducationDAC : DataAccessComponent
	{
		#region Constructors
        public PersonEducationDAC() : base("", "Person.PersonEducation") { }
		public PersonEducationDAC(string connectionString): base(connectionString){}
		public PersonEducationDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonEducation using Stored Procedure
		/// and return a DataTable containing all PersonEducation Data
		/// </summary>
		public DataTable GetAllPersonEducation()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonEducation";
         string query = " select * from GetAllPersonEducation";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonEducation"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonEducation using Stored Procedure
		/// and return a DataTable containing all PersonEducation Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonEducation(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonEducation";
         string query = " select * from GetAllPersonEducation";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonEducation"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonEducation using Stored Procedure
		/// and return a DataTable containing all PersonEducation Data
		/// </summary>
		public DataTable GetAllPersonEducation(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonEducation";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPersonEducation" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonEducation"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonEducation using Stored Procedure
		/// and return a DataTable containing all PersonEducation Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonEducation(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonEducation";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPersonEducation" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonEducation"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonEducation using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonEducation( int personEducationId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonEducation");
				    Database.AddInParameter(command,"PersonEducationId",DbType.Int32,personEducationId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonEducation using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonEducation( int personEducationId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonEducation");
				    Database.AddInParameter(command,"PersonEducationId",DbType.Int32,personEducationId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonEducation using Stored Procedure
		/// and return the auto number primary key of PersonEducation inserted row
		/// </summary>
		public bool InsertNewPersonEducation( ref int personEducationId,  int personId,  string institutionName,  string degree,  DateTime startDate,  DateTime graduationDate,  string finalGrade)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonEducation");
				Database.AddOutParameter(command,"PersonEducationId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"InstitutionName",DbType.String,institutionName);
				Database.AddInParameter(command,"Degree",DbType.String,degree);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
				Database.AddInParameter(command,"GraduationDate",DbType.DateTime,graduationDate);
				Database.AddInParameter(command,"FinalGrade",DbType.String,finalGrade);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 personEducationId = Convert.ToInt32(Database.GetParameterValue(command, "PersonEducationId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonEducation using Stored Procedure
		/// and return the auto number primary key of PersonEducation inserted row using Transaction
		/// </summary>
		public bool InsertNewPersonEducation( ref int personEducationId,  int personId,  string institutionName,  string degree,  DateTime startDate,  DateTime graduationDate,  string finalGrade,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonEducation");
				Database.AddOutParameter(command,"PersonEducationId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"InstitutionName",DbType.String,institutionName);
				Database.AddInParameter(command,"Degree",DbType.String,degree);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
				Database.AddInParameter(command,"GraduationDate",DbType.DateTime,graduationDate);
				Database.AddInParameter(command,"FinalGrade",DbType.String,finalGrade);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 personEducationId = Convert.ToInt32(Database.GetParameterValue(command, "PersonEducationId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for PersonEducation using Stored Procedure
		/// and return DbCommand of the PersonEducation
		/// </summary>
		public DbCommand InsertNewPersonEducationCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonEducation");

				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				Database.AddInParameter(command,"InstitutionName",DbType.String,"InstitutionName",DataRowVersion.Current);
				Database.AddInParameter(command,"Degree",DbType.String,"Degree",DataRowVersion.Current);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,"StartDate",DataRowVersion.Current);
				Database.AddInParameter(command,"GraduationDate",DbType.DateTime,"GraduationDate",DataRowVersion.Current);
				Database.AddInParameter(command,"FinalGrade",DbType.String,"FinalGrade",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonEducation using Stored Procedure
		/// </summary>
		public bool UpdatePersonEducation( int personId, string institutionName, string degree, DateTime startDate, DateTime graduationDate, string finalGrade, int oldpersonEducationId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonEducation");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"InstitutionName",DbType.String,institutionName);
		    		Database.AddInParameter(command,"Degree",DbType.String,degree);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
		    		Database.AddInParameter(command,"GraduationDate",DbType.DateTime,graduationDate);
		    		Database.AddInParameter(command,"FinalGrade",DbType.String,finalGrade);
				Database.AddInParameter(command,"oldPersonEducationId",DbType.Int32,oldpersonEducationId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonEducation using Stored Procedure By Transaction
		/// </summary>
		public bool UpdatePersonEducation( int personId, string institutionName, string degree, DateTime startDate, DateTime graduationDate, string finalGrade, int oldpersonEducationId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonEducation");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"InstitutionName",DbType.String,institutionName);
		    		Database.AddInParameter(command,"Degree",DbType.String,degree);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
		    		Database.AddInParameter(command,"GraduationDate",DbType.DateTime,graduationDate);
		    		Database.AddInParameter(command,"FinalGrade",DbType.String,finalGrade);
				Database.AddInParameter(command,"oldPersonEducationId",DbType.Int32,oldpersonEducationId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from PersonEducation using Stored Procedure
		/// </summary>
		public DbCommand UpdatePersonEducationCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonEducation");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"InstitutionName",DbType.String,"InstitutionName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Degree",DbType.String,"Degree",DataRowVersion.Current);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,"StartDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"GraduationDate",DbType.DateTime,"GraduationDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"FinalGrade",DbType.String,"FinalGrade",DataRowVersion.Current);
				Database.AddInParameter(command,"oldPersonEducationId",DbType.Int32,"PersonEducationId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From PersonEducation using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePersonEducation( int personEducationId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePersonEducation");
			Database.AddInParameter(command,"PersonEducationId",DbType.Int32,personEducationId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From PersonEducation Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePersonEducationCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePersonEducation");
				Database.AddInParameter(command,"PersonEducationId",DbType.Int32,"PersonEducationId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonEducation using Stored Procedure
		/// and return number of rows effected of the PersonEducation
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonEducation",InsertNewPersonEducationCommand(),UpdatePersonEducationCommand(),DeletePersonEducationCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonEducation using Stored Procedure
		/// and return number of rows effected of the PersonEducation
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonEducation",InsertNewPersonEducationCommand(),UpdatePersonEducationCommand(),DeletePersonEducationCommand(), transaction);
          return rowsAffected;
		}


	}
}
