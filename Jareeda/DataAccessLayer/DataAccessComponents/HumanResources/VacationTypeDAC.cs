using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.HumanResources
{
	/// <summary>
	/// This is a Data Access Class  for VacationType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the VacationType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class VacationTypeDAC : DataAccessComponent
	{
		#region Constructors
        public VacationTypeDAC() : base("", "HumanResources.VacationType") { }
		public VacationTypeDAC(string connectionString): base(connectionString){}
		public VacationTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all VacationType using Stored Procedure
		/// and return a DataTable containing all VacationType Data
		/// </summary>
		public DataTable GetAllVacationType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "VacationType";
         string query = " select * from GetAllVacationType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["VacationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all VacationType using Stored Procedure
		/// and return a DataTable containing all VacationType Data using a Transaction
		/// </summary>
		public DataTable GetAllVacationType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "VacationType";
         string query = " select * from GetAllVacationType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["VacationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all VacationType using Stored Procedure
		/// and return a DataTable containing all VacationType Data
		/// </summary>
		public DataTable GetAllVacationType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "VacationType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllVacationType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["VacationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all VacationType using Stored Procedure
		/// and return a DataTable containing all VacationType Data using a Transaction
		/// </summary>
		public DataTable GetAllVacationType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "VacationType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllVacationType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["VacationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From VacationType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDVacationType( int vacationTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDVacationType");
				    Database.AddInParameter(command,"VacationTypeID",DbType.Int32,vacationTypeID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From VacationType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDVacationType( int vacationTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDVacationType");
				    Database.AddInParameter(command,"VacationTypeID",DbType.Int32,vacationTypeID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into VacationType using Stored Procedure
		/// and return the auto number primary key of VacationType inserted row
		/// </summary>
		public bool InsertNewVacationType( ref int vacationTypeID,  string name)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewVacationType");
				Database.AddOutParameter(command,"VacationTypeID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 vacationTypeID = Convert.ToInt32(Database.GetParameterValue(command, "VacationTypeID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into VacationType using Stored Procedure
		/// and return the auto number primary key of VacationType inserted row using Transaction
		/// </summary>
		public bool InsertNewVacationType( ref int vacationTypeID,  string name,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewVacationType");
				Database.AddOutParameter(command,"VacationTypeID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 vacationTypeID = Convert.ToInt32(Database.GetParameterValue(command, "VacationTypeID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for VacationType using Stored Procedure
		/// and return DbCommand of the VacationType
		/// </summary>
		public DbCommand InsertNewVacationTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewVacationType");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into VacationType using Stored Procedure
		/// </summary>
		public bool UpdateVacationType( string name, int oldvacationTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateVacationType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldVacationTypeID",DbType.Int32,oldvacationTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into VacationType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateVacationType( string name, int oldvacationTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateVacationType");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldVacationTypeID",DbType.Int32,oldvacationTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from VacationType using Stored Procedure
		/// </summary>
		public DbCommand UpdateVacationTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateVacationType");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"oldVacationTypeID",DbType.Int32,"VacationTypeID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From VacationType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteVacationType( int vacationTypeID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteVacationType");
			Database.AddInParameter(command,"VacationTypeID",DbType.Int32,vacationTypeID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From VacationType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteVacationTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteVacationType");
				Database.AddInParameter(command,"VacationTypeID",DbType.Int32,"VacationTypeID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table VacationType using Stored Procedure
		/// and return number of rows effected of the VacationType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"VacationType",InsertNewVacationTypeCommand(),UpdateVacationTypeCommand(),DeleteVacationTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table VacationType using Stored Procedure
		/// and return number of rows effected of the VacationType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"VacationType",InsertNewVacationTypeCommand(),UpdateVacationTypeCommand(),DeleteVacationTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
