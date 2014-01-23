using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for ContentEntity table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ContentEntity table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ContentEntityDAC : DataAccessComponent
	{
		#region Constructors
        public ContentEntityDAC() : base("", "ContentManagement.ContentEntity") { }
		public ContentEntityDAC(string connectionString): base(connectionString){}
		public ContentEntityDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContentEntity using Stored Procedure
		/// and return a DataTable containing all ContentEntity Data
		/// </summary>
		public DataTable GetAllContentEntity()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContentEntity";
         string query = " select * from GetAllContentEntity";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ContentEntity"];

		}
        public DataTable GetAllContentEntityByType(string type)
        {
            return GetAllContentEntityByType(type, "");
        }
        public DataTable GetAllContentEntityByType(string type,string where)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ContentEntity";
            string whereClause = "";
            string query = " select * from GetAllContentEntity";
            switch (type)
            {
                case "CS":
                    query = " select * From ViewContentEntitySite";
                    break;
                case "SF":
                    query = " select * From ViewContentEntitySystemFolder";
                    break;
                case "SP":
                    query = " select * From ViewContentEntitySystemPage";
                    break;
                case "SS":
                    query = " select * From ViewContentEntitySiteSection";
                    break;
                case "CP":
                    query = " select * From ViewContentEntitySitePage";
                    break;
                case "CF":
                    query = " select * From ViewContentEntitySectionFiles";
                    break;
                case "CA":
                    query = " select * From ViewContentEntitySiteArticle";
                    break;
            }
            if (!string.IsNullOrEmpty(where))
            {
                whereClause = " Where " + where;
            }
            query += whereClause;
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["ContentEntity"];

        }

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContentEntity using Stored Procedure
		/// and return a DataTable containing all ContentEntity Data using a Transaction
		/// </summary>
		public DataTable GetAllContentEntity(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContentEntity";
         string query = " select * from GetAllContentEntity";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ContentEntity"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContentEntity using Stored Procedure
		/// and return a DataTable containing all ContentEntity Data
		/// </summary>
		public DataTable GetAllContentEntity(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContentEntity";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllContentEntity" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ContentEntity"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContentEntity using Stored Procedure
		/// and return a DataTable containing all ContentEntity Data using a Transaction
		/// </summary>
		public DataTable GetAllContentEntity(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ContentEntity";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllContentEntity" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ContentEntity"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ContentEntity using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDContentEntity( int contentEntityId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDContentEntity");
				    Database.AddInParameter(command,"ContentEntityId",DbType.Int32,contentEntityId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ContentEntity using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDContentEntity( int contentEntityId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDContentEntity");
				    Database.AddInParameter(command,"ContentEntityId",DbType.Int32,contentEntityId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ContentEntity using Stored Procedure
		/// and return the auto number primary key of ContentEntity inserted row
		/// </summary>
		public bool InsertNewContentEntity( ref int contentEntityId,  string contentEntityType,  Guid rowGuid,  DateTime modifiedDate)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewContentEntity");
				Database.AddOutParameter(command,"ContentEntityId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ContentEntityType",DbType.String,contentEntityType);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 contentEntityId = Convert.ToInt32(Database.GetParameterValue(command, "ContentEntityId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ContentEntity using Stored Procedure
		/// and return the auto number primary key of ContentEntity inserted row using Transaction
		/// </summary>
		public bool InsertNewContentEntity( ref int contentEntityId,  string contentEntityType,  Guid rowGuid,  DateTime modifiedDate,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewContentEntity");
				Database.AddOutParameter(command,"ContentEntityId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ContentEntityType",DbType.String,contentEntityType);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 contentEntityId = Convert.ToInt32(Database.GetParameterValue(command, "ContentEntityId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ContentEntity using Stored Procedure
		/// and return DbCommand of the ContentEntity
		/// </summary>
		public DbCommand InsertNewContentEntityCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewContentEntity");

				Database.AddInParameter(command,"ContentEntityType",DbType.String,"ContentEntityType",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ContentEntity using Stored Procedure
		/// </summary>
		public bool UpdateContentEntity( string contentEntityType, Guid rowGuid, DateTime modifiedDate, int oldcontentEntityId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateContentEntity");

		    		Database.AddInParameter(command,"ContentEntityType",DbType.String,contentEntityType);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldContentEntityId",DbType.Int32,oldcontentEntityId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ContentEntity using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateContentEntity( string contentEntityType, Guid rowGuid, DateTime modifiedDate, int oldcontentEntityId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateContentEntity");

		    		Database.AddInParameter(command,"ContentEntityType",DbType.String,contentEntityType);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"oldContentEntityId",DbType.Int32,oldcontentEntityId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ContentEntity using Stored Procedure
		/// </summary>
		public DbCommand UpdateContentEntityCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateContentEntity");

		    		Database.AddInParameter(command,"ContentEntityType",DbType.String,"ContentEntityType",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"oldContentEntityId",DbType.Int32,"ContentEntityId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ContentEntity using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteContentEntity( int contentEntityId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteContentEntity");
			Database.AddInParameter(command,"ContentEntityId",DbType.Int32,contentEntityId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ContentEntity Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteContentEntityCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteContentEntity");
				Database.AddInParameter(command,"ContentEntityId",DbType.Int32,"ContentEntityId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ContentEntity using Stored Procedure
		/// and return number of rows effected of the ContentEntity
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ContentEntity",InsertNewContentEntityCommand(),UpdateContentEntityCommand(),DeleteContentEntityCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ContentEntity using Stored Procedure
		/// and return number of rows effected of the ContentEntity
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ContentEntity",InsertNewContentEntityCommand(),UpdateContentEntityCommand(),DeleteContentEntityCommand(), transaction);
          return rowsAffected;
		}


	}
}
