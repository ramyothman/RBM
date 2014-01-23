using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for Hotel table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Hotel table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class HotelDAC : DataAccessComponent
	{
		#region Constructors
        public HotelDAC() : base("", "Conference.Hotel") { }
		public HotelDAC(string connectionString): base(connectionString){}
		public HotelDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Hotel using Stored Procedure
		/// and return a DataTable containing all Hotel Data
		/// </summary>
		public DataTable GetAllHotel()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Hotel";
         string query = " select * from GetAllHotel";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Hotel"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Hotel using Stored Procedure
		/// and return a DataTable containing all Hotel Data using a Transaction
		/// </summary>
		public DataTable GetAllHotel(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Hotel";
         string query = " select * from GetAllHotel";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Hotel"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Hotel using Stored Procedure
		/// and return a DataTable containing all Hotel Data
		/// </summary>
		public DataTable GetAllHotel(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Hotel";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllHotel" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Hotel"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Hotel using Stored Procedure
		/// and return a DataTable containing all Hotel Data using a Transaction
		/// </summary>
		public DataTable GetAllHotel(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Hotel";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllHotel" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Hotel"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Hotel using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDHotel( int iD)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDHotel");
				    Database.AddInParameter(command,"ID",DbType.Int32,iD);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Hotel using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDHotel( int iD,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDHotel");
				    Database.AddInParameter(command,"ID",DbType.Int32,iD);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Hotel using Stored Procedure
		/// and return the auto number primary key of Hotel inserted row
		/// </summary>
		public bool InsertNewHotel( ref int iD,  string name,  string description,  string location,  int star,  string uRL,  string phone,  string fax,  string email,int ConferenceID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewHotel");
				Database.AddOutParameter(command,"ID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"Location",DbType.String,location);
				Database.AddInParameter(command,"Star",DbType.Int32,star);
				Database.AddInParameter(command,"URL",DbType.String,uRL);
				Database.AddInParameter(command,"Phone",DbType.String,phone);
				Database.AddInParameter(command,"Fax",DbType.String,fax);
				Database.AddInParameter(command,"Email",DbType.String,email);
                Database.AddInParameter(command, "ConferenceID", DbType.Int32, ConferenceID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Hotel using Stored Procedure
		/// and return the auto number primary key of Hotel inserted row using Transaction
		/// </summary>
        public bool InsertNewHotel(ref int iD, string name, string description, string location, int star, string uRL, string phone, string fax, string email, int ConferenceID, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewHotel");
				Database.AddOutParameter(command,"ID",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"Name",DbType.String,name);
				Database.AddInParameter(command,"Description",DbType.String,description);
				Database.AddInParameter(command,"Location",DbType.String,location);
				Database.AddInParameter(command,"Star",DbType.Int32,star);
				Database.AddInParameter(command,"URL",DbType.String,uRL);
				Database.AddInParameter(command,"Phone",DbType.String,phone);
				Database.AddInParameter(command,"Fax",DbType.String,fax);
				Database.AddInParameter(command,"Email",DbType.String,email);
                Database.AddInParameter(command, "ConferenceID", DbType.Int32, ConferenceID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 iD = Convert.ToInt32(Database.GetParameterValue(command, "ID"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Hotel using Stored Procedure
		/// and return DbCommand of the Hotel
		/// </summary>
		public DbCommand InsertNewHotelCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewHotel");

				Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
				Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
				Database.AddInParameter(command,"Location",DbType.String,"Location",DataRowVersion.Current);
				Database.AddInParameter(command,"Star",DbType.Int32,"Star",DataRowVersion.Current);
				Database.AddInParameter(command,"URL",DbType.String,"URL",DataRowVersion.Current);
				Database.AddInParameter(command,"Phone",DbType.String,"Phone",DataRowVersion.Current);
				Database.AddInParameter(command,"Fax",DbType.String,"Fax",DataRowVersion.Current);
				Database.AddInParameter(command,"Email",DbType.String,"Email",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Hotel using Stored Procedure
		/// </summary>
        public bool UpdateHotel(string name, string description, string location, int star, string uRL, string phone, string fax, string email, int ConferenceID, int oldiD)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateHotel");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"Location",DbType.String,location);
		    		Database.AddInParameter(command,"Star",DbType.Int32,star);
		    		Database.AddInParameter(command,"URL",DbType.String,uRL);
		    		Database.AddInParameter(command,"Phone",DbType.String,phone);
		    		Database.AddInParameter(command,"Fax",DbType.String,fax);
		    		Database.AddInParameter(command,"Email",DbType.String,email);
                    Database.AddInParameter(command, "ConferenceID", DbType.Int32, ConferenceID);
				Database.AddInParameter(command,"oldID",DbType.Int32,oldiD);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Hotel using Stored Procedure By Transaction
		/// </summary>
        public bool UpdateHotel(string name, string description, string location, int star, string uRL, string phone, string fax, string email, int ConferenceID, int oldiD, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateHotel");

		    		Database.AddInParameter(command,"Name",DbType.String,name);
		    		Database.AddInParameter(command,"Description",DbType.String,description);
		    		Database.AddInParameter(command,"Location",DbType.String,location);
		    		Database.AddInParameter(command,"Star",DbType.Int32,star);
		    		Database.AddInParameter(command,"URL",DbType.String,uRL);
		    		Database.AddInParameter(command,"Phone",DbType.String,phone);
		    		Database.AddInParameter(command,"Fax",DbType.String,fax);
		    		Database.AddInParameter(command,"Email",DbType.String,email);
                    Database.AddInParameter(command, "ConferenceID", DbType.Int32, ConferenceID);
				Database.AddInParameter(command,"oldID",DbType.Int32,oldiD);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Hotel using Stored Procedure
		/// </summary>
		public DbCommand UpdateHotelCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateHotel");

		    		Database.AddInParameter(command,"Name",DbType.String,"Name",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Description",DbType.String,"Description",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Location",DbType.String,"Location",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Star",DbType.Int32,"Star",DataRowVersion.Current);
		    		Database.AddInParameter(command,"URL",DbType.String,"URL",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Phone",DbType.String,"Phone",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Fax",DbType.String,"Fax",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Email",DbType.String,"Email",DataRowVersion.Current);
				Database.AddInParameter(command,"oldID",DbType.Int32,"ID",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Hotel using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteHotel( int iD)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteHotel");
			Database.AddInParameter(command,"ID",DbType.Int32,iD);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Hotel Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteHotelCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteHotel");
				Database.AddInParameter(command,"ID",DbType.Int32,"ID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Hotel using Stored Procedure
		/// and return number of rows effected of the Hotel
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Hotel",InsertNewHotelCommand(),UpdateHotelCommand(),DeleteHotelCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Hotel using Stored Procedure
		/// and return number of rows effected of the Hotel
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Hotel",InsertNewHotelCommand(),UpdateHotelCommand(),DeleteHotelCommand(), transaction);
          return rowsAffected;
		}


	}
}
