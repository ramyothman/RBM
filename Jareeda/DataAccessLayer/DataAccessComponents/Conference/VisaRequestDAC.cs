using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for VisaRequest table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the VisaRequest table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class VisaRequestDAC : DataAccessComponent
	{
		#region Constructors
        public VisaRequestDAC() : base("", "Conference.VisaRequest") { }
		public VisaRequestDAC(string connectionString): base(connectionString){}
		public VisaRequestDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all VisaRequest using Stored Procedure
		/// and return a DataTable containing all VisaRequest Data
		/// </summary>
		public DataTable GetAllVisaRequest()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "VisaRequest";
         string query = " select * from GetAllVisaRequest";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["VisaRequest"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all VisaRequest using Stored Procedure
		/// and return a DataTable containing all VisaRequest Data using a Transaction
		/// </summary>
		public DataTable GetAllVisaRequest(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "VisaRequest";
         string query = " select * from GetAllVisaRequest";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["VisaRequest"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all VisaRequest using Stored Procedure
		/// and return a DataTable containing all VisaRequest Data
		/// </summary>
		public DataTable GetAllVisaRequest(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "VisaRequest";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllVisaRequest" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["VisaRequest"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all VisaRequest using Stored Procedure
		/// and return a DataTable containing all VisaRequest Data using a Transaction
		/// </summary>
		public DataTable GetAllVisaRequest(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "VisaRequest";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllVisaRequest" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["VisaRequest"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From VisaRequest using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDVisaRequest( int visaRequestID)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDVisaRequest");
				    Database.AddInParameter(command,"VisaRequestID",DbType.Int32,visaRequestID);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From VisaRequest using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDVisaRequest( int visaRequestID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDVisaRequest");
				    Database.AddInParameter(command,"VisaRequestID",DbType.Int32,visaRequestID);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into VisaRequest using Stored Procedure
		/// and return the auto number primary key of VisaRequest inserted row
		/// </summary>
		public bool InsertNewVisaRequest( ref int visaRequestID,  int conferenceID,  int personID,  string country,  string city,  string religion,  string jobTitle,  string company,  string passportAttachment,  bool isOrganizationApproved,  bool isTaken,  string visaAttachment)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewVisaRequest");
				Database.AddOutParameter(command,"VisaRequestID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceID",DbType.Int32,conferenceID);
				Database.AddInParameter(command,"PersonID",DbType.Int32,personID);
				Database.AddInParameter(command,"Country",DbType.String,country);
				Database.AddInParameter(command,"City",DbType.String,city);
				Database.AddInParameter(command,"Religion",DbType.String,religion);
				Database.AddInParameter(command,"JobTitle",DbType.String,jobTitle);
				Database.AddInParameter(command,"Company",DbType.String,company);
				Database.AddInParameter(command,"PassportAttachment",DbType.String,passportAttachment);
				Database.AddInParameter(command,"IsOrganizationApproved",DbType.Boolean,isOrganizationApproved);
				Database.AddInParameter(command,"IsTaken",DbType.Boolean,isTaken);
				Database.AddInParameter(command,"VisaAttachment",DbType.String,visaAttachment);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 visaRequestID = Convert.ToInt32(Database.GetParameterValue(command, "VisaRequestID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into VisaRequest using Stored Procedure
		/// and return the auto number primary key of VisaRequest inserted row using Transaction
		/// </summary>
		public bool InsertNewVisaRequest( ref int visaRequestID,  int conferenceID,  int personID,  string country,  string city,  string religion,  string jobTitle,  string company,  string passportAttachment,  bool isOrganizationApproved,  bool isTaken,  string visaAttachment,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewVisaRequest");
				Database.AddOutParameter(command,"VisaRequestID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceID",DbType.Int32,conferenceID);
				Database.AddInParameter(command,"PersonID",DbType.Int32,personID);
				Database.AddInParameter(command,"Country",DbType.String,country);
				Database.AddInParameter(command,"City",DbType.String,city);
				Database.AddInParameter(command,"Religion",DbType.String,religion);
				Database.AddInParameter(command,"JobTitle",DbType.String,jobTitle);
				Database.AddInParameter(command,"Company",DbType.String,company);
				Database.AddInParameter(command,"PassportAttachment",DbType.String,passportAttachment);
				Database.AddInParameter(command,"IsOrganizationApproved",DbType.Boolean,isOrganizationApproved);
				Database.AddInParameter(command,"IsTaken",DbType.Boolean,isTaken);
				Database.AddInParameter(command,"VisaAttachment",DbType.String,visaAttachment);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 visaRequestID = Convert.ToInt32(Database.GetParameterValue(command, "VisaRequestID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for VisaRequest using Stored Procedure
		/// and return DbCommand of the VisaRequest
		/// </summary>
		public DbCommand InsertNewVisaRequestCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewVisaRequest");

				Database.AddInParameter(command,"ConferenceID",DbType.Int32,"ConferenceID",DataRowVersion.Current);
				Database.AddInParameter(command,"PersonID",DbType.Int32,"PersonID",DataRowVersion.Current);
				Database.AddInParameter(command,"Country",DbType.String,"Country",DataRowVersion.Current);
				Database.AddInParameter(command,"City",DbType.String,"City",DataRowVersion.Current);
				Database.AddInParameter(command,"Religion",DbType.String,"Religion",DataRowVersion.Current);
				Database.AddInParameter(command,"JobTitle",DbType.String,"JobTitle",DataRowVersion.Current);
				Database.AddInParameter(command,"Company",DbType.String,"Company",DataRowVersion.Current);
				Database.AddInParameter(command,"PassportAttachment",DbType.String,"PassportAttachment",DataRowVersion.Current);
				Database.AddInParameter(command,"IsOrganizationApproved",DbType.Boolean,"IsOrganizationApproved",DataRowVersion.Current);
				Database.AddInParameter(command,"IsTaken",DbType.Boolean,"IsTaken",DataRowVersion.Current);
				Database.AddInParameter(command,"VisaAttachment",DbType.String,"VisaAttachment",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into VisaRequest using Stored Procedure
		/// </summary>
		public bool UpdateVisaRequest( int conferenceID, int personID, string country, string city, string religion, string jobTitle, string company, string passportAttachment, bool isOrganizationApproved, bool isTaken, string visaAttachment, int oldvisaRequestID)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateVisaRequest");

		    		Database.AddInParameter(command,"ConferenceID",DbType.Int32,conferenceID);
		    		Database.AddInParameter(command,"PersonID",DbType.Int32,personID);
		    		Database.AddInParameter(command,"Country",DbType.String,country);
		    		Database.AddInParameter(command,"City",DbType.String,city);
		    		Database.AddInParameter(command,"Religion",DbType.String,religion);
		    		Database.AddInParameter(command,"JobTitle",DbType.String,jobTitle);
		    		Database.AddInParameter(command,"Company",DbType.String,company);
		    		Database.AddInParameter(command,"PassportAttachment",DbType.String,passportAttachment);
		    		Database.AddInParameter(command,"IsOrganizationApproved",DbType.Boolean,isOrganizationApproved);
		    		Database.AddInParameter(command,"IsTaken",DbType.Boolean,isTaken);
		    		Database.AddInParameter(command,"VisaAttachment",DbType.String,visaAttachment);
				Database.AddInParameter(command,"oldVisaRequestID",DbType.Int32,oldvisaRequestID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into VisaRequest using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateVisaRequest( int conferenceID, int personID, string country, string city, string religion, string jobTitle, string company, string passportAttachment, bool isOrganizationApproved, bool isTaken, string visaAttachment, int oldvisaRequestID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateVisaRequest");

		    		Database.AddInParameter(command,"ConferenceID",DbType.Int32,conferenceID);
		    		Database.AddInParameter(command,"PersonID",DbType.Int32,personID);
		    		Database.AddInParameter(command,"Country",DbType.String,country);
		    		Database.AddInParameter(command,"City",DbType.String,city);
		    		Database.AddInParameter(command,"Religion",DbType.String,religion);
		    		Database.AddInParameter(command,"JobTitle",DbType.String,jobTitle);
		    		Database.AddInParameter(command,"Company",DbType.String,company);
		    		Database.AddInParameter(command,"PassportAttachment",DbType.String,passportAttachment);
		    		Database.AddInParameter(command,"IsOrganizationApproved",DbType.Boolean,isOrganizationApproved);
		    		Database.AddInParameter(command,"IsTaken",DbType.Boolean,isTaken);
		    		Database.AddInParameter(command,"VisaAttachment",DbType.String,visaAttachment);
				Database.AddInParameter(command,"oldVisaRequestID",DbType.Int32,oldvisaRequestID);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from VisaRequest using Stored Procedure
		/// </summary>
		public DbCommand UpdateVisaRequestCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateVisaRequest");

		    		Database.AddInParameter(command,"ConferenceID",DbType.Int32,"ConferenceID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PersonID",DbType.Int32,"PersonID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Country",DbType.String,"Country",DataRowVersion.Current);
		    		Database.AddInParameter(command,"City",DbType.String,"City",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Religion",DbType.String,"Religion",DataRowVersion.Current);
		    		Database.AddInParameter(command,"JobTitle",DbType.String,"JobTitle",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Company",DbType.String,"Company",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PassportAttachment",DbType.String,"PassportAttachment",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsOrganizationApproved",DbType.Boolean,"IsOrganizationApproved",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsTaken",DbType.Boolean,"IsTaken",DataRowVersion.Current);
		    		Database.AddInParameter(command,"VisaAttachment",DbType.String,"VisaAttachment",DataRowVersion.Current);
				Database.AddInParameter(command,"oldVisaRequestID",DbType.Int32,"VisaRequestID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From VisaRequest using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteVisaRequest( int visaRequestID)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteVisaRequest");
			Database.AddInParameter(command,"VisaRequestID",DbType.Int32,visaRequestID);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From VisaRequest Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteVisaRequestCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteVisaRequest");
				Database.AddInParameter(command,"VisaRequestID",DbType.Int32,"VisaRequestID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table VisaRequest using Stored Procedure
		/// and return number of rows effected of the VisaRequest
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"VisaRequest",InsertNewVisaRequestCommand(),UpdateVisaRequestCommand(),DeleteVisaRequestCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table VisaRequest using Stored Procedure
		/// and return number of rows effected of the VisaRequest
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"VisaRequest",InsertNewVisaRequestCommand(),UpdateVisaRequestCommand(),DeleteVisaRequestCommand(), transaction);
          return rowsAffected;
		}


	}
}
