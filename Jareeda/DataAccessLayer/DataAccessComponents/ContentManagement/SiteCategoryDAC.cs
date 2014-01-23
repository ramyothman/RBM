using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for SiteCategory table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the SiteCategory table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SiteCategoryDAC : DataAccessComponent
	{
		#region Constructors
        public SiteCategoryDAC() : base("", "ContentManagement.SiteCategory") { }
		public SiteCategoryDAC(string connectionString): base(connectionString){}
		public SiteCategoryDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SiteCategory using Stored Procedure
		/// and return a DataTable containing all SiteCategory Data
		/// </summary>
		public DataTable GetAllSiteCategory()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SiteCategory";
         string query = " select * from GetAllSiteCategory";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SiteCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SiteCategory using Stored Procedure
		/// and return a DataTable containing all SiteCategory Data using a Transaction
		/// </summary>
		public DataTable GetAllSiteCategory(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SiteCategory";
         string query = " select * from GetAllSiteCategory";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SiteCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SiteCategory using Stored Procedure
		/// and return a DataTable containing all SiteCategory Data
		/// </summary>
		public DataTable GetAllSiteCategory(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SiteCategory";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSiteCategory" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SiteCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SiteCategory using Stored Procedure
		/// and return a DataTable containing all SiteCategory Data using a Transaction
		/// </summary>
		public DataTable GetAllSiteCategory(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SiteCategory";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSiteCategory" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SiteCategory"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SiteCategory using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSiteCategory( int siteCategoryId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSiteCategory");
				    Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,siteCategoryId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SiteCategory using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSiteCategory( int siteCategoryId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSiteCategory");
				    Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,siteCategoryId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SiteCategory using Stored Procedure
		/// and return the auto number primary key of SiteCategory inserted row
		/// </summary>
		public bool InsertNewSiteCategory( ref int siteCategoryId,  string name,  Guid rowGuid,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSiteCategory");
				Database.AddOutParameter(command,"SiteCategoryId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 siteCategoryId = Convert.ToInt32(Database.GetParameterValue(command, "SiteCategoryId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SiteCategory using Stored Procedure
		/// and return the auto number primary key of SiteCategory inserted row using Transaction
		/// </summary>
		public bool InsertNewSiteCategory( ref int siteCategoryId,  string name,  Guid rowGuid,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSiteCategory");
				Database.AddOutParameter(command,"SiteCategoryId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 siteCategoryId = Convert.ToInt32(Database.GetParameterValue(command, "SiteCategoryId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for SiteCategory using Stored Procedure
		/// and return DbCommand of the SiteCategory
		/// </summary>
		public DbCommand InsertNewSiteCategoryCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSiteCategory");

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
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SiteCategory using Stored Procedure
		/// </summary>
		public bool UpdateSiteCategory( string name, Guid rowGuid, DateTime modifiedDate, int oldsiteCategoryId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSiteCategory");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSiteCategoryId",DbType.Int32,oldsiteCategoryId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SiteCategory using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSiteCategory( string name, Guid rowGuid, DateTime modifiedDate, int oldsiteCategoryId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSiteCategory");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSiteCategoryId",DbType.Int32,oldsiteCategoryId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from SiteCategory using Stored Procedure
		/// </summary>
		public DbCommand UpdateSiteCategoryCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSiteCategory");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSiteCategoryId",DbType.Int32,"SiteCategoryId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From SiteCategory using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSiteCategory( int siteCategoryId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSiteCategory");
			Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,siteCategoryId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From SiteCategory Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSiteCategoryCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSiteCategory");
				Database.AddInParameter(command,"SiteCategoryId",DbType.Int32,"SiteCategoryId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SiteCategory using Stored Procedure
		/// and return number of rows effected of the SiteCategory
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SiteCategory",InsertNewSiteCategoryCommand(),UpdateSiteCategoryCommand(),DeleteSiteCategoryCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SiteCategory using Stored Procedure
		/// and return number of rows effected of the SiteCategory
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SiteCategory",InsertNewSiteCategoryCommand(),UpdateSiteCategoryCommand(),DeleteSiteCategoryCommand(), transaction);
          return rowsAffected;
		}


	}
}
