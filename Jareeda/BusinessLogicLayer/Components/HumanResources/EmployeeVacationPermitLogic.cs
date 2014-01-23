using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for EmployeeVacationPermit table
	/// This class RAPs the EmployeeVacationPermitDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class EmployeeVacationPermitLogic : BusinessLogic
	{
		public EmployeeVacationPermitLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<EmployeeVacationPermit> GetAll()
         {
             EmployeeVacationPermitDAC _employeeVacationPermitComponent = new EmployeeVacationPermitDAC();
             IDataReader reader =  _employeeVacationPermitComponent.GetAllEmployeeVacationPermit().CreateDataReader();
             List<EmployeeVacationPermit> _employeeVacationPermitList = new List<EmployeeVacationPermit>();
             while(reader.Read())
             {
             if(_employeeVacationPermitList == null)
                 _employeeVacationPermitList = new List<EmployeeVacationPermit>();
                 EmployeeVacationPermit _employeeVacationPermit = new EmployeeVacationPermit();
                 if(reader["EmployeeVacationPermitID"] != DBNull.Value)
                     _employeeVacationPermit.EmployeeVacationPermitID = Convert.ToInt32(reader["EmployeeVacationPermitID"]);
                 if(reader["Name"] != DBNull.Value)
                     _employeeVacationPermit.Name = Convert.ToString(reader["Name"]);
                 if(reader["VacationTypeID"] != DBNull.Value)
                     _employeeVacationPermit.VacationTypeID = Convert.ToInt32(reader["VacationTypeID"]);
                 if(reader["PermitNumberinDays"] != DBNull.Value)
                     _employeeVacationPermit.PermitNumberinDays = Convert.ToInt32(reader["PermitNumberinDays"]);
                 if(reader["IsMonthly"] != DBNull.Value)
                     _employeeVacationPermit.IsMonthly = Convert.ToBoolean(reader["IsMonthly"]);
                 if(reader["IsYearly"] != DBNull.Value)
                     _employeeVacationPermit.IsYearly = Convert.ToBoolean(reader["IsYearly"]);
             _employeeVacationPermit.NewRecord = false;
             _employeeVacationPermitList.Add(_employeeVacationPermit);
             }             reader.Close();
             return _employeeVacationPermitList;
         }

        #region Insert And Update
		public bool Insert(EmployeeVacationPermit employeevacationpermit)
		{
			int autonumber = 0;
			EmployeeVacationPermitDAC employeevacationpermitComponent = new EmployeeVacationPermitDAC();
			bool endedSuccessfuly = employeevacationpermitComponent.InsertNewEmployeeVacationPermit( ref autonumber,  employeevacationpermit.Name,  employeevacationpermit.VacationTypeID,  employeevacationpermit.PermitNumberinDays,  employeevacationpermit.IsMonthly,  employeevacationpermit.IsYearly);
			if(endedSuccessfuly)
			{
				employeevacationpermit.EmployeeVacationPermitID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int EmployeeVacationPermitID,  string Name,  int VacationTypeID,  int PermitNumberinDays,  bool IsMonthly,  bool IsYearly)
		{
			EmployeeVacationPermitDAC employeevacationpermitComponent = new EmployeeVacationPermitDAC();
			return employeevacationpermitComponent.InsertNewEmployeeVacationPermit( ref EmployeeVacationPermitID,  Name,  VacationTypeID,  PermitNumberinDays,  IsMonthly,  IsYearly);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  int VacationTypeID,  int PermitNumberinDays,  bool IsMonthly,  bool IsYearly)
		{
			EmployeeVacationPermitDAC employeevacationpermitComponent = new EmployeeVacationPermitDAC();
            int EmployeeVacationPermitID = 0;

			return employeevacationpermitComponent.InsertNewEmployeeVacationPermit( ref EmployeeVacationPermitID,  Name,  VacationTypeID,  PermitNumberinDays,  IsMonthly,  IsYearly);
		}
		public bool Update(EmployeeVacationPermit employeevacationpermit ,int old_employeeVacationPermitID)
		{
			EmployeeVacationPermitDAC employeevacationpermitComponent = new EmployeeVacationPermitDAC();
			return employeevacationpermitComponent.UpdateEmployeeVacationPermit( employeevacationpermit.Name,  employeevacationpermit.VacationTypeID,  employeevacationpermit.PermitNumberinDays,  employeevacationpermit.IsMonthly,  employeevacationpermit.IsYearly,  old_employeeVacationPermitID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int VacationTypeID,  int PermitNumberinDays,  bool IsMonthly,  bool IsYearly,  int Original_EmployeeVacationPermitID)
		{
			EmployeeVacationPermitDAC employeevacationpermitComponent = new EmployeeVacationPermitDAC();
			return employeevacationpermitComponent.UpdateEmployeeVacationPermit( Name,  VacationTypeID,  PermitNumberinDays,  IsMonthly,  IsYearly,  Original_EmployeeVacationPermitID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_EmployeeVacationPermitID)
		{
			EmployeeVacationPermitDAC employeevacationpermitComponent = new EmployeeVacationPermitDAC();
			employeevacationpermitComponent.DeleteEmployeeVacationPermit(Original_EmployeeVacationPermitID);
		}

        #endregion
         public EmployeeVacationPermit GetByID(int _employeeVacationPermitID)
         {
             EmployeeVacationPermitDAC _employeeVacationPermitComponent = new EmployeeVacationPermitDAC();
             IDataReader reader = _employeeVacationPermitComponent.GetByIDEmployeeVacationPermit(_employeeVacationPermitID);
             EmployeeVacationPermit _employeeVacationPermit = null;
             while(reader.Read())
             {
                 _employeeVacationPermit = new EmployeeVacationPermit();
                 if(reader["EmployeeVacationPermitID"] != DBNull.Value)
                     _employeeVacationPermit.EmployeeVacationPermitID = Convert.ToInt32(reader["EmployeeVacationPermitID"]);
                 if(reader["Name"] != DBNull.Value)
                     _employeeVacationPermit.Name = Convert.ToString(reader["Name"]);
                 if(reader["VacationTypeID"] != DBNull.Value)
                     _employeeVacationPermit.VacationTypeID = Convert.ToInt32(reader["VacationTypeID"]);
                 if(reader["PermitNumberinDays"] != DBNull.Value)
                     _employeeVacationPermit.PermitNumberinDays = Convert.ToInt32(reader["PermitNumberinDays"]);
                 if(reader["IsMonthly"] != DBNull.Value)
                     _employeeVacationPermit.IsMonthly = Convert.ToBoolean(reader["IsMonthly"]);
                 if(reader["IsYearly"] != DBNull.Value)
                     _employeeVacationPermit.IsYearly = Convert.ToBoolean(reader["IsYearly"]);
             _employeeVacationPermit.NewRecord = false;             }             reader.Close();
             return _employeeVacationPermit;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			EmployeeVacationPermitDAC employeevacationpermitcomponent = new EmployeeVacationPermitDAC();
			return employeevacationpermitcomponent.UpdateDataset(dataset);
		}



	}
}
