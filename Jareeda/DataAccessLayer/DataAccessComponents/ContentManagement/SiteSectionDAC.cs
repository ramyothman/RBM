using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for SiteSection table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the SiteSection table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SiteSectionDAC : DataAccessComponent
	{
		#region Constructors
        public SiteSectionDAC() : base("", "ContentManagement.SiteSection") { }
		public SiteSectionDAC(string connectionString): base(connectionString){}
		public SiteSectionDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SiteSection using Stored Procedure
		/// and return a DataTable containing all SiteSection Data
		/// </summary>
		public DataTable GetAllSiteSection()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SiteSection";
         string query = " select * from GetAllSiteSection";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SiteSection"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SiteSection using Stored Procedure
		/// and return a DataTable containing all SiteSection Data using a Transaction
		/// </summary>
		public DataTable GetAllSiteSection(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SiteSection";
         string query = " select * from GetAllSiteSection";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SiteSection"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SiteSection using Stored Procedure
		/// and return a DataTable containing all SiteSection Data
		/// </summary>
		public DataTable GetAllSiteSection(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SiteSection";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSiteSection" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SiteSection"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SiteSection using Stored Procedure
		/// and return a DataTable containing all SiteSection Data using a Transaction
		/// </summary>
		public DataTable GetAllSiteSection(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SiteSection";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSiteSection" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SiteSection"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SiteSection using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSiteSection( int siteSectionId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSiteSection");
				    Database.AddInParameter(command,"SiteSectionId",DbType.Int32,siteSectionId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SiteSection using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSiteSection( int siteSectionId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSiteSection");
				    Database.AddInParameter(command,"SiteSectionId",DbType.Int32,siteSectionId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SiteSection using Stored Procedure
		/// and return the auto number primary key of SiteSection inserted row
		/// </summary>
		public bool InsertNewSiteSection( int siteSectionId,  string name,  int siteSectionParentId,  int sectionStatusId,  int siteId,  int personId,  int securityAccessTypeId,  Guid rowGuid,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSiteSection");
				Database.AddInParameter(command,"SiteSectionId",DbType.Int32,siteSectionId);
				Database.AddInParameter(command,"Name",DbType.String,name);
            if(siteSectionParentId == 0)
				Database.AddInParameter(command,"SiteSectionParentId",DbType.Int32,DBNull.Value);
            else
                Database.AddInParameter(command, "SiteSectionParentId", DbType.Int32, siteSectionParentId);
				Database.AddInParameter(command,"SectionStatusId",DbType.Int32,sectionStatusId);
				Database.AddInParameter(command,"SiteId",DbType.Int32,siteId);
            if(personId == 0)
				Database.AddInParameter(command,"PersonId",DbType.Int32,DBNull.Value);
            else
                Database.AddInParameter(command, "PersonId", DbType.Int32, personId);
				Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SiteSection using Stored Procedure
		/// and return the auto number primary key of SiteSection inserted row using Transaction
		/// </summary>
		public bool InsertNewSiteSection( int siteSectionId,  string name,  int siteSectionParentId,  int sectionStatusId,  int siteId,  int personId,  int securityAccessTypeId,  Guid rowGuid,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSiteSection");
				Database.AddInParameter(command,"SiteSectionId",DbType.Int32,siteSectionId);
				Database.AddInParameter(command,"Name",DbType.String,name);
                if (siteSectionParentId == 0)
                    Database.AddInParameter(command, "SiteSectionParentId", DbType.Int32, DBNull.Value);
                else
                    Database.AddInParameter(command, "SiteSectionParentId", DbType.Int32, siteSectionParentId);
                Database.AddInParameter(command, "SectionStatusId", DbType.Int32, sectionStatusId);
                Database.AddInParameter(command, "SiteId", DbType.Int32, siteId);
                if (personId == 0)
                    Database.AddInParameter(command, "PersonId", DbType.Int32, DBNull.Value);
                else
                    Database.AddInParameter(command, "PersonId", DbType.Int32, personId);
				Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for SiteSection using Stored Procedure
		/// and return DbCommand of the SiteSection
		/// </summary>
		public DbCommand InsertNewSiteSectionCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSiteSection");
				Database.AddInParameter(command,"SiteSectionId",DbType.Int32,"SiteSectionId",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"SiteSectionParentId",DbType.Int32,"SiteSectionParentId",DataRowVersion.Current);
				Database.AddInParameter(command,"SectionStatusId",DbType.Int32,"SectionStatusId",DataRowVersion.Current);
				Database.AddInParameter(command,"SiteId",DbType.Int32,"SiteId",DataRowVersion.Current);
				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,"SecurityAccessTypeId",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SiteSection using Stored Procedure
		/// </summary>
		public bool UpdateSiteSection( int siteSectionId, string name, int siteSectionParentId, int sectionStatusId, int siteId, int personId, int securityAccessTypeId, Guid rowGuid, DateTime modifiedDate, int oldsiteSectionId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSiteSection");
		    		Database.AddInParameter(command,"SiteSectionId",DbType.Int32,siteSectionId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
                    if (siteSectionParentId == 0)
                        Database.AddInParameter(command, "SiteSectionParentId", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "SiteSectionParentId", DbType.Int32, siteSectionParentId);
                    Database.AddInParameter(command, "SectionStatusId", DbType.Int32, sectionStatusId);
                    Database.AddInParameter(command, "SiteId", DbType.Int32, siteId);
                    if (personId == 0)
                        Database.AddInParameter(command, "PersonId", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "PersonId", DbType.Int32, personId);
		    		Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSiteSectionId",DbType.Int32,oldsiteSectionId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SiteSection using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSiteSection( int siteSectionId, string name, int siteSectionParentId, int sectionStatusId, int siteId, int personId, int securityAccessTypeId, Guid rowGuid, DateTime modifiedDate, int oldsiteSectionId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSiteSection");
		    		Database.AddInParameter(command,"SiteSectionId",DbType.Int32,siteSectionId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
                    if (siteSectionParentId == 0)
                        Database.AddInParameter(command, "SiteSectionParentId", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "SiteSectionParentId", DbType.Int32, siteSectionParentId);
                    Database.AddInParameter(command, "SectionStatusId", DbType.Int32, sectionStatusId);
                    Database.AddInParameter(command, "SiteId", DbType.Int32, siteId);
                    if (personId == 0)
                        Database.AddInParameter(command, "PersonId", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "PersonId", DbType.Int32, personId);
		    		Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSiteSectionId",DbType.Int32,oldsiteSectionId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from SiteSection using Stored Procedure
		/// </summary>
		public DbCommand UpdateSiteSectionCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSiteSection");
		    		Database.AddInParameter(command,"SiteSectionId",DbType.Int32,"SiteSectionId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SiteSectionParentId",DbType.Int32,"SiteSectionParentId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SectionStatusId",DbType.Int32,"SectionStatusId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SiteId",DbType.Int32,"SiteId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,"SecurityAccessTypeId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSiteSectionId",DbType.Int32,"SiteSectionId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From SiteSection using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSiteSection( int siteSectionId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSiteSection");
			Database.AddInParameter(command,"SiteSectionId",DbType.Int32,siteSectionId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From SiteSection Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSiteSectionCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSiteSection");
				Database.AddInParameter(command,"SiteSectionId",DbType.Int32,"SiteSectionId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SiteSection using Stored Procedure
		/// and return number of rows effected of the SiteSection
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SiteSection",InsertNewSiteSectionCommand(),UpdateSiteSectionCommand(),DeleteSiteSectionCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SiteSection using Stored Procedure
		/// and return number of rows effected of the SiteSection
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SiteSection",InsertNewSiteSectionCommand(),UpdateSiteSectionCommand(),DeleteSiteSectionCommand(), transaction);
          return rowsAffected;
		}


	}
}
