using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for PersonPublication table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the PersonPublication table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PersonPublicationDAC : DataAccessComponent
	{
		#region Constructors
        public PersonPublicationDAC() : base("", "Person.PersonPublication") { }
		public PersonPublicationDAC(string connectionString): base(connectionString){}
		public PersonPublicationDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonPublication using Stored Procedure
		/// and return a DataTable containing all PersonPublication Data
		/// </summary>
		public DataTable GetAllPersonPublication()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonPublication";
         string query = " select * from GetAllPersonPublication";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonPublication"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonPublication using Stored Procedure
		/// and return a DataTable containing all PersonPublication Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonPublication(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonPublication";
         string query = " select * from GetAllPersonPublication";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonPublication"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonPublication using Stored Procedure
		/// and return a DataTable containing all PersonPublication Data
		/// </summary>
		public DataTable GetAllPersonPublication(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonPublication";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPersonPublication" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["PersonPublication"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all PersonPublication using Stored Procedure
		/// and return a DataTable containing all PersonPublication Data using a Transaction
		/// </summary>
		public DataTable GetAllPersonPublication(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "PersonPublication";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPersonPublication" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["PersonPublication"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonPublication using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonPublication( int personPublicationId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonPublication");
				    Database.AddInParameter(command,"PersonPublicationId",DbType.Int32,personPublicationId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From PersonPublication using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPersonPublication( int personPublicationId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPersonPublication");
				    Database.AddInParameter(command,"PersonPublicationId",DbType.Int32,personPublicationId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonPublication using Stored Procedure
		/// and return the auto number primary key of PersonPublication inserted row
		/// </summary>
		public bool InsertNewPersonPublication( ref int personPublicationId,  int personId,  string publicationTitle,  string publicationAbstract,  string publicationAttachmentPath)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonPublication");
				Database.AddOutParameter(command,"PersonPublicationId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"PublicationTitle",DbType.String,publicationTitle);
				Database.AddInParameter(command,"PublicationAbstract",DbType.String,publicationAbstract);
				Database.AddInParameter(command,"PublicationAttachmentPath",DbType.String,publicationAttachmentPath);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 personPublicationId = Convert.ToInt32(Database.GetParameterValue(command, "PersonPublicationId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into PersonPublication using Stored Procedure
		/// and return the auto number primary key of PersonPublication inserted row using Transaction
		/// </summary>
		public bool InsertNewPersonPublication( ref int personPublicationId,  int personId,  string publicationTitle,  string publicationAbstract,  string publicationAttachmentPath,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonPublication");
				Database.AddOutParameter(command,"PersonPublicationId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"PublicationTitle",DbType.String,publicationTitle);
				Database.AddInParameter(command,"PublicationAbstract",DbType.String,publicationAbstract);
				Database.AddInParameter(command,"PublicationAttachmentPath",DbType.String,publicationAttachmentPath);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 personPublicationId = Convert.ToInt32(Database.GetParameterValue(command, "PersonPublicationId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for PersonPublication using Stored Procedure
		/// and return DbCommand of the PersonPublication
		/// </summary>
		public DbCommand InsertNewPersonPublicationCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPersonPublication");

				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				Database.AddInParameter(command,"PublicationTitle",DbType.String,"PublicationTitle",DataRowVersion.Current);
				Database.AddInParameter(command,"PublicationAbstract",DbType.String,"PublicationAbstract",DataRowVersion.Current);
				Database.AddInParameter(command,"PublicationAttachmentPath",DbType.String,"PublicationAttachmentPath",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonPublication using Stored Procedure
		/// </summary>
		public bool UpdatePersonPublication( int personId, string publicationTitle, string publicationAbstract, string publicationAttachmentPath, int oldpersonPublicationId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonPublication");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"PublicationTitle",DbType.String,publicationTitle);
		    		Database.AddInParameter(command,"PublicationAbstract",DbType.String,publicationAbstract);
		    		Database.AddInParameter(command,"PublicationAttachmentPath",DbType.String,publicationAttachmentPath);
				Database.AddInParameter(command,"oldPersonPublicationId",DbType.Int32,oldpersonPublicationId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into PersonPublication using Stored Procedure By Transaction
		/// </summary>
		public bool UpdatePersonPublication( int personId, string publicationTitle, string publicationAbstract, string publicationAttachmentPath, int oldpersonPublicationId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonPublication");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"PublicationTitle",DbType.String,publicationTitle);
		    		Database.AddInParameter(command,"PublicationAbstract",DbType.String,publicationAbstract);
		    		Database.AddInParameter(command,"PublicationAttachmentPath",DbType.String,publicationAttachmentPath);
				Database.AddInParameter(command,"oldPersonPublicationId",DbType.Int32,oldpersonPublicationId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from PersonPublication using Stored Procedure
		/// </summary>
		public DbCommand UpdatePersonPublicationCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePersonPublication");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PublicationTitle",DbType.String,"PublicationTitle",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PublicationAbstract",DbType.String,"PublicationAbstract",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PublicationAttachmentPath",DbType.String,"PublicationAttachmentPath",DataRowVersion.Current);
				Database.AddInParameter(command,"oldPersonPublicationId",DbType.Int32,"PersonPublicationId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From PersonPublication using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePersonPublication( int personPublicationId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePersonPublication");
			Database.AddInParameter(command,"PersonPublicationId",DbType.Int32,personPublicationId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From PersonPublication Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePersonPublicationCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePersonPublication");
				Database.AddInParameter(command,"PersonPublicationId",DbType.Int32,"PersonPublicationId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonPublication using Stored Procedure
		/// and return number of rows effected of the PersonPublication
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonPublication",InsertNewPersonPublicationCommand(),UpdatePersonPublicationCommand(),DeletePersonPublicationCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table PersonPublication using Stored Procedure
		/// and return number of rows effected of the PersonPublication
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"PersonPublication",InsertNewPersonPublicationCommand(),UpdatePersonPublicationCommand(),DeletePersonPublicationCommand(), transaction);
          return rowsAffected;
		}


	}
}
