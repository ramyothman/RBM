using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for ConferenceRegistrationType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ConferenceRegistrationType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class ConferenceRegistrationTypeDAC : DataAccessComponent
	{
		#region Constructors
        public ConferenceRegistrationTypeDAC() : base("", "Conference.ConferenceRegistrationType") { }
		public ConferenceRegistrationTypeDAC(string connectionString): base(connectionString){}
		public ConferenceRegistrationTypeDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationType using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationType Data
		/// </summary>
		public DataTable GetAllConferenceRegistrationType()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationType";
         string query = " select * from GetAllConferenceRegistrationType";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceRegistrationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationType using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationType Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceRegistrationType(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationType";
         string query = " select * from GetAllConferenceRegistrationType";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceRegistrationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationType using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationType Data
		/// </summary>
		public DataTable GetAllConferenceRegistrationType(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllConferenceRegistrationType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["ConferenceRegistrationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ConferenceRegistrationType using Stored Procedure
		/// and return a DataTable containing all ConferenceRegistrationType Data using a Transaction
		/// </summary>
		public DataTable GetAllConferenceRegistrationType(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "ConferenceRegistrationType";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllConferenceRegistrationType" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["ConferenceRegistrationType"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceRegistrationType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceRegistrationType( int conferenceRegistrationTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceRegistrationType");
				    Database.AddInParameter(command,"ConferenceRegistrationTypeId",DbType.Int32,conferenceRegistrationTypeId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ConferenceRegistrationType using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDConferenceRegistrationType( int conferenceRegistrationTypeId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDConferenceRegistrationType");
				    Database.AddInParameter(command,"ConferenceRegistrationTypeId",DbType.Int32,conferenceRegistrationTypeId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceRegistrationType using Stored Procedure
		/// and return the auto number primary key of ConferenceRegistrationType inserted row
		/// </summary>
		public bool InsertNewConferenceRegistrationType( ref int conferenceRegistrationTypeId,  int conferenceId,  string name,  decimal fee,string GroupName,DateTime StartDate,DateTime EndDate,DateTime EarlyRegistrationEndDate,decimal LateFee,int ConferenceScheduleID,DateTime OfferStartDate,DateTime OfferEndDate,decimal OfferFee,bool HaveOffer,bool MustRegister)
		{
                DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceRegistrationType");
				Database.AddOutParameter(command,"ConferenceRegistrationTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Fee",DbType.Decimal,fee);
                Database.AddInParameter(command, "GroupName", DbType.String, GroupName);
                if(StartDate == DateTime.MinValue)
                    Database.AddInParameter(command, "StartDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "StartDate", DbType.DateTime, StartDate);
                if (EndDate == DateTime.MinValue)
                    Database.AddInParameter(command, "EndDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "EndDate", DbType.DateTime, EndDate);
                if (EarlyRegistrationEndDate == DateTime.MinValue)
                    Database.AddInParameter(command, "EarlyRegistrationEndDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "EarlyRegistrationEndDate", DbType.DateTime, EarlyRegistrationEndDate);
                if (OfferStartDate == DateTime.MinValue)
                    Database.AddInParameter(command, "OfferStartDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "OfferStartDate", DbType.DateTime, OfferStartDate);
                if (OfferEndDate == DateTime.MinValue)
                    Database.AddInParameter(command, "OfferEndDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "OfferEndDate", DbType.DateTime, OfferEndDate);

                Database.AddInParameter(command, "LateFee", DbType.Decimal, LateFee);
                Database.AddInParameter(command, "OfferFee", DbType.Decimal, OfferFee);
                if (ConferenceScheduleID == 0)    
                    Database.AddInParameter(command, "ConferenceScheduleID", DbType.Int32, DBNull.Value);
                else
                    Database.AddInParameter(command, "ConferenceScheduleID", DbType.Int32, ConferenceScheduleID);
                Database.AddInParameter(command, "HaveOffer", DbType.Boolean, HaveOffer);
                Database.AddInParameter(command, "MustRegister", DbType.Boolean, MustRegister);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 conferenceRegistrationTypeId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceRegistrationTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ConferenceRegistrationType using Stored Procedure
		/// and return the auto number primary key of ConferenceRegistrationType inserted row using Transaction
		/// </summary>
        public bool InsertNewConferenceRegistrationType(ref int conferenceRegistrationTypeId, int conferenceId, string name, decimal fee, string GroupName, DateTime StartDate, DateTime EndDate, DateTime EarlyRegistrationEndDate, decimal LateFee, int ConferenceScheduleID, DateTime OfferStartDate, DateTime OfferEndDate, decimal OfferFee, bool HaveOffer, bool MustRegister, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceRegistrationType");
				Database.AddOutParameter(command,"ConferenceRegistrationTypeId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Fee",DbType.Decimal,fee);
                Database.AddInParameter(command, "GroupName", DbType.String, GroupName);
                if (StartDate == DateTime.MinValue)
                    Database.AddInParameter(command, "StartDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "StartDate", DbType.DateTime, StartDate);
                if (EndDate == DateTime.MinValue)
                    Database.AddInParameter(command, "EndDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "EndDate", DbType.DateTime, EndDate);
                if (EarlyRegistrationEndDate == DateTime.MinValue)
                    Database.AddInParameter(command, "EarlyRegistrationEndDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "EarlyRegistrationEndDate", DbType.DateTime, EarlyRegistrationEndDate);
                if (OfferStartDate == DateTime.MinValue)
                    Database.AddInParameter(command, "OfferStartDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "OfferStartDate", DbType.DateTime, OfferStartDate);
                if (OfferEndDate == DateTime.MinValue)
                    Database.AddInParameter(command, "OfferEndDate", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "OfferEndDate", DbType.DateTime, OfferEndDate);

                Database.AddInParameter(command, "LateFee", DbType.Decimal, LateFee);
                Database.AddInParameter(command, "OfferFee", DbType.Decimal, OfferFee);
                if (ConferenceScheduleID == 0)
                    Database.AddInParameter(command, "ConferenceScheduleID", DbType.Int32, DBNull.Value);
                else
                    Database.AddInParameter(command, "ConferenceScheduleID", DbType.Int32, ConferenceScheduleID);
                Database.AddInParameter(command, "HaveOffer", DbType.Boolean, HaveOffer);
                Database.AddInParameter(command, "MustRegister", DbType.Boolean, MustRegister);	
            bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 conferenceRegistrationTypeId = Convert.ToInt32(Database.GetParameterValue(command, "ConferenceRegistrationTypeId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ConferenceRegistrationType using Stored Procedure
		/// and return DbCommand of the ConferenceRegistrationType
		/// </summary>
		public DbCommand InsertNewConferenceRegistrationTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewConferenceRegistrationType");

				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"Fee",DbType.Decimal,"Fee",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceRegistrationType using Stored Procedure
		/// </summary>
        public bool UpdateConferenceRegistrationType(int conferenceId, string name, decimal fee, string GroupName, DateTime StartDate, DateTime EndDate, DateTime EarlyRegistrationEndDate, decimal LateFee, int ConferenceScheduleID, DateTime OfferStartDate, DateTime OfferEndDate, decimal OfferFee, bool HaveOffer, bool MustRegister, int oldconferenceRegistrationTypeId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceRegistrationType");

		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Fee",DbType.Decimal,fee);
                    Database.AddInParameter(command, "GroupName", DbType.String, GroupName);
                    if (StartDate == DateTime.MinValue)
                        Database.AddInParameter(command, "StartDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "StartDate", DbType.DateTime, StartDate);
                    if (EndDate == DateTime.MinValue)
                        Database.AddInParameter(command, "EndDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "EndDate", DbType.DateTime, EndDate);
                    if (EarlyRegistrationEndDate == DateTime.MinValue)
                        Database.AddInParameter(command, "EarlyRegistrationEndDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "EarlyRegistrationEndDate", DbType.DateTime, EarlyRegistrationEndDate);
                    if (OfferStartDate == DateTime.MinValue)
                        Database.AddInParameter(command, "OfferStartDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "OfferStartDate", DbType.DateTime, OfferStartDate);
                    if (OfferEndDate == DateTime.MinValue)
                        Database.AddInParameter(command, "OfferEndDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "OfferEndDate", DbType.DateTime, OfferEndDate);

                    Database.AddInParameter(command, "LateFee", DbType.Decimal, LateFee);
                    Database.AddInParameter(command, "OfferFee", DbType.Decimal, OfferFee);
                    if (ConferenceScheduleID == 0)
                        Database.AddInParameter(command, "ConferenceScheduleID", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "ConferenceScheduleID", DbType.Int32, ConferenceScheduleID);
                    Database.AddInParameter(command, "HaveOffer", DbType.Boolean, HaveOffer);
                    Database.AddInParameter(command, "MustRegister", DbType.Boolean, MustRegister);
				Database.AddInParameter(command,"oldConferenceRegistrationTypeId",DbType.Int32,oldconferenceRegistrationTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ConferenceRegistrationType using Stored Procedure By Transaction
		/// </summary>
        public bool UpdateConferenceRegistrationType(int conferenceId, string name, decimal fee, string GroupName, DateTime StartDate, DateTime EndDate, DateTime EarlyRegistrationEndDate, decimal LateFee, int ConferenceScheduleID, DateTime OfferStartDate, DateTime OfferEndDate, decimal OfferFee, bool HaveOffer, bool MustRegister, int oldconferenceRegistrationTypeId, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceRegistrationType");

		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Fee",DbType.Decimal,fee);
                    Database.AddInParameter(command, "GroupName", DbType.String, GroupName);
                    if (StartDate == DateTime.MinValue)
                        Database.AddInParameter(command, "StartDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "StartDate", DbType.DateTime, StartDate);
                    if (EndDate == DateTime.MinValue)
                        Database.AddInParameter(command, "EndDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "EndDate", DbType.DateTime, EndDate);
                    if (EarlyRegistrationEndDate == DateTime.MinValue)
                        Database.AddInParameter(command, "EarlyRegistrationEndDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "EarlyRegistrationEndDate", DbType.DateTime, EarlyRegistrationEndDate);
                    if (OfferStartDate == DateTime.MinValue)
                        Database.AddInParameter(command, "OfferStartDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "OfferStartDate", DbType.DateTime, OfferStartDate);
                    if (OfferEndDate == DateTime.MinValue)
                        Database.AddInParameter(command, "OfferEndDate", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "OfferEndDate", DbType.DateTime, OfferEndDate);

                    Database.AddInParameter(command, "LateFee", DbType.Decimal, LateFee);
                    Database.AddInParameter(command, "OfferFee", DbType.Decimal, OfferFee);
                    if (ConferenceScheduleID == 0)
                        Database.AddInParameter(command, "ConferenceScheduleID", DbType.Int32, DBNull.Value);
                    else
                        Database.AddInParameter(command, "ConferenceScheduleID", DbType.Int32, ConferenceScheduleID);
                    Database.AddInParameter(command, "HaveOffer", DbType.Boolean, HaveOffer);
                    Database.AddInParameter(command, "MustRegister", DbType.Boolean, MustRegister);
				Database.AddInParameter(command,"oldConferenceRegistrationTypeId",DbType.Int32,oldconferenceRegistrationTypeId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ConferenceRegistrationType using Stored Procedure
		/// </summary>
		public DbCommand UpdateConferenceRegistrationTypeCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateConferenceRegistrationType");

		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Fee",DbType.Decimal,"Fee",DataRowVersion.Current);
				Database.AddInParameter(command,"oldConferenceRegistrationTypeId",DbType.Int32,"ConferenceRegistrationTypeId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ConferenceRegistrationType using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteConferenceRegistrationType( int conferenceRegistrationTypeId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteConferenceRegistrationType");
			Database.AddInParameter(command,"ConferenceRegistrationTypeId",DbType.Int32,conferenceRegistrationTypeId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ConferenceRegistrationType Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteConferenceRegistrationTypeCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteConferenceRegistrationType");
				Database.AddInParameter(command,"ConferenceRegistrationTypeId",DbType.Int32,"ConferenceRegistrationTypeId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceRegistrationType using Stored Procedure
		/// and return number of rows effected of the ConferenceRegistrationType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceRegistrationType",InsertNewConferenceRegistrationTypeCommand(),UpdateConferenceRegistrationTypeCommand(),DeleteConferenceRegistrationTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ConferenceRegistrationType using Stored Procedure
		/// and return number of rows effected of the ConferenceRegistrationType
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"ConferenceRegistrationType",InsertNewConferenceRegistrationTypeCommand(),UpdateConferenceRegistrationTypeCommand(),DeleteConferenceRegistrationTypeCommand(), transaction);
          return rowsAffected;
		}


	}
}
