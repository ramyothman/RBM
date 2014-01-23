using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for MasterPageTemplate table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the MasterPageTemplate table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class MasterPageTemplateDAC : DataAccessComponent
	{
		#region Constructors
        public MasterPageTemplateDAC() : base("", "ContentManagement.MasterPageTemplate") { }
		public MasterPageTemplateDAC(string connectionString): base(connectionString){}
		public MasterPageTemplateDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MasterPageTemplate using Stored Procedure
		/// and return a DataTable containing all MasterPageTemplate Data
		/// </summary>
		public DataTable GetAllMasterPageTemplate()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MasterPageTemplate";
         string query = " select * from GetAllMasterPageTemplate";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MasterPageTemplate"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MasterPageTemplate using Stored Procedure
		/// and return a DataTable containing all MasterPageTemplate Data using a Transaction
		/// </summary>
		public DataTable GetAllMasterPageTemplate(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MasterPageTemplate";
         string query = " select * from GetAllMasterPageTemplate";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MasterPageTemplate"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MasterPageTemplate using Stored Procedure
		/// and return a DataTable containing all MasterPageTemplate Data
		/// </summary>
		public DataTable GetAllMasterPageTemplate(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MasterPageTemplate";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllMasterPageTemplate" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["MasterPageTemplate"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all MasterPageTemplate using Stored Procedure
		/// and return a DataTable containing all MasterPageTemplate Data using a Transaction
		/// </summary>
		public DataTable GetAllMasterPageTemplate(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "MasterPageTemplate";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllMasterPageTemplate" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["MasterPageTemplate"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MasterPageTemplate using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMasterPageTemplate( int masterPageTemplateId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMasterPageTemplate");
				    Database.AddInParameter(command,"MasterPageTemplateId",DbType.Int32,masterPageTemplateId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From MasterPageTemplate using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDMasterPageTemplate( int masterPageTemplateId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDMasterPageTemplate");
				    Database.AddInParameter(command,"MasterPageTemplateId",DbType.Int32,masterPageTemplateId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MasterPageTemplate using Stored Procedure
		/// and return the auto number primary key of MasterPageTemplate inserted row
		/// </summary>
		public bool InsertNewMasterPageTemplate( ref int masterPageTemplateId,  string name,  string path,  string className,  string masterPageContent)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMasterPageTemplate");
				Database.AddOutParameter(command,"MasterPageTemplateId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Path",DbType.String,path);
				Database.AddInParameter(command,"ClassName",DbType.String,className);
				Database.AddInParameter(command,"MasterPageContent",DbType.String,masterPageContent);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 masterPageTemplateId = Convert.ToInt32(Database.GetParameterValue(command, "MasterPageTemplateId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into MasterPageTemplate using Stored Procedure
		/// and return the auto number primary key of MasterPageTemplate inserted row using Transaction
		/// </summary>
		public bool InsertNewMasterPageTemplate( ref int masterPageTemplateId,  string name,  string path,  string className,  string masterPageContent,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMasterPageTemplate");
				Database.AddOutParameter(command,"MasterPageTemplateId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Path",DbType.String,path);
				Database.AddInParameter(command,"ClassName",DbType.String,className);
				Database.AddInParameter(command,"MasterPageContent",DbType.String,masterPageContent);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 masterPageTemplateId = Convert.ToInt32(Database.GetParameterValue(command, "MasterPageTemplateId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for MasterPageTemplate using Stored Procedure
		/// and return DbCommand of the MasterPageTemplate
		/// </summary>
		public DbCommand InsertNewMasterPageTemplateCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewMasterPageTemplate");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"Path",DbType.String,"Path",DataRowVersion.Current);
				Database.AddInParameter(command,"ClassName",DbType.String,"ClassName",DataRowVersion.Current);
				Database.AddInParameter(command,"MasterPageContent",DbType.String,"MasterPageContent",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MasterPageTemplate using Stored Procedure
		/// </summary>
		public bool UpdateMasterPageTemplate( string name, string path, string className, string masterPageContent, int oldmasterPageTemplateId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMasterPageTemplate");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Path",DbType.String,path);
		    		Database.AddInParameter(command,"ClassName",DbType.String,className);
		    		Database.AddInParameter(command,"MasterPageContent",DbType.String,masterPageContent);
				Database.AddInParameter(command,"oldMasterPageTemplateId",DbType.Int32,oldmasterPageTemplateId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into MasterPageTemplate using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateMasterPageTemplate( string name, string path, string className, string masterPageContent, int oldmasterPageTemplateId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMasterPageTemplate");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Path",DbType.String,path);
		    		Database.AddInParameter(command,"ClassName",DbType.String,className);
		    		Database.AddInParameter(command,"MasterPageContent",DbType.String,masterPageContent);
				Database.AddInParameter(command,"oldMasterPageTemplateId",DbType.Int32,oldmasterPageTemplateId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from MasterPageTemplate using Stored Procedure
		/// </summary>
		public DbCommand UpdateMasterPageTemplateCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateMasterPageTemplate");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Path",DbType.String,"Path",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ClassName",DbType.String,"ClassName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"MasterPageContent",DbType.String,"MasterPageContent",DataRowVersion.Current);
				Database.AddInParameter(command,"oldMasterPageTemplateId",DbType.Int32,"MasterPageTemplateId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From MasterPageTemplate using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteMasterPageTemplate( int masterPageTemplateId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteMasterPageTemplate");
			Database.AddInParameter(command,"MasterPageTemplateId",DbType.Int32,masterPageTemplateId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From MasterPageTemplate Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteMasterPageTemplateCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteMasterPageTemplate");
				Database.AddInParameter(command,"MasterPageTemplateId",DbType.Int32,"MasterPageTemplateId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MasterPageTemplate using Stored Procedure
		/// and return number of rows effected of the MasterPageTemplate
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MasterPageTemplate",InsertNewMasterPageTemplateCommand(),UpdateMasterPageTemplateCommand(),DeleteMasterPageTemplateCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table MasterPageTemplate using Stored Procedure
		/// and return number of rows effected of the MasterPageTemplate
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"MasterPageTemplate",InsertNewMasterPageTemplateCommand(),UpdateMasterPageTemplateCommand(),DeleteMasterPageTemplateCommand(), transaction);
          return rowsAffected;
		}


	}
}
