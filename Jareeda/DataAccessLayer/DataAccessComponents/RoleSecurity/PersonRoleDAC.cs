using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.RoleSecurity
{
	/// <summary>
	/// This is a Data Access Class  for PersonRole table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the PersonRole table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PersonRoleDAC : DataAccessComponent
	{
		#region Constructors
        public PersonRoleDAC() : base("", "RoleSecurity.PersonRole") { }
		public PersonRoleDAC(string connectionString): base(connectionString){}
		public PersonRoleDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonRole using Stored Procedure
		/// and return a DataTable containing all PersonRole Data
		/// </summary>
		public DataTable GetAllPersonRole()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonRole";
         string query = " select * from GetAllPersonRole";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table; //ds.Tables["PersonRole"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonRole using Stored Procedure
		/// and return a DataTable containing all PersonRole Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonRole(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonRole";
         string query = " select * from GetAllPersonRole";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonRole"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonRole using Stored Procedure
		/// and return a DataTable containing all PersonRole Data
		/// </summary>
		public DataTable GetAllPersonRole(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonRole";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPersonRole" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonRole"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonRole using Stored Procedure
		/// and return a DataTable containing all PersonRole Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonRole(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonRole";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPersonRole" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonRole"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonRole using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonRole( int personRoleId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonRole");
				    Database.AddInParameter(command,"PersonRoleId",DbType.Int32,personRoleId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonRole using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonRole( int personRoleId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonRole");
				    Database.AddInParameter(command,"PersonRoleId",DbType.Int32,personRoleId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonRole using Stored Procedure
		/// and return the auto number primary key of PersonRole inserted row
		/// </summary>
		public bool InsertNewPersonRole( ref int personRoleId,  int roleId,  int personId,  DateTime modifiedDate)
		{
            try
            {
                DbCommand command = Database.GetStoredProcCommand("InsertNewPersonRole");
                Database.AddOutParameter(command, "PersonRoleId", DbType.Int32, Int32.MaxValue);
                Database.AddInParameter(command, "RoleId", DbType.Int32, roleId);
                Database.AddInParameter(command, "PersonId", DbType.Int32, personId);
                Database.AddInParameter(command, "ModifiedDate", DbType.DateTime, modifiedDate);
                bool _status = false;
                if (Database.ExecuteNonQuery(command) > 0)
                {
                    _status = true; personRoleId = Convert.ToInt32(Database.GetParameterValue(command, "PersonRoleId"));
                }
                return _status;
            }
            catch(Exception ex)
            {
                return false;
            }
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonRole using Stored Procedure
		/// and return the auto number primary key of PersonRole inserted row using Transaction
		/// </summary>
		public bool InsertNewPersonRole( ref int personRoleId,  int roleId,  int personId,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonRole");
				Database.AddOutParameter(command,"PersonRoleId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"RoleId",DbType.Int32,roleId);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 personRoleId = Convert.ToInt32(Database.GetParameterValue(command, "PersonRoleId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for PersonRole using Stored Procedure
		/// and return DbCommand of the PersonRole
		/// </summary>
		public DbCommand InsertNewPersonRoleCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonRole");

				Database.AddInParameter(command,"RoleId",DbType.Int32,"RoleId",DataRowVersion.Current);
				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonRole using Stored Procedure
		/// </summary>
		public bool UpdatePersonRole( int roleId, int personId, DateTime modifiedDate, int oldpersonRoleId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonRole");

		    		Database.AddInParameter(command,"RoleId",DbType.Int32,roleId);
		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldPersonRoleId",DbType.Int32,oldpersonRoleId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonRole using Stored Procedure By Transaction
		/// </summary>
		public bool UpdatePersonRole( int roleId, int personId, DateTime modifiedDate, int oldpersonRoleId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonRole");

		    		Database.AddInParameter(command,"RoleId",DbType.Int32,roleId);
		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldPersonRoleId",DbType.Int32,oldpersonRoleId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from PersonRole using Stored Procedure
		/// </summary>
		public DbCommand UpdatePersonRoleCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonRole");

		    		Database.AddInParameter(command,"RoleId",DbType.Int32,"RoleId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldPersonRoleId",DbType.Int32,"PersonRoleId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From PersonRole using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePersonRole( int personRoleId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePersonRole");
			Database.AddInParameter(command,"PersonRoleId",DbType.Int32,personRoleId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From PersonRole Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePersonRoleCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePersonRole");
				Database.AddInParameter(command,"PersonRoleId",DbType.Int32,"PersonRoleId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonRole using Stored Procedure
		/// and return number of rows effected of the PersonRole
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonRole",InsertNewPersonRoleCommand(),UpdatePersonRoleCommand(),DeletePersonRoleCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonRole using Stored Procedure
		/// and return number of rows effected of the PersonRole
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonRole",InsertNewPersonRoleCommand(),UpdatePersonRoleCommand(),DeletePersonRoleCommand(), transaction);
          return rowsAffected;
		}


	}
}
