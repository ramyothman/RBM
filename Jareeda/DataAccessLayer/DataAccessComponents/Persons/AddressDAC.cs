using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for Address table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Address table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class AddressDAC : DataAccessComponent
	{
		#region Constructors
        public AddressDAC() : base("", "Person.Address") { }
		public AddressDAC(string connectionString): base(connectionString){}
		public AddressDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Address using Stored Procedure
		/// and return a DataTable containing all Address Data
		/// </summary>
		public DataTable GetAllAddress()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Address";
         string query = " select * from GetAllAddress";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Address"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Address using Stored Procedure
		/// and return a DataTable containing all Address Data using a Transaction
		/// </summary>
		public DataTable GetAllAddress(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Address";
         string query = " select * from GetAllAddress";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Address"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Address using Stored Procedure
		/// and return a DataTable containing all Address Data
		/// </summary>
		public DataTable GetAllAddress(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Address";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllAddress" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Address"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Address using Stored Procedure
		/// and return a DataTable containing all Address Data using a Transaction
		/// </summary>
		public DataTable GetAllAddress(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Address";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllAddress" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Address"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Address using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAddress( int addressId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAddress");
				    Database.AddInParameter(command,"AddressId",DbType.Int32,addressId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Address using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAddress( int addressId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAddress");
				    Database.AddInParameter(command,"AddressId",DbType.Int32,addressId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Address using Stored Procedure
		/// and return the auto number primary key of Address inserted row
		/// </summary>
		public bool InsertNewAddress( ref int addressId,  string addressLine1,  string addressLine2,  string addressLine3,  string countryRegionCode,  string city,  int stateProvinceId,  string postalCode,  string zipCode,  string spatialLocation,  Guid rowGuid,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAddress");
				Database.AddOutParameter(command,"AddressId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
				Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
				Database.AddInParameter(command,"AddressLine3",DbType.String,addressLine3);
				Database.AddInParameter(command,"CountryRegionCode",DbType.String,countryRegionCode);
				Database.AddInParameter(command,"City",DbType.String,city);
				Database.AddInParameter(command,"StateProvinceId",DbType.Int32,stateProvinceId);
				Database.AddInParameter(command,"PostalCode",DbType.String,postalCode);
				Database.AddInParameter(command,"ZipCode",DbType.String,zipCode);
				Database.AddInParameter(command,"SpatialLocation",DbType.String,spatialLocation);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 addressId = Convert.ToInt32(Database.GetParameterValue(command, "AddressId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Address using Stored Procedure
		/// and return the auto number primary key of Address inserted row using Transaction
		/// </summary>
		public bool InsertNewAddress( ref int addressId,  string addressLine1,  string addressLine2,  string addressLine3,  string countryRegionCode,  string city,  int stateProvinceId,  string postalCode,  string zipCode,  string spatialLocation,  Guid rowGuid,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAddress");
				Database.AddOutParameter(command,"AddressId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
				Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
				Database.AddInParameter(command,"AddressLine3",DbType.String,addressLine3);
				Database.AddInParameter(command,"CountryRegionCode",DbType.String,countryRegionCode);
				Database.AddInParameter(command,"City",DbType.String,city);
				Database.AddInParameter(command,"StateProvinceId",DbType.Int32,stateProvinceId);
				Database.AddInParameter(command,"PostalCode",DbType.String,postalCode);
				Database.AddInParameter(command,"ZipCode",DbType.String,zipCode);
				Database.AddInParameter(command,"SpatialLocation",DbType.String,spatialLocation);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 addressId = Convert.ToInt32(Database.GetParameterValue(command, "AddressId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Address using Stored Procedure
		/// and return DbCommand of the Address
		/// </summary>
		public DbCommand InsertNewAddressCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAddress");

				Database.AddInParameter(command,"AddressLine1",DbType.String,"AddressLine1",DataRowVersion.Current);
				Database.AddInParameter(command,"AddressLine2",DbType.String,"AddressLine2",DataRowVersion.Current);
				Database.AddInParameter(command,"AddressLine3",DbType.String,"AddressLine3",DataRowVersion.Current);
				Database.AddInParameter(command,"CountryRegionCode",DbType.String,"CountryRegionCode",DataRowVersion.Current);
				Database.AddInParameter(command,"City",DbType.String,"City",DataRowVersion.Current);
				Database.AddInParameter(command,"StateProvinceId",DbType.Int32,"StateProvinceId",DataRowVersion.Current);
				Database.AddInParameter(command,"PostalCode",DbType.String,"PostalCode",DataRowVersion.Current);
				Database.AddInParameter(command,"ZipCode",DbType.String,"ZipCode",DataRowVersion.Current);
				Database.AddInParameter(command,"SpatialLocation",DbType.String,"SpatialLocation",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Address using Stored Procedure
		/// </summary>
		public bool UpdateAddress( string addressLine1, string addressLine2, string addressLine3, string countryRegionCode, string city, int stateProvinceId, string postalCode, string zipCode, string spatialLocation, Guid rowGuid, DateTime modifiedDate, int oldaddressId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAddress");

		    		Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
		    		Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
		    		Database.AddInParameter(command,"AddressLine3",DbType.String,addressLine3);
		    		Database.AddInParameter(command,"CountryRegionCode",DbType.String,countryRegionCode);
		    		Database.AddInParameter(command,"City",DbType.String,city);
		    		Database.AddInParameter(command,"StateProvinceId",DbType.Int32,stateProvinceId);
		    		Database.AddInParameter(command,"PostalCode",DbType.String,postalCode);
		    		Database.AddInParameter(command,"ZipCode",DbType.String,zipCode);
		    		Database.AddInParameter(command,"SpatialLocation",DbType.String,spatialLocation);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldAddressId",DbType.Int32,oldaddressId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Address using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateAddress( string addressLine1, string addressLine2, string addressLine3, string countryRegionCode, string city, int stateProvinceId, string postalCode, string zipCode, string spatialLocation, Guid rowGuid, DateTime modifiedDate, int oldaddressId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAddress");

		    		Database.AddInParameter(command,"AddressLine1",DbType.String,addressLine1);
		    		Database.AddInParameter(command,"AddressLine2",DbType.String,addressLine2);
		    		Database.AddInParameter(command,"AddressLine3",DbType.String,addressLine3);
		    		Database.AddInParameter(command,"CountryRegionCode",DbType.String,countryRegionCode);
		    		Database.AddInParameter(command,"City",DbType.String,city);
		    		Database.AddInParameter(command,"StateProvinceId",DbType.Int32,stateProvinceId);
		    		Database.AddInParameter(command,"PostalCode",DbType.String,postalCode);
		    		Database.AddInParameter(command,"ZipCode",DbType.String,zipCode);
		    		Database.AddInParameter(command,"SpatialLocation",DbType.String,spatialLocation);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldAddressId",DbType.Int32,oldaddressId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Address using Stored Procedure
		/// </summary>
		public DbCommand UpdateAddressCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAddress");

		    		Database.AddInParameter(command,"AddressLine1",DbType.String,"AddressLine1",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AddressLine2",DbType.String,"AddressLine2",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AddressLine3",DbType.String,"AddressLine3",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CountryRegionCode",DbType.String,"CountryRegionCode",DataRowVersion.Current);
		    		Database.AddInParameter(command,"City",DbType.String,"City",DataRowVersion.Current);
		    		Database.AddInParameter(command,"StateProvinceId",DbType.Int32,"StateProvinceId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PostalCode",DbType.String,"PostalCode",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ZipCode",DbType.String,"ZipCode",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SpatialLocation",DbType.String,"SpatialLocation",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldAddressId",DbType.Int32,"AddressId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Address using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteAddress( int addressId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteAddress");
			Database.AddInParameter(command,"AddressId",DbType.Int32,addressId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Address Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteAddressCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteAddress");
				Database.AddInParameter(command,"AddressId",DbType.Int32,"AddressId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Address using Stored Procedure
		/// and return number of rows effected of the Address
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Address",InsertNewAddressCommand(),UpdateAddressCommand(),DeleteAddressCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Address using Stored Procedure
		/// and return number of rows effected of the Address
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Address",InsertNewAddressCommand(),UpdateAddressCommand(),DeleteAddressCommand(), transaction);
          return rowsAffected;
		}


	}
}
