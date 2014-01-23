using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for CountryRegion table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the CountryRegion table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class CountryRegionDAC : DataAccessComponent
	{
		#region Constructors
        public CountryRegionDAC() : base("", "Person.CountryRegion") { }
		public CountryRegionDAC(string connectionString): base(connectionString){}
		public CountryRegionDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all CountryRegion using Stored Procedure
		/// and return a DataTable containing all CountryRegion Data
		/// </summary>
		public DataTable GetAllCountryRegion()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "CountryRegion";
         string query = " select * from GetAllCountryRegion";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["CountryRegion"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all CountryRegion using Stored Procedure
		/// and return a DataTable containing all CountryRegion Data using a Transaction
		/// </summary>
		public DataTable GetAllCountryRegion(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "CountryRegion";
         string query = " select * from GetAllCountryRegion";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["CountryRegion"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all CountryRegion using Stored Procedure
		/// and return a DataTable containing all CountryRegion Data
		/// </summary>
		public DataTable GetAllCountryRegion(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "CountryRegion";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllCountryRegion" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["CountryRegion"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all CountryRegion using Stored Procedure
		/// and return a DataTable containing all CountryRegion Data using a Transaction
		/// </summary>
		public DataTable GetAllCountryRegion(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "CountryRegion";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllCountryRegion" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["CountryRegion"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From CountryRegion using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDCountryRegion( string countryRegionCode)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDCountryRegion");
				    Database.AddInParameter(command,"CountryRegionCode",DbType.String,countryRegionCode);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From CountryRegion using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDCountryRegion( string countryRegionCode,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDCountryRegion");
				    Database.AddInParameter(command,"CountryRegionCode",DbType.String,countryRegionCode);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into CountryRegion using Stored Procedure
		/// and return the auto number primary key of CountryRegion inserted row
		/// </summary>
		public bool InsertNewCountryRegion( string countryRegionCode,  string name,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewCountryRegion");
				Database.AddInParameter(command,"CountryRegionCode",DbType.String,countryRegionCode);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into CountryRegion using Stored Procedure
		/// and return the auto number primary key of CountryRegion inserted row using Transaction
		/// </summary>
		public bool InsertNewCountryRegion( string countryRegionCode,  string name,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewCountryRegion");
				Database.AddInParameter(command,"CountryRegionCode",DbType.String,countryRegionCode);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for CountryRegion using Stored Procedure
		/// and return DbCommand of the CountryRegion
		/// </summary>
		public DbCommand InsertNewCountryRegionCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewCountryRegion");
				Database.AddInParameter(command,"CountryRegionCode",DbType.String,"CountryRegionCode",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into CountryRegion using Stored Procedure
		/// </summary>
		public bool UpdateCountryRegion( string countryRegionCode, string name, DateTime modifiedDate, string oldcountryRegionCode)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateCountryRegion");
		    		Database.AddInParameter(command,"CountryRegionCode",DbType.String,countryRegionCode);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldCountryRegionCode",DbType.String,oldcountryRegionCode);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into CountryRegion using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateCountryRegion( string countryRegionCode, string name, DateTime modifiedDate, string oldcountryRegionCode,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateCountryRegion");
		    		Database.AddInParameter(command,"CountryRegionCode",DbType.String,countryRegionCode);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldCountryRegionCode",DbType.String,oldcountryRegionCode);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from CountryRegion using Stored Procedure
		/// </summary>
		public DbCommand UpdateCountryRegionCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateCountryRegion");
		    		Database.AddInParameter(command,"CountryRegionCode",DbType.String,"CountryRegionCode",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldCountryRegionCode",DbType.String,"CountryRegionCode",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From CountryRegion using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteCountryRegion( string countryRegionCode)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteCountryRegion");
			Database.AddInParameter(command,"CountryRegionCode",DbType.String,countryRegionCode);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From CountryRegion Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteCountryRegionCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteCountryRegion");
				Database.AddInParameter(command,"CountryRegionCode",DbType.String,"CountryRegionCode",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table CountryRegion using Stored Procedure
		/// and return number of rows effected of the CountryRegion
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"CountryRegion",InsertNewCountryRegionCommand(),UpdateCountryRegionCommand(),DeleteCountryRegionCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table CountryRegion using Stored Procedure
		/// and return number of rows effected of the CountryRegion
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"CountryRegion",InsertNewCountryRegionCommand(),UpdateCountryRegionCommand(),DeleteCountryRegionCommand(), transaction);
          return rowsAffected;
		}


	}
}
