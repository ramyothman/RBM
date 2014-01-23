using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for TransportationTypeLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the TransportationTypeLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class TransportationTypeLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public TransportationTypeLanguageDAC() : base("", "Conference.TransportationTypeLanguage") { }
		public TransportationTypeLanguageDAC(string connectionString): base(connectionString){}
		public TransportationTypeLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all TransportationTypeLanguage using Stored Procedure
		/// and return a DataTable containing all TransportationTypeLanguage Data
		/// </summary>
		public DataTable GetAllTransportationTypeLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "TransportationTypeLanguage";
         string query = " select * from GetAllTransportationTypeLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["TransportationTypeLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all TransportationTypeLanguage using Stored Procedure
		/// and return a DataTable containing all TransportationTypeLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllTransportationTypeLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "TransportationTypeLanguage";
         string query = " select * from GetAllTransportationTypeLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["TransportationTypeLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all TransportationTypeLanguage using Stored Procedure
		/// and return a DataTable containing all TransportationTypeLanguage Data
		/// </summary>
		public DataTable GetAllTransportationTypeLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "TransportationTypeLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllTransportationTypeLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["TransportationTypeLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all TransportationTypeLanguage using Stored Procedure
		/// and return a DataTable containing all TransportationTypeLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllTransportationTypeLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "TransportationTypeLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllTransportationTypeLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["TransportationTypeLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From TransportationTypeLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDTransportationTypeLanguage( int iD)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDTransportationTypeLanguage");
				    Database.AddInParameter(command,"ID",DbType.Int32,iD);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From TransportationTypeLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDTransportationTypeLanguage( int iD,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDTransportationTypeLanguage");
				    Database.AddInParameter(command,"ID",DbType.Int32,iD);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into TransportationTypeLanguage using Stored Procedure
		/// and return the auto number primary key of TransportationTypeLanguage inserted row
		/// </summary>
		public bool InsertNewTransportationTypeLanguage( ref int iD,  string typeName,  int languageID,  int parentID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewTransportationTypeLanguage");
				Database.AddOutParameter(command,"ID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"TypeName",DbType.String,typeName);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"ParentID",DbType.Int32,parentID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into TransportationTypeLanguage using Stored Procedure
		/// and return the auto number primary key of TransportationTypeLanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewTransportationTypeLanguage( ref int iD,  string typeName,  int languageID,  int parentID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewTransportationTypeLanguage");
				Database.AddOutParameter(command,"ID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"TypeName",DbType.String,typeName);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"ParentID",DbType.Int32,parentID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for TransportationTypeLanguage using Stored Procedure
		/// and return DbCommand of the TransportationTypeLanguage
		/// </summary>
		public DbCommand InsertNewTransportationTypeLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewTransportationTypeLanguage");

				Database.AddInParameter(command,"TypeName",DbType.String,"TypeName",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"ParentID",DbType.Int32,"ParentID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into TransportationTypeLanguage using Stored Procedure
		/// </summary>
		public bool UpdateTransportationTypeLanguage( string typeName, int languageID, int parentID, int oldiD)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateTransportationTypeLanguage");

		    		Database.AddInParameter(command,"TypeName",DbType.String,typeName);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"ParentID",DbType.Int32,parentID);
				Database.AddInParameter(command,"oldID",DbType.Int32,oldiD);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into TransportationTypeLanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateTransportationTypeLanguage( string typeName, int languageID, int parentID, int oldiD,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateTransportationTypeLanguage");

		    		Database.AddInParameter(command,"TypeName",DbType.String,typeName);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
		    		Database.AddInParameter(command,"ParentID",DbType.Int32,parentID);
				Database.AddInParameter(command,"oldID",DbType.Int32,oldiD);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from TransportationTypeLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateTransportationTypeLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateTransportationTypeLanguage");

		    		Database.AddInParameter(command,"TypeName",DbType.String,"TypeName",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ParentID",DbType.Int32,"ParentID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldID",DbType.Int32,"ID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From TransportationTypeLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteTransportationTypeLanguage( int iD)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteTransportationTypeLanguage");
			Database.AddInParameter(command,"ID",DbType.Int32,iD);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From TransportationTypeLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteTransportationTypeLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteTransportationTypeLanguage");
				Database.AddInParameter(command,"ID",DbType.Int32,"ID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table TransportationTypeLanguage using Stored Procedure
		/// and return number of rows effected of the TransportationTypeLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"TransportationTypeLanguage",InsertNewTransportationTypeLanguageCommand(),UpdateTransportationTypeLanguageCommand(),DeleteTransportationTypeLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table TransportationTypeLanguage using Stored Procedure
		/// and return number of rows effected of the TransportationTypeLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"TransportationTypeLanguage",InsertNewTransportationTypeLanguageCommand(),UpdateTransportationTypeLanguageCommand(),DeleteTransportationTypeLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
