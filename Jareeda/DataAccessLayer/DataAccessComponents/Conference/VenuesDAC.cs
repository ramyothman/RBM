using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for Venues table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Venues table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class VenuesDAC : DataAccessComponent
	{
		#region Constructors
        public VenuesDAC() : base("", "Conference.Venues") { }
		public VenuesDAC(string connectionString): base(connectionString){}
		public VenuesDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Venues using Stored Procedure
		/// and return a DataTable containing all Venues Data
		/// </summary>
		public DataTable GetAllVenues()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Venues";
         string query = " select * from GetAllVenues";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Venues"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Venues using Stored Procedure
		/// and return a DataTable containing all Venues Data using a Transaction
		/// </summary>
		public DataTable GetAllVenues(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Venues";
         string query = " select * from GetAllVenues";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Venues"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Venues using Stored Procedure
		/// and return a DataTable containing all Venues Data
		/// </summary>
		public DataTable GetAllVenues(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Venues";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllVenues" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Venues"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Venues using Stored Procedure
		/// and return a DataTable containing all Venues Data using a Transaction
		/// </summary>
		public DataTable GetAllVenues(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Venues";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllVenues" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Venues"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Venues using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDVenues( int iD)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDVenues");
				    Database.AddInParameter(command,"ID",DbType.Int32,iD);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Venues using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDVenues( int iD,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDVenues");
				    Database.AddInParameter(command,"ID",DbType.Int32,iD);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Venues using Stored Procedure
		/// and return the auto number primary key of Venues inserted row
		/// </summary>
		public bool InsertNewVenues( ref int iD,  string name,  string description,  string location,  int star,  string uRL,  string phone,  string fax,  string email)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewVenues");
				Database.AddOutParameter(command,"ID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"Location",DbType.String,location);
				Database.AddInParameter(command,"Star",DbType.Int32,star);
				Database.AddInParameter(command,"URL",DbType.String,uRL);
				Database.AddInParameter(command,"Phone",DbType.String,phone);
				Database.AddInParameter(command,"Fax",DbType.String,fax);
				Database.AddInParameter(command,"Email",DbType.String,email);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Venues using Stored Procedure
		/// and return the auto number primary key of Venues inserted row using Transaction
		/// </summary>
		public bool InsertNewVenues( ref int iD,  string name,  string description,  string location,  int star,  string uRL,  string phone,  string fax,  string email,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewVenues");
				Database.AddOutParameter(command,"ID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"Location",DbType.String,location);
				Database.AddInParameter(command,"Star",DbType.Int32,star);
				Database.AddInParameter(command,"URL",DbType.String,uRL);
				Database.AddInParameter(command,"Phone",DbType.String,phone);
				Database.AddInParameter(command,"Fax",DbType.String,fax);
				Database.AddInParameter(command,"Email",DbType.String,email);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Venues using Stored Procedure
		/// and return DbCommand of the Venues
		/// </summary>
		public DbCommand InsertNewVenuesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewVenues");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
				Database.AddInParameter(command,"Location",DbType.String,"Location",DataRowVersion.Current);
				Database.AddInParameter(command,"Star",DbType.Int32,"Star",DataRowVersion.Current);
				Database.AddInParameter(command,"URL",DbType.String,"URL",DataRowVersion.Current);
				Database.AddInParameter(command,"Phone",DbType.String,"Phone",DataRowVersion.Current);
				Database.AddInParameter(command,"Fax",DbType.String,"Fax",DataRowVersion.Current);
				Database.AddInParameter(command,"Email",DbType.String,"Email",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Venues using Stored Procedure
		/// </summary>
		public bool UpdateVenues( string name, string description, string location, int star, string uRL, string phone, string fax, string email, int oldiD)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateVenues");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"Location",DbType.String,location);
		    		Database.AddInParameter(command,"Star",DbType.Int32,star);
		    		Database.AddInParameter(command,"URL",DbType.String,uRL);
		    		Database.AddInParameter(command,"Phone",DbType.String,phone);
		    		Database.AddInParameter(command,"Fax",DbType.String,fax);
		    		Database.AddInParameter(command,"Email",DbType.String,email);
				Database.AddInParameter(command,"oldID",DbType.Int32,oldiD);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Venues using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateVenues( string name, string description, string location, int star, string uRL, string phone, string fax, string email, int oldiD,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateVenues");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"Location",DbType.String,location);
		    		Database.AddInParameter(command,"Star",DbType.Int32,star);
		    		Database.AddInParameter(command,"URL",DbType.String,uRL);
		    		Database.AddInParameter(command,"Phone",DbType.String,phone);
		    		Database.AddInParameter(command,"Fax",DbType.String,fax);
		    		Database.AddInParameter(command,"Email",DbType.String,email);
				Database.AddInParameter(command,"oldID",DbType.Int32,oldiD);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Venues using Stored Procedure
		/// </summary>
		public DbCommand UpdateVenuesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateVenues");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Location",DbType.String,"Location",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Star",DbType.Int32,"Star",DataRowVersion.Current);
		    		Database.AddInParameter(command,"URL",DbType.String,"URL",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Phone",DbType.String,"Phone",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Fax",DbType.String,"Fax",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Email",DbType.String,"Email",DataRowVersion.Current);
				Database.AddInParameter(command,"oldID",DbType.Int32,"ID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Venues using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteVenues( int iD)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteVenues");
			Database.AddInParameter(command,"ID",DbType.Int32,iD);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Venues Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteVenuesCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteVenues");
				Database.AddInParameter(command,"ID",DbType.Int32,"ID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Venues using Stored Procedure
		/// and return number of rows effected of the Venues
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Venues",InsertNewVenuesCommand(),UpdateVenuesCommand(),DeleteVenuesCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Venues using Stored Procedure
		/// and return number of rows effected of the Venues
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Venues",InsertNewVenuesCommand(),UpdateVenuesCommand(),DeleteVenuesCommand(), transaction);
          return rowsAffected;
		}


	}
}
