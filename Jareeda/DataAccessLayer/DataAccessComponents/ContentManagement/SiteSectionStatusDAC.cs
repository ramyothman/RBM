using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for SiteSectionStatus table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the SiteSectionStatus table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SiteSectionStatusDAC : DataAccessComponent
	{
		#region Constructors
        public SiteSectionStatusDAC() : base("", "ContentManagement.SiteSectionStatus") { }
		public SiteSectionStatusDAC(string connectionString): base(connectionString){}
		public SiteSectionStatusDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SiteSectionStatus using Stored Procedure
		/// and return a DataTable containing all SiteSectionStatus Data
		/// </summary>
		public DataTable GetAllSiteSectionStatus()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SiteSectionStatus";
         string query = " select * from GetAllSiteSectionStatus";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SiteSectionStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SiteSectionStatus using Stored Procedure
		/// and return a DataTable containing all SiteSectionStatus Data using a Transaction
		/// </summary>
		public DataTable GetAllSiteSectionStatus(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SiteSectionStatus";
         string query = " select * from GetAllSiteSectionStatus";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SiteSectionStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SiteSectionStatus using Stored Procedure
		/// and return a DataTable containing all SiteSectionStatus Data
		/// </summary>
		public DataTable GetAllSiteSectionStatus(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SiteSectionStatus";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSiteSectionStatus" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SiteSectionStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SiteSectionStatus using Stored Procedure
		/// and return a DataTable containing all SiteSectionStatus Data using a Transaction
		/// </summary>
		public DataTable GetAllSiteSectionStatus(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SiteSectionStatus";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSiteSectionStatus" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SiteSectionStatus"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SiteSectionStatus using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSiteSectionStatus( int siteSectionStatusId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSiteSectionStatus");
				    Database.AddInParameter(command,"SiteSectionStatusId",DbType.Int32,siteSectionStatusId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SiteSectionStatus using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSiteSectionStatus( int siteSectionStatusId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSiteSectionStatus");
				    Database.AddInParameter(command,"SiteSectionStatusId",DbType.Int32,siteSectionStatusId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SiteSectionStatus using Stored Procedure
		/// and return the auto number primary key of SiteSectionStatus inserted row
		/// </summary>
		public bool InsertNewSiteSectionStatus( ref int siteSectionStatusId,  string name,  Guid rowGuid,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSiteSectionStatus");
				Database.AddOutParameter(command,"SiteSectionStatusId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 siteSectionStatusId = Convert.ToInt32(Database.GetParameterValue(command, "SiteSectionStatusId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SiteSectionStatus using Stored Procedure
		/// and return the auto number primary key of SiteSectionStatus inserted row using Transaction
		/// </summary>
		public bool InsertNewSiteSectionStatus( ref int siteSectionStatusId,  string name,  Guid rowGuid,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSiteSectionStatus");
				Database.AddOutParameter(command,"SiteSectionStatusId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 siteSectionStatusId = Convert.ToInt32(Database.GetParameterValue(command, "SiteSectionStatusId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for SiteSectionStatus using Stored Procedure
		/// and return DbCommand of the SiteSectionStatus
		/// </summary>
		public DbCommand InsertNewSiteSectionStatusCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSiteSectionStatus");

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
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SiteSectionStatus using Stored Procedure
		/// </summary>
		public bool UpdateSiteSectionStatus( string name, Guid rowGuid, DateTime modifiedDate, int oldsiteSectionStatusId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSiteSectionStatus");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSiteSectionStatusId",DbType.Int32,oldsiteSectionStatusId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SiteSectionStatus using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSiteSectionStatus( string name, Guid rowGuid, DateTime modifiedDate, int oldsiteSectionStatusId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSiteSectionStatus");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldSiteSectionStatusId",DbType.Int32,oldsiteSectionStatusId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from SiteSectionStatus using Stored Procedure
		/// </summary>
		public DbCommand UpdateSiteSectionStatusCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSiteSectionStatus");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSiteSectionStatusId",DbType.Int32,"SiteSectionStatusId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From SiteSectionStatus using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSiteSectionStatus( int siteSectionStatusId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSiteSectionStatus");
			Database.AddInParameter(command,"SiteSectionStatusId",DbType.Int32,siteSectionStatusId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From SiteSectionStatus Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSiteSectionStatusCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSiteSectionStatus");
				Database.AddInParameter(command,"SiteSectionStatusId",DbType.Int32,"SiteSectionStatusId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SiteSectionStatus using Stored Procedure
		/// and return number of rows effected of the SiteSectionStatus
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SiteSectionStatus",InsertNewSiteSectionStatusCommand(),UpdateSiteSectionStatusCommand(),DeleteSiteSectionStatusCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SiteSectionStatus using Stored Procedure
		/// and return number of rows effected of the SiteSectionStatus
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SiteSectionStatus",InsertNewSiteSectionStatusCommand(),UpdateSiteSectionStatusCommand(),DeleteSiteSectionStatusCommand(), transaction);
          return rowsAffected;
		}


	}
}
