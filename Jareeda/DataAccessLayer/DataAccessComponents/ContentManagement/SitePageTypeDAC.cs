using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for SitePageType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the SitePageType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SitePageTypeDAC : DataAccessComponent
	{
		#region Constructors
        public SitePageTypeDAC() : base("", "ContentManagement.SitePageType") { }
		public SitePageTypeDAC(string connectionString): base(connectionString){}
		public SitePageTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageType using Stored Procedure
		/// and return a DataTable containing all SitePageType Data
		/// </summary>
		public DataTable GetAllSitePageType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageType";
         string query = " select * from GetAllSitePageType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SitePageType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageType using Stored Procedure
		/// and return a DataTable containing all SitePageType Data using a Transaction
		/// </summary>
		public DataTable GetAllSitePageType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageType";
         string query = " select * from GetAllSitePageType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SitePageType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageType using Stored Procedure
		/// and return a DataTable containing all SitePageType Data
		/// </summary>
		public DataTable GetAllSitePageType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSitePageType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SitePageType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SitePageType using Stored Procedure
		/// and return a DataTable containing all SitePageType Data using a Transaction
		/// </summary>
		public DataTable GetAllSitePageType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SitePageType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSitePageType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SitePageType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SitePageType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSitePageType( int sitePageTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSitePageType");
				    Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,sitePageTypeID);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SitePageType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSitePageType( int sitePageTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSitePageType");
				    Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,sitePageTypeID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SitePageType using Stored Procedure
		/// and return the auto number primary key of SitePageType inserted row
		/// </summary>
		public bool InsertNewSitePageType( int sitePageTypeID,  string name)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePageType");
				Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,sitePageTypeID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SitePageType using Stored Procedure
		/// and return the auto number primary key of SitePageType inserted row using Transaction
		/// </summary>
		public bool InsertNewSitePageType( int sitePageTypeID,  string name,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePageType");
				Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,sitePageTypeID);
				Database.AddInParameter(command,"Name",DbType.String,name);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for SitePageType using Stored Procedure
		/// and return DbCommand of the SitePageType
		/// </summary>
		public DbCommand InsertNewSitePageTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSitePageType");
				Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,"SitePageTypeID",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SitePageType using Stored Procedure
		/// </summary>
		public bool UpdateSitePageType( int sitePageTypeID, string name, int oldsitePageTypeID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePageType");
		    		Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,sitePageTypeID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldSitePageTypeID",DbType.Int32,oldsitePageTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SitePageType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSitePageType( int sitePageTypeID, string name, int oldsitePageTypeID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePageType");
		    		Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,sitePageTypeID);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"oldSitePageTypeID",DbType.Int32,oldsitePageTypeID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from SitePageType using Stored Procedure
		/// </summary>
		public DbCommand UpdateSitePageTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSitePageType");
		    		Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,"SitePageTypeID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSitePageTypeID",DbType.Int32,"SitePageTypeID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From SitePageType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSitePageType( int sitePageTypeID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSitePageType");
			Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,sitePageTypeID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From SitePageType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSitePageTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSitePageType");
				Database.AddInParameter(command,"SitePageTypeID",DbType.Int32,"SitePageTypeID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SitePageType using Stored Procedure
		/// and return number of rows effected of the SitePageType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SitePageType",InsertNewSitePageTypeCommand(),UpdateSitePageTypeCommand(),DeleteSitePageTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SitePageType using Stored Procedure
		/// and return number of rows effected of the SitePageType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SitePageType",InsertNewSitePageTypeCommand(),UpdateSitePageTypeCommand(),DeleteSitePageTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
