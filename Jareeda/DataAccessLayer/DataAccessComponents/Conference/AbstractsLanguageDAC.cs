using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for AbstractsLanguage table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the AbstractsLanguage table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class AbstractsLanguageDAC : DataAccessComponent
	{
		#region Constructors
        public AbstractsLanguageDAC() : base("", "Conference.AbstractsLanguage") { }
		public AbstractsLanguageDAC(string connectionString): base(connectionString){}
		public AbstractsLanguageDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractsLanguage using Stored Procedure
		/// and return a DataTable containing all AbstractsLanguage Data
		/// </summary>
		public DataTable GetAllAbstractsLanguage()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractsLanguage";
         string query = " select * from GetAllAbstractsLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["AbstractsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractsLanguage using Stored Procedure
		/// and return a DataTable containing all AbstractsLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstractsLanguage(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractsLanguage";
         string query = " select * from GetAllAbstractsLanguage";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["AbstractsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractsLanguage using Stored Procedure
		/// and return a DataTable containing all AbstractsLanguage Data
		/// </summary>
		public DataTable GetAllAbstractsLanguage(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractsLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllAbstractsLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["AbstractsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all AbstractsLanguage using Stored Procedure
		/// and return a DataTable containing all AbstractsLanguage Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstractsLanguage(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "AbstractsLanguage";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllAbstractsLanguage" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["AbstractsLanguage"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From AbstractsLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstractsLanguage( int abstractLanguageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstractsLanguage");
				    Database.AddInParameter(command,"AbstractLanguageId",DbType.Int32,abstractLanguageId);
				IDataReader reader  = Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From AbstractsLanguage using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstractsLanguage( int abstractLanguageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstractsLanguage");
				    Database.AddInParameter(command,"AbstractLanguageId",DbType.Int32,abstractLanguageId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into AbstractsLanguage using Stored Procedure
		/// and return the auto number primary key of AbstractsLanguage inserted row
		/// </summary>
		public bool InsertNewAbstractsLanguage( ref int abstractLanguageId,  int abstractId,  string abstractTitle,  string abstractIntro,  string coverLetter,  string topic,  string background,  string methods,  string results,  string conclusions,  string abstractTerms,  string abstractKeywords,  int languageID)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractsLanguage");
				Database.AddOutParameter(command,"AbstractLanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"AbstractId",DbType.Int32,abstractId);
				Database.AddInParameter(command,"AbstractTitle",DbType.String,abstractTitle);
				Database.AddInParameter(command,"AbstractIntro",DbType.String,abstractIntro);
				Database.AddInParameter(command,"CoverLetter",DbType.String,coverLetter);
				Database.AddInParameter(command,"Topic",DbType.String,topic);
				Database.AddInParameter(command,"Background",DbType.String,background);
				Database.AddInParameter(command,"Methods",DbType.String,methods);
				Database.AddInParameter(command,"Results",DbType.String,results);
				Database.AddInParameter(command,"Conclusions",DbType.String,conclusions);
				Database.AddInParameter(command,"AbstractTerms",DbType.String,abstractTerms);
				Database.AddInParameter(command,"AbstractKeywords",DbType.String,abstractKeywords);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 abstractLanguageId = Convert.ToInt32(Database.GetParameterValue(command, "AbstractLanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into AbstractsLanguage using Stored Procedure
		/// and return the auto number primary key of AbstractsLanguage inserted row using Transaction
		/// </summary>
		public bool InsertNewAbstractsLanguage( ref int abstractLanguageId,  int abstractId,  string abstractTitle,  string abstractIntro,  string coverLetter,  string topic,  string background,  string methods,  string results,  string conclusions,  string abstractTerms,  string abstractKeywords,  int languageID,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractsLanguage");
				Database.AddOutParameter(command,"AbstractLanguageId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"AbstractId",DbType.Int32,abstractId);
				Database.AddInParameter(command,"AbstractTitle",DbType.String,abstractTitle);
				Database.AddInParameter(command,"AbstractIntro",DbType.String,abstractIntro);
				Database.AddInParameter(command,"CoverLetter",DbType.String,coverLetter);
				Database.AddInParameter(command,"Topic",DbType.String,topic);
				Database.AddInParameter(command,"Background",DbType.String,background);
				Database.AddInParameter(command,"Methods",DbType.String,methods);
				Database.AddInParameter(command,"Results",DbType.String,results);
				Database.AddInParameter(command,"Conclusions",DbType.String,conclusions);
				Database.AddInParameter(command,"AbstractTerms",DbType.String,abstractTerms);
				Database.AddInParameter(command,"AbstractKeywords",DbType.String,abstractKeywords);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 abstractLanguageId = Convert.ToInt32(Database.GetParameterValue(command, "AbstractLanguageId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for AbstractsLanguage using Stored Procedure
		/// and return DbCommand of the AbstractsLanguage
		/// </summary>
		public DbCommand InsertNewAbstractsLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstractsLanguage");

				Database.AddInParameter(command,"AbstractId",DbType.Int32,"AbstractId",DataRowVersion.Current);
				Database.AddInParameter(command,"AbstractTitle",DbType.String,"AbstractTitle",DataRowVersion.Current);
				Database.AddInParameter(command,"AbstractIntro",DbType.String,"AbstractIntro",DataRowVersion.Current);
				Database.AddInParameter(command,"CoverLetter",DbType.String,"CoverLetter",DataRowVersion.Current);
				Database.AddInParameter(command,"Topic",DbType.String,"Topic",DataRowVersion.Current);
				Database.AddInParameter(command,"Background",DbType.String,"Background",DataRowVersion.Current);
				Database.AddInParameter(command,"Methods",DbType.String,"Methods",DataRowVersion.Current);
				Database.AddInParameter(command,"Results",DbType.String,"Results",DataRowVersion.Current);
				Database.AddInParameter(command,"Conclusions",DbType.String,"Conclusions",DataRowVersion.Current);
				Database.AddInParameter(command,"AbstractTerms",DbType.String,"AbstractTerms",DataRowVersion.Current);
				Database.AddInParameter(command,"AbstractKeywords",DbType.String,"AbstractKeywords",DataRowVersion.Current);
				Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into AbstractsLanguage using Stored Procedure
		/// </summary>
		public bool UpdateAbstractsLanguage( int abstractId, string abstractTitle, string abstractIntro, string coverLetter, string topic, string background, string methods, string results, string conclusions, string abstractTerms, string abstractKeywords, int languageID, int oldabstractLanguageId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractsLanguage");

		    		Database.AddInParameter(command,"AbstractId",DbType.Int32,abstractId);
		    		Database.AddInParameter(command,"AbstractTitle",DbType.String,abstractTitle);
		    		Database.AddInParameter(command,"AbstractIntro",DbType.String,abstractIntro);
		    		Database.AddInParameter(command,"CoverLetter",DbType.String,coverLetter);
		    		Database.AddInParameter(command,"Topic",DbType.String,topic);
		    		Database.AddInParameter(command,"Background",DbType.String,background);
		    		Database.AddInParameter(command,"Methods",DbType.String,methods);
		    		Database.AddInParameter(command,"Results",DbType.String,results);
		    		Database.AddInParameter(command,"Conclusions",DbType.String,conclusions);
		    		Database.AddInParameter(command,"AbstractTerms",DbType.String,abstractTerms);
		    		Database.AddInParameter(command,"AbstractKeywords",DbType.String,abstractKeywords);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"oldAbstractLanguageId",DbType.Int32,oldabstractLanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into AbstractsLanguage using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateAbstractsLanguage( int abstractId, string abstractTitle, string abstractIntro, string coverLetter, string topic, string background, string methods, string results, string conclusions, string abstractTerms, string abstractKeywords, int languageID, int oldabstractLanguageId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractsLanguage");

		    		Database.AddInParameter(command,"AbstractId",DbType.Int32,abstractId);
		    		Database.AddInParameter(command,"AbstractTitle",DbType.String,abstractTitle);
		    		Database.AddInParameter(command,"AbstractIntro",DbType.String,abstractIntro);
		    		Database.AddInParameter(command,"CoverLetter",DbType.String,coverLetter);
		    		Database.AddInParameter(command,"Topic",DbType.String,topic);
		    		Database.AddInParameter(command,"Background",DbType.String,background);
		    		Database.AddInParameter(command,"Methods",DbType.String,methods);
		    		Database.AddInParameter(command,"Results",DbType.String,results);
		    		Database.AddInParameter(command,"Conclusions",DbType.String,conclusions);
		    		Database.AddInParameter(command,"AbstractTerms",DbType.String,abstractTerms);
		    		Database.AddInParameter(command,"AbstractKeywords",DbType.String,abstractKeywords);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,languageID);
				Database.AddInParameter(command,"oldAbstractLanguageId",DbType.Int32,oldabstractLanguageId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from AbstractsLanguage using Stored Procedure
		/// </summary>
		public DbCommand UpdateAbstractsLanguageCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstractsLanguage");

		    		Database.AddInParameter(command,"AbstractId",DbType.Int32,"AbstractId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AbstractTitle",DbType.String,"AbstractTitle",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AbstractIntro",DbType.String,"AbstractIntro",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CoverLetter",DbType.String,"CoverLetter",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Topic",DbType.String,"Topic",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Background",DbType.String,"Background",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Methods",DbType.String,"Methods",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Results",DbType.String,"Results",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Conclusions",DbType.String,"Conclusions",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AbstractTerms",DbType.String,"AbstractTerms",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AbstractKeywords",DbType.String,"AbstractKeywords",DataRowVersion.Current);
		    		Database.AddInParameter(command,"LanguageID",DbType.Int32,"LanguageID",DataRowVersion.Current);
				Database.AddInParameter(command,"oldAbstractLanguageId",DbType.Int32,"AbstractLanguageId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From AbstractsLanguage using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteAbstractsLanguage( int abstractLanguageId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteAbstractsLanguage");
			Database.AddInParameter(command,"AbstractLanguageId",DbType.Int32,abstractLanguageId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From AbstractsLanguage Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteAbstractsLanguageCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteAbstractsLanguage");
				Database.AddInParameter(command,"AbstractLanguageId",DbType.Int32,"AbstractLanguageId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table AbstractsLanguage using Stored Procedure
		/// and return number of rows effected of the AbstractsLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"AbstractsLanguage",InsertNewAbstractsLanguageCommand(),UpdateAbstractsLanguageCommand(),DeleteAbstractsLanguageCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table AbstractsLanguage using Stored Procedure
		/// and return number of rows effected of the AbstractsLanguage
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"AbstractsLanguage",InsertNewAbstractsLanguageCommand(),UpdateAbstractsLanguageCommand(),DeleteAbstractsLanguageCommand(), transaction);
          return rowsAffected;
		}


	}
}
