using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DataAccessLayer.Helpers;
namespace DataAccessLayer.DataAccessComponents.ContentManagement
{
	/// <summary>
	/// This is a Data Access Class  for Position table This Class is used to
	/// Insert, Update, Delete, Select, GetByID Operations and dealing with
	/// with the database to retrieve or execute any commands on the Position table or related views
	/// Last Modified By: Ramy Mostafa
	/// </summary>
    public class PositionDAC : DataAccessComponent
    {
        #region Constructors
        public PositionDAC() : base("", "ContentManagement.Position") { }
        public PositionDAC(string connectionString) : base(connectionString) { }
        public PositionDAC(string connectionStringKey, DatabaseType type) : base(connectionStringKey, type) { }
        #endregion


        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Position using Stored Procedure
        /// and return a DataTable containing all Position Data
        /// </summary>
        public DataTable GetAllPosition()
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "Position";
            string query = " select * from GetAllPosition";
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["Position"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Position using Stored Procedure
        /// and return a DataTable containing all Position Data using a Transaction
        /// </summary>
        public DataTable GetAllPosition(DbTransaction transaction)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "Position";
            string query = " select * from GetAllPosition";
            DbCommand command = Database.GetSqlStringCommand(query);
            Database.LoadDataSet(command, ds, tableNames, transaction);
            return ds.Tables["Position"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Position using Stored Procedure
        /// and return a DataTable containing all Position Data
        /// </summary>
        public DataTable GetAllPosition(string where)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "Position";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = " select * from GetAllPosition" + whereClause;
            DbCommand command = Database.GetSqlStringCommand(query);
            DataTable table = new DataTable(tableNames[0]);
            table.Merge(this.FromCache(command));
            //Database.LoadDataSet(command,ds,tableNames);
            return table;// ds.Tables["Position"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get all Position using Stored Procedure
        /// and return a DataTable containing all Position Data using a Transaction
        /// </summary>
        public DataTable GetAllPosition(string where, DbTransaction transaction)
        {

            DataSet ds = new DataSet();
            string[] tableNames = new string[1];
            tableNames[0] = "Position";
            string whereClause = "";
            if (!string.IsNullOrEmpty(where))
                whereClause = " Where " + where;
            string query = " select * from GetAllPosition" + whereClause;
            DbCommand command = Database.GetSqlStringCommand(query);
            Database.LoadDataSet(command, ds, tableNames, transaction);
            return ds.Tables["Position"];

        }



        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Position using Stored Procedure
        /// and return the Record Object
        /// </summary>
        public System.Data.IDataReader GetByIDPosition(int positionID)
        {
            DbCommand command = Database.GetStoredProcCommand("GetByIDPosition");
            Database.AddInParameter(command, "PositionID", DbType.Int32, positionID);
            IDataReader reader = this.FromCache(command).CreateDataReader();// Database.ExecuteReader(command);
            return reader;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Record ByID From Position using Stored Procedure
        /// and return the Record Object
        /// </summary>
        public System.Data.IDataReader GetByIDPosition(int positionID, DbTransaction transaction)
        {
            DbCommand command = Database.GetStoredProcCommand("GetByIDPosition");
            Database.AddInParameter(command, "PositionID", DbType.Int32, positionID);
            IDataReader reader = Database.ExecuteReader(command, transaction);
            return reader;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Position using Stored Procedure
        /// and return the auto number primary key of Position inserted row
        /// </summary>
        public bool InsertNewPosition(ref int positionID, int siteID, string name, string code)
        {
            DbCommand command = Database.GetStoredProcCommand("InsertNewPosition");
            Database.AddOutParameter(command, "PositionID", DbType.Int32, Int32.MaxValue);
            Database.AddInParameter(command, "SiteID", DbType.Int32, siteID);
            Database.AddInParameter(command, "Name", DbType.String, name);
            Database.AddInParameter(command, "Code", DbType.String, code);
            bool _status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                _status = true; positionID = Convert.ToInt32(Database.GetParameterValue(command, "PositionID"));
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Insert a row into Position using Stored Procedure
        /// and return the auto number primary key of Position inserted row using Transaction
        /// </summary>
        public bool InsertNewPosition(ref int positionID, int siteID, string name, string code, DbTransaction transaction)
        {
            DbCommand command = Database.GetStoredProcCommand("InsertNewPosition");
            Database.AddOutParameter(command, "PositionID", DbType.Int32, Int32.MaxValue);
            Database.AddInParameter(command, "SiteID", DbType.Int32, siteID);
            Database.AddInParameter(command, "Name", DbType.String, name);
            Database.AddInParameter(command, "Code", DbType.String, code);
            bool _status = false;
            if (Database.ExecuteNonQuery(command, transaction) > 0)
            {
                _status = true; positionID = Convert.ToInt32(Database.GetParameterValue(command, "PositionID"));
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get InsertCommand for Position using Stored Procedure
        /// and return DbCommand of the Position
        /// </summary>
        public DbCommand InsertNewPositionCommand()
        {
            try
            {
                DbCommand command = Database.GetStoredProcCommand("InsertNewPosition");

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
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Position using Stored Procedure
        /// </summary>
        public bool UpdatePosition(int siteID, string name, string code, int oldpositionID)
        {
            DbCommand command = Database.GetStoredProcCommand("UpdatePosition");

            Database.AddInParameter(command, "SiteID", DbType.Int32, siteID);
            Database.AddInParameter(command, "Name", DbType.String, name);
            Database.AddInParameter(command, "Code", DbType.String, code);
            Database.AddInParameter(command, "oldPositionID", DbType.Int32, oldpositionID);

            bool _status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                _status = true;
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get Update a row into Position using Stored Procedure By Transaction
        /// </summary>
        public bool UpdatePosition(int siteID, string name, string code, int oldpositionID, DbTransaction transaction)
        {
            DbCommand command = Database.GetStoredProcCommand("UpdatePosition");

            Database.AddInParameter(command, "SiteID", DbType.Int32, siteID);
            Database.AddInParameter(command, "Name", DbType.String, name);
            Database.AddInParameter(command, "Code", DbType.String, code);
            Database.AddInParameter(command, "oldPositionID", DbType.Int32, oldpositionID);

            bool _status = false;
            if (Database.ExecuteNonQuery(command, transaction) > 0)
            {
                _status = true;
            }
            return _status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to get UpdateCommand from Position using Stored Procedure
        /// </summary>
        public DbCommand UpdatePositionCommand()
        {
            try
            {
                DbCommand command = Database.GetStoredProcCommand("UpdatePosition");

                Database.AddInParameter(command, "SiteID", DbType.Int32, "SiteID", DataRowVersion.Current);
                Database.AddInParameter(command, "Name", DbType.String, "Name", DataRowVersion.Current);
                Database.AddInParameter(command, "Code", DbType.String, "Code", DataRowVersion.Current);
                Database.AddInParameter(command, "oldPositionID", DbType.Int32, "PositionID", DataRowVersion.Current);

                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Delete a row From Position using Stored Procedure
        /// and return boolean Whether the record was deleted or not
        /// </summary>
        public bool DeletePosition(int positionID)
        {
            DbCommand command = Database.GetStoredProcCommand("DeletePosition");
            Database.AddInParameter(command, "PositionID", DbType.Int32, positionID);
            bool status = false;
            if (Database.ExecuteNonQuery(command) > 0)
            {
                status = true;
            }
            return status;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Get a Delete Command From Position Delete Stored Procedure
        /// and return DbCommand Init the delete command
        /// </summary>
        public DbCommand DeletePositionCommand()
        {
            try
            {
                DbCommand command = Database.GetStoredProcCommand("DeletePosition");
                Database.AddInParameter(command, "PositionID", DbType.Int32, "PositionID", DataRowVersion.Current);
                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Position using Stored Procedure
        /// and return number of rows effected of the Position
        /// </summary>
        public int UpdateDataset(System.Data.DataSet dataset)
        {
            int rowsAffected = 0;
            rowsAffected = Database.UpdateDataSet(dataset, "Position", InsertNewPositionCommand(), UpdatePositionCommand(), DeletePositionCommand(), Microsoft.Practices.EnterpriseLibrary.Data.UpdateBehavior.Standard);
            return rowsAffected;
        }

        /// <summary>
        /// This Function Uses the Microsoft.Practices.EnterpriseLibrary.Data to Update Dataset for table Position using Stored Procedure
        /// and return number of rows effected of the Position
        /// </summary>
        public int UpdateDataset(System.Data.DataSet dataset, DbTransaction transaction)
        {
            int rowsAffected = 0;
            rowsAffected = Database.UpdateDataSet(dataset, "Position", InsertNewPositionCommand(), UpdatePositionCommand(), DeletePositionCommand(), transaction);
            return rowsAffected;
        }


    }

}
