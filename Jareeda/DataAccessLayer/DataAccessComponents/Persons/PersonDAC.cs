using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Persons
{
	/// <summary>
	/// This is a Data Access Class  for Person table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Person table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class PersonDAC : DataAccessComponent
	{
		#region Constructors
        public PersonDAC() : base("", "Person.Person") { }
		public PersonDAC(string connectionString): base(connectionString){}
		public PersonDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Person using Stored Procedure
		/// and return a DataTable containing all Person Data
		/// </summary>
		public DataTable GetAllPerson()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Person";
         string query = " select * from GetAllPerson";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Person"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Person using Stored Procedure
		/// and return a DataTable containing all Person Data using a Transaction
		/// </summary>
		public DataTable GetAllPerson(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Person";
         string query = " select * from GetAllPerson";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Person"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Person using Stored Procedure
		/// and return a DataTable containing all Person Data
		/// </summary>
		public DataTable GetAllPerson(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Person";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllPerson" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Person"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Person using Stored Procedure
		/// and return a DataTable containing all Person Data using a Transaction
		/// </summary>
		public DataTable GetAllPerson(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Person";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllPerson" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Person"];

		}


        public System.Data.IDataReader GetByUserNamePerson(string UserName)
		{
            DbCommand command = Database.GetStoredProcCommand("GetByUserNamePerson");
            Database.AddInParameter(command, "UserName", DbType.String, UserName);
            IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

        public System.Data.IDataReader GetByActivationCodePerson(string ActivationCode)
        {
            DbCommand command = Database.GetStoredProcCommand("GetByActivationCodePerson");
            Database.AddInParameter(command, "ActivationCode", DbType.String, ActivationCode);
            IDataReader reader = Database.ExecuteReader(command);
            return reader;
        }
		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Person using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPerson( int businessEntityId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPerson");
				    Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
                    IDataReader reader = this.FromCache(command).CreateDataReader(); //Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Person using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDPerson( int businessEntityId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDPerson");
				    Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Person using Stored Procedure
		/// and return the auto number primary key of Person inserted row
		/// </summary>
        public bool InsertNewPerson(int businessEntityId, bool nameStyle, int emailPromotion, Guid rowGuid, DateTime modifiedDate, DateTime createdDate, string nationalityCode, string gender, DateTime dateofBirth, string PersonImage)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPerson");
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				Database.AddInParameter(command,"NameStyle",DbType.Boolean,nameStyle);
				Database.AddInParameter(command,"EmailPromotion",DbType.Int32,emailPromotion);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"CreatedDate",DbType.DateTime,createdDate);
				Database.AddInParameter(command,"NationalityCode",DbType.String,nationalityCode);
                Database.AddInParameter(command, "Gender", DbType.String, gender);
                
                if(dateofBirth == DateTime.MinValue)
                    Database.AddInParameter(command, "DateOfBirth", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "DateOfBirth", DbType.DateTime, dateofBirth);
                Database.AddInParameter(command, "PersonImage", DbType.String, PersonImage);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Person using Stored Procedure
		/// and return the auto number primary key of Person inserted row using Transaction
		/// </summary>
        public bool InsertNewPerson(int businessEntityId, bool nameStyle, int emailPromotion, Guid rowGuid, DateTime modifiedDate, DateTime createdDate, string nationalityCode, string gender, DateTime dateofBirth, string PersonImage, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPerson");
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
				Database.AddInParameter(command,"NameStyle",DbType.Boolean,nameStyle);
				Database.AddInParameter(command,"EmailPromotion",DbType.Int32,emailPromotion);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
				Database.AddInParameter(command,"CreatedDate",DbType.DateTime,createdDate);
				Database.AddInParameter(command,"NationalityCode",DbType.String,nationalityCode);
                Database.AddInParameter(command, "Gender", DbType.String, gender);
                Database.AddInParameter(command, "PersonImage", DbType.String, PersonImage);
                if (dateofBirth == DateTime.MinValue)
                    Database.AddInParameter(command, "DateOfBirth", DbType.DateTime, DBNull.Value);
                else
                    Database.AddInParameter(command, "DateOfBirth", DbType.DateTime, dateofBirth);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Person using Stored Procedure
		/// and return DbCommand of the Person
		/// </summary>
		public DbCommand InsertNewPersonCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewPerson");
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);
				Database.AddInParameter(command,"NameStyle",DbType.Boolean,"NameStyle",DataRowVersion.Current);
				Database.AddInParameter(command,"EmailPromotion",DbType.Int32,"EmailPromotion",DataRowVersion.Current);
				Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
				Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"CreatedDate",DbType.DateTime,"CreatedDate",DataRowVersion.Current);
				Database.AddInParameter(command,"NationalityCode",DbType.String,"NationalityCode",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Person using Stored Procedure
		/// </summary>
        public bool UpdatePerson(int businessEntityId, bool nameStyle, int emailPromotion, Guid rowGuid, DateTime modifiedDate, DateTime createdDate, string nationalityCode, string gender, DateTime dateofBirth, string PersonImage, int oldbusinessEntityId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePerson");
		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
		    		Database.AddInParameter(command,"NameStyle",DbType.Boolean,nameStyle);
		    		Database.AddInParameter(command,"EmailPromotion",DbType.Int32,emailPromotion);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
		    		Database.AddInParameter(command,"CreatedDate",DbType.DateTime,createdDate);
		    		Database.AddInParameter(command,"NationalityCode",DbType.String,nationalityCode);
                    Database.AddInParameter(command, "Gender", DbType.String, gender);
                    
                    if (dateofBirth == DateTime.MinValue)
                        Database.AddInParameter(command, "DateOfBirth", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "DateOfBirth", DbType.DateTime, dateofBirth);
                    Database.AddInParameter(command, "PersonImage", DbType.String, PersonImage);
				Database.AddInParameter(command,"oldBusinessEntityId",DbType.Int32,oldbusinessEntityId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Person using Stored Procedure By Transaction
		/// </summary>
        public bool UpdatePerson(int businessEntityId, bool nameStyle, int emailPromotion, Guid rowGuid, DateTime modifiedDate, DateTime createdDate, string nationalityCode, string gender, DateTime dateofBirth, string PersonImage, int oldbusinessEntityId, DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePerson");
		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
		    		Database.AddInParameter(command,"NameStyle",DbType.Boolean,nameStyle);
		    		Database.AddInParameter(command,"EmailPromotion",DbType.Int32,emailPromotion);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,rowGuid);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,modifiedDate);
		    		Database.AddInParameter(command,"CreatedDate",DbType.DateTime,createdDate);
		    		Database.AddInParameter(command,"NationalityCode",DbType.String,nationalityCode);
                    Database.AddInParameter(command, "Gender", DbType.String, gender);
                    if (dateofBirth == DateTime.MinValue)
                        Database.AddInParameter(command, "DateOfBirth", DbType.DateTime, DBNull.Value);
                    else
                        Database.AddInParameter(command, "DateOfBirth", DbType.DateTime, dateofBirth);
                    Database.AddInParameter(command, "PersonImage", DbType.String, PersonImage);
				Database.AddInParameter(command,"oldBusinessEntityId",DbType.Int32,oldbusinessEntityId);


				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Person using Stored Procedure
		/// </summary>
		public DbCommand UpdatePersonCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdatePerson");
		    		Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"NameStyle",DbType.Boolean,"NameStyle",DataRowVersion.Current);
		    		Database.AddInParameter(command,"EmailPromotion",DbType.Int32,"EmailPromotion",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RowGuid",DbType.Guid,"RowGuid",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ModifiedDate",DbType.DateTime,"ModifiedDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CreatedDate",DbType.DateTime,"CreatedDate",DataRowVersion.Current);
		    		Database.AddInParameter(command,"NationalityCode",DbType.String,"NationalityCode",DataRowVersion.Current);
				Database.AddInParameter(command,"oldBusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Person using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeletePerson( int businessEntityId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeletePerson");
			Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,businessEntityId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Person Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeletePersonCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeletePerson");
				Database.AddInParameter(command,"BusinessEntityId",DbType.Int32,"BusinessEntityId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Person using Stored Procedure
		/// and return number of rows effected of the Person
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Person",InsertNewPersonCommand(),UpdatePersonCommand(),DeletePersonCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Person using Stored Procedure
		/// and return number of rows effected of the Person
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Person",InsertNewPersonCommand(),UpdatePersonCommand(),DeletePersonCommand(), transaction);
          return rowsAffected;
		}


	}
}
