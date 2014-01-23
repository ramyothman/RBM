using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for VenuesLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the VenuesLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class VenuesLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public VenuesLanguageDAC() : base("", "Conference.VenuesLanguage") { }
		public VenuesLanguageDAC(string connectionString): base(connectionString){}
		public VenuesLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all VenuesLanguage using Stored Procedure
		/// and return a DataTable containing all VenuesLanguage Data
		/// </summary>
		public DataTable GetAllVenuesLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "VenuesLanguage";
         string query = " select * from GetAllVenuesLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["VenuesLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all VenuesLanguage using Stored Procedure
		/// and return a DataTable containing all VenuesLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllVenuesLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "VenuesLanguage";
         string query = " select * from GetAllVenuesLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["VenuesLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all VenuesLanguage using Stored Procedure
		/// and return a DataTable containing all VenuesLanguage Data
		/// </summary>
		public DataTable GetAllVenuesLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "VenuesLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllVenuesLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["VenuesLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all VenuesLanguage using Stored Procedure
		/// and return a DataTable containing all VenuesLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllVenuesLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "VenuesLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllVenuesLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["VenuesLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From VenuesLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDVenuesLanguage( int iD)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDVenuesLanguage");
				    Database.AddInParameter(command,"ID",DbType.Int32,iD);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From VenuesLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDVenuesLanguage( int iD,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDVenuesLanguage");
				    Database.AddInParameter(command,"ID",DbType.Int32,iD);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into VenuesLanguage using Stored Procedure
		/// and return the auto number primary key of VenuesLanguage inserted row
		/// </summary>
		public bool InsertNewVenuesLanguage( ref int iD,  string name,  string description,  string location,  int star,  string uRL,  string phone,  string fax,  string email,  int languageID,  int parentID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewVenuesLanguage");
				Database.AddOutParameter(command,"ID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"Location",DbType.String,location);
				Database.AddInParameter(command,"Star",DbType.Int32,star);
				Database.AddInParameter(command,"URL",DbType.String,uRL);
				Database.AddInParameter(command,"Phone",DbType.String,phone);
				Database.AddInParameter(command,"Fax",DbType.String,fax);
				Database.AddInParameter(command,"Email",DbType.String,email);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"parentID",DbType.Int32,parentID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into VenuesLanguage using Stored Procedure
		/// and return the auto number primary key of VenuesLanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewVenuesLanguage( ref int iD,  string name,  string description,  string location,  int star,  string uRL,  string phone,  string fax,  string email,  int languageID,  int parentID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewVenuesLanguage");
				Database.AddOutParameter(command,"ID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"Location",DbType.String,location);
				Database.AddInParameter(command,"Star",DbType.Int32,star);
				Database.AddInParameter(command,"URL",DbType.String,uRL);
				Database.AddInParameter(command,"Phone",DbType.String,phone);
				Database.AddInParameter(command,"Fax",DbType.String,fax);
				Database.AddInParameter(command,"Email",DbType.String,email);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"parentID",DbType.Int32,parentID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for VenuesLanguage using Stored Procedure
		/// and return DbCommand of the VenuesLanguage
		/// </summary>
		public DbCommand InsertNewVenuesLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewVenuesLanguage");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
				Database.AddInParameter(command,"Location",DbType.String,"Location",DataRowVersion.Current);
				Database.AddInParameter(command,"Star",DbType.Int32,"Star",DataRowVersion.Current);
				Database.AddInParameter(command,"URL",DbType.String,"URL",DataRowVersion.Current);
				Database.AddInParameter(command,"Phone",DbType.String,"Phone",DataRowVersion.Current);
				Database.AddInParameter(command,"Fax",DbType.String,"Fax",DataRowVersion.Current);
				Database.AddInParameter(command,"Email",DbType.String,"Email",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"parentID",DbType.Int32,"parentID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into VenuesLanguage using Stored Procedure
		/// </summary>
		public bool UpdateVenuesLanguage( string name, string description, string location, int star, string uRL, string phone, string fax, string email, int languageID, int parentID, int oldiD)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateVenuesLanguage");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"Location",DbType.String,location);
		    		Database.AddInParameter(command,"Star",DbType.Int32,star);
		    		Database.AddInParameter(command,"URL",DbType.String,uRL);
		    		Database.AddInParameter(command,"Phone",DbType.String,phone);
		    		Database.AddInParameter(command,"Fax",DbType.String,fax);
		    		Database.AddInParameter(command,"Email",DbType.String,email);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"parentID",DbType.Int32,parentID);
				Database.AddInParameter(command,"oldID",DbType.Int32,oldiD);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into VenuesLanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateVenuesLanguage( string name, string description, string location, int star, string uRL, string phone, string fax, string email, int languageID, int parentID, int oldiD,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateVenuesLanguage");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"Location",DbType.String,location);
		    		Database.AddInParameter(command,"Star",DbType.Int32,star);
		    		Database.AddInParameter(command,"URL",DbType.String,uRL);
		    		Database.AddInParameter(command,"Phone",DbType.String,phone);
		    		Database.AddInParameter(command,"Fax",DbType.String,fax);
		    		Database.AddInParameter(command,"Email",DbType.String,email);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"parentID",DbType.Int32,parentID);
				Database.AddInParameter(command,"oldID",DbType.Int32,oldiD);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from VenuesLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateVenuesLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateVenuesLanguage");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Location",DbType.String,"Location",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Star",DbType.Int32,"Star",DataRowVersion.Current);
		    		Database.AddInParameter(command,"URL",DbType.String,"URL",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Phone",DbType.String,"Phone",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Fax",DbType.String,"Fax",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Email",DbType.String,"Email",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"parentID",DbType.Int32,"parentID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldID",DbType.Int32,"ID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From VenuesLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteVenuesLanguage( int iD)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteVenuesLanguage");
			Database.AddInParameter(command,"ID",DbType.Int32,iD);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From VenuesLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteVenuesLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteVenuesLanguage");
				Database.AddInParameter(command,"ID",DbType.Int32,"ID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table VenuesLanguage using Stored Procedure
		/// and return number of rows effected of the VenuesLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"VenuesLanguage",InsertNewVenuesLanguageCommand(),UpdateVenuesLanguageCommand(),DeleteVenuesLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table VenuesLanguage using Stored Procedure
		/// and return number of rows effected of the VenuesLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"VenuesLanguage",InsertNewVenuesLanguageCommand(),UpdateVenuesLanguageCommand(),DeleteVenuesLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
