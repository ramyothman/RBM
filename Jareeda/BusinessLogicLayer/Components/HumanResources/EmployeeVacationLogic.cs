using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for EmployeeVacation table
	/// This class RAPs the EmployeeVacationDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class EmployeeVacationLogic : BusinessLogic
	{
		public EmployeeVacationLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<EmployeeVacation> GetAll()
         {
             EmployeeVacationDAC _employeeVacationComponent = new EmployeeVacationDAC();
             IDataReader reader =  _employeeVacationComponent.GetAllEmployeeVacation().CreateDataReader();
             List<EmployeeVacation> _employeeVacationList = new List<EmployeeVacation>();
             while(reader.Read())
             {
             if(_employeeVacationList == null)
                 _employeeVacationList = new List<EmployeeVacation>();
                 EmployeeVacation _employeeVacation = new EmployeeVacation();
                 if(reader["EmployeeVacationID"] != DBNull.Value)
                     _employeeVacation.EmployeeVacationID = Convert.ToInt32(reader["EmployeeVacationID"]);
                 if(reader["EmployeeID"] != DBNull.Value)
                     _employeeVacation.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                 if(reader["VacationTypeID"] != DBNull.Value)
                     _employeeVacation.VacationTypeID = Convert.ToInt32(reader["VacationTypeID"]);
                 if(reader["StartDate"] != DBNull.Value)
                     _employeeVacation.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if(reader["EndDate"] != DBNull.Value)
                     _employeeVacation.EndDate = Convert.ToDateTime(reader["EndDate"]);
                 if(reader["DurationInDays"] != DBNull.Value)
                     _employeeVacation.DurationInDays = Convert.ToInt32(reader["DurationInDays"]);
                 if(reader["RequestDate"] != DBNull.Value)
                     _employeeVacation.RequestDate = Convert.ToDateTime(reader["RequestDate"]);
                 if(reader["ApprovalDate"] != DBNull.Value)
                     _employeeVacation.ApprovalDate = Convert.ToDateTime(reader["ApprovalDate"]);
                 if(reader["ApprovedBy"] != DBNull.Value)
                     _employeeVacation.ApprovedBy = Convert.ToInt32(reader["ApprovedBy"]);
             _employeeVacation.NewRecord = false;
             _employeeVacationList.Add(_employeeVacation);
             }             reader.Close();
             return _employeeVacationList;
         }

        #region Insert And Update
		public bool Insert(EmployeeVacation employeevacation)
		{
			int autonumber = 0;
			EmployeeVacationDAC employeevacationComponent = new EmployeeVacationDAC();
			bool endedSuccessfuly = employeevacationComponent.InsertNewEmployeeVacation( ref autonumber,  employeevacation.EmployeeID,  employeevacation.VacationTypeID,  employeevacation.StartDate,  employeevacation.EndDate,  employeevacation.DurationInDays,  employeevacation.RequestDate,  employeevacation.ApprovalDate,  employeevacation.ApprovedBy);
			if(endedSuccessfuly)
			{
				employeevacation.EmployeeVacationID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int EmployeeVacationID,  int EmployeeID,  int VacationTypeID,  DateTime StartDate,  DateTime EndDate,  int DurationInDays,  DateTime RequestDate,  DateTime ApprovalDate,  int ApprovedBy)
		{
			EmployeeVacationDAC employeevacationComponent = new EmployeeVacationDAC();
			return employeevacationComponent.InsertNewEmployeeVacation( ref EmployeeVacationID,  EmployeeID,  VacationTypeID,  StartDate,  EndDate,  DurationInDays,  RequestDate,  ApprovalDate,  ApprovedBy);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int EmployeeID,  int VacationTypeID,  DateTime StartDate,  DateTime EndDate,  int DurationInDays,  DateTime RequestDate,  DateTime ApprovalDate,  int ApprovedBy)
		{
			EmployeeVacationDAC employeevacationComponent = new EmployeeVacationDAC();
            int EmployeeVacationID = 0;

			return employeevacationComponent.InsertNewEmployeeVacation( ref EmployeeVacationID,  EmployeeID,  VacationTypeID,  StartDate,  EndDate,  DurationInDays,  RequestDate,  ApprovalDate,  ApprovedBy);
		}
		public bool Update(EmployeeVacation employeevacation ,int old_employeeVacationID)
		{
			EmployeeVacationDAC employeevacationComponent = new EmployeeVacationDAC();
			return employeevacationComponent.UpdateEmployeeVacation( employeevacation.EmployeeID,  employeevacation.VacationTypeID,  employeevacation.StartDate,  employeevacation.EndDate,  employeevacation.DurationInDays,  employeevacation.RequestDate,  employeevacation.ApprovalDate,  employeevacation.ApprovedBy,  old_employeeVacationID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int EmployeeID,  int VacationTypeID,  DateTime StartDate,  DateTime EndDate,  int DurationInDays,  DateTime RequestDate,  DateTime ApprovalDate,  int ApprovedBy,  int Original_EmployeeVacationID)
		{
			EmployeeVacationDAC employeevacationComponent = new EmployeeVacationDAC();
			return employeevacationComponent.UpdateEmployeeVacation( EmployeeID,  VacationTypeID,  StartDate,  EndDate,  DurationInDays,  RequestDate,  ApprovalDate,  ApprovedBy,  Original_EmployeeVacationID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_EmployeeVacationID)
		{
			EmployeeVacationDAC employeevacationComponent = new EmployeeVacationDAC();
			employeevacationComponent.DeleteEmployeeVacation(Original_EmployeeVacationID);
		}

        #endregion
         public EmployeeVacation GetByID(int _employeeVacationID)
         {
             EmployeeVacationDAC _employeeVacationComponent = new EmployeeVacationDAC();
             IDataReader reader = _employeeVacationComponent.GetByIDEmployeeVacation(_employeeVacationID);
             EmployeeVacation _employeeVacation = null;
             while(reader.Read())
             {
                 _employeeVacation = new EmployeeVacation();
                 if(reader["EmployeeVacationID"] != DBNull.Value)
                     _employeeVacation.EmployeeVacationID = Convert.ToInt32(reader["EmployeeVacationID"]);
                 if(reader["EmployeeID"] != DBNull.Value)
                     _employeeVacation.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                 if(reader["VacationTypeID"] != DBNull.Value)
                     _employeeVacation.VacationTypeID = Convert.ToInt32(reader["VacationTypeID"]);
                 if(reader["StartDate"] != DBNull.Value)
                     _employeeVacation.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if(reader["EndDate"] != DBNull.Value)
                     _employeeVacation.EndDate = Convert.ToDateTime(reader["EndDate"]);
                 if(reader["DurationInDays"] != DBNull.Value)
                     _employeeVacation.DurationInDays = Convert.ToInt32(reader["DurationInDays"]);
                 if(reader["RequestDate"] != DBNull.Value)
                     _employeeVacation.RequestDate = Convert.ToDateTime(reader["RequestDate"]);
                 if(reader["ApprovalDate"] != DBNull.Value)
                     _employeeVacation.ApprovalDate = Convert.ToDateTime(reader["ApprovalDate"]);
                 if(reader["ApprovedBy"] != DBNull.Value)
                     _employeeVacation.ApprovedBy = Convert.ToInt32(reader["ApprovedBy"]);
             _employeeVacation.NewRecord = false;             }             reader.Close();
             return _employeeVacation;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			EmployeeVacationDAC employeevacationcomponent = new EmployeeVacationDAC();
			return employeevacationcomponent.UpdateDataset(dataset);
		}



	}
}
