using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for Employees table
	/// This class RAPs the EmployeesDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class EmployeesLogic : BusinessLogic
	{
		public EmployeesLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Employees> GetAll()
         {
             EmployeesDAC _employeesComponent = new EmployeesDAC();
             IDataReader reader =  _employeesComponent.GetAllEmployees().CreateDataReader();
             List<Employees> _employeesList = new List<Employees>();
             while(reader.Read())
             {
             if(_employeesList == null)
                 _employeesList = new List<Employees>();
                 Employees _employees = new Employees();
                 if(reader["EmployeeId"] != DBNull.Value)
                     _employees.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                 if(reader["EmployeeNumber"] != DBNull.Value)
                     _employees.EmployeeNumber = Convert.ToString(reader["EmployeeNumber"]);
                 if(reader["DepartmentId"] != DBNull.Value)
                     _employees.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                 if(reader["DivisionId"] != DBNull.Value)
                     _employees.DivisionId = Convert.ToInt32(reader["DivisionId"]);
                 if(reader["FormalSiteUrl"] != DBNull.Value)
                     _employees.FormalSiteUrl = Convert.ToString(reader["FormalSiteUrl"]);
                 if(reader["NationalIdNumber"] != DBNull.Value)
                     _employees.NationalIdNumber = Convert.ToString(reader["NationalIdNumber"]);
                 if(reader["NationalIdType"] != DBNull.Value)
                     _employees.NationalIdType = Convert.ToString(reader["NationalIdType"]);
                 if(reader["ManagerId"] != DBNull.Value)
                     _employees.ManagerId = Convert.ToInt32(reader["ManagerId"]);
                 if(reader["BirthDate"] != DBNull.Value)
                     _employees.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                 if(reader["MaritalStatus"] != DBNull.Value)
                     _employees.MaritalStatus = Convert.ToString(reader["MaritalStatus"]);
                 if(reader["Gender"] != DBNull.Value)
                     _employees.Gender = Convert.ToString(reader["Gender"]);
                 if(reader["HireDate"] != DBNull.Value)
                     _employees.HireDate = Convert.ToDateTime(reader["HireDate"]);
                 if(reader["SalariedFlag"] != DBNull.Value)
                     _employees.SalariedFlag = Convert.ToBoolean(reader["SalariedFlag"]);
                 if(reader["VacationHours"] != DBNull.Value)
                     _employees.VacationHours = Convert.ToInt16(reader["VacationHours"]);
                 if(reader["SickLeaveHours"] != DBNull.Value)
                     _employees.SickLeaveHours = Convert.ToInt16(reader["SickLeaveHours"]);
                 if(reader["CurrentFlag"] != DBNull.Value)
                     _employees.CurrentFlag = Convert.ToBoolean(reader["CurrentFlag"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _employees.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _employees.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if(reader["Position"] != DBNull.Value)
                     _employees.Position = Convert.ToString(reader["Position"]);
             _employees.NewRecord = false;
             _employeesList.Add(_employees);
             }             reader.Close();
             return _employeesList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Employees> GetAllView(int LanguageID)
        {
            EmployeesDAC _employeesComponent = new EmployeesDAC();
            IDataReader reader = _employeesComponent.GetAllEmployeesView("LanguageID = " + LanguageID).CreateDataReader();
            List<Employees> _employeesList = new List<Employees>();
            while (reader.Read())
            {
                if (_employeesList == null)
                    _employeesList = new List<Employees>();
                Employees _employees = new Employees();
                #region Employee Info
                if (reader["EmployeeId"] != DBNull.Value)
                    _employees.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                if (reader["EmployeeNumber"] != DBNull.Value)
                    _employees.EmployeeNumber = Convert.ToString(reader["EmployeeNumber"]);
                if (reader["DepartmentId"] != DBNull.Value)
                    _employees.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                if (reader["DivisionId"] != DBNull.Value)
                    _employees.DivisionId = Convert.ToInt32(reader["DivisionId"]);
                if (reader["FormalSiteUrl"] != DBNull.Value)
                    _employees.FormalSiteUrl = Convert.ToString(reader["FormalSiteUrl"]);
                if (reader["NationalIdNumber"] != DBNull.Value)
                    _employees.NationalIdNumber = Convert.ToString(reader["NationalIdNumber"]);
                if (reader["NationalIdType"] != DBNull.Value)
                    _employees.NationalIdType = Convert.ToString(reader["NationalIdType"]);
                if (reader["ManagerId"] != DBNull.Value)
                    _employees.ManagerId = Convert.ToInt32(reader["ManagerId"]);
                if (reader["BirthDate"] != DBNull.Value)
                    _employees.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                if (reader["MaritalStatus"] != DBNull.Value)
                    _employees.MaritalStatus = Convert.ToString(reader["MaritalStatus"]);
                if (reader["Gender"] != DBNull.Value)
                    _employees.Gender = Convert.ToString(reader["Gender"]);
                if (reader["HireDate"] != DBNull.Value)
                    _employees.HireDate = Convert.ToDateTime(reader["HireDate"]);
                if (reader["SalariedFlag"] != DBNull.Value)
                    _employees.SalariedFlag = Convert.ToBoolean(reader["SalariedFlag"]);
                if (reader["VacationHours"] != DBNull.Value)
                    _employees.VacationHours = Convert.ToInt16(reader["VacationHours"]);
                if (reader["SickLeaveHours"] != DBNull.Value)
                    _employees.SickLeaveHours = Convert.ToInt16(reader["SickLeaveHours"]);
                if (reader["CurrentFlag"] != DBNull.Value)
                    _employees.CurrentFlag = Convert.ToBoolean(reader["CurrentFlag"]);
                if (reader["EmployeeRowGuid"] != DBNull.Value)
                    _employees.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["EmployeeModifiedDate"] != DBNull.Value)
                    _employees.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["Position"] != DBNull.Value)
                    _employees.Position = Convert.ToString(reader["Position"]);
                _employees.NewRecord = false;
                #endregion

                #region Person Info
                BusinessLogicLayer.Entities.Persons.Person _person = new BusinessLogicLayer.Entities.Persons.Person();
                #region Main Info
                if (reader["EmployeeId"] != DBNull.Value)
                    _person.BusinessEntityId = Convert.ToInt32(reader["EmployeeId"]);
                if (reader["NameStyle"] != DBNull.Value)
                    _person.NameStyle = Convert.ToBoolean(reader["NameStyle"]);
                if (reader["EmailPromotion"] != DBNull.Value)
                    _person.EmailPromotion = Convert.ToInt32(reader["EmailPromotion"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _person.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _person.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["CreatedDate"] != DBNull.Value)
                    _person.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                if (reader["NationalityCode"] != DBNull.Value)
                    _person.NationalityCode = Convert.ToString(reader["NationalityCode"]);
                if (reader["Gender"] != DBNull.Value)
                    _person.Gender = Convert.ToString(reader["Gender"]);
                if (reader["DateofBirth"] != DBNull.Value)
                    _person.DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                if (reader["PersonImage"] != DBNull.Value)
                    _person.PersonImage = Convert.ToString(reader["PersonImage"]);
                #endregion

                #region Person Languages
                BusinessLogicLayer.Entities.Persons.PersonLanguages _personLanguages = new BusinessLogicLayer.Entities.Persons.PersonLanguages();
                if (reader["PersonLanguageId"] != DBNull.Value)
                    _personLanguages.PersonLanguageId = Convert.ToInt32(reader["PersonLanguageId"]);
                if (reader["EmployeeId"] != DBNull.Value)
                    _personLanguages.PersonId = Convert.ToInt32(reader["EmployeeId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _personLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["Title"] != DBNull.Value)
                    _personLanguages.Title = Convert.ToString(reader["Title"]);
                if (reader["FirstName"] != DBNull.Value)
                    _personLanguages.FirstName = Convert.ToString(reader["FirstName"]);
                if (reader["MiddleName"] != DBNull.Value)
                    _personLanguages.MiddleName = Convert.ToString(reader["MiddleName"]);
                if (reader["LastName"] != DBNull.Value)
                    _personLanguages.LastName = Convert.ToString(reader["LastName"]);
                if (reader["Suffix"] != DBNull.Value)
                    _personLanguages.Suffix = Convert.ToString(reader["Suffix"]);
                if (reader["DisplayName"] != DBNull.Value)
                    _personLanguages.DisplayName = Convert.ToString(reader["DisplayName"]);
                _person.PersonLanguages.Add(_personLanguages);
                #endregion

                #region Credentials
                BusinessLogicLayer.Entities.Persons.Credential _credential = new BusinessLogicLayer.Entities.Persons.Credential();
                if (reader["EmployeeId"] != DBNull.Value)
                    _credential.BusinessEntityId = Convert.ToInt32(reader["EmployeeId"]);
                if (reader["Username"] != DBNull.Value)
                    _credential.Username = Convert.ToString(reader["Username"]);
                
                if (reader["IsActivated"] != DBNull.Value)
                    _credential.IsActivated = Convert.ToBoolean(reader["IsActivated"]);
                if (reader["IsActive"] != DBNull.Value)
                    _credential.IsActive = Convert.ToBoolean(reader["IsActive"]);
                _person.Credentials = _credential;
                #endregion
                _employees.EmployeePerson = _person;
                #endregion

                #region Departments
                Departments _departments = new Departments();
                #region Department Info
                if (reader["DepartmentId"] != DBNull.Value)
                    _departments.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                if (reader["OrganizationId"] != DBNull.Value)
                    _departments.OrganizationId = Convert.ToInt32(reader["OrganizationId"]);
                if (reader["DepartmentName"] != DBNull.Value)
                    _departments.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                if (reader["DepartmentDescription"] != DBNull.Value)
                    _departments.DepartmentDescription = Convert.ToString(reader["DepartmentDescription"]);
               
                #endregion
                #region Organization
                Organizations _organizations = new Organizations();
                if (reader["OrganizationId"] != DBNull.Value)
                    _organizations.OrganizationId = Convert.ToInt32(reader["OrganizationId"]);
                if (reader["OrganizationName"] != DBNull.Value)
                    _organizations.OrganizationName = Convert.ToString(reader["OrganizationName"]);
                if (reader["OrganizationDescription"] != DBNull.Value)
                    _organizations.OrganizationDescription = Convert.ToString(reader["OrganizationDescription"]);
                _departments.Organization = _organizations;
                #endregion
                _employees.Department = _departments;
                #endregion

                #region Division
                Divisions _divisions = new Divisions();
                if (reader["DivisionId"] != DBNull.Value)
                    _divisions.DivisionId = Convert.ToInt32(reader["DivisionId"]);
                if (reader["DepartmentId"] != DBNull.Value)
                    _divisions.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                if (reader["DivisionName"] != DBNull.Value)
                    _divisions.DivisionName = Convert.ToString(reader["DivisionName"]);
                if (reader["DivisionDescription"] != DBNull.Value)
                    _divisions.DivisionDescription = Convert.ToString(reader["DivisionDescription"]);
                _employees.Division = _divisions;
                #endregion


                _employeesList.Add(_employees);
            } reader.Close();
            return _employeesList;
        }

        #region Insert And Update
		public bool Insert(Employees employees)
		{
			EmployeesDAC employeesComponent = new EmployeesDAC();
			return employeesComponent.InsertNewEmployees( employees.EmployeeId,  employees.EmployeeNumber,  employees.DepartmentId,  employees.DivisionId,  employees.FormalSiteUrl,  employees.NationalIdNumber,  employees.NationalIdType,  employees.ManagerId,  employees.BirthDate,  employees.MaritalStatus,  employees.Gender,  employees.HireDate,  employees.SalariedFlag,  employees.VacationHours,  employees.SickLeaveHours,  employees.CurrentFlag,  employees.RowGuid,  employees.ModifiedDate,  employees.Position);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int EmployeeId,  string EmployeeNumber,  int DepartmentId,  int DivisionId,  string FormalSiteUrl,  string NationalIdNumber,  string NationalIdType,  int ManagerId,  DateTime BirthDate,  string MaritalStatus,  string Gender,  DateTime HireDate,  bool SalariedFlag,  short VacationHours,  short SickLeaveHours,  bool CurrentFlag,  Guid RowGuid,  DateTime ModifiedDate,  string Position)
		{
			EmployeesDAC employeesComponent = new EmployeesDAC();
			return employeesComponent.InsertNewEmployees( EmployeeId,  EmployeeNumber,  DepartmentId,  DivisionId,  FormalSiteUrl,  NationalIdNumber,  NationalIdType,  ManagerId,  BirthDate,  MaritalStatus,  Gender,  HireDate,  SalariedFlag,  VacationHours,  SickLeaveHours,  CurrentFlag,  RowGuid,  ModifiedDate,  Position);
		}
		public bool Update(Employees employees ,int old_employeeId)
		{
			EmployeesDAC employeesComponent = new EmployeesDAC();
			return employeesComponent.UpdateEmployees( employees.EmployeeId,  employees.EmployeeNumber,  employees.DepartmentId,  employees.DivisionId,  employees.FormalSiteUrl,  employees.NationalIdNumber,  employees.NationalIdType,  employees.ManagerId,  employees.BirthDate,  employees.MaritalStatus,  employees.Gender,  employees.HireDate,  employees.SalariedFlag,  employees.VacationHours,  employees.SickLeaveHours,  employees.CurrentFlag,  employees.RowGuid,  employees.ModifiedDate,  employees.Position,  old_employeeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int EmployeeId,  string EmployeeNumber,  int DepartmentId,  int DivisionId,  string FormalSiteUrl,  string NationalIdNumber,  string NationalIdType,  int ManagerId,  DateTime BirthDate,  string MaritalStatus,  string Gender,  DateTime HireDate,  bool SalariedFlag,  short VacationHours,  short SickLeaveHours,  bool CurrentFlag,  Guid RowGuid,  DateTime ModifiedDate,  string Position,  int Original_EmployeeId)
		{
			EmployeesDAC employeesComponent = new EmployeesDAC();
			return employeesComponent.UpdateEmployees( EmployeeId,  EmployeeNumber,  DepartmentId,  DivisionId,  FormalSiteUrl,  NationalIdNumber,  NationalIdType,  ManagerId,  BirthDate,  MaritalStatus,  Gender,  HireDate,  SalariedFlag,  VacationHours,  SickLeaveHours,  CurrentFlag,  RowGuid,  ModifiedDate,  Position,  Original_EmployeeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_EmployeeId)
		{
			EmployeesDAC employeesComponent = new EmployeesDAC();
			employeesComponent.DeleteEmployees(Original_EmployeeId);
		}

        #endregion
         public Employees GetByID(int _employeeId)
         {
             EmployeesDAC _employeesComponent = new EmployeesDAC();
             IDataReader reader = _employeesComponent.GetByIDEmployees(_employeeId);
             Employees _employees = null;
             while(reader.Read())
             {
                 _employees = new Employees();
                 if(reader["EmployeeId"] != DBNull.Value)
                     _employees.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                 if(reader["EmployeeNumber"] != DBNull.Value)
                     _employees.EmployeeNumber = Convert.ToString(reader["EmployeeNumber"]);
                 if(reader["DepartmentId"] != DBNull.Value)
                     _employees.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                 if(reader["DivisionId"] != DBNull.Value)
                     _employees.DivisionId = Convert.ToInt32(reader["DivisionId"]);
                 if(reader["FormalSiteUrl"] != DBNull.Value)
                     _employees.FormalSiteUrl = Convert.ToString(reader["FormalSiteUrl"]);
                 if(reader["NationalIdNumber"] != DBNull.Value)
                     _employees.NationalIdNumber = Convert.ToString(reader["NationalIdNumber"]);
                 if(reader["NationalIdType"] != DBNull.Value)
                     _employees.NationalIdType = Convert.ToString(reader["NationalIdType"]);
                 if(reader["ManagerId"] != DBNull.Value)
                     _employees.ManagerId = Convert.ToInt32(reader["ManagerId"]);
                 if(reader["BirthDate"] != DBNull.Value)
                     _employees.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                 if(reader["MaritalStatus"] != DBNull.Value)
                     _employees.MaritalStatus = Convert.ToString(reader["MaritalStatus"]);
                 if(reader["Gender"] != DBNull.Value)
                     _employees.Gender = Convert.ToString(reader["Gender"]);
                 if(reader["HireDate"] != DBNull.Value)
                     _employees.HireDate = Convert.ToDateTime(reader["HireDate"]);
                 if(reader["SalariedFlag"] != DBNull.Value)
                     _employees.SalariedFlag = Convert.ToBoolean(reader["SalariedFlag"]);
                 if(reader["VacationHours"] != DBNull.Value)
                     _employees.VacationHours = Convert.ToInt16(reader["VacationHours"]);
                 if(reader["SickLeaveHours"] != DBNull.Value)
                     _employees.SickLeaveHours = Convert.ToInt16(reader["SickLeaveHours"]);
                 if(reader["CurrentFlag"] != DBNull.Value)
                     _employees.CurrentFlag = Convert.ToBoolean(reader["CurrentFlag"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _employees.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _employees.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                 if(reader["Position"] != DBNull.Value)
                     _employees.Position = Convert.ToString(reader["Position"]);
             _employees.NewRecord = false;             }             reader.Close();
             return _employees;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			EmployeesDAC employeescomponent = new EmployeesDAC();
			return employeescomponent.UpdateDataset(dataset);
		}



	}
}
