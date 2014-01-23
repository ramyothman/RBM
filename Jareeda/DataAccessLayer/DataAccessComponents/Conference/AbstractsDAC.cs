using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.Conference
{
	/// <summary>
	/// This is a Data Access Class  for Abstracts table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Abstracts table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
	public class AbstractsDAC : DataAccessComponent
	{
		#region Constructors
        public AbstractsDAC() : base("", "Conference.Abstracts") { }
		public AbstractsDAC(string connectionString): base(connectionString){}
		public AbstractsDAC(string connectionStringKey,DatabaseType type): base(connectionStringKey,type){}
		#endregion


		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Abstracts using Stored Procedure
		/// and return a DataTable containing all Abstracts Data
		/// </summary>
		public DataTable GetAllAbstracts()
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Abstracts";
         string query = " select * from GetAllAbstracts";
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Abstracts"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Abstracts using Stored Procedure
		/// and return a DataTable containing all Abstracts Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstracts(DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Abstracts";
         string query = " select * from GetAllAbstracts";
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Abstracts"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Abstracts using Stored Procedure
		/// and return a DataTable containing all Abstracts Data
		/// </summary>
		public DataTable GetAllAbstracts(string where)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Abstracts";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
             whereClause = " Where " + where;
         string query = " select * from GetAllAbstracts" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         DataTable table = new DataTable(tableNames[0]);
         table.Merge(this.FromCache(command));
         //Database.LoadDataSet(command,ds,tableNames);
         return table;// ds.Tables["Abstracts"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Abstracts using Stored Procedure
		/// and return a DataTable containing all Abstracts Data using a Transaction
		/// </summary>
		public DataTable GetAllAbstracts(string where,DbTransaction transaction)
		{

			DataSet ds = new DataSet();
			string[] tableNames = new string[1];
			tableNames[0] = "Abstracts";
         string whereClause = "";
         if(!string.IsNullOrEmpty(where))
          whereClause = " Where " + where;
         string query = " select * from GetAllAbstracts" + whereClause;
         DbCommand command = Database.GetSqlStringCommand(query);
         Database.LoadDataSet(command,ds,tableNames,transaction);
         return ds.Tables["Abstracts"];

		}



		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Abstracts using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstracts( int abstractId)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstracts");
				    Database.AddInParameter(command,"AbstractId",DbType.Int32,abstractId);
                    IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Abstracts using Stored Procedure
		/// and return the Record Object
		/// </summary>
		public System.Data.IDataReader GetByIDAbstracts( int abstractId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("GetByIDAbstracts");
				    Database.AddInParameter(command,"AbstractId",DbType.Int32,abstractId);
				IDataReader reader  = Database.ExecuteReader(command,transaction);
				return reader;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Abstracts using Stored Procedure
		/// and return the auto number primary key of Abstracts inserted row
		/// </summary>
		public bool InsertNewAbstracts( ref int abstractId,  int personId,  int conferenceId,  int conferenceCategoryId,  string abstractTitle,  string abstractIntro,  string abstractAuthors,  string coverLetter,  bool isAccepted,  string acceptanceType,  string presentationPath,  string posterPath,  string topic,  string background,  string methods,  string results,  string conclusions,  string abstractTerms,  string abstractKeywords,  string documentPath1,  string documentPath2,  string documentPath3,  int revisionNumber,  int parentID,  int abstractStatusId)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstracts");
				Database.AddOutParameter(command,"AbstractId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"ConferenceCategoryId",DbType.Int32,conferenceCategoryId);
				Database.AddInParameter(command,"AbstractTitle",DbType.String,abstractTitle);
				Database.AddInParameter(command,"AbstractIntro",DbType.String,abstractIntro);
				Database.AddInParameter(command,"AbstractAuthors",DbType.String,abstractAuthors);
				Database.AddInParameter(command,"CoverLetter",DbType.String,coverLetter);
				Database.AddInParameter(command,"IsAccepted",DbType.Boolean,isAccepted);
				Database.AddInParameter(command,"AcceptanceType",DbType.String,acceptanceType);
				Database.AddInParameter(command,"PresentationPath",DbType.String,presentationPath);
				Database.AddInParameter(command,"PosterPath",DbType.String,posterPath);
				Database.AddInParameter(command,"Topic",DbType.String,topic);
				Database.AddInParameter(command,"Background",DbType.String,background);
				Database.AddInParameter(command,"Methods",DbType.String,methods);
				Database.AddInParameter(command,"Results",DbType.String,results);
				Database.AddInParameter(command,"Conclusions",DbType.String,conclusions);
				Database.AddInParameter(command,"AbstractTerms",DbType.String,abstractTerms);
				Database.AddInParameter(command,"AbstractKeywords",DbType.String,abstractKeywords);
				Database.AddInParameter(command,"DocumentPath1",DbType.String,documentPath1);
				Database.AddInParameter(command,"DocumentPath2",DbType.String,documentPath2);
				Database.AddInParameter(command,"DocumentPath3",DbType.String,documentPath3);
				Database.AddInParameter(command,"RevisionNumber",DbType.Int32,revisionNumber);
				Database.AddInParameter(command,"ParentID",DbType.Int32,parentID);
				Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,abstractStatusId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;                 abstractId = Convert.ToInt32(Database.GetParameterValue(command, "AbstractId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Abstracts using Stored Procedure
		/// and return the auto number primary key of Abstracts inserted row using Transaction
		/// </summary>
		public bool InsertNewAbstracts( ref int abstractId,  int personId,  int conferenceId,  int conferenceCategoryId,  string abstractTitle,  string abstractIntro,  string abstractAuthors,  string coverLetter,  bool isAccepted,  string acceptanceType,  string presentationPath,  string posterPath,  string topic,  string background,  string methods,  string results,  string conclusions,  string abstractTerms,  string abstractKeywords,  string documentPath1,  string documentPath2,  string documentPath3,  int revisionNumber,  int parentID,  int abstractStatusId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstracts");
				Database.AddOutParameter(command,"AbstractId",DbType.Int32,Int32.MaxValue);
				Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
				Database.AddInParameter(command,"ConferenceCategoryId",DbType.Int32,conferenceCategoryId);
				Database.AddInParameter(command,"AbstractTitle",DbType.String,abstractTitle);
				Database.AddInParameter(command,"AbstractIntro",DbType.String,abstractIntro);
				Database.AddInParameter(command,"AbstractAuthors",DbType.String,abstractAuthors);
				Database.AddInParameter(command,"CoverLetter",DbType.String,coverLetter);
				Database.AddInParameter(command,"IsAccepted",DbType.Boolean,isAccepted);
				Database.AddInParameter(command,"AcceptanceType",DbType.String,acceptanceType);
				Database.AddInParameter(command,"PresentationPath",DbType.String,presentationPath);
				Database.AddInParameter(command,"PosterPath",DbType.String,posterPath);
				Database.AddInParameter(command,"Topic",DbType.String,topic);
				Database.AddInParameter(command,"Background",DbType.String,background);
				Database.AddInParameter(command,"Methods",DbType.String,methods);
				Database.AddInParameter(command,"Results",DbType.String,results);
				Database.AddInParameter(command,"Conclusions",DbType.String,conclusions);
				Database.AddInParameter(command,"AbstractTerms",DbType.String,abstractTerms);
				Database.AddInParameter(command,"AbstractKeywords",DbType.String,abstractKeywords);
				Database.AddInParameter(command,"DocumentPath1",DbType.String,documentPath1);
				Database.AddInParameter(command,"DocumentPath2",DbType.String,documentPath2);
				Database.AddInParameter(command,"DocumentPath3",DbType.String,documentPath3);
				Database.AddInParameter(command,"RevisionNumber",DbType.Int32,revisionNumber);
				Database.AddInParameter(command,"ParentID",DbType.Int32,parentID);
				Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,abstractStatusId);
				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;                 abstractId = Convert.ToInt32(Database.GetParameterValue(command, "AbstractId"));
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Abstracts using Stored Procedure
		/// and return DbCommand of the Abstracts
		/// </summary>
		public DbCommand InsertNewAbstractsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("InsertNewAbstracts");

				Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
				Database.AddInParameter(command,"ConferenceCategoryId",DbType.Int32,"ConferenceCategoryId",DataRowVersion.Current);
				Database.AddInParameter(command,"AbstractTitle",DbType.String,"AbstractTitle",DataRowVersion.Current);
				Database.AddInParameter(command,"AbstractIntro",DbType.String,"AbstractIntro",DataRowVersion.Current);
				Database.AddInParameter(command,"AbstractAuthors",DbType.String,"AbstractAuthors",DataRowVersion.Current);
				Database.AddInParameter(command,"CoverLetter",DbType.String,"CoverLetter",DataRowVersion.Current);
				Database.AddInParameter(command,"IsAccepted",DbType.Boolean,"IsAccepted",DataRowVersion.Current);
				Database.AddInParameter(command,"AcceptanceType",DbType.String,"AcceptanceType",DataRowVersion.Current);
				Database.AddInParameter(command,"PresentationPath",DbType.String,"PresentationPath",DataRowVersion.Current);
				Database.AddInParameter(command,"PosterPath",DbType.String,"PosterPath",DataRowVersion.Current);
				Database.AddInParameter(command,"Topic",DbType.String,"Topic",DataRowVersion.Current);
				Database.AddInParameter(command,"Background",DbType.String,"Background",DataRowVersion.Current);
				Database.AddInParameter(command,"Methods",DbType.String,"Methods",DataRowVersion.Current);
				Database.AddInParameter(command,"Results",DbType.String,"Results",DataRowVersion.Current);
				Database.AddInParameter(command,"Conclusions",DbType.String,"Conclusions",DataRowVersion.Current);
				Database.AddInParameter(command,"AbstractTerms",DbType.String,"AbstractTerms",DataRowVersion.Current);
				Database.AddInParameter(command,"AbstractKeywords",DbType.String,"AbstractKeywords",DataRowVersion.Current);
				Database.AddInParameter(command,"DocumentPath1",DbType.String,"DocumentPath1",DataRowVersion.Current);
				Database.AddInParameter(command,"DocumentPath2",DbType.String,"DocumentPath2",DataRowVersion.Current);
				Database.AddInParameter(command,"DocumentPath3",DbType.String,"DocumentPath3",DataRowVersion.Current);
				Database.AddInParameter(command,"RevisionNumber",DbType.Int32,"RevisionNumber",DataRowVersion.Current);
				Database.AddInParameter(command,"ParentID",DbType.Int32,"ParentID",DataRowVersion.Current);
				Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,"AbstractStatusId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Abstracts using Stored Procedure
		/// </summary>
		public bool UpdateAbstracts( int personId, int conferenceId, int conferenceCategoryId, string abstractTitle, string abstractIntro, string abstractAuthors, string coverLetter, bool isAccepted, string acceptanceType, string presentationPath, string posterPath, string topic, string background, string methods, string results, string conclusions, string abstractTerms, string abstractKeywords, string documentPath1, string documentPath2, string documentPath3, int revisionNumber, int parentID, int abstractStatusId, int oldabstractId)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstracts");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"ConferenceCategoryId",DbType.Int32,conferenceCategoryId);
		    		Database.AddInParameter(command,"AbstractTitle",DbType.String,abstractTitle);
		    		Database.AddInParameter(command,"AbstractIntro",DbType.String,abstractIntro);
		    		Database.AddInParameter(command,"AbstractAuthors",DbType.String,abstractAuthors);
		    		Database.AddInParameter(command,"CoverLetter",DbType.String,coverLetter);
		    		Database.AddInParameter(command,"IsAccepted",DbType.Boolean,isAccepted);
		    		Database.AddInParameter(command,"AcceptanceType",DbType.String,acceptanceType);
		    		Database.AddInParameter(command,"PresentationPath",DbType.String,presentationPath);
		    		Database.AddInParameter(command,"PosterPath",DbType.String,posterPath);
		    		Database.AddInParameter(command,"Topic",DbType.String,topic);
		    		Database.AddInParameter(command,"Background",DbType.String,background);
		    		Database.AddInParameter(command,"Methods",DbType.String,methods);
		    		Database.AddInParameter(command,"Results",DbType.String,results);
		    		Database.AddInParameter(command,"Conclusions",DbType.String,conclusions);
		    		Database.AddInParameter(command,"AbstractTerms",DbType.String,abstractTerms);
		    		Database.AddInParameter(command,"AbstractKeywords",DbType.String,abstractKeywords);
		    		Database.AddInParameter(command,"DocumentPath1",DbType.String,documentPath1);
		    		Database.AddInParameter(command,"DocumentPath2",DbType.String,documentPath2);
		    		Database.AddInParameter(command,"DocumentPath3",DbType.String,documentPath3);
		    		Database.AddInParameter(command,"RevisionNumber",DbType.Int32,revisionNumber);
		    		Database.AddInParameter(command,"ParentID",DbType.Int32,parentID);
		    		Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,abstractStatusId);
				Database.AddInParameter(command,"oldAbstractId",DbType.Int32,oldabstractId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Abstracts using Stored Procedure By Transaction
		/// </summary>
		public bool UpdateAbstracts( int personId, int conferenceId, int conferenceCategoryId, string abstractTitle, string abstractIntro, string abstractAuthors, string coverLetter, bool isAccepted, string acceptanceType, string presentationPath, string posterPath, string topic, string background, string methods, string results, string conclusions, string abstractTerms, string abstractKeywords, string documentPath1, string documentPath2, string documentPath3, int revisionNumber, int parentID, int abstractStatusId, int oldabstractId,DbTransaction transaction)
		{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstracts");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,personId);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,conferenceId);
		    		Database.AddInParameter(command,"ConferenceCategoryId",DbType.Int32,conferenceCategoryId);
		    		Database.AddInParameter(command,"AbstractTitle",DbType.String,abstractTitle);
		    		Database.AddInParameter(command,"AbstractIntro",DbType.String,abstractIntro);
		    		Database.AddInParameter(command,"AbstractAuthors",DbType.String,abstractAuthors);
		    		Database.AddInParameter(command,"CoverLetter",DbType.String,coverLetter);
		    		Database.AddInParameter(command,"IsAccepted",DbType.Boolean,isAccepted);
		    		Database.AddInParameter(command,"AcceptanceType",DbType.String,acceptanceType);
		    		Database.AddInParameter(command,"PresentationPath",DbType.String,presentationPath);
		    		Database.AddInParameter(command,"PosterPath",DbType.String,posterPath);
		    		Database.AddInParameter(command,"Topic",DbType.String,topic);
		    		Database.AddInParameter(command,"Background",DbType.String,background);
		    		Database.AddInParameter(command,"Methods",DbType.String,methods);
		    		Database.AddInParameter(command,"Results",DbType.String,results);
		    		Database.AddInParameter(command,"Conclusions",DbType.String,conclusions);
		    		Database.AddInParameter(command,"AbstractTerms",DbType.String,abstractTerms);
		    		Database.AddInParameter(command,"AbstractKeywords",DbType.String,abstractKeywords);
		    		Database.AddInParameter(command,"DocumentPath1",DbType.String,documentPath1);
		    		Database.AddInParameter(command,"DocumentPath2",DbType.String,documentPath2);
		    		Database.AddInParameter(command,"DocumentPath3",DbType.String,documentPath3);
		    		Database.AddInParameter(command,"RevisionNumber",DbType.Int32,revisionNumber);
		    		Database.AddInParameter(command,"ParentID",DbType.Int32,parentID);
		    		Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,abstractStatusId);
				Database.AddInParameter(command,"oldAbstractId",DbType.Int32,oldabstractId);

				bool _status = false;
				if(Database.ExecuteNonQuery(command,transaction) > 0)
				{
					_status = true;
				}
				return _status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Abstracts using Stored Procedure
		/// </summary>
		public DbCommand UpdateAbstractsCommand()
		{
			try
			{
                 DbCommand command = Database.GetStoredProcCommand("UpdateAbstracts");

		    		Database.AddInParameter(command,"PersonId",DbType.Int32,"PersonId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceId",DbType.Int32,"ConferenceId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ConferenceCategoryId",DbType.Int32,"ConferenceCategoryId",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AbstractTitle",DbType.String,"AbstractTitle",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AbstractIntro",DbType.String,"AbstractIntro",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AbstractAuthors",DbType.String,"AbstractAuthors",DataRowVersion.Current);
		    		Database.AddInParameter(command,"CoverLetter",DbType.String,"CoverLetter",DataRowVersion.Current);
		    		Database.AddInParameter(command,"IsAccepted",DbType.Boolean,"IsAccepted",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AcceptanceType",DbType.String,"AcceptanceType",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PresentationPath",DbType.String,"PresentationPath",DataRowVersion.Current);
		    		Database.AddInParameter(command,"PosterPath",DbType.String,"PosterPath",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Topic",DbType.String,"Topic",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Background",DbType.String,"Background",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Methods",DbType.String,"Methods",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Results",DbType.String,"Results",DataRowVersion.Current);
		    		Database.AddInParameter(command,"Conclusions",DbType.String,"Conclusions",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AbstractTerms",DbType.String,"AbstractTerms",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AbstractKeywords",DbType.String,"AbstractKeywords",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DocumentPath1",DbType.String,"DocumentPath1",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DocumentPath2",DbType.String,"DocumentPath2",DataRowVersion.Current);
		    		Database.AddInParameter(command,"DocumentPath3",DbType.String,"DocumentPath3",DataRowVersion.Current);
		    		Database.AddInParameter(command,"RevisionNumber",DbType.Int32,"RevisionNumber",DataRowVersion.Current);
		    		Database.AddInParameter(command,"ParentID",DbType.Int32,"ParentID",DataRowVersion.Current);
		    		Database.AddInParameter(command,"AbstractStatusId",DbType.Int32,"AbstractStatusId",DataRowVersion.Current);
				Database.AddInParameter(command,"oldAbstractId",DbType.Int32,"AbstractId",DataRowVersion.Current);

				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Abstracts using Stored Procedure
		/// and return boolean Whether the record was deleted or not
		/// </summary>
		public bool DeleteAbstracts( int abstractId)
		{
           DbCommand command = Database.GetStoredProcCommand("DeleteAbstracts");
			Database.AddInParameter(command,"AbstractId",DbType.Int32,abstractId);
			bool status = false;
			if(Database.ExecuteNonQuery(command) > 0)
			{
				status = true;
			}
			return status;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Abstracts Delete Stored Procedure
		/// and return DbCommand Init the delete command
		/// </summary>
		public DbCommand DeleteAbstractsCommand()
		{
			try
			{
                DbCommand command = Database.GetStoredProcCommand("DeleteAbstracts");
				Database.AddInParameter(command,"AbstractId",DbType.Int32,"AbstractId",DataRowVersion.Current);
				return command;
			}			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Abstracts using Stored Procedure
		/// and return number of rows effected of the Abstracts
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Abstracts",InsertNewAbstractsCommand(),UpdateAbstractsCommand(),DeleteAbstractsCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
          return rowsAffected;
		}

		/// <summary>
		/// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Abstracts using Stored Procedure
		/// and return number of rows effected of the Abstracts
		/// </summary>
		public int UpdateDataset(System.Data.DataSet dataset,DbTransaction transaction)
		{
          int rowsAffected = 0;
          rowsAffected = Database.UpdateDataSet(dataset,"Abstracts",InsertNewAbstractsCommand(),UpdateAbstractsCommand(),DeleteAbstractsCommand(), transaction);
          return rowsAffected;
		}


	}
}
