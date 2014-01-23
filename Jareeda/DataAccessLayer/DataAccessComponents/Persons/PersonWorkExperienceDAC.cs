using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for PersonWorkExperience table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the PersonWorkExperience table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PersonWorkExperienceDAC : DataAccessComponent
	{
		#region Constructors
        public PersonWorkExperienceDAC() : base("", "Person.PersonWorkExperience") { }
		public PersonWorkExperienceDAC(string connectionString): base(connectionString){}
		public PersonWorkExperienceDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonWorkExperience using Stored Procedure
		/// and return a DataTable containing all PersonWorkExperience Data
		/// </summary>
		public DataTable GetAllPersonWorkExperience()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonWorkExperience";
         string query = " select * from GetAllPersonWorkExperience";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonWorkExperience"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonWorkExperience using Stored Procedure
		/// and return a DataTable containing all PersonWorkExperience Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonWorkExperience(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonWorkExperience";
         string query = " select * from GetAllPersonWorkExperience";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonWorkExperience"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonWorkExperience using Stored Procedure
		/// and return a DataTable containing all PersonWorkExperience Data
		/// </summary>
		public DataTable GetAllPersonWorkExperience(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonWorkExperience";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPersonWorkExperience" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonWorkExperience"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonWorkExperience using Stored Procedure
		/// and return a DataTable containing all PersonWorkExperience Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonWorkExperience(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonWorkExperience";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPersonWorkExperience" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonWorkExperience"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonWorkExperience using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonWorkExperience( int personWorkExperienceId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonWorkExperience");
				    Database.AddInParameter(command,"PersonWorkExperienceId",DbType.Int32,personWorkExperienceId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonWorkExperience using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonWorkExperience( int personWorkExperienceId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonWorkExperience");
				    Database.AddInParameter(command,"PersonWorkExperienceId",DbType.Int32,personWorkExperienceId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonWorkExperience using Stored Procedure
		/// and return the auto number primary key of PersonWorkExperience inserted row
		/// </summary>
		public bool InsertNewPersonWorkExperience( ref int personWorkExperienceId,  int personId,  string employer,  string positionHeld,  string responsibilities,  DateTime startDate,  DateTime endDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonWorkExperience");
				Database.AddOutParameter(command,"PersonWorkExperienceId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"Employer",DbType.String,employer);
				Database.AddInParameter(command,"PositionHeld",DbType.String,positionHeld);
				Database.AddInParameter(command,"Responsibilities",DbType.String,responsibilities);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 personWorkExperienceId = Convert.ToInt32(Database.GetParameterValue(command, "PersonWorkExperienceId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonWorkExperience using Stored Procedure
		/// and return the auto number primary key of PersonWorkExperience inserted row using Transaction
		/// </summary>
		public bool InsertNewPersonWorkExperience( ref int personWorkExperienceId,  int personId,  string employer,  string positionHeld,  string responsibilities,  DateTime startDate,  DateTime endDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonWorkExperience");
				Database.AddOutParameter(command,"PersonWorkExperienceId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"Employer",DbType.String,employer);
				Database.AddInParameter(command,"PositionHeld",DbType.String,positionHeld);
				Database.AddInParameter(command,"Responsibilities",DbType.String,responsibilities);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 personWorkExperienceId = Convert.ToInt32(Database.GetParameterValue(command, "PersonWorkExperienceId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for PersonWorkExperience using Stored Procedure
		/// and return DbCommand of the PersonWorkExperience
		/// </summary>
		public DbCommand InsertNewPersonWorkExperienceCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonWorkExperience");

				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				Database.AddInParameter(command,"Employer",DbType.String,"Employer",DataRowVersion.Current);
				Database.AddInParameter(command,"PositionHeld",DbType.String,"PositionHeld",DataRowVersion.Current);
				Database.AddInParameter(command,"Responsibilities",DbType.String,"Responsibilities",DataRowVersion.Current);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,"StartDate",DataRowVersion.Current);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,"EndDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonWorkExperience using Stored Procedure
		/// </summary>
		public bool UpdatePersonWorkExperience( int personId, string employer, string positionHeld, string responsibilities, DateTime startDate, DateTime endDate, int oldpersonWorkExperienceId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonWorkExperience");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"Employer",DbType.String,employer);
		    		Database.AddInParameter(command,"PositionHeld",DbType.String,positionHeld);
		    		Database.AddInParameter(command,"Responsibilities",DbType.String,responsibilities);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				Database.AddInParameter(command,"oldPersonWorkExperienceId",DbType.Int32,oldpersonWorkExperienceId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonWorkExperience using Stored Procedure By Transaction
		/// </summary>
		public bool UpdatePersonWorkExperience( int personId, string employer, string positionHeld, string responsibilities, DateTime startDate, DateTime endDate, int oldpersonWorkExperienceId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonWorkExperience");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"Employer",DbType.String,employer);
		    		Database.AddInParameter(command,"PositionHeld",DbType.String,positionHeld);
		    		Database.AddInParameter(command,"Responsibilities",DbType.String,responsibilities);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				Database.AddInParameter(command,"oldPersonWorkExperienceId",DbType.Int32,oldpersonWorkExperienceId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from PersonWorkExperience using Stored Procedure
		/// </summary>
		public DbCommand UpdatePersonWorkExperienceCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonWorkExperience");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Employer",DbType.String,"Employer",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PositionHeld",DbType.String,"PositionHeld",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Responsibilities",DbType.String,"Responsibilities",DataRowVersion.Current);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,"StartDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,"EndDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldPersonWorkExperienceId",DbType.Int32,"PersonWorkExperienceId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From PersonWorkExperience using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePersonWorkExperience( int personWorkExperienceId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePersonWorkExperience");
			Database.AddInParameter(command,"PersonWorkExperienceId",DbType.Int32,personWorkExperienceId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From PersonWorkExperience Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePersonWorkExperienceCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePersonWorkExperience");
				Database.AddInParameter(command,"PersonWorkExperienceId",DbType.Int32,"PersonWorkExperienceId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonWorkExperience using Stored Procedure
		/// and return number of rows effected of the PersonWorkExperience
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonWorkExperience",InsertNewPersonWorkExperienceCommand(),UpdatePersonWorkExperienceCommand(),DeletePersonWorkExperienceCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonWorkExperience using Stored Procedure
		/// and return number of rows effected of the PersonWorkExperience
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonWorkExperience",InsertNewPersonWorkExperienceCommand(),UpdatePersonWorkExperienceCommand(),DeletePersonWorkExperienceCommand(), transaction);
          return rowsAffected;
		}


	}
}
