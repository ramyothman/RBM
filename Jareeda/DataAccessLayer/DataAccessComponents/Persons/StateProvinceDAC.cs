using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for StateProvince table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the StateProvince table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class StateProvinceDAC : DataAccessComponent
	{
		#region Constructors
        public StateProvinceDAC() : base("", "Person.StateProvince") { }
		public StateProvinceDAC(string connectionString): base(connectionString){}
		public StateProvinceDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all StateProvince using Stored Procedure
		/// and return a DataTable containing all StateProvince Data
		/// </summary>
		public DataTable GetAllStateProvince()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "StateProvince";
         string query = " select * from GetAllStateProvince";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["StateProvince"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all StateProvince using Stored Procedure
		/// and return a DataTable containing all StateProvince Data using a Transaction
		/// </summary>
		public DataTable GetAllStateProvince(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "StateProvince";
         string query = " select * from GetAllStateProvince";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["StateProvince"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all StateProvince using Stored Procedure
		/// and return a DataTable containing all StateProvince Data
		/// </summary>
		public DataTable GetAllStateProvince(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "StateProvince";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllStateProvince" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["StateProvince"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all StateProvince using Stored Procedure
		/// and return a DataTable containing all StateProvince Data using a Transaction
		/// </summary>
		public DataTable GetAllStateProvince(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "StateProvince";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllStateProvince" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["StateProvince"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From StateProvince using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDStateProvince( int stateProvinceId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDStateProvince");
				    Database.AddInParameter(command,"StateProvinceId",DbType.Int32,stateProvinceId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From StateProvince using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDStateProvince( int stateProvinceId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDStateProvince");
				    Database.AddInParameter(command,"StateProvinceId",DbType.Int32,stateProvinceId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into StateProvince using Stored Procedure
		/// and return the auto number primary key of StateProvince inserted row
		/// </summary>
		public bool InsertNewStateProvince( ref int stateProvinceId,  string stateProvinceCode,  string countryRegionCode,  bool isOnlyStateProvince,  string name,  Guid rowGuid,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewStateProvince");
				Database.AddOutParameter(command,"StateProvinceId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"StateProvinceCode",DbType.String,stateProvinceCode);
				Database.AddInParameter(command,"CountryRegionCode",DbType.String,countryRegionCode);
				Database.AddInParameter(command,"IsOnlyStateProvince",DbType.Boolean,isOnlyStateProvince);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 stateProvinceId = Convert.ToInt32(Database.GetParameterValue(command, "StateProvinceId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into StateProvince using Stored Procedure
		/// and return the auto number primary key of StateProvince inserted row using Transaction
		/// </summary>
		public bool InsertNewStateProvince( ref int stateProvinceId,  string stateProvinceCode,  string countryRegionCode,  bool isOnlyStateProvince,  string name,  Guid rowGuid,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewStateProvince");
				Database.AddOutParameter(command,"StateProvinceId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"StateProvinceCode",DbType.String,stateProvinceCode);
				Database.AddInParameter(command,"CountryRegionCode",DbType.String,countryRegionCode);
				Database.AddInParameter(command,"IsOnlyStateProvince",DbType.Boolean,isOnlyStateProvince);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 stateProvinceId = Convert.ToInt32(Database.GetParameterValue(command, "StateProvinceId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for StateProvince using Stored Procedure
		/// and return DbCommand of the StateProvince
		/// </summary>
		public DbCommand InsertNewStateProvinceCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewStateProvince");

				Database.AddInParameter(command,"StateProvinceCode",DbType.String,"StateProvinceCode",DataRowVersion.Current);
				Database.AddInParameter(command,"CountryRegionCode",DbType.String,"CountryRegionCode",DataRowVersion.Current);
				Database.AddInParameter(command,"IsOnlyStateProvince",DbType.Boolean,"IsOnlyStateProvince",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into StateProvince using Stored Procedure
		/// </summary>
		public bool UpdateStateProvince( string stateProvinceCode, string countryRegionCode, bool isOnlyStateProvince, string name, Guid rowGuid, DateTime modifiedDate, int oldstateProvinceId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateStateProvince");

		    		Database.AddInParameter(command,"StateProvinceCode",DbType.String,stateProvinceCode);
		    		Database.AddInParameter(command,"CountryRegionCode",DbType.String,countryRegionCode);
		    		Database.AddInParameter(command,"IsOnlyStateProvince",DbType.Boolean,isOnlyStateProvince);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldStateProvinceId",DbType.Int32,oldstateProvinceId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into StateProvince using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateStateProvince( string stateProvinceCode, string countryRegionCode, bool isOnlyStateProvince, string name, Guid rowGuid, DateTime modifiedDate, int oldstateProvinceId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateStateProvince");

		    		Database.AddInParameter(command,"StateProvinceCode",DbType.String,stateProvinceCode);
		    		Database.AddInParameter(command,"CountryRegionCode",DbType.String,countryRegionCode);
		    		Database.AddInParameter(command,"IsOnlyStateProvince",DbType.Boolean,isOnlyStateProvince);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldStateProvinceId",DbType.Int32,oldstateProvinceId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from StateProvince using Stored Procedure
		/// </summary>
		public DbCommand UpdateStateProvinceCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateStateProvince");

		    		Database.AddInParameter(command,"StateProvinceCode",DbType.String,"StateProvinceCode",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CountryRegionCode",DbType.String,"CountryRegionCode",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsOnlyStateProvince",DbType.Boolean,"IsOnlyStateProvince",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldStateProvinceId",DbType.Int32,"StateProvinceId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From StateProvince using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteStateProvince( int stateProvinceId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteStateProvince");
			Database.AddInParameter(command,"StateProvinceId",DbType.Int32,stateProvinceId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From StateProvince Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteStateProvinceCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteStateProvince");
				Database.AddInParameter(command,"StateProvinceId",DbType.Int32,"StateProvinceId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table StateProvince using Stored Procedure
		/// and return number of rows effected of the StateProvince
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"StateProvince",InsertNewStateProvinceCommand(),UpdateStateProvinceCommand(),DeleteStateProvinceCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table StateProvince using Stored Procedure
		/// and return number of rows effected of the StateProvince
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"StateProvince",InsertNewStateProvinceCommand(),UpdateStateProvinceCommand(),DeleteStateProvinceCommand(), transaction);
          return rowsAffected;
		}


	}
}
