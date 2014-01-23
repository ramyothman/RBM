using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for PersonDependent table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the PersonDependent table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PersonDependentDAC : DataAccessComponent
	{
		#region Constructors
        public PersonDependentDAC() : base("", "Person.PersonDependent") { }
		public PersonDependentDAC(string connectionString): base(connectionString){}
		public PersonDependentDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonDependent using Stored Procedure
		/// and return a DataTable containing all PersonDependent Data
		/// </summary>
		public DataTable GetAllPersonDependent()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonDependent";
         string query = " select * from GetAllPersonDependent";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonDependent"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonDependent using Stored Procedure
		/// and return a DataTable containing all PersonDependent Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonDependent(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonDependent";
         string query = " select * from GetAllPersonDependent";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonDependent"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonDependent using Stored Procedure
		/// and return a DataTable containing all PersonDependent Data
		/// </summary>
		public DataTable GetAllPersonDependent(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonDependent";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPersonDependent" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonDependent"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonDependent using Stored Procedure
		/// and return a DataTable containing all PersonDependent Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonDependent(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonDependent";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPersonDependent" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonDependent"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonDependent using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonDependent( int personDependentId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonDependent");
				    Database.AddInParameter(command,"PersonDependentId",DbType.Int32,personDependentId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonDependent using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonDependent( int personDependentId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonDependent");
				    Database.AddInParameter(command,"PersonDependentId",DbType.Int32,personDependentId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonDependent using Stored Procedure
		/// and return the auto number primary key of PersonDependent inserted row
		/// </summary>
		public bool InsertNewPersonDependent( ref int personDependentId,  int personId,  string dependentName,  string gender,  int age,  DateTime dateOfBirth,  string relation,  DateTime dateModified)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonDependent");
				Database.AddOutParameter(command,"PersonDependentId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"DependentName",DbType.String,dependentName);
				Database.AddInParameter(command,"Gender",DbType.String,gender);
				Database.AddInParameter(command,"Age",DbType.Int32,age);
				Database.AddInParameter(command,"DateOfBirth",DbType.DateTime,dateOfBirth);
				Database.AddInParameter(command,"Relation",DbType.String,relation);
				Database.AddInParameter(command,"DateModified",DbType.DateTime,dateModified);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 personDependentId = Convert.ToInt32(Database.GetParameterValue(command, "PersonDependentId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonDependent using Stored Procedure
		/// and return the auto number primary key of PersonDependent inserted row using Transaction
		/// </summary>
		public bool InsertNewPersonDependent( ref int personDependentId,  int personId,  string dependentName,  string gender,  int age,  DateTime dateOfBirth,  string relation,  DateTime dateModified,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonDependent");
				Database.AddOutParameter(command,"PersonDependentId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"DependentName",DbType.String,dependentName);
				Database.AddInParameter(command,"Gender",DbType.String,gender);
				Database.AddInParameter(command,"Age",DbType.Int32,age);
				Database.AddInParameter(command,"DateOfBirth",DbType.DateTime,dateOfBirth);
				Database.AddInParameter(command,"Relation",DbType.String,relation);
				Database.AddInParameter(command,"DateModified",DbType.DateTime,dateModified);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 personDependentId = Convert.ToInt32(Database.GetParameterValue(command, "PersonDependentId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for PersonDependent using Stored Procedure
		/// and return DbCommand of the PersonDependent
		/// </summary>
		public DbCommand InsertNewPersonDependentCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonDependent");

				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				Database.AddInParameter(command,"DependentName",DbType.String,"DependentName",DataRowVersion.Current);
				Database.AddInParameter(command,"Gender",DbType.String,"Gender",DataRowVersion.Current);
				Database.AddInParameter(command,"Age",DbType.Int32,"Age",DataRowVersion.Current);
				Database.AddInParameter(command,"DateOfBirth",DbType.DateTime,"DateOfBirth",DataRowVersion.Current);
				Database.AddInParameter(command,"Relation",DbType.String,"Relation",DataRowVersion.Current);
				Database.AddInParameter(command,"DateModified",DbType.DateTime,"DateModified",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonDependent using Stored Procedure
		/// </summary>
		public bool UpdatePersonDependent( int personId, string dependentName, string gender, int age, DateTime dateOfBirth, string relation, DateTime dateModified, int oldpersonDependentId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonDependent");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"DependentName",DbType.String,dependentName);
		    		Database.AddInParameter(command,"Gender",DbType.String,gender);
		    		Database.AddInParameter(command,"Age",DbType.Int32,age);
		    		Database.AddInParameter(command,"DateOfBirth",DbType.DateTime,dateOfBirth);
		    		Database.AddInParameter(command,"Relation",DbType.String,relation);
		    		Database.AddInParameter(command,"DateModified",DbType.DateTime,dateModified);
				Database.AddInParameter(command,"oldPersonDependentId",DbType.Int32,oldpersonDependentId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonDependent using Stored Procedure By Transaction
		/// </summary>
		public bool UpdatePersonDependent( int personId, string dependentName, string gender, int age, DateTime dateOfBirth, string relation, DateTime dateModified, int oldpersonDependentId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonDependent");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"DependentName",DbType.String,dependentName);
		    		Database.AddInParameter(command,"Gender",DbType.String,gender);
		    		Database.AddInParameter(command,"Age",DbType.Int32,age);
		    		Database.AddInParameter(command,"DateOfBirth",DbType.DateTime,dateOfBirth);
		    		Database.AddInParameter(command,"Relation",DbType.String,relation);
		    		Database.AddInParameter(command,"DateModified",DbType.DateTime,dateModified);
				Database.AddInParameter(command,"oldPersonDependentId",DbType.Int32,oldpersonDependentId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from PersonDependent using Stored Procedure
		/// </summary>
		public DbCommand UpdatePersonDependentCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonDependent");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DependentName",DbType.String,"DependentName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Gender",DbType.String,"Gender",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Age",DbType.Int32,"Age",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DateOfBirth",DbType.DateTime,"DateOfBirth",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Relation",DbType.String,"Relation",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DateModified",DbType.DateTime,"DateModified",DataRowVersion.Current);
				Database.AddInParameter(command,"oldPersonDependentId",DbType.Int32,"PersonDependentId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From PersonDependent using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePersonDependent( int personDependentId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePersonDependent");
			Database.AddInParameter(command,"PersonDependentId",DbType.Int32,personDependentId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From PersonDependent Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePersonDependentCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePersonDependent");
				Database.AddInParameter(command,"PersonDependentId",DbType.Int32,"PersonDependentId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonDependent using Stored Procedure
		/// and return number of rows effected of the PersonDependent
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonDependent",InsertNewPersonDependentCommand(),UpdatePersonDependentCommand(),DeletePersonDependentCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonDependent using Stored Procedure
		/// and return number of rows effected of the PersonDependent
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonDependent",InsertNewPersonDependentCommand(),UpdatePersonDependentCommand(),DeletePersonDependentCommand(), transaction);
          return rowsAffected;
		}


	}
}
