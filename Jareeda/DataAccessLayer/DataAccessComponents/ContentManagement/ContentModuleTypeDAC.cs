using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for ContentModuleType table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the ContentModuleType table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
    public class ContentModuleTypeDAC : DataAccessComponent
    {
        #region Constructors
        public ContentModuleTypeDAC() : base("", "ContentManagement.ContentModuleType") { }
        public ContentModuleTypeDAC(string connectionString) : base(connectionString) { }
        public ContentModuleTypeDAC(string connectionStringKey, DatabaseType type) : base(connectionStringKey, type) { }
        #endregion


        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContentModuleType using Stored Procedure
        /// and return a DataTable containing all ContentModuleType Data
        /// </summary>
        public DataTable GetAllContentModuleType()
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ContentModuleType";
            string query = " select * from GetAllContentModuleType";
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["ContentModuleType"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContentModuleType using Stored Procedure
        /// and return a DataTable containing all ContentModuleType Data using a Transaction
        /// </summary>
        public DataTable GetAllContentModuleType(DbTransaction transaction)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ContentModuleType";
            string query = " select * from GetAllContentModuleType";
            DbCommand command = Database.GetSqlStringCommand(query);
            Database.LoadDataSet(command, ds, tableNames, transaction);
            return ds.Tables["ContentModuleType"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContentModuleType using Stored Procedure
        /// and return a DataTable containing all ContentModuleType Data
        /// </summary>
        public DataTable GetAllContentModuleType(string where)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ContentModuleType";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = " select * from GetAllContentModuleType" + whereClause;
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["ContentModuleType"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all ContentModuleType using Stored Procedure
        /// and return a DataTable containing all ContentModuleType Data using a Transaction
        /// </summary>
        public DataTable GetAllContentModuleType(string where, DbTransaction transaction)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "ContentModuleType";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = " select * from GetAllContentModuleType" + whereClause;
            DbCommand command = Database.GetSqlStringCommand(query);
            Database.LoadDataSet(command, ds, tableNames, transaction);
            return ds.Tables["ContentModuleType"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ContentModuleType using Stored Procedure
        /// and return the Record Object
        /// </summary>
        public System.Data.IDataReader GetByIDContentModuleType(int contentModuleTypeID)
        {
            DbCommand command = Database.GetStoredProcCommand("GetByIDContentModuleType");
            Database.AddInParameter(command, "ContentModuleTypeID", DbType.Int32, contentModuleTypeID);
            IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
            return reader;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From ContentModuleType using Stored Procedure
        /// and return the Record Object
        /// </summary>
        public System.Data.IDataReader GetByIDContentModuleType(int contentModuleTypeID, DbTransaction transaction)
        {
            DbCommand command = Database.GetStoredProcCommand("GetByIDContentModuleType");
            Database.AddInParameter(command, "ContentModuleTypeID", DbType.Int32, contentModuleTypeID);
            IDataReader reader = Database.ExecuteReader(command, transaction);
            return reader;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ContentModuleType using Stored Procedure
        /// and return the auto number primary key of ContentModuleType inserted row
        /// </summary>
        public bool InsertNewContentModuleType(ref int contentModuleTypeID, int siteID, string name, string code, string ImagePreview, int PositionID, string ControlPath)
        {
            DbCommand command = Database.GetStoredProcCommand("InsertNewContentModuleType");
            Database.AddOutParameter(command, "ContentModuleTypeID", DbType.Int32, Int32.MaxValue);
            Database.AddInParameter(command, "SiteID", DbType.Int32, siteID);
            Database.AddInParameter(command, "Name", DbType.String, name);
            Database.AddInParameter(command, "Code", DbType.String, code);
            Database.AddInParameter(command, "ImagePreview", DbType.String, ImagePreview);
            Database.AddInParameter(command, "PositionID", DbType.Int32, PositionID);
            Database.AddInParameter(command, "ControlPath", DbType.String, ControlPath);
            bool _status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                _status = true; contentModuleTypeID = Convert.ToInt32(Database.GetParameterValue(command, "ContentModuleTypeID"));
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into ContentModuleType using Stored Procedure
        /// and return the auto number primary key of ContentModuleType inserted row using Transaction
        /// </summary>
        public bool InsertNewContentModuleType(ref int contentModuleTypeID, int siteID, string name, string code, string ImagePreview, int PositionID, string ControlPath, DbTransaction transaction)
        {
            DbCommand command = Database.GetStoredProcCommand("InsertNewContentModuleType");
            Database.AddOutParameter(command, "ContentModuleTypeID", DbType.Int32, Int32.MaxValue);
            Database.AddInParameter(command, "SiteID", DbType.Int32, siteID);
            Database.AddInParameter(command, "Name", DbType.String, name);
            Database.AddInParameter(command, "Code", DbType.String, code);
            Database.AddInParameter(command, "ImagePreview", DbType.String, ImagePreview);
            Database.AddInParameter(command, "PositionID", DbType.Int32, PositionID);
            Database.AddInParameter(command, "ControlPath", DbType.String, ControlPath);
            bool _status = false;
            if (Database.ExecuteNonQuery(command, transaction) > 0)
            {
                _status = true; contentModuleTypeID = Convert.ToInt32(Database.GetParameterValue(command, "ContentModuleTypeID"));
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for ContentModuleType using Stored Procedure
        /// and return DbCommand of the ContentModuleType
        /// </summary>
        public DbCommand InsertNewContentModuleTypeCommand()
        {
            try
            {
                DbCommand command = Database.GetStoredProcCommand("InsertNewContentModuleType");

                Database.AddInParameter(command, "SiteID", DbType.Int32, "SiteID", DataRowVersion.Current);
                Database.AddInParameter(command, "Name", DbType.String, "Name", DataRowVersion.Current);
                Database.AddInParameter(command, "Code", DbType.String, "Code", DataRowVersion.Current);
                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ContentModuleType using Stored Procedure
        /// </summary>
        public bool UpdateContentModuleType(int siteID, string name, string code, string ImagePreview, int PositionID, string ControlPath, int oldcontentModuleTypeID)
        {
            DbCommand command = Database.GetStoredProcCommand("UpdateContentModuleType");

            Database.AddInParameter(command, "SiteID", DbType.Int32, siteID);
            Database.AddInParameter(command, "Name", DbType.String, name);
            Database.AddInParameter(command, "Code", DbType.String, code);
            Database.AddInParameter(command, "ImagePreview", DbType.String, ImagePreview);
            Database.AddInParameter(command, "PositionID", DbType.Int32, PositionID);
            Database.AddInParameter(command, "ControlPath", DbType.String, ControlPath);
            Database.AddInParameter(command, "oldContentModuleTypeID", DbType.Int32, oldcontentModuleTypeID);

            bool _status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                _status = true;
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into ContentModuleType using Stored Procedure By Transaction
        /// </summary>
        public bool UpdateContentModuleType(int siteID, string name, string code, string ImagePreview, int PositionID, string ControlPath, int oldcontentModuleTypeID, DbTransaction transaction)
        {
            DbCommand command = Database.GetStoredProcCommand("UpdateContentModuleType");

            Database.AddInParameter(command, "SiteID", DbType.Int32, siteID);
            Database.AddInParameter(command, "Name", DbType.String, name);
            Database.AddInParameter(command, "Code", DbType.String, code);
            Database.AddInParameter(command, "ImagePreview", DbType.String, ImagePreview);
            Database.AddInParameter(command, "PositionID", DbType.Int32, PositionID);
            Database.AddInParameter(command, "ControlPath", DbType.String, ControlPath);
            Database.AddInParameter(command, "oldContentModuleTypeID", DbType.Int32, oldcontentModuleTypeID);

            bool _status = false;
            if (Database.ExecuteNonQuery(command, transaction) > 0)
            {
                _status = true;
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from ContentModuleType using Stored Procedure
        /// </summary>
        public DbCommand UpdateContentModuleTypeCommand()
        {
            try
            {
                DbCommand command = Database.GetStoredProcCommand("UpdateContentModuleType");

                Database.AddInParameter(command, "SiteID", DbType.Int32, "SiteID", DataRowVersion.Current);
                Database.AddInParameter(command, "Name", DbType.String, "Name", DataRowVersion.Current);
                Database.AddInParameter(command, "Code", DbType.String, "Code", DataRowVersion.Current);
                Database.AddInParameter(command, "oldContentModuleTypeID", DbType.Int32, "ContentModuleTypeID", DataRowVersion.Current);

                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From ContentModuleType using Stored Procedure
        /// and return boolean Whether the record was deleted or not
        /// </summary>
        public bool DeleteContentModuleType(int contentModuleTypeID)
        {
            DbCommand command = Database.GetStoredProcCommand("DeleteContentModuleType");
            Database.AddInParameter(command, "ContentModuleTypeID", DbType.Int32, contentModuleTypeID);
            bool status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                status = true;
            }
            return status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From ContentModuleType Delete Stored Procedure
        /// and return DbCommand Init the delete command
        /// </summary>
        public DbCommand DeleteContentModuleTypeCommand()
        {
            try
            {
                DbCommand command = Database.GetStoredProcCommand("DeleteContentModuleType");
                Database.AddInParameter(command, "ContentModuleTypeID", DbType.Int32, "ContentModuleTypeID", DataRowVersion.Current);
                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ContentModuleType using Stored Procedure
        /// and return number of rows effected of the ContentModuleType
        /// </summary>
        public int UpdateDataset(System.Data.DataSet dataset)
        {
            int rowsAffected = 0;
            rowsAffected = Database.UpdateDataSet(dataset, "ContentModuleType", InsertNewContentModuleTypeCommand(), UpdateContentModuleTypeCommand(), DeleteContentModuleTypeCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
            return rowsAffected;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table ContentModuleType using Stored Procedure
        /// and return number of rows effected of the ContentModuleType
        /// </summary>
        public int UpdateDataset(System.Data.DataSet dataset, DbTransaction transaction)
        {
            int rowsAffected = 0;
            rowsAffected = Database.UpdateDataSet(dataset, "ContentModuleType", InsertNewContentModuleTypeCommand(), UpdateContentModuleTypeCommand(), DeleteContentModuleTypeCommand(), transaction);
            return rowsAffected;
        }


    }

}
