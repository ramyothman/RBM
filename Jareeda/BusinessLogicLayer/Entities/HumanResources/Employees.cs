using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace BusinessLogicLayer.Entities.HumanResources
{
	/// <summary>
	/// This is a Business Entity Class  for Employees table
	/// </summary>

    [DataObject(true)]
	public class Employees : Entity
	{
		public Employees(){}

		/// <summary>
		/// This Property represents the EmployeeId which has int type
		/// </summary>
		private int _employeeId;
        [DataObjectField(true,false,false)]
		public int EmployeeId
		{
            get 
            {
              return _employeeId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _employeeId != value)
                     RBMDataChanged = true;
                _employeeId = value;
            }
		}

        private Persons.Person _EmployeePerson = null;
        public Persons.Person EmployeePerson
        {
            set { _EmployeePerson = value; }
            get 
            {
                if (_EmployeePerson == null)
                {
                    _EmployeePerson = BusinessLogicLayer.Common.PersonLogic.GetByID(EmployeeId);
                    if (_EmployeePerson == null)
                    {
                        _EmployeePerson = new Persons.Person();
                    }
                }
                return _EmployeePerson;
            }
        }

        #region  Wrapped Info
        public string DisplayName
        {
            get
            {
                return EmployeePerson.DisplayName;
            }
        }

        public string UserName
        {
            get
            {
                return EmployeePerson.UserName;
            }
        }

        public string DepartmentName
        {
            get
            {
                return Department.DepartmentName;
            }
        }

        public string OrganizationName
        {
            get
            {
                return Department.Organization.OrganizationName;
            }
        }

        public string DivisionName
        {
            get
            {
                return Division.DivisionName;
            }
        }

        public string EmployeeImage
        {
            get
            {
                return EmployeePerson.PersonImage;
            }
        }
        #endregion

        /// <summary>
		/// This Property represents the EmployeeNumber which has nvarchar type
		/// </summary>
		private string _employeeNumber = "";
        [DataObjectField(false,false,true,50)]
		public string EmployeeNumber
		{
            get 
            {
              return _employeeNumber;
            }
            set 
            {
                if (!RBMInitiatingEntity && _employeeNumber != value)
                     RBMDataChanged = true;
                _employeeNumber = value;
            }
		}

		/// <summary>
		/// This Property represents the DepartmentId which has int type
		/// </summary>
		private int _departmentId;
        [DataObjectField(false,false,true)]
		public int DepartmentId
		{
            get 
            {
              return _departmentId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _departmentId != value)
                     RBMDataChanged = true;
                _departmentId = value;
            }
		}

        private Departments _Department = null;
        public Departments Department
        {
            set { _Department = value; }
            get 
            {
                if (_Department == null)
                {
                    _Department = new BusinessLogicLayer.Components.HumanResources.DepartmentsLogic().GetByID(DepartmentId);
                    if (_Department == null)
                        _Department = new Departments();
                }
                return _Department;
            }
        }

        

		/// <summary>
		/// This Property represents the DivisionId which has int type
		/// </summary>
		private int _divisionId;
        [DataObjectField(false,false,true)]
		public int DivisionId
		{
            get 
            {
              return _divisionId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _divisionId != value)
                     RBMDataChanged = true;
                _divisionId = value;
            }
		}

        private Divisions _Division = null;
        public Divisions Division
        {
            set { _Division = value; }
            get
            {
                if (_Division == null)
                {
                    _Division = new BusinessLogicLayer.Components.HumanResources.DivisionsLogic().GetByID(DivisionId);
                    if (_Division == null)
                        _Division = new Divisions();
                }
                return _Division;
            }
        }

        

		/// <summary>
		/// This Property represents the FormalSiteUrl which has nvarchar type
		/// </summary>
		private string _formalSiteUrl = "";
        [DataObjectField(false,false,true,250)]
		public string FormalSiteUrl
		{
            get 
            {
              return _formalSiteUrl;
            }
            set 
            {
                if (!RBMInitiatingEntity && _formalSiteUrl != value)
                     RBMDataChanged = true;
                _formalSiteUrl = value;
            }
		}

		/// <summary>
		/// This Property represents the NationalIdNumber which has nvarchar type
		/// </summary>
		private string _nationalIdNumber = "";
        [DataObjectField(false,false,true,50)]
		public string NationalIdNumber
		{
            get 
            {
              return _nationalIdNumber;
            }
            set 
            {
                if (!RBMInitiatingEntity && _nationalIdNumber != value)
                     RBMDataChanged = true;
                _nationalIdNumber = value;
            }
		}

		/// <summary>
		/// This Property represents the NationalIdType which has nchar type
		/// </summary>
		private string _nationalIdType = "";
        [DataObjectField(false,false,true,1)]
		public string NationalIdType
		{
            get 
            {
              return _nationalIdType;
            }
            set 
            {
                if (!RBMInitiatingEntity && _nationalIdType != value)
                     RBMDataChanged = true;
                _nationalIdType = value;
            }
		}

		/// <summary>
		/// This Property represents the ManagerId which has int type
		/// </summary>
		private int _managerId;
        [DataObjectField(false,false,true)]
		public int ManagerId
		{
            get 
            {
              return _managerId;
            }
            set 
            {
                if (!RBMInitiatingEntity && _managerId != value)
                     RBMDataChanged = true;
                _managerId = value;
            }
		}

		/// <summary>
		/// This Property represents the BirthDate which has datetime type
		/// </summary>
		private DateTime _birthDate;
        [DataObjectField(false,false,true)]
		public DateTime BirthDate
		{
            get 
            {
              return _birthDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _birthDate != value)
                     RBMDataChanged = true;
                _birthDate = value;
            }
		}

		/// <summary>
		/// This Property represents the MaritalStatus which has nchar type
		/// </summary>
		private string _maritalStatus = "";
        [DataObjectField(false,false,true,1)]
		public string MaritalStatus
		{
            get 
            {
              return _maritalStatus;
            }
            set 
            {
                if (!RBMInitiatingEntity && _maritalStatus != value)
                     RBMDataChanged = true;
                _maritalStatus = value;
            }
		}

		/// <summary>
		/// This Property represents the Gender which has nchar type
		/// </summary>
		private string _gender = "";
        [DataObjectField(false,false,true,1)]
		public string Gender
		{
            get 
            {
              return _gender;
            }
            set 
            {
                if (!RBMInitiatingEntity && _gender != value)
                     RBMDataChanged = true;
                _gender = value;
            }
		}

		/// <summary>
		/// This Property represents the HireDate which has datetime type
		/// </summary>
		private DateTime _hireDate;
        [DataObjectField(false,false,true)]
		public DateTime HireDate
		{
            get 
            {
              return _hireDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _hireDate != value)
                     RBMDataChanged = true;
                _hireDate = value;
            }
		}

		/// <summary>
		/// This Property represents the SalariedFlag which has bit type
		/// </summary>
		private bool _salariedFlag;
        [DataObjectField(false,false,true)]
		public bool SalariedFlag
		{
            get 
            {
              return _salariedFlag;
            }
            set 
            {
                if (!RBMInitiatingEntity && _salariedFlag != value)
                     RBMDataChanged = true;
                _salariedFlag = value;
            }
		}

		/// <summary>
		/// This Property represents the VacationHours which has smallint type
		/// </summary>
		private short _vacationHours;
        [DataObjectField(false,false,true)]
		public short VacationHours
		{
            get 
            {
              return _vacationHours;
            }
            set 
            {
                if (!RBMInitiatingEntity && _vacationHours != value)
                     RBMDataChanged = true;
                _vacationHours = value;
            }
		}

		/// <summary>
		/// This Property represents the SickLeaveHours which has smallint type
		/// </summary>
		private short _sickLeaveHours;
        [DataObjectField(false,false,true)]
		public short SickLeaveHours
		{
            get 
            {
              return _sickLeaveHours;
            }
            set 
            {
                if (!RBMInitiatingEntity && _sickLeaveHours != value)
                     RBMDataChanged = true;
                _sickLeaveHours = value;
            }
		}

		/// <summary>
		/// This Property represents the CurrentFlag which has bit type
		/// </summary>
		private bool _currentFlag;
        [DataObjectField(false,false,true)]
		public bool CurrentFlag
		{
            get 
            {
              return _currentFlag;
            }
            set 
            {
                if (!RBMInitiatingEntity && _currentFlag != value)
                     RBMDataChanged = true;
                _currentFlag = value;
            }
		}

		/// <summary>
		/// This Property represents the RowGuid which has uniqueidentifier type
		/// </summary>
		private Guid _rowGuid;
        [DataObjectField(false,false,true)]
		public Guid RowGuid
		{
            get 
            {
              return _rowGuid;
            }
            set 
            {
                if (!RBMInitiatingEntity && _rowGuid != value)
                     RBMDataChanged = true;
                _rowGuid = value;
            }
		}

		/// <summary>
		/// This Property represents the ModifiedDate which has datetime type
		/// </summary>
		private DateTime _modifiedDate;
        [DataObjectField(false,false,true)]
		public DateTime ModifiedDate
		{
            get 
            {
              return _modifiedDate;
            }
            set 
            {
                if (!RBMInitiatingEntity && _modifiedDate != value)
                     RBMDataChanged = true;
                _modifiedDate = value;
            }
		}

		/// <summary>
		/// This Property represents the Position which has nvarchar type
		/// </summary>
		private string _position = "";
        [DataObjectField(false,false,true,150)]
		public string Position
		{
            get 
            {
              return _position;
            }
            set 
            {
                if (!RBMInitiatingEntity && _position != value)
                     RBMDataChanged = true;
                _position = value;
            }
		}


	}
}
