using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for SectionFiles table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the SectionFiles table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class SectionFilesDAC : DataAccessComponent
	{
		#region Constructors
        public SectionFilesDAC() : base("", "ContentManagement.SectionFiles") { }
		public SectionFilesDAC(string connectionString): base(connectionString){}
		public SectionFilesDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SectionFiles using Stored Procedure
		/// and return a DataTable containing all SectionFiles Data
		/// </summary>
		public DataTable GetAllSectionFiles()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SectionFiles";
         string query = " select * from GetAllSectionFiles";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SectionFiles"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SectionFiles using Stored Procedure
		/// and return a DataTable containing all SectionFiles Data using a Transaction
		/// </summary>
		public DataTable GetAllSectionFiles(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SectionFiles";
         string query = " select * from GetAllSectionFiles";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SectionFiles"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SectionFiles using Stored Procedure
		/// and return a DataTable containing all SectionFiles Data
		/// </summary>
		public DataTable GetAllSectionFiles(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SectionFiles";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllSectionFiles" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["SectionFiles"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all SectionFiles using Stored Procedure
		/// and return a DataTable containing all SectionFiles Data using a Transaction
		/// </summary>
		public DataTable GetAllSectionFiles(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "SectionFiles";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllSectionFiles" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["SectionFiles"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SectionFiles using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSectionFiles( int sectionFileId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSectionFiles");
				    Database.AddInParameter(command,"SectionFileId",DbType.Int32,sectionFileId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From SectionFiles using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDSectionFiles( int sectionFileId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDSectionFiles");
				    Database.AddInParameter(command,"SectionFileId",DbType.Int32,sectionFileId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SectionFiles using Stored Procedure
		/// and return the auto number primary key of SectionFiles inserted row
		/// </summary>
		public bool InsertNewSectionFiles( int sectionFileId,  string sectionFileName,  string sectionFilePath,  int sectionId,  int securityAccessTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSectionFiles");
				Database.AddInParameter(command,"SectionFileId",DbType.Int32,sectionFileId);
				Database.AddInParameter(command,"SectionFileName",DbType.String,sectionFileName);
				Database.AddInParameter(command,"SectionFilePath",DbType.String,sectionFilePath);
				Database.AddInParameter(command,"SectionId",DbType.Int32,sectionId);
				Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into SectionFiles using Stored Procedure
		/// and return the auto number primary key of SectionFiles inserted row using Transaction
		/// </summary>
		public bool InsertNewSectionFiles( int sectionFileId,  string sectionFileName,  string sectionFilePath,  int sectionId,  int securityAccessTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSectionFiles");
				Database.AddInParameter(command,"SectionFileId",DbType.Int32,sectionFileId);
				Database.AddInParameter(command,"SectionFileName",DbType.String,sectionFileName);
				Database.AddInParameter(command,"SectionFilePath",DbType.String,sectionFilePath);
				Database.AddInParameter(command,"SectionId",DbType.Int32,sectionId);
				Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for SectionFiles using Stored Procedure
		/// and return DbCommand of the SectionFiles
		/// </summary>
		public DbCommand InsertNewSectionFilesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewSectionFiles");
				Database.AddInParameter(command,"SectionFileId",DbType.Int32,"SectionFileId",DataRowVersion.Current);
				Database.AddInParameter(command,"SectionFileName",DbType.String,"SectionFileName",DataRowVersion.Current);
				Database.AddInParameter(command,"SectionFilePath",DbType.String,"SectionFilePath",DataRowVersion.Current);
				Database.AddInParameter(command,"SectionId",DbType.Int32,"SectionId",DataRowVersion.Current);
				Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,"SecurityAccessTypeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SectionFiles using Stored Procedure
		/// </summary>
		public bool UpdateSectionFiles( int sectionFileId, string sectionFileName, string sectionFilePath, int sectionId, int securityAccessTypeId, int oldsectionFileId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSectionFiles");
		    		Database.AddInParameter(command,"SectionFileId",DbType.Int32,sectionFileId);
		    		Database.AddInParameter(command,"SectionFileName",DbType.String,sectionFileName);
		    		Database.AddInParameter(command,"SectionFilePath",DbType.String,sectionFilePath);
		    		Database.AddInParameter(command,"SectionId",DbType.Int32,sectionId);
		    		Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
				Database.AddInParameter(command,"oldSectionFileId",DbType.Int32,oldsectionFileId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into SectionFiles using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateSectionFiles( int sectionFileId, string sectionFileName, string sectionFilePath, int sectionId, int securityAccessTypeId, int oldsectionFileId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSectionFiles");
		    		Database.AddInParameter(command,"SectionFileId",DbType.Int32,sectionFileId);
		    		Database.AddInParameter(command,"SectionFileName",DbType.String,sectionFileName);
		    		Database.AddInParameter(command,"SectionFilePath",DbType.String,sectionFilePath);
		    		Database.AddInParameter(command,"SectionId",DbType.Int32,sectionId);
		    		Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,securityAccessTypeId);
				Database.AddInParameter(command,"oldSectionFileId",DbType.Int32,oldsectionFileId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from SectionFiles using Stored Procedure
		/// </summary>
		public DbCommand UpdateSectionFilesCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateSectionFiles");
		    		Database.AddInParameter(command,"SectionFileId",DbType.Int32,"SectionFileId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SectionFileName",DbType.String,"SectionFileName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SectionFilePath",DbType.String,"SectionFilePath",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SectionId",DbType.Int32,"SectionId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SecurityAccessTypeId",DbType.Int32,"SecurityAccessTypeId",DataRowVersion.Current);
				Database.AddInParameter(command,"oldSectionFileId",DbType.Int32,"SectionFileId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From SectionFiles using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteSectionFiles( int sectionFileId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteSectionFiles");
			Database.AddInParameter(command,"SectionFileId",DbType.Int32,sectionFileId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From SectionFiles Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteSectionFilesCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteSectionFiles");
				Database.AddInParameter(command,"SectionFileId",DbType.Int32,"SectionFileId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SectionFiles using Stored Procedure
		/// and return number of rows effected of the SectionFiles
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SectionFiles",InsertNewSectionFilesCommand(),UpdateSectionFilesCommand(),DeleteSectionFilesCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table SectionFiles using Stored Procedure
		/// and return number of rows effected of the SectionFiles
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"SectionFiles",InsertNewSectionFilesCommand(),UpdateSectionFilesCommand(),DeleteSectionFilesCommand(), transaction);
          return rowsAffected;
		}


	}
}
