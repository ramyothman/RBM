using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for PersonInternship table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the PersonInternship table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PersonInternshipDAC : DataAccessComponent
	{
		#region Constructors
        public PersonInternshipDAC() : base("", "Person.PersonInternship") { }
		public PersonInternshipDAC(string connectionString): base(connectionString){}
		public PersonInternshipDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonInternship using Stored Procedure
		/// and return a DataTable containing all PersonInternship Data
		/// </summary>
		public DataTable GetAllPersonInternship()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonInternship";
         string query = " select * from GetAllPersonInternship";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonInternship"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonInternship using Stored Procedure
		/// and return a DataTable containing all PersonInternship Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonInternship(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonInternship";
         string query = " select * from GetAllPersonInternship";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonInternship"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonInternship using Stored Procedure
		/// and return a DataTable containing all PersonInternship Data
		/// </summary>
		public DataTable GetAllPersonInternship(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonInternship";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPersonInternship" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonInternship"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonInternship using Stored Procedure
		/// and return a DataTable containing all PersonInternship Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonInternship(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonInternship";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPersonInternship" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonInternship"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonInternship using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonInternship( int personInternshipId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonInternship");
				    Database.AddInParameter(command,"PersonInternshipId",DbType.Int32,personInternshipId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonInternship using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonInternship( int personInternshipId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonInternship");
				    Database.AddInParameter(command,"PersonInternshipId",DbType.Int32,personInternshipId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonInternship using Stored Procedure
		/// and return the auto number primary key of PersonInternship inserted row
		/// </summary>
		public bool InsertNewPersonInternship( ref int personInternshipId,  int personId,  string service,  string institution,  string evaluation,  DateTime startDate,  DateTime endDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonInternship");
				Database.AddOutParameter(command,"PersonInternshipId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"Service",DbType.String,service);
				Database.AddInParameter(command,"Institution",DbType.String,institution);
				Database.AddInParameter(command,"Evaluation",DbType.String,evaluation);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 personInternshipId = Convert.ToInt32(Database.GetParameterValue(command, "PersonInternshipId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonInternship using Stored Procedure
		/// and return the auto number primary key of PersonInternship inserted row using Transaction
		/// </summary>
		public bool InsertNewPersonInternship( ref int personInternshipId,  int personId,  string service,  string institution,  string evaluation,  DateTime startDate,  DateTime endDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonInternship");
				Database.AddOutParameter(command,"PersonInternshipId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"Service",DbType.String,service);
				Database.AddInParameter(command,"Institution",DbType.String,institution);
				Database.AddInParameter(command,"Evaluation",DbType.String,evaluation);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 personInternshipId = Convert.ToInt32(Database.GetParameterValue(command, "PersonInternshipId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for PersonInternship using Stored Procedure
		/// and return DbCommand of the PersonInternship
		/// </summary>
		public DbCommand InsertNewPersonInternshipCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonInternship");

				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				Database.AddInParameter(command,"Service",DbType.String,"Service",DataRowVersion.Current);
				Database.AddInParameter(command,"Institution",DbType.String,"Institution",DataRowVersion.Current);
				Database.AddInParameter(command,"Evaluation",DbType.String,"Evaluation",DataRowVersion.Current);
				Database.AddInParameter(command,"StartDate",DbType.DateTime,"StartDate",DataRowVersion.Current);
				Database.AddInParameter(command,"EndDate",DbType.DateTime,"EndDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonInternship using Stored Procedure
		/// </summary>
		public bool UpdatePersonInternship( int personId, string service, string institution, string evaluation, DateTime startDate, DateTime endDate, int oldpersonInternshipId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonInternship");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"Service",DbType.String,service);
		    		Database.AddInParameter(command,"Institution",DbType.String,institution);
		    		Database.AddInParameter(command,"Evaluation",DbType.String,evaluation);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				Database.AddInParameter(command,"oldPersonInternshipId",DbType.Int32,oldpersonInternshipId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonInternship using Stored Procedure By Transaction
		/// </summary>
		public bool UpdatePersonInternship( int personId, string service, string institution, string evaluation, DateTime startDate, DateTime endDate, int oldpersonInternshipId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonInternship");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"Service",DbType.String,service);
		    		Database.AddInParameter(command,"Institution",DbType.String,institution);
		    		Database.AddInParameter(command,"Evaluation",DbType.String,evaluation);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,startDate);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,endDate);
				Database.AddInParameter(command,"oldPersonInternshipId",DbType.Int32,oldpersonInternshipId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from PersonInternship using Stored Procedure
		/// </summary>
		public DbCommand UpdatePersonInternshipCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonInternship");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Service",DbType.String,"Service",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Institution",DbType.String,"Institution",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Evaluation",DbType.String,"Evaluation",DataRowVersion.Current);
		    		Database.AddInParameter(command,"StartDate",DbType.DateTime,"StartDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EndDate",DbType.DateTime,"EndDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldPersonInternshipId",DbType.Int32,"PersonInternshipId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From PersonInternship using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePersonInternship( int personInternshipId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePersonInternship");
			Database.AddInParameter(command,"PersonInternshipId",DbType.Int32,personInternshipId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From PersonInternship Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePersonInternshipCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePersonInternship");
				Database.AddInParameter(command,"PersonInternshipId",DbType.Int32,"PersonInternshipId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonInternship using Stored Procedure
		/// and return number of rows effected of the PersonInternship
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonInternship",InsertNewPersonInternshipCommand(),UpdatePersonInternshipCommand(),DeletePersonInternshipCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonInternship using Stored Procedure
		/// and return number of rows effected of the PersonInternship
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonInternship",InsertNewPersonInternshipCommand(),UpdatePersonInternshipCommand(),DeletePersonInternshipCommand(), transaction);
          return rowsAffected;
		}


	}
}
