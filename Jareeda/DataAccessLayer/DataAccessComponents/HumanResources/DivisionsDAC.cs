using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.HumanResources
{
	/// <summary>
	/// This is a Data Access Class  for Divisions table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Divisions table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class DivisionsDAC : DataAccessComponent
	{
		#region Constructors
        public DivisionsDAC() : base("", "HumanResources.Divisions") { }
		public DivisionsDAC(string connectionString): base(connectionString){}
		public DivisionsDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Divisions using Stored Procedure
		/// and return a DataTable containing all Divisions Data
		/// </summary>
		public DataTable GetAllDivisions()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Divisions";
         string query = " select * from GetAllDivisions";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Divisions"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Divisions using Stored Procedure
		/// and return a DataTable containing all Divisions Data using a Transaction
		/// </summary>
		public DataTable GetAllDivisions(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Divisions";
         string query = " select * from GetAllDivisions";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Divisions"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Divisions using Stored Procedure
		/// and return a DataTable containing all Divisions Data
		/// </summary>
		public DataTable GetAllDivisions(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Divisions";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllDivisions" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Divisions"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Divisions using Stored Procedure
		/// and return a DataTable containing all Divisions Data using a Transaction
		/// </summary>
		public DataTable GetAllDivisions(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Divisions";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllDivisions" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Divisions"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Divisions using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDDivisions( int divisionId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDDivisions");
				    Database.AddInParameter(command,"DivisionId",DbType.Int32,divisionId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Divisions using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDDivisions( int divisionId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDDivisions");
				    Database.AddInParameter(command,"DivisionId",DbType.Int32,divisionId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Divisions using Stored Procedure
		/// and return the auto number primary key of Divisions inserted row
		/// </summary>
		public bool InsertNewDivisions( ref int divisionId,  int departmentId,  string divisionName,  string divisionDescription,  string phone1,  string phone2,  string fax1,  string fax2)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewDivisions");
				Database.AddOutParameter(command,"DivisionId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"DepartmentId",DbType.Int32,departmentId);
				Database.AddInParameter(command,"DivisionName",DbType.String,divisionName);
				Database.AddInParameter(command,"DivisionDescription",DbType.String,divisionDescription);
				Database.AddInParameter(command,"Phone1",DbType.String,phone1);
				Database.AddInParameter(command,"Phone2",DbType.String,phone2);
				Database.AddInParameter(command,"Fax1",DbType.String,fax1);
				Database.AddInParameter(command,"Fax2",DbType.String,fax2);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 divisionId = Convert.ToInt32(Database.GetParameterValue(command, "DivisionId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Divisions using Stored Procedure
		/// and return the auto number primary key of Divisions inserted row using Transaction
		/// </summary>
		public bool InsertNewDivisions( ref int divisionId,  int departmentId,  string divisionName,  string divisionDescription,  string phone1,  string phone2,  string fax1,  string fax2,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewDivisions");
				Database.AddOutParameter(command,"DivisionId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"DepartmentId",DbType.Int32,departmentId);
				Database.AddInParameter(command,"DivisionName",DbType.String,divisionName);
				Database.AddInParameter(command,"DivisionDescription",DbType.String,divisionDescription);
				Database.AddInParameter(command,"Phone1",DbType.String,phone1);
				Database.AddInParameter(command,"Phone2",DbType.String,phone2);
				Database.AddInParameter(command,"Fax1",DbType.String,fax1);
				Database.AddInParameter(command,"Fax2",DbType.String,fax2);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 divisionId = Convert.ToInt32(Database.GetParameterValue(command, "DivisionId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Divisions using Stored Procedure
		/// and return DbCommand of the Divisions
		/// </summary>
		public DbCommand InsertNewDivisionsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewDivisions");

				Database.AddInParameter(command,"DepartmentId",DbType.Int32,"DepartmentId",DataRowVersion.Current);
				Database.AddInParameter(command,"DivisionName",DbType.String,"DivisionName",DataRowVersion.Current);
				Database.AddInParameter(command,"DivisionDescription",DbType.String,"DivisionDescription",DataRowVersion.Current);
				Database.AddInParameter(command,"Phone1",DbType.String,"Phone1",DataRowVersion.Current);
				Database.AddInParameter(command,"Phone2",DbType.String,"Phone2",DataRowVersion.Current);
				Database.AddInParameter(command,"Fax1",DbType.String,"Fax1",DataRowVersion.Current);
				Database.AddInParameter(command,"Fax2",DbType.String,"Fax2",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Divisions using Stored Procedure
		/// </summary>
		public bool UpdateDivisions( int departmentId, string divisionName, string divisionDescription, string phone1, string phone2, string fax1, string fax2, int olddivisionId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateDivisions");

		    		Database.AddInParameter(command,"DepartmentId",DbType.Int32,departmentId);
		    		Database.AddInParameter(command,"DivisionName",DbType.String,divisionName);
		    		Database.AddInParameter(command,"DivisionDescription",DbType.String,divisionDescription);
		    		Database.AddInParameter(command,"Phone1",DbType.String,phone1);
		    		Database.AddInParameter(command,"Phone2",DbType.String,phone2);
		    		Database.AddInParameter(command,"Fax1",DbType.String,fax1);
		    		Database.AddInParameter(command,"Fax2",DbType.String,fax2);
				Database.AddInParameter(command,"oldDivisionId",DbType.Int32,olddivisionId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Divisions using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateDivisions( int departmentId, string divisionName, string divisionDescription, string phone1, string phone2, string fax1, string fax2, int olddivisionId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateDivisions");

		    		Database.AddInParameter(command,"DepartmentId",DbType.Int32,departmentId);
		    		Database.AddInParameter(command,"DivisionName",DbType.String,divisionName);
		    		Database.AddInParameter(command,"DivisionDescription",DbType.String,divisionDescription);
		    		Database.AddInParameter(command,"Phone1",DbType.String,phone1);
		    		Database.AddInParameter(command,"Phone2",DbType.String,phone2);
		    		Database.AddInParameter(command,"Fax1",DbType.String,fax1);
		    		Database.AddInParameter(command,"Fax2",DbType.String,fax2);
				Database.AddInParameter(command,"oldDivisionId",DbType.Int32,olddivisionId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Divisions using Stored Procedure
		/// </summary>
		public DbCommand UpdateDivisionsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateDivisions");

		    		Database.AddInParameter(command,"DepartmentId",DbType.Int32,"DepartmentId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DivisionName",DbType.String,"DivisionName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DivisionDescription",DbType.String,"DivisionDescription",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Phone1",DbType.String,"Phone1",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Phone2",DbType.String,"Phone2",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Fax1",DbType.String,"Fax1",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Fax2",DbType.String,"Fax2",DataRowVersion.Current);
				Database.AddInParameter(command,"oldDivisionId",DbType.Int32,"DivisionId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Divisions using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteDivisions( int divisionId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteDivisions");
			Database.AddInParameter(command,"DivisionId",DbType.Int32,divisionId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Divisions Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteDivisionsCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteDivisions");
				Database.AddInParameter(command,"DivisionId",DbType.Int32,"DivisionId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Divisions using Stored Procedure
		/// and return number of rows effected of the Divisions
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Divisions",InsertNewDivisionsCommand(),UpdateDivisionsCommand(),DeleteDivisionsCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Divisions using Stored Procedure
		/// and return number of rows effected of the Divisions
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Divisions",InsertNewDivisionsCommand(),UpdateDivisionsCommand(),DeleteDivisionsCommand(), transaction);
          return rowsAffected;
		}


	}
}
