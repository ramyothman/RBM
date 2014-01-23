using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for TransportationType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the TransportationType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class TransportationTypeDAC : DataAccessComponent
	{
		#region Constructors
        public TransportationTypeDAC() : base("", "Conference.TransportationType") { }
		public TransportationTypeDAC(string connectionString): base(connectionString){}
		public TransportationTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all TransportationType using Stored Procedure
		/// and return a DataTable containing all TransportationType Data
		/// </summary>
		public DataTable GetAllTransportationType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "TransportationType";
         string query = " select * from GetAllTransportationType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["TransportationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all TransportationType using Stored Procedure
		/// and return a DataTable containing all TransportationType Data using a Transaction
		/// </summary>
		public DataTable GetAllTransportationType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "TransportationType";
         string query = " select * from GetAllTransportationType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["TransportationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all TransportationType using Stored Procedure
		/// and return a DataTable containing all TransportationType Data
		/// </summary>
		public DataTable GetAllTransportationType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "TransportationType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllTransportationType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["TransportationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all TransportationType using Stored Procedure
		/// and return a DataTable containing all TransportationType Data using a Transaction
		/// </summary>
		public DataTable GetAllTransportationType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "TransportationType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllTransportationType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["TransportationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From TransportationType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDTransportationType( int iD)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDTransportationType");
				    Database.AddInParameter(command,"ID",DbType.Int32,iD);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From TransportationType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDTransportationType( int iD,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDTransportationType");
				    Database.AddInParameter(command,"ID",DbType.Int32,iD);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into TransportationType using Stored Procedure
		/// and return the auto number primary key of TransportationType inserted row
		/// </summary>
		public bool InsertNewTransportationType( ref int iD,  string typeName)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewTransportationType");
				Database.AddOutParameter(command,"ID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"TypeName",DbType.String,typeName);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into TransportationType using Stored Procedure
		/// and return the auto number primary key of TransportationType inserted row using Transaction
		/// </summary>
		public bool InsertNewTransportationType( ref int iD,  string typeName,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewTransportationType");
				Database.AddOutParameter(command,"ID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"TypeName",DbType.String,typeName);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for TransportationType using Stored Procedure
		/// and return DbCommand of the TransportationType
		/// </summary>
		public DbCommand InsertNewTransportationTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewTransportationType");

				Database.AddInParameter(command,"TypeName",DbType.String,"TypeName",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into TransportationType using Stored Procedure
		/// </summary>
		public bool UpdateTransportationType( string typeName, int oldiD)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateTransportationType");

		    		Database.AddInParameter(command,"TypeName",DbType.String,typeName);
				Database.AddInParameter(command,"oldID",DbType.Int32,oldiD);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into TransportationType using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateTransportationType( string typeName, int oldiD,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateTransportationType");

		    		Database.AddInParameter(command,"TypeName",DbType.String,typeName);
				Database.AddInParameter(command,"oldID",DbType.Int32,oldiD);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from TransportationType using Stored Procedure
		/// </summary>
		public DbCommand UpdateTransportationTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateTransportationType");

		    		Database.AddInParameter(command,"TypeName",DbType.String,"TypeName",DataRowVersion.Current);
				Database.AddInParameter(command,"oldID",DbType.Int32,"ID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From TransportationType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteTransportationType( int iD)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteTransportationType");
			Database.AddInParameter(command,"ID",DbType.Int32,iD);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From TransportationType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteTransportationTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteTransportationType");
				Database.AddInParameter(command,"ID",DbType.Int32,"ID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table TransportationType using Stored Procedure
		/// and return number of rows effected of the TransportationType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"TransportationType",InsertNewTransportationTypeCommand(),UpdateTransportationTypeCommand(),DeleteTransportationTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table TransportationType using Stored Procedure
		/// and return number of rows effected of the TransportationType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"TransportationType",InsertNewTransportationTypeCommand(),UpdateTransportationTypeCommand(),DeleteTransportationTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
