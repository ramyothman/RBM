using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for ModuleSection table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ModuleSection table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ModuleSectionDAC : DataAccessComponent
	{
		#region Constructors
        public ModuleSectionDAC() : base("", "ContentManagement.ModuleSection") { }
		public ModuleSectionDAC(string connectionString): base(connectionString){}
		public ModuleSectionDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ModuleSection using Stored Procedure
		/// and return a DataTable containing all ModuleSection Data
		/// </summary>
		public DataTable GetAllModuleSection()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ModuleSection";
         string query = " select * from GetAllModuleSection";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ModuleSection"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ModuleSection using Stored Procedure
		/// and return a DataTable containing all ModuleSection Data using a Transaction
		/// </summary>
		public DataTable GetAllModuleSection(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ModuleSection";
         string query = " select * from GetAllModuleSection";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ModuleSection"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ModuleSection using Stored Procedure
		/// and return a DataTable containing all ModuleSection Data
		/// </summary>
		public DataTable GetAllModuleSection(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ModuleSection";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllModuleSection" + whereClause + " Order By OrderNumber";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ModuleSection"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ModuleSection using Stored Procedure
		/// and return a DataTable containing all ModuleSection Data using a Transaction
		/// </summary>
		public DataTable GetAllModuleSection(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ModuleSection";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllModuleSection" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ModuleSection"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ModuleSection using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDModuleSection( int moduleSectionID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDModuleSection");
				    Database.AddInParameter(command,"ModuleSectionID",DbType.Int32,moduleSectionID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ModuleSection using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDModuleSection( int moduleSectionID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDModuleSection");
				    Database.AddInParameter(command,"ModuleSectionID",DbType.Int32,moduleSectionID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ModuleSection using Stored Procedure
		/// and return the auto number primary key of ModuleSection inserted row
		/// </summary>
		public bool InsertNewModuleSection( ref int moduleSectionID,  int homePageID,  int sectionID,  int orderNumber,  int itemsNumber,  int itemsPerPage,  bool isActive)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewModuleSection");
				Database.AddOutParameter(command,"ModuleSectionID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"HomePageID",DbType.Int32,homePageID);
				Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
				Database.AddInParameter(command,"OrderNumber",DbType.Int32,orderNumber);
				Database.AddInParameter(command,"ItemsNumber",DbType.Int32,itemsNumber);
				Database.AddInParameter(command,"ItemsPerPage",DbType.Int32,itemsPerPage);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 moduleSectionID = Convert.ToInt32(Database.GetParameterValue(command, "ModuleSectionID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ModuleSection using Stored Procedure
		/// and return the auto number primary key of ModuleSection inserted row using Transaction
		/// </summary>
		public bool InsertNewModuleSection( ref int moduleSectionID,  int homePageID,  int sectionID,  int orderNumber,  int itemsNumber,  int itemsPerPage,  bool isActive,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewModuleSection");
				Database.AddOutParameter(command,"ModuleSectionID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"HomePageID",DbType.Int32,homePageID);
				Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
				Database.AddInParameter(command,"OrderNumber",DbType.Int32,orderNumber);
				Database.AddInParameter(command,"ItemsNumber",DbType.Int32,itemsNumber);
				Database.AddInParameter(command,"ItemsPerPage",DbType.Int32,itemsPerPage);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 moduleSectionID = Convert.ToInt32(Database.GetParameterValue(command, "ModuleSectionID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ModuleSection using Stored Procedure
		/// and return DbCommand of the ModuleSection
		/// </summary>
		public DbCommand InsertNewModuleSectionCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewModuleSection");

				Database.AddInParameter(command,"HomePageID",DbType.Int32,"HomePageID",DataRowVersion.Current);
				Database.AddInParameter(command,"SectionID",DbType.Int32,"SectionID",DataRowVersion.Current);
				Database.AddInParameter(command,"OrderNumber",DbType.Int32,"OrderNumber",DataRowVersion.Current);
				Database.AddInParameter(command,"ItemsNumber",DbType.Int32,"ItemsNumber",DataRowVersion.Current);
				Database.AddInParameter(command,"ItemsPerPage",DbType.Int32,"ItemsPerPage",DataRowVersion.Current);
				Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ModuleSection using Stored Procedure
		/// </summary>
		public bool UpdateModuleSection( int homePageID, int sectionID, int orderNumber, int itemsNumber, int itemsPerPage, bool isActive, int oldmoduleSectionID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateModuleSection");

		    		Database.AddInParameter(command,"HomePageID",DbType.Int32,homePageID);
		    		Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
		    		Database.AddInParameter(command,"OrderNumber",DbType.Int32,orderNumber);
		    		Database.AddInParameter(command,"ItemsNumber",DbType.Int32,itemsNumber);
		    		Database.AddInParameter(command,"ItemsPerPage",DbType.Int32,itemsPerPage);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"oldModuleSectionID",DbType.Int32,oldmoduleSectionID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ModuleSection using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateModuleSection( int homePageID, int sectionID, int orderNumber, int itemsNumber, int itemsPerPage, bool isActive, int oldmoduleSectionID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateModuleSection");

		    		Database.AddInParameter(command,"HomePageID",DbType.Int32,homePageID);
		    		Database.AddInParameter(command,"SectionID",DbType.Int32,sectionID);
		    		Database.AddInParameter(command,"OrderNumber",DbType.Int32,orderNumber);
		    		Database.AddInParameter(command,"ItemsNumber",DbType.Int32,itemsNumber);
		    		Database.AddInParameter(command,"ItemsPerPage",DbType.Int32,itemsPerPage);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,isActive);
				Database.AddInParameter(command,"oldModuleSectionID",DbType.Int32,oldmoduleSectionID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ModuleSection using Stored Procedure
		/// </summary>
		public DbCommand UpdateModuleSectionCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateModuleSection");

		    		Database.AddInParameter(command,"HomePageID",DbType.Int32,"HomePageID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"SectionID",DbType.Int32,"SectionID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"OrderNumber",DbType.Int32,"OrderNumber",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ItemsNumber",DbType.Int32,"ItemsNumber",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ItemsPerPage",DbType.Int32,"ItemsPerPage",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsActive",DbType.Boolean,"IsActive",DataRowVersion.Current);
				Database.AddInParameter(command,"oldModuleSectionID",DbType.Int32,"ModuleSectionID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ModuleSection using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteModuleSection( int moduleSectionID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteModuleSection");
			Database.AddInParameter(command,"ModuleSectionID",DbType.Int32,moduleSectionID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ModuleSection Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteModuleSectionCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteModuleSection");
				Database.AddInParameter(command,"ModuleSectionID",DbType.Int32,"ModuleSectionID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ModuleSection using Stored Procedure
		/// and return number of rows effected of the ModuleSection
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ModuleSection",InsertNewModuleSectionCommand(),UpdateModuleSectionCommand(),DeleteModuleSectionCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ModuleSection using Stored Procedure
		/// and return number of rows effected of the ModuleSection
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ModuleSection",InsertNewModuleSectionCommand(),UpdateModuleSectionCommand(),DeleteModuleSectionCommand(), transaction);
          return rowsAffected;
		}


	}
}
